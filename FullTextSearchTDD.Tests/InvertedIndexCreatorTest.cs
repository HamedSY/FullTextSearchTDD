using System.Collections;

namespace FullTextSearchTDD.Tests;

public class InvertedIndexCreatorTest
{
    [Theory]
    [MemberData(nameof(SplitTextData))]
    public void SplitText_ReturnCorrectSplitText(List<string> expectedSplitText, string text)
    {
        // Arrange
        var invertedIndexCreator = new InvertedIndexCreator();

        // Act
        var splitText = invertedIndexCreator.SplitText(text);

        // Assert
        Assert.True(expectedSplitText.SequenceEqual(splitText));
    }

    public static IEnumerable<object[]> SplitTextData()
    {
        yield return new object[] { new List<string> { "Hello", "How", "are", "you" }, "Hello----!!!How   are you??" };
    }
}

public class InvertedIndexCreator
{
    public List<string> SplitText(string text)
    {
        throw new NotImplementedException();
    }
}