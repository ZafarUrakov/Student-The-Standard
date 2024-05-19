using System;

namespace Student_The_Standard.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetDateTimeOffset() =>
            DateTimeOffset.Now;
    }
}
