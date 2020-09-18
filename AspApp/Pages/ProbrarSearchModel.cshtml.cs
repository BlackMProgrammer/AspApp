using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using LibreriaClases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AspApp.Pages
{
    public class ProbrarSearchModelModel : PageModel
    {
        public List<LibroModel> ListaLibro;
        private IConfigurationRoot ConfigRoot;
        public string MessageText { get; set; }
        public string SearchText { get; set; }

        public ProbrarSearchModelModel(IConfiguration pconfig) 
        {
            ConfigRoot = (IConfigurationRoot)pconfig;
        }
        public void Onget() 
        {
            ListaLibro = new List<LibroModel>();
        }

        public void OnPost() 
        {
            if (Request.Form["search"] != "")
            {
                SearchText = Request.Form["search"];
                string setting = ConfigRoot["AppSettings:serverconn"].ToString();
                Libro eltitle = new Libro(setting);
                ListaLibro = eltitle.Read(SearchText);
            }
        }
    }
}
