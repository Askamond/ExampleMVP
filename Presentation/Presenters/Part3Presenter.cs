using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVP.Presentation.Common;
using MVP.Presentation.Views;
using MVP.Model;


namespace MVP.Presentation.Presenters
{
    public class Part3Presenter : IPresenter
    {

        private readonly IPartView _view;
        private readonly IPart3Model _service;

        public Part3Presenter(IPartView view, IPart3Model service)
        {
            _view = view;
            _service = service;

            _view.StartWork += () => StartWork(_view.ExID);
        }
        public void Run()
        {
            _view.Show();
        }
        
        private void StartWork(int LabPart)
        {
            switch (LabPart)
            {
                case 11:
                    
                    break;
                case 12:

                    break;
                case 13:

                    break;
                case 14:

                    break;
                default:
                    //throw new ArgumentOutOfRangeException("Номер части не тот, бака!");
                    _view.ShowError("Номер части не тот, бака!");
                    break;
            }
            
        }

    }
}
