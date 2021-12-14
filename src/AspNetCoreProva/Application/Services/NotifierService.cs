using Application.Domain.Entities;
using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NotifierService : INotifierService
    {
        private readonly List<Notifier> _notifications = new List<Notifier>();

        public void AddError(string errorMessage)
        {
            _notifications.Add(new Notifier(errorMessage));
        }

        public IEnumerable<Notifier> GetErrors()
        {
            return _notifications;
        }

        public bool HasError()
        {
            return _notifications.Any();
        }
    }
}
