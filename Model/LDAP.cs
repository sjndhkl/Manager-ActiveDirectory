namespace Manager_ActiveDirectory
{
    using System;
    using System.Collections.Generic;
    using System.DirectoryServices;

    public class LDAP
    {
        #region Struct
        public struct User
        {
            [System.ComponentModel.DisplayName("Mail adress")]
            public string Email { get; set; }
            [System.ComponentModel.DisplayName("User")]
            public string UserName { get; set; }
            [System.ComponentModel.DisplayName("Display name")]
            public string DisplayName { get; set; }
            [System.ComponentModel.DisplayName("Mapping done")]
            public bool IsMapped { get; set; }
            [System.ComponentModel.DisplayName("Telephone")]
            public string Telephone { get; set; }
            [System.ComponentModel.DisplayName("Departement")]
            public string Departement { get; set; }
            [System.ComponentModel.DisplayName("Titre")]
            public string Titre { get; set; }
            [System.ComponentModel.DisplayName("DC")]
            public string DC { get; set; }
            [System.ComponentModel.DisplayName("SN")]
            public string SN { get; set; }
            [System.ComponentModel.DisplayName("Name")]
            public string Name { get; set; }
            [System.ComponentModel.DisplayName("Member Of")]
            public string MemberOf { get; set; }
            [System.ComponentModel.DisplayName("Physical Delivery Office Name")]
            public string PhysicalDeliveryOfficeName { get; set; }
            [System.ComponentModel.DisplayName("Last Logon")]
            public DateTime LastLogon { get; set; }
            [System.ComponentModel.DisplayName("Last Logoff")]
            public DateTime LastLogoff { get; set; }
            [System.ComponentModel.DisplayName("Last Logon Timestamp")]
            public DateTime LastLogonTimestamp { get; set; }

        }
        #endregion

        #region Attribute
        private string _login;
        private string _password;
        private string _domain;
        private List<User> _users;
        #endregion

        #region Properties
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        #endregion

        #region Constructor
        public LDAP(string domain)
        {
            Console.WriteLine("Build : " + domain);
            _users = new List<User>();
            _domain = domain;
            AddADUserList();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void AddADUserList()
        {
            try
            {
                DirectoryEntry searchRoot = new DirectoryEntry(_domain);
                searchRoot.Username = _login;
                searchRoot.Password = _password;
                DirectorySearcher search = new DirectorySearcher(searchRoot);
                search.Filter = "(objectClass=user)";

                foreach (SearchResult result in search.FindAll())
                {
                    try
                    {
                        _users.Add(AddADUser(result));
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Arf : " + exp.Message);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Cannot load : " + exp.Message);
            }
        }
        private User AddADUser(SearchResult result)
        {
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("fr-FR");
            User objSurveyUsers = new User();
            if (result.Properties.Contains("lastLogon")) objSurveyUsers.LastLogon = new DateTime((Int64)result.Properties["lastLogon"][0]);
            if (result.Properties.Contains("lastLogoff")) objSurveyUsers.LastLogoff = new DateTime((Int64)result.Properties["lastLogoff"][0]);
            if (result.Properties.Contains("lastLogonTimestamp")) objSurveyUsers.LastLogonTimestamp = new DateTime((Int64)result.Properties["lastLogonTimestamp"][0]);
            if (result.Properties.Contains("mail")) objSurveyUsers.Email = (String)result.Properties["mail"][0];
            if (result.Properties.Contains("samaccountname")) objSurveyUsers.UserName = (String)result.Properties["samaccountname"][0];
            if (result.Properties.Contains("displayname")) objSurveyUsers.DisplayName = (String)result.Properties["displayname"][0];
            if (result.Properties.Contains("telephoneNumber")) objSurveyUsers.Telephone = (String)result.Properties["telephoneNumber"][0];
            if (result.Properties.Contains("department")) objSurveyUsers.Departement = (String)result.Properties["department"][0];
            if (result.Properties.Contains("title")) objSurveyUsers.Titre = (String)result.Properties["title"][0];
            if (result.Properties.Contains("dc")) objSurveyUsers.DC = (String)result.Properties["dc"][0];
            if (result.Properties.Contains("sn")) objSurveyUsers.SN = (String)result.Properties["sn"][0];
            if (result.Properties.Contains("name")) objSurveyUsers.Name = (String)result.Properties["name"][0];
            if (result.Properties.Contains("memberOf")) objSurveyUsers.MemberOf = (String)result.Properties["memberOf"][0];
            if (result.Properties.Contains("physicalDeliveryOfficeName")) objSurveyUsers.PhysicalDeliveryOfficeName = (String)result.Properties["physicalDeliveryOfficeName"][0];
            return objSurveyUsers;
        }
        #endregion
    }
}
