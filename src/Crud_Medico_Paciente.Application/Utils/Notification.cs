namespace Crud_Medico_Paciente.Application.Notificacoes
{
    public class Notification
    {

        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }
}
