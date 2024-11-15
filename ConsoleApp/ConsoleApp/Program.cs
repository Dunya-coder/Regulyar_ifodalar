using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "Universitet telefon nomeri: 998-96-238-05-34, fakultet nomeri: 998-77-450-46-19";
            Regex regex = new Regex(@"\d{3}-\d{2}-\d{3}-\d{2}-\d{2}");

            // Mos keladigan raqamlarni topish
            MatchCollection matches = regex.Matches(s);

            // Agar mos keladigan topilsa, ularni chiqazish
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
            else
            {
                Console.WriteLine("Mos kelgan topilmadi");
            }

            ///////////
            // Matn
            string s1 = "Milliy universitet talabalar soni 30000 tani tashkil qiladi. Talabalarning 70% kunduzgi bo’limlarda o’qiydi";

            // "lar" qo'shimchasi mavjud so'zlarni qidirish uchun regex
            Regex regex1 = new Regex(@"\w*lar\w*");

            // Mos keladigan so'zlarni topish
            MatchCollection matches1 = regex1.Matches(s1);

            // Natijalarni chiqarish
            if (matches1.Count > 0)
            {
                foreach (Match match1 in matches1)
                    Console.WriteLine(match1.Value);
            }
            else
            {
                Console.WriteLine("Mos kelgan topilmadi");
            }
        }
    }
}
