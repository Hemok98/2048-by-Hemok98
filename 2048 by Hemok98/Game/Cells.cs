using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_by_Hemok98
{
    class Cells
    {
        public int num = 0;
        public bool changed = false;

        public Cells(int num)
        {
            this.num = num;
            this.changed = false;

        }
    }
}
