using FullTextSearchTDD.Controller;
using FullTextSearchTDD.Model;

namespace FullTextSearchTDD.Tests;

public class SearcherTest
{
    private static readonly HashSet<string> DocumentNames = new HashSet<string> { "test1", "test2", "test3" };

    [Theory]
    [MemberData(nameof(HandleEachInputData))]
    public void HandleEachInput_MakeSetsCorrectly(SearchResult expectedSearchResult, string word,
        Dictionary<string, HashSet<string>> invertedIndex)
    {
        // Arrange
        var searcher = new Searcher();
        var searchResult = new SearchResult(DocumentNames);

        // Act
        searcher.HandleEachInput(word, invertedIndex, searchResult);

        // Assert
        Assert.Equal(expectedSearchResult, searchResult);
    }

    public static IEnumerable<object[]> HandleEachInputData()
    {
        var searchResult = new SearchResult(DocumentNames)
        {
            NecessaryWordsDocsNumbers = DocumentNames,
            AtLeastOneDocsNumbers = new HashSet<string> { "test1", "test2", "test3" },
            MustNotBeDocsNumbers = new HashSet<string>()
        };

        yield return new object[]
        {
            searchResult,
            "+hamed",
            new Dictionary<string, HashSet<string>>
            {
                { "SALAM", new HashSet<string> { "test1", "test2", "test3" } },
                { "HAMED", new HashSet<string> { "test1", "test3" } },
                { "KHOBI", new HashSet<string> { "test1" } },
                { "ALI", new HashSet<string> { "test2" } },
                { "CHETORI", new HashSet<string> { "test2" } },
                { "ALEIKE", new HashSet<string> { "test3" } },
                { "JOOOOON", new HashSet<string> { "test3" } },
                { "KHOBAM", new HashSet<string> { "test3" } }
            },
        };
    }
}