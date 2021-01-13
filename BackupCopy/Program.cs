using System;
using ConsoleMenu;

namespace BackupCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            DVD dvd = new DVD
            {
                StorageName = "DVD",
                StorageModel = "DVD-R Mixer",
                SpeedOfReadAndWrite = 10, //мб
                TypeOfDVD = TypeOfDVD.SingleSidedDVD
            };
            HDD hdd = new HDD
            {
                StorageName = "HDD",
                StorageModel = "HDD Toshiba HDWL11UZSVA",
                Speed= 300, //мб
                CountOfSections = 4,
                VolumeOfSections = 250,
            };

            Flash flash = new Flash
            {
                StorageName = "Flash",
                StorageModel = "Kingston DataTraveler Exodia",
                Speed = 20, // мб
                FlashMemoryVolume = 128, 
            };

            const int sizeArray = 3;
            Storage[] storages = new Storage[sizeArray] { hdd, dvd, flash };


            string[] items = { "Pасчет общего количества памяти всех устройств", "Копирование информации на устройства", 
                "Pасчет времени необходимого для копирования", "расчет необходимого количества носителей информации представленных типов для переноса информации"};
            var menu = new Menu(items);
            string choice;
            do
            {
                Console.Clear();
                menu.Print();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            double devicesMemory = 0;
                            foreach(var storage in storages)
                            {
                                devicesMemory += storage.GetMemorySize();
                            }
                            Console.WriteLine($"Общая память всех устройств = {devicesMemory}");
                        }
                        break;
                    case "2":
                        {
                            double memoryCopyData;
                            Console.Write("Введите объем информации: ");
                            memoryCopyData = double.Parse(Console.ReadLine());
                            Console.WriteLine("Выберите устройство:\n1. HDD\n2.DVD\n3.Flash");
                            int deviceNumber = int.Parse(Console.ReadLine());
                            if(storages[deviceNumber-1].CopyDataToDevice(memoryCopyData))
                            {
                                Console.WriteLine("Копирование прошло успешно!");
                            }
                            else
                            {
                                Console.WriteLine("Произошла ошибка");
                            }                         
                        }break;
                    case "3":
                        {
                            Console.Write("Введите объем информации: ");
                            double memoryCopyData = double.Parse(Console.ReadLine());
                            Console.WriteLine("Выберите устройство:\n1. HDD\n2.DVD\n3.Flash");
                            int deviceNumber = int.Parse(Console.ReadLine());
                            DateTime time = new DateTime();
                            if (storages[deviceNumber-1] is HDD)
                            {
                                var storageAsHDD = storages[deviceNumber - 1] as HDD;
                                time = time.AddSeconds((int)(memoryCopyData * 1024 / storageAsHDD.Speed));
                                Console.WriteLine($"Время передачи информации: {time.TimeOfDay}");
                            }
                            else if (storages[deviceNumber - 1] is DVD)
                            {
                                var storageAsDVD = storages[deviceNumber - 1] as DVD;
                                time = time.AddSeconds((int)(memoryCopyData * 1024 / storageAsDVD.SpeedOfReadAndWrite));
                                Console.WriteLine($"Время передачи информации: {time.TimeOfDay}");
                            }
                            else if(storages[deviceNumber - 1] is Flash)
                            {
                                var storageAsFlash = storages[deviceNumber - 1] as Flash;
                                time = time.AddSeconds((int)(memoryCopyData * 1024 / storageAsFlash.Speed));
                                Console.WriteLine($"Время передачи информации: {time.TimeOfDay}");
                            }
                        }break;
                    case "4":
                        {
                            Console.Write("Введите объем информации: ");
                            double memoryCopyData = double.Parse(Console.ReadLine());
                            Console.WriteLine("Выберите устройство:\n1. HDD\n2.DVD\n3.Flash");
                            int deviceNumber = int.Parse(Console.ReadLine());
                            if (memoryCopyData < storages[deviceNumber - 1].GetMemorySize())
                            {
                                Console.WriteLine($"Необходимое количество {storages[deviceNumber - 1].StorageName} = 1");
                            }
                            else
                            {
                                Console.WriteLine($"Необходимое количество {storages[deviceNumber - 1].StorageName} = {Math.Ceiling(memoryCopyData / hdd.GetMemorySize())}");
                            }                         
                        }break;
                }
                Console.ReadKey();
            } while (choice != "5");

        }
    }
}
