using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace library_system.ApiControllers
{
    public class UserController : ApiController
    {
        Data.LibrarySystemDbDataContext db = new Data.LibrarySystemDbDataContext();

        // GET api/<controller>
        public IEnumerable<Api_Models.MstUser_ApiModel> Get()
        {
            var users = from d in db.MstUsers
                        select new Api_Models.MstUser_ApiModel
                        {
                            Id = d.Id,
                            FirstName = d.FirstName,
                            LastName = d.LastName,
                            Password = d.Password,
                            UserTypeId = d.UserTypeId,
                            AspNetUserId = d.AspNetUserId,
                            UserName = d.UserName,
                            Email = d.Email,
                        };
            return users.ToList();
        }

        // GET api/<controller>/5
        public Api_Models.MstUser_ApiModel Get(int id)
        {
            var users = from d in db.MstUsers
                          where d.Id == id
                          select new Api_Models.MstUser_ApiModel
                          {
                              Id = d.Id,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              Password = d.Password,
                              UserTypeId = d.UserTypeId,
                              AspNetUserId = d.AspNetUserId,
                              UserName = d.UserName,
                              Email = d.Email,
                          };
            return users.FirstOrDefault();
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Api_Models.MstUser_ApiModel objUser)
        {
            try
            {
                Data.MstUser newUser = new Data.MstUser
                {
                    FirstName = objUser.FirstName,
                    LastName = objUser.LastName,
                    Password = objUser.Password,
                    UserTypeId = objUser.UserTypeId,
                    AspNetUserId = objUser.AspNetUserId,
                    UserName = objUser.UserName,
                    Email = objUser.Email,
                };
                db.MstUsers.InsertOnSubmit(newUser);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(String Id, Api_Models.MstUser_ApiModel objUser)
        {
            try
            {
                var user = from d in db.MstUsers
                             where d.Id == Convert.ToInt32(Id)
                             select d;

                if (user.Any())
                {
                    var updateUser = user.FirstOrDefault();
                    updateUser.FirstName = objUser.FirstName;
                    updateUser.LastName = objUser.LastName;
                    updateUser.Password = objUser.Password;
                    updateUser.UserTypeId = objUser.UserTypeId;
                    updateUser.AspNetUserId = objUser.AspNetUserId;
                    updateUser.UserName = objUser.UserName;
                    updateUser.Email = objUser.Email;
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "User not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var user = from d in db.MstUsers
                             where d.Id == id
                             select d;

                if (user.Any())
                {
                    db.MstUsers.DeleteOnSubmit(user.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}