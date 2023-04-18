using ClinicaVeterinaria.API.Models;

namespace ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services
{
    public interface IVeterinarioService
    {
        public Task<List<VeterinarioModel>> ListarVeterinarios();
        public Task<bool> DeletarVeterinario(int veterinarioId);
        public Task<VeterinarioModel> CadastrarVeterinario(VeterinarioModel veterinario);
        public Task<VeterinarioModel> BuscarVeterinarioPorId(int idVeterinario);
        //public Task<VeterinarioModel> BuscarVeterinarioPeloNome(string nomeVeterinario);
    }
}
