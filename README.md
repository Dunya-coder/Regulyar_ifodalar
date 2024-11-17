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
RegexOptions parametrlari
Regex sinfida ob'ektni dastlabki ishga tushirishni amalga oshirish imkonini beruvchi bir qator konstruktorlar mavjud. Konstruktorlarning ikkita versiyasi o'zlarining parametrlaridan biri sifatida RegexOptions ro'yxatini oladi. Ushbu ro'yxat tomonidan qabul qilingan ba'zi qiymatlar:
Compiled: Ushbu qiymatni o'rnatish muntazam ifodani kompilyatsiya qiladi, bu esa tezroq bajarilishiga olib keladi.
CultureInvariant: Ushbu qiymatni o'rnatish mintaqaviy farqlarni e'tiborsiz qoldiradi
IgnoreCase: Ushbu qiymatni o'rnatish katta harflarni e'tiborsiz qoldiradi
IgnorePatternWhitespace: satrdan boʻshliqlarni olib tashlaydi va # belgisi bilan boshlangan izohlarga ruxsat beradi
Multiline: matnni ko'p qatorli rejimda ko'rish kerakligini bildiradi. Ushbu rejimda "^" va "$" belgilari mos ravishda butun matnning boshi va oxiriga emas, balki har qanday satrning boshi va oxiriga to'g'ri keladi.
RightToLeft: qatorni o‘ngdan chapga o‘qishni tayinlaydi
Singleline: bu rejimda "." belgisi har qanday belgiga, jumladan, keyingi qatorga olib boradigan "\n" ketma-ketligiga mos keladi
Misol uchun,
Regex regex = new Regex(@"talaba(\w*)", RegexOptions.IgnoreCase);
Agar kerak bo'lsa, siz bir nechta parametrlarni o'rnatishingiz mumkin:
Regex regex = new Regex(@"talaba(\w*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Regulyar ifoda sintaksisi
Regulyar ifoda sintaksisining ba'zi elementlarini qisqacha ko'rib chiqamiz:
^: Moslik satr boshida boshlanishi kerak (masalan, @"^sa\w*" ifodasi "salom dunyo" qatoridagi "salom" so'ziga mos keladi)
$: satr oxiri (masalan, @"\w*yo$" "salom dunyo" qatoridagi "dunyo" so'ziga mos keladi, chunki "yo" qismi eng oxirida joylashgan)
.: nuqta belgisi istalgan bitta belgiga mos keladi (masalan, "m.s" iborasi "mis", "mas" yoki "mos" so'ziga mos keladi)
*: oldingi belgi 0 yoki undan ortiq marta takrorlanadi
+: oldingi belgi 1 yoki undan ortiq marta takrorlanadi
?: oldingi belgi 0 yoki 1 marta takrorlanadi
\s: har qanday bo'shliq belgisiga mos keladi
\S: bo'sh joy bo'lmagan har qanday belgiga mos keladi
\w: har qanday alfavit belgiga mos keladi
\W: har qanday alfavit bo'lmagan belgilarga mos keladi
\d: har qanday kasrli sonli mos keladi
\D : o'nlik raqam bo'lmagan har qanday belgiga mos keladi

