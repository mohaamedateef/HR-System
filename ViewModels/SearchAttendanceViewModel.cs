namespace HRSystem.ViewModels
{
    public class SearchAttendanceViewModel
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Remote("CheckSearchDate","Attendance",AdditionalFields = "EndDate", ErrorMessage = "Invalid Start Date or End Date")]
        [Required(ErrorMessage ="This field is required")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        
        public DateTime EndDate { get; set; }
    }
}
