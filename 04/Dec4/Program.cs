using System;
using System.Linq;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;

namespace Dec4
{
    class Program
    {
        static void Main()
        {
            using var client = new WebClient();

            var lines = client.DownloadString(
                    "https://julekalender-backend.knowit.no/challenges/4/attachments/leveringsliste.txt")
                .Split(new[] {'\n', ','}).Select(d => d.Split(':'))
                .Select(x => new {key = x[0].Trim(), number = int.Parse(x[1])})
                .GroupBy(w => w.key)
                .Select(cl => new
                {
                    key = cl.Key,
                    sum = cl.Sum(q => q.number)
                });

            var egg = lines.Where(x => x.key == "egg").First().sum;
            var mel = lines.Where(x => x.key == "mel").First().sum;
            var sukker = lines.First(x => x.key == "sukker").sum;
            var melk = lines.Where(x => x.key == "melk").First().sum;

            int prodegg = egg / 1;
            int prodmel = mel / 3;
            int prodsukker = sukker / 2;
            int prodmelk = melk / 3;

            int kake = (new int[] {prodegg, prodmel, prodsukker, prodmelk}).Min();



            Console.WriteLine(kake);
        }
    }
}
