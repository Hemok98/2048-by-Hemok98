using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {
        private int selectedLoad = 0;

        private Button acceptLoadButton;
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

                if (this.selectedLoad == 1 && Properties.Settings.Default.saveCont1 != null) this.game = (Game)ObjectCopier.Clone(Properties.Settings.Default.saveCont1);
                if (this.selectedLoad == 2 && Properties.Settings.Default.saveCont2 != null) this.game = (Game)ObjectCopier.Clone(Properties.Settings.Default.saveCont2);
                if (this.selectedLoad == 3 && Properties.Settings.Default.saveCont3 != null) this.game = (Game)ObjectCopier.Clone(Properties.Settings.Default.saveCont3);
                if (this.selectedLoad == 4 && Properties.Settings.Default.saveCont4 != null) this.game = (Game)ObjectCopier.Clone(Properties.Settings.Default.saveCont4);
                if (this.selectedLoad == 5 && Properties.Settings.Default.saveCont5 != null) this.game = (Game)ObjectCopier.Clone(Properties.Settings.Default.saveCont5);
                if (this.selectedLoad == 6 && Properties.Settings.Default.saveCont6 != null) this.game = (Game)ObjectCopier.Clone(Properties.Settings.Default.saveCont6);
                if (this.selectedLoad == 7 && Properties.Settings.Default.saveCont7 != null) this.game = (Game)ObjectCopier.Clone(Properties.Settings.Default.saveCont7);
                if (this.selectedLoad == 8 && Properties.Settings.Default.saveCont8 != null) this.game = (Game)ObjectCopier.Clone(Properties.Settings.Default.saveCont8);
                if (this.selectedLoad == 9 && Properties.Settings.Default.saveCont9 != null) this.game = (Game)ObjectCopier.Clone(Properties.Settings.Default.saveCont9);

                this.displayCellsCount = this.game.cellsCount;
                this.SetCellsDiplay(displayCellsCount);
                this.DisplayShow();
            }

            else MessageBox.Show("Вы не выбрали ячейку для загрузки", "2048");
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