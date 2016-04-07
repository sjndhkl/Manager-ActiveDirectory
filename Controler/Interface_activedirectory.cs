namespace Manager_ActiveDirectory.Controler
{
    public class Interface_activedirectory
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public Interface_activedirectory()
        {

        }
        #endregion

        #region Methods public
        public static object ACTION_130_lister_utilisateurs()
        {
            return null;
        }
        public static object ACTION_131_nommer_ordinateur()
        {
            return DomainManager.ComputerName;
        }
        public static object ACTION_132_lister_domaines()
        {
            return DomainManager.GetDomains();
        }
        public static object ACTION_133_lister_activeDirectory()
        {
            return DomainManager.GetADList();
        }
        #endregion

        #region Methods private
        #endregion
    }
}
