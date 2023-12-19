using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;
using System.Threading.Tasks;

var input2 = @"Time:        54     81     70     88
Distance:   446   1292   1035   1007";


var input1 = @"Time:      7  15   30
Distance:  9  40  200";

var input = input2;

using var sr = new StringReader(input);
var line1 = sr.ReadLine().Substring(5);
var line2 = sr.ReadLine().Substring(9);
var times = line1.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
var distances = line2.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
var ways = new List<long>();

for (var i = 0; i < times.Length; i++)
{
    var time = times[i];
    var distance = distances[i];

    var waysCount = 0L;
    for (var j = 1L; j < time; j++)
    {
        if (j * (time - j) > distance) waysCount++;
    }

    if (waysCount > 0) ways.Add(waysCount);
}

var agg = ways.Aggregate(1L, (mul, next) => mul * next);
Console.WriteLine($"Aggregate: {agg}");

var oneTime = long.Parse(line1.Replace(" ", ""));
var oneDistance = long.Parse(line2.Replace(" ", ""));
var oneCount = 0L;
for (var j = 1L; j < oneTime; j++)
{
    if (j * (oneTime - j) > oneDistance) oneCount++;
}

Console.WriteLine($"One race: {oneCount}");
