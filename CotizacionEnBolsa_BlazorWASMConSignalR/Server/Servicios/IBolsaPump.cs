using CotizacionEnBolsa_BlazorWASMConSignalR.Shared;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace CotizacionEnBolsa_BlazorWASMConSignalR.Server.Servicios
{
    public interface IBolsaPump
    {
        event EventHandler<CotizacionBolsa> ActualizarAccion;

        Task ExecuteAsync(CancellationToken pararToken);
    }
}
