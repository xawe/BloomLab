using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace BloomLab01.Tools
{
    public class File
    {
        public List<string> Read(string path)
        {
            var x = System.IO.File.ReadAllText(path)
                .Split(Environment.NewLine);
            return x.ToList();
        }
    }
}
