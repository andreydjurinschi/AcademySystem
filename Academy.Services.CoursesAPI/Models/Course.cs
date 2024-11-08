using System.ComponentModel.DataAnnotations;
namespace Academy.Services.CourseAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Название курса не должно превышать 100 символов")]
        public string CourseName { get; set; }

        [StringLength(500, ErrorMessage = "Описание курса не должно превышать 500 символов")]
        public string CourseDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Level { get; set; }

        public string ImagePath { get; set; }
    }
}
