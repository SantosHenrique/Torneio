
using System.Threading.Tasks;

namespace HenriqueSantos.Torneio.Negocio.Interfaces.Repositories
{
    public interface IUnitOfWork 
    {
        ICampeonatoRepository CampeonatoRepository { get; }
        Task SaveChangesAsync();
    }
}
