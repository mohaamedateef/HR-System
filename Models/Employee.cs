namespace HRSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        [Column(TypeName = "money")]
        public double NetSalary { get; set; }
        public string Nationality { get; set; }
        public int NationalId { get; set; }
        public string Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ContractDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<Salary>? Salary { get; set; }
        public virtual List<Attendance>? Attendance { get; set; }
        public virtual List<Exception>? Exceptions { get; set; }
    }
}
