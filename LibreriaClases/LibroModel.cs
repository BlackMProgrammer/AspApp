using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaClases
{
    public class LibroModel
    {
        public string Titleid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Editora { get; set; }
        public double Price { get; set; }
        public double Avance { get; set; }
        public double Royal { get; set; }
        public double YearSales { get; set; }
        public string Notas { get; set; }
        public DateTime FechaPublicado { get; set; }
    }
}
