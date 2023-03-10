using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{

    // Описываем наш класс и помечаем его атрибутом для последующей сериализации   
    [Serializable]
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Pet(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    [Serializable]
    class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Сериализация Contact
            var contact = new Contact("Peter", 6565746354546464, "peter@gmail.com");

            BinaryFormatter formatter1 = new BinaryFormatter();
            using (var sf = new FileStream("BinaryFile.bin", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(sf, contact);
                Console.WriteLine("Объект сериализован");
            }
            using (var sf = new FileStream("BinaryFile.bin", FileMode.OpenOrCreate))
            {
                var newcontact = (Contact)formatter1.Deserialize(sf);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newcontact.Name}\nВозраст: {newcontact.PhoneNumber}\nEmail: {newcontact.Email}");
                Console.ReadKey();
            }

        }
        #endregion

        #region
        //// объект для сериализации
        //var person = new Pet("Rex", 2);
        //Console.WriteLine("Объект создан");

        //BinaryFormatter formatter = new BinaryFormatter();
        //// получаем поток, куда будем записывать сериализованный объект
        //using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
        //{
        //    formatter.Serialize(fs, person);
        //    Console.WriteLine("Объект сериализован");
        //}
        //// десериализация
        //using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
        //{
        //    var newPet = (Pet)formatter.Deserialize(fs);
        //    Console.WriteLine("Объект десериализован");
        //    Console.WriteLine($"Имя: {newPet.Name} --- Возраст: {newPet.Age}");
        //}
        //Console.ReadLine();
        #endregion

    }
}

//namespace FileSystem
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string filePath = @"C:\Users\elsokolova\Desktop\BinaryFile.bin";
//            string binFile;


//            if (File.Exists(filePath))
//            {
//                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
//                {
//                    binFile = reader.ReadString();
//                    Console.WriteLine($"Информация из файла BinaryFile.bin:{binFile}");
//                    Console.ReadKey();
//                    reader.Close();
//                }

//                // Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
//                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
//                {
//                    DriveInfo[] drives = DriveInfo.GetDrives(); ;
//                    writer.Write($"Файл изменен {DateTime.Now} на компьютере {Environment.OSVersion}");
//                    writer.Close();
//                }
//            }

//            //Код для истории
//            #region
//            //var str = DriveInfo.GetDrives();
//            //Console.WriteLine("Название и перечень дисков:\n{0}.\nДополнительная информация:\n{1},\n{2},\n{3},\n{4},\n{5},\n{6},\n{7},\n{8}", str[0],str[0].AvailableFreeSpace,str[0].DriveFormat,str[0].DriveType,str[0].IsReady,str[0].Name,str[0].TotalFreeSpace,str[0].TotalSize,str[0].VolumeLabel);

//            //foreach (var item in str)
//            //{
//            //    Console.WriteLine(item);
//            //}

//            //// получим системные диски
//            //DriveInfo[] drives = DriveInfo.GetDrives();

//            //// Пробежимся по дискам и выведем их свойства
//            //foreach (DriveInfo drive in drives)
//            //{
//            //    Console.WriteLine($"Название: {drive.Name}");
//            //    Console.WriteLine($"Тип: {drive.DriveType}");
//            //    if (drive.IsReady) //возращает bool
//            //    {
//            //        Console.WriteLine($"Объем: {drive.TotalSize}");
//            //        Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
//            //        Console.WriteLine($"Метка: {drive.VolumeLabel}");
//            //    }
//            //}

//            //Task2.FileAppendText();
//            ////GetCatalogs();      // Вызов метода получения директорий
//            //string path = "TEST2";
//            //string newpath = "TEST";
//            //GetCatalogsCount(); // Вызов метода подсчета директорий и файлов
//            //CreateDir(path);        // Вызов метода для создания новой папки
//            //GetCatalogsCount();
//            ////DeleteDir(path);
//            //MoveDir(path, newpath);
//            //Console.ReadKey();
//            #endregion
//        }

//        // Код для истории
//        #region
//        //    static void GetCatalogs()
//        //    {
//        //        string dirName = @"/"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
//        //        if (Directory.Exists(dirName)) // Проверим, что директория существует
//        //        {
//        //            Console.WriteLine("Папки:");
//        //            string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

//        //            foreach (string d in dirs) // Выведем их все
//        //                Console.WriteLine(d);

//        //            Console.WriteLine();
//        //            Console.WriteLine("Файлы:");
//        //            string[] files = Directory.GetFiles(dirName,"*",SearchOption.TopDirectoryOnly);// Получим все файлы корневого каталога

//        //            foreach (string s in files)   // Выведем их все
//        //                Console.WriteLine(s);
//        //        }
//        //        //Console.ReadKey();
//        //    }

//        //    static void GetCatalogsCount(string path = @"/")
//        //    {
//        //        string dirName = @"/";         // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
//        //        if (Directory.Exists(dirName)) // Проверим, что директория существует
//        //        {
//        //            Console.WriteLine("Считаем папки:");
//        //            string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

//        //            int i = 0;
//        //            foreach (var item in dirs)
//        //            {
//        //                i++;
//        //            }
//        //            Console.WriteLine("---------------------\nКоличество папок: {0}", i);

//        //            Console.WriteLine("\nСчитаем файлы.");
//        //            string[] files = Directory.GetFiles(dirName, "*", SearchOption.TopDirectoryOnly); // Получим все файлы корневого каталога

//        //            int j = 0;
//        //            foreach (string s in files) 
//        //            {
//        //                j++;

//        //            }
//        //            Console.WriteLine("---------------------\nКоличество файлов: {0}\n\n", j);
//        //        }

//        //        try
//        //        {
//        //            DirectoryInfo dirInfo = new DirectoryInfo(@"/"); /* Или С:\\ для Windows */
//        //            //CreateDir();
//        //            if (dirInfo.Exists)
//        //            {
//        //                Console.WriteLine("Всего: {0}\n\n", dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
//        //            }
//        //        }
//        //        catch (Exception e)
//        //        {
//        //            Console.WriteLine(e.Message);
//        //        }


//        //        //Console.ReadKey();
//        //    }

//        //    public static void CreateDir(string foldername, string path = @"/")
//        //    {
//        //        DirectoryInfo dirInfo = new DirectoryInfo(path);
//        //        if (!dirInfo.Exists)
//        //            dirInfo.Create();

//        //        dirInfo.CreateSubdirectory(foldername);

//        //        Console.WriteLine($"Название каталога: {dirInfo.Name}");
//        //        Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
//        //        Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
//        //        Console.WriteLine($"Корневой каталог: {dirInfo.Root}\n\n");
//        //    }

//        //    public static void DeleteDir(string path)
//        //    {
//        //        try
//        //        {
//        //            DirectoryInfo dirInfo = new DirectoryInfo(@"\" + path);
//        //            dirInfo.Delete(true); // Удаление со всем содержимым
//        //            Console.WriteLine("Каталог удален");
//        //        }
//        //        catch (Exception ex)
//        //        {
//        //            Console.WriteLine(ex.Message);
//        //        }
//        //    }

//        //    public static void MoveDir(string path, string newPath)
//        //    {
//        //        DirectoryInfo dirInfo = new DirectoryInfo(@"\" + path);
//        //        //string newPath = @"\TEST";

//        //        if (dirInfo.Exists && !Directory.Exists(newPath))
//        //            dirInfo.MoveTo(newPath);
//        //    }

//        //}

//        //class Drive
//        //{
//        //    public Drive()
//        //    {

//        //    }

//        //    public Drive(string name, long totalSpace, long freeSpace)
//        //    {
//        //        Name = name;
//        //        TotalSpace = totalSpace;
//        //        FreeSpace = freeSpace;
//        //    }

//        //    public string Name { get; }
//        //    public long TotalSpace { get; }
//        //    public long FreeSpace { get; }


//        //}

//        //class Folder
//        //{
//        //    public List<string> Files { get; set; } = new List<string>();

//        //    Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

//        //    public void CreateFolder(string name)
//        //    {
//        //        Folders.Add(name, new Folder());
//        //    }
//        //}

//        //class SystemDrive : Drive
//        //{
//        //    public long ReservedSpace { get; set; }

//        //    public SystemDrive()
//        //    {
//        //        var strInt = int.TryParse(Console.ReadLine(), out int result);
//        //    }
//        //}

//        //static class Task2
//        //{
//        //    public static void FileAppendText()
//        //    {
//        //        var fileInfo = new FileInfo(@"C:\Users\LocalUser\SkillFactory\repos\Module8\FileSystem\Program.cs");

//        //        using (StreamWriter sw = fileInfo.AppendText())
//        //        {
//        //            sw.WriteLine($"// Время запуска: {DateTime.Now}");
//        //        }

//        //        using (StreamReader sr = fileInfo.OpenText())
//        //        {
//        //            string str = "";
//        //            while ((str = sr.ReadLine()) != null)
//        //                Console.WriteLine(str);

//        //            Console.ReadKey();

//        //        }
//        //    }
//        #endregion
//    }

//    [Serializable] //   Атрибут сериализации
//    class Person
//    {
//        // Простая модель класса 
//        public string Name { get; set; }
//        public int Year { get; set; }

//        // Метод - конструктор
//        public Person(string name, int year)
//        {
//            Name = name;
//            Year = year;
//        }
//    }
//}
//// Время запуска: 05.01.2023 00:06:12
//// Время запуска: 05.01.2023 00:07:18
