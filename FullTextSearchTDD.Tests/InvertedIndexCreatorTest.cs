using System.Collections;
using FullTextSearchTDD.Controller;
using FullTextSearchTDD.Model;

namespace FullTextSearchTDD.Tests;

public class InvertedIndexCreatorTest
{
    [Theory]
    [MemberData(nameof(SplitTextData))]
    public void SplitUppedText_ReturnCorrectSplitText(List<string> expectedSplitText, string text)
    {
        // Arrange
        var invertedIndexCreator = new InvertedIndexCreator();

        // Act
        var splitText = invertedIndexCreator.SplitUppedText(text);

        // Assert
        Assert.True(expectedSplitText.SequenceEqual(splitText));
    }

    public static IEnumerable<object[]> SplitTextData()
    {
        yield return new object[] { new List<string> { "HELLO", "HOW", "ARE", "YOU" }, "Hello----!!!How   are you??" };
        yield return new object[] { new List<string> { "YOU", "KNOW" }, "yoU@---knoW???!" };
    }

    [Theory]
    [MemberData(nameof(DocumentsData))]
    public void CreateInvertedIndex_ReturnCorrectInvertedIndex(
        Dictionary<string, HashSet<string>> expectedInvertedIndex,
        List<Document> documents)
    {
        // Arrange
        var invertedIndexCreator = new InvertedIndexCreator();

        // Act
        var invertedIndex = invertedIndexCreator.CreateInvertedIndex(documents);

        // Assert
        Assert.True(expectedInvertedIndex.SequenceEqual(invertedIndex));
    }

    public static IEnumerable<object[]> DocumentsData()
    {
        yield return new object[]
        {
            new Dictionary<string, HashSet<string>>
            {
                { "Salam", new HashSet<string> { "test1", "test2", "test3" } },
                { "Hamed", new HashSet<string> { "test1", "test3" } },
                { "Khobi", new HashSet<string> { "test1" } },
                { "Ali", new HashSet<string> { "test2" } },
                { "Chetori", new HashSet<string> { "test2" } },
                { "Aleike", new HashSet<string> { "test3" } },
                { "Jooooon", new HashSet<string> { "test3" } },
                { "Khobam", new HashSet<string> { "test3" } }
            },
            new List<Document>
            {
                new("test1", "Salam Hamed Khobi"),
                new("test2", "Salam Ali Chetori"),
                new("test3", "Aleike Salam Hamed Jooooon Khobam"),
            }
        };
    }
}