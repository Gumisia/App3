using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using XYZExporter.Models;

namespace XYZExporter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //1 opcja
            List<string> list = new List<string>();
            using (StreamReader stream = new StreamReader(@"C:\Users\gabri\OneDrive\PJATK OneDrive\PJATK1\APBD\OneDrive_2022-03-20.zip\2. Ćwiczenia 2\Zadanie 1\dane.csv"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            using (StreamWriter stream = new StreamWriter("opcja1.txt"))
            {
                foreach (var item in list)
                {
                    stream.WriteLine(item);
                }
            }
            //2 opcja
            string[] result2 = await File.ReadAllLinesAsync(@"C:\Users\mpazio\Downloads\OneDrive_2022-03-20\2. Ćwiczenia 2\Zadanie 1\dane.csv");
            await File.WriteAllLinesAsync("opcja2.txt", result2);
            string a = "";
            string[] b = a.Split(',');
            new Student { };
            //var jObject = new JObject();
            // { }
            var jArray = new JArray();
            // []
            var jProperty = new JProperty("property", jArray);
            // nazwaProperty: ""
            var jObject = new JObject(
                new JProperty("uczelnia", new JObject(
                    new JProperty("createdAt", DateTime.Today.ToString("dd.MM.yyyy")),
                    new JProperty("author", "Michał Pazio")
                ))
            );
            Console.WriteLine(jObject);
        }
        /*
        //1. Jako, że konstruktor nie może być asynchroniczny, poniżej jest przykład metody statycznej inicjalizującą klasę
        class StudentParser
        {
            private HashSet<Student> _students;
            public static async Task<StudentParser> Parse(List<string> studentDataList)
            {
                var students = new HashSet<Student>(new StudentComparer());
                foreach (var student in studentDataList)
                {
                    await ParseStudentAsync(student, students);
                }
                return new StudentParser { _students = students };
            }
        }
        //2. Comparator, który możemy użyć w kolekcji np. HashSet
        var set = new HashSet<Student>(new StudentComparer());
        public class StudentComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                return (x.Imie == y.Imie)
                    && (x.Nazwisko == y.Nazwisko)
                    && (x.NrIndeksu == y.NrIndeksu);
            }
            public int GetHashCode(Student obj)
            {
                return obj.NrIndeksu.GetHashCode();
            }
        }*/
    }
}
