using FullTextSearchTDD.Model;

namespace FullTextSearchTDD.Tests;

public class DataReaderTest
{
    private const string Path =
        @"C:\Users\h.sabour\Documents\RiderProjects\StarAcademy\FullTextSearchTDD\FullTextSearchTDD\EnglishData";

    [Theory]
    [InlineData("57110")]
    [InlineData("59281")]
    [InlineData("59578")]
    public void ReadFiles_ShouldReadAllFilesInTheFolder(string fileName)
    {
        // Arrange
        var dataReader = new DataReader();

        // Act
        var files = dataReader.ReadFilesFromADir(Path);
        var fileNames = files.Select(System.IO.Path.GetFileName);
        
        // Assert
        Assert.Contains(fileName, fileNames);
    }

    [Theory]
    [InlineData("58043", ">This wouldn't happen to be the same thing as chiggers, would it>A truly awful parasitic affliction, as I understand it.  Tiny bug>dig deeply into the skin, burying themselves.  Yuck!  They have thes>things in OklahomaClose. My mother comes from Gainesville Tex, right across the borderThey claim to be the chigger capitol of the world, and I believe themWhen I grew up in Fort Worth it was bad enough, but in Gainesvillin the summer an attack was guaranteedDoug McDonal")]
    [InlineData("59297", "HiThought I'd add something to the conversation.My girlfriend used to work in a lab studying different natural carcinogensShe mentioned once about the cancerous effect of barbecued foodBasically, she said that if you eat barbecued foods with strawberrie(a natural carcinogen) the slight carcinogenic properties of botcancel out each other-Jeff Pouporjtpoupor@undergrad.math.uwaterloo.c--Jeff Pouporjtpoupor@undergrad.math.uwaterloo.c")]
    public void MakeADocumentListFromFiles_ShouldCreateACorrectList(string name, string content)
    {
        // Arrange
        var dataReader = new DataReader();
        var document = new Document(name, content);
        
        // Act
        var files = dataReader.ReadFilesFromADir(Path);
        var documents = dataReader.MakeADocumentListFromFiles(files);
        
        // Assert
        Assert.Contains(document, documents);
    }
}