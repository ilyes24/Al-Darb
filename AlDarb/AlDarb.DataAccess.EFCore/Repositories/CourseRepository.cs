using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using IronPython.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.DataAccess.EFCore.Repositories
{
    public class CourseRepository : BaseDeletableRepository<Course, DataContext>, ICourseRepository<Course>
    {
        private readonly DataContext _dbContext;
        public CourseRepository(DataContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Course>> GetByName(string name, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.Name == name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetByUserId(int userId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.User.Id == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetList(int? userId, string name, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();
            var courses = await entity.Where(obj => obj.Id > 0).ToListAsync();
            SaveToCsv<Course>(courses, Environment.CurrentDirectory + "/csv/course.csv");
            var ratings = _dbContext.Set<CourseRating>().AsQueryable();
            if (!includeDeleted)
            {
                ratings = ratings.Where(obj => !obj.IsDeleted);
            }

            var i = await ratings.Where(obj => obj.Id > 0).ToListAsync();
            SaveToCsv<CourseRating>(i, Environment.CurrentDirectory + "/csv/ratings_Final.csv");

            ScriptRuntimeSetup setup = Python.CreateRuntimeSetup(null);
            ScriptRuntime runtime = new ScriptRuntime(setup);
            ScriptEngine engine = Python.GetEngine(runtime);
            ICollection<string> searchPaths = engine.GetSearchPaths();
            searchPaths.Add("C:\\Users\\Admin\\PycharmProjects\\ArClassifier\\venv\\Lib");
            searchPaths.Add("C:\\Users\\Admin\\PycharmProjects\\ArClassifier\\venv\\Lib\\site-packages");
            engine.SetSearchPaths(searchPaths);
            ScriptSource source = engine.CreateScriptSourceFromFile(Environment.CurrentDirectory + "/CB_RS.py");
            ScriptScope scope = engine.CreateScope();
            List<String> argv = new List<String>();
            argv.Add(session.UserId.ToString());
            argv.Add(Environment.CurrentDirectory + "/csv/course.csv");
            argv.Add(Environment.CurrentDirectory + "/csv/ratings_Final.csv");
            engine.GetSysModule().SetVariable("argv", argv);
            try
            {
                var qq= source.Execute(scope);
                var qq2 = qq;
            }
            catch(Exception ex)
            {
                var error = ex;
            }

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }

        private void SaveToCsv<T>(List<T> reportData, string path)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            File.WriteAllLines(path, lines.ToArray());
        }
    }
}
