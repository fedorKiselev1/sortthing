using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace classes
{
    public class Firm
    {
        public Firm(string name,List<Section> sectionList) 
        {
            Name = name;
            SectionList = sectionList;
        }
        public string Name { get; set; }
        public List<Section> SectionList { get; set; }
    }

    public class Section
    {
        public Section(string name, List<Employee> employeeList)
        {
            Name = name;
            EmployeeList = employeeList;
            EmployeeCount = employeeList.Count;
        }

        public string Name { get; set; }
        public int EmployeeCount { get; set; }
        public List<Employee> EmployeeList { get; set; }

        public void UpdateCount()
        {
            EmployeeCount = EmployeeList.Count;
        }
    }

    public class Employee
    {
        public Employee(string name, string duty, int salary)
        {
            Name = name;
            Duty = duty;
            Salary = salary;
        }

        public string Name { get; set; }
        public string Duty { get; set; }
        public int Salary { get; set; }
        public virtual int CalculateSalary()
        {
            return Salary;
        }
    }

    public class FullTimer : Employee
    {
        public FullTimer(string name, string duty, int salary, int prize) : base(name, duty, salary)
        {
            Name = name;
            Duty = duty;
            Salary = salary;
            Prize = prize;
        }

        public int Prize { get; set; }
        public override int CalculateSalary()
        {
            return base.CalculateSalary() + Prize;
        }
    }

    public class Contracter : Employee
    {
        public Contracter(string name, string duty, int salary) : base(name, duty, salary)
        {
            Name = name;
            Duty = duty;
            Salary = salary;
        }
         public override int CalculateSalary()
        {
            return base.CalculateSalary() / 2; 
        }
    }
}
