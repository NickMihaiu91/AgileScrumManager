using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class EmailServerRepository : BaseRepository<EmailServer>
    {
        #region Default email 
        public readonly static string DefaultSubject = "User registration link for Agile Scrum Manager";
        public readonly static string DefaultBody = "Please use the following link to register in the Agile Scrum Manager application: ";
        public readonly static string DefaultRegistrationLink = "http://localhost:6250/User/Create/";
        #endregion

        private void ClearEmailServerTable()
        {
            var all = from c in _context.EmailServers select c;
            _context.EmailServers.RemoveRange(all);
            _context.SaveChanges();
        }

        public void SetEmailServer(string emailAddress, string emailPassword)
        {
            ClearEmailServerTable();
            _context.EmailServers.Add(new EmailServer
            {
                EmailAddress = emailAddress,
                EmailPassword = emailPassword
            });
            _context.SaveChanges();
        }

        public EmailServer GetEmailServer()
        {
            return _context.EmailServers.FirstOrDefault();
        }
    }
}
