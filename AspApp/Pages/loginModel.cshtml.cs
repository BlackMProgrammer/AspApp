using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AspApp.Pages.Shared
{
    public class loginModelModel : PageModel
    {
        private IConfigurationRoot configRoot;
        public string MessageText { get; set; }

        public loginModelModel(IConfiguration configRoot) 
        {
            configRoot = (IConfigurationRoot)configRoot;
        }
        public void OnGet()
        {
            if (Request.Query["loginaction"] == "__salir")
                HttpContext.Session.SetString("userid", ""); // clear
            if (HttpContext.Session.GetString("userid") != null &&
            HttpContext.Session.GetString("userid") != "")
                HttpContext.Response.Redirect("index");
        }

        public void OnPost() 
        {
            if (postData(Request.Form["userid"].ToString(),
            Request.Form["passkey"].ToString()))
            HttpContext.Response.Redirect("index");
        }

        private bool postData(string p_userid,string p_pass) 
        {
            bool result = false;

            try
            {
                string path = configRoot["AppSettings:" + p_userid].ToString();
                /* Hay que ir al db*/
                result = (p_pass == path);
            }
            catch (Exception e)
            {
                MessageText = e.Message;
                throw;
            }
            if (!result)
            {
                MessageText = "Password Incorrecto";
            }
            else
                HttpContext.Session.SetString("userid", p_userid);

            return result;
        }

        public void ProbarFormModel(IConfiguration configRoot)
        {
            configRoot = (IConfiguration)configRoot;

            string path = configRoot["Appsettings:filepath"].ToString();
            StreamWriter miarchivo = new StreamWriter(path + "\\student.txt", true);
        }


    }

}
