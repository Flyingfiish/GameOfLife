using GameOfLife.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Settings
    {
        public bool[,] InitialField { get; }
        public string Symbol { get; }

        public int Height { get; }
        public int Width { get; }

        public Settings(bool[,] field = null, string symbol = "█")
        {
            InitialField = field ?? DefaultMap.Get();
            Symbol = symbol;

            Height = InitialField.GetLength(0);
            Width = InitialField.GetLength(1);
        }
    }
}
