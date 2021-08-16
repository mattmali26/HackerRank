using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesManagement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Company { get; set; }
        }

        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            return employees.GroupBy(x => x.Company)
                .Select(x => new { Company = x.Key, AverageAge = (int)Math.Round(employees.Where(e => e.Company.Equals(x.Key)).Average(e => e.Age), 0) })
                .OrderBy(x => x.Company).ToDictionary(x => x.Company, x => x.AverageAge);
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            return employees.GroupBy(x => x.Company).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Count());
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            var oldestGroups = employees.GroupBy(x => x.Company).Select(x => new
            {
                Company = x.Key,
                OldestAge = employees.Where(e => e.Company.Equals(x.Key)).Max(a => a.Age)
            }).ToDictionary(x => x.Company, x => x.OldestAge);

            return employees.GroupBy(x => x.Company).Select(x => new
            {
                Company = x.Key,
                OldestEmployee = employees.Where(e => e.Company.Equals(x.Key) && e.Age.Equals(oldestGroups[x.Key])).FirstOrDefault()
            }).OrderBy(x => x.Company).ToDictionary(x => x.Company, x => x.OldestEmployee);
        }
    }
}