using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {       

        private bool CheckForDuplicate(string teamName)
        {
            return _context.Teams.Any(x => x.Name == teamName);
        }

        public bool AddTeam(Team team)
        {
            if (CheckForDuplicate(team.Name))
                return false;

            _context.Teams.Add(team);
            _context.SaveChanges();

            return true;
        }

        public bool EditTeam(Team team)
        {
            if (CheckForDuplicate(team.Name))
                return false;

            var storedTeam = GetById(team.Id);
            storedTeam.Name = team.Name;
            _context.SaveChanges();

            return true;
        }

        public bool DeleteTeam(int id)
        {
            var team = GetById(id);

            if (team == null)
                return false;

            var usersAssignedToTeam = _context.Users.Where(x => x.TeamId == id).ToList();

            foreach (var user in usersAssignedToTeam)
                user.TeamId = null;

            _context.SaveChanges();

            _context.Teams.Remove(team);
            _context.SaveChanges();

            return true;
        }

        public ICollection<Team> GetAssignableTeamsForProduct(int productId)
        {
            return _context.Teams.Where(x => x.ProductId != productId).ToList();
        }

        public ICollection<User> GetAsignableUsersForTeam(int teamId)
        {
            return _context.Users.Where(x=>x.UserType != DomainClasses.Enums.UserType.Admin).Where(x => x.TeamId != teamId).ToList();
        }

        public bool AssignUserToTeam(int teamId, string userEmail)
        {
            if (GetById(teamId) == null)
                return false;

            var user = _context.Users.Where(x => x.Email == userEmail).FirstOrDefault();

            if (user == null)
                return false;

            user.TeamId = teamId;
            user.UserType = DomainClasses.Enums.UserType.TeamMember;
            _context.SaveChanges();

            return true;
        }

        public bool UnAssignUserFromTeam(string userEmail)
        {
            var user = _context.Users.Where(x => x.Email == userEmail).FirstOrDefault();

            if (user == null)
                return false;

            user.TeamId = null;
            user.UserType = DomainClasses.Enums.UserType.None;

            //if team lead unassign as lead
            if (user.Team.TeamLeaderId == user.Id)
                user.Team.TeamLeaderId = null;

            _context.SaveChanges();

            return true;
        }

        public bool SetTeamLeader(int teamId, int userId)
        {
            var team = GetById(teamId);

            if (team == null)
                return false;

            var user = _context.Users.Find(userId);

            if (user == null)
                return false;

            var formerTeamLeader = team.TeamLeaderId != null ? _context.Users.Find(team.TeamLeaderId) : null;

            if (formerTeamLeader != null)
                formerTeamLeader.UserType = DomainClasses.Enums.UserType.TeamMember;

            team.TeamLeaderId = userId;
            user.UserType = DomainClasses.Enums.UserType.TeamLeader;

            _context.SaveChanges();

            return true;
        }

        public Team GetTeamWithRelatedItems(int id)
        {
            return _context.Teams.Where(x => x.Id == id).Include(x => x.TeamLeader).FirstOrDefault();
        }

    }
}
