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
using MVP.Presentation.Presenters;
using MVP.Presentation.Common;
using MVP.Model;

namespace MVP.UI
{
    public partial class ChooseLabForm : Form, IChooseLabView
    {
        private readonly ApplicationContext _context;
        public ChooseLabForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();

            startButton.Click += (sender, args) => Invoke(StartLaba);
            LabList.AfterSelect += (sender, args) => { PartID = args.Node.Index; };
            LabList.AfterSelect += (sender, args) => BtnControl(PartID);
            LabList.AfterSelect += (sender, args) => ChangeTextAboutProgram(PartID);
            leftButton.Click += (sender, args) => { MoveNodeFromBtn(PartID, true); };
            rightButton.Click += (sender, args) => { MoveNodeFromBtn(PartID, false); };

        }

        private void MoveNodeFromBtn(int partID, bool isLeft)
        {
            LabList.Focus();
            if (isLeft)
                LabList.SelectedNode = LabList.Nodes[PartID - 1];
            else
                LabList.SelectedNode = LabList.Nodes[PartID + 1];
        }

        private void BtnControl(int partID)
        {
            switch (partID)
            {
                case 0:
                    leftButton.Enabled = false;
                    rightButton.Enabled = true;
                    break;
                case 1:
                    leftButton.Enabled = true;
                    rightButton.Enabled = true;
                    break;
                case 2:
                    leftButton.Enabled = true;
                    rightButton.Enabled = true;
                    break;
                case 3:
                    leftButton.Enabled = true;
                    rightButton.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("partID");
            }
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }


        public event Action StartLaba;
        public int PartID { get; set; }

        

        public void ShowError(string errorMessage)
        {
            StatusInfo.Text = errorMessage;
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public IPresenter ReturnNameOfNextPresenter()
        {
            switch (PartID)
            {
                case 0:
                    return new Part1Presenter(new Part1Form(), new Part1Model());
                case 1:
                    return new Part2Presenter(new Part2Form(), new Part2Model());
                case 2:
                    return new Part3Presenter(new Part3Form(), new Part3Model());
                default:
                    throw new ArgumentOutOfRangeException("PartID");
            }
        }

        private void ChangeTextAboutProgram(int partID)
        {
            switch (partID)
            {
                case 0:
                    textBox1.Text = "Часть 1." + Environment.NewLine + "1. С клавиатуры вводится 32-х разрядное целое число 𝑎 в двоичной системе счисления." + Environment.NewLine + "\t1. Вывести 𝑘−ый бит числа 𝑎. Номер бита предварительно запросить у пользователя." + Environment.NewLine + "\t2. Установить/снять 𝑘−ый бит числа 𝑎." + Environment.NewLine + "\t3. Поменять местами 𝑖−ый и 𝑗−ый биты в числе 𝑎. Числа 𝑖 и 𝑗 предварительно запросить у пользователя." + Environment.NewLine + "\t4. Обнулить младшие 𝑚 бит." + Environment.NewLine + "2. A) «Склеить» первые 𝑖 битов с последними 𝑖 битами из целого числа длиной 𝑙𝑒𝑛 битов." + Environment.NewLine + "B) Получить биты из целого числа длиной 𝑙𝑒𝑛 битов, находящиеся между первыми 𝑖 битами и последними 𝑖 битами." + Environment.NewLine + "3. Поменять местами байты в заданном 32-х разрядном целом числе. Перестановка задается пользователем.";
                    break;
                case 1:
                    textBox1.Text = "Часть 2." + Environment.NewLine + "4. Найти максимальную степень 2, на которую делится данное целое число. Примечание. Операторами цикла пользоваться нельзя." + Environment.NewLine + "5. Пусть 𝑥 целое число. Найти такое 𝑝, что 2/≤𝑥≤2/12." + Environment.NewLine + "6. Дано 2/ разрядное целое число. «Поксорить» все биты этого числа друг с другом." + Environment.NewLine + "Пример.101110001→1;	11100111→0." + Environment.NewLine + "7. Написать макросы циклического сдвига в 2/ разрядном целом числе на 𝑛 бит влево и вправо." + Environment.NewLine + "8. Дано 𝑛 битовое данное. Задана перестановка бит (1,8,23,0,16,…). Написать функцию, выполняющую эту перестановку.";
                    break;
                case 2:
                    textBox1.Text = "Часть 3." + Environment.NewLine + "9. Разработайте алгоритм шифрования на основе замены последовательности битов. Например, определите таблицу, в которой задано правило замены 4 бит на какую-то другую последовательность бит. Разработайте консольное приложение, шифрующее и дешифрующее файл, используя ваш алгоритм." + Environment.NewLine + "10. Разработать приложение, шифрующее и дешифрующее файл с помощью алгоритма Вернама." + Environment.NewLine + "11. Разработайте приложение, обеспечивающее безопасность данных на основе алгоритма DES." + Environment.NewLine + "Примечание. В приложении необходимо реализовать возможность выбора режима работы алгоритма. Выполните сравнительный анализ эффективности вашей реализации алгоритма DES. Воспользуйтесь какой-либо готовой реализацией алгоритма и выполните множественное шифрование и дешифрование данных вашей реализацией и готовым решением. Постройте графики скорости шифрования данных (𝑣=𝑣(𝑠),𝑠−размер шифруемых данных)." + Environment.NewLine + "12. Реализуйте алгоритм RC4. ";
                    break;
                case 3:
                    //TODO: Вписать тз
                    textBox1.Text = "Часть 4." + Environment.NewLine;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("partID");
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

    }
}
