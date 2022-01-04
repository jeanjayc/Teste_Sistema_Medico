using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Medico_Paciente.Domain.Entities
{
    public class Doctor: Entity
    {
        public string Name { get; set; }
        public string CRM { get; set; }
        public string CRMUF { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
    }
}
