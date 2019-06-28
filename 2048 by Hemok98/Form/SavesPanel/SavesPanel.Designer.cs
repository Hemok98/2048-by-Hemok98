using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {

        private void IntitializeSavesPanel()
        {
            this.saveButtons = new Button[9];
            this.acceptSavesButton = new System.Windows.Forms.Button();

            int xStart = 100,
                yStart = 20,
                size = 120,
                indent = 10;
            for (int i = 0; i < 9; i++)
            {
                this.saveButtons[i] = new System.Windows.Forms.Button();
                //this.SuspendLayout();
                this.saveButtons[i].Location = new System.Drawing.Point(xStart + (i % 3) * (size + indent), yStart + (i / 3) * (size + indent));
                this.saveButtons[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.saveButtons[i].Name = i.ToString();
                this.saveButtons[i].Size = new System.Drawing.Size(size, size);
                this.saveButtons[i].TabIndex = 0;
                this.saveButtons[i].Text = (i + 1).ToString();
                this.saveButtons[i].UseVisualStyleBackColor = true;
                this.pages[2].Controls.Add(this.saveButtons[i]);
                this.saveButtons[i].Click += new System.EventHandler(this.SelectSaveNumber);
                this.saveButtons[i].BackColor = System.Drawing.Color.WhiteSmoke;
            }

            this.acceptSavesButton.BackColor = System.Drawing.Color.LightGray;
            this.acceptSavesButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptSavesButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.acceptSavesButton.Location = new System.Drawing.Point(230, 415);
            this.acceptSavesButton.Name = "acceptOptions";
            this.acceptSavesButton.Size = new System.Drawing.Size(120, 50);
            this.acceptSavesButton.TabIndex = 4;
            this.acceptSavesButton.Text = "Сохранить";
            this.acceptSavesButton.UseVisualStyleBackColor = false;
            this.acceptSavesButton.Click += new System.EventHandler(this.AcceptSavesClick);

            this.pages[2].Controls.Add(this.acceptSavesButton);
        }
    }
}