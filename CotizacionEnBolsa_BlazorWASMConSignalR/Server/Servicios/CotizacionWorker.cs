

using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Threading;
using System.Threading.Tasks;

namespace CotizacionEnBolsa_BlazorWASMConSignalR.Server.Servicios
{
    public class CotizacionWorker : BackgroundService
    {
        private readonly ILogger<CotizacionWorker> logger;
        private readonly IHubContext<BolsaHub, IBolsaHub> bolsaHub;
        private readonly IBolsaPump bolsaPump;

        public CotizacionWorker(ILogger<CotizacionWorker> logger, IHubContext<BolsaHub, IBolsaHub> bolsaHub, IBolsaPump bolsaPump)
        {
            this.logger = logger;
            this.bolsaHub = bolsaHub;
            this.bolsaPump = bolsaPump;
        }


        /// <summary>
        /// Heredado de clase abstracta, a cal hai que modificar usando como base BackgroundService
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.bolsaPump.ActualizarAccion += BolsaPump_ActualizacionAccion;

            await this.bolsaPump.ExecuteAsync(stoppingToken);
            this.bolsaPump.ActualizarAccion -= BolsaPump_ActualizacionAccion;

        }

        private async void BolsaPump_ActualizacionAccion(object sender, Shared.CotizacionBolsa cotizacion)
        {
            await this.bolsaHub.Clients.All.EnviarInfoCotizacion(cotizacion);
        }
    }
}
