using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm 
    {
        private void ChangeTrackBarValue(object sender, EventArgs e)
        {
            this.trackBarLabel.Text = String.Format("Число ячеек : {0}", cellsCountTrackBar.Value);
        } 

        private System.Windows.Forms.Label optinsNameDisplay;
        private System.Windows.Forms.TrackBar cellsCountTrackBar;
        private System.Windows.Forms.Label trackBarLabel;
        private System.Windows.Forms.CheckBox showNewCheckBox;
        private System.Windows.Forms.CheckBox WASDcheckBox;
        private System.Windows.Forms.CheckBox resetRecordCheckBox;
        private System.Windows.Forms.Button acceptOptions;
        private System.Windows.Forms.Panel panel2;   

        private void SetDisplayOption()
        {
            this.WASDcheckBox.Checked = this.canUseKeys;
            this.showNewCheckBox.Checked = this.showNew;
            this.cellsCountTrackBar.Value = this.game.cellsCount;
            this.trackBarLabel.Text = String.Format("Число ячеек : {0}", cellsCountTrackBar.Value);
            this.resetRecordCheckBox.Checked = false;
        }

        private void AcceptOptionsClick(object sender, EventArgs e)
        {
            this.canUseKeys = this.WASDcheckBox.Checked;
            this.showNew = this.showNewCheckBox.Checked;
            if (this.resetRecordCheckBox.Checked == true)
            {
                this.game.SetRecord(0);
            }

            if (this.cellsCountTrackBar.Value != this.displayCellsCount)
            {
                this.displayCellsCount = this.cellsCountTrackBar.Value;
                this.game.cellsCount = this.displayCellsCount;
                this.SetCellsDiplay(this.cellsCountTrackBar.Value);
                this.game.RestartGame();
            }

            

            this.DisplayShow();
            MessageBox.Show("Настройки успешно применены", "2048");
        }

        private void SetCellsDiplay(int count)
        {
            int xStart = 10;
            int yStart = 50;          
            int indent = 10;
            int size = (390 - (count-1)*indent) / count;

            for (int i = 0; i < Game.MAXCELLS; i++)
            {
                for (int j = 0; j < Game.MAXCELLS; j++)
                {
                    this.cellsDispay[i, j].Location = new System.Drawing.Point(xStart + j * (size + indent), yStart + i * (size + indent));
                    this.cellsDispay[i, j].Size = new System.Drawing.Size(size, size);
                    this.cellsDispay[i, j].Visible = ((i < this.displayCellsCount) && (j < this.displayCellsCount));
                }
            }

            
        }

        
    }
}