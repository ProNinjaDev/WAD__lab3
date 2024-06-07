using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;

namespace third_product_lab3
{
    public partial class CarListForm : Form
    {
        List<ICar> cars;
        List<ICar> selectedCars;
        List<ICar> generatedCars;

        private int widthColumnForm;
        private int heightRowTable;

        Loader loader = new Loader();

        Thread Thread2;

        public CarListForm(List<ICar> loaderCars)
        {
            InitializeComponent();
            selectedCars = loaderCars;

            widthColumnForm = this.Width / 4 - 21;
            //this.FormClosing += CarListForm_FormClosing;

            OnlyBrandTable.DefaultCellStyle.Font = new Font("TT Firs Neue", 11);
            OnlyBrandTable.ColumnHeadersDefaultCellStyle.Font = new Font("TT Firs Neue", 13, FontStyle.Bold);
            OnlyBrandTable.Visible = false;

            this.Text = loaderCars[0].Model;


        }

        private void OnlyBrandTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarListForm_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 3; i++)
            {
                OnlyBrandTable.Columns.Add(new DataGridViewTextBoxColumn());
            }

            // Инициализация столбцов определённого вида
            if (selectedCars[0] is PassengerCar)
            {
                OnlyBrandTable.Columns[0].HeaderText = "Регистрационный номер";
                OnlyBrandTable.Columns[1].HeaderText = "Название мультимедиа";
                OnlyBrandTable.Columns[2].HeaderText = "Количество подушек безопасности";
            }
            else if (selectedCars[0] is Truck)
            {
                OnlyBrandTable.Columns[0].HeaderText = "Регистрационный номер";
                OnlyBrandTable.Columns[1].HeaderText = "Количество колёс";
                OnlyBrandTable.Columns[2].HeaderText = "Объём кузова";
            }
            else if (selectedCars[0] is Plane)
            {
                OnlyBrandTable.Columns[0].HeaderText = "Регистрационный номер";
                OnlyBrandTable.Columns[1].HeaderText = "Количество мест";
                OnlyBrandTable.Columns[2].HeaderText = "Размах крыла";
            }


            Thread2 = new Thread(delegate ()
            {
                cars = Loader.Load(selectedCars[0].Model, selectedCars[0].CarType);
            });

            Thread2.Start();

            ProgressTimer.Interval = 1000; // Интервал в миллисекундах
            ProgressTimer.Tick += ProgressTimer_Tick;
            ProgressTimer.Start();
        }

        private void DisplayCarsInTable(List<ICar> cars)
        {
            OnlyBrandTable.Rows.Clear();

            foreach (var car in cars)
            {
                // Добавление строки в таблицу
                OnlyBrandTable.Rows.Add(GetCarRow(car));
            }
        }

        private object[] GetCarRow(ICar car)
        {
            // Возвращает массив значений для заполнения строки таблицы в зависимости от типа автомобиля
            if (car is PassengerCar passengerCar)
            {
                return new object[] { passengerCar.RegNumber, passengerCar.Multimedia, passengerCar.NumOfAirbags };
            }
            else if (car is Truck truck)
            {
                return new object[] { truck.RegNumber, truck.NumOfWheels, truck.BodyCapacity };
            }
            else if (car is Plane plane)
            {
                return new object[] { plane.RegNumber, plane.Capacity, plane.Wingspan };
            }

            return null;
        }

        // Реагируем на изменение размеров формы
        private void CarListForm_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            
            progressBar1.Value = Loader.GetProgress();

            if (progressBar1.Value == progressBar1.Maximum)
            {
                // Отображение данных в таблице
                DisplayCarsInTable(cars);
                OnlyBrandTable.Visible = true;
                progressBar1.Visible = false;
                ProgressTimer.Stop(); // Останавливаем таймер после заполнения прогрессбара
            }
        }

        private void CarListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Отменить закрытие формы
            this.Hide();
        }
    }
}
