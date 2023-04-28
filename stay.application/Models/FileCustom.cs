namespace stay.application.Models
{
    public class FileCustom
    {
        public string Name { get; set; }
        public Stream Content { get; set; }

        public FileCustom(string name, Stream content)
        {
            Name = name;
            Content = content;
        }
    }
}