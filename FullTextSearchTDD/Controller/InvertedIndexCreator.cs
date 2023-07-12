namespace FullTextSearchTDD.Controller;

public class InvertedIndexCreator
{
    private readonly char[] _delimiterChars = new char[]
        { ' ', ',', '=', '-', '|', '>', '<', '(', ')', '?', '!', '.', '@', '/', '_', '\\', ':', '\"', '*' };

    public List<string> SplitUppedText(string text)
    {
        return text.ToUpper().Split(_delimiterChars, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}