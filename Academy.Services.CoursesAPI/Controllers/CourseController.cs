using Academy.Services.CourseAPI.Models;
using Academy.Services.CourseAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Services.CourseAPI.Controllers
{
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {

        protected ResponseDto _response;
        private ICourseRepository _courseRepository;


        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> GetAll()
        {
            try
            {
                List<CourseDto> courses = await _courseRepository.GetCourses();
                _response.Result = courses;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Errors = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<object> GetById(int id)
        {
            try
            {
                CourseDto course = await _courseRepository.GetCourseById(id);
                if (course == null) {
                    return NotFound(new { Succes = false, Message = "Курс не найден" });
                }

                return Ok(new { Success = true, Message = "Курс был найден " + id, Data = course });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Succes = false, Message = "Серверная ошибка", Error = ex.Message });

            }

        }

        [HttpGet]
        [Route("byitle{title}")]
        public async Task<object> GetByTitle(string title) 
        {
            try
            {
                List<CourseDto> course = await _courseRepository.GetCourseByTitle(title);
                _response.Result = course;
            }
            catch (Exception ex)
            {
                _response.isSuccess=false;
                _response.Errors = new List<string>() {ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        public async Task<object> CreateUpdate([FromBody] CourseDto course) 
        {
            try
            {
                CourseDto courseDto = await _courseRepository.CreareUpdateCourse(course);
                return Ok(new { Success = true, Message = "Успех", Data = courseDto}); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "ошибка создания курса",Error = ex.ToString() });
                
            }
        }
        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool courseDto = await _courseRepository.DeleteCourseById(id);
                if(!courseDto)
                    {
                    return NotFound(new { Success = false, Message = "Курс не найден" });                
                    }
                return Ok(new { Success = true, Message = "Успех, курс удален", Data = courseDto });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "Ошибка удаления курса", Error = ex.ToString() });

            }
        }




    }
}
