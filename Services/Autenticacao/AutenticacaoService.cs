using FirebaseAdmin.Auth;
using TargetCustomer.Dtos;
using TargetCustomer.Models;

namespace TargetCustomer.Services.Autenticacao
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;
        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> LoginAsync(LoginDto request)
        {
            var credentials = new
            {
                request.Email,
                request.Password,
                returnSecureToken = true
            };
            var response = await _httpClient.PostAsJsonAsync("", credentials);

            var authFirebasseObject = await response.Content.ReadFromJsonAsync<AutenticacaoFirebase>();

            return authFirebasseObject!.IdToken!;

        }
        public async Task<string> CadastroAsync(CadastroDto request)
        {
            var userArgs = new UserRecordArgs
            {
                Email = request.Email,
                Password = request.Password
            };
            var usuario = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
            return usuario.Uid;
        }

    }
}
