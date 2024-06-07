using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace third_product_lab3
{
    public class Loader
    {
        public static Dictionary<string, List<ICar>> carData = new Dictionary<string, List<ICar>>();
        private static Random random = new Random();

        // Внедряем прогресс
        private static int progress = 0;
        private static object progressLock = new object();

        private static TcpListener tcpListener;
        private static Thread listenerThread;
        private static int port = 11000;
        public static List<ICar> Load(string model, CarType carType)
        {
            if (string.IsNullOrEmpty(model) || !carData.ContainsKey(model) || carData[model] == null)
            {
                GenerateCarData(carType, model);
            }

            return carData[model];
        }

        public static void StartServer()    
        {
            // Создаю новый поток для прослушивания клиентов
            listenerThread = new Thread(ListenForClients);
            listenerThread.Start(port);
        }

        private static void ListenForClients(object portObject)
        {

            int port = (int)portObject;
            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            // Создаем сокет Tcp/Ip
            tcpListener = new TcpListener(ipAddr, port);

            // Начинаем слушать соединения
            tcpListener.Start();

            //Console.WriteLine($"Сервер запущен на порту {port}");

            while (true)
            {
                // Программа приостанавливается, ожидая входящее соединение
                TcpClient client = tcpListener.AcceptTcpClient();

                // Создаем новый поток для обслуживания клиента
                Thread clientThread = new Thread(HandleClient);
                clientThread.Start(client);
            }
        }

        private static void HandleClient(object clientObject)
        {
            TcpClient tcpClient = (TcpClient)clientObject;

            NetworkStream clientStream = tcpClient.GetStream();
            byte[] messageBytes = new byte[1024];

            int bytesRead = clientStream.Read(messageBytes, 0, messageBytes.Length);
            string messages = Encoding.UTF8.GetString(messageBytes, 0, bytesRead);

            RequestData request = JsonConvert.DeserializeObject<RequestData>(messages);
            string response = ProccesingRequest(request);

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            clientStream.Write(responseBytes, 0, responseBytes.Length);

            tcpClient.Close();
        }

        private static string ProccesingRequest(RequestData request)
        {

            //ResponseData response = new ResponseData();

            string response;
            // Загружаем данные для указанной модели
            List<ICar> cars = Load(request.Model, request.CarType);

            // Преобразуем данные в строку JSON
            response = JsonConvert.SerializeObject(cars);

            //response = "Неизвестный тип запроса";
            
            return response;
        }

        public static void StopServer()
        {
            // Останавливаем прослушивание новых соединений
            tcpListener.Stop();

            
            Environment.Exit(0);
        }


        private static void GenerateCarData(CarType carType, string carModel)
        {
            Random random = new Random();
            int numberOfCars = random.Next(3, 6); // Случайное количество от 5 до 10

            List<ICar> generatedCars = new List<ICar>();

            for (int i = 0; i < numberOfCars; i++)
            {
                Thread.Sleep(random.Next(0, 1001));
                // Генерируем случайный автомобиль
                ICar newCar = GenerateRandomCar(carType);
                newCar.Model = carModel;

                progress = (int)(((double)(i + 1) / numberOfCars) * 100);

                generatedCars.Add(newCar);
            }

            carData[carModel] = generatedCars;
        }

        private static ICar GenerateRandomCar(CarType carType)
        {
            ICar newCar;

            switch (carType)
            {
                case CarType.PassengerCar:
                    newCar = new PassengerCar();
                    PassengerCar passengerCar = (PassengerCar)newCar;
                    passengerCar.RegNumber = GenerateRandomRegistrationNumber();
                    passengerCar.Multimedia = GenerateRandomMultimedia();
                    passengerCar.NumOfAirbags = random.Next(1, 5);
                    break;
                case CarType.Truck:
                    newCar = new Truck();
                    Truck truck = (Truck)newCar;
                    truck.RegNumber = GenerateRandomRegistrationNumber();
                    truck.NumOfWheels = random.Next(4, 18);
                    truck.BodyCapacity = random.Next(100, 1001);
                    break;

                case CarType.Plane:
                    newCar = new Plane();
                    Plane plane = (Plane)newCar;
                    plane.RegNumber = GenerateRandomRegistrationNumber();
                    plane.Capacity = random.Next(2, 120);
                    plane.Wingspan = random.Next(10, 50);
                    break;

                default:
                    // Выкидываю экзепшн для несуществующего типа
                    throw new ArgumentException("Несуществующий тип");
            }

            return newCar;
        }

        private static string GenerateRandomRegistrationNumber()
        {
            Random random = new Random();
            string letters = "АВЕКМНОРСТУХ";
            string numbers = "0123456789";

            // Генерируем 3 буквы
            string registrationNumber = $"{letters[random.Next(0, letters.Length)]}{letters[random.Next(0, letters.Length)]}{letters[random.Next(0, letters.Length)]}";

            // Генерируем 3 цифры
            string threeNumbers = $"{numbers[random.Next(0, numbers.Length)]}{numbers[random.Next(0, numbers.Length)]}{numbers[random.Next(0, numbers.Length)]}";

            registrationNumber = threeNumbers[0] + registrationNumber + threeNumbers[1] + threeNumbers[2];
            return registrationNumber;
        }

        private static string GenerateRandomMultimedia()
        {
            List<string> multimediaOptions = new List<string> { "Enjoy", "Alpine", "Vulcan", "OptimusPrime" };
            Random random = new Random();

            return multimediaOptions[random.Next(0, multimediaOptions.Count)];
        }

        public static int GetProgress()
        {
            return progress;
        }

        
       


    }

    // Классы для обработки информации
    public class RequestData
    {
        public string Model { get; set; }
        public CarType CarType { get; set; }

    }

    // Класс для представления данных ответа сервера клиенту
    public class ResponseData
    {
        public List<ICar> Cars { get; set; }

    }

}
