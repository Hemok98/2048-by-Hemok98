using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {
        private int selectedSave = 0;

        private Button acceptSavesButton;
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

                if (this.selectedSave == 1) Properties.Settings.Default.saveStr1 = this.game.SaveGame();
                if (this.selectedSave == 2) Properties.Settings.Default.saveStr2 = this.game.SaveGame();
                if (this.selectedSave == 3) Properties.Settings.Default.saveStr3 = this.game.SaveGame();
                if (this.selectedSave == 4) Properties.Settings.Default.saveStr4 = this.game.SaveGame();
                if (this.selectedSave == 5) Properties.Settings.Default.saveStr5 = this.game.SaveGame();
                if (this.selectedSave == 6) Properties.Settings.Default.saveStr6 = this.game.SaveGame();
                if (this.selectedSave == 7) Properties.Settings.Default.saveStr7 = this.game.SaveGame();
                if (this.selectedSave == 8) Properties.Settings.Default.saveStr8 = this.game.SaveGame();
                if (this.selectedSave == 9) Properties.Settings.Default.saveStr9 = this.game.SaveGame();
                Properties.Settings.Default.Save();
                this.achiveManager.ChekSaveLoad("save");
                MessageBox.Show("Игра успешно сохранена", "2048");                
            }
                
                else MessageBox.Show("Вы не выбрали ячейку для сохранения", "2048");
        }

        
    }
}