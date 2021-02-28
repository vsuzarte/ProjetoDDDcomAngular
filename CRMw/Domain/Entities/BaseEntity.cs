using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Classe base do sistema.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Chave de identificação da entidade.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Chave de identificação visual da entidade definidade pelo usuário.
        /// </summary>
        public string CodigoVisual { get; set; }

        private DateTime _dataCriacao;

        /// <summary>
        /// Data da criação da entidade;
        /// </summary>
        public DateTime DataCriacao
        {
            get { return _dataCriacao; }
            set { _dataCriacao = (value == null) ? DateTime.Now : value; }
        }

        /// <summary>
        /// Data da última alteração feita na entidade.
        /// </summary>
        public DateTime DataAtualizacao { get; set; }

        /// <summary>
        /// Define se o entidade está ativado ou não.
        /// </summary>
        public bool Desativado { get; set; }

        /// <summary>
        /// Define se o entidade já foi deletada.
        /// </summary>
        public bool Deletado { get; set; }

    }
}
