using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace library_system.ApiControllers
{
    public class UserTypeController : ApiController
    {
        Data.LibrarySystemDbDataContext db = new Data.LibrarySystemDbDataContext();

        // GET api/<controller>
        public IEnumerable<Api_Models.MstUserType_ApiModel> Get()
        {
            var userTypes = from d in db.MstUserTypes
                        select new Api_Models.MstUserType_ApiModel
                        {
                            Id = d.Id,
                            UserType = d.UserType,
                        };
            return userTypes.ToList();
        }

        // GET api/<controller>/5
        public Api_Models.MstUserType_ApiModel Get(int id)
        {
            var userTypes = from d in db.MstUserTypes
                            where d.Id == id
                            select new Api_Models.MstUserType_ApiModel
                            {
                                Id = d.Id,
                                UserType = d.UserType,
                            };
            return userTypes.FirstOrDefault();
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Api_Models.MstUserType_ApiModel objUserType)
        {
            try
            {
                Data.MstUserType newUserType = new Data.MstUserType
                {
                    UserType = objUserType.UserType,
                };
                db.MstUserTypes.InsertOnSubmit(newUserType);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Api_Models.MstUserType_ApiModel objUserType)
        {
            try
            {
                var userType = from d in db.MstUserTypes
                               where d.Id == id
                               select d;

                if (userType.Any())
                {
                    var updateUserType = userType.FirstOrDefault();
                    updateUserType.UserType = objUserType.UserType;
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found!");
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
                var userType = from d in db.MstUserTypes
                           where d.Id == id
                           select d;

                if (userType.Any())
                {
                    db.MstUserTypes.DeleteOnSubmit(userType.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}