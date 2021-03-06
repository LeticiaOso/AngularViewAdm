using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularViewAdm.Models
{
    public partial class Evento
    {
        public Evento()
        {
            Caja = new HashSet<Caja>();
            Sala = new HashSet<Sala>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Caja> Caja { get; set; }
        public virtual ICollection<Sala> Sala { get; set; }
    }
}
