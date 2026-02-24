using System;
using System.Collections.Generic;
using System.Text;

namespace PartialStaticEnumerations
{
    partial class File1
    {
        public File1(string current) 
        {
          Previous = current;
        }
    }
}
