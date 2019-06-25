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

        private int selectedPanel = 1; //хранит номер использованной панельки

        public MainForm() //конструктор класса новой формы, то что запустится при её создании
        {
            //инициализация объектов на форме
            this.InitializeComponent();
            this.MyInitializeComponent();
            this.InitializeOptionsPanel();
            this.IntitializeSavesPanel();
            this.SetDisplayOption();
            this.IntitializeLoadPanel();

            /*
            Properties.Settings.Default.saveString1 = "";
            Properties.Settings.Default.saveString2 = "";
            Properties.Settings.Default.saveString3 = "";
            Properties.Settings.Default.saveString4 = "";
            Properties.Settings.Default.saveString5 = "";
            Properties.Settings.Default.saveString6 = "";
            Properties.Settings.Default.saveString7 = "";
            Properties.Settings.Default.saveString8 = "";
            Properties.Settings.Default.saveString9 = "";
            */

            //старт игры
            this.game.RestartGame();
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);


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
                this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay, this.backPriceDisplay);
                this.ShowNewCell(x, y);
                
            }
            
        }

        private void RestartButtonClick(object sender, EventArgs e) //перезапуск игры
        {
            this.game.RestartGame();
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay, this.backPriceDisplay);
        }

        private async void CellsDisplayClick(object sender, EventArgs e) //обработка нажатия по игровому полю
        {
            TButton cell = (TButton)sender;
            int indexX = int.Parse(cell.Name[0] + "");
            int indexY = int.Parse(cell.Name[1] + "");
            
            if ( this.game.UseSkill(indexX,indexY) ) //смотрим смогли мы использовать скил по этому полю
            {
                await Task.Run(() => ChangeButtonColor(cell, System.Drawing.Color.Green)); //в паралельном потоке меняем цвет нажатой ячейки на зелёный
                this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay); //выводим
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
            cell.BackColor = cell.mainColor;
        }

        private async void ShowNewCell(int x, int y) //показывает новую появившуюся ячейку
        {
            if (this.showNew) await Task.Run(() => ChangeButtonColor(this.cellsDispay[y,x], System.Drawing.Color.LightBlue));
        }

        private void X2ButtonClick(object sender, EventArgs e) //нажатие по Х2
        {
            this.game.SelectActivatedSkill(Skills.X2);
            //this.textBox1.Text += this.game.skillActivated.ToString();
        }

        private void DeleteButtonClick(object sender, EventArgs e) //нажатие по обнулению
        {
            this.game.SelectActivatedSkill(Skills.DELETE);
        }

        private void BackButtonClick(object sender, EventArgs e) //нажатие по ходу назад
        {
            this.game.SelectActivatedSkill(Skills.BACK);
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
        }

        private void ChangeShowNewCells(object sender, EventArgs e) //переключать показа ячеек
        {
            this.showNew = !this.showNew;
        }

        private void GoToOptionsClick(object sender, EventArgs e) //нажатие по кнопке сверху для перехода во вкладку опций
        {
            if (selectedPanel == 2) return;
            //смотрим если уже была выбрана эта панелька

            //обнуляем панельку с настройка и отключаем видимость остальных
            this.SetDisplayOption();
            if (this.selectedPanel == 1) this.panel1.Visible = false;
            if (this.selectedPanel == 3) this.panel3.Visible = false;
            if (this.selectedPanel == 4) this.panel4.Visible = false;

            this.selectedPanel = 2;
            this.panel2.Visible = true;
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
                this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay, this.backPriceDisplay);
                this.ShowNewCell(x, y);
            }

        }

        private void Form1Closed(object sender, FormClosedEventArgs e) //обработка закрытия формы(программы в целом)
        {
            Properties.Settings.Default.saveRecord = this.game.GetRecord(); //сохраняем рекорд в настройки
            Properties.Settings.Default.Save(); //сохраняем настройки
        }

        private void GoToMainPanelClick(object sender, EventArgs e) //то же что и GoToOptionsClick. Нужно переписать в единую функцию 
        // fix me
        {
            if (selectedPanel == 1) return;
            
            if (this.selectedPanel == 4) this.panel4.Visible = false;
            if (this.selectedPanel == 3) this.panel3.Visible = false;
            if (this.selectedPanel == 2) this.panel2.Visible = false;

            this.selectedPanel = 1;
            this.panel1.Visible = true;      
        }

        private void GoToSavePanelClick(object sender, EventArgs e) //аналогично предыдущей
        {
            if (selectedPanel == 3) return;
           
            this.selectedSave = 0;
            this.ClearForUsingSaves();
            
            if (this.selectedPanel == 4) this.panel4.Visible = false;
            if (this.selectedPanel == 2) this.panel2.Visible = false;
            if (this.selectedPanel == 1) this.panel1.Visible = false;

            this.panel3.Visible = true;
            this.selectedPanel = 3;
        }

        private void GoToLoadPanelClick(object sender, EventArgs e)//аналогично предыдущей
        {
            if (selectedPanel == 4) return;
            
            this.ClearForUsingLoad();
            
            if (this.selectedPanel == 3) this.panel3.Visible = false;
            if (this.selectedPanel == 2) this.panel2.Visible = false;
            if (this.selectedPanel == 1) this.panel1.Visible = false;

            this.selectedPanel = 4;
            this.panel4.Visible = true;
        }
    }
}
