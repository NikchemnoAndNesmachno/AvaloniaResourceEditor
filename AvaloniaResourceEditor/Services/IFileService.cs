using System.Threading.Tasks;

namespace AvaloniaResourceEditor.Services;

public interface IFileService
{
    Task<string> GetFolder();
}