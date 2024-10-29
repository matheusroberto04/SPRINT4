using Microsoft.EntityFrameworkCore;
using TargetCustomer.Data;
using TargetCustomer.Models;
using TargetCustomer.Repository.Interface;

namespace TargetCustomer.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly dbContext dbContext;

        public ClienteRepository(dbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            var result = await dbContext.Clientes.AddAsync(cliente);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Cliente> GetCliente(int clienteId)
        {
            return await dbContext.Clientes.FirstOrDefaultAsync(
                x => x.ClienteId == clienteId);
        }
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            var result = await dbContext.Clientes.FirstOrDefaultAsync(
                x => x.ClienteId == cliente.ClienteId);
            if (result != null)
            {
                result.CNPJ = cliente.CNPJ;
                result.Nome = cliente.Nome;
                result.Logradouro = cliente.Logradouro;
                result.RamodeAtuacao = cliente.RamodeAtuacao;
                result.Email = cliente.Email;
                result.Senha = cliente.Senha;
                
                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async void DeleteCliente(int clienteId)
        {
            var result = await dbContext.Clientes.FirstOrDefaultAsync(
                x => x.ClienteId == clienteId);
            if (result != null) 
            {
                dbContext.Clientes.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
