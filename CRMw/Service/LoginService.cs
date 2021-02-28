using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LoginService : ILoginService
    {
        private IUsuarioRepository _repository;

        private SigninConfigurations _signinConfigurations { get; set; }

        private TokenConfigurations _tokenConfigurations { get; set; }

        private IConfiguration _configuration { get;}

        public LoginService(IUsuarioRepository repository, SigninConfigurations signinConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration)
        {
            _repository = repository;
            _signinConfigurations = signinConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<object> CarregarPorLoginSenha(LoginDTO login)
        {
            var baseUsuario = new UsuarioEntity();
            
            if (login != null && (!string.IsNullOrWhiteSpace(login.Usuario) && !string.IsNullOrWhiteSpace(login.Senha)))
            {
                baseUsuario = await _repository.BuscarUsuarioSenha(login.Usuario, login.Senha);

                if (baseUsuario == null || (baseUsuario.Deletado || baseUsuario.Desativado))
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar usuário e senha."
                    };
                }
                else
                {
                    //IMPLEMENTAÇÃO DO JWT
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUsuario.Usuario), 
                        new[] { 
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, baseUsuario.Usuario),
                        }
                    );

                    DateTime createDate = DateTime.Now;
                    //Pego a data configurada no arquivo appsetting para defirnir o tempo de vida do token. 120 s.
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();

                    string token = CreateToken(identity, createDate, expirationDate, handler);

                    return SuccessObject(createDate, expirationDate, token, login);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar usuário e senha."
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime exprirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor { 
            
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signinConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = exprirationDate
            });

            return handler.WriteToken(securityToken);
        }

        private object SuccessObject(DateTime createDate, DateTime exprirationDate, string token, LoginDTO login)
        {
            return new
            {
                authenticated = true,
                createDate = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = exprirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                usarName = login.Usuario,
                message = "Usuário logado com sucesso."
            };
        }
    }
}
