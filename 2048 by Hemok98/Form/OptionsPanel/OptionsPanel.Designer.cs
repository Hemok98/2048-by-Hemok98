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

        private void InitializeOptionsPanel()
        {
            this.cellsCountTrackBar = new System.Windows.Forms.TrackBar();
            this.trackBarLabel = new System.Windows.Forms.Label();
            this.optinsNameDisplay = new System.Windows.Forms.Label();
            this.showNewCheckBox = new System.Windows.Forms.CheckBox();
            this.resetRecordCheckBox = new System.Windows.Forms.CheckBox();
            this.WASDcheckBox = new System.Windows.Forms.CheckBox();
            this.acceptOptions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cellsCountTrackBar)).BeginInit();
            //this.panel2.SuspendLayout();
            //this.SuspendLayout();
            // 
            // cellsCountTrackBar
            // 
            this.cellsCountTrackBar.BackColor = System.Drawing.Color.White;
            this.cellsCountTrackBar.LargeChange = 1;
            this.cellsCountTrackBar.Location = new System.Drawing.Point(0, 80);
            this.cellsCountTrackBar.Maximum = 6;
            this.cellsCountTrackBar.Minimum = 2;
            this.cellsCountTrackBar.Name = "cellsCountTrackBar";
            this.cellsCountTrackBar.Size = new System.Drawing.Size(300, 45);
            this.cellsCountTrackBar.TabIndex = 0;
            this.cellsCountTrackBar.Value = 4;
            this.cellsCountTrackBar.Scroll += new System.EventHandler(this.ChangeTrackBarValue);
            // 
            // trackBarLabel
            // 
            this.trackBarLabel.BackColor = System.Drawing.Color.White;
            this.trackBarLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackBarLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.trackBarLabel.Location = new System.Drawing.Point(0, 50);
            this.trackBarLabel.Name = "trackBarLabel";
            this.trackBarLabel.Size = new System.Drawing.Size(300, 30);
            this.trackBarLabel.TabIndex = 1;
            this.trackBarLabel.Text = "Число ячеек : 4";
            this.trackBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarLabel
            // 
            this.optinsNameDisplay.BackColor = System.Drawing.Color.White;
            this.optinsNameDisplay.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.optinsNameDisplay.ForeColor = System.Drawing.Color.DarkRed;
            this.optinsNameDisplay.Location = new System.Drawing.Point(0, 0);
            this.optinsNameDisplay.Name = "trackBarLabel";
            this.optinsNameDisplay.Size = new System.Drawing.Size(600, 50);
            this.optinsNameDisplay.TabIndex = 1;
            this.optinsNameDisplay.Text = "Настройки";
            this.optinsNameDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetRecordCheckBox
            //
            this.resetRecordCheckBox.BackColor = System.Drawing.Color.White;
            this.resetRecordCheckBox.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetRecordCheckBox.Location = new System.Drawing.Point(310, 125);
            this.resetRecordCheckBox.Name = "resetRecordCheckBox";
            this.resetRecordCheckBox.Size = new System.Drawing.Size(300, 45);
            this.resetRecordCheckBox.TabIndex = 2;
            this.resetRecordCheckBox.Text = "Обнулить рекорд";
            this.resetRecordCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetRecordCheckBox.UseVisualStyleBackColor = false;


            // 
            // showNewCheckBox
            //
            this.showNewCheckBox.BackColor = System.Drawing.Color.White;
            this.showNewCheckBox.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showNewCheckBox.Location = new System.Drawing.Point(0, 125);
            this.showNewCheckBox.Name = "showNewCheckBox";
            this.showNewCheckBox.Size = new System.Drawing.Size(300, 45);
            this.showNewCheckBox.TabIndex = 2;
            this.showNewCheckBox.Text = "Отображать появление новых чисел";
            this.showNewCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showNewCheckBox.UseVisualStyleBackColor = false;
            // 
            // WASDcheckBox
            // 
            this.WASDcheckBox.BackColor = System.Drawing.Color.White;
            this.WASDcheckBox.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WASDcheckBox.Location = new System.Drawing.Point(0, 170);
            this.WASDcheckBox.Name = "WASDcheckBox";
            this.WASDcheckBox.Size = new System.Drawing.Size(300, 45);
            this.WASDcheckBox.TabIndex = 3;
            this.WASDcheckBox.Text = "Управление клавиатурой(WASD)";
            this.WASDcheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WASDcheckBox.UseVisualStyleBackColor = false;
            // 
            // acceptOptions
            // 
            this.acceptOptions.BackColor = System.Drawing.Color.LightGray;
            this.acceptOptions.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptOptions.ForeColor = System.Drawing.Color.DarkGreen;
            this.acceptOptions.Location = new System.Drawing.Point(400, 404);
            this.acceptOptions.Name = "acceptOptions";
            this.acceptOptions.Size = new System.Drawing.Size(127, 47);
            this.acceptOptions.TabIndex = 4;
            this.acceptOptions.Text = "Применить";
            this.acceptOptions.UseVisualStyleBackColor = false;
            this.acceptOptions.Click += new System.EventHandler(this.AcceptOptionsClick);
            // 
            // panel1
            //
            //this.pages[1].BackColor = System.Drawing.Color.White;
            this.pages[1].Controls.Add(this.acceptOptions);
            this.pages[1].Controls.Add(this.WASDcheckBox);
            this.pages[1].Controls.Add(this.showNewCheckBox);
            this.pages[1].Controls.Add(this.trackBarLabel);
            this.pages[1].Controls.Add(this.cellsCountTrackBar);
            this.pages[1].Controls.Add(this.optinsNameDisplay);
            this.pages[1].Controls.Add(this.resetRecordCheckBox);

            ((System.ComponentModel.ISupportInitialize)(this.cellsCountTrackBar)).EndInit();

            //this.WASDcheckBox.Checked = this.canUseKeys;
            //this.showNewCheckBox.Checked = this.showNew;
        }
    }
}
