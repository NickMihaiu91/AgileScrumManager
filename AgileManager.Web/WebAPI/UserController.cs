using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileManager.Web.WebAPI
{
    public class UserController : ApiController
    {
        public IEnumerable<string> GetAssignableUsersForPO(int id, string input)
        {
            var repo = new UserRepository();

            var assignableUsers = repo.GetAssignableUsersForProductOwnerState();

            return assignableUsers.Where(x => x.Email.Contains(input)).Select(x => x.Email).ToList();
        }

        public IHttpActionResult GetAssignProductOwnerToProduct(int id, string name)
        {
            var repo = new UserRepository();

            if (!repo.AssignProductOwnerToProduct(id, name))
                return NotFound();

            return Ok();
        }

        [HttpPost]
        public HttpResponseMessage PostUnassignPO([FromBody] string name)
        {
            var repo = new UserRepository();

            if (!repo.UnAssignProductOwnerFromProduct(name))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
