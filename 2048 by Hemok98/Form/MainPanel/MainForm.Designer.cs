using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private TButton[,] cellsDispay = new TButton[6, 6];
        private ToolTip toolTipsShower;

        private void MainPageInit()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            for (int i = 0; i < Game.MAXCELLS; i++)
            {
                for (int j = 0; j < Game.MAXCELLS; j++)
                {
                    this.cellsDispay[i, j] = new TButton();
                    //this.SuspendLayout();
                    this.cellsDispay[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    this.cellsDispay[i, j].Name = i.ToString() + j.ToString();
                    this.cellsDispay[i, j].TabIndex = 0;
                    this.cellsDispay[i, j].Text = "";
                    this.cellsDispay[i, j].UseVisualStyleBackColor = true;
                    this.pages[0].Controls.Add(this.cellsDispay[i, j]);
                    this.cellsDispay[i, j].Click += new System.EventHandler(this.CellsDisplayClick);
                    this.cellsDispay[i, j].BackColor = System.Drawing.Color.WhiteSmoke;
                }
            }
            this.SetCellsDiplay(4); //описана в Options.Action, отрисовывает сами кнопки
            this.pages[0].Visible = true;

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            this.KeyPreview = true;

            ///////////////////////////////////////////////////////////////
            
            this.rightButton = new System.Windows.Forms.Button();
            this.rightButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightButton.Location = new System.Drawing.Point(513, 90);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(40, 40);
            this.rightButton.TabIndex = 0;
            this.rightButton.Text = "→";
            this.rightButton.UseVisualStyleBackColor = false;
            this.rightButton.Click += new System.EventHandler(this.MoveButtonClick);
            this.pages[0].Controls.Add(this.rightButton);


            this.leftButton = new System.Windows.Forms.Button();
            this.leftButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftButton.Location = new System.Drawing.Point(433, 90);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(40, 40);
            this.leftButton.TabIndex = 2;
            this.leftButton.Text = "←";
            this.leftButton.UseVisualStyleBackColor = false;
            this.leftButton.Click += new System.EventHandler(this.MoveButtonClick);
            this.pages[0].Controls.Add(this.leftButton);


            this.upButton = new System.Windows.Forms.Button();
            this.upButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.upButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.upButton.Location = new System.Drawing.Point(473, 50);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(40, 40);
            this.upButton.TabIndex = 3;
            this.upButton.Text = "↑";
            this.upButton.UseVisualStyleBackColor = false;
            this.upButton.Click += new System.EventHandler(this.MoveButtonClick);
            this.pages[0].Controls.Add(this.upButton);


            this.downButton = new System.Windows.Forms.Button();
            this.downButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.downButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downButton.Location = new System.Drawing.Point(473, 130);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(40, 40);
            this.downButton.TabIndex = 4;
            this.downButton.Text = "↓";
            this.downButton.UseVisualStyleBackColor = false;
            this.downButton.Click += new System.EventHandler(this.MoveButtonClick);
            this.pages[0].Controls.Add(this.downButton);


            this.stepDisplay = new System.Windows.Forms.Label();
            this.stepDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepDisplay.Location = new System.Drawing.Point(6, 10);
            this.stepDisplay.Name = "stepDisplay";
            this.stepDisplay.Size = new System.Drawing.Size(120, 26);
            this.stepDisplay.TabIndex = 5;
            this.stepDisplay.Text = "Ход";
            this.stepDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pages[0].Controls.Add(this.stepDisplay);


            this.scoreDisplay = new System.Windows.Forms.Label();
            this.scoreDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreDisplay.Location = new System.Drawing.Point(132, 10);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(120, 26);
            this.scoreDisplay.TabIndex = 6;
            this.scoreDisplay.Text = "Счёт";
            this.scoreDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pages[0].Controls.Add(this.scoreDisplay);


            this.recordDisplay = new System.Windows.Forms.Label();
            this.recordDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recordDisplay.Location = new System.Drawing.Point(258, 9);
            this.recordDisplay.Name = "recordDisplay";
            this.recordDisplay.Size = new System.Drawing.Size(120, 26);
            this.recordDisplay.TabIndex = 7;
            this.recordDisplay.Text = "Рекорд";
            this.recordDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pages[0].Controls.Add(this.recordDisplay);


            this.restartButton = new System.Windows.Forms.Button();
            this.restartButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.restartButton.Location = new System.Drawing.Point(523, 138);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(30, 32);
            this.restartButton.TabIndex = 9;
            this.restartButton.Text = "R";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.RestartButtonClick);
            this.pages[0].Controls.Add(this.restartButton);


            this.x2PriceDisplay = new System.Windows.Forms.Label();
            this.x2PriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.x2PriceDisplay.Location = new System.Drawing.Point(425, 253);
            this.x2PriceDisplay.Name = "x2PriceDisplay";
            this.x2PriceDisplay.Size = new System.Drawing.Size(65, 20);
            this.x2PriceDisplay.TabIndex = 12;
            this.x2PriceDisplay.Text = "Цена";
            this.x2PriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pages[0].Controls.Add(this.x2PriceDisplay);


            this.deletePriceDisplay = new System.Windows.Forms.Label();
            this.deletePriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deletePriceDisplay.Location = new System.Drawing.Point(497, 253);
            this.deletePriceDisplay.Name = "deletePriceDisplay";
            this.deletePriceDisplay.Size = new System.Drawing.Size(65, 20);
            this.deletePriceDisplay.TabIndex = 13;
            this.deletePriceDisplay.Text = "Цена";
            this.deletePriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pages[0].Controls.Add(this.deletePriceDisplay);


            this.backPriceDisplay = new Label();
            this.backPriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backPriceDisplay.Location = new System.Drawing.Point(425, 344);
            this.backPriceDisplay.Name = "backPriceDisplay";
            this.backPriceDisplay.Size = new System.Drawing.Size(65, 20);
            this.backPriceDisplay.TabIndex = 15;
            this.backPriceDisplay.Text = "Цена";
            this.backPriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pages[0].Controls.Add(this.backPriceDisplay);


            this.swapPriceDisplay = new Label();
            this.swapPriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.swapPriceDisplay.Location = new System.Drawing.Point(497, 344);
            this.swapPriceDisplay.Name = "swapPriceDisplay";
            this.swapPriceDisplay.Size = new System.Drawing.Size(65, 20);
            this.swapPriceDisplay.TabIndex = 17;
            this.swapPriceDisplay.Text = "Цена";
            this.swapPriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pages[0].Controls.Add(this.swapPriceDisplay);


            this.swapButton = new Button();
            this.swapButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.swapButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("swapButton.BackgroundImage")));
            this.swapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.swapButton.Location = new System.Drawing.Point(497, 276);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(65, 65);
            this.swapButton.TabIndex = 16;
            this.swapButton.UseVisualStyleBackColor = false;
            this.swapButton.Click += new System.EventHandler(this.SwapButtonClick);
            this.pages[0].Controls.Add(this.swapButton);


            this.backButton = new Button();
            this.backButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.backButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backButton.BackgroundImage")));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(425, 276);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(65, 65);
            this.backButton.TabIndex = 14;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButtonClick);
            this.pages[0].Controls.Add(this.backButton);


            this.deleteButton = new Button();
            this.deleteButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(497, 185);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(65, 65);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            this.pages[0].Controls.Add(this.deleteButton);


            this.x2Button = new Button();
            this.x2Button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.x2Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("x2Button.BackgroundImage")));
            this.x2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2Button.Location = new System.Drawing.Point(425, 185);
            this.x2Button.Name = "x2Button";
            this.x2Button.Size = new System.Drawing.Size(65, 65);
            this.x2Button.TabIndex = 10;
            this.x2Button.UseVisualStyleBackColor = false;
            this.x2Button.Click += new System.EventHandler(this.X2ButtonClick);
            this.pages[0].Controls.Add(this.x2Button);


            this.components = new System.ComponentModel.Container();
            this.toolTipsShower = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipsShower.SetToolTip(this.backButton, "Вернуть на ход назад");
            this.toolTipsShower.SetToolTip(this.deleteButton, "Обнулить ячейку");
            this.toolTipsShower.SetToolTip(this.x2Button, "Удвоить ячейку");
        }

        private void InitForm()
        {

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SuspendLayout();
            this.goToOptionsPanelButton = new System.Windows.Forms.Button();
            this.goToMainPanelButton = new System.Windows.Forms.Button();
            this.goToSavePanelButton = new System.Windows.Forms.Button();
            this.goToLoadPanelButton = new System.Windows.Forms.Button();
            this.goToAchivesPanelButton = new System.Windows.Forms.Button();


            int xSize = 117;

            this.goToOptionsPanelButton.BackColor = System.Drawing.Color.LightGray;
            this.goToOptionsPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goToOptionsPanelButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.goToOptionsPanelButton.ForeColor = System.Drawing.Color.DarkRed;
            this.goToOptionsPanelButton.Location = new System.Drawing.Point(xSize, 0);
            this.goToOptionsPanelButton.Name = "goToOptionsPanelButton";
            this.goToOptionsPanelButton.Size = new System.Drawing.Size(xSize, 30);
            this.goToOptionsPanelButton.TabIndex = 17;
            this.goToOptionsPanelButton.Text = "Настройки";
            this.goToOptionsPanelButton.UseVisualStyleBackColor = true;
            this.goToOptionsPanelButton.Click += new System.EventHandler(this.GoToPage);

            // 
            this.goToMainPanelButton.BackColor = System.Drawing.Color.LightGray;
            this.goToMainPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goToMainPanelButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.goToMainPanelButton.ForeColor = System.Drawing.Color.DarkRed;
            this.goToMainPanelButton.Location = new System.Drawing.Point(0, 0);
            this.goToMainPanelButton.Name = "goToMainPanelButton";
            this.goToMainPanelButton.Size = new System.Drawing.Size(xSize, 30);
            this.goToMainPanelButton.TabIndex = 19;
            this.goToMainPanelButton.Text = "Игра";
            this.goToMainPanelButton.UseVisualStyleBackColor = true;
            this.goToMainPanelButton.Click += new System.EventHandler(this.GoToPage);
            // 
            // goToSavePanelButton
            // 
            this.goToSavePanelButton.BackColor = System.Drawing.Color.LightGray;
            this.goToSavePanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goToSavePanelButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.goToSavePanelButton.ForeColor = System.Drawing.Color.DarkRed;
            this.goToSavePanelButton.Location = new System.Drawing.Point(xSize*2, 0);
            this.goToSavePanelButton.Name = "goToSavePanelButton";
            this.goToSavePanelButton.Size = new System.Drawing.Size(xSize, 30);
            this.goToSavePanelButton.TabIndex = 20;
            this.goToSavePanelButton.Text = "Сохранить";
            this.goToSavePanelButton.UseVisualStyleBackColor = true;
            this.goToSavePanelButton.Click += new System.EventHandler(this.GoToPage);
            // 
            // goToLoadPanelButton
            // 
            this.goToLoadPanelButton.BackColor = System.Drawing.Color.LightGray;
            this.goToLoadPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goToLoadPanelButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.goToLoadPanelButton.ForeColor = System.Drawing.Color.DarkRed;
            this.goToLoadPanelButton.Location = new System.Drawing.Point(xSize*3, 0);
            this.goToLoadPanelButton.Name = "goToLoadPanelButton";
            this.goToLoadPanelButton.Size = new System.Drawing.Size(xSize, 30);
            this.goToLoadPanelButton.TabIndex = 21;
            this.goToLoadPanelButton.Text = "Загрузить";
            this.goToLoadPanelButton.UseVisualStyleBackColor = true;
            this.goToLoadPanelButton.Click += new System.EventHandler(this.GoToPage);
            //
            ///
            this.goToAchivesPanelButton.BackColor = System.Drawing.Color.LightGray;
            this.goToAchivesPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goToAchivesPanelButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.goToAchivesPanelButton.ForeColor = System.Drawing.Color.DarkRed;
            this.goToAchivesPanelButton.Location = new System.Drawing.Point(xSize*4, 0);
            this.goToAchivesPanelButton.Name = "goToAchivesPanelButton";
            this.goToAchivesPanelButton.Size = new System.Drawing.Size(xSize, 30);
            this.goToAchivesPanelButton.TabIndex = 21;
            this.goToAchivesPanelButton.Text = "Достижения";
            this.goToAchivesPanelButton.UseVisualStyleBackColor = true;
            this.goToAchivesPanelButton.Click += new System.EventHandler(this.GoToPage);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.goToLoadPanelButton);
            this.Controls.Add(this.goToSavePanelButton);
            this.Controls.Add(this.goToMainPanelButton);
            this.Controls.Add(this.goToOptionsPanelButton);
            this.Controls.Add(this.goToAchivesPanelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 550);
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048 by Hemok98";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1Closed);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Label stepDisplay;
        private System.Windows.Forms.Label scoreDisplay;
        private System.Windows.Forms.Label recordDisplay;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button x2Button;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label x2PriceDisplay;
        private System.Windows.Forms.Label deletePriceDisplay;
        private System.Windows.Forms.Label backPriceDisplay;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button goToOptionsPanelButton;
        private System.Windows.Forms.Button goToMainPanelButton;
        private System.Windows.Forms.Button goToSavePanelButton;
        private System.Windows.Forms.Button goToLoadPanelButton;
        private System.Windows.Forms.Button goToAchivesPanelButton;
        private Label swapPriceDisplay;
        private Button swapButton;
    }
}

