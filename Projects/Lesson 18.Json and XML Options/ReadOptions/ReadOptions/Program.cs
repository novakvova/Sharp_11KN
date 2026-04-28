// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Робота з налаштуваннями");

//Програма працює із користувачами.
//Наприклад телефоний довідник
//Де довідник зберігає інформацію -
//У Файловій системі - може бути БД, файл
//Файл має назву user.bin - це наша БД.
//Ми хочемо змінити назву сховища - для цього викори
//стовується файли для зберігання конфігукації.

//Для збереження налаштування використовується файл
// - це xml - конфігурація
//web.config




var json = File.ReadAllText("appsettings.json");

// парсимо
var node = JsonNode.Parse(json);

// змінюємо значення
node["storage"] = "newValue";

// записуємо назад у файл
File.WriteAllText("appsettings.json", node.ToJsonString(new JsonSerializerOptions
{
    WriteIndented = true
}));

string fileWebConfig = File.ReadAllText("App.config");
string fileJsonConfig = File.ReadAllText("appsettings.json");

Console.WriteLine("---Web Config---");
Console.WriteLine(fileWebConfig);

Console.WriteLine("---Json config---");
Console.WriteLine(fileJsonConfig);

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

// читання значень
string nameStorage = config["storage"];
Console.WriteLine(nameStorage);