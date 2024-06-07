using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using third_product_lab3;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace SocketClient
{
    internal class Program
    {
        private static Socket sender;
        [STAThread]
        static async Task Main(string[] args)
        {

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            // Создаем сокет Tcp/IP
            sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Соединяем сокет с удаленной точкой
                await sender.ConnectAsync(ipEndPoint);

                MainForm mainForm = new MainForm();
                mainForm.CarSelected += OnCarSelected;
                Task mainFormTask = Task.Run(() => Application.Run(mainForm));

                while (true)
                {
                    // Получение ответа от сервера
                    byte[] responseBytes = new byte[1024];
                    int bytesRead = sender.Receive(responseBytes);

                    if (bytesRead == 0)
                    {
                        // Сервер закрыл соединение
                        break;
                    }

                    string responseJson = Encoding.UTF8.GetString(responseBytes, 0, bytesRead);

                    List<RequestData> requestDataList = JsonConvert.DeserializeObject<List<RequestData>>(responseJson);

                    List<ICar> response = new List<ICar>();
                    foreach (var requestData in requestDataList)
                    {
                        ICar car;
                        if (requestData.CarType == CarType.PassengerCar)
                        {
                            car = JsonConvert.DeserializeObject<PassengerCar>(JsonConvert.SerializeObject(requestData));
                        }
                        else if (requestData.CarType == CarType.Truck)
                        {
                            // Обработка других типов машин, например, CargoCar
                            car = JsonConvert.DeserializeObject<Truck>(JsonConvert.SerializeObject(requestData));
                        }
                        else
                        {
                            car = JsonConvert.DeserializeObject<Plane>(JsonConvert.SerializeObject(requestData));
                        }

                        response.Add(car);
                    }
                    Console.WriteLine("Данные получены от сервера.");
                    Application.Run(new CarListForm(response));
                    //Console.WriteLine("Данные получены от сервера.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка: {e.ToString()}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Console.WriteLine("Ошибка: " + e.ToString());
            }
            finally
            {
                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
        }   

        private static void OnCarSelected(ICar selectedCar)
        {
            try
            {

                // Подготавливаем данные для отправки
                if (selectedCar != null)
                {
                    RequestData selectedCarData = new RequestData
                    {
                        Model = selectedCar.Model,
                        CarType = selectedCar.CarType
                    };

                    // Отправляем данные серверу
                    string selectedCarJson = JsonConvert.SerializeObject(selectedCarData);
                    byte[] selectedCarBytes = Encoding.UTF8.GetBytes(selectedCarJson);

                    sender.Send(selectedCarBytes);
                    Console.WriteLine($"Выбранная машина отправлена на сервер: {selectedCar.Model}");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка при отправке выбранной машины на сервер: {e.ToString()}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
