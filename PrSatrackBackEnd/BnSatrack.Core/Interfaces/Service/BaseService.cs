using BnSatrack.Core.Interfaces.Repository;

namespace BnSatrack.Core.Interfaces.Service
{
    public class BaseService
    {
        protected internal IUnitOfWork UnitOfWork { get; set; }
        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
