using System;
using System.Windows.Forms;

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
                MessageBox.Show("Игра успешно сохранена", "2048");
                

                if (this.selectedSave == 1) Properties.Settings.Default.saveCont1 = (object)ObjectCopier.Clone(this.game);
                if (this.selectedSave == 2) Properties.Settings.Default.saveCont2 = (object)ObjectCopier.Clone(this.game);
                if (this.selectedSave == 3) Properties.Settings.Default.saveCont3 = (object)ObjectCopier.Clone(this.game);
                if (this.selectedSave == 4) Properties.Settings.Default.saveCont4 = (object)ObjectCopier.Clone(this.game);
                if (this.selectedSave == 5) Properties.Settings.Default.saveCont5 = (object)ObjectCopier.Clone(this.game);
                if (this.selectedSave == 6) Properties.Settings.Default.saveCont6 = (object)ObjectCopier.Clone(this.game);
                if (this.selectedSave == 7) Properties.Settings.Default.saveCont7 = (object)ObjectCopier.Clone(this.game);
                if (this.selectedSave == 8) Properties.Settings.Default.saveCont8 = (object)ObjectCopier.Clone(this.game);
                if (this.selectedSave == 9) Properties.Settings.Default.saveCont9 = (object)ObjectCopier.Clone(this.game);


                Properties.Settings.Default.Save();
            }
                
                else MessageBox.Show("Вы не выбрали ячейку для сохранения", "2048");
        }

        
    }
}