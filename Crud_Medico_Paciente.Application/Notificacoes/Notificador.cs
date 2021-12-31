using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Application.Notificacoes
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacaos;

        public Notificador()
        {
            _notificacaos = new List<Notificacao>();
        }
        
        //Metodo que adiciona notificacoes na lista de notificacoes
        public void Handle(Notificacao notificacao)
        {
            _notificacaos.Add(notificacao);
        }

        public bool TemNotificacao()
        {
            return _notificacaos.Any();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacaos;
        }

    }
}
