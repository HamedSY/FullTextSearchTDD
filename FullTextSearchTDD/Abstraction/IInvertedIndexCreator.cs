using FullTextSearchTDD.Model;

namespace FullTextSearchTDD.Abstraction;

public interface IInvertedIndexCreator
{
    public IEnumerable<string> SplitUppedText(string text);
    public Dictionary<string, HashSet<string>> CreateInvertedIndex(List<Document> documents);
}