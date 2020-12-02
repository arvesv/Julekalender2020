using System;
using System.Linq;
using System.Net;

const string url = "https://julekalender-backend.knowit.no/challenges/1/attachments/numbers.txt";
const int maxsize = 100000;

var vs = new bool[maxsize + 1];
vs[0] = true; // hack as as the numbers start at 1
using var client = new WebClient();

foreach (var number in 
    client
    .DownloadString(url)
    .Split(',')
    .Select(s => int.Parse(s)))
{
    vs[number] = true;
}

Console.WriteLine(Array.IndexOf(vs, false));
