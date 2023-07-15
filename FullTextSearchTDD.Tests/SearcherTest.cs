using FluentAssertions;
using FullTextSearchTDD.Abstraction;
using FullTextSearchTDD.Controller;
using FullTextSearchTDD.Model;

namespace FullTextSearchTDD.Tests;

public class SearcherTest
{
    private static readonly HashSet<string> TestDocumentNames = new() { "test1", "test2", "test3" };
    private static readonly Dictionary<string, HashSet<string>> TestInvertedIndex = new()
    {
        { "SALAM", new HashSet<string> { "test1", "test2", "test3" } },
        { "HAMED", new HashSet<string> { "test1", "test3" } },
        { "KHOBI", new HashSet<string> { "test1" } },
        { "ALI", new HashSet<string> { "test2" } },
        { "CHETORI", new HashSet<string> { "test2" } },
        { "ALEIKE", new HashSet<string> { "test3" } },
        { "JOOOOON", new HashSet<string> { "test3" } },
        { "KHOBAM", new HashSet<string> { "test3" } }
    };

    private readonly ISearcher _searcher;

    public SearcherTest()
    {
        _searcher = new Searcher();
    }

    [Theory]
    [MemberData(nameof(HandleEachInputData))]
    public void HandleEachInput_MakeSetsCorrectly(SearchResult expectedSearchResult, string word,
        Dictionary<string, HashSet<string>> invertedIndex)
    {
        // Arrange
        var searchResult = new SearchResult(TestDocumentNames);

        // Act
        _searcher.HandleEachInput(word, invertedIndex, searchResult);

        // Assert
        searchResult.Should().BeEquivalentTo(expectedSearchResult);
    }

    public static IEnumerable<object[]> HandleEachInputData()
    {
        yield return new object[]
        {
            new SearchResult(TestDocumentNames)
            {
                AtLeastOneDocsNumbers = new HashSet<string> { "test1", "test3" },
                MustNotBeDocsNumbers = new HashSet<string>()
            },
            "+HAMED", TestInvertedIndex
        };
        yield return new object[]
        {
            new SearchResult(TestDocumentNames)
            {
                AtLeastOneDocsNumbers = new HashSet<string>(),
                MustNotBeDocsNumbers = new HashSet<string>() { "test2" }
            },
            "-ALI", TestInvertedIndex
        };
        yield return new object[]
        {
            new SearchResult
            {
                NecessaryWordsDocsNumbers = new HashSet<string> { "test3" },
                AtLeastOneDocsNumbers = new HashSet<string>(),
                MustNotBeDocsNumbers = new HashSet<string>()
            },
            "KHOBAM", TestInvertedIndex
        };
    }

    [Theory]
    [MemberData(nameof(CalculateFoundDocsNumbersData))]
    public void CalculateFoundDocsNumbers_ShouldReturnFoundDocsNumbers_WhenGetsASearchResult(
        HashSet<string> expectedFoundDocsNumbers, SearchResult searchResult)
    {
        // Act
        var foundDocsNumbers = _searcher.FindWord(searchResult);

        // Assert
        foundDocsNumbers.Should().BeEquivalentTo(expectedFoundDocsNumbers);
    }

    public static IEnumerable<object[]> CalculateFoundDocsNumbersData()
    {
        yield return new object[]
        {
            new HashSet<string> { "test1" },
            new SearchResult
            {
                NecessaryWordsDocsNumbers = new HashSet<string> { "test1" },
                AtLeastOneDocsNumbers = new HashSet<string> { "test1", "test2" },
                MustNotBeDocsNumbers = new HashSet<string> { "test2" }
            }
        };
        yield return new object[]
        {
            new HashSet<string> { "test2", "test3" },
            new SearchResult(TestDocumentNames)
            {
                AtLeastOneDocsNumbers = new HashSet<string> { "test1", "test2", "test3" },
                MustNotBeDocsNumbers = new HashSet<string> { "test1" }
            }
        };
        yield return new object[]
        {
            new HashSet<string>(),
            new SearchResult(TestDocumentNames)
            {
                AtLeastOneDocsNumbers = new HashSet<string>(),
                MustNotBeDocsNumbers = new HashSet<string> {"test1", "test2", "test3" }
            }
        };
    }
}