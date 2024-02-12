using System;
using MVP.Presentation.Common;
using MVP.Presentation.Views;
using MVP.Model;

namespace MVP.Presentation.Presenters
{
    public class ChooseLabaPresenter : IPresenter
    {
        private readonly IChooseLabView _view;
        private readonly IChooseLabaService _service;

        public ChooseLabaPresenter(IChooseLabView view, IChooseLabaService service)
        {
            _view = view;
            _service = service;
            
            _view.StartLaba += () => StartLaba(_view.PartID);
        }

        public void Run()
        {
            _view.Show();
        }

        private void StartLaba(int LabPart)
        {
            /*if (LabPart == 0)
                throw new ArgumentNullException("Lab part");*/

            if (!_service.StartLab(LabPart))
            {
                _view.ShowError("Invalid LabPart");
            }
            else
            {
                _view.ShowError("Open Part " + (LabPart+1).ToString());
                var presenter = _view.ReturnNameOfNextPresenter();
                presenter.Run();
            }
        }
    }
}
