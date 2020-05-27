namespace AlDarb.Entities
{
    public class CourseTask : DeletableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Difficulty { get; set; }

        public virtual Course Course { get; set; }
    }
}
