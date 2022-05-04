using System;
using System.Collections.Generic;
using System.Text;

namespace CotizacionEnBolsa_BlazorWASMConSignalR.Shared
{
    public class CotizacionBolsa
    {
        public event EventHandler CotizacionActualizada;

        public string Simbolo { get; set; }
        public double Precio { get; set; }
        public double PrecioBase { get; set; }
        public double PrecioRecente { get; private set; }
        public double Porcentaxe
        {
            get
            {
                return (PrecioBase == 0) ? 0 : (Precio / PrecioBase * 100d) - 100d;
            }
        }

        public bool IncrementoPrecio { get; private set; }
        public int Volumen { get; set; }
        public DateTime Hora { get; set; }

        /// <summary>
        /// Actualizamos todas as propiedades en canto recibimos un obxecto CotizacionBolsa con cambios de precios
        /// </summary>
        /// <param name="novosValores"></param>
        public void UpdateDatosAccions(CotizacionBolsa novosValores)
        {
            this.IncrementoPrecio = novosValores.Precio > this.PrecioRecente;

            this.PrecioRecente = this.Precio;
            this.Precio = novosValores.Precio;
            this.Volumen = novosValores.Volumen;
            this.Hora = novosValores.Hora;

            this.CotizacionActualizada?.Invoke(this, new EventArgs());
        }
    }
}
