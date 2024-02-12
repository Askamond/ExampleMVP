using System.Windows.Forms;
using MVP.Model;
using MVP.Presentation.Common;
using MVP.Presentation.Presenters;
using MVP.Presentation.Views;

namespace MVP.UI
{
    public class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var presenter = new ChooseLabaPresenter(new ChooseLabForm(Context), new ChooseLabaService());
            presenter.Run();
        }
    }
}
