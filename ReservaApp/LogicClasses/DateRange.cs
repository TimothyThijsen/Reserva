using LogicClasses.Interfaces;

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
        public bool IsBiggerThan(DateTime date)
        {
            if (Start > date) return true;
            return false;
        }
        public int GetDaysCount()
        {
            return (End - Start).Days;
        }
    }
}
