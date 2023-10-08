using System;

namespace DoublyLinkedLists
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class Employee : IComparable<Employee>
    {
        /// <summary>
        /// Initializes an instance of Employee with an employee id, a first name and a last name.
        /// </summary>
        /// <param name="employeeId">The employee id for the employee.</param>
        /// <param name="firstName">The first name of the employee.</param>
        /// <param name="lastName">The last name of the employee.</param>
        public Employee(int employeeId, string firstName, string lastName)
        {
            this.EmployeeID = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Initializes an instance of Employee with an employee id, no first name and last name.
        /// </summary>
        /// <param name="employeeId">The employee id for the employee.</param>
        public Employee(int employeeId) : this(employeeId, null, null)
        {
            
        }

        /// <summary>
        /// Gets or sets the id of the employee.
        /// </summary>
        public int EmployeeID
        {
            get; set;
        }

        /// <summary>
        /// Gets the first name of the employee.
        /// </summary>
        public string FirstName
        {
            get;
        }

        /// <summary>
        /// Gets the last name of the employee.
        /// </summary>
        public string LastName
        {
            get;
        }

        /// <summary>
        /// Returns a negative integer number if the employeeId of this instance is less than
        /// the employeeId of the other, 0 if equal, and postive if greater.
        /// </summary>
        /// <param name="other">The other instance of Employee</param>
        /// <returns>The integer number</returns>
        public int CompareTo(Employee other)
        {
            return this.EmployeeID.CompareTo(other.EmployeeID);
        }

        /// <summary>
        /// Returns a custom string representation of an instance of Employee.
        /// </summary>
        /// <returns>The custom string representation.</returns>
        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.EmployeeID, this.FirstName ?? "null", this.LastName ?? "null");
        }
    }
}