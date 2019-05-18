using System;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    partial class Form1
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

        private System.Windows.Forms.Panel[] pages = new System.Windows.Forms.Panel[10];

        /*private void PagesInitialize()
        {
            for (int i = 0; i < 10; i++)
            {
                this.pages[i] = new System.Windows.Forms.Panel();
                this.pages[i].Visible = false;
                this.pages[i].Location = new System.Drawing.Point(0, 30);
                this.pages[i].Name = "panel" + i.ToString();
                this.pages[i].Size = new System.Drawing.Size(774, 480);
                this.pages[i].TabIndex = 18;
                this.Controls.Add(this.pages[i]);
            }

            //MAIN PAGE
            this.pages[0].Controls.Add(this.backPriceDisplay);
            this.pages[0].Controls.Add(this.backButton);
            this.pages[0].Controls.Add(this.deletePriceDisplay);
            this.pages[0].Controls.Add(this.x2PriceDisplay);
            this.pages[0].Controls.Add(this.deleteButton);
            this.pages[0].Controls.Add(this.x2Button);
            this.pages[0].Controls.Add(this.restartButton);
            this.pages[0].Controls.Add(this.recordDisplay);
            this.pages[0].Controls.Add(this.scoreDisplay);
            this.pages[0].Controls.Add(this.stepDisplay);
            this.pages[0].Controls.Add(this.downButton);
            this.pages[0].Controls.Add(this.upButton);
            this.pages[0].Controls.Add(this.leftButton);
            this.pages[0].Controls.Add(this.rightButton);
        } */

        private TButton[,] cellsDispay = new TButton[6, 6];

        private void MyInitializeComponent()
        {
            int xStart = 10; 
            int yStart = 50; 
            int size = 90;
            int indent = 10;
            for (int i = 0; i < Game.MAXCELLS; i++)
            {
                for (int j = 0; j < Game.MAXCELLS; j++)
                {
                    this.cellsDispay[i, j] = new TButton();
                    //this.SuspendLayout();
                    this.cellsDispay[i, j].Location = new System.Drawing.Point(xStart + j*(size + indent), yStart +  i*(size + indent));
                    this.cellsDispay[i,j].Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    this.cellsDispay[i, j].Name = i.ToString() + j.ToString();
                    this.cellsDispay[i, j].Size = new System.Drawing.Size(size, size);
                    this.cellsDispay[i, j].TabIndex = 0;
                    this.cellsDispay[i, j].Text = "";
                    this.cellsDispay[i, j].UseVisualStyleBackColor = true;
                    this.panel1.Controls.Add(this.cellsDispay[i, j]);
                    this.cellsDispay[i, j].Click += new System.EventHandler(this.CellsDisplayClick);
                    this.cellsDispay[i,j].BackColor = System.Drawing.Color.WhiteSmoke;
                }
            }

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            this.KeyPreview = true;

            this.components = new System.ComponentModel.Container();
            this.toolTipsShower = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipsShower.SetToolTip(this.backButton, "Вернуть на ход назад");
            this.toolTipsShower.SetToolTip(this.deleteButton, "Обнулить ячейку");
            this.toolTipsShower.SetToolTip(this.x2Button, "Удвоить ячейку");
        }

        private ToolTip toolTipsShower;

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rightButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.stepDisplay = new System.Windows.Forms.Label();
            this.scoreDisplay = new System.Windows.Forms.Label();
            this.recordDisplay = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.x2PriceDisplay = new System.Windows.Forms.Label();
            this.deletePriceDisplay = new System.Windows.Forms.Label();
            this.backPriceDisplay = new System.Windows.Forms.Label();
            this.goToOptionsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.x2Button = new System.Windows.Forms.Button();
            this.goToMainPanelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightButton
            // 
            this.rightButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightButton.Location = new System.Drawing.Point(500, 90);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(40, 40);
            this.rightButton.TabIndex = 0;
            this.rightButton.Text = "→";
            this.rightButton.UseVisualStyleBackColor = false;
            this.rightButton.Click += new System.EventHandler(this.MoveButtonClick);
            // 
            // leftButton
            // 
            this.leftButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftButton.Location = new System.Drawing.Point(420, 90);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(40, 40);
            this.leftButton.TabIndex = 2;
            this.leftButton.Text = "←";
            this.leftButton.UseVisualStyleBackColor = false;
            this.leftButton.Click += new System.EventHandler(this.MoveButtonClick);
            // 
            // upButton
            // 
            this.upButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.upButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.upButton.Location = new System.Drawing.Point(460, 50);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(40, 40);
            this.upButton.TabIndex = 3;
            this.upButton.Text = "↑";
            this.upButton.UseVisualStyleBackColor = false;
            this.upButton.Click += new System.EventHandler(this.MoveButtonClick);
            // 
            // downButton
            // 
            this.downButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.downButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downButton.Location = new System.Drawing.Point(460, 130);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(40, 40);
            this.downButton.TabIndex = 4;
            this.downButton.Text = "↓";
            this.downButton.UseVisualStyleBackColor = false;
            this.downButton.Click += new System.EventHandler(this.MoveButtonClick);
            // 
            // stepDisplay
            // 
            this.stepDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepDisplay.Location = new System.Drawing.Point(6, 10);
            this.stepDisplay.Name = "stepDisplay";
            this.stepDisplay.Size = new System.Drawing.Size(120, 26);
            this.stepDisplay.TabIndex = 5;
            this.stepDisplay.Text = "Ход";
            this.stepDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreDisplay
            // 
            this.scoreDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreDisplay.Location = new System.Drawing.Point(132, 10);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(120, 26);
            this.scoreDisplay.TabIndex = 6;
            this.scoreDisplay.Text = "Счёт";
            this.scoreDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // recordDisplay
            // 
            this.recordDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recordDisplay.Location = new System.Drawing.Point(258, 9);
            this.recordDisplay.Name = "recordDisplay";
            this.recordDisplay.Size = new System.Drawing.Size(120, 26);
            this.recordDisplay.TabIndex = 7;
            this.recordDisplay.Text = "Рекорд";
            this.recordDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.restartButton.Location = new System.Drawing.Point(510, 138);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(30, 32);
            this.restartButton.TabIndex = 9;
            this.restartButton.Text = "R";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.RestartButtonClick);
            // 
            // x2PriceDisplay
            // 
            this.x2PriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.x2PriceDisplay.Location = new System.Drawing.Point(420, 253);
            this.x2PriceDisplay.Name = "x2PriceDisplay";
            this.x2PriceDisplay.Size = new System.Drawing.Size(65, 20);
            this.x2PriceDisplay.TabIndex = 12;
            this.x2PriceDisplay.Text = "Цена";
            this.x2PriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deletePriceDisplay
            // 
            this.deletePriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deletePriceDisplay.Location = new System.Drawing.Point(492, 253);
            this.deletePriceDisplay.Name = "deletePriceDisplay";
            this.deletePriceDisplay.Size = new System.Drawing.Size(65, 20);
            this.deletePriceDisplay.TabIndex = 13;
            this.deletePriceDisplay.Text = "Цена";
            this.deletePriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backPriceDisplay
            // 
            this.backPriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backPriceDisplay.Location = new System.Drawing.Point(420, 344);
            this.backPriceDisplay.Name = "backPriceDisplay";
            this.backPriceDisplay.Size = new System.Drawing.Size(65, 20);
            this.backPriceDisplay.TabIndex = 15;
            this.backPriceDisplay.Text = "Цена";
            this.backPriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // goToOptionsButton
            // 
            this.goToOptionsButton.BackColor = System.Drawing.Color.LightGray;
            this.goToOptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goToOptionsButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.goToOptionsButton.ForeColor = System.Drawing.Color.DarkRed;
            this.goToOptionsButton.Location = new System.Drawing.Point(100, 0);
            this.goToOptionsButton.Name = "goToOptionsButton";
            this.goToOptionsButton.Size = new System.Drawing.Size(100, 30);
            this.goToOptionsButton.TabIndex = 17;
            this.goToOptionsButton.Text = "Настройки";
            this.goToOptionsButton.UseVisualStyleBackColor = true;
            this.goToOptionsButton.Click += new System.EventHandler(this.GoToOptionsClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.backPriceDisplay);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.deletePriceDisplay);
            this.panel1.Controls.Add(this.x2PriceDisplay);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.x2Button);
            this.panel1.Controls.Add(this.restartButton);
            this.panel1.Controls.Add(this.recordDisplay);
            this.panel1.Controls.Add(this.scoreDisplay);
            this.panel1.Controls.Add(this.stepDisplay);
            this.panel1.Controls.Add(this.downButton);
            this.panel1.Controls.Add(this.upButton);
            this.panel1.Controls.Add(this.leftButton);
            this.panel1.Controls.Add(this.rightButton);
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 480);
            this.panel1.TabIndex = 18;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.backButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backButton.BackgroundImage")));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(420, 276);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(65, 65);
            this.backButton.TabIndex = 14;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(492, 185);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(65, 65);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // x2Button
            // 
            this.x2Button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.x2Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("x2Button.BackgroundImage")));
            this.x2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2Button.Location = new System.Drawing.Point(420, 185);
            this.x2Button.Name = "x2Button";
            this.x2Button.Size = new System.Drawing.Size(65, 65);
            this.x2Button.TabIndex = 10;
            this.x2Button.UseVisualStyleBackColor = false;
            this.x2Button.Click += new System.EventHandler(this.X2ButtonClick);
            // 
            // goToMainPanelButton
            // 
            this.goToMainPanelButton.BackColor = System.Drawing.Color.LightGray;
            this.goToMainPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goToMainPanelButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.goToMainPanelButton.ForeColor = System.Drawing.Color.DarkRed;
            this.goToMainPanelButton.Location = new System.Drawing.Point(0, 0);
            this.goToMainPanelButton.Name = "goToMainPanelButton";
            this.goToMainPanelButton.Size = new System.Drawing.Size(100, 30);
            this.goToMainPanelButton.TabIndex = 19;
            this.goToMainPanelButton.Text = "Игра";
            this.goToMainPanelButton.UseVisualStyleBackColor = true;
            this.goToMainPanelButton.Click += new System.EventHandler(this.GoToMainPanelClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(200, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 20;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GoToSavePanelClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Location = new System.Drawing.Point(300, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 21;
            this.button2.Text = "Загрузить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.GoToLoadPanelClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(774, 511);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.goToMainPanelButton);
            this.Controls.Add(this.goToOptionsButton);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(790, 550);
            this.MinimumSize = new System.Drawing.Size(790, 550);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048 by Hemok98";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1Closed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Button goToOptionsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button goToMainPanelButton;
        private Button button1;
        private Button button2;
    }
}

