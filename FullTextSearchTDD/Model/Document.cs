namespace FullTextSearchTDD.Model;

public class Document
{
    public string Name { set; get; }
    public string Content { set; get; }

    public Document(string name, string content)
    {
        Name = name;
        Content = content;
    }
}