namespace FullTextSearchTDD;

public class DataReader
{
    public IEnumerable<string> ReadFilesFromADir(string dirPath)
    {
        return Directory.EnumerateFiles(dirPath);
    }
}