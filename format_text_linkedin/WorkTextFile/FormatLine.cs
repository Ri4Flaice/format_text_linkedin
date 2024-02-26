using format_text_linkedin.FormatText;

namespace format_text_linkedin.WorkTextFile
{
    internal class FormatLine
    {
        private string _sourcePath;
        private string _outputPath;

        RegularExpression _regularExpression;

        public FormatLine(string sourcePath, string outputPath)
        {
            _sourcePath = sourcePath;
            _outputPath = outputPath;

            _regularExpression = new RegularExpression();
        }

        public void FormattingLinesInTextFile()
        {
            string[] lines = File.ReadAllLines(_sourcePath);

            using (StreamWriter writer = new StreamWriter(_outputPath))
            {
                foreach (string line in lines)
                {
                    if (!_regularExpression.IsNumeric(line) && !_regularExpression.IsTimestamp(line))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            _regularExpression.ReplaceText(_outputPath);
        }
    }
}
