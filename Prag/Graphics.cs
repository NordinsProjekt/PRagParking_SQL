using System;
using System.Collections.Generic;
using System.Text;

namespace Prag
{
    class Graphics
    {
    }
    class GraphicSimple
    {
        private string picture;
        private int x;
        private int y;
        private ConsoleColor color;
        public GraphicSimple(string picture,int x, int y,ConsoleColor color)
        {
            this.picture = picture;
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }
        public void Erase()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("   ");
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(picture);
        }
    }
    class GraphicText
    {
        private string[] art;
        private int x;
        private int y;
        private int startFrame;
        private int maxFrames;
        private int frame;

        public GraphicText(string[] art,int x,int y)
        {
            this.art = art;
            this.x = x;
            this.y = y;
        }
        public void SetFrames(int startFrame, int maxFrames)
        {
            this.maxFrames = maxFrames;
            this.startFrame = startFrame;
            frame = startFrame;
        }
        public void Draw()
        {
            if (frame >= maxFrames)
                frame = startFrame;

            Console.ForegroundColor = (ConsoleColor)frame;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < art.Length; i++)
            {
                Console.SetCursorPosition(x, y+i);
                Console.Write(art[i]);
            }
            frame++;
            
        }
    }
    class GraphicSimpleText
    {
        private string art;
        private int x;
        private int y;
        private int frame = 1;

        public GraphicSimpleText(string art, int x, int y)
        {
            this.art = art;
            this.x = x;
            this.y = y;
        }
        public void Draw()
        {
            switch(frame)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    frame++;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Black;
                    frame = 1;
                    break;
                default:
                    frame = 1;
                    break;
            }
            Console.SetCursorPosition(x, y);
            Console.Write(art);

        }
    }
}
