using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using AvaloniaResourceEditor.Services;

namespace AvaloniaResourceEditor.Views.ServiceImplementation;

public class FileService(SelectFilesWindow window): IFileService
{
    public async Task<string> GetFolder()
    {
        var folders = await window.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions()
        {
            Title = "Обрати теку за axaml"
        });
        return folders.Count == 0 ? "" : folders[0].Path.AbsolutePath;
    }
}