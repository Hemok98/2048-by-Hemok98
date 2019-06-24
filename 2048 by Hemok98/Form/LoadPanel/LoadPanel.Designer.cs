using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {
        private void IntitializeLoadPanel()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.loadButtons = new Button[9];
            this.acceptLoadButton = new System.Windows.Forms.Button();

            int xStart = 20,
                yStart = 20,
                size = 90,
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
                this.panel4.Controls.Add(this.loadButtons[i]);
                this.loadButtons[i].Click += new System.EventHandler(this.SelectLoadNumber);
                this.loadButtons[i].BackColor = System.Drawing.Color.WhiteSmoke;
            }

            this.acceptLoadButton.BackColor = System.Drawing.Color.LightGray;
            this.acceptLoadButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptLoadButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.acceptLoadButton.Location = new System.Drawing.Point(627, 404);
            this.acceptLoadButton.Name = "acceptLoad";
            this.acceptLoadButton.Size = new System.Drawing.Size(127, 47);
            this.acceptLoadButton.TabIndex = 4;
            this.acceptLoadButton.Text = "Загрузить";
            this.acceptLoadButton.UseVisualStyleBackColor = false;
            this.acceptLoadButton.Click += new System.EventHandler(this.AcceptLoadClick);

            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Visible = false;
            this.panel4.Controls.Add(this.acceptLoadButton);
            this.panel4.Location = new System.Drawing.Point(1, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(774, 480);
            this.panel4.TabIndex = 5;
            this.Controls.Add(this.panel4);
        }
    }
}