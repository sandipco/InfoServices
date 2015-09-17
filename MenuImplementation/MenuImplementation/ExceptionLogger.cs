using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuImplementation
{
    public class ExceptionLogger : IExceptionLogger
    {
        public void addErrorLog(Exception ex)
        {
            try
            {
                string path = Environment.CurrentDirectory.Replace("bin\\Debug", "logs\\logs.txt");
                string content = string.Empty;
                try
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        content = reader.ReadToEnd();
                    }
                }
                catch (FileNotFoundException e)
                {

                    FileStream file = new FileStream(path, FileMode.CreateNew);
                    file.Close();
                }
                using (StreamWriter writer = new StreamWriter(path))
                {
                    content = System.DateTime.Now.ToString() + " : " + ex.ToString() + Environment.NewLine + content;
                    writer.Write(content);
                }
            }
            catch
            { }
        }
    }
}
