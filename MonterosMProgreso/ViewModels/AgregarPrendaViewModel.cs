using System.ComponentModel;
using System.Windows.Input;
using MonterosMProgreso.Data;
using MonterosMProgreso.Models;

namespace MonterosMProgreso.ViewModels
{
    public class AgregarPrendaViewModel : INotifyPropertyChanged
    {
        public string Nombre { get; set; }
        public string Color { get; set; }
        public int Talla { get; set; }
        public bool EnInventario { get; set; }
        public ICommand GuardarCommand { get; }
        private readonly PrendaDatabase _database;
        public AgregarPrendaViewModel()
        {
            _database = App.Database;
            GuardarCommand = new Command(async () => await Guardar());
        }
        private async Task Guardar()
        {
            if (EnInventario && Talla < 10)
            {
                await App.Current.MainPage.DisplayAlert("Error", "La talla debe ser mayor o igual a 10 para prendas en inventario.", "OK");
                return;
            }
            var prenda = new Prenda
            {
                Nombre = Nombre,
                Color = Color,
                Talla = Talla,
                EnInventario = EnInventario
            };
            await _database.SavePrendaAsync(prenda);
            string logpath = Path.Combine(FileSystem.AppDataDirectory, "log.txt");
            string log = $"Se incluyo el registro [{Nombre}] el {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n";
            File.AppendAllText(logpath, log);
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
        
    