using System.Data;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Negocio
{
    public partial class Servicio : IServicio
    {
        public async Task<DataTable> ListarPersonas()
        {
           return await PersonaData.ListarPersonas();
        }

        public async Task<Resultado> RegistrarPersona(Persona ent)
        {
            return await PersonaData.RegistrarPersona(ent);
        }
    }
}
