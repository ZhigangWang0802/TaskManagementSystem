using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace Repository
{
    public class UnitOfWork
    {

        private TaskManagerEntities context = new TaskManagerEntities();
        private IGenericRepo<tblQuote> quoteRepo;


        public IGenericRepo<tblQuote> QuoteRepo
        {
            get
            {

                if (this.quoteRepo == null)
                {
                    this.quoteRepo = new GenericRepo<tblQuote>(context);
                }
                return quoteRepo;
            }
        }


    }
}
