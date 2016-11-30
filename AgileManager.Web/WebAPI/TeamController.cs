using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileManager.Web.WebAPI
{
    public class TeamController : ApiController
    {
        public IEnumerable<string> GetAssignableUsersForTeam(int id, string input)
        {
            var repo = new TeamRepository();

            var assignableTeams = repo.GetAsignableUsersForTeam(id);

            return assignableTeams.Where(x => x.Email.Contains(input)).Select(x => x.Email).ToList();
        }

        public IHttpActionResult GetAssignUserToTeam(int id, string name)
        {
            var repo = new TeamRepository();

            if (!repo.AssignUserToTeam(id, name))
                return NotFound();

            return Ok();
        }

        [HttpPost]
        public HttpResponseMessage PostUnassignUser([FromBody] string name)
        {
            var repo = new TeamRepository();

            if (!repo.UnAssignUserFromTeam(name))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
