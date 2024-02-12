using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVP.Presentation.Common;

namespace MVP.Presentation.Views
{
    public interface IPartView:IView
    {
        int ExID { get; }

        int Num_A { get; set; }

        event Action StartWork;
        void ShowError(string errorMessage);

        void SetResult(string result);
    }
}
