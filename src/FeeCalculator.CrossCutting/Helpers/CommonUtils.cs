using System;
using System.Globalization;

namespace FeeCalculator.CrossCutting.Helpers
{
    public static class CommonUtils
    {
        private static readonly string TimeZone = "E. Australia Standard Time";
        private static readonly TimeZoneInfo TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZone);
        private static CultureInfo _defaultCulture = new CultureInfo("en-AU", true);

        public static DateTime ToLocalDateTime(this DateTime utcDateTime)
        {
            return ToLocalDateTime(utcDateTime, TimeZone);
        }

        public static string TimeZoneAbbr(this DateTime date)
        {
            return TimeZoneInfo.IsDaylightSavingTime(date) ? "AEDT" : "AEST";
        }

        public static DateTime ToLocalDateTime(this DateTime utcDateTime, string timeZone)
        {
            TimeZoneInfo SiteLocalTime = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, SiteLocalTime);
        }

        public static DateTime ToUTCDateTime(this DateTime localDateTime, string timeZone)
        {
            TimeZoneInfo SiteLocalTime = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeToUtc(localDateTime, SiteLocalTime);
        }

        public static DateTime ToUTCDateTime(this DateTime localDateTime)
        {
            return ToUTCDateTime(localDateTime, TimeZone);
        }

        public static DateTime LocalNow { get { return DateTime.UtcNow.ToLocalDateTime(); } }

        public static string ToFmtString(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMM yyyy hh:mm:ss ") + dateTime.ToString("tt").ToUpper();
        }

        public static string ToFmt24FullShortString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public static string ToFmtFullHourString(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMM yyyy hh:00 ") + dateTime.ToString("tt").ToUpper();
        }

        public static string ToFmtSlotDateString(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMM yyyy") + " between " + dateTime.ToString("HH:00 ") + " and " + dateTime.AddHours(1).ToString("HH:00");
        }
        public static string ToFmtSlotDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMM yyyy") + " (" + dateTime.ToString("HH:00 ") + " to " + dateTime.AddHours(1).ToString("HH:00") + ")";
        }
        public static string ToSlotDateTimeIntervalString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + " (" + dateTime.ToString("HH:00 ") + " - " + dateTime.AddHours(1).ToString("HH:00") + ")";
        }

        public static string ToFmt24String(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMM yyyy HH:mm:ss ");
        }

        public static string ToFmtHourMinutesMeridiemString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy hh:mm ", CultureInfo.InvariantCulture) + dateTime.ToString("tt").ToUpper();
        }


        public static string ToBootstrapDateTimePickerFormatString(this DateTime dateTime)
        {
            return dateTime.ToString("MMM/dd/yyyy HH:mm");
        }

        public static string ToFmtHourMinutesString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/mm/yyyy HH:mm tt");
        }

        public static string ToLocalNowDate { get { return DateTime.UtcNow.ToLocalDateTime().ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture); } }
        public static string ToLocalNowDatePlus1Hour { get { return DateTime.UtcNow.ToLocalDateTime().AddHours(1).ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture); } }

        public static string ToLocalYesterdayDate { get { return DateTime.UtcNow.AddDays(-1).ToLocalDateTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); } }

        public static string localTimeZone { get { return LocalNow.TimeZoneAbbr(); } }
    }

  
}
