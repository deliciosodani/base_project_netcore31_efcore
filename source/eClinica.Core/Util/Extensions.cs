using System;

namespace eClinica.Core.Util
{
    public static class Extensions
    {
        public static DateTime PanamaDateTime(this DateTime UtcNow)
        {
            DateTime timeUtc = UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Uruguay Time"); // (GMT-3) Uruguay "Uruguay Time"
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
        }

        public static string GetFileNameFromURL(this string Url)
        {
            string filename = "";

            if (Url != null && Url != string.Empty)
            {
                var startFileNamePos = Url.LastIndexOf("/");
                filename = startFileNamePos > 0 ? Url.Substring(startFileNamePos + 1) : "";
            }

            return filename;            
        }
    }
}