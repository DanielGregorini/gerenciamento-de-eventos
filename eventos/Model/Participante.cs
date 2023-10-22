using System.ComponentModel.DataAnnotations;
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
