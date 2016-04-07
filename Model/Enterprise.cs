using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Manager_ActiveDirectory
{
    public class Enterprise
    {
        #region Attribute
        private string _login;
        private string _password;
        private List<LDAP.User> _users;
        private List<LDAP> _ldapList;
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
        public List<LDAP.User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public List<LDAP> LDAP
        {
            get { return _ldapList; }
            set { _ldapList = value; }
        }
        #endregion

        #region Constructor
        public Enterprise()
        {
            Init();
            GetADUsers();
        }
        #endregion

        #region Methods public
        public List<LDAP.User> GetADUsers()
        {
            _users = new List<LDAP.User>();
            foreach (LDAP ldap in _ldapList)
            {
                try
                {
                    Console.WriteLine("Adding users from : " + ldap.Domain);
                    _users.AddRange(ldap.Users);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Cannot load domain : " + exp.Message);
                }
            }
            return _users;
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _ldapList = new List<LDAP>();

            Parallel.ForEach(DomainManager.GetADList(), (adDomain) =>
            {
                _ldapList.Add(new LDAP("LDAP://" + adDomain));
            });
        }
        #endregion
    }
}
