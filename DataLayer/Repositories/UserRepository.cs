using DataLayer.Utils;
using DomainClasses;
using DomainClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        //TODO: Add salt

        const int RESET_PASSWORD_CODE_LENGTH = 32;

        public bool CheckCredentials(string email, string password)
        {           
            bool userExists = false;
            string hashedPass = DataLayer.Utils.Hash.GetHash(password, Utils.Hash.HashType.SHA512); 

            userExists = _context.Users.Where(u => u.Email == email).Where(u => u.Password == hashedPass).Any();

            return userExists;
        }

        public bool CheckUserExists(string email)
        {
            return _context.Users.Where(u => u.Email == email).Any();
        }

        public void CreateUser(ref User user, string registrationCode)
        {
            var registrationRepo = new RegistrationDetailRepository();
            user.RegistrationId = registrationRepo.GetEntry(registrationCode).Id;

            string hashedPass = DataLayer.Utils.Hash.GetHash(user.Password, Utils.Hash.HashType.SHA512);
            user.Password = hashedPass;

            _context.Users.Add(user);
            _context.SaveChanges();

            registrationRepo.MarkRegistrationCodeAsUsed(registrationCode);
        }

        public bool EditUser(User user)
        {
            var storedUser = GetById(user.Id);

            storedUser.Email = user.Email;
            storedUser.Firstname = user.Firstname;
            storedUser.Lastname = user.Lastname;

            _context.SaveChanges();
            return true;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public string ResetPassword(string email)
        {
            if (!CheckUserExists(email))
                return null;

            var resetPasswordDetail = new ResetPasswordDetail
            {
                RequestedAt = DateTime.Now,
                PasswordReseted = false,
                UserId = GetUserByEmail(email).Id,
                ResetPasswordCode = UtilityMethods.GetRandomString(RESET_PASSWORD_CODE_LENGTH)
            };

            _context.ResetPasswordDetails.Add(resetPasswordDetail);

            return resetPasswordDetail.ResetPasswordCode;
        }

        public ICollection<User> GetAssignableUsersForProductOwnerState()
        {
            return _context.Users.Where(x => x.UserType == UserType.None).ToList();
        }

        public bool AssignProductOwnerToProduct(int productId, string userEmail)
        {
            var user = GetUserByEmail(userEmail);

            if (user == null)
                return false;

            var product = _context.Products.Find(productId);

            if (product == null)
                return false;

            user.UserType = UserType.ProductOwner;
            product.ProductOwners.Add(user);

            _context.SaveChanges();

            return true;
        }

        public bool UnAssignProductOwnerFromProduct(string userEmail)
        {
            var user = GetUserByEmail(userEmail);

            if (user == null)
                return false;

            var product = _context.Products.Where(x => x.ProductOwners.Any(y => y.Id == user.Id)).FirstOrDefault();

            if (product != null)
                product.ProductOwners.Remove(user);

            user.UserType = UserType.None;

            _context.SaveChanges();

            return true;
        }

        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var user = GetById(userId);

            if (user == null)
                return false;

            var hashedOldPass = Utils.Hash.GetHash(oldPassword, Hash.HashType.SHA512);

            if (hashedOldPass != user.Password)
                return false;

            user.Password = Utils.Hash.GetHash(newPassword, Hash.HashType.SHA512);

            _context.SaveChanges();

            return true;
        }

        public Product GetProductOnWhichUserWorks(int userId)
        {
            var user = _context.Users.Where(x => x.Id == userId).Include(x => x.Team.Product.Backlog).FirstOrDefault();

            if(user == null)
                return  null;

            if (user.Team == null)
                return null;

            return user.Team.Product;             
        }

        public User GetUserByIdWithRelatedItems(int id)
        {
            return _context.Users.Where(x => x.Id == id).Include(x => x.Team).FirstOrDefault();
        }

    }
}
