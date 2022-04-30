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

        private readonly IMap _map;

        public Settings(IMap map = null, string symbol = "█")
        {
            _map = map ?? new DefaultMap();

            InitialField = _map.Get();
            Symbol = symbol;

            Height = InitialField.GetLength(0);
            Width = InitialField.GetLength(1);
        }
    }
}
