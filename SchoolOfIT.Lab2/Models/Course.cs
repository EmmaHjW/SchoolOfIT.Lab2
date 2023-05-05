namespace SchoolOfIT.Lab2.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<RelationTable>? Relations { get; set; }
    }
}
