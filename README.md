# Regulyar_ifodalar
StringBuilder va String sinflari satrlar bilan ishlash uchun yetarli funksionallikni ta'minlaydi. Biroq, 
.NET yana bir kuchli vosita - regulyar ifodalarni taklif qiladi. Oddiy iboralar katta matnlarni qayta ishlashning samarali va moslashuvchan usulini ta'minlaydi, shu bilan birga standart string amallaridan foydalanish bilan solishtirganda kodni sezilarli darajada kamaytirishga imkon beradi.
.NET dagi regulyarifodalarning asosiy funksiyasi System.Text.RegularExpressions nomlar fazosida  joylashgan. Regulyar iboralar bilan ishlashda markaziy sinf Regex sinfidir. Misol uchun, bizda qandaydir matn bor va biz undan so'zning barcha so'z shakllarini topishimiz kerak. Buni Regex sinfi bilan qilish juda oson:

```Cs
class Program
{
    static void Main()
    {
        string s = "O'zbekiston Milliy universitetida talabalar o'rtasida ko'rik tanlov bo'lib o'tdi. Tanlovda talaba-yoshlar aktiv ishtirok etishdi. Bunda 2-kurs talabalaridan tuzilgan jamoa 1-o'rin oldi.";
        Regex regex = new Regex(@"talaba(\w*)");
        MatchCollection matches = regex.Matches(s);
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
                Console.WriteLine(match.Value);
        }
        else
        {
            Console.WriteLine("Mos kelgan topilmadi");
        }
    }
}
```
Bu yerda biz qidiruv satrida "talaba" so'zining barcha so'z shakllarini topamiz. Regex ob'ektining konstruktori izlash uchun regulyar ifodadan o'tadi. Keyin biz regulyar iboralar sintaksisining ba'zi elementlarini tahlil qilamiz, ammo hozircha talaba(\w*) iborasi nimani anglatishini bilib olamiz. Demak,  "talaba" ildiziga ega bo'lgan va boshqa belgilar bilan kelishi mumkin bo'lgan barcha so'zlarni topadi.  \w belgi iborasi alfafit belgini anglatadi va ifodadan keyingi yulduzcha ularning noaniq sonini bildiradi - bitta, ikkita, uchta yoki umuman bo'lmasligi ham mumkin.
Regex sinfining Matches usuli regulyar ifoda qo'llanilishi kerak bo'lgan qatorni oladi va topilgan mosliklar to'plamini qaytaradi.
Bunday to'plamning har bir elementi Match ob'ektini ifodalaydi. Uning Value xususiyati topilgan moslikni qaytaradi.
Va bu holda biz quyidagi konsol chiqishini olamiz:
```Cs
talabalar
talaba
talabalaridan
```
