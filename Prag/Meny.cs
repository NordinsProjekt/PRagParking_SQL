using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Prag
{
    //Klassen som skall hantera hela menysystemet.
    //Snyggare meny.
    class Meny
    {
        public static void Intro()
        {
            GraphicSimple b1 = new GraphicSimple("^v^",15, 5,ConsoleColor.White);
            GraphicSimple b2 = new GraphicSimple("^v^",35, 6, ConsoleColor.White);
            GraphicSimple b3 = new GraphicSimple("^v^",8, 22, ConsoleColor.White);
            GraphicText t1 = new GraphicText(Filhantering.GetStrings("ascii\\pragLogo.ascii"), 50, 2);
            GraphicSimpleText ts1 = new GraphicSimpleText("Press ENTER to continue", 75, 15);
            t1.SetFrames(1, 15);
            Console.CursorVisible = false;
            int frame = 1;
            Meny.Draw(Filhantering.GetStrings("ascii\\borg2.ascii"), 5, 2, ConsoleColor.DarkCyan);
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter))
            {
                b1.Erase(); b2.Erase(); b3.Erase();
                switch (frame)
                {
                    case 1:
                        b1.Y += 1; b2.X -= 1; b3.X += 1;
                        frame = 2;
                        break;
                    case 2:
                        b1.Y -= 1; b2.X += 1; b3.X -= 1;
                        frame = 1;
                        ts1.Draw();
                        break;
                }
                b1.Draw(); b2.Draw(); b3.Draw();
                t1.Draw();
                Thread.Sleep(250);
            }
            DefaultConsoleSettings();
        }
        public static void DefaultWindow()
        {
            Console.Clear();
            Meny.DefaultConsoleSettings();
            Meny.Draw(Filhantering.GetStrings("ascii\\borg2.ascii"), 5, 2, ConsoleColor.DarkCyan);
            Meny.Draw("^v^", 5, 15, ConsoleColor.White);
            Meny.Draw("^v^", 17, 5, ConsoleColor.White);
            Meny.Draw("^v^", 26, 4, ConsoleColor.White);
            Meny.Draw("^v^", 44, 20, ConsoleColor.White);
            Meny.Draw("^v^", 42, 8, ConsoleColor.White);
            Meny.Draw(Filhantering.GetStrings("ascii\\pragLogo.ascii"), 40, 2, ConsoleColor.DarkCyan);
        }
        public static string[] CoolMenu(string titel, string meddelande)
        {
            string[] text = {
                titel.ToString() ,
                "[1] Parkera fordon",
                "[2] Avsluta parkering",
                "[3] Hitta fordon",
                "[4] Flytta fordon",
                "[5] Lista parkeringsplatserna",
                "[6] Logga ut",
                meddelande.ToString()};              
            return text;
        }
        public static string[] RegNrMeny(string titel)
        {
            string[] text = {
                titel.ToString(),
                "Skriv in Registreringsnummer",
                "ex (ABC123)"};
            return text;
        }
        public static string[] FordonTypMeny(string titel)
        {
            string[] text = {
                titel.ToString(),
                "Vad ska du parkera?",
                "[1] Bil",
                "[2] MC",
                "?: "};
            return text;
        }
        public static string[] FlyttaFordon(string titel)
        {
            string[] text = {
                titel.ToString(),
                "Skriv in önskad plats",
                "ex (7)"};
            return text;
        }
        public static void Draw(string[] text,int x = 5, int y = 2,ConsoleColor textColor = ConsoleColor.White)
        {
            //Ritar upp all text som skickas till den.
            //Enligt en specifik standard.
            Console.ForegroundColor=textColor;
            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(text[i]);
            }
        }
        public static void Draw(string text, int x = 5, int y = 2, ConsoleColor textColor = ConsoleColor.White)
        {
            //Ritar upp all text som skickas till den.
            //Enligt en specifik standard.
            Console.ForegroundColor = textColor;

                Console.SetCursorPosition(x, y);
                Console.Write(text);
        }
        public static void Window(int width = 160,int height = 35,int border = 2,ConsoleColor fore = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.BackgroundColor = fore;
                Console.Write(" ");
                Console.SetCursorPosition(i, height);
                Console.Write(" ");
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < border; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.BackgroundColor = fore;
                    Console.Write(" ");
                    Console.SetCursorPosition(j +(width-border), i);
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(width-15, height);
            Console.BackgroundColor = fore;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Version 3.0");
            DefaultConsoleSettings();
        }

        public static void DefaultConsoleSettings()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static string AnswerFromUser(string question,ConsoleColor text,int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = text;
            Console.Write(question);
            return Console.ReadLine();
        }
    }

}
