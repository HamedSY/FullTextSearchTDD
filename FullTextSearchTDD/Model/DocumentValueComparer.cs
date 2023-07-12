namespace FullTextSearchTDD.Model;

public class DocumentValueComparer : IEqualityComparer<Document>
{
    public bool Equals(Document doc1, Document doc2)
    {
        return doc1.Name == doc2.Name && doc1.Content == doc2.Content;
    }

    public int GetHashCode(Document obj)
    {
        return HashCode.Combine(obj.Name, obj.Content);
    }
}