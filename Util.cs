using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPManagement
{
    class Util
    {
        public bool IsMatchFileName(string fileName, string pattern)
        {
            var regexPattern = "^" + System.Text.RegularExpressions.Regex.Escape(pattern)
                .Replace("\\*", ".*")
                .Replace("\\?", ".") + "$";
            return System.Text.RegularExpressions.Regex.IsMatch(fileName, regexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        public bool IsUnderIgnoredDirectory(string path, string[] ignorePatterns)
        {
            string relativePath = path.Replace("\\", "/");
            return ignorePatterns.Any(pattern =>
                relativePath.Equals(pattern) ||
                relativePath.StartsWith(pattern.TrimEnd('*').TrimEnd('/')) ||
                relativePath.Contains(pattern.TrimEnd('*').TrimEnd('/')) && (relativePath.IndexOf(pattern.TrimEnd('*').TrimEnd('/')) + pattern.TrimEnd('*').TrimEnd('/').Length) == relativePath.Length);
        }
    }
}
