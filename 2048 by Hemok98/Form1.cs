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
            this.game.RestartGame();
            this.textBox1.Text = this.game.output();
        }

        private Game game = new Game();


        private void button1_Click(object sender, EventArgs e)
        {
            this.game.Move(Movement.RIGHT);
            this.textBox1.Text = this.game.output();
            //this.game.addRandomCell();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.game.Move(Movement.LEFT);
            this.textBox1.Text = this.game.output();
            //this.game.addRandomCell();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.game.Move(Movement.UP);
            this.textBox1.Text = this.game.output();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.game.Move(Movement.DOWN);
            this.textBox1.Text = this.game.output();
        }
    }
}
