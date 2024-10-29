using Microsoft.EntityFrameworkCore;
using TargetCustomer.Data;
using TargetCustomer.Models;
using TargetCustomer.Repository.Interface;

namespace TargetCustomer.Repository
{
    public class ConsultoriaRepository : IConsultoriaRepository
    {
        private readonly dbContext dbContext;
        public ConsultoriaRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Consultoria> AddConsultoria(Consultoria consultoria)
        {
            var result = await dbContext.Consultorias.AddAsync(consultoria);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Consultoria> GetConsultoria(int consulid)
        {
            return await dbContext.Consultorias.FirstOrDefaultAsync(
                x => x.ConsultoriaId == consulid);
        }
        public async Task<IEnumerable<Consultoria>> GetConsultorias()
        {
            return await dbContext.Consultorias.ToListAsync();
        }
        public async Task<Consultoria> UpdateConsultoria(Consultoria consultoria)
        {
            var result = await dbContext.Consultorias.FirstOrDefaultAsync(
                x => x.ConsultoriaId == consultoria.ConsultoriaId);
            if (result != null)
            {
                result.ConsultoriaId = consultoria.ConsultoriaId;
                result.NomeConsultoria = consultoria.NomeConsultoria;
                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async void DeleteConsultoria(int consulid)
        {
            var result = await dbContext.Consultorias.FirstOrDefaultAsync(
                x => x.ConsultoriaId == consulid);
            if (result != null)
            {
                dbContext.Consultorias.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
