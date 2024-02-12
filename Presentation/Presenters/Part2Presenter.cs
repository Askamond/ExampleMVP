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
    public class Part2Presenter : IPresenter
    {

        private readonly IPart2View _view;
        private readonly IPart2Model _service;

        public Part2Presenter(IPart2View view, IPart2Model service)
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
                case 1:
                    var maxDivider = _service.MaxDivider(_view.Num_A).ToString();
                    _view.SetResult(maxDivider);
                    _view.ShowError("Выполнен пункт 4.");
                    break;
                case 2:
                    var maxPowerLesserTheNumber = _service.MaxPowerLesserTheNumber(_view.Num_A).ToString();
                    _view.SetResult(maxPowerLesserTheNumber);
                    _view.ShowError("Выполнен пункт 5.");
                    break;
                case 3:
                    var xorAllBits = _service.XorAllBits(_view.Num_A).ToString();
                    _view.SetResult(xorAllBits);
                    _view.ShowError("Выполнен пункт 6.");
                    break;
                case 4:
                    var shiftLeft = _service.CyclicShiftLeft(_view.Num_A, _view.Index_L).ToString();
                    _view.SetResult(shiftLeft);
                    _view.ShowError("Выполнен пункт 7.");
                    break;
                case 5:
                    var shiftRight = _service.CyclicShiftLeft(_view.Num_A, _view.Index_R).ToString();
                    _view.SetResult(shiftRight);
                    _view.ShowError("Выполнен пункт 8.");
                    break;
                default:
                    //throw new ArgumentOutOfRangeException("Номер части не тот, бака!");
                    _view.ShowError("Номер части не тот, бака!");
                    break;
            }
            
        }

    }
}
