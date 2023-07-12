namespace FullTextSearchTDD.Tests;

public class DataReaderTest
{
    private const string path =
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
        var files = dataReader.ReadFilesFromADir(path);
        var fileNames = files.Select(Path.GetFileName);
        
        // Assert
        Assert.Contains(fileName, fileNames);
    }
}