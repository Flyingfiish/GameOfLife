using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class StateRenderer
    {
        private readonly int _height;
        private readonly int _width;
        private readonly string _symbol;

        public StateRenderer(int height, int width, string symbol)
        {
            _height = height;
            _width = width;
            _symbol = symbol;

            Console.CursorVisible = false;
            Console.SetWindowSize(_width, _height);
            Console.SetBufferSize(_width, _height);
        }

        public void Render(bool[,] state)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    sb.Append(state[i, j] ? _symbol : " ");
                }
                sb.Append("\n");
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());
        }
    }
}
