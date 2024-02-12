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
    public partial class Part1Form : Form, IPart1View
    {
        public Part1Form()
        {
            InitializeComponent();
            Num_A = 1;
            ExID = 0;
            ChangeArray = new int[32];
            //Place for Events
            startPart1.Click += (sender, args) =>
            {
                if (mValueTextBox.Text == "")
                {
                    ShowError("Пустое поле числа m!");
                    return;
                }

                Num_A = Convert.ToInt32(mValueTextBox.Text);

                ExID = 10;
                Invoke(StartWork);
            };
            startPart2.Click += (sender, args) =>
            {
 /*               if (textBox5.Text == "")
                {
                    ShowError("Пустое поле числа a!");
                    return;
                }
                if (textBox6.Text == "")
                {
                    ShowError("Пустое поле индекса len!");
                    return;
                }
                
                Num_A = Convert.ToInt32(textBox5.Text);

                Index_I = Convert.ToInt32(textBox6.Text);
                */
                ExID = 20;
                Invoke(StartWork); ;
            };
            startPart3.Click += (sender, args) =>
            {
/*                if (textBox8.Text == "")
                {
                    ShowError("Пустое поле числа a!");
                    return;
                }
                if (textBox9.Text == "")
                {
                    ShowError("Пустое поле перестановки!");
                    return;
                }

                Num_A = Convert.ToInt32(textBox8.Text);

                var split = textBox9.Text.Split(' ');

                if (split.Length != 32)
                {
                    ShowError("Недостаточно элементов!");
                    return;
                }
                for (int i = 0; i < 32; ++i)
                {
                    ChangeArray[i] = -1;
                }
                //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31
                for (int i = 0; i < 32; ++i)
                {
                    if(Array.IndexOf(ChangeArray, Convert.ToInt32(split[i])) == -1)
                        ChangeArray[i] = Convert.ToInt32(split[i]);
                    else
                    {
                        ShowError("Повторяющийся индекс!");
                        return;
                    }
                }
                */
                ExID = 30;
                Invoke(StartWork); ;
            };
            mValueTextBox.KeyPress += (sender, args) => txtBox_keyPress(sender, args);

        }

        public int ExID { get; set; }
        public int Num_A { get; set; }
        public int[] ChangeArray { get; set; }
        public int Index_I { get; set; }

        public int Index_J { get; set; }

        public new void Show()
        {
            ShowDialog();
        }

        private void txtBox_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private void Change_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == ' '));          
        }

        public event Action StartWork;



        public void ShowError(string errorMessage)
        {

            toolStripStatusLabel1.Text = errorMessage;
        }


        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public void SetResult(string result)
        {
            if (ExID == 10)
                resultTextBox1.Text = result;
            else if (ExID == 20)
            { }
            //textBox7.Text = result;
            else if (ExID == 30)
            { }
                    //textBox10.Text = result;
        }
    }
}
