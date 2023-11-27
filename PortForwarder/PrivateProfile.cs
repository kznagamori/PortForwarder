using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;
using System.Drawing;

namespace PortForwarder
{
	public class PrivateProfile
	{
		private const string CONNECTIONSTRING = @"Data Source=""{0}{1}""";
		private const string SQL_HAS_TABLE = @"SELECT COUNT(name) FROM (SELECT name FROM sqlite_master WHERE type = 'table') WHERE name=@Name;";
		private const string SQL_CREATE_TABLE = @"CREATE TABLE {0} (Key TEXT NOT NULL UNIQUE, Value TEXT);";
		private const string SQL_GET = @"SELECT Value FROM {0} WHERE Key = @Key;";
		private const string SQL_UPSERT = @"INSERT OR REPLACE INTO {0} (Key, Value) VALUES (@Key, @Value);";
		public string connectionString = null;

		public PrivateProfile(string file_name)
		{
			string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
			connectionString = String.Format(CONNECTIONSTRING, appPath, file_name);
		}
		public object Get(string section, string key, Type type, object default_value)
		{
			object value = default_value;
			using (SQLiteConnection cn = new SQLiteConnection(connectionString))
			{
				cn.Open();
				using (SQLiteTransaction tx = cn.BeginTransaction())
				{
					SQLiteCommand cmd;
					string Value = null;
					cmd = cn.CreateCommand();
					cmd.CommandText = SQL_HAS_TABLE;
					cmd.Parameters.Add(new SQLiteParameter("@Name", DbType.String) { Value = section });
					if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
					{
						cmd = cn.CreateCommand();
						cmd.CommandText = String.Format(SQL_GET, section);
						cmd.Parameters.Add(new SQLiteParameter("@Key", DbType.String) { Value = key });
						using (SQLiteDataReader dr = cmd.ExecuteReader())
						{
							while (dr.Read())
							{
								Value = dr.GetString(0);
								if (type == typeof(Color))
								{
									DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(string));
									string color = (string)serializer.ReadObject(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(Value)));
									ColorConverter cc = new ColorConverter();
									value = cc.ConvertFromString(color);
									cc = null;
								}
								else
								{
									DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);
									value = serializer.ReadObject(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(Value)));
								}
									
							}
						}
					}
					tx.Commit();
				}
				cn.Close();
			}
			return value;
		}
		public bool Set(string section, string key, Type type, object value)
		{
			bool ret = false;
			if (type == typeof(Color))
			{
				type = typeof(string);
				ColorConverter cc = new ColorConverter();
				value = cc.ConvertToString(value);
				cc = null;
			}
			using (SQLiteConnection cn = new SQLiteConnection(connectionString))
			{
				cn.Open();
				using (SQLiteTransaction tx = cn.BeginTransaction())
				{
					SQLiteCommand cmd;
					string Value = null;
                    cmd = cn.CreateCommand();
					cmd.CommandText = SQL_HAS_TABLE;
					cmd.Parameters.Add(new SQLiteParameter("@Name", DbType.String) { Value = section });
					if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
					{
						cmd.CommandText = String.Format(SQL_CREATE_TABLE, section);
						cmd.ExecuteNonQuery();
					}
					DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);
					using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
					{
						serializer.WriteObject(ms, value);
						Value = Encoding.UTF8.GetString(ms.ToArray());
					}
					cmd = cn.CreateCommand();
					cmd.CommandText = String.Format(SQL_UPSERT, section);
					cmd.Parameters.Add(new SQLiteParameter("@Key", DbType.String) { Value = key });
					cmd.Parameters.Add(new SQLiteParameter("@Value", DbType.String) { Value = Value });
					cmd.ExecuteNonQuery();
					tx.Commit();
					ret = true;
				}
				cn.Close();
			}
			return ret;
		}

	}
}
