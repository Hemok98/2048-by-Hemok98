using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            int cellCount = this.game.output(this.cellsDispay, label1,  label2,  label3);
            textBox1.Text = test;

        }

        private Game game = new Game();


        private void RightButtonClick(object sender, EventArgs e)
        {
            this.game.Move(Movement.RIGHT);
            int cellCount = this.game.output(this.cellsDispay, label1, label2, label3);
        }

        private void LeftButtonClick(object sender, EventArgs e)
        {
            this.game.Move(Movement.LEFT);
            int[,] cells = new int[4,4];
            int cellCount = this.game.output(this.cellsDispay, label1, label2, label3);
        }

        private void UpButtonClick(object sender, EventArgs e)
        {
            this.game.Move(Movement.UP);
            int cellCount = this.game.output(this.cellsDispay, label1, label2, label3);
        }

        private void DownButtonClick(object sender, EventArgs e)
        {
            this.game.Move(Movement.DOWN);
            int cellCount = this.game.output(this.cellsDispay, label1, label2, label3);
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            game.RestartGame();
            int cellCount = this.game.output(this.cellsDispay, label1, label2, label3);
        }

        private void cellsDisplayClick(object sender, EventArgs e)
        {
            Button cell = (Button)sender;
            int indexX = int.Parse(cell.Name[0] + "");
            int indexY = int.Parse(cell.Name[1] + "");
            //cell.BackColor = System.Drawing.SystemColors.Highlight;

        }
    }
}