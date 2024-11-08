using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Academy.Services.CourseAPI.Models
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Level { get; set; }
        public string ImagePath { get; set; }
    }
}

//DBCC CHECKIDENT ('Courses', RESEED, 0);