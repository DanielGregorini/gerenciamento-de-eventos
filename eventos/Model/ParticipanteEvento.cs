using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eventos.Classes
{
    [Table("tb_participante_evento")]
    class ParticipanteEvento
    {
        public int IdParticipanteEvento { get; set; }
        public int IdParticipante { get; set; }
        public Participante Participante { get; set; }
        public int IdEvento { get; set; }
        public Evento Evento { get; set; }
    }
}
