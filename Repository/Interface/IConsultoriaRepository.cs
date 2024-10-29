using TargetCustomer.Models;

namespace TargetCustomer.Repository.Interface
{
    public interface IConsultoriaRepository
    {
        Task<IEnumerable<Consultoria>> GetConsultorias();
        Task<Consultoria> GetConsultoria(int consulid);
        Task<Consultoria> AddConsultoria(Consultoria consultoria);
        Task<Consultoria> UpdateConsultoria(Consultoria consultoria);
        void DeleteConsultoria(int consulid);
    }
}
