using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.Cheat
{
    class File_NameGenerator
    {
        public string GetFileName()
        {
            return "RBMS" + DateTime.Now.ToString("yyMMdd HHmmss");
        }
    }
}
