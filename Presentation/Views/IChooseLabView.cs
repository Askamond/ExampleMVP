using System;
using MVP.Presentation.Common;


namespace MVP.Presentation.Views
{
    public interface IChooseLabView : IView
    {
        int PartID { get; }
        event Action StartLaba;
        void ShowError(string errorMessage);

        IPresenter ReturnNameOfNextPresenter();
    }
}
