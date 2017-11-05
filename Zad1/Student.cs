using System;

namespace Razredi.Zad1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            this.Name = name;
            this.Jmbag = jmbag;
        }

        public static bool operator ==(Student first, Student second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !(first.Equals(second));
        }

        public override bool Equals(Object second)
        {
            if (second == null || second?.GetType() != GetType())
            {
                return false;
            }

            return ((Student)second).Jmbag.Equals(Jmbag);
        }

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }
    }

    public enum Gender
    {
        Male, Female
    }
}