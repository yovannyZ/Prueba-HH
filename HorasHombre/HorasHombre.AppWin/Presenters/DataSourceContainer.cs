using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace HorasHombre.AppWin.Presenters
{
    public class DataSourceContainer
    {
        private object mDataSource;
        private string mDataTextFieldName;
        private string mDataValueFieldName;

        public object DataSource
        {
            get { return mDataSource; }
            set { mDataSource = value; }
        }

        public string DataTextFieldName
        {
            get { return mDataTextFieldName; }
            set { mDataTextFieldName = value; }
        }

        public string DataValueFieldName
        {
            get { return mDataValueFieldName; }
            set { mDataValueFieldName = value; }
        }

        public DataSourceContainer(string dataTextFieldName, string dataValueFieldName, object dataSource)
        {
            this.mDataSource = dataSource;
            this.mDataTextFieldName = dataTextFieldName;
            this.mDataValueFieldName = dataValueFieldName;
        }

        public DataSourceContainer(Type type, bool all = false)
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("Se esperaba un objeto de tipo ennumeración");
            }

            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();

            foreach (int i in Enum.GetValues(type))
            {
                string name = Enum.GetName(type, i);
                string desc = name;
                FieldInfo fi = type.GetField(name);


                // Get description for enum element
                TitleAttribute[] attributes = (TitleAttribute[])fi.GetCustomAttributes(typeof(TitleAttribute), false);
                BrowsableAttribute[] attr = (BrowsableAttribute[])fi.GetCustomAttributes(typeof(BrowsableAttribute), false);

                if (attributes.Length > 0)
                {
                    string s = attributes[0].Title;
                    if (!string.IsNullOrEmpty(s))
                    {
                        desc = s;
                    }
                }
                if (attr.Length > 0 && !all)
                {
                    if (attr[0].Browsable)
                        list.Add(new KeyValuePair<string, int>(desc, i));
                }
                else
                    list.Add(new KeyValuePair<string, int>(desc, i));
            }
            this.mDataSource = list;
            this.mDataTextFieldName = "Key";
            this.mDataValueFieldName = "Value";
        }
    }
}
