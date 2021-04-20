using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParibuClientMVC.Helper
{
    public static class LogOperation
    {
        public static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\log.txt";        
        public static bool InsertLog(string methodName, string errorMessage, DateTime logTime)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter sw = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Tarih : {0} - Hata alınan metod: {1} - Hata içeriği : {2}", logTime.ToString(), methodName, errorMessage);
                sb.AppendLine();
                sw.WriteLine(sb.ToString());
                sw.Close();                
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}