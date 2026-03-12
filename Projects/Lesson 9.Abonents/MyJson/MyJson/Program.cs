// See https://aka.ms/new-console-template for more information
using MyJson;
using Newtonsoft.Json;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Переворюю дані у формат JSON");

//MyAbonent vova = new ()
//{
//    LastName = "Новак",
//    FirstName= "Вова",
//    SecondName = "Миколайович",
//    Phone = "098 78 78 334"
//};
////Перетворити vova у json - рядок тексту
//string json = JsonConvert.SerializeObject(vova);
//Console.WriteLine($"json = {json}");

//File.AppendAllText("mytext.txt", json, Encoding.UTF8);

string jsonRead = File.ReadAllText("mytext.txt", Encoding.UTF8);
// Перетворюємо із Json назад у С#
MyAbonent stepan = JsonConvert.DeserializeObject<MyAbonent>(jsonRead);

Console.WriteLine($"{stepan.LastName} {stepan.FirstName} {stepan.SecondName} - {stepan.Phone}");

