using System.Text.RegularExpressions;

namespace format_text_linkedin.FormatText
{
    internal class RegularExpression
    {
        public bool IsNumeric(string line)
        {
            return Regex.IsMatch(line, @"^\d+$");
        }

        public bool IsTimestamp(string line)
        {
            return Regex.IsMatch(line, @"^\d{2}:\d{2}:\d{2},\d{2} --> \d{2}:\d{2}:\d{2},\d{2}$") || 
                Regex.IsMatch(line, @"^\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}$") ||
                Regex.IsMatch(line, @"^\d{2}:\d{2}:\d{2},\d{2} --> \d{2}:\d{2}:\d{2},\d{3}$") ||
                Regex.IsMatch(line, @"^\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{2}$");
        }

        public void ReplaceText(string path)
        {
            string text = File.ReadAllText(path);

            text = Regex.Replace(text, @"^-\s+\[.+?\]\s+", "", RegexOptions.Multiline);
            text = Regex.Replace(text, @"^- ", "", RegexOptions.Multiline);

            text = DeleteLineBreak(text);
            text = DeleteSpace(text, @"[ ]{4}");
            text = DeleteSpace(text, @"[ ]{3}");
            text = DeleteSpace(text, @"[ ]{2}");

            File.WriteAllText(path, text);
        }

        private string DeleteLineBreak(string text)
        {
            return text.Replace("\n", " ").Replace("\r", " ");
        }

        private string DeleteSpace(string text, string regularExpension)
        {
            return Regex.Replace(text, regularExpension, " ");
        }
    }
}
