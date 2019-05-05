using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _2048_by_Hemok98
{
    public partial class Form1 : Form
    {
        private bool showNew = false;

        private bool canUseKeys = true;

        private int displayCellsCount = 4;

        private int selectedPanel = 1;

        public Form1()
        {
            this.InitializeComponent();
            this.MyInitializeComponent();
            this.InitializeOptionsPanel();
            this.IntitializeSavesPanel();
            this.SetDisplayOption();
            IntitializeLoadPanel();

            /*Properties.Settings.Default.saveString1 = "";
            Properties.Settings.Default.saveString2 = "";
            Properties.Settings.Default.saveString3 = "";
            Properties.Settings.Default.saveString4 = "";
            Properties.Settings.Default.saveString5 = "";
            Properties.Settings.Default.saveString6 = "";
            Properties.Settings.Default.saveString7 = "";
            Properties.Settings.Default.saveString8 = "";
            Properties.Settings.Default.saveString9 = ""; */

            int x = 0, y = 0;
            this.game.RestartGame(ref x, ref y);
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
            if ( x != -1)
            {
                ShowNewCell(x, y);
            }
        }

        private Game game = new Game();

        private void MoveButtonClick(object sender, EventArgs e)
        {
            int x = -1, y = -1;
            Button pressedButton = (Button)sender;

            switch (pressedButton.Name)
            {
                case "rightButton":
                {
                    this.game.Move(Movement.RIGHT, ref x, ref y);
                    break;
                }

                case "leftButton":
                {
                    this.game.Move(Movement.LEFT, ref x, ref y);
                    break;
                }

                case "upButton":
                {
                    this.game.Move(Movement.UP, ref x, ref y);
                    break;
                }

                case "downButton":
                {
                    this.game.Move(Movement.DOWN, ref x, ref y);
                    break;
                }
            }

            if (x != -1)
            {
                this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay, this.backPriceDisplay);
                ShowNewCell(x, y);
                
            }
            
        }

        private void RestartButtonClick(object sender, EventArgs e)
        {
            int x = -1, y = -1;
            this.game.RestartGame(ref x, ref y);
            if (x != -1)
            {
                this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
                ShowNewCell(x, y);
            }
            
            
        }

        private async void CellsDisplayClick(object sender, EventArgs e)
        {
            Button cell = (Button)sender;
            int indexX = int.Parse(cell.Name[0] + "");
            int indexY = int.Parse(cell.Name[1] + "");
            
            if ( this.game.UseSkill(indexX,indexY) )
            {
                await Task.Run(() => ChangeButtonColor(cell, System.Drawing.Color.Green));
                this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
            }
            else
            {
                await Task.Run(() => ChangeButtonColor(cell, System.Drawing.Color.Red));
            }
        }

        private void ChangeButtonColor(Button cell, System.Drawing.Color color)
        {
            System.Drawing.Color first = new System.Drawing.Color();
            first = cell.BackColor;

            cell.BackColor = color;
            Thread.Sleep(200);
            //cell.BackColor = System.Drawing.Color.WhiteSmoke;
            cell.BackColor = first;
        }

        private async void ShowNewCell(int x, int y)
        {
            if (this.showNew) await Task.Run(() => ChangeButtonColor(this.cellsDispay[y,x], System.Drawing.Color.LightBlue));
        }

        private void X2ButtonClick(object sender, EventArgs e)
        {
            this.game.SelectActivatedSkill(Skills.X2);
            //this.textBox1.Text += this.game.skillActivated.ToString();
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            this.game.SelectActivatedSkill(Skills.DELETE);
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            this.game.SelectActivatedSkill(Skills.BACK);
            this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay,this.backPriceDisplay);
        }

        private void ChangeShowNewCells(object sender, EventArgs e)
        {
            this.showNew = !this.showNew;
        }

        private void GoToOptionsClick(object sender, EventArgs e)
        {
            if (selectedPanel == 2) return;

            this.SetDisplayOption();
            if (this.selectedPanel == 1) this.panel1.Visible = false;
            if (this.selectedPanel == 3) this.panel3.Visible = false;
            if (this.selectedPanel == 4) this.panel4.Visible = false;

            this.selectedPanel = 2;
            this.panel2.Visible = true;
        }

        private void KeyPressed (object sender, KeyEventArgs e)
        {
            if (!canUseKeys) return;

            bool beenUsed = false;
            int x = -1, y = -1;
            switch (e.KeyData)
            {
                case Keys.W:
                {
                    beenUsed = true;
                    this.game.Move(Movement.UP, ref x, ref y);                  
                    break;
                }

                case Keys.S:
                {
                    beenUsed = true;
                    this.game.Move(Movement.DOWN, ref x, ref y);
                    break;
                }

                case Keys.A:
                {
                    beenUsed = true;
                    this.game.Move(Movement.LEFT, ref x, ref y);
                    break;
                }

                case Keys.D:
                {
                    beenUsed = true;
                    this.game.Move(Movement.RIGHT, ref x, ref y);
                    break;
                }
            }

            if (x != -1 && beenUsed)
            {
                this.game.Output(this.cellsDispay, stepDisplay, scoreDisplay, recordDisplay, this.x2PriceDisplay, this.deletePriceDisplay, this.backPriceDisplay);
                ShowNewCell(x, y);
            }

        }

        private void Form1Closed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.saveRecord = this.game.GetRecord();
            Properties.Settings.Default.Save();
        }

        private void GoToMainPanelClick(object sender, EventArgs e)
        {
            if (selectedPanel == 1) return;
            
            if (this.selectedPanel == 4) this.panel4.Visible = false;
            if (this.selectedPanel == 3) this.panel3.Visible = false;
            if (this.selectedPanel == 2) this.panel2.Visible = false;

            this.selectedPanel = 1;
            this.panel1.Visible = true;      
        }

        private void GoToSavePanelClick(object sender, EventArgs e)
        {
            if (selectedPanel == 3) return;
           
            this.selectedSave = 0;
            this.ClearForUsingSaves();
            
            if (this.selectedPanel == 4) this.panel4.Visible = false;
            if (this.selectedPanel == 2) this.panel2.Visible = false;
            if (this.selectedPanel == 1) this.panel1.Visible = false;

            this.panel3.Visible = true;
            this.selectedPanel = 3;
        }

        private void GoToLoadPanelClick(object sender, EventArgs e)
        {
            if (selectedPanel == 4) return;
            
            this.ClearForUsingLoad();
            
            if (this.selectedPanel == 3) this.panel3.Visible = false;
            if (this.selectedPanel == 2) this.panel2.Visible = false;
            if (this.selectedPanel == 1) this.panel1.Visible = false;

            this.selectedPanel = 4;
            this.panel4.Visible = true;
        }
    }
}
