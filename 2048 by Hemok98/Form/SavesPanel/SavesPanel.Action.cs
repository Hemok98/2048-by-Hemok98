using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {
        private int selectedSave = 0;

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button acceptSavesButton;
        private Button[] saveButtons;

        private void ClearForUsingSaves()
        {
            this.selectedSave = 0;
            for (int i = 0; i < 9; i++)
            {
                this.saveButtons[i].BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void SelectSaveNumber(object sender,EventArgs e)
        {
            Button sended = (Button)sender;
            if (this.selectedSave != 0) this.saveButtons[this.selectedSave - 1].BackColor = System.Drawing.Color.WhiteSmoke;
            this.selectedSave = int.Parse(sended.Name)+1;
            sended.BackColor = System.Drawing.Color.Gold;
        }

        private void AcceptSavesClick(object sender, EventArgs e)
        {
            
            if ( this.selectedSave != 0 )
            {
                this.saveButtons[this.selectedSave-1].BackColor = System.Drawing.Color.WhiteSmoke;
                MessageBox.Show("Игра успешно сохранена", "2048");
                this.game.SaveGame(this.selectedSave);
            }
                
                else MessageBox.Show("Игра успешно никуда не сохранена", "2048");
        }

        
    }
}