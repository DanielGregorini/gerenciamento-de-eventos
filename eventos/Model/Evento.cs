using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos.Classes
{
    [Table("tb_evento")]
    class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public int LocalID { get; set; }
        public Local? Local { get; set; }
        public int OrganizadorID { get; set; }
        public Organizador Organizador { get; set; }
        public List<ParticipanteEvento> ParticipantesInscritos { get; set; }
    
    }
}
