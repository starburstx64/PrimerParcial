using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCRUDMVC.DTO
{
    class Acciones
    {
        private int id;
        private string fecha;
        private float precioAccion;
        private float dineroInvertido;
        private int accionesOperadas;

        public Acciones(int id, string fecha, float precioAccion, float dineroInvertido, int accionesOperadas)
        {
            Id = id;
            Fecha = fecha;
            PrecioAccion = precioAccion;
            DineroInvertido = dineroInvertido;
            AccionesOperadas = accionesOperadas;
        }

        public int Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public float PrecioAccion { get => precioAccion; set => precioAccion = value; }
        public float DineroInvertido { get => dineroInvertido; set => dineroInvertido = value; }
        public int AccionesOperadas { get => accionesOperadas; set => accionesOperadas = value; }
    }
}
