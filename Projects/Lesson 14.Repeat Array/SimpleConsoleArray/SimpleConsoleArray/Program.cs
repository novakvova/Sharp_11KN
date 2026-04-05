// See https://aka.ms/new-console-template for more information

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Основи C#. Повторення.");

//-----------змінні-------
//
//Тип даних string - рядок
//string str = "Hello!";
//Console.WriteLine(str);

//-----------обробка виключень-------
//int a; // Зберігає значення 0 - по замовчуванню
//Console.WriteLine("Вкажіть значення a:");
//string input = Console.ReadLine(); //Рядок записується в input
//try
//{
//    a = int.Parse(input); //Перетворюємо рядок в ціле число
//}
//catch(Exception ex)
//{
//    Console.WriteLine("У нас проблеми Хюсто {0}", ex.Message);
//    a = 0; // Присвоюємо a значення 0, якщо сталася помилка
//}

//Console.WriteLine("a = {0}", a);

//------Умовні оператори-------
// if, else if, else, switch

// Приклади запису умови - == - порівнянн,
// > - більше, < - менше, >= - більше або дорівнює,
// <= - менше або дорівнює, != - не дорівнює 

/*
int age = 0;
Console.WriteLine("Вкажіть Ваш вік:");
age = int.Parse(Console.ReadLine()); // Перетворюємо рядок в ціле число

// І та АБО - && та ||
if (age >= 23 && age < 25)
{
    Console.WriteLine("Ви уже не можете виїхати за кордом.");
    Console.WriteLine("Вас не можуть мобілізувати :)");
}
else if (age >= 25 && age < 60)
{
    Console.WriteLine("У Вас уже є Резерв +");
    Console.WriteLine("Вас можуть мобілізувати :)");
}
else if (age >= 60)
{
    Console.WriteLine("Ви можете виїхати за кордом.");
    Console.WriteLine("Вас не можуть мобілізувати :)");
}
else
{
    Console.WriteLine("Ви можете виїхати за кордом.");
    Console.WriteLine("Вас не можуть мобілізувати :)");
}
*/

//------Цикли-------
//string name = "Привіт, я - цикл for!";
//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine(name);
//}

//foreach - для перебору колекцій
//
//int[] numbers = { 23, 45, 78, 12 };
//foreach(int n in numbers)
//{
//    Console.WriteLine("item = {0}", n);
//}    

//string []names = { 
//    "Вася", "Петя", "Маша", 
//    "Оля", "Семен", "Коля", 
//    "Іван" 
//}; 
//for (int i = 0; i < names.Length; i++)
//{
//    Console.WriteLine("item = {0}", names[i]);
//}

//Динамічна колекція - збеіргає числа
List<int> items = new List<int>();
int n = 10;
int counter = 0; //Лічильни для циклу
while (counter<n)
{
    try
    {
        Console.WriteLine("Вкажіть число: ");
        int number = int.Parse(Console.ReadLine());
        items.Add(number);
        counter++;
    }
    catch (Exception ex)
    {
        Console.WriteLine("У нас проблеми Хюсто {0}", ex.Message);
        break; // Вихід з циклу, якщо сталася помилка
    }
}

Console.WriteLine("Результат:");
foreach (int number in items)
{
    Console.Write($"{number}\t");
}