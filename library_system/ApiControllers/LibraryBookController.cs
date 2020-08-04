using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace library_system.ApiControllers
{
    public class LibraryBookController : ApiController
    {
        Data.LibrarySystemDbDataContext db = new Data.LibrarySystemDbDataContext();

        // GET api/<controller>
        public IEnumerable<Api_Models.MstLibraryBook_ApiModel> Get()
        {
            var books = from d in db.MstLibraryBooks
                        select new Api_Models.MstLibraryBook_ApiModel
                        {
                            Id = d.Id,
                            BookNumber = d.BookNumber,
                            Title = d.Title,
                            Author = d.Author,
                            EditionNumber = d.EditionNumber,
                            PlaceOfPublication = d.PlaceOfPublication,
                            CopyRightDate = d.CopyRightDate,
                            ISBN = d.ISBN,
                            CreatedByUserId = d.CreatedByUserId,
                            CreatedBy = d.CreatedBy,
                            CreatedDate = d.CreatedDate,
                            UpdatedByUserId = d.UpdatedByUserId,
                            UpdatedBy = d.UpdatedBy,
                            UpdatedDate = d.UpdatedDate,
                        };
            return books.ToList();
        }

        // GET api/<controller>/5
        public Api_Models.MstLibraryBook_ApiModel Get(int id)
        {
            var books = from d in db.MstLibraryBooks
                        where d.Id == id
                        select new Api_Models.MstLibraryBook_ApiModel
                        {
                            Id = d.Id,
                            BookNumber = d.BookNumber,
                            Title = d.Title,
                            Author = d.Author,
                            EditionNumber = d.EditionNumber,
                            PlaceOfPublication = d.PlaceOfPublication,
                            CopyRightDate = d.CopyRightDate,
                            ISBN = d.ISBN,
                            CreatedByUserId = d.CreatedByUserId,
                            CreatedBy = d.CreatedBy,
                            CreatedDate = d.CreatedDate,
                            UpdatedByUserId = d.UpdatedByUserId,
                            UpdatedBy = d.UpdatedBy,
                            UpdatedDate = d.UpdatedDate,
                        };
            return books.FirstOrDefault();
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Api_Models.MstLibraryBook_ApiModel objBook)
        {
            try
            {
                Data.MstLibraryBook newBook = new Data.MstLibraryBook
                {
                    BookNumber = objBook.BookNumber,
                    Title = objBook.Title,
                    Author = objBook.Author,
                    EditionNumber = objBook.EditionNumber,
                    PlaceOfPublication = objBook.PlaceOfPublication,
                    CopyRightDate = objBook.CopyRightDate,
                    ISBN = objBook.ISBN,
                    CreatedByUserId = objBook.CreatedByUserId,
                    CreatedBy = objBook.CreatedBy,
                    CreatedDate = objBook.CreatedDate,
                    UpdatedByUserId = objBook.UpdatedByUserId,
                    UpdatedBy = objBook.UpdatedBy,
                    UpdatedDate = objBook.UpdatedDate,
                };
                db.MstLibraryBooks.InsertOnSubmit(newBook);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Api_Models.MstLibraryBook_ApiModel objBook)
        {
            try
            {
                var book = from d in db.MstLibraryBooks
                           where d.Id == id
                           select d;

                if (book.Any())
                {
                    var updateBook = book.FirstOrDefault();
                    updateBook.BookNumber = objBook.BookNumber;
                    updateBook.Title = objBook.Title;
                    updateBook.Author = objBook.Author;
                    updateBook.EditionNumber = objBook.EditionNumber;
                    updateBook.CopyRightDate = objBook.CopyRightDate;
                    updateBook.ISBN = objBook.ISBN;
                    updateBook.CreatedByUserId = objBook.CreatedByUserId;
                    updateBook.CreatedBy = objBook.CreatedBy;
                    updateBook.CreatedDate = objBook.CreatedDate;
                    updateBook.UpdatedByUserId = objBook.UpdatedByUserId;
                    updateBook.UpdatedBy = objBook.UpdatedBy;
                    updateBook.UpdatedDate = objBook.UpdatedDate;
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Book not found!");
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
                var book = from d in db.MstLibraryBooks
                           where d.Id == id
                           select d;

                if (book.Any())
                {
                    db.MstLibraryBooks.DeleteOnSubmit(book.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Book not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}