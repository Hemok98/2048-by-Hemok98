using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_by_Hemok98
{
    [Serializable]
    class Achivements
    {
        public static int achivCount = 17;
        private bool[] achivContainer = new bool[achivCount];

        public Achivements()
        {
            for (int i = 0; i < achivCount; i++)
            {
                this.achivContainer[i] = false;
            }
        }

        public void ChekGame(Game game)
        {
            int record = 0, steps = 0, score = 0;
            int[,] cells = new int[game.cellsCount, game.cellsCount];
            game.GetGame(cells, ref record, ref score, ref steps);

            for (int i  = 0; i < game.cellsCount; i++)
            {
                for (int j = 0; j < game.cellsCount; j++)
                {
                    this.achivContainer[0] = this.achivContainer[0] || (cells[i, j] == 256);
                    this.achivContainer[1] = this.achivContainer[1] || (cells[i, j] == 512);
                    this.achivContainer[2] = this.achivContainer[2] || (cells[i, j] == 1024);
                    this.achivContainer[3] = this.achivContainer[3] || (cells[i, j] == 2048);
                    this.achivContainer[4] = this.achivContainer[4] || (cells[i, j] == 4096);
                }
            }

            this.achivContainer[5] = this.achivContainer[5] || (record > 1000);
            this.achivContainer[6] = this.achivContainer[6] || (record > 5000);
            this.achivContainer[7] = this.achivContainer[7] || (record > 10000);
            this.achivContainer[8] = this.achivContainer[8] || (record > 50000);
        }
    }
}
