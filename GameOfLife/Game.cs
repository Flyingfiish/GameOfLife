using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Game
    {
        private readonly StateRenderer _stateRenderer;
        private readonly Settings _settings;
        private bool[,] _state;

        public Game(Settings settings)
        {
            _settings = settings;
            _stateRenderer = new StateRenderer(_settings.Height, _settings.Width, _settings.Symbol);

            _state = _settings.InitialField;
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(100);
                _state = GetNewState();
                Render();
            }
        }

        private bool[,] GetNewState()
        {
            bool[,] newState = new bool[_settings.Height, _settings.Width];

            for (int i = 0; i < _settings.Height; i++)
            {
                for (int j = 0; j < _settings.Width; j++)
                {
                    int sum = GetSumActiveAroundPoint(i, j);
                    if (sum == 3)
                        newState[i, j] = true;
                    else if ((sum == 2 || sum == 3) && _state[i, j] == true)
                        newState[i, j] = true;
                }
            }
            return newState;
        }

        private int GetSumActiveAroundPoint(int i, int j)
        {
            int sum = 0;
            var coords = GetCoordinatesAroundPoint(i, j);

            foreach (var coord in coords)
                sum += _state[coord.Item1, coord.Item2] ? 1 : 0;

            return sum;
        }

        private List<(int, int)> GetCoordinatesAroundPoint(int i, int j)
        {
            var result = new List<(int, int)>();

            if (i > 0)
                result.Add((i - 1, j));
            if (i > 0 && j > 0)
                result.Add((i - 1, j - 1));
            if (i > 0 && j < _settings.Width - 1)
                result.Add((i - 1, j + 1));

            if (i < _settings.Height - 1)
                result.Add((i + 1, j));
            if (i < _settings.Height - 1 && j > 0)
                result.Add((i + 1, j - 1));
            if (i < _settings.Height - 1 && j < _settings.Width - 1)
                result.Add((i + 1, j + 1));

            if (j > 0)
                result.Add((i, j - 1));
            if (j < _settings.Width - 1)
                result.Add((i, j + 1));

            if (i == 0)
                result.Add((_settings.Height - 1, j));
            if (i == 0 &&
                j == 0)
                result.Add((_settings.Height - 1, _settings.Width - 1));
            if (i == 0 &&
                j == _settings.Width - 1)
                result.Add((_settings.Height - 1, 0));

            if (i == _settings.Height - 1)
                result.Add((0, j));
            if (i == _settings.Height - 1 &&
                j == 0)
                result.Add((0, _settings.Width - 1));
            if (i == _settings.Height - 1 &&
                j == _settings.Width - 1)
                result.Add((0, 0));

            if (j == 0)
                result.Add((i, _settings.Width - 1));
            if (j == _settings.Width - 1)
                result.Add((i, 0));

            return result;
        }

        private void Render()
        {
            _stateRenderer.Render(_state);
        }
    }
}
