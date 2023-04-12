using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Repository.Interfaces
{
    public interface IVeterinarioRepository
    {
        Task<List<VeterinarioModel>> BuscarVeterinarios();
        Task<VeterinarioModel> BuscarVeterinarioPorId(int idVeterinario);
        Task<VeterinarioModel> CadastrarVeterinario(VeterinarioModel veterinario);
        Task<bool> DeletarVeterinario(int idVeterinario);
        Task<VeterinarioModel> AtualizarVeterinario(VeterinarioModel veterinarioAtualizado, int idVeterinario);
    }
}
