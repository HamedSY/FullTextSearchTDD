namespace FullTextSearchTDD.Tests;

public class DataReaderTest
{
    private const string Path =
        @"C:\Users\h.sabour\Documents\RiderProjects\StarAcademy\FullTextSearchTDD\FullTextSearchTDD\EnglishData";

    [Theory]
    [InlineData("57110")]
    [InlineData("59281")]
    [InlineData("59578")]
    public void ReadData_ShouldReadAllFilesInTheFolder(string fileName)
    {
        // Arrange
        var dataReader = new DataReader();

        // Act
        var files = dataReader.ReadFiles();
        
        // Assert
        Assert.Contains(fileName, files);
    }
}

public class DataReader
{
    public IEnumerable<string> ReadFiles()
    {
        throw new NotImplementedException();
    }
}