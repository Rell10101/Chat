﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chat
{
    public abstract class AbstractChatBot
    {
        public abstract string answer(string s);
    }

    public class ChatBotCS : AbstractChatBot
    {
        // имя пользователя
        private string username;

        // сетер для имени пользователя
        public void username_set(string user)
        {
            username = user;
        }

        // гетер для имени пользователя
        public string username_get()
        {
            return username;
        }

        public override string answer(string s)
        {
            // перевод всех символов в нижний регистр
            s = s.ToLower();
            // удаление всех пробелов в начале и конце
            s = s.Trim();

            //прив(\w *) обозначает, найти все слова, которые имеют корень "прив"
            Regex hello = new Regex(@"прив(\w*)");
            MatchCollection matchesH = hello.Matches(s);
            // если есть совпадения, написать ответ
            if (matchesH.Count > 0)
            {
                return "Привет";                                  //
            }

            Regex time = new Regex(@"врем(\w*)");
            MatchCollection matchesT = time.Matches(s);
            if (matchesT.Count > 0)
            {
                return ChatBotTime();
            }

            Regex date = new Regex(@"дат(\w*)");
            MatchCollection matchesD = date.Matches(s);
            if (matchesD.Count > 0)
            {
                return ChatBotDate();
            }

            Regex Sum = new Regex(@"прибавь(\w*)");
            MatchCollection matchesSum = Sum.Matches(s);
            if (matchesSum.Count > 0)
            {
                return Convert.ToString(ChatBotSum(s));
            }

            Regex Mult = new Regex(@"умножь(\w*)");
            MatchCollection matchesMult = Mult.Matches(s);
            if (matchesMult.Count > 0)
            {
                return Convert.ToString(ChatBotMult(s));
            }

            Regex Diff = new Regex(@"разность(\w*)");
            MatchCollection matchesDiff = Diff.Matches(s);
            if (matchesDiff.Count > 0)
            {
                return Convert.ToString(ChatBotDiff(s));
            }

            Regex Division = new Regex(@"раздели(\w*)");
            MatchCollection matchesDivision = Division.Matches(s);
            if (matchesDivision.Count > 0)
            {
                return Convert.ToString(ChatBotDivision(s));
            }

            else
            {
                return "Не знаю, что ответить";
            }
        }

        // вывод времени
        public string ChatBotTime()
        {
            return DateTime.Now.ToString("T");
        }

        // вывод даты
        private string ChatBotDate()
        {
            return DateTime.Now.ToString("D");
        }

        // сумма двух параметров
        private float ChatBotSum(string s)
        {
            // split делит строку на массив; каждое отдельное слово это элемент массива(различает слова благодаря пробелам между ними)
            string[] s_arr = s.Split();
            float x1 = float.Parse(s_arr[1]);
            float x2 = float.Parse(s_arr[3]);
            return x1 + x2;
        }

        // умножение двух параметров
        private float ChatBotMult(string s)
        {
            string[] s_arr = s.Split();
            float x1 = float.Parse(s_arr[1]);
            float x2 = float.Parse(s_arr[3]);
            return x1 * x2;
        }

        // разница двух параметров
        private float ChatBotDiff(string s)
        {
            string[] s_arr = s.Split();
            float x1 = float.Parse(s_arr[1]);
            float x2 = float.Parse(s_arr[3]);
            return x1 - x2;
        }

        // деление двух параметров
        private float ChatBotDivision(string s)
        {
            string[] s_arr = s.Split();
            float x1 = float.Parse(s_arr[1]);
            float x2 = float.Parse(s_arr[3]);
            return x1 / x2;
        }
    }
}
