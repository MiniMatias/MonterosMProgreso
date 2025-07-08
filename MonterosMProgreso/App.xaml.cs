using MonterosMProgreso.Data;
namespace MonterosMProgreso;
public partial class App : Application
{
    public static PrendaDatabase Database { get; private set; }
    public App()
    {
        InitializeComponent();

        Database = new PrendaDatabase(Path.Combine(FileSystem.AppDataDirectory, "prendas.db3"));
        MainPage = new AppShell();
    }
}    

