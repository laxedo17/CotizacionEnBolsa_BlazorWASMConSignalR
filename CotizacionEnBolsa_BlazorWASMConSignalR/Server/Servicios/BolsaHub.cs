using CotizacionEnBolsa_BlazorWASMConSignalR.Server.Servicios;
using CotizacionEnBolsa_BlazorWASMConSignalR.Shared;

using Microsoft.AspNetCore.SignalR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionEnBolsa_BlazorWASMConSignalR.Server.Servicios
{
    public static class XestorUsuario
    {
        public static HashSet<string> IdsConectadas = new HashSet<string>();
    }

    public class BolsaHub : Hub<IBolsaHub>
    {
        public override async Task OnConnectedAsync()
        {
            XestorUsuario.IdsConectadas.Add(Context.ConnectionId);

            var msx = $"{Context.ConnectionId} uniuse a hub (Instancia:{this.GetHashCode()})  clientes-conta:{XestorUsuario.IdsConectadas.Count}";
            await Clients.All.HubMensaxeCotizacion(msx).ConfigureAwait(false);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            XestorUsuario.IdsConectadas.Remove(Context.ConnectionId);

            var msx = $"{Context.ConnectionId} saiu do hub (Instancia:{this.GetHashCode()})  clientes-conta:{XestorUsuario.IdsConectadas.Count}";
            await Clients.All.HubMensaxeCotizacion(msx);
            await base.OnDisconnectedAsync(exception);
        }

        public Task HubMensaxeCotizacion(string msx)
        {
            return Clients.All.HubMensaxeCotizacion(msx);
        }

        public Task EnviarInfo(CotizacionBolsa cotizacion)
        {
            return Clients.All.EnviarInfoCotizacion(cotizacion);
        }
    }
}
