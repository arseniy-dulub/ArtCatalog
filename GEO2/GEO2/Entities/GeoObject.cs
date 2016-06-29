namespace GEO2.Entities
{
    using System.Globalization;

    public abstract class GeoObject
    {
        private string name, id, description, title;
        private CultureInfo ci;
        private object value;

        //***************************PROPERTIES********************************
        public string Name { get { return name; } set { name = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Id { get { return id; } set { id = value; } }
        public CultureInfo Culture { get { return ci; } set { ci = value; } }
        public virtual object Value { get { return value; } set { this.value = value; } }

        //*******************************METHODS*******************************
        public override string ToString() { return base.ToString(); }
    }
}
