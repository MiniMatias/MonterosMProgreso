using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MonterosMProgreso.Models;
using MonterosMProgreso.Data;

namespace MonterosMProgreso.ViewModels;

public class ListaPrendasViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Prenda> Prendas { get; } = new();
    private readonly PrendaDatabase _database;

    public ICommand CargarCommand { get; }

    public ListaPrendasViewModel()
    {
        _database = App.Database;
        CargarCommand = new Command(async () => await Cargar());
        _ = Cargar(); // carga automática al iniciar
    }

    public async Task Cargar()
    {
        var lista = await _database.GetPrendasAsync();
        Prendas.Clear();
        foreach (var prenda in lista)
            Prendas.Add(prenda);
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
}
