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

                bool flag = false;
                if (this.selectedLoad == 1 && Properties.Settings.Default.saveStr1 != "") flag = true;        
                if (this.selectedLoad == 2 && Properties.Settings.Default.saveStr2 != "") flag = true;
                if (this.selectedLoad == 3 && Properties.Settings.Default.saveStr3 != "") flag = true;
                if (this.selectedLoad == 4 && Properties.Settings.Default.saveStr4 != "") flag = true;
                if (this.selectedLoad == 5 && Properties.Settings.Default.saveStr5 != "") flag = true;
                if (this.selectedLoad == 6 && Properties.Settings.Default.saveStr6 != "") flag = true;
                if (this.selectedLoad == 7 && Properties.Settings.Default.saveStr7 != "") flag = true;
                if (this.selectedLoad == 8 && Properties.Settings.Default.saveStr8 != "") flag = true;
                if (this.selectedLoad == 9 && Properties.Settings.Default.saveStr9 != "") flag = true;

                if (flag)
                {
                    this.game = new Game();
                    this.achiveManager.ChekSaveLoad("load");

                    if (this.selectedLoad == 1) this.game.LoadGame(Properties.Settings.Default.saveStr1);
                    if (this.selectedLoad == 2) this.game.LoadGame(Properties.Settings.Default.saveStr2);
                    if (this.selectedLoad == 3) this.game.LoadGame(Properties.Settings.Default.saveStr3);
                    if (this.selectedLoad == 4) this.game.LoadGame(Properties.Settings.Default.saveStr4);
                    if (this.selectedLoad == 5) this.game.LoadGame(Properties.Settings.Default.saveStr5);
                    if (this.selectedLoad == 6) this.game.LoadGame(Properties.Settings.Default.saveStr6);
                    if (this.selectedLoad == 7) this.game.LoadGame(Properties.Settings.Default.saveStr7);
                    if (this.selectedLoad == 8) this.game.LoadGame(Properties.Settings.Default.saveStr8);
                    if (this.selectedLoad == 9) this.game.LoadGame(Properties.Settings.Default.saveStr9);

                    this.game.SetAchivRef(this.achiveManager);
                    this.displayCellsCount = this.game.cellsCount;
                    this.SetCellsDiplay(displayCellsCount);
                    this.DisplayShow();
                    MessageBox.Show("Игра успешно загружена", "2048");
                }
                else MessageBox.Show("Вы выбрали пустую ячейку сохранения", "2048");
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