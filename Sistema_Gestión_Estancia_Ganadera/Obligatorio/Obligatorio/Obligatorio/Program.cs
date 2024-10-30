using System.Formats.Tar;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Obligatorio.Dominio;

namespace Obligatorio.MiApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema _sistema = Sistema.Instance();
            _sistema.MostrarPotrerosEnConsola(10, 10);
            _sistema.MostrarGanadoEnConsola();
            _sistema.EstablecerCostoKgLanaOvinos();
            _sistema.LoginUsersConsola();
            _sistema.AltaBovinoConsola();
        }
    }
}









