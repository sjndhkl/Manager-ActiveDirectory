using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace Manager_ActiveDirectory
{
    public static class DomainManager
    {
        #region Constructor
        static DomainManager()
        {
            Domain domain = null;
            DomainController domainController = null;
            try
            {
                domain = Domain.GetCurrentDomain();
                DomainName = domain.Name;
                domainController = domain.PdcRoleOwner;
                DomainControllerName = domainController.Name.Split('.')[0];
                ComputerName = Environment.MachineName;
            }
            finally
            {
                if (domain != null)
                    domain.Dispose();
                if (domainController != null)
                    domainController.Dispose();
            }
        }
        #endregion

        #region Properties
        public static string DomainControllerName { get; private set; }
        public static string ComputerName { get; private set; }
        public static string DomainName { get; private set; }
        public static string DomainPath
        {
            get
            {
                bool bFirst = true;
                StringBuilder sbReturn = new StringBuilder(200);
                string[] strlstDc = DomainName.Split('.');
                foreach (string strDc in strlstDc)
                {
                    if (bFirst)
                    {
                        sbReturn.Append("DC=");
                        bFirst = false;
                    }
                    else
                        sbReturn.Append(",DC=");

                    sbReturn.Append(strDc);
                }
                return sbReturn.ToString();
            }
        }
        public static string RootPath
        {
            get
            {
                return string.Format("LDAP://{0}/{1}", DomainName, DomainPath);
            }
        }
        #endregion

        #region Methods public
        public static IEnumerable<Domain> GetDomains()
        {
            ICollection<Domain> domains = new List<Domain>();
            foreach (Domain d in Forest.GetCurrentForest().Domains) domains.Add(d);
            return domains;
        }
        public static IEnumerable<string> GetUserDomain(string userName)
        {
            List<string> domainsNames = new List<string>();
            foreach (var d in GetDomains())
            {
                try
                {
                    using (DirectoryEntry domain = new DirectoryEntry(GetDomainFullName(d.Name)))
                    {
                        using (DirectorySearcher searcher = new DirectorySearcher())
                        {
                            searcher.SearchRoot = domain;
                            searcher.SearchScope = SearchScope.Subtree;
                            searcher.PropertiesToLoad.Add("sAMAccountName");
                            searcher.Filter = string.Format("(&(objectClass=user)(sAMAccountName={0}))", userName);

                            try
                            {
                                SearchResultCollection results = searcher.FindAll();
                                if (results == null || results.Count == 0) continue;
                                domainsNames.Add(domain.Path);
                            }
                            finally
                            {
                                searcher.Dispose();
                                domain.Dispose();
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(string.Format("Error while parsing domain {0} : {1}", d.Name, exp.Message));
                }
            }
            return domainsNames;
        }
        public static List<string> GetADList()
        {
            List<string> adList = new List<string>();

            Forest currentForest = Forest.GetCurrentForest();
            DomainCollection domains = currentForest.Domains;
            foreach (Domain objDomain in domains)
            {
                foreach (DomainController controler in objDomain.DomainControllers)
                {
                    adList.Add(controler.Name.Split('.')[0]);
                }
            }

            return adList;
        }
        #endregion

        #region Methods private
        private static string GetDomainFullName(string friendlyName)
        {
            DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain, friendlyName);
            Domain domain = Domain.GetDomain(context);
            return domain.Name;
        }
        #endregion
    }
}
