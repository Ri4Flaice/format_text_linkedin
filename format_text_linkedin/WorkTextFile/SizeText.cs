using format_text_linkedin.FormatText;
using format_text_linkedin.LengthText;

namespace format_text_linkedin.WorkTextFile
{
    internal class SizeText
    {
        private string _outputPath;
        private int _lengthText;
        private Length _length;
        private UnnecessaryWords _unnecessaryWords;

        public SizeText(string outputPath)
        {
            _outputPath = outputPath;

            _length = new Length();
            _unnecessaryWords = new UnnecessaryWords();
        }

        public void DeleteWords()
        {
            _lengthText = _length.GetLengthText(_outputPath);

            if (_lengthText > 4000)
            {
                Console.WriteLine($"\nThe number of characters is more than 4000!!!\n" +
                    $"Number of characters: {_lengthText}");

                Console.Write($"\nDo you want to shorten the text to 4000 (y/n):");
                string choiceUser = Console.ReadLine();

                if (choiceUser.ToLower() == "y")
                {
                    _unnecessaryWords.DeleteUnnecessaryWords(_outputPath);
                    _lengthText = _length.GetLengthText(_outputPath);
                    Console.WriteLine($"Number of characters: {_lengthText}");
                }
            }
            else
            {
                Console.WriteLine($"Number of characters: {_lengthText}");
            }
        }
    }
}
