using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Presentation.Views
{
    public interface IPart2View: IPartView
    {
        int subPart { get; set; }

        int Index_L { get; set; }
        int Index_R { get; set; }
    }
}
