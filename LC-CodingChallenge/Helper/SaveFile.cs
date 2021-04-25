using System;
using System.IO;
using System.Web;

namespace LC_CodingChallenge.Helper
{
    public static class SaveFile
    {
        public static string Save(HttpPostedFileBase postedFile)
        {
            string filePath = string.Empty;
            string path = System.Web.HttpContext.Current.Server.MapPath(string.Format("{0}{1}/", "~/Uploads/", DateTime.Now.Ticks));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            filePath = string.Format("{0}{1}", path, Path.GetFileName(postedFile.FileName));
            postedFile.SaveAs(filePath);
            return filePath;
        }
    }
}