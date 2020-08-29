namespace BestJoke
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

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.timerReadKeys = new System.Windows.Forms.Timer(this.components);
			this.timerMouseMove = new System.Windows.Forms.Timer(this.components);
			this.timerOpenWindow = new System.Windows.Forms.Timer(this.components);
			this.timerSiteOpen = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(93, 192);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(422, 49);
			this.label1.TabIndex = 0;
			this.label1.Text = "Доброго ранку і вам";
			// 
			// timerReadKeys
			// 
			this.timerReadKeys.Enabled = true;
			this.timerReadKeys.Tick += new System.EventHandler(this.timerReadKeys_Tick);
			// 
			// timerMouseMove
			// 
			this.timerMouseMove.Enabled = true;
			this.timerMouseMove.Tick += new System.EventHandler(this.timerMouseMove_Tick);
			// 
			// timerOpenWindow
			// 
			this.timerOpenWindow.Enabled = true;
			this.timerOpenWindow.Interval = 1000;
			this.timerOpenWindow.Tick += new System.EventHandler(this.timerOpenWindow_Tick);
			// 
			// timerSiteOpen
			// 
			this.timerSiteOpen.Enabled = true;
			this.timerSiteOpen.Interval = 5000;
			this.timerSiteOpen.Tick += new System.EventHandler(this.timerSiteOpen_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 441);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Good morning";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timerReadKeys;
		private System.Windows.Forms.Timer timerMouseMove;
		private System.Windows.Forms.Timer timerOpenWindow;
		private System.Windows.Forms.Timer timerSiteOpen;
	}
}

