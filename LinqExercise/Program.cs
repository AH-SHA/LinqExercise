using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var numSum = numbers.Sum();
            Console.WriteLine("Sum: " + numSum);

            //TODO: Print the Average of numbers
            var numAvg = numbers.Average();
            Console.WriteLine("Average: " + numAvg);

            //TODO: Order numbers in ascending order and print to the console
            var numAscend = from num in numbers orderby num ascending select num;
            foreach (var numAsc in numAscend)
                Console.Write(numAsc + ", ");
            Console.WriteLine("");

            // Alternative Method to Sort Ascend:   var ascend = numbers.OrderBy(num => num);
            //Alternative Method to Sort Descend:   var descend = numbers.OrderbyDescending(x => x);

            //TODO: Order numbers in descending order and print to the console

            var numDescend = from num in numbers orderby num descending select num;
            foreach (var numDesc in numDescend)
                Console.Write(numDesc + ", ");
            Console.WriteLine("");


            //TODO: Print to the console only the numbers greater than 6
            IEnumerable<int> numOverSix = from num in numbers where (num > 6) select num;
            foreach (var num6 in numOverSix)
            {
                Console.Write(num6 + " ");
            }
            Console.WriteLine("");

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Print Only 4 Numbers");
            var numDescend2 = from num in numbers orderby num descending select num;

            // Used the Take() method within a foreach loop to choose only a specified number of observations w/in the variable.
            foreach (var num4 in numDescend2.Take(4))
                Console.Write(num4 + " ");
            Console.WriteLine("");

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            Console.WriteLine("New Value in num Array");

            numbers[4] = 28;
            foreach (var numChange in numbers.OrderByDescending(num => num))
            {
                Console.Write(numChange + " ");
            }
            Console.WriteLine(" ");




            // List of employees ****Do not remove this****
                var employees = CreateEmployees();

            //Example Syntax - OrderBy x.ColumnName
            //NOTES: employees or things in a table may be objects and objects have properties, so the LINQ commands slightly differ
            //Notes: strings can be treated ike arrays since they are character arrays

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            
            Console.WriteLine(" ");
            var changeFullName = employees.Where(x => x.FirstName[0] == 'C' || x.FirstName[0] == 'S').OrderBy(x => x.FirstName);
            //Alternative (...Where(x => x.FirstName.StartsWith('C'), etc.
           
            Console.WriteLine("Ony 'S' or 'C' employees");
            foreach (var item in changeFullName)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine(" ");


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var over_26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);

            Console.WriteLine("Over 26 Employees");
            foreach(var p in over_26)
            {
                Console.WriteLine($" Name: {p.FullName} , Age: {p.Age}");
            }

            Console.WriteLine("");

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine("Sum of Years of Experience:");
            var yoeSum = employees.Where(y => y.YearsOfExperience <= 10 && y.Age > 35);

            Console.WriteLine( yoeSum.Sum( yoe => yoe.YearsOfExperience ) );
            Console.WriteLine("");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine("Average Years of Experience:");
            var yoeAvg = employees.Where(ya => ya.YearsOfExperience <= 10 && ya.Age > 35);

            Console.WriteLine(yoeAvg.Average(yoea => yoea.YearsOfExperience));
            Console.WriteLine("");

            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Adding New Employee Not Using .Add Method: ");
            employees = employees.Append(new Employee("Dude", "I-Work-Here", 59, 20)).ToList();

            foreach (var newEmp in employees)
            {
                Console.WriteLine($"{newEmp.FirstName} {newEmp.LastName} {newEmp.Age} {newEmp.YearsOfExperience }");
            }

            Console.WriteLine(" ");


Console.ReadLine();
}

#region CreateEmployeesMethod
private static List<Employee> CreateEmployees()
{
List<Employee> employees = new List<Employee>();
employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
employees.Add(new Employee("Steven", "Bustamento", 56, 5));
employees.Add(new Employee("Micheal", "Doyle", 36, 8));
employees.Add(new Employee("Daniel", "Walsh", 72, 22));
employees.Add(new Employee("Jill", "Valentine", 32, 43));
employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
employees.Add(new Employee("Big", "Boss", 23, 14));
employees.Add(new Employee("Solid", "Snake", 18, 3));
employees.Add(new Employee("Chris", "Redfield", 44, 7));
employees.Add(new Employee("Faye", "Valentine", 32, 10));

return employees;
}
#endregion
}
}
