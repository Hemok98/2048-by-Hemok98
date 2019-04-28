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

        private System.Windows.Forms.Button[,] cellsDispay = new System.Windows.Forms.Button[6, 6];

        private void MyInitializeComponent()
        {
            for (int i = 0; i < Game.MAXCELLS; i++)
            {
                for (int j = 0; j < Game.MAXCELLS; j++)
                {
                    int xStart = 10; 
                    int yStart = 50; 
                    int size = 90;
                    int indent = 10;

                    this.cellsDispay[i, j] = new System.Windows.Forms.Button();
                    //this.SuspendLayout();
                    this.cellsDispay[i, j].Location = new System.Drawing.Point(xStart + i*(size + indent), yStart +  j*(size + indent));
                    this.cellsDispay[i,j].Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    this.cellsDispay[i, j].Name = i.ToString() + j.ToString();
                    this.cellsDispay[i, j].Size = new System.Drawing.Size(size, size);
                    this.cellsDispay[i, j].TabIndex = 0;
                    this.cellsDispay[i, j].Text = "";
                    this.cellsDispay[i, j].UseVisualStyleBackColor = true;
                    this.Controls.Add(this.cellsDispay[i, j]);
                    this.cellsDispay[i, j].Click += new System.EventHandler(this.CellsDisplayClick);
                    this.cellsDispay[i,j].BackColor = System.Drawing.Color.WhiteSmoke;
                    //this.cellsDispay[i, j].Click += new System.EventHandler(this.RightButtonClick);
                    //this.ResumeLayout(false);
                    //this.PerformLayout();
                }
            }
        }

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.restartButton = new System.Windows.Forms.Button();
            this.x2PriceDisplay = new System.Windows.Forms.Label();
            this.deletePriceDisplay = new System.Windows.Forms.Label();
            this.backPriceDisplay = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.x2Button = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rightButton
            // 
            this.rightButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightButton.Location = new System.Drawing.Point(520, 80);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(40, 40);
            this.rightButton.TabIndex = 0;
            this.rightButton.Text = "→";
            this.rightButton.UseVisualStyleBackColor = false;
            this.rightButton.Click += new System.EventHandler(this.RightButtonClick);
            // 
            // leftButton
            // 
            this.leftButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftButton.Location = new System.Drawing.Point(440, 80);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(40, 40);
            this.leftButton.TabIndex = 2;
            this.leftButton.Text = "←";
            this.leftButton.UseVisualStyleBackColor = false;
            this.leftButton.Click += new System.EventHandler(this.LeftButtonClick);
            // 
            // upButton
            // 
            this.upButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.upButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.upButton.Location = new System.Drawing.Point(480, 40);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(40, 40);
            this.upButton.TabIndex = 3;
            this.upButton.Text = "↑";
            this.upButton.UseVisualStyleBackColor = false;
            this.upButton.Click += new System.EventHandler(this.UpButtonClick);
            // 
            // downButton
            // 
            this.downButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.downButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downButton.Location = new System.Drawing.Point(480, 120);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(40, 40);
            this.downButton.TabIndex = 4;
            this.downButton.Text = "↓";
            this.downButton.UseVisualStyleBackColor = false;
            this.downButton.Click += new System.EventHandler(this.DownButtonClick);
            // 
            // stepDisplay
            // 
            this.stepDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepDisplay.Location = new System.Drawing.Point(7, 10);
            this.stepDisplay.Name = "stepDisplay";
            this.stepDisplay.Size = new System.Drawing.Size(120, 26);
            this.stepDisplay.TabIndex = 5;
            this.stepDisplay.Text = "Ход";
            this.stepDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreDisplay
            // 
            this.scoreDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreDisplay.Location = new System.Drawing.Point(133, 10);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(120, 26);
            this.scoreDisplay.TabIndex = 6;
            this.scoreDisplay.Text = "Счёт";
            this.scoreDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // recordDisplay
            // 
            this.recordDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recordDisplay.Location = new System.Drawing.Point(259, 9);
            this.recordDisplay.Name = "recordDisplay";
            this.recordDisplay.Size = new System.Drawing.Size(120, 26);
            this.recordDisplay.TabIndex = 7;
            this.recordDisplay.Text = "Рекорд";
            this.recordDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(674, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 454);
            this.textBox1.TabIndex = 8;
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.restartButton.Location = new System.Drawing.Point(530, 128);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(30, 32);
            this.restartButton.TabIndex = 9;
            this.restartButton.Text = "R";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.RestartButtonClick);
            // 
            // x2PriceDisplay
            // 
            this.x2PriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x2PriceDisplay.Location = new System.Drawing.Point(477, 185);
            this.x2PriceDisplay.Name = "x2PriceDisplay";
            this.x2PriceDisplay.Size = new System.Drawing.Size(171, 48);
            this.x2PriceDisplay.TabIndex = 12;
            this.x2PriceDisplay.Text = "Цена:";
            this.x2PriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deletePriceDisplay
            // 
            this.deletePriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deletePriceDisplay.Location = new System.Drawing.Point(477, 237);
            this.deletePriceDisplay.Name = "deletePriceDisplay";
            this.deletePriceDisplay.Size = new System.Drawing.Size(171, 48);
            this.deletePriceDisplay.TabIndex = 13;
            this.deletePriceDisplay.Text = "Цена:";
            this.deletePriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backPriceDisplay
            // 
            this.backPriceDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backPriceDisplay.Location = new System.Drawing.Point(477, 293);
            this.backPriceDisplay.Name = "backPriceDisplay";
            this.backPriceDisplay.Size = new System.Drawing.Size(171, 48);
            this.backPriceDisplay.TabIndex = 15;
            this.backPriceDisplay.Text = "Цена:";
            this.backPriceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.backButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backButton.BackgroundImage")));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(423, 293);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(48, 48);
            this.backButton.TabIndex = 14;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DeleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BackgroundImage")));
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Location = new System.Drawing.Point(423, 239);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(48, 48);
            this.DeleteButton.TabIndex = 11;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // x2Button
            // 
            this.x2Button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.x2Button.BackgroundImage = global::_2048_by_Hemok98.Properties.Resources.x2PNG;
            this.x2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x2Button.Location = new System.Drawing.Point(423, 185);
            this.x2Button.Name = "x2Button";
            this.x2Button.Size = new System.Drawing.Size(48, 48);
            this.x2Button.TabIndex = 10;
            this.x2Button.UseVisualStyleBackColor = false;
            this.x2Button.Click += new System.EventHandler(this.X2ButtonClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(573, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 30);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Отображение\r\n Нового";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.ChangeShowNewCells);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(766, 463);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.backPriceDisplay);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.deletePriceDisplay);
            this.Controls.Add(this.x2PriceDisplay);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.x2Button);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.recordDisplay);
            this.Controls.Add(this.scoreDisplay);
            this.Controls.Add(this.stepDisplay);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightButton);
            this.MaximumSize = new System.Drawing.Size(782, 502);
            this.MinimumSize = new System.Drawing.Size(782, 502);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Label stepDisplay;
        private System.Windows.Forms.Label scoreDisplay;
        private System.Windows.Forms.Label recordDisplay;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button x2Button;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label x2PriceDisplay;
        private System.Windows.Forms.Label deletePriceDisplay;
        private System.Windows.Forms.Label backPriceDisplay;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

