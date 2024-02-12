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
    public partial class Part2Form : Form, IPart2View
    {
        public Part2Form()
        {
            InitializeComponent();
            subPart = 1;
            //Place for Events
            startButton.Click += (sender, args) =>
            {
                if (textBox1.Text == "")
                {
                    ShowError("Пустое поле числа a!");
                    return;
                }

                Num_A = Convert.ToInt32(textBox1.Text);
                if (subPart == 4 || subPart == 5)
                {
                    if (textBox3.Text == "" && textBox4.Text != "")
                    {
                        Index_R = Convert.ToInt32(textBox4.Text);
                        subPart = 5;
                    }
                    else if (textBox3.Text != "" && textBox4.Text == "")
                    {
                        Index_L = Convert.ToInt32(textBox3.Text);
                        subPart = 4;
                    }
                    else
                    {
                        ShowError("Неверный ввод сдвига!");
                        return;
                    }
                }
                ExID = subPart;
                Invoke(StartWork); ;
            };
            radioButton1.Click += (sender, args) => subPart = 1;
            radioButton2.Click += (sender, args) => subPart = 2;
            radioButton3.Click += (sender, args) => subPart = 3;
            radioButton4.Click += (sender, args) => subPart = 4;
            textBox1.KeyPress += (sender, args) => txtBox_keyPress(sender, args);
            textBox2.KeyPress += (sender, args) => txtBox_keyPress(sender, args);
            textBox3.KeyPress += (sender, args) => txtBox_keyPress(sender, args);
            textBox4.KeyPress += (sender, args) => txtBox_keyPress(sender, args);

        }

        public int Index_L { get; set; }
        public int Index_R { get; set; }
        public int subPart { get; set; }
        public int Num_A { get; set; }
        public new void Show()
        {
            ShowDialog();
        }


        public event Action StartWork;


        public void SetResult(string result)
        {
            textBox2.Text = result;
        }
        public void ShowError(string errorMessage)
        {
            toolStripStatusLabel1.Text = errorMessage;
        }
        public int ExID { get; set; }

        private void txtBox_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

    }
}
