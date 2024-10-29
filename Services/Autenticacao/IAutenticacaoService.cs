using TargetCustomer.Dtos;

namespace TargetCustomer.Services.Autenticacao
{
    public interface IAutenticacaoService
    {
        Task<string> CadastroAsync(CadastroDto request);
        Task<string> LoginAsync(LoginDto request);
    }
}
