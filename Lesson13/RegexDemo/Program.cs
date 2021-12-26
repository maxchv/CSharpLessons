﻿using System;
using System.Net;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Сайт для тестированя регулярок https://regex101.com/
            // Метасимвол      Споставление
            // -------------------------------------------------------
            // .               Любой символ, кроме перевода строки
            // \.              Символ точка
            // \d              Арабская цифра [0-9]
            // \w              Буква или цифра, знак _ или [a-zA-Z0-9_]
            // \s              Пробельный символ 
            // ^               Начало строки
            // $               Конец строки
            // \D              Не \d или [^0-9]
            // \W              Не \w
            // \S              Не \s
            // |               Алтьернативный вариант. Пример:  (a|b) 
            // --------------------------------------------------------
            //                         Повторители
            // --------------------------------------------------------
            // *               Повторение от 0 до ∞ раз
            // +               Повторение от 1 до ∞ раз
            // ?               Повторение от 0 до 1 раза (может быть, а может не быть)
            // {n}             Повторение n раз
            // {n, m}          Повторение от n до m раз
            // {n, }           Повторение от n до ∞ раз
            // {, m}           Повторение от 0 до m раз
            // --------------------------------------------------------
            //                         Классы символов
            // --------------------------------------------------------
            // [abc]           Или a или b или c === a|b|c
            // [a-z]           Все символы от a-z
            // [a-z0-9]        Все латинские символы в нижнем регистре и все цифры
            // [^abc]          Все символы, кроме a, b, c   

            // Извлечение данных по шаблону
            var input = "Дата отправки 31/12/2021"; // шаблон dd/dd/dddd
            const string datePattern = @"\d{1,2}(\/|-)\d{1,2}\1\d{4}";
            Match match = Regex.Match(input, datePattern);
            if(match.Success)
            {
                Console.WriteLine(match.Value);
            }

            // Найти все вхождения
            foreach(Match m in Regex.Matches("10:00 12:00 13:00", @"\d{2}:\d{2}"))
            {
                Console.WriteLine(m.Value);
            }

            // Верификация (валидация) данных
            if(Regex.IsMatch("31-12/2021", datePattern))
            {
                Console.WriteLine("Это корректная дата");
            }
            else
            {
                Console.WriteLine("Дата должна быть в корректном формате");
            }

            // Замена данных по шаблону
            // Разделение строк по шаблону

            // Загрузка данных по сети
            var client = new WebClient();
            var html = client.DownloadString("https://itstep.dp.ua");
            Console.WriteLine(html);
        }
    }
}
