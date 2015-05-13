using System;
using System.Text.RegularExpressions;

namespace Ignobilis.Business.Extensions
{
    public static class StringExtensions
    {
        public static bool IsURL(this string urlText)
        {
            try
            {
                var isUrl = Regex.IsMatch(urlText,
                    @"\b(?:(?:https?|ftp|file)://|www\.|ftp\.)[-A-Ö0-9+&@#/%=~_|$?!:,.]*[A-Ö0-9+&@#/%=~_|$]",
                    RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                return isUrl;
            }
            catch (ArgumentException ex)
            {
                //LM_Log.WriteError(ex);
                return false;
            }
        }

        public static bool IsFilePath(this string path)
        {
            bool isUrl;
            try
            {
                isUrl = Regex.IsMatch(path,
                    @"(?:\b[a-z]:|\\\\[a-z0-9 %._-]+\\[a-z0-9 $%._-]+)\\  # Drive
		            (?:[^\\/:*?""<>|\r\n]+\\)*                           # Folder
		            [^\\/:*?""<>|\r\n]*                                  # File",
                    RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            }
            catch (ArgumentException ex)
            {
                //LM_Log.WriteError(ex);
                return false;
            }
            return isUrl;
        }
    }
}