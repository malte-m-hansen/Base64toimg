using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Base64toimg
{
    class Program
    {
        static void Main(string[] args)
        {
            string importpath = Path.Combine(Directory.GetCurrentDirectory(), "import");
            string exportpath = Path.Combine(Directory.GetCurrentDirectory(), "export");

            if (!Directory.Exists(importpath))
            {
                Directory.CreateDirectory(importpath);
            }
            if (!Directory.Exists(exportpath))
            {
                Directory.CreateDirectory(exportpath);
            }

            List<string> nonquox = Directory.GetFiles(importpath).ToList();
            List<string> importlist = new List<string>();
            foreach (string s in nonquox)
            {
                if (Path.GetExtension(s) == ".QUOX")
                {
                    importlist.Add(s);
                }
            }
            int number = 0;

            foreach (string s in importlist)
            {
                string p = Path.GetFileName(s);
                string base64String = File.ReadAllText(s);
                byte[] imageBytes = Convert.FromBase64String(base64String);
                string filePath = Path.Combine(exportpath, p +".jpg" );
                File.WriteAllBytes(filePath, imageBytes);
                number++;
            }


        }
    }
}
