using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //basic_LINQ_Query_1()();

            //basic_LINQ_Query_2()();

            //basic_LINQ_Query_3()();

            //grouping_LINQ_Query();

            //joining_LINQ_Query();

            //group_Join_LINQ_Query();

            //lambda_Expressions_1();

            //lambda_Expressions_2();

            lambda_Expressions_3();

            Console.Read();
        }

        private static void basic_LINQ_Query_1()
        {
            string sentence = "I love cats";
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            //----------------------------------------------
            SeparatingLine();
            // 1. Simple Linq Example
            var simpleLinq = from s in sentence
                             select s;

            //Console.WriteLine(string.Join("", simpleLinq));

            //----------------------------------------------
            //SeparatingLine();
            // 2. Linq Example with Condition
            var lessThanFive = from num in numbers
                               where num < 5
                               select num;

            List<int> newNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (number < 5)
                {
                    newNumbers.Add(number);
                }
            }


            //Console.WriteLine(string.Join(", ", newNumbers));

            //Console.WriteLine(string.Join(", ", lessThanFive));

            //Console.WriteLine(lessThanFive);


            //----------------------------------------------
            //SeparatingLine();
            // 3. Linq Example with Multiple Conditions
            var lessThanFiveAndGreaterThanTen = from num in numbers
                                                where (num > 5) && (num < 10)
                                                select num;

            //Console.WriteLine(string.Join(", ", lessThanFiveAndGreaterThanTen));

            //----------------------------------------------
            //SeparatingLine();
            // 4. Linq Example with Contains
            var catsWithA = from cat in catNames
                            where cat.Contains("a")
                            select cat;

            //Console.WriteLine(string.Join(", ", catsWithA));

            //----------------------------------------------
            //SeparatingLine();
            // 5. Linq Example with Multiple Where
            var moreSpecificCats = from cat in catNames
                                   where cat.Contains("a")
                                   where cat.Length > 4
                                   select cat;

            //Console.WriteLine(string.Join(", ", moreSpecificCats));

            //----------------------------------------------
            //SeparatingLine();
            // 6. Linq Example with Ordering
            var orderedNumbers = from num in numbers
                                 where (num > 5) && (num < 10)
                                 orderby num // optional argument ascending or descending, ascending by default
                                 select num;

            //Console.WriteLine(string.Join(", ", orderedNumbers));
        }

        private static void basic_LINQ_Query_2()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tod", 180, 70, Gender.Male),
                new Person("John", 170, 88, Gender.Male),
                new Person("Anna", 150, 48, Gender.Female),
                new Person("Kyle", 164, 77, Gender.Male),
                new Person("Anna", 164, 77, Gender.Male),
                new Person("Maria", 160, 55, Gender.Female),
                new Person("John", 160, 55, Gender.Female)
            };


            //----------------------------------------------
            SeparatingLine();
            // 1. Linq Example with Objects
            var fourCharPeople = from p in people
                                 where (p.Name.Length == 4)
                                 select p;

            foreach (var p in fourCharPeople)
            {
                //Console.WriteLine(p.Name);
            }


            //----------------------------------------------
            //SeparatingLine();
            // 2. Linq Example with Objects Condition and Ordering
            var fourCharPeopleOrdered = from p in people
                                        where (p.Name.Length == 4)
                                        orderby p.Weight
                                        select p;

            foreach (var p in fourCharPeopleOrdered)
            {
                //Console.WriteLine(p.Name);
            }

            //----------------------------------------------
            //SeparatingLine();
            // 3. Linq Example Extracting Properties from Objects in a new collection
            var extractedNames = from p in people
                                 where (p.Name.Length == 4)
                                 select p.Name;

            foreach (var p in extractedNames)
            {
                // Console.WriteLine(p);
            }

            //----------------------------------------------
            //SeparatingLine();
            //4.Linq Example with Objects Condition and Special Ordering
            var peopleSpecialOrder = from p in people
                                     where (p.Name.Length == 4)
                                     orderby p.Name, p.Height
                                     select p;

            foreach (var p in peopleSpecialOrder)
            {
                //Console.WriteLine($"Name: {p.Name}, Height: {p.Height}");
            }
        }

        private static void basic_LINQ_Query_3()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 43, Gender.Female),
                new Person("John", "Jones", 7, 160, 37, Gender.Female),
                new Person("Samba", "TheLion", 8, 175, 33, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 18, Gender.Female)
            };

            //----------------------------------------------
            //SeparatingLine();
            // 1. Creating new anonymous objects for Young People
            var youngPeople = from p in people
                              where p.Age < 25
                              select new
                              {
                                  Name = p.Name,
                                  Age = p.Age
                              };

            foreach (var p in youngPeople)
            {
                //Console.WriteLine($"My name is {p.Name} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            //SeparatingLine();
            // 2. Reusing the Properties Names
            var youngPeopleSameProp = from p in people
                                      where p.Age < 25
                                      select new
                                      {
                                          p.Name,
                                          p.Age
                                      };

            foreach (var p in youngPeopleSameProp)
            {
                //Console.WriteLine($"My name is {p.Name} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            //SeparatingLine();
            // 3. Reusing the Properties Names, Mix
            var youngPeopleMixProp = from p in people
                                     where p.Age < 25
                                     select new
                                     {
                                         N = p.Name,
                                         p.Age
                                     };

            foreach (var p in youngPeopleMixProp)
            {
                //Console.WriteLine($"My name is {p.N} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            //SeparatingLine();
            // 4. Creating new YoungPerson Objects from Person
            var youngPersonObj = from p in people
                                 where p.Age < 25
                                 select new YoungPerson
                                 {
                                     FullName = p.Name,
                                     Age = p.Age
                                 };

            foreach (var p in youngPersonObj)
            {
                //Console.WriteLine($"My name is {p.FullName} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            //SeparatingLine();
            // 5. Creating new YoungPerson Objects from Person
            var youngPersonFullName = from p in people

                                      where p.Age < 25
                                      select new YoungPerson
                                      {
                                          FullName = string.Format($"{p.Name} {p.LastName}"),
                                          Age = p.Age
                                      };
            //select new YoungPerson { Name = p.FirstName + " " + p.LastName, Age = p.Age };

            foreach (var p in youngPersonFullName)
            {
                Console.WriteLine($"My name is {p.FullName} and I am {p.Age} years old.");
            }
        }

        private static void basic_LINQ_Query_4()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 43, Gender.Female),
                new Person("John", "Jones", 7, 160, 37, Gender.Female),
                new Person("Samba", "TheLion", 8, 175, 33, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 18, Gender.Female)
            };


            //----------------------------------------------
            //SeparatingLine();
            // 1. Extracting People with names that start with 'a'
            var peopleWithA = from p in people
                              let pNameFirstLetter = p.Name.ToLower()[0]
                              where pNameFirstLetter == 'a'
                              select p;

            foreach (var p in peopleWithA)
            {
                //Console.WriteLine($"My name is {p.Name} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            //SeparatingLine();
            // 2. Extracting New Objects from people names that start with 'a'
            var peopleWithAObj = from p in people
                                 let pNameFirstLetter = p.Name.ToLower()[0]
                                 where pNameFirstLetter == 'a'
                                 select new { Name = string.Format($"{p.Name} {p.LastName}"), p.Age };

            foreach (var p in peopleWithAObj)
            {
                Console.WriteLine($"My name is {p.Name} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            //SeparatingLine();
            // 3. Collection of Collections into a single Collection
            var youngPersonFullName = from p in people
                                      where p.Age < 25
                                      let fN = string.Format($"{p.Name} {p.LastName}")
                                      select new YoungPerson { FullName = fN, Age = p.Age };

            foreach (var p in youngPersonFullName)
            {
                //Console.WriteLine($"My name is {p.FullName} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            //SeparatingLine();
            // 4. Collection of Collections into a single Collection
            List<List<int>> list = new List<List<int>>
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 7, 8, 9 }
            };

            var allNumbers = from l in list
                             let numbers = l
                             from n in numbers
                             select n;

            foreach (var n in allNumbers)
            {
                //Console.WriteLine($"{n}");
            }

            //----------------------------------------------
            //SeparatingLine();
            // 5. Collection of Collections into a single Collection of Squared Numbers that are less than 50
            var allNumbersSquared = from l in list
                                    from n in l
                                    let squared = n * n
                                    where squared < 50
                                    select squared;

            foreach (var n in allNumbersSquared)
            {
                //Console.WriteLine($"{n}");
            }

            //----------------------------------------------
            //SeparatingLine();
            // (A bit more advanced example) 6. Extract persons whos age is less than the average age of all persons
            var lessThanAverageAge = from p in people
                                     let averageAge = people.Sum(person => person.Age) / people.Count
                                     where p.Age < averageAge
                                     select p;

            foreach (var p in lessThanAverageAge)
            {
                //Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
            }

        }

        private static void grouping_LINQ_Query()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
                new Person("John", "Jones", 7, 160, 22, Gender.Female),
                new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
            };

            //----------------------------------------------
            SeparatingLine();
            // 01. Grouping Persons by Gender
            IEnumerable<IGrouping<Gender, Person>> genderGroup = from p in people
                                                                 group p by p.Gender;

            foreach (IGrouping<Gender, Person> item in genderGroup)
            {
                Console.WriteLine("People with Gender: " + item.Key);

                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Name}, Gender: {p.Gender}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 02. Grouping an Object by Property, Persons by Age with condition
            IEnumerable<IGrouping<int, Person>> ageGroup = from p in people
                                                           where p.Age > 20
                                                           group p by p.Age;

            foreach (IGrouping<int, Person> item in ageGroup)
            {
                Console.WriteLine("People with Age: " + item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Name}, Age: {p.Age}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 03. Grouping an Object by Property, Alphabetical Grouping
            IEnumerable<IGrouping<char, Person>> alphabeticalGroup = from p in people
                                                                     orderby p.Name
                                                                     group p by p.Name[0];

            foreach (IGrouping<char, Person> item in alphabeticalGroup)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Name}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 4. Grouping by Multikey
            var multiGroup = from p in people
                             group p by new { p.Gender, p.Age };

            foreach (var item in multiGroup)
            {
                Console.WriteLine($"{item.Key}");

                foreach (Person i in item)
                {
                    Console.WriteLine($" {i.Name}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 5. Ordering by amount of numbers in each key (group)
            var orderedGroupsAndCount = from g in multiGroup
                                        orderby g.Count()
                                        select g;

            foreach (var item in orderedGroupsAndCount)
            {
                Console.WriteLine($"Gender: {item.Key.Gender}, Age: {item.Key.Age}");
                foreach (Person i in item)
                {
                    Console.WriteLine($" {i.Age}");
                }
            }
        }

        private static void joining_LINQ_Query()
        {

            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "EarthIsFlat District", Age = 40 },
                new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Jaime", District = "Developers District", Age = 35 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
            };
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", District = "Fantasy District", Age = 22 },
                new Supplier() { Name = "Charles", District = "Developers District", Age = 40 },
                new Supplier() { Name = "Hailee", District = "Scientists District", Age = 35 },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30 }
            };

            //----------------------------------------------
            SeparatingLine();
            // 1. Simple Inner Join, just selecting properties

            var innerJoin = from b in buyers
                            orderby b.District
                            join s in suppliers on b.District equals s.District
                            select new
                            {
                                Supplier = s.Name,
                                Buyer = b.Name,
                                District = b.District
                            };

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"District: {item.District}, Supplier: {item.Supplier}, Buyer: {item.Buyer}");
            }

            //----------------------------------------------
            SeparatingLine();
            // 2. Joining by more than one key
            var compositeJoin = from b in buyers
                                join s in suppliers on new { b.District, b.Age } equals new { s.District, s.Age }
                                select new
                                {
                                    Supplier = s,
                                    BuyerName = b.Name
                                };

            foreach (var item in compositeJoin)
            {
                //Console.WriteLine($"District: {item.Supplier.District}, Age: {item.Supplier.Age}");
                //Console.WriteLine($"  Supplier: {item.Supplier.Name}");
                //Console.WriteLine($"  Supplier: {item.BuyerName}");
                //Console.WriteLine();
            }

        }

        private static void group_Join_LINQ_Query()
        {

            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District" },
                new Buyer() { Name = "Peter", District = "Scientists District" },
                new Buyer() { Name = "Paul", District = "Fantasy District" },
                new Buyer() { Name = "Maria", District = "Scientists District" },
                new Buyer() { Name = "Joshua", District = "EarthIsFlat District" },
                new Buyer() { Name = "Sylvia", District = "Developers District" },
                new Buyer() { Name = "Rebecca", District = "Scientists District" },
                new Buyer() { Name = "Jaime", District = "Developers District" },
                new Buyer() { Name = "Pierce", District = "Fantasy District" }
            };
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", District = "Fantasy District" },
                new Supplier() { Name = "Charles", District = "Developers District" },
                new Supplier() { Name = "Hailee", District = "Scientists District" },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District" }
            };

            //----------------------------------------------
            SeparatingLine();
            // 1. Simple Group Join, the result of the join is in a variable (into ...) iterate on that variable to get the results
            var matchingSuppliersWithBuyers = from s in suppliers
                                              orderby s.District
                                              join b in buyers on s.District equals b.District into buyersGroup
                                              select new
                                              {
                                                  s.Name,
                                                  s.District,
                                                  Buyers = buyersGroup
                                              };

            foreach (var item in matchingSuppliersWithBuyers)
            {
                Console.WriteLine($"Supplier: {item.Name}, District: {item.District} " +
                    $"\nBuyers:");

                foreach (var buyer in item.Buyers)
                {
                    Console.WriteLine($"  {buyer.Name}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 2. Performing some operation on the joined collection
            var innerGroupJoin = from s in suppliers
                                 orderby s.District
                                 join b in buyers on s.District equals b.District into buyersGroup
                                 select new
                                 {
                                     s.District,
                                     s.Name,
                                     Buyers = from b in buyersGroup
                                              orderby b.Name
                                              select b
                                 };

            foreach (var supplier in innerGroupJoin)
            {
                //Console.WriteLine($"Supplier: {supplier.Name}, District: {supplier.District}");

                foreach (var buyer in supplier.Buyers)
                {
                    //Console.WriteLine($"  Buyer: {buyer.Name}, District: {buyer.District}");
                }
            }

        }

        private static void lambda_Expressions_1()
        {
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            List<int> numbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };
            object[] mix = { 1, "string", 'd', new List<int>() { 1, 2, 3, 4 }, new List<int>() { 5, 2, 3, 4 }, "dd", 's', "Hello Kitty", 1, 2, 3, 4, };

            SeparatingLine();
            // 1. Extract odd numbers with Lambda
            List<int> oddNumbers = numbers.Where(n => (n % 2) == 1).ToList();

            Console.WriteLine("The odd numbers are: " + string.Join(", ", oddNumbers));

            SeparatingLine();
            // 2. Select vs Where
            List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior() { Height = 100 },
                new Warrior() { Height = 80 },
                new Warrior() { Height = 100 },
                new Warrior() { Height = 70 },
            };

            List<int> heights = warriors.Where(wh => wh.Height == 100)
                                        .Select(wh => wh.Height)
                                        .ToList();

            Console.WriteLine("Heights: " + string.Join(", ", heights));

            SeparatingLine();
            // 3. Short ForEach
            Console.WriteLine("Short ForEach heights");
            heights.ForEach(h => Console.WriteLine(h));

            Console.WriteLine("Short ForEach heights from Warriors");
            warriors.ForEach(wh => Console.WriteLine(wh.Height)); // can't do it with string.Join

        }

        private static void lambda_Expressions_2()
        {

            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 22, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
                new Person("John", "Jones", 7, 160, 22, Gender.Male),
                new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 23, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
            };

            //----------------------------------------------
            SeparatingLine();
            // 1. Group by gender
            IEnumerable<IGrouping<Gender, Person>> genderGroup = people                   // from p in people
                                                                 .GroupBy(p => p.Gender); // group p by p.Gender 

            foreach (IGrouping<Gender, Person> item in genderGroup)
            {
                Console.WriteLine("People with Gender: " + item.Key);

                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Name}, Gender: {p.Gender}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 02. Grouping by Property
            IEnumerable<IGrouping<int, Person>> ageGroup = people                      // from p in people
                                                           .Where(p => p.Age > 20)     // where p.Age > 20
                                                           .GroupBy(p => p.Age);       // group p by p.Age

            foreach (IGrouping<int, Person> item in ageGroup)
            {
                Console.WriteLine("People with Age: " + item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Name}, Age: {p.Age}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 03. Group & order
            var alphabeticalGroup = people.OrderBy(p => p.Name).GroupBy(p => p.Name[0]);

            foreach (IGrouping<char, Person> item in alphabeticalGroup)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Name}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 04. Group by multiple keys
            var multiGroup = people.GroupBy(p => new { p.Gender, p.Age });

            foreach (var item in multiGroup)
            {
                Console.WriteLine($"{item.Key}");

                foreach (Person i in item)
                {
                    Console.WriteLine($" {i.Name}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 05. 04 order by items in key
            var orderedGroupsAndCount = multiGroup.OrderBy(key => key.Count());

            foreach (var item in orderedGroupsAndCount)
            {
                Console.WriteLine($"Gender: {item.Key.Gender}, Age: {item.Key.Age}");
                foreach (Person i in item)
                {
                    Console.WriteLine($" {i.Age}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 06. Order the keys in a group (into..)
            var multiGroupKeyOrderSingleLine = people.GroupBy(p => new { p.Gender, p.Age }).OrderBy(p => p.Count());

            foreach (var key in multiGroupKeyOrderSingleLine)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($" {item.Age}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 07. Even/Odd numbers group
            int[] arrayOfNumbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            var numbers = arrayOfNumbers.OrderBy(n => n)
                                        .GroupBy(n => (n % 2 == 0) ? "Even" : "Odd")
                                        .OrderBy(key => key.Count());

            foreach (var item in numbers)
            {
                foreach (var i in item)
                {
                    Console.WriteLine($"  {i}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 08. Multiple custom groups
            var peopleMultiGrouping = people.GroupBy(p => p.Age < 20
                                                                ? "Young"
                                                                : p.Age >= 20 && p.Age <= 22
                                                                    ? "Adult"
                                                                    : "Senior");
            //{
            //    var young = p.Age < 20;
            //    var adult = p.Age >= 20 && p.Age <= 22;

            //    var age = young 
            //                ? "Young" 
            //                    : adult 
            //                        ? "Adult" 
            //                        : "Senior";

            //    return age;
            //});

            foreach (var p in peopleMultiGrouping)
            {
                Console.WriteLine($"{p.Key}");
                foreach (var i in p)
                {
                    Console.WriteLine($" {i.Age}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 09. How many items in each group
            var howManyOfEachGroup = people.GroupBy(p => p.Gender)
                                           .OrderBy(p => p.Count())
                                           .Select(p => new
                                           {
                                               Gender = p.Key,
                                               NumOfPeople = p.Count()
                                           });

            foreach (var amount in howManyOfEachGroup)
            {
                Console.WriteLine($"{amount.Gender}");
                Console.WriteLine($"{amount.NumOfPeople}");
            }
        }

        private static void lambda_Expressions_3()
        {

            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "Scientists District", Age = 40 },
                new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Jaime", District = "Developers District", Age = 35 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
            };
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", District = "Fantasy District", Age = 22 },
                new Supplier() { Name = "Charles", District = "Developers District", Age = 40 },
                new Supplier() { Name = "Hailee", District = "Scientists District", Age = 35 },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30 }
            };

            //----------------------------------------------
            SeparatingLine();
            // 01. Simple Inner Join, just seleecting properties
            var innerJoin = suppliers.Join(buyers,
                                      s => s.District, b => b.District,
                                      (s, b) => new
                                      {
                                          SupplierName = s.Name,
                                          BuyerName = b.Name,
                                          District = b.District
                                      });

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"District: {item.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");
            }

            //----------------------------------------------
            SeparatingLine();
            // 02. Joining by more than one key
            var compositeJoin = suppliers.Join(buyers,
                                               s => new { s.District, s.Age },
                                               b => new { b.District, b.Age },
                                               (s, b) => new
                                               {
                                                   Supplier = s,
                                                   BuyerName = b.Name
                                               });

            foreach (var item in compositeJoin)
            {
                Console.WriteLine($"District: {item.Supplier.District}, Age: {item.Supplier.Age}");
                Console.WriteLine($"  Supplier: {item.Supplier.Name}");
                Console.WriteLine($"  Supplier: {item.BuyerName}");
                Console.WriteLine();
            }

            //----------------------------------------------
            SeparatingLine();
            // 03. Simple Group Join, the result of the join is in a variable (into ...) iterate on that variable to get the results
            var groupJoin = suppliers.GroupJoin(buyers,
                s => s.District, b => b.District,
                (s, buyersGroup) => new
                {
                    s.Name,
                    s.District,
                    Buyers = buyersGroup.OrderBy(b => b.Name)
                });
            foreach (var item in groupJoin)
            {
                Console.WriteLine($"Supplier: {item.Name}, District: {item.District} " +
                    $"\nBuyers:");

                foreach (var buyer in item.Buyers)
                {
                    Console.WriteLine($"  {buyer.Name}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 04. Left Outer Join Buyer Object Returned
            var leftOuterJoinBuyer = suppliers.GroupJoin(
                buyers,
                s => s.District,
                b => b.District,
                (s, buyersGroup) => new
                {
                    s.Name,
                    s.District,
                    Buyers = buyersGroup
                })
                .SelectMany(s => s.Buyers.DefaultIfEmpty(new Buyer() { Name = "No name", District = "No place", }),
                            (s, b) => new
                            {
                                SupplierName = s.Name,
                                Buyers = s.Buyers,
                                s.District
                            }
                );


            // Only one loop needed because SelectMany "flattens" the collection and we get only 1 collection in result.
            foreach (var item in leftOuterJoinBuyer)
            {
                Console.WriteLine($"{item.SupplierName}");
                foreach (var buyer in item.Buyers)
                {
                    Console.WriteLine($"  {buyer.District} {buyer.Name}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 05. Left Outer Join Anonymous object returned
            var leftOuterJoinAnon = suppliers.GroupJoin(buyers,
                s => s.District, b => b.District,
                (s, buyersGroup) => new
                {
                    s.Name,
                    s.District,
                    Buyers = buyersGroup.OrderBy(b => b.Name)
                })
                .SelectMany(s => s.Buyers.DefaultIfEmpty(),
                (s, b) => new
                {
                    s.Name,
                    s.District,
                    BuyersName = b?.Name ?? "No name",
                    BuyersDistrict = b?.District ?? "No place"
                });

            foreach (var item in leftOuterJoinAnon)
            {
                Console.WriteLine($"{item.District}");
                Console.WriteLine($"  {item.Name}, {item.BuyersName}");
            }

        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }
}
