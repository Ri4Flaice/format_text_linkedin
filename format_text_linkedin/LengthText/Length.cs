namespace format_text_linkedin.LengthText
{
    internal class Length
    {
        public int GetLengthText(string path)
        {
            string text = File.ReadAllText(path);
            int length = text.Length;

            return length;
        }
    }
}
