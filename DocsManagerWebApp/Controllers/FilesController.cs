using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DocsManagerWebApp.Controllers
{
    public class FilesController : BaseController
    {
        // GET: Files
        [HttpPost]
        public async Task<ActionResult> UploadDocument(HttpPostedFileBase file)
        {
            return GetJson(new
            {
                Success = true,
                UploadedFileName = ""
            });
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFile(HttpPostedFileBase file)
        {
            return GetJson(new
            {
                Success = true,
                UploadedFileName = ""
            });
        }

 
    }
}