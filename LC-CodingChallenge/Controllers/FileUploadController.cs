using CsvHelper.Configuration;
using LC_CodingChallenge.Helper;
using LC_CodingChallenge.Repository.Interfaces;
using LC_CodingChallenge.Repository.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace LC_CodingChallenge.Controllers
{
    public class FileUploadController : Controller
    {
        readonly ILeaseRepository fileUploadRepository;
        public FileUploadController(ILeaseRepository fileUploadRepository)
        {
            this.fileUploadRepository = fileUploadRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            return View(keyValuePairs);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            string filePath = string.Empty;
            Dictionary<int, string> errorLogs = new Dictionary<int, string>();
            if (postedFile != null && Path.GetExtension(postedFile.FileName) == ".csv")
            {
                filePath = SaveFile.Save(postedFile);

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    IgnoreBlankLines = false,
                    HasHeaderRecord = true
                };
                var leases = Helper.CsvReader.Read<Lease>(config, filePath);
                var datatable = LeaseModelToDataset.Convert(leases, errorLogs);
                if (errorLogs.Count == 0)
                {
                    errorLogs.Add(1, "csv file upload successfully.");
                    fileUploadRepository.BulkUpdateCSVFile(datatable);
                }
            }
            return View(errorLogs);
        }
    }
}