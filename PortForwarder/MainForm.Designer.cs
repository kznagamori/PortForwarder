namespace PortForwarder
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.ListDataGridView = new System.Windows.Forms.DataGridView();
			this.DisconnectButton = new System.Windows.Forms.Button();
			this.ConnectButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.EditButton = new System.Windows.Forms.Button();
			this.AddButton = new System.Windows.Forms.Button();
			this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.MainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).BeginInit();
			this.MainStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// ListDataGridView
			// 
			this.ListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.ListDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
			this.ListDataGridView.Location = new System.Drawing.Point(0, 46);
			this.ListDataGridView.Name = "ListDataGridView";
			this.ListDataGridView.RowTemplate.Height = 21;
			this.ListDataGridView.Size = new System.Drawing.Size(355, 395);
			this.ListDataGridView.TabIndex = 3;
			// 
			// DisconnectButton
			// 
			this.DisconnectButton.Image = global::PortForwarder.Properties.Resources.Scissors;
			this.DisconnectButton.Location = new System.Drawing.Point(40, 0);
			this.DisconnectButton.Name = "DisconnectButton";
			this.DisconnectButton.Size = new System.Drawing.Size(40, 40);
			this.DisconnectButton.TabIndex = 5;
			this.DisconnectButton.UseVisualStyleBackColor = true;
			this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
			// 
			// ConnectButton
			// 
			this.ConnectButton.Image = global::PortForwarder.Properties.Resources.connections;
			this.ConnectButton.Location = new System.Drawing.Point(0, 0);
			this.ConnectButton.Name = "ConnectButton";
			this.ConnectButton.Size = new System.Drawing.Size(40, 40);
			this.ConnectButton.TabIndex = 4;
			this.ConnectButton.UseVisualStyleBackColor = true;
			this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
			// 
			// DeleteButton
			// 
			this.DeleteButton.Image = global::PortForwarder.Properties.Resources.delete_item;
			this.DeleteButton.Location = new System.Drawing.Point(200, 0);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(40, 40);
			this.DeleteButton.TabIndex = 2;
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// EditButton
			// 
			this.EditButton.Image = global::PortForwarder.Properties.Resources.edit;
			this.EditButton.Location = new System.Drawing.Point(160, 0);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(40, 40);
			this.EditButton.TabIndex = 1;
			this.EditButton.UseVisualStyleBackColor = true;
			this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
			// 
			// AddButton
			// 
			this.AddButton.Image = global::PortForwarder.Properties.Resources.add_item;
			this.AddButton.Location = new System.Drawing.Point(120, 0);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(40, 40);
			this.AddButton.TabIndex = 0;
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// MainStatusStrip
			// 
			this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainToolStripStatusLabel});
			this.MainStatusStrip.Location = new System.Drawing.Point(0, 444);
			this.MainStatusStrip.Name = "MainStatusStrip";
			this.MainStatusStrip.Size = new System.Drawing.Size(355, 22);
			this.MainStatusStrip.TabIndex = 6;
			this.MainStatusStrip.Text = "statusStrip1";
			// 
			// MainToolStripStatusLabel
			// 
			this.MainToolStripStatusLabel.Name = "MainToolStripStatusLabel";
			this.MainToolStripStatusLabel.Size = new System.Drawing.Size(340, 17);
			this.MainToolStripStatusLabel.Spring = true;
			this.MainToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 466);
			this.Controls.Add(this.MainStatusStrip);
			this.Controls.Add(this.DisconnectButton);
			this.Controls.Add(this.ConnectButton);
			this.Controls.Add(this.ListDataGridView);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.AddButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(120, 80);
			this.Name = "MainForm";
			this.Text = "PortForwarder";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).EndInit();
			this.MainStatusStrip.ResumeLayout(false);
			this.MainStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.Button EditButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.DataGridView ListDataGridView;
		private System.Windows.Forms.Button ConnectButton;
		private System.Windows.Forms.Button DisconnectButton;
		private System.Windows.Forms.StatusStrip MainStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel MainToolStripStatusLabel;
	}
}

