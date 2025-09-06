using System;

namespace ConsoleApp.Models
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;
        private int milliseconds;

        public Time() : this(0, 0, 0, 0) { }
        public Time(int hours) : this(hours, 0, 0, 0) { }
        public Time(int hours, int minutes) : this(hours, minutes, 0, 0) { }
        public Time(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0) { }
        public Time(int hours, int minutes, int seconds, int milliseconds)
        {

            if (hours < 0 || hours > 23) throw new ArgumentOutOfRangeException($"The hour: {hours}, is not valid.");
            if (minutes < 0 || minutes > 59) throw new ArgumentOutOfRangeException($"The minutes: {minutes}, is not valid.");
            if (seconds < 0 || seconds > 59) throw new ArgumentOutOfRangeException($"The seconds: {seconds}, is not valid.");
            if (milliseconds < 0 || milliseconds > 999) throw new ArgumentOutOfRangeException($"The milliseconds: {milliseconds}, is not valid.");

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;
        }


        public override string ToString()
        {
            int hour12 = hours % 12;
            string hourStr = hour12 == 0 ? "00" : hour12.ToString("D2");
            string ampm = hours < 12 ? "AM" : "PM";
            return $"{hourStr}:{minutes:D2}:{seconds:D2}.{milliseconds:D3} {ampm}";
        }

        public long ToMilliseconds()
        {
            return ((long)hours * 3600 + (long)minutes * 60 + (long)seconds) * 1000 + milliseconds;
        }

        public long ToSeconds()
        {
            return (long)hours * 3600 + (long)minutes * 60 + (long)seconds;
        }

        public long ToMinutes()
        {
            return (long)hours * 60 + (long)minutes;
        }

        public bool IsOtherDay(Time other)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            long totalHours = totalMs / (3600L * 1000);
            return totalHours >= 24;
        }


        public Time Add(Time other)
        {
            int ms = this.milliseconds + other.milliseconds;
            int carryS = ms / 1000;
            ms = ms % 1000;

            int s = this.seconds + other.seconds + carryS;
            int carryM = s / 60;
            s = s % 60;

            int m = this.minutes + other.minutes + carryM;
            int carryH = m / 60;
            m = m % 60;

            int h = this.hours + other.hours + carryH;
            h = h % 24;

            return new Time(h, m, s, ms);
        }
    }
}
