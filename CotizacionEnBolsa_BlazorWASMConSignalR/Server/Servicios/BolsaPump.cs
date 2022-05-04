using CotizacionEnBolsa_BlazorWASMConSignalR.Shared;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CotizacionEnBolsa_BlazorWASMConSignalR.Server.Servicios
{
    public class BolsaPump : IBolsaPump
    {
        public event EventHandler<CotizacionBolsa> ActualizarAccion;

        private List<CotizacionBolsa> cotizacions = new List<CotizacionBolsa>(); //simula os cambios de precio

        public BolsaPump()
        {
            this.Iniciar();
        }

        private void Iniciar()
        {
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "MSFT", Precio = 80, PrecioBase = 80, Volumen = 2000, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "AAPL", Precio = 100, PrecioBase = 100, Volumen = 3000, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "TSLA", Precio = 350, PrecioBase = 350, Volumen = 120, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "NVDA", Precio = 420, PrecioBase = 420, Volumen = 400, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "GOOG", Precio = 1640, PrecioBase = 1640, Volumen = 110, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "AMZN", Precio = 3200, PrecioBase = 3200, Volumen = 99, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "710000", Precio = 34.845, PrecioBase = 34.845, Volumen = 3990203, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "703712", Precio = 28.73, PrecioBase = 28.73, Volumen = 4972549, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "823212", Precio = 6.892, PrecioBase = 6.892, Volumen = 9374495, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "604700", Precio = 44.54, PrecioBase = 44.54, Volumen = 1052172, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "ENAG99", Precio = 8.816, PrecioBase = 8.816, Volumen = 8198277, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "A0WMPJ", Precio = 8.87, PrecioBase = 8.87, Volumen = 1715021, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "555750", Precio = 12.655, PrecioBase = 12.655, Volumen = 16028358, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "716460", Precio = 90.18, PrecioBase = 90.18, Volumen = 6439388, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "581005", Precio = 125.3, PrecioBase = 125.3, Volumen = 753801, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "BASF11", Precio = 46.31, PrecioBase = 46.31, Volumen = 3644131, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "BAY001", Precio = 40.005, PrecioBase = 40.005, Volumen = 6964005, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "843002", Precio = 196.75, PrecioBase = 196.75, Volumen = 808543, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "555200", Precio = 29.07, PrecioBase = 29.07, Volumen = 4172211, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "578560", Precio = 31.24, PrecioBase = 31.24, Volumen = 12094230, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "520000", Precio = 88.94, PrecioBase = 88.94, Volumen = 408959, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "606214", Precio = 31.98, PrecioBase = 31.98, Volumen = 1767693, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "A0D9PT", Precio = 130, PrecioBase = 130, Volumen = 254502, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "604843", Precio = 78.84, PrecioBase = 78.84, Volumen = 800386, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "A2DSYC", Precio = 173.65, PrecioBase = 173.65, Volumen = 1248213, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "578580", Precio = 64.86, PrecioBase = 64.86, Volumen = 1189784, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "A1EWWW", Precio = 224.1, PrecioBase = 224.1, Volumen = 747668, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "A1ML7J", Precio = 52.4, PrecioBase = 52.4, Volumen = 14648193, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "766403", Precio = 123.42, PrecioBase = 123.42, Volumen = 1124661, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "846900", Precio = 11463.9, PrecioBase = 11463.9, Volumen = 100607290, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "623100", Precio = 18.936, PrecioBase = 18.936, Volumen = 4419546, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "519000", Precio = 54.39, PrecioBase = 54.39, Volumen = 1694979, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "840400", Precio = 149.32, PrecioBase = 149.32, Volumen = 1288010, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "703000", Precio = 61.58, PrecioBase = 61.58, Volumen = 178345, Hora = DateTime.Now });
            this.cotizacions.Add(new CotizacionBolsa() { Simbolo = "543900", Precio = 81.72, PrecioBase = 81.72, Volumen = 450792, Hora = DateTime.Now });

        }

        /// <summary>
        /// Simula cambios de precio constantes, cun delay de 50 milisegundos
        /// </summary>
        /// <param name="pararToken"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(CancellationToken pararToken)
        {
            int i = 0;

            //definimos 3 randomizers
            Random rndPrecio = new Random();
            Random rndVol = new Random();
            Random rndIndice = new Random();

            while (!pararToken.IsCancellationRequested)
            {
                i = (int)(rndIndice.NextDouble() * this.cotizacions.Count);

                if (i < this.cotizacions.Count)
                {
                    var cotizacion = this.cotizacions[i];

                    var p = cotizacion.Precio * (((rndPrecio.NextDouble() - 0.48d) / 1000d) + 1d);
                    cotizacion.Precio = Math.Round(p, 2);
                    cotizacion.Volumen = (int)(rndVol.NextDouble() * 3000d / p);
                    cotizacion.Hora = DateTime.Now;

                    this.ActualizarAccion?.Invoke(this, cotizacion);
                }

                await Task.Delay(50);
            }
        }
    }
}
