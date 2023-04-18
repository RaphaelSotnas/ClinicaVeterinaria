using ClinicaVeterinaria.API.Models;


namespace ClinicaVeterinaria.API.Domain.Interfaces.InterfacesRepository
{
    public interface IVeterinarioRepository
    {
        Task<List<VeterinarioModel>> BuscarVeterinarios();
        Task<VeterinarioModel> CadastrarVeterinario(VeterinarioModel veterinario);
        Task<bool> DeletarVeterinario(int idVeterinario);
        Task<VeterinarioModel> BuscarVeterinarioPorId(int idVeterinario);
        //Task<VeterinarioModel> BuscarVeterinarioPeloNome(string nomeVeterinario);
        //Task<VeterinarioModel> AtualizarVeterinario(VeterinarioModel veterinarioAtualizado, int idVeterinario);
    }
}
