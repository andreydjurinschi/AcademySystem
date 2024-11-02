namespace Academy.Services.CourseAPI.Models
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; } = true;
        public object Result { get; set; }
        public List<string> Errors { get; set; }
        public string message { get; set; } = "";

    }
}
