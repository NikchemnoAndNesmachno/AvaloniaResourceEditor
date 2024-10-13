using AvaloniaResourceEditor.Services;

namespace AvaloniaResourceEditor.Views.ServiceImplementation;

public class FinishService(SelectFilesWindow window): IFinishWork
{
    public void Finish()
    {
        window.Close();
    }
}