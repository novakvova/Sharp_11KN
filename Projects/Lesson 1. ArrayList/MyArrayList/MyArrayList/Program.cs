// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Робота з ArrayList Collection");

///ArrayList - це обєкт, який може зберігати
///різні типи даних. Використовується для масивів
///Можна додавати елементи динамічно
///Динімачно значить у процесі виконання програми.
//Він зберігає тип даних object
//char ch = 'Х';
/*
object myObject = 'x'; // може зібарігати будь-який тип даних
//var type = typeof();
ArrayList myArray = new ArrayList();
//Додати новий елемент у список
myArray.Add(12); //масиві появився новий елемент 12
myArray.Add("Ковбаса");
myArray.Add(false);

foreach(var item in myArray)
{
    Console.Write($"{item}\t");
}
*/

var marks = new ArrayList(); //Будь, який тип даних, який з права
//вічник цикл
while(marks.Count != 10) // максимальна кількість оцінок 10
{
    Console.WriteLine("Вкажіть вашу оцінку:");
    var mark = Console.ReadLine();
    if (mark == "")
        break;
    marks.Add(mark);
}

Console.WriteLine("Наш масив:");
int n = marks.Count;
for(int i=0; i<n; i++)
{
    Console.Write($"{marks[i]}\t");
}

foreach(var item in marks)
{
    try
    {
        int mark = Convert.ToInt32(item);
        //ніяких змін у масиві не буде
    } 
    catch
    {
        Console.WriteLine($"У нас попалося не число: {item}");
        marks.Remove(item); // Видаляю елемент із масиву
    }
}


