using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {
        private void IntitializeLoadPanel()
        {
            this.loadButtons = new Button[9];
            this.acceptLoadButton = new System.Windows.Forms.Button();

            int xStart = 100,
                yStart = 20,
                size = 120,
                indent = 10;
            for (int i = 0; i < 9; i++)
            {
                this.loadButtons[i] = new Button();
                //this.SuspendLayout();
                this.loadButtons[i].Location = new System.Drawing.Point(xStart + (i % 3) * (size + indent), yStart + (i / 3) * (size + indent));
                this.loadButtons[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.loadButtons[i].Name = i.ToString();
                this.loadButtons[i].Size = new System.Drawing.Size(size, size);
                this.loadButtons[i].TabIndex = 0;
                this.loadButtons[i].Text = (i + 1).ToString();
                this.loadButtons[i].UseVisualStyleBackColor = true;
                this.pages[3].Controls.Add(this.loadButtons[i]);
                this.loadButtons[i].Click += new System.EventHandler(this.SelectLoadNumber);
                this.loadButtons[i].BackColor = System.Drawing.Color.WhiteSmoke;
            }

            this.acceptLoadButton.BackColor = System.Drawing.Color.LightGray;
            this.acceptLoadButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptLoadButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.acceptLoadButton.Location = new System.Drawing.Point(230, 415);
            this.acceptLoadButton.Name = "acceptLoad";
            this.acceptLoadButton.Size = new System.Drawing.Size(120, 50);
            this.acceptLoadButton.TabIndex = 4;
            this.acceptLoadButton.Text = "Загрузить";
            this.acceptLoadButton.UseVisualStyleBackColor = false;
            this.acceptLoadButton.Click += new System.EventHandler(this.AcceptLoadClick);

            this.pages[3].Controls.Add(this.acceptLoadButton);
        }
    }
}