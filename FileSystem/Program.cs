using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //var str = DriveInfo.GetDrives();
            //Console.WriteLine("Название и перечень дисков:\n{0}.\nДополнительная информация:\n{1},\n{2},\n{3},\n{4},\n{5},\n{6},\n{7},\n{8}", str[0],str[0].AvailableFreeSpace,str[0].DriveFormat,str[0].DriveType,str[0].IsReady,str[0].Name,str[0].TotalFreeSpace,str[0].TotalSize,str[0].VolumeLabel);

            //foreach (var item in str)
            //{
            //    Console.WriteLine(item);
            //}

            //// получим системные диски
            //DriveInfo[] drives = DriveInfo.GetDrives();

            //// Пробежимся по дискам и выведем их свойства
            //foreach (DriveInfo drive in drives)
            //{
            //    Console.WriteLine($"Название: {drive.Name}");
            //    Console.WriteLine($"Тип: {drive.DriveType}");
            //    if (drive.IsReady) //возращает bool
            //    {
            //        Console.WriteLine($"Объем: {drive.TotalSize}");
            //        Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
            //        Console.WriteLine($"Метка: {drive.VolumeLabel}");
            //    }
            //}
           

            GetCatalogs();      // Вызов метода получения директорий
            GetCatalogsCount(); // Вызов метода подсчета директорий и файлов
        }

        static void GetCatalogs()
        {
            string dirName = @"/"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName,"*",SearchOption.TopDirectoryOnly);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }
            Console.ReadKey();
        }

        static void GetCatalogsCount()
        {
            string dirName = @"/"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Считаем папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                int i = 0;
                foreach (var item in dirs)
                {
                    i++;
                }
                Console.WriteLine("---------------------\nКоличество папок: {0}", i);

                Console.WriteLine("\nСчитаем файлы.");
                string[] files = Directory.GetFiles(dirName, "*", SearchOption.TopDirectoryOnly);// Получим все файлы корневого каталога

                int j = 0;
                foreach (string s in files) 
                {
                    j++;
                    
                }
                Console.WriteLine("---------------------\nКоличество файлов: {0}", j);
            }
            Console.ReadKey();

        }
    }

    class Drive
    {
        public Drive()
        {

        }

        public Drive(string name, long totalSpace, long freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }

        public string Name { get; }
        public long TotalSpace { get; }
        public long FreeSpace { get; }


    }

    class Folder
    {
        public List<string> Files { get; set; } = new List<string>();

        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

        public void CreateFolder(string name)
        {
            Folders.Add(name, new Folder());
        }
    }

    class SystemDrive : Drive
    {
        public long ReservedSpace { get; set; }
        
        public SystemDrive()
        {
            var strInt = int.TryParse(Console.ReadLine(), out int result);
            
        }


    }



}
