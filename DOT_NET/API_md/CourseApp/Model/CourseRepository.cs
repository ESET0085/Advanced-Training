namespace CourseApp.Model
{
    public class CourseRepository
    {
        public static List<Course> course { get; set; } = new List<Course>()
        {
            new Course()
            {
                Id= 1,
                Name="Maths"
            },
            new Course()
            {
                Id= 2,
                Name = "Science"
            }
        };
    }
}
