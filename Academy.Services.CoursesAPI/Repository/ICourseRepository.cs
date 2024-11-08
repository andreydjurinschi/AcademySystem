using Academy.Services.CourseAPI.Models;

namespace Academy.Services.CourseAPI.Repository
{
    public interface ICourseRepository
    {
        Task<List<CourseDto>> GetCourses();
        Task<CourseDto> CreareUpdateCourse(CourseDto course);
        Task<List<CourseDto>> GetCourseByTitle(string title);
        Task<CourseDto> GetCourseById(int Id);
        Task<bool> DeleteCourseById(int id);
        
    }
}
