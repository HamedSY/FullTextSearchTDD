using System.Collections;
using FluentAssertions;
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
        splitText.Should().BeEquivalentTo(expectedSplitText);
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
        invertedIndex.Should().BeEquivalentTo(expectedInvertedIndex);
    }

    public static IEnumerable<object[]> DocumentsData()
    {
        yield return new object[]
        {
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
            new List<Document>
            {
                new("test1", "Salam Hamed Khobi"),
                new("test2", "Salam Ali Chetori"),
                new("test3", "Aleike Salam Hamed Jooooon Khobam"),
            }
        };
    }
}