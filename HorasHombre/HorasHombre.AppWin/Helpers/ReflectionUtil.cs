using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Helpers
{
    static class ReflectionUtil
    {
        public static List<TitleAttribute> ListTitleAttibute(object target)
        {
            List<TitleAttribute> list = new List<TitleAttribute>();

            PropertyInfo[] props = target.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    TitleAttribute authAttr = attr as TitleAttribute;
                    if (authAttr != null)
                        list.Add(authAttr);
                }
            }
            return list;
        }

        public static Dictionary<string, string> GetTitleAttibute(object target)
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            PropertyInfo[] props = target.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    TitleAttribute titleAttr = attr as TitleAttribute;
                    if (titleAttr != null)
                    {
                        string propName = prop.Name;
                        string auth = titleAttr.Title;

                        _dict.Add(propName, auth);
                    }
                }
            }
            return _dict;
        }

        public static object GetPropertyValue(object obj, string name)
        {
            return obj == null ? null : obj.GetType()
                                           .GetProperty(name)
                                           .GetValue(obj, null);
        }

        public static object GetEntityByTitle(string typeObject)
        {
            object entity = null;
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            AssemblyName[] asemblies = currentAssembly.GetReferencedAssemblies();
            foreach (var t in asemblies)
            {
                if (t.Name == "HorasHombre.Model")
                {
                    Assembly assembly = Assembly.Load(t);
                    foreach (var type in assembly.GetTypes())
                    {
                        var attribs = type.GetCustomAttributes(typeof(TitleAttribute), false);
                        if (attribs != null && attribs.Length > 0)
                        {
                            foreach (var attrib in attribs)
                            {
                                if (((TitleAttribute)attrib).Title == typeObject)
                                {
                                    entity = Activator.CreateInstance(type);
                                    return entity;
                                }
                            }
                        }

                    }
                }
            }
            return entity;
        }

        public static Form GetFormByTag(string typeObject)
        {
            object frm = null;
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Type[] types = currentAssembly.GetTypes();
            foreach (var t in types)
            {
                if (t.BaseType == typeof(Form) || t.BaseType == typeof(HerenciaVisual.frmMantenimiento)
                    || t.BaseType == typeof(HerenciaVisual.frmMantenimiento))
                {
                    frm = Activator.CreateInstance(t, true);
                    var propertyValue = ReflectionUtil.GetPropertyValue(frm, "Tag");
                    if (propertyValue != null && propertyValue.ToString() == typeObject)
                    {
                        return (Form)frm;
                    }
                }
            }
            return null;
        }

        public static string GetChangesFromObjects(object originalObject, object changedObject)
        {
            List<string> list = new List<string>();
            string originalText = string.Empty;
            string newText = string.Empty;
            list.Add(new string(Convert.ToChar("-"), 3));
            foreach (PropertyInfo property in originalObject.GetType().GetProperties())
            {
                Type comparable =
            property.PropertyType.GetInterface("System.IComparable");

                if (comparable != null)
                {
                    if (property.GetIndexParameters().Length == 0)
                    {
                        object originalValue = ReflectionUtil.GetPropertyValue(originalObject, property.Name);
                        object newValue = ReflectionUtil.GetPropertyValue(changedObject, property.Name);
                        if (!object.Equals(originalValue, newValue))
                        {
                            object attr = GetPropertyTittleAttribute(property);
                            originalText = (originalValue != null) ?
                               originalValue.ToString() : "[NULL]";
                            newText = (newValue != null) ?
                               newValue.ToString() : "[NULL]";
                            list.Add(string.Concat("*-", attr, ": fue cambiado de '", originalText,
                                "' a '", newText, "'"));
                        }
                    }
                }
            }
            return string.Join("\r\n", list.ToArray());
        }

        public static object GetPropertyTittleAttribute(PropertyInfo property)
        {
            var propattr = property.GetCustomAttributes(false);
            object attr = (from row in propattr
                           where row.GetType() == typeof(TitleAttribute)
                           select row).FirstOrDefault();
            if (attr != null)
                attr = ((TitleAttribute)attr).Title;
            else
                attr = property.Name;
            return attr;
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name).GetCustomAttributes(false)
                .OfType<TAttribute>().SingleOrDefault();
        }

        public static T GetEnumValueFromTittle<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(TitleAttribute)) as TitleAttribute;
                if (attribute != null)
                {
                    if (attribute.Title == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("No se encontro coincidencia.", "Title");
            // or return default(T);
        }

        public static string GetEnumTittleAttribute(this Enum value)
        {
            FieldInfo field;
            TitleAttribute attribute;
            string result;

            field = value.GetType().GetField(value.ToString());
            attribute = (TitleAttribute)Attribute.GetCustomAttribute(field, typeof(TitleAttribute));
            result = attribute != null ? attribute.Title : string.Empty;

            return result;
        }

    }
}
