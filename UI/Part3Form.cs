using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVP.Presentation.Views;

namespace MVP.UI
{
    public partial class Part3Form : Form, IPartView
    {

        public Part3Form()
        {
            InitializeComponent();

            //Place for Events
        }

        public int ExID { get; set; }
        public int Num_A { get; set; }
        public new void Show()
        {
            ShowDialog();
        }


        public event Action StartWork;
        public int PartID { get; set; }

        public void SetResult(string result)
        {

        }

        public void ShowError(string errorMessage)
        {
            statusBar.Text = errorMessage;
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

    }
}
