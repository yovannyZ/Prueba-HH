using System.Configuration;
using System.Data.Common;
using System.Data;

namespace HorasHombre.Data
{
    public abstract class DataAccessGestion
    {
        private string _cadenaConexion;
        protected string ConnectionString
        {
            get
            {
                if (_cadenaConexion == null)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                    ConfigurationSectionGroup userSettings = config.GetSectionGroup("userSettings");
                    ClientSettingsSection settings = (ClientSettingsSection)userSettings.Sections.Get(0);
                    SettingElement srvElem = settings.Settings.Get("Servidor");
                    SettingElement dbElem = settings.Settings.Get("BaseDatos");
                    string ServerName = string.Empty;
                    string DataBaseName = string.Empty;
                    if (srvElem != null)
                        ServerName = srvElem.Value.ValueXml.InnerText;

                    if (dbElem != null)
                        DataBaseName = dbElem.Value.ValueXml.InnerText;
                    _cadenaConexion = string.Format("Data Source={0};Initial Catalog=BD_GCO{1};User=miguel;password=main", ServerName, DataBaseName);
                    //_cadenaConexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                }
                return _cadenaConexion;
            }
            set { _cadenaConexion = value; }
        }

        protected int ExecuteNonQuery(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
    }
}
