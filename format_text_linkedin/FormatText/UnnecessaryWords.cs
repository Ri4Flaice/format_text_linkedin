using System.Text;

namespace format_text_linkedin.FormatText
{
    internal class UnnecessaryWords
    {
        public void DeleteUnnecessaryWords(string path)
        {
            string[] lines = File.ReadAllLines(path);
            string text = string.Join(" ", lines);

            string[] sentences = text.Split(new[] { ". " }, StringSplitOptions.None);

            StringBuilder sb = new StringBuilder();
            foreach (var sentence in sentences)
            {
                if (sb.Length + sentence.Length > 4000)
                    break;

                sb.Append(sentence);
                sb.Append(". ");
            }

            File.WriteAllText(path, sb.ToString());
        }
    }
}
