using System;

namespace AdventOfCode.Day4
{
    public static class DateTimeEx
    {
        public static double SubtractMinutesFromOther(this DateTime source, DateTime other)
        {
            return other.Minute - 1 - source.Minute;
        }
    }
}