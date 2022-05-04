using CotizacionEnBolsa_BlazorWASMConSignalR.Shared;

using System.Threading.Tasks;

namespace CotizacionEnBolsa_BlazorWASMConSignalR.Server.Servicios
{
    public interface IBolsaHub
    {
        Task EnviarInfoCotizacion(CotizacionBolsa cotizacion);
        Task HubMensaxeCotizacion(string msx);
    }
}
