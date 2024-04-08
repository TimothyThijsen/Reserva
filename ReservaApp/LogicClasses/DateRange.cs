using LogicClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class DateRange : IRange<DateTime>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public bool Includes(DateTime value)
        {
            return (Start <= value) && (value <= End);
        }

        public bool Includes(IRange<DateTime> range)
        {
            return ((range.Start >= Start) && (range.Start <= End) || (range.End >= Start) && (range.End <= End));
        }
    }
}
