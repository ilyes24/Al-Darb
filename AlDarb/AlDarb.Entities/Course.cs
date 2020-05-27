namespace AlDarb.Entities
{
    public class Course : DeletableEntity
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }
    }
}
