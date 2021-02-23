using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExamples
{
    class Person
    {
        private string name;
        private string lastName;
        private int id;
        private int height;
        private int weight;
        private int age;
        private Gender gender;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public Person(string name, int height, int weight, Gender gender)
        {
            this.name = name;
            this.Height = height;
            this.Weight = weight;
            this.Gender = gender;
        }

        public Person(string name, string lastName, int id, int height, int age, Gender gender)
        {
            this.name = name;
            this.lastName = lastName;
            this.id = id;
            this.Height = height;
            this.Age = age;
            this.Gender = gender;
        }
    }

}
