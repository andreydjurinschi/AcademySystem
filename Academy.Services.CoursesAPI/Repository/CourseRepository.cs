using Academy.Services.CourseAPI.DbContexts;
using Academy.Services.CourseAPI.Models;
using AutoMapper;
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
            Course course = _mapper.Map<CourseDto, Course>(courseDto);
            if (course.CourseId > 0) 
            {
                _dbContext.Courses.Update(course);
            }
            else 
            {
                _dbContext.Courses.Add(course);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Course, CourseDto>(course);

        }

        public async Task<bool> DeleteCourseById(int id)
        {
            try
            {
                Course? course = await _dbContext.Courses.Where(X => X.CourseId == id).FirstOrDefaultAsync();
                if (course == null) { return false; }
                _dbContext.Courses.Remove(course);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
              return false;
            }
        }

        public async Task<CourseDto> GetCourseById(int Id)
        {
            Course? course = await _dbContext.Courses.Where(x=> x.CourseId == Id).FirstOrDefaultAsync();
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<List<CourseDto>> GetCourseByLevel(string level)
        {
            List<Course> courses = await _dbContext.Courses.Where(l => l.Level == level).ToListAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }

        
        public async Task<List<CourseDto>> GetCourseByTitle(string title)
        {
            List<Course> courses = await _dbContext.Courses.Where(t=>t.CourseName == title).ToListAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }

        public async Task<List<CourseDto>> GetCourses()
        {
            List<Course> courses = await _dbContext.Courses.ToListAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }
    }
}
