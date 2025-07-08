using System.Collections.ObjectModel;
using System.ComponentModel;

namespace InventarioRopa_Monteros.ViewModels;

public class LogsViewModel : INotifyPropertyChanged
{
    public ObservableCollection
<string> Registros
    { get; } = new();

    public LogsViewModel()
    {
        CargarLogs();
    }

    private void CargarLogs()
    {
        string ruta = Path.Combine(FileSystem.AppDataDirectory, "Logs_Monteros.txt");
        if (File.Exists(ruta))
        {
            var lineas = File.ReadAllLines(ruta);
            foreach (var linea in lineas)
                Registros.Add(linea);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}