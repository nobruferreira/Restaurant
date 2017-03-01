using Restaurant.Data.Persistence.UoW;
using Restaurant.SharedKernel;
using Restaurant.SharedKernel.Events;

namespace Restaurant.Application.Services
{
    public class ApplicationServiceBase
    {
        private IUnitOfWork _unitOfWork;
        private IHandler<DomainNotification> _notifications;

        public ApplicationServiceBase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}