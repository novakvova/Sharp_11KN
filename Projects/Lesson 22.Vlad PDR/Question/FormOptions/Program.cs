using System;
using System.IO;
using System.Text.Json;
using WinFormsApp1;
using FormOptions;

namespace FormOptions
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Перевіряємо, чи користувач уже залогінений
            if (File.Exists("auth.bin"))
            {
                try
                {
                    // Користувач уже залогінений, відкриваємо главне меню
                    Application.Run(new MainForm());
                }
                catch
                {
                    // Якщо помилка, видаляємо файл сесії та стартуємо з реєстрації
                    File.Delete("auth.bin");
                    Application.Run(new ChooseThemeForm());
                }
            }
            else
            {
                // Користувач не залогінений, показуємо форму вибору теми
                Application.Run(new ChooseThemeForm());
            }
        }
    }
}