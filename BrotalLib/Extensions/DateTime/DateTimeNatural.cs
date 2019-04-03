using System;
using System.Text;

namespace Brotal.Extensions
{
    public static partial class DateTimeExtensions
    {
        public static string Natural(this DateTime dt, bool capitalizeFirstLetter = false)
        {
            #region Calculate Values
            var originalSpan = DateTime.Now.Subtract(dt);
            var span = originalSpan;
            var future = span.TotalSeconds < 0;
            if (future) span = span.Negate();

            var years = (int)(span.TotalDays / 365);
            span -= TimeSpan.FromDays(years * 365);

            var months = (int)(span.TotalDays / 30);
            span -= TimeSpan.FromDays(months * 30);

            var weeks = (int)(span.TotalDays / 7);
            span -= TimeSpan.FromDays(weeks * 7);

            var days = span.Days;
            span -= TimeSpan.FromDays(days);

            var hours = span.Hours;
            span -= TimeSpan.FromHours(hours);

            var minutes = span.Minutes;
            span -= TimeSpan.FromMinutes(minutes);

            var seconds = span.Seconds;
            #endregion

            var result = new StringBuilder();
            if (future && capitalizeFirstLetter)
                result.Append("In ");
            if (future)
                result.Append("in ");

            if (years == 1)
                result.Append("1 year");
            else if (years > 1)
                result.Append(years).Append(" years");
            else
            {
                if (months == 1)
                    result.Append("1 month");
                else if (months > 1)
                    result.Append(months).Append(" months");
                else
                {
                    if (weeks == 1)
                        result.Append("1 week");
                    else if (weeks > 1)
                        result.Append(weeks).Append(" weeks");
                    else
                    {
                        if (days == 1)
                            result.Append("1 day");
                        else if (days > 1)
                            result.Append(days).Append(" days");
                        else
                        {
                            if (hours == 1)
                                result.Append("1 hour");
                            else if (hours > 1)
                                result.Append(hours).Append(" hours");
                            else
                            {
                                if (minutes == 1)
                                    result.Append("1 minute");
                                else if (minutes > 1)
                                    result.Append(minutes).Append(" minutes");
                                else
                                {
                                    if (seconds > 10)
                                        result.Append(seconds - seconds % 10).Append(" seconds");
                                    else if (future)
                                        result.Append("a bit");
                                    else if (capitalizeFirstLetter)
                                        result.Append("Just now");
                                    else
                                        result.Append("just now");
                                }
                            }
                        }
                    }
                }
            }

            if (!future && originalSpan > TimeSpan.FromSeconds(10))
                result.Append(" ago");

            return result.ToString();
        }

    }
}
