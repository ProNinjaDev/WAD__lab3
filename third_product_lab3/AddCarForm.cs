using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace third_product_lab3
{
    public partial class AddCarForm : Form
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Power { get; private set; }
        public string MaxSpeed { get; private set; }
        public CarType CarType { get; private set; }

        public AddCarForm()
        {
            InitializeComponent();

            carTypeComboBox.DataSource = Enum.GetValues(typeof(CarType));
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Получение данных из элементов управления
            Brand = brandTextBox.Text;
            Model = modelTextBox.Text;
            
            Power = powerTextBox.Text;
            try
            {
                for (int i = 0; i != Power.Length; ++i)
                {
                    if (char.IsLetter(Power[i]))
                    {
                        throw new ArgumentException("Неверный ввод");
                    }
                }

            MaxSpeed = maxSpeedTextBox.Text;

                for (int i = 0; i != MaxSpeed.Length; ++i)
                {
                    if (char.IsLetter(MaxSpeed[i]))
                    {
                        throw new ArgumentException("Неверный ввод");
                    }
                }

            }
            catch
            {
                //MessageBox.Show("Неверный ввод!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Power = null;
                MaxSpeed = null;
                Close();
            }

            // Проверка выбора типа машины
            if (carTypeComboBox.SelectedItem != null)
            {
                CarType = (CarType)carTypeComboBox.SelectedItem;
            }
            else
            {
                MessageBox.Show("Выберите тип машины.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка наличия введенных данных
            if (string.IsNullOrEmpty(Brand) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Power) || string.IsNullOrEmpty(MaxSpeed))
            {
                MessageBox.Show("Неверное заполнение полей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void powerTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
