using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {
        private AchivementsPanel[] achivesDisplay = new AchivementsPanel[Achievements.achivCount+10];
        private void AchivesPanelInit()
        {
            //for (int i = 0; i < Achivements.achivCount; i++)
            //{
            //    achivesDisplay[i] = new AchivementsPanel();
            //}
            //this.pages[4].Size = 300;
            this.pages[4].AutoScroll = true;
            //this.pages[4].AutoScrollMargin = new System.Drawing.Size(10, 50);

            string str = Properties.Settings.Default.achivementsParse;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            int i = 0;
            while (str!="" )
            //for (;i < 10; i++)
            {
                string name = str.Substring(0, str.IndexOf(";"));
                str = str.Substring(str.IndexOf(";") +1);
                
                string descrip =  str.Substring(0, str.IndexOf(";")) ;
                str = str.Substring(str.IndexOf(";") + 1);
                //descrip = name;
                this.achivesDisplay[i] = new AchivementsPanel(name, descrip, ((System.Drawing.Bitmap)(resources.GetObject("swapButton.BackgroundImage"))),10,10+i*100);
                this.pages[4].Controls.Add(achivesDisplay[i]);
                i++;
            }  
            
        }

        private void DisplayAchivements()
        {
            for (int i = 0; i < Achievements.achivCount; i++)
            {
                this.achivesDisplay[i].setColor(achiveManager.GetAchivement(i));
            }
        }
    }
}
