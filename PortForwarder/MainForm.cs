using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using System.Data.SQLite;
using System.Diagnostics;
using System.Net;

namespace PortForwarder
{
	public partial class MainForm : Form
	{
		private PrivateProfile _PrivateProfile = null;
		private EditList _EditList = null;
		public string connectionString = null;
		private DataTable _DataTable = null;
		private DBConnector _DBConnector = null;

		struct SSHNet
		{
			public string SettingName;
			public PrivateKeyFile _PrivateKeyFile;
			public PrivateKeyConnectionInfo _PrivateKeyConnectionInfo;
			public SshClient _SshClient;
			public ForwardedPortLocal _ForwardedPortLocal;
		};

		private List<SSHNet> _SSHNetList = null;


		public MainForm()
		{
			InitializeComponent();
			_PrivateProfile = new PrivateProfile("config.db");
			connectionString = _PrivateProfile.connectionString;
			_DBConnector = new DBConnector(connectionString);
			_SSHNetList = new List<SSHNet>();
		}

		private void Restuct()
		{
			_DataTable = new DataTable();
			if (_DBConnector.Connect())
			{
				try
				{
					SQLiteCommand cmd;
					cmd = _DBConnector.Connection.CreateCommand();
					cmd.CommandText = SQLSTR.HAS_TABLE;
					cmd.Parameters.Add(new SQLiteParameter("@Name", DbType.String) { Value = SQLSTR.LIST_TABLE_NAME });
					if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
					{
						cmd.CommandText = String.Format(SQLSTR.CREATE_TABLE, SQLSTR.LIST_TABLE_NAME);
						cmd.ExecuteNonQuery();
						_DBConnector.Transaction.Commit();
					}
					cmd = _DBConnector.Connection.CreateCommand();
					cmd.CommandText = String.Format(SQLSTR.SELECT_ALL, SQLSTR.LIST_TABLE_NAME);
					SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);
					adp.Fill(_DataTable);
					ListDataGridView.DataSource = _DataTable;
					ListDataGridView.Columns[6].Visible = false;
					ListDataGridView.Columns[7].Visible = false;
					ListDataGridView.Columns[8].Visible = false;
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
				finally
				{
					_DBConnector.DisConnect();
				}
			}
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			this.StartPosition = FormStartPosition.Manual;
			this.Location = (Point)_PrivateProfile.Get("UI", "Location", typeof(Point), this.Location);
			this.Size = (Size)_PrivateProfile.Get("UI", "Size", typeof(Size), this.Size);

			//選択を行単位
			ListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			//データ追加を禁止
			ListDataGridView.AllowUserToAddRows = false;
			//行削除禁止
			ListDataGridView.AllowUserToDeleteRows = false;
			//セル編集禁止
			ListDataGridView.ReadOnly = true;
			//Rowヘッダーを表示させない
			ListDataGridView.RowHeadersVisible = false;
			//複数選択禁止
			ListDataGridView.MultiSelect = false;
			ListDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			_EditList = new EditList(_DBConnector);
			_EditList.GoToBack += MainForm_GotoBack;
			this.Controls.Add(_EditList);
			_EditList.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - MainStatusStrip.Height);
			_EditList.BringToFront();
			_EditList.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			_EditList.Visible = false;

			if (_DBConnector.Connect())
			{
				try
				{
					SQLiteCommand cmd;
					cmd = _DBConnector.Connection.CreateCommand();
					cmd.CommandText = String.Format(SQLSTR.UPDATE_ALL_CONNECT, SQLSTR.LIST_TABLE_NAME);
					cmd.Parameters.Add(new SQLiteParameter("@Connect", DbType.String) { Value = "切断" });
					cmd.ExecuteNonQuery();
					_DBConnector.Transaction.Commit();
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
				finally
				{
					_DBConnector.DisConnect();
				}
			}
			Restuct();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			_EditList.Restruct();
			_EditList.Visible = true;
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			var sel_row = ListDataGridView.SelectedRows;
			if (sel_row == null)
			{
				return;
			}
			var setting_name = sel_row[0].Cells[0].Value.ToString();
			var connect = @"切断";
			if (_DBConnector.Connect())
			{
				try
				{
					SQLiteCommand cmd;
					cmd = _DBConnector.Connection.CreateCommand();
					cmd.CommandText = String.Format(SQLSTR.GET_CONNECT, SQLSTR.LIST_TABLE_NAME);
					cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
					using (SQLiteDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							connect = dr.GetString(0);
						}
					}
					MainToolStripStatusLabel.Text = "";
				}
				catch (Exception ex)
				{
					MainToolStripStatusLabel.Text = ex.Message;
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
				finally
				{
					_DBConnector.DisConnect();
				}

			}
			if (connect == "切断")
			{
				_EditList.Restruct(sel_row[0].Cells[0].Value.ToString());
				_EditList.Visible = true;
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			var sel_row = ListDataGridView.SelectedRows;
			if (sel_row == null)
			{
				return;
			}
			var setting_name = sel_row[0].Cells[0].Value.ToString();
			if (_DBConnector.Connect())
			{
				try
				{
					SQLiteCommand cmd;
					cmd = _DBConnector.Connection.CreateCommand();
					cmd.CommandText = String.Format(SQLSTR.HAS_SETTING, SQLSTR.LIST_TABLE_NAME);
					cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
					if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
					{
						cmd = _DBConnector.Connection.CreateCommand();
						cmd.CommandText = String.Format(SQLSTR.DELETE_SETTING, SQLSTR.LIST_TABLE_NAME);
						cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
						cmd.ExecuteNonQuery();
						_DBConnector.Transaction.Commit();
					}
					MainToolStripStatusLabel.Text = "";
				}
				catch (Exception ex)
				{
					MainToolStripStatusLabel.Text = ex.Message;
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
				finally
				{
					_DBConnector.DisConnect();
				}

			}
			Restuct();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			_PrivateProfile.Set("UI", "Location", typeof(Point), this.Location);
			_PrivateProfile.Set("UI", "Size", typeof(Size), this.Size);
		}

		private void MainForm_GotoBack(object sender, EventArgs e)
		{
			Restuct();
		}

		private void ConnectButton_Click(object sender, EventArgs e)
		{
			var sel_row = ListDataGridView.SelectedRows;
			if (sel_row.Count == 0)
			{
				return;
			}
			var setting_name = sel_row[0].Cells[0].Value.ToString();
			if (_SSHNetList.Any(t => t.SettingName == setting_name))
			{
				return;
			}
			if (_DBConnector.Connect())
			{
				try
				{
					SQLiteCommand cmd;
					cmd = _DBConnector.Connection.CreateCommand();
					cmd.CommandText = String.Format(SQLSTR.HAS_SETTING, SQLSTR.LIST_TABLE_NAME);
					cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
					if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
					{
						cmd = _DBConnector.Connection.CreateCommand();
						cmd.CommandText = String.Format(SQLSTR.SELECT_SETTING, SQLSTR.LIST_TABLE_NAME);
						cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
						using (SQLiteDataReader dr = cmd.ExecuteReader())
						{
							SSHNet sshnet = new SSHNet();
							while (dr.Read())
							{
								sshnet.SettingName = dr.GetString(0);
								sshnet._PrivateKeyFile = new PrivateKeyFile(dr.GetString(7), dr.GetString(8));
								sshnet._PrivateKeyConnectionInfo = new PrivateKeyConnectionInfo(dr.GetString(2),dr.GetInt32(3) , dr.GetString(6), sshnet._PrivateKeyFile);
								sshnet._SshClient = new SshClient(sshnet._PrivateKeyConnectionInfo);
								sshnet._SshClient.Connect();
								string loopback = IPAddress.Loopback.ToString();
								sshnet._ForwardedPortLocal = new ForwardedPortLocal(loopback, (uint)dr.GetInt32(4), loopback, (uint)dr.GetInt32(5));
								sshnet._SshClient.AddForwardedPort(sshnet._ForwardedPortLocal);
								sshnet._ForwardedPortLocal.Start();
								_SSHNetList.Add(sshnet);
							}
						}
						cmd = _DBConnector.Connection.CreateCommand();
						cmd.CommandText = String.Format(SQLSTR.UPDATE_CONNECT, SQLSTR.LIST_TABLE_NAME);
						cmd.Parameters.Add(new SQLiteParameter("@Connect", DbType.String) { Value = "接続" });
						cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
						cmd.ExecuteNonQuery();
						_DBConnector.Transaction.Commit();
						MainToolStripStatusLabel.Text = "";
					}
				}
				catch (Exception ex)
				{
					MainToolStripStatusLabel.Text = ex.Message;
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
				finally
				{
					_DBConnector.DisConnect();
				}
			}
			Restuct();
		}

		private void DisconnectButton_Click(object sender, EventArgs e)
		{
			var sel_row = ListDataGridView.SelectedRows;
			if (sel_row.Count == 0)
			{
				return;
			}
			var setting_name = sel_row[0].Cells[0].Value.ToString();
			var _sshnetlist = _SSHNetList.Where(t => t.SettingName == setting_name).ToList();
			if (_sshnetlist.Count() == 0)
			{
				return;
			}
			foreach(var sshnet in _sshnetlist)
			{
				sshnet._ForwardedPortLocal.Stop();
				sshnet._SshClient.Disconnect();
				sshnet._PrivateKeyConnectionInfo.Dispose();
				sshnet._PrivateKeyFile.Dispose();
				if (_DBConnector.Connect())
				{
					try
					{
						SQLiteCommand cmd;
						cmd = _DBConnector.Connection.CreateCommand();
						cmd.CommandText = String.Format(SQLSTR.HAS_SETTING, SQLSTR.LIST_TABLE_NAME);
						cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
						if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
						{
							cmd = _DBConnector.Connection.CreateCommand();
							cmd.CommandText = String.Format(SQLSTR.UPDATE_CONNECT, SQLSTR.LIST_TABLE_NAME);
							cmd.Parameters.Add(new SQLiteParameter("@Connect", DbType.String) { Value = "切断" });
							cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
							cmd.ExecuteNonQuery();
							_DBConnector.Transaction.Commit();
						}
						MainToolStripStatusLabel.Text = "";
					}
					catch (Exception ex)
					{
						MainToolStripStatusLabel.Text = ex.Message;
						System.Diagnostics.Debug.WriteLine(ex.Message);
					}
					finally
					{
						_DBConnector.DisConnect();
					}

				}
				_SSHNetList.Remove(sshnet);
			}
			Restuct();
		}
	}
	public partial class DBConnector
	{
		public string connectionString = null;
		public bool IsConnect { get { return Connection != null; } }

		public SQLiteConnection Connection { get; set; }

		public SQLiteTransaction Transaction { get; set; }

		public DBConnector(string connectionstring)
		{
			connectionString = connectionstring;
			Connection = null;
			Transaction = null;
		}

		public bool Connect()
		{
			bool ret = false;
			if (IsConnect)
			{
				return true;
			}
			try
			{
				Connection = new SQLiteConnection(connectionString);
				try
				{
					Connection.Open();
					try
					{
						Transaction = Connection.BeginTransaction();
						ret = true;
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine(ex.Message);
						Connection.Close();
						Connection = null;
					}
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
					Connection.Close();
					Connection = null;
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}

			return ret;
		}
		public void DisConnect()
		{
			if (!IsConnect)
			{
				return;
			}
			Transaction.Dispose();
			Transaction = null;
			Connection.Close();
			Connection.Dispose();
			Connection = null;
		}
	}
	public static class SQLSTR
	{
		public const string LIST_TABLE_NAME = @"list_table";
		public const string HAS_TABLE =
			@"SELECT COUNT(name) 
				FROM (SELECT name FROM sqlite_master WHERE type = 'table') 
				WHERE name=@Name;";
		public const string CREATE_TABLE =
			@"CREATE TABLE {0} (SettingName TEXT NOT NULL UNIQUE,
								Connect		TEXT,
								ServerName  TEXT,
								ServerPort  INT,
								LocalPort   INT,
								ForwardPort INT,
								UserName    TEXT,
								KeyPath     TEXT,
								KeyPassword TEXT);";
		public const string SELECT_ALL =
			@"SELECT SettingName AS ""設定名"",
					Connect      AS ""接続"",
					ServerName   AS ""サーバー名"",
					ServerPort   AS ""サーバーポート番号"",
					LocalPort    AS ""ローカルポート番号"",
					ForwardPort	 AS ""転送先ポート番号"",
					UserName	 AS ""ユーザー名"",
					KeyPath      AS ""SSHキーパス"",
					KeyPassword  AS ""パスワード""
				FROM {0};";
		public const string HAS_SETTING =
			@"SELECT COUNT(SettingName) FROM {0}
				WHERE SettingName=@SettingName;";
		public const string SELECT_SETTING =
			@"SELECT * FROM {0}
				WHERE SettingName=@SettingName;";

		public const string DELETE_SETTING =
			@"DELETE FROM {0}
				WHERE SettingName=@SettingName;";

		public const string UPDATE_ALL_CONNECT =
			@"UPDATE {0} SET Connect=@Connect;";

		public const string UPDATE_CONNECT =
				@"UPDATE {0} SET Connect=@Connect WHERE SettingName=@SettingName;";

		public const string GET_CONNECT =
			@"SELECT Connect FROM {0} WHERE SettingName=@SettingName;";

		public const string UPSERT = @"INSERT OR REPLACE INTO {0} 
				(SettingName, Connect, ServerName, ServerPort, LocalPort, ForwardPort, UserName, KeyPath, KeyPassword) VALUES 
				(@SettingName, @Connect, @ServerName, @ServerPort, @LocalPort, @ForwardPort, @UserName, @KeyPath, @KeyPassword);";
	}
}
