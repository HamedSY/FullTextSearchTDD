using FullTextSearchTDD.Model;

namespace FullTextSearchTDD.Abstraction;

public interface IDataReader
{
    public IEnumerable<string> ReadFilesFromADir(string dirPath);
    public List<Document> MakeADocumentListFromFiles(IEnumerable<string> files);
}