using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zysoft.FrameWork.Store
{
    public class EXTField
    {
        public string name { get; set; }
        public string type { get; set; }
        public string mapping { get; set; }
        public string dateFormat { get; set; }
        public string convert { get; set; }
        public bool allowBlank { get; set; }

        public EXTField()
        {
            name = "";
            type = "";
            mapping = "";
            dateFormat = "";
            convert = "";
            allowBlank = true;
        }
    }
}
