using FullTextSearchTDD.Model;

namespace FullTextSearchTDD.Controller;

public class Searcher
{
    public void HandleEachInput(string word, Dictionary<string,HashSet<string>> invertedIndex, SearchResult searchResult)
    {
        // At least one of these words should be in the documents
        if (word.StartsWith("+"))
            searchResult.AtLeastOneDocsNumbers.UnionWith(invertedIndex[word[1..]]);

        // These words must not be in the document
        else if (word.StartsWith("-"))
            searchResult.MustNotBeDocsNumbers.UnionWith(invertedIndex[word[1..]]);

        // These words should be in the documents
        else
            searchResult.NecessaryWordsDocsNumbers.IntersectWith(invertedIndex[word]);
    }

    public HashSet<string> FindWord(SearchResult searchResult)
    {
        var foundDocsNumbers = new HashSet<string>(searchResult.NecessaryWordsDocsNumbers);
        if (searchResult.AtLeastOneDocsNumbers.Any())
            foundDocsNumbers.IntersectWith(searchResult.AtLeastOneDocsNumbers);
        foundDocsNumbers.ExceptWith(searchResult.MustNotBeDocsNumbers);
        return foundDocsNumbers;
    }
}