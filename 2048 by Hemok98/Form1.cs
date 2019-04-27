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
        public Form1()
        {
            InitializeComponent();
            MyInitializeComponent();
            this.game.RestartGame();

            string test = "";
            this.game.output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay);
            textBox1.Text = test;

        }

        private Game game = new Game();


        private void RightButtonClick(object sender, EventArgs e)
        {
            this.game.Move(Movement.RIGHT);
            this.game.output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay);
        }

        private void LeftButtonClick(object sender, EventArgs e)
        {
            this.game.Move(Movement.LEFT);
            int[,] cells = new int[4,4];
            this.game.output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay);
        }

        private void UpButtonClick(object sender, EventArgs e)
        {
            this.game.Move(Movement.UP);
            this.game.output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay);
        }

        private void DownButtonClick(object sender, EventArgs e)
        {
            this.game.Move(Movement.DOWN);
            this.game.output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay);
        }

        private void RestartButtonClick(object sender, EventArgs e)
        {
            game.RestartGame();
            this.game.output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay);
        }

        private async void CellsDisplayClick(object sender, EventArgs e)
        {
            Button cell = (Button)sender;
            int indexX = int.Parse(cell.Name[0] + "");
            int indexY = int.Parse(cell.Name[1] + "");
            
            if ( this.game.UseSkill(indexX,indexY) )
            {
                await Task.Run(() => ChangeButtonColor(cell, System.Drawing.Color.Green));
                this.game.output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay);
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

        private void X2ButtonClick(object sender, EventArgs e)
        {
            this.game.selectActivatedSkill(Skills.X2);
            //this.textBox1.Text += this.game.skillActivated.ToString();
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            this.game.selectActivatedSkill(Skills.DELETE);
        }
    }
}