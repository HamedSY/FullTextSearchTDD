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
        return files.Select(f => new Document(Path.GetFileName(f), File.ReadAllText(f))).ToList();
    }
}