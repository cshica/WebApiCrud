using System.Data;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Negocio
{
    public partial class Servicio : IServicio
    {
        public async Task<DataTable> ListarPersonas()
        {
           return await PersonaData.ListarPersonas();
        }
    }
}
