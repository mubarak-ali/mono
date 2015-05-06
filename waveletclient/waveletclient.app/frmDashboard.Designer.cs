/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 11:11 AM
 */
namespace waveletclient.app
{
	partial class frmDashboard
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
			this.btnCreateCompany = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCreateCompany
			// 
			this.btnCreateCompany.Location = new System.Drawing.Point(49, 179);
			this.btnCreateCompany.Name = "btnCreateCompany";
			this.btnCreateCompany.Size = new System.Drawing.Size(110, 23);
			this.btnCreateCompany.TabIndex = 0;
			this.btnCreateCompany.Text = "Create Company";
			this.btnCreateCompany.UseVisualStyleBackColor = true;
			this.btnCreateCompany.Click += new System.EventHandler(this.BtnCreateCompanyClick);
			// 
			// frmDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(673, 464);
			this.Controls.Add(this.btnCreateCompany);
			this.Name = "frmDashboard";
			this.Text = "Dashboard";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmDashboardLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnCreateCompany;
	}
}
