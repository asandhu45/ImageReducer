namespace Review_Lab1
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
            this.UI_PicBox = new System.Windows.Forms.PictureBox();
            this.ThreshVal_Label = new System.Windows.Forms.Label();
            this.UI_ReduceVal_lbl = new System.Windows.Forms.Label();
            this.UI_Reduce_Btn = new System.Windows.Forms.Button();
            this.UI_ColorNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_PicBox
            // 
            this.UI_PicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_PicBox.BackColor = System.Drawing.Color.FloralWhite;
            this.UI_PicBox.Location = new System.Drawing.Point(9, 39);
            this.UI_PicBox.Margin = new System.Windows.Forms.Padding(2);
            this.UI_PicBox.Name = "UI_PicBox";
            this.UI_PicBox.Size = new System.Drawing.Size(616, 372);
            this.UI_PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UI_PicBox.TabIndex = 0;
            this.UI_PicBox.TabStop = false;
            // 
            // ThreshVal_Label
            // 
            this.ThreshVal_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ThreshVal_Label.AutoSize = true;
            this.ThreshVal_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreshVal_Label.Location = new System.Drawing.Point(274, 7);
            this.ThreshVal_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ThreshVal_Label.Name = "ThreshVal_Label";
            this.ThreshVal_Label.Size = new System.Drawing.Size(149, 20);
            this.ThreshVal_Label.TabIndex = 1;
            this.ThreshVal_Label.Text = "Threshold Value :";
            // 
            // UI_ReduceVal_lbl
            // 
            this.UI_ReduceVal_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_ReduceVal_lbl.BackColor = System.Drawing.SystemColors.Info;
            this.UI_ReduceVal_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_ReduceVal_lbl.ForeColor = System.Drawing.Color.Black;
            this.UI_ReduceVal_lbl.Location = new System.Drawing.Point(416, 7);
            this.UI_ReduceVal_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UI_ReduceVal_lbl.Name = "UI_ReduceVal_lbl";
            this.UI_ReduceVal_lbl.Size = new System.Drawing.Size(122, 24);
            this.UI_ReduceVal_lbl.TabIndex = 2;
            this.UI_ReduceVal_lbl.Text = "10";
            this.UI_ReduceVal_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_Reduce_Btn
            // 
            this.UI_Reduce_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Reduce_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Reduce_Btn.Location = new System.Drawing.Point(542, 3);
            this.UI_Reduce_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.UI_Reduce_Btn.Name = "UI_Reduce_Btn";
            this.UI_Reduce_Btn.Size = new System.Drawing.Size(82, 31);
            this.UI_Reduce_Btn.TabIndex = 3;
            this.UI_Reduce_Btn.Text = "Reduce !";
            this.UI_Reduce_Btn.UseVisualStyleBackColor = true;
            this.UI_Reduce_Btn.Click += new System.EventHandler(this.UI_Reduce_Btn_Click);
            // 
            // UI_ColorNum
            // 
            this.UI_ColorNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_ColorNum.AutoSize = true;
            this.UI_ColorNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_ColorNum.Location = new System.Drawing.Point(9, 414);
            this.UI_ColorNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UI_ColorNum.Name = "UI_ColorNum";
            this.UI_ColorNum.Size = new System.Drawing.Size(245, 17);
            this.UI_ColorNum.TabIndex = 4;
            this.UI_ColorNum.Text = "There\'s no picture to find colors!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 432);
            this.Controls.Add(this.UI_ColorNum);
            this.Controls.Add(this.UI_Reduce_Btn);
            this.Controls.Add(this.UI_ReduceVal_lbl);
            this.Controls.Add(this.ThreshVal_Label);
            this.Controls.Add(this.UI_PicBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "ImageReducer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UI_PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UI_PicBox;
        private System.Windows.Forms.Label ThreshVal_Label;
        private System.Windows.Forms.Label UI_ReduceVal_lbl;
        private System.Windows.Forms.Button UI_Reduce_Btn;
        private System.Windows.Forms.Label UI_ColorNum;
    }
}

