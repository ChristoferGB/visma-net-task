namespace API.DTOs.Requests
{
    public class EmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int? BossId { get; set; }
        public string HomeAddress { get; set; }
        public float Salary { get; set; }
        public int Role { get; set; }
    }
}