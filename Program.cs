using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SQLitePCL;



namespace Cars_Collection
{ 
    class Program
    {

        static void Main(string[] args)
        {
          
            SQLiteConnection db = new SQLiteConnection("Data Source = Car.db; Version = 3");
            db.Open();
     
           
            int repeat = 1;
            while(repeat == 1) { 
            Console.WriteLine("1. Вставка");
            Console.WriteLine("2. Удаление");
            Console.WriteLine("3. Редактирование");
            Console.WriteLine("4. Выборка машин одной марки");
            Console.WriteLine("5. Выборка машин одного цвета");
            Console.WriteLine("6. Выборка машин одного года выпуска");
            Console.WriteLine("7. Вывод всех машин на экран");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
            
                case 1:
                    {
                        int year;
                        string mark, model, type, color, country;
               
                        Console.Write("Введите марку: ");
                        mark = Console.ReadLine().ToUpper();
                        Console.Write("Введите модель: ");
                        model = Console.ReadLine().ToUpper();
                        Console.Write("Введите год производства: ");
                        year = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите тип кузова: ");
                        type = Console.ReadLine().ToUpper();
                        Console.Write("Введите цвет: ");
                        color = Console.ReadLine().ToUpper();
                        Console.Write("Введите страну-производитель: ");
                        country = Console.ReadLine().ToUpper();
                        SQLiteCommand insert = db.CreateCommand();
                        insert.CommandText = "insert into Car(Марка, Модель, Год, Тип, Цвет, Страна) values (@Марка, @Модель, @Год, @Тип, @Цвет, @Страна)";
                        
                        insert.Parameters.Add("@Марка", System.Data.DbType.String).Value = mark.ToUpper();
                        insert.Parameters.Add("@Модель", System.Data.DbType.String).Value = model.ToUpper();
                        insert.Parameters.Add("@Год", System.Data.DbType.Int32).Value = year;
                        insert.Parameters.Add("@Тип", System.Data.DbType.String).Value = type.ToUpper();
                        insert.Parameters.Add("@Цвет", System.Data.DbType.String).Value = color.ToUpper();
                        insert.Parameters.Add("@Страна", System.Data.DbType.String).Value = country.ToUpper();
                        
                        insert.ExecuteNonQuery();
                    }
                    break;
                case 2:{
                        SQLiteCommand delete = db.CreateCommand();
                        Console.WriteLine("Введите номер гаража, который хотите удалить из БД: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        delete.CommandText = "delete from Car where id = " + id.ToString();
                        delete.ExecuteNonQuery();

                        
                    } break;
                case 3: {
                        Console.WriteLine("Введите номер гаража, информацию о котором вы хотите редактировать: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите название поля, которое хотите редактировать: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите новое значение поля, которое хотите редактировать: ");
                        string temp = Console.ReadLine().ToUpper();

                        SQLiteCommand update = db.CreateCommand();
                        if(name == "Год")
                        {
                            update.CommandText = "update Car set " + name + " = " + temp + " where id = " + id;
                        }
                        else
                        {
                            update.CommandText = "update Car set " + name + " = '" + temp + "' where id = " + id.ToString();
                        }
                        update.ExecuteNonQuery();

                    }
                    break;
                case 4:
                        { 
                        Console.Write("Введите марку: ");
                        string mark_temp = Console.ReadLine().ToUpper();

                    
                        List<Car> onemark = new List<Car>(); 

                        SQLiteCommand cmd = db.CreateCommand();
                     cmd.CommandText = "select * from Car where Марка = '" + mark_temp + "'";
                     SQLiteDataReader inp = cmd.ExecuteReader();
          
                     while(inp.Read()){
                     int  id_inp = Convert.ToInt32(inp["Id"]);
                     string mark_inp = inp["Марка"].ToString();
                     string model_inp = inp["Модель"].ToString();
                     int year_inp = Convert.ToInt32(inp["Год"]);
                     string type_inp = inp["Тип"].ToString();
                     string color_inp = inp["Цвет"].ToString();
                     string country_inp = inp["Страна"].ToString();
                     Car temp = new Car();
                     temp.Id = id_inp;
                     temp.Mark = mark_inp;
                     temp.Model = model_inp;
                     temp.Year = year_inp;
                     temp.Type = type_inp;
                     temp.Color = color_inp;
                     temp.Country = country_inp;
                     onemark.Add(temp);

                     }
                     foreach(var i in onemark)
                     {
                     Console.WriteLine(i.Id + ". " + i.Mark + " " + i.Model + " " + i.Year + " " + i.Type + " " + i.Color + " " + i.Country);
                     }
                     }
                    
                    break;
                case 5: {
                            Console.Write("Введите цвет: ");
                            string color_temp  = Console.ReadLine().ToUpper();
                               List<Car> onecolor = new List<Car>(); 

                        SQLiteCommand cmd = db.CreateCommand();
                     cmd.CommandText = "select * from Car where Цвет = '" + color_temp + "'";
                     SQLiteDataReader inp = cmd.ExecuteReader();
          
                     while(inp.Read()){
                     int id_inp = Convert.ToInt32(inp["Id"]);
                     string mark_inp = inp["Марка"].ToString();
                     string model_inp = inp["Модель"].ToString();
                     int year_inp = Convert.ToInt32(inp["Год"]);
                     string type_inp = inp["Тип"].ToString();
                     string color_inp = inp["Цвет"].ToString();
                     string country_inp = inp["Страна"].ToString();
                     Car temp = new Car();
                     temp.Id = id_inp;
                     temp.Mark = mark_inp;
                     temp.Model = model_inp;
                     temp.Year = year_inp;
                     temp.Type = type_inp;
                     temp.Color = color_inp;
                     temp.Country = country_inp;
                     onecolor.Add(temp);

                     }
                     foreach(var i in onecolor)
                     {
                     Console.WriteLine(i.Id + ". " + i.Mark + " " + i.Model + " " + i.Year + " " + i.Type + " " + i.Color + " " + i.Country);
                     }
                     }
                        
                        break;
                case 6:
                    {
                    Console.Write("Введите год выпуска автомобиля: ");
                    int year_temp = Convert.ToInt32(Console.ReadLine());
                       List<Car> oneyear = new List<Car>(); 

                        SQLiteCommand cmd = db.CreateCommand();
                     cmd.CommandText = "select * from Car where Год = " + year_temp;
                     SQLiteDataReader inp = cmd.ExecuteReader();
          
                     while(inp.Read()){
                     int id_inp = Convert.ToInt32(inp["Id"]);
                     string mark_inp = inp["Марка"].ToString();
                     string model_inp = inp["Модель"].ToString();
                     int year_inp = Convert.ToInt32(inp["Год"]);
                     string type_inp = inp["Тип"].ToString();
                     string color_inp = inp["Цвет"].ToString();
                     string country_inp = inp["Страна"].ToString();
                     Car temp = new Car();
                     temp.Id = id_inp;
                     temp.Mark = mark_inp;
                     temp.Model = model_inp;
                     temp.Year = year_inp;
                     temp.Type = type_inp;
                     temp.Color = color_inp;
                     temp.Country = country_inp;
                     oneyear.Add(temp);

                     }
                     foreach(var i in oneyear)
                     {
                     Console.WriteLine(i.Id + ". " + i.Mark + " " + i.Model + " " + i.Year + " " + i.Type + " " + i.Color + " " + i.Country);
                     }
                     }
                
                break;
                case 7:
                    {
                       List<Car> list = new List<Car>();
                     SQLiteCommand cmd = db.CreateCommand();
                     cmd.CommandText = "select * from Car";
                     SQLiteDataReader inp = cmd.ExecuteReader();
          
                     while(inp.Read()){
                     int id = Convert.ToInt32(inp["Id"]);
                     string mark = inp["Марка"].ToString();
                     string model = inp["Модель"].ToString();
                     int year = Convert.ToInt32(inp["Год"]);
                     string type = inp["Тип"].ToString();
                     string color = inp["Цвет"].ToString();
                     string country = inp["Страна"].ToString();
                     Car temp = new Car();
                     temp.Id = id;
                     temp.Mark = mark;
                     temp.Model = model;
                     temp.Year = year;
                     temp.Type = type;
                     temp.Color = color;
                     temp.Country = country;
                     list.Add(temp);

                     }
                     foreach(var i in list)
                     {
                     Console.WriteLine(i.Id + ". " + i.Mark + " " + i.Model + " " + i.Year + " " + i.Type + " " + i.Color + " " + i.Country);
                     }
                    }

                    break;
                   
                 
                    }             
                   Console.WriteLine("Вы хотите продолжить? 1 - да, 0 - нет");
                   repeat = Convert.ToInt32(Console.ReadLine());
                  
                }


         





















          db.Close();
        }

    }
}
