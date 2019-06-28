using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _2048_by_Hemok98
{
    [Serializable]
    partial class Game
    {
        private Cells[,] cellsContainer = new Cells[MAXCELLS, MAXCELLS]; //массив который хранит основное поле игры

        private Cells[,] copyCellsContainer = new Cells[MAXCELLS, MAXCELLS]; //массив который хранит предыдущий ход(нужен для скила "ход назад")
        //тип данных Cells описан в файле Cells.cs в этой же папке

        public int cellsCount = 4; //хранит текущее кол-во ячеек

        private Skill[] skills;

        private int[] swapCords = new int[2] { -1, -1};

        private int steps = 0; //счётчик ходов
        private int score = 0; //хранит текущий счёт
        private int record = Properties.Settings.Default.saveRecord; //хранит рекорд, подсасывая его из настроек

        public static int MAXCELLS = 6; //хранит максимальное колличество ячеек(возможно ненужна)

        public Game()
        {
            //skills init
            this.skills = new Skill[Skill.skillCount];
            this.skills[0] = new Skill(1250, SkillName.X2);
            this.skills[1] = new Skill(1000, SkillName.DELETE);
            this.skills[2] = new Skill(1000, SkillName.BACK);
            this.skills[3] = new Skill(500, SkillName.SWAP);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }     

    public void RestartGame() //перезапуск игры
        {
            this.cellsContainer = new Cells[this.cellsCount, this.cellsCount];
            this.copyCellsContainer = new Cells[this.cellsCount, this.cellsCount];

            for (int i = 0; i < this.cellsCount; i++)
                for (int j = 0; j < this.cellsCount; j++)
                {
                    this.cellsContainer[i, j] = new Cells(0);
                    this.copyCellsContainer[i, j] = new Cells(0);
                }
            //обнуляем массив поля
            int x = -1;
            int y = -1;
            //будут хранить координаты зарандомленных ячеек, нужны чтоб просто передать что-то в функцию добавления новой ячейки, т.к. лень писать для неё перегрузку без параметров

            this.AddRandomCell(ref x, ref y);
            this.AddRandomCell(ref x, ref y);
            //рандомим ячейки и записываем в х и у их координаты

            this.steps = 0; //обнуляем счётчик ходов
            this.score = 0; //обнуляем счёт
            for (int i = 0; i < Skill.skillCount; i++)
            {
                this.skills[i].ResetPrice();
            }
            Skill.skillActivated = false; //переводим в положение пока нельзя использовать скилы

        }

        public void Move(Movement direction, ref int x, ref int y) //главная игровая механика движения ячеек взависимости от направления.
        //сюда пересылаем направление и ссылки на координаты, куда запишим координаты новой сгенерированой ячейки(2)
        {   
            if (Skill.skillActivated) return; //если скил был активирован, то не исполняем

            Cells[,] copyCellsContainer = new Cells[this.cellsCount, this.cellsCount]; //создаём промежуточный массив и копируем в него текущий
            for (int i = 0; i < this.cellsCount; i++)
            {
                for (int j = 0; j < this.cellsCount; j++)
                {
                    copyCellsContainer[i, j] = new Cells(this.cellsContainer[i, j].num);
                }
            }

            int mainIndex = 0; //отвечает за направление движения при работе алгроритма
            int vertical = 0; //отвечает за направление движения при работе алгроритма
            int moves = 0; //считает кол-во каких либо действий при работе алгоритма, нужен для отслеживания холостого срабатывания, когда ничего не произошло
            int nowScore = 0; //считает сколько нужно будет прибавить к текущему счёту по окончанию хода

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

            for (int repeatCount = 0; repeatCount < cellsCount; repeatCount++) //само движение, это сложно объяснить. Это тупо нужно понять либо принять
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
            //переводим поле изменения в состояние можно работать(своебразное зануление, нужно чтоб алгоритм корректно отработал на следующем ходу)

            if (moves > 0) //проверяем сработал ли алгорит в холостую
            {   

                this.AddRandomCell(ref x, ref y); //добавляем новую ячейку
                this.steps++; //увеличиваем шаги
                this.score += nowScore; //увиличиваем счёт
                if (this.score > this.record) this.record = this.score; //проверяем стал ли счёт больше рекорда
                //вообще тут надо бы его сохранять в настройки на всякий так, что
                //fix me

                Skill.canUseSkill = true; //ход походили, скилы можно использовать

                for (int i = 0; i < this.cellsCount; i++)
                {
                    for (int j = 0; j < this.cellsCount; j++)
                    {
                        this.copyCellsContainer[i, j].num = copyCellsContainer[i, j].num;
                    }
                } //т.к. ход походили то сохраняем в предыдущей ход, массив который мы откопировали перед началом текущего хода
            }
            //fix me нужно добавить проверку на проигрыш
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
                        freeCellsCount++; //записываем в массив адреса свободных ячеек
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
            y = freeCells[rand, 0];
            x = freeCells[rand, 1];
            this.cellsContainer[freeCells[rand, 0], freeCells[rand, 1]].num = 2;
        }

        public void Output(string[,] cellsStr, Color[,] cellsCol, ref string stepsStr, ref string scoreStr, ref string recordStr, string[] skillsPrice)
        {
            //надо переделать передачу с массива кнопок, лейблов на массив интов, цветов и строк
            //fix me
            stepsStr = "Ход: " + this.steps.ToString();
            scoreStr = "Счёт: " + this.score.ToString();
            recordStr = "Рекорд: " + this.record.ToString();
            for (int i = 0; i < Skill.skillCount; i++ )
            {
                skillsPrice[i] = this.skills[i].GetPrice().ToString();
            }

            //в переданные поля передаём значения игры

            //передаём значения ячеек и задаём для них нужный цвет
            for (int i = 0; i < this.cellsCount; i++)
            {
                for (int j = 0; j < this.cellsCount; j++)
                {
                    cellsStr[i, j] = this.cellsContainer[i, j].num.ToString();
                    if (this.cellsContainer[i, j].num == 0) cellsStr[i, j] = "";
                    
                    if (this.cellsContainer[i, j].num == 0) cellsCol[i,j] = Color.WhiteSmoke;
                    if (this.cellsContainer[i, j].num == 2) cellsCol[i,j] = Color.Gainsboro;
                    if (this.cellsContainer[i, j].num == 4) cellsCol[i,j] = Color.Silver;
                    if (this.cellsContainer[i, j].num == 8) cellsCol[i,j] = Color.PeachPuff;
                    if (this.cellsContainer[i, j].num == 16) cellsCol[i,j] = Color.DarkSalmon;
                    if (this.cellsContainer[i, j].num == 32) cellsCol[i,j] = Color.Tomato;
                    if (this.cellsContainer[i, j].num == 64) cellsCol[i,j] = Color.OrangeRed;
                    if (this.cellsContainer[i, j].num == 128) cellsCol[i,j] = Color.LemonChiffon;
                    if (this.cellsContainer[i, j].num == 256) cellsCol[i,j] = Color.Khaki;
                    if (this.cellsContainer[i, j].num == 512) cellsCol[i,j] = Color.Yellow;
                    if (this.cellsContainer[i, j].num == 1024) cellsCol[i,j] = Color.Gold;
                    if (this.cellsContainer[i, j].num == 2048) cellsCol[i,j] = Color.Goldenrod;
                    if (this.cellsContainer[i, j].num == 4096) cellsCol[i,j] = Color.Salmon;
                    if (this.cellsContainer[i, j].num == 8192) cellsCol[i,j] = Color.IndianRed;
                    if (this.cellsContainer[i, j].num > 16384) cellsCol[i,j] = Color.Brown;
                }
            }
        }

        public void SelectActivatedSkill(SkillName skill) //обрабатывает активацию скилов
        {
            if (Skill.canUseSkill == false) return;
            if (Skill.skillActivated == true) return;
            //если скил не может быть активирован или уже активирован, то выходим

            //проверяем для каждого скила может ли он быть активирован(хватает ли очков), если хватило то переводим программу в ожидания нажатия по ячейки(кроме хода назад, он тут же обрабатывается)
            int num = (int)skill;
            switch (skill)
            {
                case SkillName.X2:
                {
                    if (this.score >= this.skills[num].GetPrice())
                    {
                        Skill.skillActivated = true;
                        Skill.activatedSkill = SkillName.X2;
                    }
                    break;
                } 
                
                case SkillName.DELETE:
                {
                    if (this.score >= this.skills[num].GetPrice())
                    {
                        Skill.skillActivated = true;
                        Skill.activatedSkill = SkillName.DELETE;
                    }
                    break;
                }

                case SkillName.BACK:
                {
                    if (this.score >= this.skills[num].GetPrice()) //проверяем цену
                    {

                        this.score -= this.skills[num].GetPrice();
                        this.skills[num].IncPrice();
                        Skill.SkillEnd();
                        //увеличиваем цену на 25%
                        for (int i = 0; i < this.cellsCount; i++)
                        {
                            for (int j = 0; j < this.cellsCount; j++)
                            {
                                this.cellsContainer[i, j].num = this.copyCellsContainer[i, j].num;
                            }
                        }//копируем массив из предыдущего хода в текущий
                    }
                    break;
                }

                case SkillName.SWAP:
                {
                    if (this.score >= this.skills[num].GetPrice())
                    {
                        Skill.skillActivated = true;
                        Skill.activatedSkill = SkillName.SWAP;
                    }
                    break;
                }
            }
        }

        public bool UseSkill(int str, int column) //обработка самих скилов, сюда пересылаются координаты нажатой ячейки, по которой использовали скил
        {
            if (Skill.skillActivated == false) return false;
            //проверяем был ли вообще использован скил, если нет, то выкидываем
            int num = (int)Skill.activatedSkill;

            switch (Skill.activatedSkill)
            {
                case SkillName.X2:
                {
                    //тоже самое как в ходе назад, только удваиваем нужную нам ячейку и ве
                    this.score -= this.skills[num].GetPrice();
                    this.skills[num].IncPrice();
                    Skill.SkillEnd();
                    this.cellsContainer[str, column].num += this.cellsContainer[str, column].num;
                    break;
                }


                case SkillName.DELETE:
                {
                    this.score -= this.skills[num].GetPrice();
                    this.skills[num].IncPrice();
                    Skill.SkillEnd();

                    this.cellsContainer[str, column].num -= this.cellsContainer[str, column].num;
                        
                    break;
                }

                case SkillName.BACK: //вообще ненужная фигня и думаю её надо бы удалить, но пусть пока живёт
                {
                   
                    break;
                }

                case SkillName.SWAP:
                {
                    if (this.swapCords[0] == -1)
                    {
                        this.swapCords[0] = str;
                        this.swapCords[1] = column;
                    } else
                    {
                        if ( (this.swapCords[0] != str) || (this.swapCords[1] != column))
                        {
                            int vspomog = this.cellsContainer[this.swapCords[0], this.swapCords[1]].num;
                            this.cellsContainer[this.swapCords[0], this.swapCords[1]].num = this.cellsContainer[str, column].num;
                            this.cellsContainer[str, column].num = vspomog;

                            this.score -= this.skills[num].GetPrice();
                            this.skills[num].IncPrice();
                            Skill.SkillEnd();
                            this.swapCords[0] = -1;
                            this.swapCords[1] = -1;
                        }
                    }
                    break;
                }
            }

            return true;
        }

        public int GetRecord() //возвращает текущий рекорд
        {
            return this.record;
        }

        public void SetRecord(int record) //задаёт текущий рекорд. Пока используется для его обнуления
        {
            this.record = record;
            Properties.Settings.Default.saveRecord = record;
            Properties.Settings.Default.Save();

        }

    }  

    enum Movement //перечисление : стороны движения
    {
        RIGHT,LEFT,UP,DOWN
    }
}
