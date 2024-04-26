using API.Exceptions;

namespace API.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EmploymentDate { get; set; }
        //public Employee? Boss { get; set; }
        public string HomeAddress { get; set; }
        public float Salary { get; set; }
        public RoleEnum Role { get; set; }

        public Employee(string firstName, string lastName, DateTime birthday, DateTime employmentDate, string homeAddress, float salary, RoleEnum role)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            EmploymentDate = employmentDate;
            //Boss = boss;
            HomeAddress = homeAddress;
            Salary = salary;
            Role = role;
        }

        public void SetFirstName(string firstName)
        {
            if(string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));

            if(firstName.Length > 50)
                throw new ArgumentOutOfRangeException(nameof(firstName));

            if (!string.IsNullOrEmpty(LastName) && LastName == firstName)
                throw new FirstAndLastNamesEqualsException("First and Last names should not be equal");

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));

            if (lastName.Length > 50)
                throw new ArgumentOutOfRangeException(nameof(lastName));

            if (!string.IsNullOrEmpty(FirstName) && FirstName == lastName)
                throw new FirstAndLastNamesEqualsException("First and Last names should not be equal");

            LastName = lastName;
        }

        public void SetBirthday(DateTime birthday)
        {
            //if( - birthday)

            Birthday = birthday.Date;
        }

        public void SetEmploymentDate(DateTime employmentDate)
        {
            if (employmentDate > DateTime.Now)
                throw new EmploymentDateOutOfRangeException("Employment date cannot be a future date");

            if(employmentDate < new DateTime(2000, 01, 01))
                throw new EmploymentDateOutOfRangeException("Employment date cannot be earlier than 2000-01-01");

            EmploymentDate = employmentDate;
        }

        // public void SetBoss(Employee boss)
        // {
        //     Boss = boss;
        // }

        public void SetHomeAddres(string homeAddres)
        {
            HomeAddress = homeAddres;
        }

        public void SetSalary(float salary)
        {
            if (salary < 0)
                throw new InvalidDataException("Salaray must be non-negative");

            Salary = salary;
        }

        public void SetRole(RoleEnum role)
        {
            Role = role;
        }
    }
}
