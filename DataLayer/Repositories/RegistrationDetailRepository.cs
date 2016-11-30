using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Utils;

namespace DataLayer.Repositories
{
    public class RegistrationDetailRepository : BaseRepository<RegistrationDetail>
    {

        public string CreateEntry(string email)
        {
            var entry = new RegistrationDetail
            {
                Email = email,
                EmailSentAt = DateTime.Now,
                RegistrationCodeUsed = false,
                RegistrationDate = null,
                RegistrationCode = UtilityMethods.GetRandomString(32)
            };

            _context.RegistrationDetails.Add(entry);
            _context.SaveChanges();

            return entry.RegistrationCode;
        }

        public RegistrationDetail GetEntry(string registrationCode)
        {
            return _context.RegistrationDetails.Where(x => x.RegistrationCode == registrationCode).FirstOrDefault();
        }

        public string GetRegistrationCodeForEmail(string email)
        {
            return _context.RegistrationDetails.Where(x => x.Email == email).Select(x => x.RegistrationCode).FirstOrDefault();
        }

        public bool CheckIfRegistrationCodeWasUsed(string registrationCode)
        {
            return _context.RegistrationDetails.Where(x => x.RegistrationCode == registrationCode).Select(x => x.RegistrationCodeUsed).FirstOrDefault();
        }

        public bool CheckIfRegistrationCodeExists(string registrationCode)
        {
            return _context.RegistrationDetails.Where(x => x.RegistrationCode == registrationCode).Any();
        }

        public bool ValidateRegistrationCode(string registrationCode)
        {
            return CheckIfRegistrationCodeExists(registrationCode) && !CheckIfRegistrationCodeWasUsed(registrationCode);
        }

        public void MarkRegistrationCodeAsUsed(string registrationCode)
        {
            var regEntry = GetEntry(registrationCode);
            regEntry.RegistrationCodeUsed = true;
            regEntry.RegistrationDate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
