using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rep
{
    internal class Class1
    {
        
        public void writeline(string filepath,string writing_element)
        {
            FileStream fs = new FileStream(filepath, FileMode.Create,FileAccess.Write);
            if (fs.CanWrite)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(writing_element);
                fs.Write(buffer, 0, buffer.Length);
            }
            fs.Flush();
            fs.Close();
        }
    }
}
