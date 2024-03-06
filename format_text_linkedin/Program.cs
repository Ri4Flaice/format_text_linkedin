using format_text_linkedin.Requests;
using format_text_linkedin.WorkTextFile;

class Program
{
    public static void Main(string[] args)
    {
        PathFile pathFile = new PathFile();
        string path = pathFile.GetFilePath();
        string currentDirectory = Environment.CurrentDirectory;
        string outputPath = $@"{currentDirectory}\output.txt";

        FormatLine formatLine = new FormatLine(path, outputPath);
        formatLine.FormattingLinesInTextFile();

        SizeText sizeText = new SizeText(outputPath);
        sizeText.DeleteWords();
    }
}