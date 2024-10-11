namespace ManageCourses.Models
{
    public class CourseVm
    {
        public List<MonHoc> Subjects { get; set; } = new List<MonHoc>();

        public List<KhoaHoc> Courses { get; set; } = new List<KhoaHoc>();
    }
}
