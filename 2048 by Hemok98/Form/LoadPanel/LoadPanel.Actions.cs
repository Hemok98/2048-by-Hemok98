using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {
        private int selectedLoad = 0;

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button acceptLoadButton;
        private Button[] loadButtons;

        private void SelectLoadNumber(object sender, EventArgs e)
        {
            Button sended = (Button)sender;
            if (this.selectedLoad != 0) this.loadButtons[this.selectedLoad - 1].BackColor = System.Drawing.Color.WhiteSmoke;
            this.selectedLoad = int.Parse(sended.Name) + 1;
            sended.BackColor = System.Drawing.Color.Gold;
        }

        private void AcceptLoadClick(object sender, EventArgs e)
        {
            
            if (this.selectedLoad != 0)
            {
                this.loadButtons[this.selectedLoad - 1].BackColor = System.Drawing.Color.WhiteSmoke;
                MessageBox.Show("Игра успешно загружена", "2048");
                this.displayCellsCount = this.game.LoadGame(this.selectedLoad);
                this.DisplayShow();
            }

            else MessageBox.Show("Игра успешно ниоткуда не загружена", "2048");
        }

        private void ClearForUsingLoad()
        {
            this.selectedLoad = 0;
            for (int i = 0; i < 9; i++)
            {
                this.loadButtons[i].BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        
    }
}