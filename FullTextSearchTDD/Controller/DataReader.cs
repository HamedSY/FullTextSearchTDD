using FullTextSearchTDD.Model;

namespace FullTextSearchTDD;

public class DataReader
{
    public IEnumerable<string> ReadFilesFromADir(string dirPath)
    {
        return Directory.EnumerateFiles(dirPath);
    }

    public List<Document> MakeADocumentListFromFiles(IEnumerable<string> files)
    {
        throw new NotImplementedException();
    }
}