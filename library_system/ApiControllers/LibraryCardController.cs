using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace library_system.ApiControllers
{
    public class LibraryCardController : ApiController
    {
        Data.LibrarySystemDbDataContext db = new Data.LibrarySystemDbDataContext();

        // GET api/<controller>
        public IEnumerable<Api_Models.MstLibraryCard_ApiModel> Get()
        {
            var libCards = from d in db.MstLibraryCards
                           select new Api_Models.MstLibraryCard_ApiModel
                           {
                               Id = d.Id,
                               LibraryCardNumber = d.LibraryCardNumber,
                               ManualLibraryCardNumber = d.ManualLibraryCardNumber,
                               BorrowerId = d.BorrowerId,
                               IsPrinted = d.IsPrinted,
                               LibraryInChargeUserId = d.LibraryInChargeUserId,
                               FootNote = d.FootNote,
                               CreatedByUserId = d.CreatedByUserId,
                               CreatedDate = d.CreatedDate,
                               UpdatedByUserId = d.UpdatedByUserId,
                               UpdatedDate = d.UpdatedDate,
                        };
            return libCards.ToList();

        }

        // GET api/<controller>/5
        public Api_Models.MstLibraryCard_ApiModel Get(int id)
        {
            var libCards = from d in db.MstLibraryCards
                        where d.Id == id
                        select new Api_Models.MstLibraryCard_ApiModel
                        {
                            Id = d.Id,
                            LibraryCardNumber = d.LibraryCardNumber,
                            ManualLibraryCardNumber = d.ManualLibraryCardNumber,
                            BorrowerId = d.BorrowerId,
                            IsPrinted = d.IsPrinted,
                            LibraryInChargeUserId = d.LibraryInChargeUserId,
                            FootNote = d.FootNote,
                            CreatedByUserId = d.CreatedByUserId,
                            CreatedDate = d.CreatedDate,
                            UpdatedByUserId = d.UpdatedByUserId,
                            UpdatedDate = d.UpdatedDate,
                        };
            return libCards.FirstOrDefault();

        }

        // POST api/<controller>
        public HttpResponseMessage Post( Api_Models.MstLibraryCard_ApiModel objLibCard)
        {
            try
            {
                Data.MstLibraryCard newLibCard = new Data.MstLibraryCard
                {
                    LibraryCardNumber = objLibCard.LibraryCardNumber,
                    ManualLibraryCardNumber = objLibCard.ManualLibraryCardNumber,
                    BorrowerId = objLibCard.BorrowerId,
                    IsPrinted = objLibCard.IsPrinted,
                    LibraryInChargeUserId = objLibCard.LibraryInChargeUserId,
                    FootNote = objLibCard.FootNote,
                    CreatedByUserId = objLibCard.CreatedByUserId,
                    CreatedDate = objLibCard.CreatedDate,
                    UpdatedByUserId = objLibCard.UpdatedByUserId,
                    UpdatedDate = objLibCard.UpdatedDate,
                };
                db.MstLibraryCards.InsertOnSubmit(newLibCard);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Api_Models.MstLibraryCard_ApiModel objLibCard)
        {
            try
            {
                var libraryCard = from d in db.MstLibraryCards
                                  where d.Id == id
                                  select d;

                if (libraryCard.Any())
                {
                    var updateLibCard = libraryCard.FirstOrDefault();
                    updateLibCard.LibraryCardNumber = objLibCard.LibraryCardNumber;
                    updateLibCard.ManualLibraryCardNumber = objLibCard.ManualLibraryCardNumber;
                    updateLibCard.BorrowerId = objLibCard.BorrowerId;
                    updateLibCard.IsPrinted = objLibCard.IsPrinted;
                    updateLibCard.LibraryInChargeUserId = objLibCard.LibraryInChargeUserId;
                    updateLibCard.FootNote = objLibCard.FootNote;
                    updateLibCard.CreatedByUserId = objLibCard.CreatedByUserId;
                    updateLibCard.CreatedDate = objLibCard.CreatedDate;
                    updateLibCard.UpdatedByUserId = objLibCard.UpdatedByUserId;
                    updateLibCard.UpdatedDate = objLibCard.UpdatedDate;
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Library Card not found!");
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
                var libraryCard = from d in db.MstLibraryCards
                                  where d.Id == id
                                  select d;

                if (libraryCard.Any())
                {
                    db.MstLibraryCards.DeleteOnSubmit(libraryCard.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Library Card not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}