using System;

namespace HorasHombre.Model
{
    [AttributeUsage(AttributeTargets.All)]
    public class TitleAttribute : Attribute
    {
        private string title;

        public TitleAttribute(string title)
        {
            this.title = title;
        }

        public string Title { get { return title; } }
    }
}
