﻿/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 10:43 AM
 */
namespace waveletclient.app
{
	partial class fmMain
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblCompany = new System.Windows.Forms.Label();
			this.lblSystem = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.btnNext = new System.Windows.Forms.Button();
			this.lblUsername = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblCompany
			// 
			this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCompany.Location = new System.Drawing.Point(45, 73);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new System.Drawing.Size(121, 21);
			this.lblCompany.TabIndex = 0;
			this.lblCompany.Text = "Select Company";
			// 
			// lblSystem
			// 
			this.lblSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSystem.Location = new System.Drawing.Point(45, 100);
			this.lblSystem.Name = "lblSystem";
			this.lblSystem.Size = new System.Drawing.Size(109, 21);
			this.lblSystem.TabIndex = 1;
			this.lblSystem.Text = "Select System";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(172, 73);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(191, 21);
			this.comboBox1.TabIndex = 2;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(172, 100);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(191, 21);
			this.comboBox2.TabIndex = 3;
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(172, 138);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(51, 23);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			// 
			// lblUsername
			// 
			this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsername.Location = new System.Drawing.Point(417, 9);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(100, 23);
			this.lblUsername.TabIndex = 5;
			// 
			// fmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(529, 309);
			this.Controls.Add(this.lblUsername);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.lblSystem);
			this.Controls.Add(this.lblCompany);
			this.MaximizeBox = false;
			this.Name = "fmMain";
			this.Text = "Main Form";
			this.Load += new System.EventHandler(this.FmMainLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label lblSystem;
		private System.Windows.Forms.Label lblCompany;
	}
}