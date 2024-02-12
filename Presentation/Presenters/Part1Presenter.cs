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
    public class Part1Presenter : IPresenter
    {

        private readonly IPart1View _view;
        private readonly IPart1Model _service;

        public Part1Presenter(IPart1View view, IPart1Model service)
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
                case 10:
                    var listResult = _service.SimpleLessThanN(_view.Num_A);
                    string result = "";
                    foreach (var num in listResult)
                        result += num.ToString() + " ";
                    _view.SetResult(result);
                    _view.ShowError("Выполнен пункт 1");
                    break;
                case 20:

                    _view.ShowError("Выполнен пункт 2");
                    break;
                case 30:

                    _view.ShowError("Выполнен пункт 3");
                    break;
                default:
                    //throw new ArgumentOutOfRangeException("Номер части не тот, бака!");
                    _view.ShowError("Номер части не тот, бака!");
                    break;
            }
            
        }

    }
}
