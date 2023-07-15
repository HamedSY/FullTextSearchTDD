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
        Dictionary<string, HashSet<string>> invertedIndex = new Dictionary<string, HashSet<string>>();
        // Iterate on our data
        foreach (var doc in documents)
        {
            var documentWords = SplitUppedText(doc.Content);
            foreach (var word in documentWords)
            {
                if (!invertedIndex.ContainsKey(word))
                    invertedIndex[word] = new HashSet<string> { doc.Name };
                else
                    // Add the file name to the word's index in the dictionary (inverted index)
                    invertedIndex[word].Add(doc.Name);
            }
        }

        return invertedIndex;
    }
}