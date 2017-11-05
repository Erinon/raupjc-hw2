
using Razredi.Zad1;
using System.Linq;

namespace Razredi.Zad4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.OrderBy(i => i)
                           .GroupBy(i => i)
                           .Select(i => $"Broj {i.Key} ponavlja se {i.Count()} puta").ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(i => i.Students.All(j => j.Gender == Gender.Male))
                                  .ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            double average = universityArray.Select(i => i.Students.Length)
                                            .Average();

            return universityArray.Where(i => i.Students.Length < average)
                                  .ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(i => i.Students)
                                  .Distinct()
                                  .ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(i => i.Students.All(j => j.Gender == Gender.Male) || i.Students.All(j => j.Gender == Gender.Female))
                                  .SelectMany(i => i.Students)
                                  .Distinct()
                                  .ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(i => i.Students)
                                  .GroupBy(i => i.Jmbag)
                                  .Where(i => i.Count() > 1)
                                  .SelectMany(i => i)
                                  .Distinct()
                                  .ToArray();
        }

    }
}