using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AspApp.Pages
{
    public class UploadFileModelModel : PageModel
    {
        private IConfigurationRoot ConfigRoot;
        public string MessageText { get; set; }
        public List<Dictionary<string, string>> FileAtributos { get; set; }

        public UploadFileModelModel(IConfigurationRoot configRoot) 
        {
            configRoot = (IConfigurationRoot)configRoot;
        }
        public void OnGet()
        {
            listaPath();
        }
        [BindProperty]
        public IFormFile Upload { get; set; }

        public async Task OnPostAsync() 
        {
            var filename = ConfigRoot["AppSettings:filepath"].ToString() + "\\" + Upload.FileName;

            using (var fileStream = new FileStream(filename, FileMode.Create)) 
            {
                await Upload.CopyToAsync(fileStream);
            }
            listaPath();
        }

        private void listaPath() 
        {
            try
            {
                string path = ConfigRoot["AppSettings:filepath"].ToString();
                string[] losfiles = Directory.GetFiles(path);
                FileAtributos = new List<Dictionary<string, string>>();
                foreach (var file in losfiles)
                {
                    FileInfo inf = new FileInfo(file);
                    Dictionary<string, string> unAtributo = new Dictionary<string, string>();
                    unAtributo.Add("name",inf.Name);
                    unAtributo.Add("date",inf.LastWriteTime.ToString());
                    unAtributo.Add("type",inf.Extension);
                    unAtributo.Add("size",inf.Length.ToString());
                    FileAtributos.Add(unAtributo);
                }
            }
            catch (Exception e)
            {
                MessageText = e.Message;

            }
        }
    }
}
