using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibreriaClases
{
    public class Libro : Conexion
    {
        public Libro(string setting) : base(setting) {
        
        }
        /* Mapping o ORM*/
        public List<LibroModel> Read(string criterio) {

            List<LibroModel> lista = new List<LibroModel>();
            DataTable tabla = Buscar("Titles","*","title LIKE '%" + criterio +"%';");

            foreach (DataRow row in tabla.Rows)
            {
                LibroModel obj1 = new LibroModel();
                obj1.Titleid = row["title_id"].ToString();
                obj1.Name = row["title"].ToString();
                obj1.Type = row["type"].ToString();
                obj1.Editora = row["pub_id"].ToString();

                try
                {
                    obj1.Price = double.Parse(row["price"].ToString());
                    obj1.Avance = double.Parse(row["advance"].ToString());
                    obj1.Royal = double.Parse(row["royalty"].ToString());
                    obj1.Royal = double.Parse(row["ytd_sales"].ToString());
                    obj1.Notas = row["notes"].ToString();
                    obj1.FechaPublicado = DateTime.Parse(row["pubdate"].ToString());
                }
                catch{ }
                lista.Add(obj1);
            }
            return lista;
        }

        public bool Crear(LibreriaClases.LibroModel objnew) 
        {
            throw new NotImplementedException();
        }

        public bool Update(LibreriaClases.LibroModel objupdate) 
        {
            throw new NotImplementedException();
        }

        public bool Delete(LibreriaClases.LibroModel objdel) 
        {
            throw new NotImplementedException();
        }
    }
}
