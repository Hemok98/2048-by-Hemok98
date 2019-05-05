using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class Form1
    {
        private int selectedSave = 0;

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button acceptSavesButton;
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
                this.game.SaveGame(this.selectedSave);
            }
                
                else MessageBox.Show("Игра успешно никуда не сохранена", "2048");
        }

        private void IntitializeSavesPanel()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.saveButtons = new Button[9];
            this.acceptSavesButton = new System.Windows.Forms.Button();

            int xStart = 20,
                yStart = 20,
                size = 90,
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
                this.saveButtons[i].Text = (i+1).ToString();
                this.saveButtons[i].UseVisualStyleBackColor = true;
                this.panel3.Controls.Add(this.saveButtons[i]);
                this.saveButtons[i].Click += new System.EventHandler(this.SelectSaveNumber);
                this.saveButtons[i].BackColor = System.Drawing.Color.WhiteSmoke;
            }

            this.acceptSavesButton.BackColor = System.Drawing.Color.LightGray;
            this.acceptSavesButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptSavesButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.acceptSavesButton.Location = new System.Drawing.Point(627, 404);
            this.acceptSavesButton.Name = "acceptOptions";
            this.acceptSavesButton.Size = new System.Drawing.Size(127, 47);
            this.acceptSavesButton.TabIndex = 4;
            this.acceptSavesButton.Text = "Сохранить";
            this.acceptSavesButton.UseVisualStyleBackColor = false;
            this.acceptSavesButton.Click += new System.EventHandler(this.AcceptSavesClick);

            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Visible = false;
            this.panel3.Controls.Add(this.acceptSavesButton);
            this.panel3.Location = new System.Drawing.Point(1, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 480);
            this.panel3.TabIndex = 5;
            this.Controls.Add(this.panel3);
        }
    }
}