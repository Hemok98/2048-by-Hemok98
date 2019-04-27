using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_by_Hemok98
{
    partial class Game
    {
        private Cells[,] cellsContainer = new Cells[MAXCELLS, MAXCELLS];

        private int cellsCount = 4;

        private bool canUseSkill = true;

        private bool skillActivated = false;

        private int skillX2Price = 1250;

        private int skillDeletePrice = 1000;

        private int skillBackPrice = 1000;

        private int steps = 0;

        private int score = 0;

        private int record = 0;

        public static int MAXCELLS = 6;

        //private int skillX2Price = 1250;

        private Skills activatedSkill;

        public void SetCellsCount()
        {
            //временно
            
        }

        public void RestartGame()
        {
            this.cellsContainer = new Cells[this.cellsCount, this.cellsCount];

            for (int i = 0; i < this.cellsCount; i++)
                for (int j = 0; j < this.cellsCount; j++)
                {
                    this.cellsContainer[i, j] = new Cells(0);
                }
            this.addRandomCell();
            this.steps = 0;
            this.score = 0;
            this.skillX2Price = 1250;
            this.skillDeletePrice = 1000;
            this.skillBackPrice = 1000;

        }

        public void Move(Movement direction)
        {
            if (skillActivated) return;

            int mainIndex = 0;
            int vertical = 0;
            int moves = 0;
            int nowScore = 0;
            switch(direction)
            { 
                case Movement.RIGHT: //movelogic
                {
                    vertical = 0;
                    mainIndex = 0;
                    break;
                }

                case Movement.LEFT: //movelogic
                {
                    vertical = 0;
                    mainIndex = 1;
                    break;
                }

                case Movement.UP: //movelogic
                {                  
                    vertical = 1;
                    mainIndex = 1;
                    break;
                }

                case Movement.DOWN: //movelogic
                {
                    vertical = 1;
                    mainIndex = 0;
                    break;
                }
            }

            for (int repeatCount = 0; repeatCount < cellsCount; repeatCount++)
            {
                for (int i = cellsCount - 2; i >= 0; i--)
                {
                    Cells mainCell = cellsContainer[repeatCount * (1 - vertical) + vertical * Math.Abs((this.cellsCount - 1) * mainIndex - i),
                                                    (1 - vertical) * Math.Abs((this.cellsCount-1) * mainIndex - i) + vertical * repeatCount];
                    if (mainCell.num == 0) continue;
                    for (int j = i + 1; j < cellsCount; j++)
                    {
                        Cells second = cellsContainer[repeatCount * (1 - vertical) + vertical * Math.Abs((this.cellsCount - 1) * mainIndex - j) ,
                                                     Math.Abs((this.cellsCount - 1) * mainIndex - j) * (1 - vertical) + vertical * repeatCount ];
                        if (second.num == 0)
                        {
                            int num = mainCell.num;
                            bool changed = mainCell.changed;
                            mainCell.num = second.num;
                            mainCell.changed = second.changed;
                            second.num = num;
                            second.changed = changed;
                            mainCell = second;
                            moves++;
                            continue;
                        }
                        else if (second.changed == false && mainCell.changed == false)
                        {
                            if (second.num == mainCell.num)
                            {
                                nowScore += second.num;
                                second.num += second.num;
                                mainCell.num = 0;
                                second.changed = true;
                                moves++;
                            }
                        }
                        break;
                    }
                }
            }

            for (int i = 0; i < this.cellsCount; i++)
                        for (int j = 0; j < this.cellsCount; j++)
                            this.cellsContainer[i, j].changed = false;
            if (moves > 0)
            {
                this.addRandomCell();
                this.steps++;
                this.score += nowScore;
                if (this.score > this.record) this.record = this.score;
                this.canUseSkill = true;
            }
        }

        //object.skills.x2()
        public void UseSkill(Skills skill)
        {
            switch (skill)
            {
                case Skills.X2: cellsCount = 5;
                    break; 
            }
                
        }

        public void addRandomCell()
        {
            int freeCellsCount = 0; //хранит кол-во свободных ячеек
            int[,] freeCells = new int[cellsCount* cellsCount, 2]; //хранит адреса свободных ячеек

            for (int i = 0; i < this.cellsCount; i++) //поиск свободных ячеек
                for (int j = 0; j < this.cellsCount; j++)
                {
                    if (cellsContainer[i,j].num == 0)
                    {
                        freeCells[freeCellsCount, 0] = i;
                        freeCells[freeCellsCount, 1] = j;
                        freeCellsCount++;
                    }
                }
            if (freeCellsCount == 0) return; //если нет свободных ячеек - выходим

            Random rm = new Random(); //если есть свободные ячейки - генерируем 2-ку в свободную из списка freeCells 
            int rand = rm.Next(0, freeCellsCount);
            this.cellsContainer[freeCells[rand, 0], freeCells[rand, 1]].num = 2;
        }

        public int output(System.Windows.Forms.Button[,] displayMassive, System.Windows.Forms.Label stepsDisplay, System.Windows.Forms.Label scoreDisplay, System.Windows.Forms.Label recordDisplay)
        {
            stepsDisplay.Text = "Ход: " + this.steps.ToString();
            scoreDisplay.Text = "Счёт: " + this.score.ToString();
            recordDisplay.Text = "Рекорд: " + this.record.ToString();

            for (int i = 0; i < this.cellsCount; i++)
            {
                for (int j = 0; j < this.cellsCount; j++)
                {
                    displayMassive[j, i].Text = this.cellsContainer[i, j].num.ToString();
                }
            }
            

            for (int i = 0; i < MAXCELLS; i++)
            {
                for (int j = 0; j < MAXCELLS; j++)
                {
                    if (i >= cellsCount || j >= cellsCount) displayMassive[i, j].Visible = false;
                }
            }

            return this.cellsCount;
        }

    }
     

    enum Skills
    {
        X2,DELETE,BACK
    }

    enum Movement
    {
        RIGHT,LEFT,UP,DOWN
    }
}
