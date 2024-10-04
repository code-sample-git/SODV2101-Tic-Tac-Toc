using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SODV2101_Tic_Tac_Toc
{
    public class GridWonEventArgs : EventArgs
    {
        public string Winner { get; set; }
    }
}

