using System.Data;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Negocio
{
    public interface IServicio
    {
        Task<DataTable> ListarPersonas();
        Task<Resultado> RegistrarPersona(Persona ent);
        Task<Resultado> EliminarPersona(Persona ent);
        Task<Resultado> ActualizarPersona(Persona ent);
    }
}
