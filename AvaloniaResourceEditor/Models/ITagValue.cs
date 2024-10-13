namespace AvaloniaResourceEditor.Models;

public interface ITagValue
{
    string Type { get; set; }
    string Key { get; set; }
    string Value { get; set; }
    
    ITagValue Copy();
}