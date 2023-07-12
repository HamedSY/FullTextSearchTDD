using System.Collections;
using FullTextSearchTDD.Controller;

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
}