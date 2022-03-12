using System;
using static System.Console;

using System.Collections.Generic; // for IEnumerable<T>
using System.Linq; // for LINQ extension methods

namespace LinqWithSets
{
    class Program
    {
        static void Output(IEnumerable<string> team, string description = "")
        {
            if (!string.IsNullOrEmpty(description))
            { // اذا ارسلنا نص وصفي اثناء استدعاء الدالة فانه يطبعه اولا
                WriteLine(description);
            }
            Write(" ");
            WriteLine(string.Join(", ", team.ToArray())); 
            // هنا يطبع محتوى المصفوفة المرسلة ويفصل كل عنصر عن الاخر بفاصلة
        }
        static void Main(string[] args)
        {
            var team1 = new string[]{ "aleen", "yazen", "saeed", "ahmed" };
            var team2 = new string[]{ "elias", "nani", "bassem", "elias", "akram" };
            var team3 = new string[]{ "adam", "elias", "elias", "dodi", "kamal" };
            Output(team1, "Team 1");
            Output(team2, "Team 2");
            Output(team3, "Team 3");
            // ماسبق مجرد عرض للمجموعات الثلاث
            WriteLine();
            Output(team2.Distinct(), "team2.Distinct():");
            // هنا سيطلع القيم في التيم الثاني بدون تكرار اي سيحذف واحد من الياس
            // elias, nani, bassem, akram
            WriteLine();
            
            Output(team2.Union(team3), "team2.Union(team3):");
            WriteLine();
            // هنا سيدمج التيم الثاني بالثالث ولكن من دون تكرار اي عنصر في المجموعتين
            // elias, nani, bassem, akram, adam, dodi, kamal
           
            Output(team2.Concat(team3), "team2.Concat(team3):");
            WriteLine();
             // هنا نفس عمل الاتحاد السابق ولكن مع اظهار القيم المكررة اي  يخرجها زي ماهي
            // elias, nani, bassem, elias, akram, adam, elias, elias, dodi, kamal

            Output(team2.Intersect(team3), "team2.Intersect(team3):");
            WriteLine();
            // هنا سنطلع القيمة المشتركة او المتقاطعة بين المجموعة الثانية والثالثة
            //elias
            Output(team2.Except(team3), "team2.Except(team3):");
            WriteLine();
            // هنا سيطلع القيمة بالتيم الثاني بشرط عدم وجودها بالتيم الثالث
            // nani, bassem, akram
            Output(team1.Zip(team2, (c1, c2) => $"{c1} matched with {c2}"), "team1.Zip(team2):");
            // هنا يطابق كل عنصر بالتيم الاول مع ما يوازيه بالموقع بالتيم الثاني
            // اذا المجموعتين غير مستاويين يعمل مقارنة بحسب الاقصر ويتغاضى عن بقية العناصر بالاطول
            // aleen matched with elias, yazen matched with nani, saeed matched with bassem, ahmed matched with elias
        }
    }
}
