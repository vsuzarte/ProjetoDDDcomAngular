using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Usuario é um campo obrigatório para Login")]
        [StringLength(100, ErrorMessage = "Usuario deve ter no máximo {1} caracteres.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigatório para Login")]
        [StringLength(100, ErrorMessage = "Senha deve ter no máximo {1} caracteres.")]
        public string Senha { get; set; }
    }
}
