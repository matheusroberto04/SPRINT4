using TargetCustomer.Models;

namespace TargetCustomer.Repository.Interface
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(int clienteid);
        Task<Cliente> AddCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(Cliente cliente);
        void DeleteCliente(int clienteId);
    }
}
