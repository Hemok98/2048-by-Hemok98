using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class Game
    {
        private Cells[,] cellsContainer = new Cells[MAXCELLS, MAXCELLS];

        private Cells[,] copyCellsContainer = new Cells[MAXCELLS, MAXCELLS];

        public int cellsCount = 4;

        private bool canUseSkill = true;

        private bool skillActivated = false;

        private int startSkillX2Price = 1250;

        private int startSkillDeletePrice = 1000;

        private int startSkillBackPrice = 1000;

        private int skillX2Price = 0;

        private int skillDeletePrice = 0;

        private int skillBackPrice = 0;

        private int steps = 0;

        private int score = 0;

        private int record = Properties.Settings.Default.saveRecord;

        public static int MAXCELLS = 6;

        private Skills activatedSkill;

        public void RestartGame(ref int x, ref int y)
        {
            this.cellsContainer = new Cells[this.cellsCount, this.cellsCount];
            this.copyCellsContainer = new Cells[this.cellsCount, this.cellsCount];

            for (int i = 0; i < this.cellsCount; i++)
                for (int j = 0; j < this.cellsCount; j++)
                {
                    this.cellsContainer[i, j] = new Cells(0);
                    this.copyCellsContainer[i, j] = new Cells(0);
                }
            x = -1;
            y = -1;
            this.AddRandomCell(ref x, ref y);
            this.steps = 0;
            this.score = 0;
            this.skillX2Price = this.startSkillX2Price;
            this.skillDeletePrice = this.startSkillDeletePrice;
            this.skillBackPrice = this.startSkillBackPrice;
            this.skillActivated = false;

        }

        public void Move(Movement direction, ref int x, ref int y)
        {   
            if (skillActivated) return;

            Cells[,] copyCellsContainer = new Cells[this.cellsCount, this.cellsCount];
            for (int i = 0; i < this.cellsCount; i++)
            {
                for (int j = 0; j < this.cellsCount; j++)
                {
                    copyCellsContainer[i, j] = new Cells(this.cellsContainer[i, j].num);
                }
            }

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

                this.AddRandomCell(ref x, ref y);
                this.steps++;
                this.score += nowScore;
                if (this.score > this.record) this.record = this.score;
                this.canUseSkill = true;
                for (int i = 0; i < this.cellsCount; i++)
                {
                    for (int j = 0; j < this.cellsCount; j++)
                    {
                        this.copyCellsContainer[i, j].num = copyCellsContainer[i, j].num;
                    }
                }
            }
        }

        public void AddRandomCell(ref int x, ref int y)
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
            if (freeCellsCount == 0)
            {
                x = -1;
                y = -1;
                return; //если нет свободных ячеек - выходим
            }

            Random rm = new Random(); //если есть свободные ячейки - генерируем 2-ку в свободную из списка freeCells 
            int rand = rm.Next(0, freeCellsCount);
            x = freeCells[rand, 0];
            y = freeCells[rand, 1];
            this.cellsContainer[freeCells[rand, 0], freeCells[rand, 1]].num = 2;
        }

        public void Output(Button[,] displayMassive, Label stepsDisplay, Label scoreDisplay, Label recordDisplay, Label x2PriceDisplay, Label deletePriceDisplay, Label backPriceDisplay)
        {
            stepsDisplay.Text = "Ход: " + this.steps.ToString();
            scoreDisplay.Text = "Счёт: " + this.score.ToString();
            recordDisplay.Text = "Рекорд: " + this.record.ToString();
            x2PriceDisplay.Text = this.skillX2Price.ToString();
            deletePriceDisplay.Text = this.skillDeletePrice.ToString();
            backPriceDisplay.Text =  this.skillBackPrice.ToString();

            for (int i = 0; i < this.cellsCount; i++)
            {
                for (int j = 0; j < this.cellsCount; j++)
                {
                    displayMassive[i, j].Text = this.cellsContainer[i, j].num.ToString();
                    if (displayMassive[i, j].Text == "0") displayMassive[i, j].Text = "";
                    
                    if (this.cellsContainer[i, j].num == 0) displayMassive[i, j].BackColor = System.Drawing.Color.WhiteSmoke;
                    if (this.cellsContainer[i, j].num == 2) displayMassive[i, j].BackColor = System.Drawing.Color.Gainsboro;
                    if (this.cellsContainer[i, j].num == 4) displayMassive[i, j].BackColor = System.Drawing.Color.Silver;
                    if (this.cellsContainer[i, j].num == 8) displayMassive[i, j].BackColor = System.Drawing.Color.PeachPuff;
                    if (this.cellsContainer[i, j].num == 16) displayMassive[i, j].BackColor = System.Drawing.Color.DarkSalmon;
                    if (this.cellsContainer[i, j].num == 32) displayMassive[i, j].BackColor = System.Drawing.Color.Tomato;
                    if (this.cellsContainer[i, j].num == 64) displayMassive[i, j].BackColor = System.Drawing.Color.OrangeRed;
                    if (this.cellsContainer[i, j].num == 128) displayMassive[i, j].BackColor = System.Drawing.Color.LemonChiffon;
                    if (this.cellsContainer[i, j].num == 256) displayMassive[i, j].BackColor = System.Drawing.Color.Khaki;
                    if (this.cellsContainer[i, j].num == 512) displayMassive[i, j].BackColor = System.Drawing.Color.Yellow;
                    if (this.cellsContainer[i, j].num == 1024) displayMassive[i, j].BackColor = System.Drawing.Color.Gold;
                    if (this.cellsContainer[i, j].num == 2048) displayMassive[i, j].BackColor = System.Drawing.Color.Goldenrod;
                    if (this.cellsContainer[i, j].num == 4096) displayMassive[i, j].BackColor = System.Drawing.Color.Salmon;
                    if (this.cellsContainer[i, j].num == 8192) displayMassive[i, j].BackColor = System.Drawing.Color.IndianRed;
                    if (this.cellsContainer[i, j].num > 16384) displayMassive[i, j].BackColor = System.Drawing.Color.Brown;

                }
            }
            

            for (int i = 0; i < MAXCELLS; i++)
            {
                for (int j = 0; j < MAXCELLS; j++)
                {
                    displayMassive[i, j].Visible = !(i >= cellsCount || j >= cellsCount);

                }
            }
        }

        public void SelectActivatedSkill(Skills skill)
        {
            if (canUseSkill == false) return;
            if (skillActivated == true) return;

            switch (skill)
            {
                case Skills.X2:
                {
                    if (this.score >= this.skillX2Price)
                    {
                        skillActivated = true;
                        this.activatedSkill = Skills.X2;
                    }
                    break;
                } 
                
                case Skills.DELETE:
                {
                    if (this.score >= this.skillDeletePrice)
                    {
                        skillActivated = true;
                        this.activatedSkill = Skills.DELETE;
                    }
                    break;
                }

                case Skills.BACK:
                {
                    if (this.score >= this.skillBackPrice)
                    {
                        this.score -= this.skillBackPrice;
                        this.skillBackPrice *= 5;
                        this.skillBackPrice /= 4;
                            for (int i = 0; i < this.cellsCount; i++)
                            {
                                for (int j = 0; j < this.cellsCount; j++)
                                {
                                    this.cellsContainer[i, j].num = this.copyCellsContainer[i, j].num;
                                }
                            }
                    this.activatedSkill = Skills.BACK;
                    this.canUseSkill = false;
                    }
                    break;
                }
            }
        }

        public bool UseSkill(int str, int column)
        {
            if (skillActivated == false) return false;

            switch (this.activatedSkill)
            {
                case Skills.X2:
                    {
                        this.score -= this.skillX2Price;
                        this.skillX2Price *= 5;
                        this.skillX2Price /= 4;
                        this.canUseSkill = false;
                        this.cellsContainer[str, column].num += this.cellsContainer[str, column].num;
                        this.skillActivated = false;
                        break;
                    }


                case Skills.DELETE:
                    {
                        this.score -= this.skillDeletePrice;
                        this.skillX2Price *= 5;
                        this.skillX2Price /= 4;
                        this.canUseSkill = false;
                        this.cellsContainer[str, column].num -= this.cellsContainer[str, column].num;
                        this.skillActivated = false;
                        break;
                    }

                case Skills.BACK:
                    {
                        if (this.score >= this.skillBackPrice)
                        {
                            //skillActivated = true;
                            activatedSkill = Skills.BACK;
                        }
                        break;
                    }
            }

            return true;
        }

        public int GetRecord()
        {
            return this.record;
        }

        public void SetRecord(int record)
        {
            this.record = record;
            Properties.Settings.Default.saveRecord = record;
            Properties.Settings.Default.Save();

        }

        public void SaveGame(int saveNumber)
        {
            if (saveNumber == 0) return;
            string final = "";

            final += this.cellsCount.ToString() + ";";
            for (int i = 0; i < this.cellsCount; i++)
            {
                for (int j = 0; j < this.cellsCount; j++)
                {
                    final += this.cellsContainer[i, j].num.ToString() + ";";
                    final += this.copyCellsContainer[i, j].num.ToString() + ";";
                }
            }

            final += this.steps.ToString() + ";";
            final += this.score.ToString() + ";";
            final += this.canUseSkill.ToString() + ";";
            final += this.activatedSkill + ";";
            final += this.skillActivated.ToString() + ";";

            final += this.skillBackPrice.ToString() + ";";
            final += this.skillDeletePrice.ToString() + ";";
            final += this.skillX2Price.ToString() + ";";
            
            switch (saveNumber)
            {
                case 1 : Properties.Settings.Default.saveString1 = final;
                    break;
                case 2 : Properties.Settings.Default.saveString2 = final;
                    break;
                case 3 : Properties.Settings.Default.saveString3 = final;
                    break;
                case 4 : Properties.Settings.Default.saveString4 = final;
                    break;
                case 5 : Properties.Settings.Default.saveString5 = final;
                    break;
                case 6 : Properties.Settings.Default.saveString6 = final;
                    break;
                case 7 : Properties.Settings.Default.saveString7 = final;
                    break;
                case 8 : Properties.Settings.Default.saveString8 = final;
                    break;
                case 9 : Properties.Settings.Default.saveString9 = final;
                    break;
            }

            Properties.Settings.Default.Save();
        }

        public int LoadGame(int loadNumber)
        {
            string str = "";
            switch (loadNumber)
            {
                case 1 : str = Properties.Settings.Default.saveString1;
                break;

                case 2 : str = Properties.Settings.Default.saveString2;
                    break;

                case 3 : str = Properties.Settings.Default.saveString3;
                    break;

                case 4 : str = Properties.Settings.Default.saveString4;
                break;

                case 5 : str = Properties.Settings.Default.saveString5;
                break;

                case 6 : str = Properties.Settings.Default.saveString6;
                break;

                case 7 : str = Properties.Settings.Default.saveString7;
                break;

                case 8 : str = Properties.Settings.Default.saveString8;
                break;

                case 9 : str = Properties.Settings.Default.saveString9;
                break;
            }

            if (str == "") return 0;

            string parse = "";
            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.cellsCount = int.Parse(parse);
            this.cellsContainer = new Cells[this.cellsCount, this.cellsCount];
            this.copyCellsContainer = new Cells[this.cellsCount, this.cellsCount];

            for (int i = 0; i < this.cellsCount; i++)
            {
                for (int j = 0; j < this.cellsCount; j++)
                {
                    parse = str.Substring(0, str.IndexOf(";"));
                    str = str.Substring(str.IndexOf(";") + 1);
                    this.cellsContainer[i, j] = new Cells(int.Parse(parse));

                    parse = str.Substring(0, str.IndexOf(";"));
                    str = str.Substring(str.IndexOf(";") + 1);
                    this.copyCellsContainer[i, j] = new Cells(int.Parse(parse));
                }
            }

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.steps = int.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.record = int.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.canUseSkill = bool.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.activatedSkill = (Skills)Enum.Parse(typeof(Skills), parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.skillActivated = bool.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.skillBackPrice = int.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.skillDeletePrice = int.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.skillX2Price = int.Parse(parse);

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
