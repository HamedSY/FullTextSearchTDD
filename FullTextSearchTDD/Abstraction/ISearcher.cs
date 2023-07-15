using FullTextSearchTDD.Model;

namespace FullTextSearchTDD.Abstraction;

public interface ISearcher
{
    public void HandleEachInput(string word, Dictionary<string, HashSet<string>> invertedIndex,
        SearchResult searchResult);

    public HashSet<string> FindWord(SearchResult searchResult);
}