using CMS_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public class clsGlobal
    {
        public static clsUsers CurrentUser = null;
        public static void ChangeSizeControl(object sender)
        {
            Control control = (sender) as Control;
            //control.Size=new Size(control.Width+2, control.Height+2);
            control.Location=new Point(control.Location.X, control.Location.Y-3);
        }
        public static void ResetSizeControl(object sender)
        {
            Control control = (sender) as Control;
            //control.Size=new Size(control.Width-2, control.Height-2);
            control.Location=new Point(control.Location.X, control.Location.Y+3);
        }
        public static bool GetInfoToLoginAgain(ref string UserName,ref string Password)
        {
            string FolderName = @"Software\CMS_CurrentLoginInfo";
            string ValueName = @"Data";
            try
            {

                using (RegistryKey Createkey = Registry.CurrentUser.CreateSubKey(FolderName)) { }
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(FolderName))
                {
                    if (key == null)
                    {
                        return false;
                    }      

                    string value = key.GetValue(ValueName) as string;
                    if (value == null)
                    {
                        return false;
                    }
                    string[] Info = value.Split(new string[] { "/##/" }, StringSplitOptions.None);
                    UserName = Info[0];
                    Password = Info[1];
                    return true;
                   
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool RememberMeToLoginAgain(string UserName, string Password)
        {
            string FolderName = @"Software\CMS_CurrentLoginInfo";
            string ValueName = @"Data";
            try
            {

                using (RegistryKey Createkey = Registry.CurrentUser.CreateSubKey(FolderName)) { }
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(FolderName, true))
                {
                    if (key == null)
                    {
                        return false;
                    }      

                    if(UserName=="")
                    {
                        if (key.GetValue(ValueName) != null)
                        {
                            key.DeleteValue(ValueName);
                        }
                        return true;
                    }
                    key.SetValue(ValueName, UserName+"/##/"+Password);
                    return true;

                }
            }
            catch
            {
                return false;
            }
        }
    }
}
