namespace HRSystem.Models
{
    public class Salary
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        public int OverTimeHours { get; set; }
        public int DiscountHours { get; set; }
        public int TotalSalary { get; set; }
        [ForeignKey("Employee")]
        public int? EmpId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
