using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee(123, "Cheng", "Wu");

            employee.EmployeeID = 321;
            Console.WriteLine(employee.EmployeeID);

            Console.ReadKey();
        }
    }
}