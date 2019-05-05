using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class Form1 : Form
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
            this.setCellsDiplay(cellsCountTrackBar.Value);
            this.game.cellsCount = cellsCountTrackBar.Value;
            if (this.resetRecordCheckBox.Checked == true)
            {
                this.game.SetRecord(0);
            }

            int x = -1, y = -1;
            if (this.cellsCountTrackBar.Value != this.displayCellsCount) this.game.RestartGame(ref x, ref y);
            this.displayCellsCount = this.cellsCountTrackBar.Value;
            if (x != -1)
            {
                ShowNewCell(x, y);
            }

            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay, this.backPriceDisplay);
            MessageBox.Show("Настройки успешно применены", "2048");
        }

        private void setCellsDiplay(int count)
        {
            int xStart = 10;
            int yStart = 50;          
            int indent = 10;
            int size = (390 - (count-1)*indent) / count;

            for (int i = 0; i < Game.MAXCELLS; i++)
            {
                for (int j = 0; j < Game.MAXCELLS; j++)
                {
                    this.cellsDispay[i, j].Location = new System.Drawing.Point(xStart + i * (size + indent), yStart + j * (size + indent));
                    this.cellsDispay[i, j].Size = new System.Drawing.Size(size, size);
                }
            }
        }

        private void InitializeOptionsPanel()
        {
            this.cellsCountTrackBar = new System.Windows.Forms.TrackBar();
            this.trackBarLabel = new System.Windows.Forms.Label();
            this.optinsNameDisplay = new System.Windows.Forms.Label();
            this.showNewCheckBox = new System.Windows.Forms.CheckBox();
            this.resetRecordCheckBox = new System.Windows.Forms.CheckBox();
            this.WASDcheckBox = new System.Windows.Forms.CheckBox();
            this.acceptOptions = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.cellsCountTrackBar)).BeginInit();
            //this.panel2.SuspendLayout();
            //this.SuspendLayout();
            // 
            // cellsCountTrackBar
            // 
            this.cellsCountTrackBar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cellsCountTrackBar.LargeChange = 1;
            this.cellsCountTrackBar.Location = new System.Drawing.Point(0, 80);
            this.cellsCountTrackBar.Maximum = 6;
            this.cellsCountTrackBar.Minimum = 2;
            this.cellsCountTrackBar.Name = "cellsCountTrackBar";
            this.cellsCountTrackBar.Size = new System.Drawing.Size(385, 45);
            this.cellsCountTrackBar.TabIndex = 0;
            this.cellsCountTrackBar.Value = 4;
            this.cellsCountTrackBar.Scroll += new System.EventHandler(this.ChangeTrackBarValue);
            // 
            // trackBarLabel
            // 
            this.trackBarLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.trackBarLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackBarLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.trackBarLabel.Location = new System.Drawing.Point(0, 50);
            this.trackBarLabel.Name = "trackBarLabel";
            this.trackBarLabel.Size = new System.Drawing.Size(385, 30);
            this.trackBarLabel.TabIndex = 1;
            this.trackBarLabel.Text = "Число ячеек : 4";
            this.trackBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarLabel
            // 
            this.optinsNameDisplay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.optinsNameDisplay.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.optinsNameDisplay.ForeColor = System.Drawing.Color.DarkRed;
            this.optinsNameDisplay.Location = new System.Drawing.Point(0, 0);
            this.optinsNameDisplay.Name = "trackBarLabel";
            this.optinsNameDisplay.Size = new System.Drawing.Size(770, 50);
            this.optinsNameDisplay.TabIndex = 1;
            this.optinsNameDisplay.Text = "Настройки";
            this.optinsNameDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetRecordCheckBox
            //
            this.resetRecordCheckBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.resetRecordCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetRecordCheckBox.Location = new System.Drawing.Point(385, 125);
            this.resetRecordCheckBox.Name = "resetRecordCheckBox";
            this.resetRecordCheckBox.Size = new System.Drawing.Size(385, 45);
            this.resetRecordCheckBox.TabIndex = 2;
            this.resetRecordCheckBox.Text = "Обнулить рекорд";
            this.resetRecordCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resetRecordCheckBox.UseVisualStyleBackColor = false;


            // 
            // showNewCheckBox
            //
            this.showNewCheckBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.showNewCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showNewCheckBox.Location = new System.Drawing.Point(0, 125);
            this.showNewCheckBox.Name = "showNewCheckBox";
            this.showNewCheckBox.Size = new System.Drawing.Size(385, 45);
            this.showNewCheckBox.TabIndex = 2;
            this.showNewCheckBox.Text = "Отображать появление новых чисел";
            this.showNewCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showNewCheckBox.UseVisualStyleBackColor = false;
            // 
            // WASDcheckBox
            // 
            this.WASDcheckBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.WASDcheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WASDcheckBox.Location = new System.Drawing.Point(0, 170);
            this.WASDcheckBox.Name = "WASDcheckBox";
            this.WASDcheckBox.Size = new System.Drawing.Size(380, 45);
            this.WASDcheckBox.TabIndex = 3;
            this.WASDcheckBox.Text = "Управление клавиатурой(WASD)";
            this.WASDcheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WASDcheckBox.UseVisualStyleBackColor = false;
            // 
            // acceptOptions
            // 
            this.acceptOptions.BackColor = System.Drawing.Color.LightGray;
            this.acceptOptions.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptOptions.ForeColor = System.Drawing.Color.DarkGreen;
            this.acceptOptions.Location = new System.Drawing.Point(627, 404);
            this.acceptOptions.Name = "acceptOptions";
            this.acceptOptions.Size = new System.Drawing.Size(127, 47);
            this.acceptOptions.TabIndex = 4;
            this.acceptOptions.Text = "Применить";
            this.acceptOptions.UseVisualStyleBackColor = false;
            this.acceptOptions.Click += new System.EventHandler(this.AcceptOptionsClick);
            // 
            // panel1
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Visible = false;
            this.panel2.Controls.Add(this.acceptOptions);
            this.panel2.Controls.Add(this.WASDcheckBox);
            this.panel2.Controls.Add(this.showNewCheckBox);
            this.panel2.Controls.Add(this.trackBarLabel);
            this.panel2.Controls.Add(this.cellsCountTrackBar);
            this.panel2.Controls.Add(this.optinsNameDisplay);
            this.panel2.Controls.Add(this.resetRecordCheckBox);
            this.panel2.Location = new System.Drawing.Point(1, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 480);
            this.panel2.TabIndex = 5;

            this.Controls.Add(this.panel2);
            ((System.ComponentModel.ISupportInitialize)(this.cellsCountTrackBar)).EndInit();

            //this.WASDcheckBox.Checked = this.canUseKeys;
            //this.showNewCheckBox.Checked = this.showNew;
        }
    }
}