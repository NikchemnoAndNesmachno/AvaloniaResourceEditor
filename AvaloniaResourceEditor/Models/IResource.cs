using System.Collections.Generic;

namespace AvaloniaResourceEditor.Models;

public interface IResource
{
    string Name { get; set; }
    IList<ITagValue> Values { get; set; }
    ITagValue Create();
}