using System;
using System.Globalization;

namespace Brotal.Extensions
{
    public static partial class DateTimeExtensions {
        public static DateTime ParseDate (
            this string date) =>
            DateTime.ParseExact (
                date, 
                @"dd/MM/yyyy", 
                CultureInfo.InvariantCulture.DateTimeFormat
            );

        public static DateTime? TryParseDate (
            this string date, 
            DateTime? fallBack = null) =>
            DateTime.TryParseExact (date,
                @"dd/MM/yyyy",
                CultureInfo.InvariantCulture.DateTimeFormat,
                DateTimeStyles.None,
                out var dt) ?
            dt :
            fallBack;

        public static string LocalTime (this DateTime dt) => 
            dt.ToString ("HH:mm");

        public static string LocalTime (
            this DateTimeOffset dt) => 
            dt.ToString ("HH:mm");

        public static string LocalDate (
            this DateTime dt) => 
            dt.ToString ("dd/MM/yyyy");

        public static string LocalDate (
            this DateTimeOffset dt) => 
            dt.ToString ("dd/MM/yyyy");

        public static string LocalDateTime (
            this DateTime dt) => 
            dt.ToString ("dd/MM/yyyy HH:mm");

        public static string LocalDateTime (
            this DateTimeOffset dt)
            => dt.ToString ("dd/MM/yyyy HH:mm");

        public static string Natural (
            this DateTimeOffset dt) => 
            dt.DateTime.Natural();

        public static string Timestamp (
            this DateTime dt) => 
            dt.ToString ("yyyyMMddHHmmss");

        public static DateTime StartOfWeek(
            this DateTime dt, 
            DayOfWeek startOfWeek) =>
            dt.AddDays(-1 * (7 + (dt.DayOfWeek - startOfWeek)) % 7).Date;

        public static DateTime StartOfWeek(
            this DateTimeOffset dt,
            DayOfWeek startOfWeek) =>
            StartOfWeek(dt.DateTime, startOfWeek);

        public static DateTime FirstDayOfMonth(
            this DateTime dt) => 
            new DateTime(dt.Year, dt.Month, 1);

        public static DateTime LastDayOfMonth(
            this DateTime dt) =>
            dt.FirstDayOfMonth().AddMonths(1).AddDays(-1);
    }
}