using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_by_Hemok98
{
    class AchivementsPanel : Panel
    {
        //private string achiveName;
        //private string achivDescription;
        //private System.Drawing.Bitmap achivesImage;
        private Button imageDisplay;
        private Label nameDisplay;
        private Label DescriptionDisplay;
        public AchivementsPanel(string nam, string description, System.Drawing.Bitmap image, int xPos, int yPos) : base()
        {
            this.SuspendLayout();
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.Visible = true;
            this.Location = new System.Drawing.Point(xPos, yPos);
            this.Name = "achiv";
            this.Size = new System.Drawing.Size(560, 90);
            this.TabIndex = 5;


            this.imageDisplay = new Button();
            this.imageDisplay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imageDisplay.BackgroundImage = image;
            this.imageDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageDisplay.Location = new System.Drawing.Point(480, 10);
            this.imageDisplay.Name = "imageDisplay";
            this.imageDisplay.Size = new System.Drawing.Size(70, 70);
            this.imageDisplay.TabIndex = 14;
            this.imageDisplay.UseVisualStyleBackColor = false;
            this.Controls.Add(this.imageDisplay);

            this.nameDisplay = new Label();
            this.nameDisplay.ForeColor = System.Drawing.Color.MidnightBlue;
            this.nameDisplay.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameDisplay.Location = new System.Drawing.Point(12, 2);
            this.nameDisplay.Name = "";
            this.nameDisplay.Size = new System.Drawing.Size(490, 30);
            this.nameDisplay.TabIndex = 7;
            this.nameDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nameDisplay.Text = description;
            this.nameDisplay.Visible = true;
            this.Controls.Add(this.nameDisplay);
            //
            //this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            //this.label1.Location = new System.Drawing.Point(570, 74);
            //this.label1.Name = "label1";
            //this.label1.Size = new System.Drawing.Size(64, 22);
            //this.label1.TabIndex = 16;
            //this.label1.Text = "label1";
            //this.label1.UseWaitCursor = true;
            //
            this.DescriptionDisplay = new Label();
            this.DescriptionDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DescriptionDisplay.Location = new System.Drawing.Point(10, 35);
            this.DescriptionDisplay.Name = description;
            this.DescriptionDisplay.Size = new System.Drawing.Size(460, 60);
            this.DescriptionDisplay.TabIndex = 7;
            this.DescriptionDisplay.Text = nam;
            this.Controls.Add(this.DescriptionDisplay);

            this.ResumeLayout(false);
        }

        public void setColor()
        {

        }
    }
}
