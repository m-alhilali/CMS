using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Navigation;

namespace CMS.Global
{
    public class clsUtil
    {
        private static string GetNewGUID()
        {
            Guid G=Guid.NewGuid();
            return G.ToString();
        }
        private static string GetNewPath(string currentpath)
        {
            FileInfo file=new FileInfo(currentpath);
            string Extension=file.Extension;
            return GetNewGUID() + Extension;
        }
        private static bool CreatFilePathIfisnotExists(string path)
        {
            if(string.IsNullOrEmpty(path))
                return false;
            if(!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch { return false; }
            }
            return true;
        }
        public static bool CopyImageToProgectFolder(ref string CurrentPath)
        {
            string FileName = @"C:\CMS_People_Images\";
            if(!CreatFilePathIfisnotExists(FileName))
            {
                return false;
            }
            string NewPath= FileName+GetNewPath(CurrentPath);
            try
            {
                File.Copy(CurrentPath, NewPath, true);
            }
            catch 
            {
                return false;
            }
            CurrentPath = NewPath;
            return true;
        }
    }

}
