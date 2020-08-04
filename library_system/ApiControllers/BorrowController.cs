using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace library_system.ApiControllers
{
    public class BorrowController : ApiController
    {
        Data.LibrarySystemDbDataContext db = new Data.LibrarySystemDbDataContext();

        // GET api/<controller>
        public IEnumerable<Api_Models.TrnBorrow_ApiModel> Get()
        {
            var borrows = from d in db.TrnBorrows
                          select new Api_Models.TrnBorrow_ApiModel
                          {
                              Id = d.Id,
                              BorrowNumber = d.BorrowNumber,
                              BookNumber = d.BookNumber,
                              ManualBorrowNumber = d.ManualBorrowNumber,
                              BorrowerId = d.BorrowerId,
                              LibraryCardId = d.LibrryCardId,
                              PreparedByUser = d.PreparedByUser,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedDate = d.CreatedDate,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedDate = d.UpdatedDate,
                          };
            return borrows.ToList();
        }

        // GET api/<controller>/5
        public Api_Models.TrnBorrow_ApiModel Get(int id)
        {
            var borrows = from d in db.TrnBorrows
                          where d.Id == id 
                          select new Api_Models.TrnBorrow_ApiModel
                          {
                              Id = d.Id,
                              BorrowNumber = d.BorrowNumber,
                              BookNumber = d.BookNumber,
                              ManualBorrowNumber = d.ManualBorrowNumber,
                              BorrowerId = d.BorrowerId,
                              LibraryCardId = d.LibrryCardId,
                              PreparedByUser = d.PreparedByUser,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedDate = d.CreatedDate,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedDate = d.UpdatedDate,
                          };
            return borrows.FirstOrDefault();
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Api_Models.TrnBorrow_ApiModel objBorrows)
        {
            try
            {
                Data.TrnBorrow newBorrows = new Data.TrnBorrow
                {
                    BorrowNumber = objBorrows.BorrowNumber,
                    BookNumber = objBorrows.BookNumber,
                    BorrowDate = objBorrows.BorrowDate,
                    ManualBorrowNumber = objBorrows.ManualBorrowNumber,
                    BorrowerId = objBorrows.BorrowerId,
                    LibrryCardId = objBorrows.LibraryCardId,
                    PreparedByUser = objBorrows.PreparedByUser,
                    CreatedByUserId = objBorrows.CreatedByUserId,
                    CreatedDate = objBorrows.CreatedDate,
                    UpdatedByUserId = objBorrows.UpdatedByUserId,
                    UpdatedDate = objBorrows.UpdatedDate,
                };
                db.TrnBorrows.InsertOnSubmit(newBorrows);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Api_Models.TrnBorrow_ApiModel objBorrows)
        {
            try
            {
                var borrow = from d in db.TrnBorrows
                             where d.Id == id
                             select d;

                if (borrow.Any())
                {
                    var updateBorrow = borrow.FirstOrDefault();
                    updateBorrow.BorrowNumber = objBorrows.BorrowNumber;
                    updateBorrow.BookNumber = objBorrows.BookNumber;
                    updateBorrow.BorrowDate = objBorrows.BorrowDate;
                    updateBorrow.ManualBorrowNumber = objBorrows.ManualBorrowNumber;
                    updateBorrow.BorrowerId = objBorrows.BorrowerId;
                    updateBorrow.LibrryCardId = objBorrows.LibraryCardId;
                    updateBorrow.PreparedByUser = objBorrows.PreparedByUser;
                    updateBorrow.CreatedByUserId = objBorrows.CreatedByUserId;
                    updateBorrow.CreatedDate = objBorrows.CreatedDate;
                    updateBorrow.UpdatedByUserId = objBorrows.UpdatedByUserId;
                    updateBorrow.UpdatedDate = objBorrows.UpdatedDate;
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
                var borrow = from d in db.TrnBorrows
                           where d.Id == id
                           select d;

                if (borrow.Any())
                {
                    db.TrnBorrows.DeleteOnSubmit(borrow.FirstOrDefault());
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