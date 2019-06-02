using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ViewFilesController : Controller
    {
        
        public List<FileNames> GetFiles()
        {

            List<FileNames> lstFiles = new List<FileNames>();
            DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/uploads"));

            int i = 0;
            foreach (var item in dirInfo.GetFiles())
            {

                lstFiles.Add(new FileNames()
                {

                    FileId = i + 1,
                    FileName = item.Name,
                    FilePath = dirInfo.FullName + @"\" + item.Name
                });
                i = i + 1;
            }

            return lstFiles;
        }
        public ActionResult Index()
        {
            var files = GetFiles();
            return View(files);
        }


        public FileResult Download(string id)
        {
            int fid = Convert.ToInt32(id);
            var files = GetFiles();
            string filename = (from f in files
                               where f.FileId == fid
                               select f.FilePath).First();
            string contentType = "application/pdf";
            //Parameters to file are
            //1. The File Path on the File Server
            //2. The content type MIME type
            //3. The parameter for the file save by the browser
            return File(filename, contentType, "Report.pdf");
        }
    }
}
