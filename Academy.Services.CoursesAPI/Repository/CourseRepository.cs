using Academy.Services.CourseAPI.DbContexts;
using Academy.Services.CourseAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Academy.Services.CourseAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private IMapper _mapper; 

        public CourseRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CourseDto> CreareUpdateCourse(CourseDto courseDto)
        {
            var courseEntity = await _dbContext.Courses.Where(x => x.CourseId == courseDto.CourseId).FirstOrDefaultAsync();
            if (courseEntity == null)
            {
                courseEntity = new Course
                {

                    CourseName = courseDto.CourseName,
                    CourseDescription = courseDto.CourseDescription,
                    StartDate = courseDto.StartDate,
                    EndDate = courseDto.EndDate,
                    Level = courseDto.Level,
                    ImagePath = courseDto.ImagePath,
                };
                await _dbContext.Courses.AddAsync(courseEntity);
            }
            else 
            {
                courseEntity.CourseName = courseDto.CourseName;
                courseEntity.CourseDescription = courseDto.CourseDescription;
                courseEntity.StartDate = courseDto.StartDate;
                courseEntity.EndDate = courseDto.EndDate;
                courseEntity.Level = courseDto.Level;
                courseEntity.ImagePath = courseDto.ImagePath;
                _dbContext.Courses.Update(courseEntity);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CourseDto>(courseEntity);
            
        }

        public async Task<bool> DeleteCourseById(int id)
        {
                Course? course = await _dbContext.Courses.Where(X => X.CourseId == id).FirstOrDefaultAsync();
                if (course == null) 
                {
                    return false; 
                }
                _dbContext.Courses.Remove(course);
                await _dbContext.SaveChangesAsync();
                return true;
        }

        public async Task<CourseDto> GetCourseById(int Id)
        {
            Course? course = await _dbContext.Courses.Where(x=> x.CourseId == Id).FirstOrDefaultAsync();
            return _mapper.Map<CourseDto>(course);
        }

   
        public async Task<List<CourseDto>> GetCourseByTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) { return new List<CourseDto>(); }
            List<Course> courses = await _dbContext.Courses.Where(t=>t.CourseName.ToLower() == title.ToLower()).ToListAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }

        public async Task<List<CourseDto>> GetCourses()
        {
            List<Course> courses = await _dbContext.Courses.ToListAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }
    }
}
