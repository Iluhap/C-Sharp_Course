using System;


//  Программа принимает строку. 
//  По нажатию произвольной клавиши поочередно выделяет в тексте заданное слово (заданное слово вводится с клавиатуры);
//  Ищет в ней глаголы и возвращает в консоль строку без глаголов.
//  Для выполнения задания создать массив строк и проинициализировать его несколькими окончаниями, которые есть у глаголов, например, “ать”, “ять” и т.д. Слово из входной строки соответствует глаголу, если оно содержит одно из этих окончаний.
//  Найти во входной строке слова с одинаковым основанием (совпадающие части двух и более слов, 3 буквы и более) и разбить эти слова на 3 части
//  – префикс, то что стоит до основания слева,
//  – основа, то что совпадает с частью другого слова,
//  – окончание.
//  Обратите внимание, что некоторые из этих 1,3 частей могут отсутствовать.

namespace TaskA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TaskA");
        }
    }
}
