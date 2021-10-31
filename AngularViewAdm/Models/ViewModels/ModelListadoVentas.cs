using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularViewAdm.Models.ViewModels
{
    public class ModelListadoVentas
    {
        public List<VentaEspacio> ventaEspacios { get; set; }
        public List<Vendedores> Vendedores { get; set; }
    }
}
