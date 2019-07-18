using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrgChartWebApp.Models;

namespace OrgChartWebApp.Controllers
{
    public class LdapController : Controller
    {
        [HttpPost]
        public JsonResult ValidateLdapUser(string user)
        {
            Boolean userExists = false;
            SearchResultCollection sResults = null;
            string path = "LDAP://Falabella.com";
            string criterios = "(&(objectClass=user)(samAccountName=" + user + "))";
            try
            {
                DirectoryEntry dEntry = new DirectoryEntry(path);
                DirectorySearcher dSearcher = new DirectorySearcher(dEntry);
                dSearcher.Filter = criterios;
                sResults = dSearcher.FindAll();
                int result = sResults.Count;
                if (result >= 1)
                {
                    userExists = true;
                }
                else
                {
                    userExists = false;
                }
            }
            catch (Exception ex)
            {
                return Json(userExists, JsonRequestBehavior.AllowGet);
            }
            return Json(userExists, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetLDAPUsers()
        {
            string path = "LDAP://Falabella.com";
            string criterios = "(&(objectClass=user)(sn=luis*))";
            List<LdapUsers> listaUsuarios = new List<LdapUsers>();
            try
            {

                DirectoryEntry dEntry = new DirectoryEntry(path);
                DirectorySearcher dSearcher = new DirectorySearcher(dEntry);
                dSearcher.Filter = criterios;
                foreach (SearchResult result in dSearcher.FindAll())
                {
                    DirectoryEntry de = result.GetDirectoryEntry() as DirectoryEntry;
                    listaUsuarios.Add(new LdapUsers()
                    {
                        Apellido = de.Properties["sn"].Value.ToString(),
                        PrimerNombre = de.Properties["givenName"].Value.ToString(),
                        PrincipalName = de.Properties["userPrincipalName"].Value.ToString(),
                        UserName = de.Properties["samAccountName"].Value.ToString()
                    });
                }

            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json(listaUsuarios, JsonRequestBehavior.AllowGet);
        }
    }
}