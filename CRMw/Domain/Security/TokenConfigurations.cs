using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Security
{
    /// <summary>
    /// Configura Token.
    /// </summary>
    public class TokenConfigurations
    {
        /// <summary>
        /// Publico.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Emissor
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Tempo de vida.
        /// </summary>
        public int Seconds { get; set; }


    }
}
