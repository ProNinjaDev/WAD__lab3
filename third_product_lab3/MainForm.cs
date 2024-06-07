using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace third_product_lab3
{
    public partial class MainForm : Form
    {
        
        public event Action<ICar> CarSelected;

        BindingSource bindingSource = new BindingSource();
        Dictionary<string, List<ICar>> carDictionary = new Dictionary<string, List<ICar>>(); // Словарь моделей и соответствующих автомобилей
        List<ICar> cars = new List<ICar>();
        List<ICar> certainCars = new List<ICar>();

        private int widthColumnForm;

        private bool isInitializing = true;

        private List<ICar> openForms = new List<ICar>();

        public MainForm()
        {
            InitializeComponent();

            TableCar.Height = this.Height / 2;
            TableCar.DefaultCellStyle.Font = new Font("TT Firs Neue", 11);
            TableCar.ColumnHeadersDefaultCellStyle.Font = new Font("TT Firs Neue", 13, FontStyle.Bold);

            widthColumnForm = this.Width / 5 - 16;

            TableCar.DataSource = bindingSource;

            // Легковые автомобили
            //AddCar(new PassengerCar("Lada", "Vesta", "120", "175"));
            //AddCar(new PassengerCar("Lada", "Granta", "90", "160"));

            //AddCar(new PassengerCar("Toyota", "Camry", "180", "200"));
            //AddCar(new PassengerCar("Toyota", "Corolla", "150", "190"));
            //AddCar(new PassengerCar("Toyota", "Rav4", "200", "220"));

            ////Грузовики
            //AddCar(new Truck("Peterbilt", "379", "475", "100")); // Оптимус прайм
            //AddCar(new Truck("Peterbilt", "579", "500", "110"));
            //AddCar(new Truck("Peterbilt", "389", "450", "95"));

            AddCar(new Plane("Boeing", "X2432", "1233", "12334"));

            // Загружаем данные в таблицу через биндинг сурс
            bindingSource.DataSource = cars;

            // Создаем словарь
            PopulateCarDictionary();

            // Заголовки
            TableCar.Columns[0].HeaderText = "Наименование марки";
            TableCar.Columns[0].Name = "Brand";
            TableCar.Columns[1].HeaderText = "Наименование модели";
            TableCar.Columns[1].Name = "Model";
            TableCar.Columns[2].HeaderText = "Мощность л.с.";
            TableCar.Columns[2].Name = "Power";
            TableCar.Columns[3].HeaderText = "Максимальная скорость";
            TableCar.Columns[3].Name = "MaxSpeed";

            // Добавление ComboBox в табличку
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
            dataGridViewComboBoxColumn.HeaderText = "Тип автомобиля";
            dataGridViewComboBoxColumn.Name = "TypeColumn";
            dataGridViewComboBoxColumn.Items.AddRange(Enum.GetNames(typeof(CarType)));

            TableCar.Columns.Add(dataGridViewComboBoxColumn);

            //Скрываю ненужный столбец
            TableCar.Columns[TableCar.Columns.Count - 2].Visible = false;
            menuStrip1.Visible = false;
            

            // Выравнивание столбиков
            foreach (DataGridViewColumn column in TableCar.Columns)
            {
                column.Width = widthColumnForm;
            }


            // Добавление событий
            TableCar.CellValueChanged += TableCar_CellValueChanged;
            TableCar.CurrentCellDirtyStateChanged += TableCar_CurrentCellDirtyStateChanged;
            //TableCar.SelectionChanged += TableCar_SelectionChanged;
        }

        private void PopulateCarDictionary()
        {
            foreach (ICar car in cars)
            {
                string model = car.Model;
                if (!carDictionary.ContainsKey(model))
                {
                    carDictionary[model] = new List<ICar>();
                }
                carDictionary[model].Add(car);
            }
        }

        private void AddCar(ICar car)
        {
            cars.Add(car);
            string model = car.Model; // Изменено: использовать модель в качестве ключа
            if (!carDictionary.ContainsKey(model))
            {
                carDictionary[model] = new List<ICar>();
            }
            carDictionary[model].Add(car);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            TableCar.Height = this.Height / 2;

            widthColumnForm = this.Width / 5 - 16;
            foreach (DataGridViewColumn column in TableCar.Columns)
            {
                column.Width = widthColumnForm;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Присваивание значения по умолчанию в комбобокс
            for (int i = 0; i < TableCar.Rows.Count; i++)
            {
                string cellValue = TableCar.Rows[i].Cells["CarType"].Value.ToString();
                if (cellValue != null)
                {
                    TableCar.Rows[i].Cells["TypeColumn"].Value = cellValue;
                }
            }

            // Начальный цвет на строки
            foreach (DataGridViewRow row in TableCar.Rows)
            {
                SetColorOfRow(row);
            }

            isInitializing = false;

            
         


        }

        // Установка цвета на строки
        private void SetColorOfRow(DataGridViewRow row)
        {
            var value = row.Cells["TypeColumn"].Value;
            if (value != null)
            {
                var carType = (CarType)Enum.Parse(typeof(CarType), value.ToString());
                if (carType == CarType.PassengerCar)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else if (carType == CarType.Truck)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (carType == CarType.Plane)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }

        private void TableCar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Реагируем на изменение комбобокса
            if (e.RowIndex >= 0 && e.ColumnIndex == TableCar.Columns["TypeColumn"].Index)
            {
                // Меняю цвет строки
                DataGridViewRow row = TableCar.Rows[e.RowIndex];
                SetColorOfRow(row);

                // Обновляем тип объекта в словаре
                ICar car = (ICar)row.Tag;
                CarType newCarType = (CarType)Enum.Parse(typeof(CarType), row.Cells["TypeColumn"].Value.ToString());

                //todo: Удалить форму при изменении комбобокса

                //if (Application.OpenForms.Count > 1)
                //    Application.OpenForms[1].Close();

                // Удаляю машинку из Loader
                if (Loader.carData.ContainsKey((string)row.Cells["Model"].Value))
                    Loader.carData[(string)row.Cells["Model"].Value] = null;

                if (car != null)
                {
                    string nowModelCar = car.Model;
                    var oldcar = car.Clone();

                    // Удаляем старую машину из словаря
                    carDictionary[car.Model].Remove(car);

                    if (newCarType == CarType.PassengerCar)
                    {
                        PassengerCar updatedCar = new PassengerCar(oldcar.Name, oldcar.Model, oldcar.Power, oldcar.MaxSpeed);
                        // Обновляем тип и добавляем обновленный объект в словарь
                        updatedCar.CarType = newCarType;
                        carDictionary[oldcar.Model].Add(updatedCar);
                    }
                    else if (newCarType == CarType.Truck)
                    {
                        Truck updatedCar = new Truck(oldcar.Name, oldcar.Model, oldcar.Power, oldcar.MaxSpeed);
                        updatedCar.CarType = newCarType;
                        carDictionary[oldcar.Model].Add(updatedCar);
                    }
                    else if (newCarType == CarType.Plane)
                    {
                        Plane updatedCar = new Plane(oldcar.Name, oldcar.Model, oldcar.Power, oldcar.MaxSpeed);
                        updatedCar.CarType = newCarType;
                        carDictionary[oldcar.Model].Add(updatedCar);
                    }
                }

            }


            // Удалить
            if (e.RowIndex > -1)
            {
                int count = TableCar.Rows[e.RowIndex].Cells.Count;
                var value = TableCar.Rows[e.RowIndex].Cells[count - 1].Value;
                if (value != null)
                {
                    if (TableCar.Rows[e.RowIndex].Cells["TypeColumn"].Value.ToString() == "PassengerCar")
                        TableCar.Rows[e.RowIndex].Tag = new PassengerCar((string)TableCar.Rows[e.RowIndex].Cells["Brand"].Value, (string)TableCar.Rows[e.RowIndex].Cells["Model"].Value, (string)TableCar.Rows[e.RowIndex].Cells["Power"].Value, (string)TableCar.Rows[e.RowIndex].Cells["MaxSpeed"].Value);


                    if (TableCar.Rows[e.RowIndex].Cells["TypeColumn"].Value.ToString() == "Truck")
                        TableCar.Rows[e.RowIndex].Tag = new Truck((string)TableCar.Rows[e.RowIndex].Cells["Brand"].Value, (string)TableCar.Rows[e.RowIndex].Cells["Model"].Value, (string)TableCar.Rows[e.RowIndex].Cells["Power"].Value, (string)TableCar.Rows[e.RowIndex].Cells["MaxSpeed"].Value);
                
                    if (TableCar.Rows[e.RowIndex].Cells["TypeColumn"].Value.ToString() == "Plane")
                        TableCar.Rows[e.RowIndex].Tag = new Plane((string)TableCar.Rows[e.RowIndex].Cells["Brand"].Value, (string)TableCar.Rows[e.RowIndex].Cells["Model"].Value, (string)TableCar.Rows[e.RowIndex].Cells["Power"].Value, (string)TableCar.Rows[e.RowIndex].Cells["MaxSpeed"].Value);
                }
            }
        }

        // Триггер на изменение в комбобоксиках
        private void TableCar_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (TableCar.IsCurrentCellDirty)
            {
                TableCar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Вызов таблички с единственной маркой
        private void TableCar_SelectionChanged(object sender, EventArgs e)
        {
            if (!isInitializing && TableCar.SelectedCells.Count > 0)
            {
                DataGridViewCell currentCell = TableCar.SelectedCells[0];

                // При работе с комбобоксами вызова таблицы быть не должно
                if (currentCell.OwningColumn.Name != "TypeColumn")
                {
                    DataGridViewRow selectedRow = TableCar.Rows[currentCell.RowIndex];
                    string selectedBrand = string.Empty;
                    

                    if (selectedRow.Cells.Count > 0 && selectedRow.Cells[0].Value != null)
                    {
                        // Сделал проверку на модельку
                        selectedBrand = selectedRow.Cells[2].Value.ToString(); // Берём именно марку
                    }
                    //ShowCarListTable(selectedBrand, selectedRow);

                    // Оповестить подписчиков о выборе машины
                    ICar selectedCar = (ICar)selectedRow.Tag;
                    CarSelected?.Invoke(selectedCar);
                }
            }
        }

        private void ShowCarListTable(string brand, DataGridViewRow selectedRow)
        {
            certainCars = GetCarsByBrand(brand);

            if (certainCars.Count > 0)
            {
                ICar selectedCar = certainCars[certainCars.Count - 1]; // Берем первую машину, но можно выбирать любую

                if (!openForms.Contains((ICar)selectedRow.Tag))
                {
                    openForms.Add((ICar)selectedRow.Tag);

                    //CarListForm carListForm = new CarListForm(selectedCar, openForms, selectedRow);
                    //carListForm.Show();

                    
                }

            }
        }

        private List<ICar> GetCarsByBrand(string model)
        {
            if (carDictionary.ContainsKey(model))
            {
                return carDictionary[model];
            }
            return new List<ICar>();
        }

        private void UpdateCarData(DataGridViewRow row)
        {
            bindingSource.ResetBindings(false);

            
        }

        private void сохранитьСписокМарокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveCars = new SaveFileDialog();
                saveCars.Filter = "Extensible Markup files (*.xml)|*.xml|All files(*.*)|*.*";
                saveCars.FilterIndex = 0;
                saveCars.RestoreDirectory = true;
                saveCars.InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                saveCars.Title = "Сохранение списка машин";

                if (saveCars.ShowDialog() == DialogResult.OK)
                {
                    if (saveCars.FileName != "")
                    {
                        CarContainer container = new CarContainer();

                        foreach (var car in cars)
                        {
                            if (car is PassengerCar)
                            {
                                container.PassengerCars.Add((PassengerCar)car);
                            }
                            else if (car is Truck)
                            {
                                container.Trucks.Add((Truck)car);
                            }
                            else if (car is Plane)
                            {
                                container.Planes.Add((Plane)car);
                            }
                        }

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarContainer));

                        using (FileStream fs = new FileStream(saveCars.FileName, FileMode.OpenOrCreate))
                        {
                            xmlSerializer.Serialize(fs, container);
                        }

                        MessageBox.Show("Список машин успешно сохранен.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели пустое имя файла", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openCars = new OpenFileDialog();
            openCars.Filter = "Extensible Markup files (*.xml)|*.xml|All files(*.*)|*.*";
            openCars.FilterIndex = 0;
            openCars.RestoreDirectory = true;
            openCars.InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (openCars.ShowDialog() == DialogResult.OK)
            {
                if (openCars.FileName != "")
                {
                    // Очистка данных перед загрузкой новых
                    cars.Clear();
                    carDictionary.Clear();

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarContainer));
                    using (FileStream fs = new FileStream(openCars.FileName, FileMode.OpenOrCreate))
                    {
                        CarContainer container = xmlSerializer.Deserialize(fs) as CarContainer;

                        // Переносим данные из контейнера в списки
                        if (container != null)
                        {
                            foreach (var passengerCar in container.PassengerCars)
                            {
                                AddCar(passengerCar);
                            }

                            foreach (var truck in container.Trucks)
                            {
                                AddCar(truck);
                            }

                            foreach (var plane in container.Planes)
                            {
                                AddCar(plane);
                            }
                        }
                    }

                    // Создаем новый BindingSource и связываем его с новым списком
                    BindingSource newBindingSource = new BindingSource();
                    newBindingSource.DataSource = cars;
                    TableCar.DataSource = newBindingSource;
                    bindingSource = newBindingSource;

                    // Пересоздаем словарь
                    PopulateCarDictionary();

                    // Применяем тип и цвет ко всем строкам
                    ApplyTypeAndColorToAllRows();
                }
                else
                {
                    MessageBox.Show("Вы ввели пустое имя файла", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void AddNewCarInTableBtn_Click(object sender, EventArgs e)
        {
            // Создаем форму для ввода данных о новой машине
            AddCarForm addCarForm = new AddCarForm();

            // Если пользователь ввел данные и нажал "ОК"
            if (addCarForm.ShowDialog() == DialogResult.OK)
            {
                // Получаем введенные данные из формы
                string brand = addCarForm.Brand;
                string model = addCarForm.Model;
                string power = addCarForm.Power;
                string maxSpeed = addCarForm.MaxSpeed;
                CarType carType = addCarForm.CarType;

                // Создаем новый объект машины
                ICar newCar;
                if (carType == CarType.PassengerCar)
                {
                    newCar = new PassengerCar(brand, model, power, maxSpeed);
                }
                else if (carType == CarType.Truck)
                {
                    newCar = new Truck(brand, model, power, maxSpeed);
                }
                else
                {
                    newCar = new Plane(brand, model, power, maxSpeed);
                }

                // Добавляем новую машину в список и словарь
                cars.Add(newCar);
                AddCarToDictionary(newCar);
                //TableCar.SelectionChanged -= TableCar_SelectionChanged;
                // Обновляем привязку данных
                bindingSource.ResetBindings(true);

                //TableCar.SelectionChanged += TableCar_SelectionChanged;

                //TableCar.Refresh();
                ApplyTypeAndColorToAllRows();

            }
        }

        private void ApplyTypeAndColorToAllRows()
        {
            foreach (DataGridViewRow row in TableCar.Rows)
            {

                ICar car = cars[row.Index];

                // Присваиваем тип машины в соответствующей ячейке
                row.Cells["TypeColumn"].Value = car.CarType.ToString();

                // Разукрашиваем строку в зависимости от типа машины
                SetColorOfRow(row);
            }
        }

        private void AddCarToDictionary(ICar car)
        {
            string model = car.Model;
            if (!carDictionary.ContainsKey(model))
            {
                carDictionary[model] = new List<ICar>();
            }
            carDictionary[model].Add(car);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (Form form in Application.OpenForms)
            //{
            //    form.Close();
            //}
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
