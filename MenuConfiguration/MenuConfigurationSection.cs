using System.Configuration;

namespace MenuConfiguration
{
    /// <summary>
    /// Menu item configuration section
    /// </summary>
    public class MenuConfigurationSection : ConfigurationSection
    {
        private const string SectionName = "MenuConfiguration";

        /// <summary>
        /// Config Item
        /// </summary>
        public static MenuConfigurationSection Config
        {
            get { return (MenuConfigurationSection)ConfigurationManager.GetSection(SectionName); }
        }

        /// <summary>
        /// Menu Items
        /// </summary>
        [ConfigurationProperty("CustomMenuItems")]
        public CustomMenuItemCollection MenuItems
        {
            get
            {
                return this["CustomMenuItems"] as CustomMenuItemCollection;
            }
        }
    }
}
