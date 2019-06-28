using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {
        private Panel[] pages = new System.Windows.Forms.Panel[10];

        private void PagesInit()
        {
            for (int i = 0; i < 10; i++)
            {
                this.pages[i] = new Panel();

                this.pages[i].BackColor = System.Drawing.Color.Transparent;
                this.pages[i].Visible = false;
                this.pages[i].Location = new System.Drawing.Point(1, 30);
                this.pages[i].Name = "page" + i.ToString();
                this.pages[i].Size = new System.Drawing.Size(600, 480);
                this.pages[i].TabIndex = 5;
                this.Controls.Add(this.pages[i]);
            }

            this.MainPageInit();
            this.InitializeOptionsPanel();
            this.IntitializeSavesPanel();
            this.SetDisplayOption();
            this.IntitializeLoadPanel();

        }
    }
}
