using System.Data;
using System.Threading.Tasks;

namespace WebApi.Negocio
{
    public interface IServicio
    {
        Task<DataTable> ListarPersonas();
    }
}
