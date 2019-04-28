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
    public partial class Form1 : Form
    {
        private bool showNew = false;

        public Form1()
        {
            InitializeComponent();
            MyInitializeComponent();
            int x = 0, y = 0;
            this.game.RestartGame(ref x, ref y);
            if ( x != -1)
            {
                ShowNewCell(x, y);
            }

            //string test = "";
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
            //textBox1.Text = test;

        }

        private Game game = new Game();


        private void RightButtonClick(object sender, EventArgs e)
        {
            int x = -1, y = -1;
            this.game.Move(Movement.RIGHT, ref x, ref y);
            if (x != -1)
            {
                ShowNewCell(x, y);
            }
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
        }

        private void LeftButtonClick(object sender, EventArgs e)
        {
            int x = -1, y = -1;
            this.game.Move(Movement.LEFT, ref x, ref y);
            if (x != -1)
            {
                ShowNewCell(x, y);
            }
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
        }

        private void UpButtonClick(object sender, EventArgs e)
        {
            int x = -1, y = -1;
            this.game.Move(Movement.UP, ref x, ref y);
            if (x != -1)
            {
                ShowNewCell(x, y);
            }
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
        }

        private void DownButtonClick(object sender, EventArgs e)
        {
            int x = -1, y = -1;
            this.game.Move(Movement.DOWN, ref x, ref y);
            if (x != -1)
            {
                ShowNewCell(x, y);
            }
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
        }

        private void RestartButtonClick(object sender, EventArgs e)
        {
            int x = -1, y = -1;
            this.game.RestartGame(ref x, ref y);
            if (x != -1)
            {
                ShowNewCell(x, y);
            }
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
        }

        private async void CellsDisplayClick(object sender, EventArgs e)
        {
            Button cell = (Button)sender;
            int indexX = int.Parse(cell.Name[0] + "");
            int indexY = int.Parse(cell.Name[1] + "");
            
            if ( this.game.UseSkill(indexX,indexY) )
            {
                await Task.Run(() => ChangeButtonColor(cell, System.Drawing.Color.Green));
                this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
            }
            else
            {
                await Task.Run(() => ChangeButtonColor(cell, System.Drawing.Color.Red));
            }
        }

        private void ChangeButtonColor(Button cell, System.Drawing.Color color)
        {

            cell.BackColor = color;
            Thread.Sleep(200);
            cell.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private async void ShowNewCell(int x, int y)
        {
            if (this.showNew) await Task.Run(() => ChangeButtonColor(this.cellsDispay[y,x], System.Drawing.Color.LightBlue));
        }

        private void X2ButtonClick(object sender, EventArgs e)
        {
            this.game.SelectActivatedSkill(Skills.X2);
            //this.textBox1.Text += this.game.skillActivated.ToString();
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            this.game.SelectActivatedSkill(Skills.DELETE);
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            this.game.SelectActivatedSkill(Skills.BACK);
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
        }

        private void ChangeShowNewCells(object sender, EventArgs e)
        {
            this.showNew = !this.showNew;
        }
    }
}