using OnlineFoodOrdering.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models.Application.SeedWork
{
    public abstract class BaseService
    {
        public IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}