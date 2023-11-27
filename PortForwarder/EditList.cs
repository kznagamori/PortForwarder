using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace PortForwarder
{
	public partial class EditList : UserControl
	{
		public event EventHandler GoToBack;
		private DBConnector _DBConnector = null;
		private DataTable _DataTable = null;

		public EditList(DBConnector dbconnector)
		{
			InitializeComponent();
			_DBConnector = dbconnector;
		}

		public void Restruct()
		{
			SettingNameTextBox.Enabled = true;
			SettingNameTextBox.Text = "";
			ServerNameTextBox.Text = "";
			ServerPortTextBox.Text = "";
			LocalPortTextBox.Text = "";
			ForwardPortTextBox.Text = "";
			UserNameTextBox.Text = "";
			KeyPathTextBox.Text = "";
			KeyPasswordTextBox.Text = "";
		}

		public void Restruct(string setting_name)
		{
			_DataTable = new DataTable();
			if (_DBConnector.Connect())
			{
				try
				{
					SQLiteCommand cmd;
					cmd = _DBConnector.Connection.CreateCommand();
					cmd.CommandText = String.Format(SQLSTR.HAS_SETTING, SQLSTR.LIST_TABLE_NAME);
					cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
					if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
					{
						SettingNameTextBox.Enabled = true;
						SettingNameTextBox.Text = "";
						ServerNameTextBox.Text = "";
						ServerPortTextBox.Text = "";
						LocalPortTextBox.Text = "";
						ForwardPortTextBox.Text = "";
						UserNameTextBox.Text = "";
						KeyPathTextBox.Text = "";
						KeyPasswordTextBox.Text = "";
					}
					else
					{
						SettingNameTextBox.Enabled = false;
						cmd = _DBConnector.Connection.CreateCommand();
						cmd.CommandText = String.Format(SQLSTR.SELECT_SETTING, SQLSTR.LIST_TABLE_NAME);
						cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = setting_name });
						using (SQLiteDataReader dr = cmd.ExecuteReader())
						{
							while (dr.Read())
							{
								SettingNameTextBox.Text = dr.GetString(0);
								ServerNameTextBox.Text = dr.GetString(2);
								ServerPortTextBox.Text = dr.GetInt32(3).ToString();
								LocalPortTextBox.Text = dr.GetInt32(4).ToString();
								ForwardPortTextBox.Text = dr.GetInt32(5).ToString();
								UserNameTextBox.Text = dr.GetString(6);
								KeyPathTextBox.Text = dr.GetString(7);
								KeyPasswordTextBox.Text = dr.GetString(8);
							}
						}
					}
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

		private void BackButton_Click(object sender, EventArgs e)
		{
			if (this.GoToBack != null)
			{
				this.GoToBack(sender, e);
			}
			this.Visible = false;
		}

		private void CommitButton_Click(object sender, EventArgs e)
		{
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
					cmd.CommandText = String.Format(SQLSTR.UPSERT, SQLSTR.LIST_TABLE_NAME);
					cmd.Parameters.Add(new SQLiteParameter("@SettingName", DbType.String) { Value = SettingNameTextBox.Text });
					cmd.Parameters.Add(new SQLiteParameter("@Connect", DbType.String) { Value = "切断" });
					cmd.Parameters.Add(new SQLiteParameter("@ServerName", DbType.String) { Value = ServerNameTextBox.Text });
					cmd.Parameters.Add(new SQLiteParameter("@ServerPort", DbType.Int32) { Value = Convert.ToInt32(ServerPortTextBox.Text) });
					cmd.Parameters.Add(new SQLiteParameter("@LocalPort", DbType.Int32) { Value = Convert.ToInt32(LocalPortTextBox.Text) });
					cmd.Parameters.Add(new SQLiteParameter("@ForwardPort", DbType.Int32) { Value = Convert.ToInt32(ForwardPortTextBox.Text) });
					cmd.Parameters.Add(new SQLiteParameter("@UserName", DbType.String) { Value = UserNameTextBox.Text });
					cmd.Parameters.Add(new SQLiteParameter("@KeyPath", DbType.String) { Value = KeyPathTextBox.Text });
					cmd.Parameters.Add(new SQLiteParameter("@KeyPassword", DbType.String) { Value = KeyPasswordTextBox.Text });
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
			if (this.GoToBack != null)
			{
				this.GoToBack(sender, e);
			}
			this.Visible = false;
		}
	}
}
