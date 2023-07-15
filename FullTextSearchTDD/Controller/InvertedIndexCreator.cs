using FullTextSearchTDD.Model;

namespace FullTextSearchTDD.Controller;

public class InvertedIndexCreator
{
    private readonly char[] _delimiterChars = new char[]
        { ' ', ',', '=', '-', '|', '>', '<', '(', ')', '?', '!', '.', '@', '/', '_', '\\', ':', '\"', '*' };

    public IEnumerable<string> SplitUppedText(string text)
    {
        return text.ToUpper().Split(_delimiterChars, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public Dictionary<string, HashSet<string>> CreateInvertedIndex(List<Document> documents)
    {
        throw new NotImplementedException();
    }
}