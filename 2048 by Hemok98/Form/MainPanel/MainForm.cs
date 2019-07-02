using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _2048_by_Hemok98
{
    public partial class MainForm : Form
    {
        private bool showNew = false; //переменная отвечающая за отображение новых ячеек

        private bool canUseKeys = true; //отвечает за возможность управлять игрой через WASD

        private int displayCellsCount = 4; //хранит кол-во ячеек поля

        private int selectedPanel = 0; //хранит номер использованной панельки

        private Achievements achiveManager;
        public MainForm() //конструктор класса новой формы, то что запустится при её создании
        {
            //ClearSavesAchievs();
            //Properties.Settings.Default.achievsContainer = "";
            //инициализация объектов на форме
            this.InitForm();
            this.PagesInit();
            //старт игры
            this.game.RestartGame();
            this.DisplayShow();

            this.achiveManager = new Achievements();
            if (Properties.Settings.Default.achievsContainer.Length != 0)
                this.achiveManager.LoadAchivements(Properties.Settings.Default.achievsContainer);
            
            this.game.SetAchivRef(this.achiveManager);
        }

        private Game game = new Game(); //сама игра по факту

        private void MoveButtonClick(object sender, EventArgs e) //функция обработки нажатия на клавиши управления
        {
            int x = -1, y = -1;
            Button pressedButton = (Button)sender; //смотрим какая клавиша была нажата

            switch (pressedButton.Name) //выполняем движение
            {
                case "rightButton":
                {
                    this.game.Move(Movement.RIGHT, ref x, ref y);
                    break;
                }

                case "leftButton":
                {
                    this.game.Move(Movement.LEFT, ref x, ref y);
                    break;
                }

                case "upButton":
                {
                    this.game.Move(Movement.UP, ref x, ref y);
                    break;
                }

                case "downButton":
                {
                    this.game.Move(Movement.DOWN, ref x, ref y);
                    break;
                }
            }

            if (x != -1) //если оно выполнено, то выводим поле и всё остальное
            {
                this.DisplayShow();
                this.ShowNewCell(x, y);
                if (this.game.CheckLose()) MessageBox.Show("Вы проиграли! :(", "2048");
            }
            
        }
        
        private void DisplayShow()
        {
            string[,] cellsStr = new string[this.displayCellsCount, this.displayCellsCount];
            Color[,] cellsColor = new Color[this.displayCellsCount, this.displayCellsCount];
            string steps = "", score = "", record = "";
            string[] skillsPrice = new string[Skill.skillCount];
            this.game.Output(cellsStr, cellsColor, ref steps, ref score, ref record, skillsPrice);

            for (int i = 0; i < this.displayCellsCount; i++)
            {
                for (int j = 0; j < this.displayCellsCount; j++)
                {
                    this.cellsDispay[i, j].Text = cellsStr[i, j];
                    this.cellsDispay[i, j].BackColor = cellsColor[i, j];
                    this.cellsDispay[i, j].MainColor = cellsColor[i, j];
                }
            }

            this.stepDisplay.Text = steps;
            this.scoreDisplay.Text = score;
            this.recordDisplay.Text = record;
            this.x2PriceDisplay.Text = skillsPrice[0];
            this.deletePriceDisplay.Text = skillsPrice[1];
            this.backPriceDisplay.Text = skillsPrice[2];
            this.swapPriceDisplay.Text = skillsPrice[3];
        }

        private void RestartButtonClick(object sender, EventArgs e) //перезапуск игры
        {
            this.game.RestartGame();
            this.DisplayShow();
        }

        private async void CellsDisplayClick(object sender, EventArgs e) //обработка нажатия по игровому полю
        {
            TButton cell = (TButton)sender;
            int indexX = int.Parse(cell.Name[0] + "");
            int indexY = int.Parse(cell.Name[1] + "");
            
            if ( this.game.UseSkill(indexX,indexY) ) //смотрим смогли мы использовать скил по этому полю
            {
                await Task.Run(() => ChangeButtonColor(cell, System.Drawing.Color.Green)); //в паралельном потоке меняем цвет нажатой ячейки на зелёный
                this.DisplayShow(); //выводим
            }
            else
            {
                await Task.Run(() => ChangeButtonColor(cell, System.Drawing.Color.Red)); //т.к. скил не выполнился, то в паралельном потоке меняем цвет на красный
            }
        }

        private void ChangeButtonColor(TButton cell, System.Drawing.Color color) //меняет цвет ячейки на заданный, а потом возвращает его обратно
        {
            cell.BackColor = color;
            Thread.Sleep(200);
            //cell.BackColor = System.Drawing.Color.WhiteSmoke;
            cell.BackColor = cell.MainColor;
        }

        private async void ShowNewCell(int x, int y) //показывает новую появившуюся ячейку
        {
            if (this.showNew) await Task.Run(() => ChangeButtonColor(this.cellsDispay[y,x], System.Drawing.Color.LightBlue));
        }

        private void X2ButtonClick(object sender, EventArgs e) //нажатие по Х2
        {
            this.game.SelectActivatedSkill(SkillName.X2);
            //this.textBox1.Text += this.game.skillActivated.ToString();
        }

        private void DeleteButtonClick(object sender, EventArgs e) //нажатие по обнулению
        {
            this.game.SelectActivatedSkill(SkillName.DELETE);
        }

        private void BackButtonClick(object sender, EventArgs e) //нажатие по ходу назад
        {
            this.game.SelectActivatedSkill(SkillName.BACK);
            this.DisplayShow();
        }

        private void SwapButtonClick(object sender, EventArgs e) //нажатие по обнулению
        {
            this.game.SelectActivatedSkill(SkillName.SWAP);
        }

        private void ChangeShowNewCells(object sender, EventArgs e) //переключать показа ячеек
        {
            this.showNew = !this.showNew;
        }


        private void KeyPressed (object sender, KeyEventArgs e) //обработка нажатий клавиш клавиатуры
        {
            if (!canUseKeys) return;
            //проверка на использование клавиш

            bool beenUsed = false;
            int x = -1, y = -1;
            switch (e.KeyData) //смотрим  какая клавиша была нажата
            {
                case Keys.W:
                {
                    beenUsed = true;
                    this.game.Move(Movement.UP, ref x, ref y);                  
                    break;
                }

                case Keys.S:
                {
                    beenUsed = true;
                    this.game.Move(Movement.DOWN, ref x, ref y);
                    break;
                }

                case Keys.A:
                {
                    beenUsed = true;
                    this.game.Move(Movement.LEFT, ref x, ref y);
                    break;
                }

                case Keys.D:
                {
                    beenUsed = true;
                    this.game.Move(Movement.RIGHT, ref x, ref y);
                    break;
                }
            }

            if (x != -1 && beenUsed) //если была нажата нужная клавиша и что-либо исполнилось, то выводим и отображаем новую
            {
                this.DisplayShow();
                this.ShowNewCell(x, y);
                if (this.game.CheckLose()) MessageBox.Show("Вы проиграли! :(", "2048");
            }

        }

        private void Form1Closed(object sender, FormClosedEventArgs e) //обработка закрытия формы(программы в целом)
        {
            Properties.Settings.Default.saveRecord = this.game.GetRecord(); //сохраняем рекорд в настройки
            Properties.Settings.Default.achievsContainer = this.achiveManager.SaveGame();
            Properties.Settings.Default.Save(); //сохраняем настройки
        }

        private void GoToPage(object sender, EventArgs e)
        {
            Button pressedButton = (Button)sender;
            int num = -1;
            if (pressedButton.Name == "goToMainPanelButton") num = 0;
            if (pressedButton.Name == "goToOptionsPanelButton") num = 1;
            if (pressedButton.Name == "goToSavePanelButton") num = 2;
            if (pressedButton.Name == "goToLoadPanelButton") num = 3;
            if (pressedButton.Name == "goToAchivesPanelButton") num = 4;

            if (this.selectedPanel == num) return;

            if (num == 1) this.SetDisplayOption();
            if (num == 2) { this.selectedSave = 0; this.ClearForUsingSaves(); }
            if (num == 3) this.ClearForUsingLoad();
            if (num == 4) this.DisplayAchivements();

            this.pages[selectedPanel].Visible = false;
            this.pages[num].Visible = true;
            this.selectedPanel = num;
        }

        private void ClearSavesAchievs()
        {
            Properties.Settings.Default.achievsContainer = "";
            Properties.Settings.Default.saveStr1 = "";
            Properties.Settings.Default.saveStr2 = "";
            Properties.Settings.Default.saveStr3 = "";
            Properties.Settings.Default.saveStr4 = "";
            Properties.Settings.Default.saveStr5 = "";
            Properties.Settings.Default.saveStr6 = "";
            Properties.Settings.Default.saveStr7 = "";
            Properties.Settings.Default.saveStr8 = "";
            Properties.Settings.Default.saveStr9 = "";
            Properties.Settings.Default.Save();
        }
    }
}
