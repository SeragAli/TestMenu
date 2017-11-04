using System.Configuration;

namespace MenuConfiguration
{
    /// <summary>
    /// Main Item in container
    /// </summary>
    public class CustomMenuItem : ConfigurationElement
    {
        /// <summary>
        /// Item name
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Item text
        /// </summary>
        [ConfigurationProperty("text", IsRequired = true)]
        public string Text
        {
            get { return this["text"] as string; }
            set { this["text"] = value; }
        }

        /// <summary>
        /// Item number
        /// </summary>
        [ConfigurationProperty("order", DefaultValue = -1, IsRequired = true)]
        public int Order
        {
            get { return (int)this["order"]; }
            set { this["order"] = value; }
        }

        /// <summary>
        /// Indecates item enable or not
        /// </summary>
        [ConfigurationProperty("active", DefaultValue = false, IsRequired = true)]
        public bool Active
        {
            get { return (bool)this["active"]; }
            set { this["active"] = value; }
        }

        /// <summary>
        /// Parent item
        /// </summary>
        [ConfigurationProperty("parent", DefaultValue = "", IsRequired = false)]
        public string Parent
        {
            get { return this["parent"] as string; }
            set { this["parent"] = value; }
        }
    }
}
