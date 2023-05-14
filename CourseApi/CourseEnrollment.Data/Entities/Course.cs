namespace CourseEnrollment.Data.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public int Credit { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
