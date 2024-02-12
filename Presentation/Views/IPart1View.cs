using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Presentation.Views
{
    public interface IPart1View: IPartView
    {

        int Index_I { get; set; }
        int Index_J { get; set; }

        int[] ChangeArray { get; set; }
    }
}
