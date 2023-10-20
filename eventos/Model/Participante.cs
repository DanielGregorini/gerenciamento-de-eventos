using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eventos.Classes
{
    [Table("tb_participante")]
    class Participante
    {
        [Key]
        public int IdParticipante { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<ParticipanteEvento> EventosInscritos { get; set; }

        
    }
}
