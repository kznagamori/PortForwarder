namespace PortForwarder
{
	partial class EditList
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

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.CommitButton = new System.Windows.Forms.Button();
			this.BackButton = new System.Windows.Forms.Button();
			this.KeyOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.SettingNameTextBox = new System.Windows.Forms.TextBox();
			this.ServerNameTextBox = new System.Windows.Forms.TextBox();
			this.ServerPortTextBox = new System.Windows.Forms.TextBox();
			this.LocalPortTextBox = new System.Windows.Forms.TextBox();
			this.ForwardPortTextBox = new System.Windows.Forms.TextBox();
			this.UserNameTextBox = new System.Windows.Forms.TextBox();
			this.KeyPathTextBox = new System.Windows.Forms.TextBox();
			this.KeyPasswordTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// CommitButton
			// 
			this.CommitButton.Image = global::PortForwarder.Properties.Resources.circle_check_3x;
			this.CommitButton.Location = new System.Drawing.Point(40, 0);
			this.CommitButton.Name = "CommitButton";
			this.CommitButton.Size = new System.Drawing.Size(40, 40);
			this.CommitButton.TabIndex = 1;
			this.CommitButton.UseVisualStyleBackColor = true;
			this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
			// 
			// BackButton
			// 
			this.BackButton.Image = global::PortForwarder.Properties.Resources.chevron_left_3x;
			this.BackButton.Location = new System.Drawing.Point(0, 0);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(40, 40);
			this.BackButton.TabIndex = 0;
			this.BackButton.UseVisualStyleBackColor = true;
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// KeyOpenFileDialog
			// 
			this.KeyOpenFileDialog.FileName = "openFileDialog1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "設定名";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "サーバー名";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 97);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "サーバーポート番号";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 122);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(95, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "ローカルポート番号";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(4, 147);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(81, 12);
			this.label5.TabIndex = 6;
			this.label5.Text = "転送ポート番号";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 172);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 12);
			this.label6.TabIndex = 7;
			this.label6.Text = "ユーザー名";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(4, 197);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 12);
			this.label7.TabIndex = 8;
			this.label7.Text = "SSHキー";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(4, 222);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(52, 12);
			this.label8.TabIndex = 9;
			this.label8.Text = "パスワード";
			// 
			// SettingNameTextBox
			// 
			this.SettingNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingNameTextBox.Location = new System.Drawing.Point(65, 44);
			this.SettingNameTextBox.Name = "SettingNameTextBox";
			this.SettingNameTextBox.Size = new System.Drawing.Size(188, 19);
			this.SettingNameTextBox.TabIndex = 10;
			// 
			// ServerNameTextBox
			// 
			this.ServerNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ServerNameTextBox.Location = new System.Drawing.Point(65, 69);
			this.ServerNameTextBox.Name = "ServerNameTextBox";
			this.ServerNameTextBox.Size = new System.Drawing.Size(188, 19);
			this.ServerNameTextBox.TabIndex = 11;
			// 
			// ServerPortTextBox
			// 
			this.ServerPortTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ServerPortTextBox.Location = new System.Drawing.Point(107, 94);
			this.ServerPortTextBox.Name = "ServerPortTextBox";
			this.ServerPortTextBox.Size = new System.Drawing.Size(146, 19);
			this.ServerPortTextBox.TabIndex = 12;
			// 
			// LocalPortTextBox
			// 
			this.LocalPortTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LocalPortTextBox.Location = new System.Drawing.Point(107, 119);
			this.LocalPortTextBox.Name = "LocalPortTextBox";
			this.LocalPortTextBox.Size = new System.Drawing.Size(146, 19);
			this.LocalPortTextBox.TabIndex = 13;
			// 
			// ForwardPortTextBox
			// 
			this.ForwardPortTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ForwardPortTextBox.Location = new System.Drawing.Point(107, 144);
			this.ForwardPortTextBox.Name = "ForwardPortTextBox";
			this.ForwardPortTextBox.Size = new System.Drawing.Size(146, 19);
			this.ForwardPortTextBox.TabIndex = 14;
			// 
			// UserNameTextBox
			// 
			this.UserNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UserNameTextBox.Location = new System.Drawing.Point(70, 169);
			this.UserNameTextBox.Name = "UserNameTextBox";
			this.UserNameTextBox.Size = new System.Drawing.Size(183, 19);
			this.UserNameTextBox.TabIndex = 15;
			// 
			// KeyPathTextBox
			// 
			this.KeyPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.KeyPathTextBox.Location = new System.Drawing.Point(70, 194);
			this.KeyPathTextBox.Name = "KeyPathTextBox";
			this.KeyPathTextBox.Size = new System.Drawing.Size(183, 19);
			this.KeyPathTextBox.TabIndex = 16;
			// 
			// KeyPasswordTextBox
			// 
			this.KeyPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.KeyPasswordTextBox.Location = new System.Drawing.Point(70, 219);
			this.KeyPasswordTextBox.Name = "KeyPasswordTextBox";
			this.KeyPasswordTextBox.PasswordChar = '*';
			this.KeyPasswordTextBox.Size = new System.Drawing.Size(183, 19);
			this.KeyPasswordTextBox.TabIndex = 17;
			// 
			// EditList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.KeyPasswordTextBox);
			this.Controls.Add(this.KeyPathTextBox);
			this.Controls.Add(this.UserNameTextBox);
			this.Controls.Add(this.ForwardPortTextBox);
			this.Controls.Add(this.LocalPortTextBox);
			this.Controls.Add(this.ServerPortTextBox);
			this.Controls.Add(this.ServerNameTextBox);
			this.Controls.Add(this.SettingNameTextBox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CommitButton);
			this.Controls.Add(this.BackButton);
			this.Name = "EditList";
			this.Size = new System.Drawing.Size(256, 385);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BackButton;
		private System.Windows.Forms.Button CommitButton;
		private System.Windows.Forms.OpenFileDialog KeyOpenFileDialog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox SettingNameTextBox;
		private System.Windows.Forms.TextBox ServerNameTextBox;
		private System.Windows.Forms.TextBox ServerPortTextBox;
		private System.Windows.Forms.TextBox LocalPortTextBox;
		private System.Windows.Forms.TextBox ForwardPortTextBox;
		private System.Windows.Forms.TextBox UserNameTextBox;
		private System.Windows.Forms.TextBox KeyPathTextBox;
		private System.Windows.Forms.TextBox KeyPasswordTextBox;
	}
}
