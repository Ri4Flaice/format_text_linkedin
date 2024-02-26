namespace format_text_linkedin.Requests
{
    internal class PathFile
    {
        public string GetFilePath()
        {
            Console.Write("Specify the file path: ");
            string path = Console.ReadLine();

            return path;
        }
    }
}
