using Crud_Medico_Paciente.Application.Interfaces;
using Crud_Medico_Paciente.Application.Notificacoes;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Crud_Medico_Paciente.Application.Utils
{
    public class NotificationContext 
    {
        private readonly List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotification => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
