namespace CourseEnrollment.Data.Entities
{
    public class Student : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StudentId { get; set; }
    }
}
