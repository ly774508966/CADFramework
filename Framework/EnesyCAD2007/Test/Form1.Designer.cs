namespace EnesyCAD2007.Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxOwnerDraw1 = new Enesy.CAD.Framework.Controls.TextBoxOwnerDraw();
            this.SuspendLayout();
            // 
            // textBoxOwnerDraw1
            // 
            this.textBoxOwnerDraw1.AutoSize = true;
            this.textBoxOwnerDraw1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.textBoxOwnerDraw1.BackColor = System.Drawing.Color.Transparent;
            this.textBoxOwnerDraw1.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxOwnerDraw1.BorderSize = 0;
            this.textBoxOwnerDraw1.CornerRadius = 0;
            this.textBoxOwnerDraw1.Location = new System.Drawing.Point(29, 21);
            this.textBoxOwnerDraw1.Name = "textBoxOwnerDraw1";
            this.textBoxOwnerDraw1.PrefSize = new System.Drawing.Size(300, 40);
            this.textBoxOwnerDraw1.SearchWaterMark = "Search in: All columns";
            this.textBoxOwnerDraw1.Size = new System.Drawing.Size(303, 32);
            this.textBoxOwnerDraw1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 285);
            this.Controls.Add(this.textBoxOwnerDraw1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Enesy.CAD.Framework.Controls.TextBoxOwnerDraw textBoxOwnerDraw1;
    }
}