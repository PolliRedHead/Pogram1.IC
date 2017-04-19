// Type: iofile.infSystem
// Assembly: iofile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Рафаэль\Desktop\Архитектура ИС\Лаба 1\Example\iofile.exe

using System;
using System.Collections.Generic;
using System.IO;

namespace iofile
{
    internal class infSystem
    {
        private string _FileName;

        public infSystem(string fileName)
        {
            this._FileName = fileName;
        }

        public void outputMain()
        {
         
            ConsoleKeyInfo consoleKey;
            do
            {
                Console.Clear();
                Console.WriteLine("Вывод данных о авиарейсах: ");
                Console.WriteLine("1. Вывести все данные о авиарейсах.");
                Console.WriteLine("2. Вывести совпадения по названию самолета.");
                Console.WriteLine("3. Вывести совпадения по длительности полета.");
                Console.WriteLine("Esc. Назад");
                consoleKey = Console.ReadKey(true);
                switch (consoleKey.KeyChar)
                {
                    case '1':
                        this.output(1, "");
                        break;
                    case '2':
                        Console.Write("Введите название самолета: ");
                        this.output(2, Console.ReadLine());
                        break;
                    case '3':
                        Console.Write("Введите длительность полета: ");
                        this.output(3, Console.ReadLine());
                        break;
                }
            }
            while (consoleKey.Key != ConsoleKey.Escape);
        }

        private void output(int type, string value = "")
        {
            Console.Clear();
            StreamReader streamReader = new StreamReader(this._FileName);
            switch (type)
            {
                case 1:
                    Console.WriteLine("Все данные из файла " + this._FileName);
                    while (!streamReader.EndOfStream)
                    {

                        string str = streamReader.ReadLine();
                        if (str!=System.String.Empty)
                        {
                            string[] strArray = str.Split(new char[1]
                                                                                      {
                                                                                       ' '
                                                                                      });
                            Plane Plane = new Plane(strArray[0], strArray[1], strArray[2], Convert.ToInt32(strArray[3]), strArray[4]);
                            Plane.PrintPlane();
                        }
    
                    }
                    streamReader.Close();
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Совпадения по названию самолета из файла " + this._FileName);
                    while (!streamReader.EndOfStream)
                    {
                        string[] strArray = streamReader.ReadLine().Split(new char[1]
                                                                                     {
                                                                                        ' '
                                                                                     });
                        
                        Plane Plane = new Plane(strArray[0], strArray[1], strArray[2], Convert.ToInt32(strArray[3]), strArray[4]);
                        if (Plane.GetPlaneName() == value)
                            Plane.PrintPlane();
                    }
                    streamReader.Close();
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Совпадения по длительности полета из файла " + this._FileName);
                    while (!streamReader.EndOfStream)
                    {
                        string[] strArray = streamReader.ReadLine().Split(new char[1]
                                                                                      {
                                                                                       ' '
                                                                                      });
                        Plane Plane = new Plane(strArray[0], strArray[1], strArray[2], Convert.ToInt32(strArray[3]), strArray[4]);

                        int intBuf = 0;
                        try
                        {
                            intBuf = Convert.ToInt32(value);
                            if (Plane.GetHours() == Convert.ToInt32(value))
                                Plane.PrintPlane();
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Ошибка, неверный ввод.");
                            return;
                        }
                        
                    }
                    streamReader.Close();
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
            }
        }

        public void inputMain()
        {
            Plane Plane = new Plane();
            Console.Clear();
            Console.WriteLine("Добавление новой записи о авиарейсе: ");
            Console.Write("Введите пункт отправки: ");
            Plane.SetFrom(Console.ReadLine());
            Console.Write("Введите пункт прибытия: ");
            Plane.SetWhere(Console.ReadLine());
            Console.Write("Введите название самолета: ");
            Plane.SetPlaneName(Console.ReadLine());
            Console.Write("Введите продолжительность полета: ");
            Plane.SetHours(Convert.ToInt32(Console.ReadLine()));
            Console.Write("Действующий авиарейс (да/нет): ");
            Plane.SetWorkingStatus(Console.ReadLine());
            StreamWriter streamWriter = new StreamWriter(this._FileName, true);
            string str1 = Plane.GetFrom() + " " + Plane.GetWhere() + " " + Plane.GetPlaneName() + " " + Plane.GetHours().ToString() + " " + Plane.GetWorkingStatus();
            streamWriter.WriteLine(Plane.GetFrom() + " " + Plane.GetWhere() + " " + Plane.GetPlaneName() + " " + Plane.GetHours().ToString() + " " + Plane.GetWorkingStatus());
            streamWriter.Close();
        }

        public void deleteMain()
        {
            Console.Clear();
            Console.WriteLine("Удаление записи о авиарейсе.");
            Console.Write("Введите название самолета: ");
            string str1 = Console.ReadLine();
            List<Plane> list = new List<Plane>();
            StreamReader streamReader = new StreamReader(this._FileName);
            while (!streamReader.EndOfStream)
            {
                string[] strArray = streamReader.ReadLine().Split(new char[1]
        {
          ' '
        });
                Plane Plane = new Plane(strArray[0], strArray[1], strArray[2], Convert.ToInt32(strArray[3]), strArray[4]);
                list.Add(Plane);
            }
            streamReader.Close();
            StreamWriter streamWriter = new StreamWriter(this._FileName, false);
            foreach (Plane Plane in list)
            {
                if (!(Plane.GetPlaneName() == str1))
                    streamWriter.WriteLine(Plane.GetFrom() + " " + Plane.GetWhere() + " " + Plane.GetPlaneName() + " " + Plane.GetHours().ToString() + " " + Plane.GetWorkingStatus());
            }
            streamWriter.Close();
        }
    }
}
