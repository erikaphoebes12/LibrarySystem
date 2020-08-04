using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace library_system.ApiControllers
{
    public class BorrowerController : ApiController
    {
        Data.LibrarySystemDbDataContext db = new Data.LibrarySystemDbDataContext();

        // GET api/<controller>
        public IEnumerable<Api_Models.MstBorrower_ApiModel> Get()
        {
            var borrower = from d in db.MstBorrowers
                        select new Api_Models.MstBorrower_ApiModel
                        {
                            Id = d.Id,
                            BorrowerNumber = d.BorrowerNumber,
                            ManualBorrowerNumber = d.ManualBorrowerNumber,
                            FullName = d.FullName,
                            Department = d.Department,
                            Course = d.Course,
                            CreatedByUserId = d.CreatedByUserId,
                            CreatedDate = d.CreatedDate,
                            UpdatedByUserId = d.UpdatedByUserId,
                            UpdatedDate = d.UpdatedDate,
                            BorrowerTypeId = d.BorrowerTypeId,
                            LibraryCardId = d.LibraryCardId,
                        };
            return borrower.ToList();
        }

        // GET api/<controller>/5
        public Api_Models.MstBorrower_ApiModel Get(int id)
        {
            var borrowers = from d in db.MstBorrowers
                           where d.Id == id
                           select new Api_Models.MstBorrower_ApiModel
                           {
                               Id = d.Id,
                               BorrowerNumber = d.BorrowerNumber,
                               ManualBorrowerNumber = d.ManualBorrowerNumber,
                               FullName = d.FullName,
                               Department = d.Department,
                               Course = d.Course,
                               CreatedByUserId = d.CreatedByUserId,
                               CreatedDate = d.CreatedDate,
                               UpdatedByUserId = d.UpdatedByUserId,
                               UpdatedDate = d.UpdatedDate,
                               BorrowerTypeId = d.BorrowerTypeId,
                               LibraryCardId = d.LibraryCardId,
                           };
            return borrowers.FirstOrDefault();
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Api_Models.MstBorrower_ApiModel objBorrower)
        {
            try
            {
                Data.MstBorrower newUser = new Data.MstBorrower
                {
                    BorrowerNumber = objBorrower.BorrowerNumber,
                    ManualBorrowerNumber = objBorrower.ManualBorrowerNumber,
                    FullName = objBorrower.FullName,
                    Department = objBorrower.Department,
                    Course = objBorrower.Course,
                    CreatedByUserId = objBorrower.CreatedByUserId,
                    CreatedDate = objBorrower.CreatedDate,
                    UpdatedByUserId = objBorrower.UpdatedByUserId,
                    UpdatedDate = objBorrower.UpdatedDate,
                    BorrowerTypeId = objBorrower.BorrowerTypeId,
                    LibraryCardId = objBorrower.LibraryCardId
                };
                db.MstBorrowers.InsertOnSubmit(newUser);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Api_Models.MstBorrower_ApiModel objBorrower)
        {
            try
            {
                var borrower = from d in db.MstBorrowers
                           where d.Id == id
                           select d;

                if (borrower.Any())
                {
                    var updateBorrower = borrower.FirstOrDefault();
                    updateBorrower.BorrowerNumber = objBorrower.BorrowerNumber;
                    updateBorrower.ManualBorrowerNumber = objBorrower.ManualBorrowerNumber;
                    updateBorrower.FullName = objBorrower.FullName;
                    updateBorrower.Department = objBorrower.Department;
                    updateBorrower.Course = objBorrower.Course;
                    updateBorrower.CreatedByUserId = objBorrower.CreatedByUserId;
                    updateBorrower.CreatedDate = objBorrower.CreatedDate;
                    updateBorrower.UpdatedByUserId = objBorrower.UpdatedByUserId;
                    updateBorrower.UpdatedDate = objBorrower.UpdatedDate;
                    updateBorrower.BorrowerTypeId = objBorrower.BorrowerTypeId;
                    updateBorrower.LibraryCardId = objBorrower.LibraryCardId;
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Borrower not found!");
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
                var borrower = from d in db.MstBorrowers
                           where d.Id == id
                           select d;

                if (borrower.Any())
                {
                    db.MstBorrowers.DeleteOnSubmit(borrower.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Borrower not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}