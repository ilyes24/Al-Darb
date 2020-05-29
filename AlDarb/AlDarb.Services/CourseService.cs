﻿using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Utils;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class CourseService<TCourse> : BaseService, ICourseService where TCourse : Course, new()
    {
        protected readonly ICourseRepository<TCourse> courseRepository;

        public CourseService(ICurrentContextProvider contextProvider, ICourseRepository<TCourse> courseRepository) : base(contextProvider)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<bool> Delete(int id)
        {
            await courseRepository.Delete(id, Session);
            return true;
        }

        public async Task<CourseDTO> Edit(CourseDTO dto)
        {
            var course = dto.MapTo<TCourse>();
            await courseRepository.Edit(course, Session);
            return course.MapTo<CourseDTO>();
        }

        public async Task<CourseDTO> GetById(int id, bool includeDeleted = false)
        {
            var course = await courseRepository.Get(id, Session, includeDeleted);
            return course.MapTo<CourseDTO>();
        }

        public async Task<CourseDTO> GetByName(string name, bool includeDeleted = false)
        {
            var course = await courseRepository.GetByName(name, Session, includeDeleted);
            return course.MapTo<CourseDTO>();
        }

        public async Task<CourseDTO> GetByUserId(int userId, bool includeDeleted = false)
        {
            var course = await courseRepository.GetByUserId(userId, Session, includeDeleted);
            return course.MapTo<CourseDTO>();
        }
    }
}