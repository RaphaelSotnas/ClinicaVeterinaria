using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services;
using ClinicaVeterinaria.Repository.Interfaces;

namespace ClinicaVeterinaria.API.Services
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly IVeterinarioRepository _veterinarioRepository;
        public VeterinarioService(IVeterinarioRepository veterinarioRepository)
        {
            _veterinarioRepository = veterinarioRepository;
        }

        public Task<VeterinarioModel> CadastrarVeterinario(VeterinarioModel veterinario)
        {
            veterinario.DataCadastro = DateTime.Now;

            return _veterinarioRepository.CadastrarVeterinario(veterinario);
        }

        public async Task<bool> DeletarVeterinario(int veterinarioId)
        {
            return await _veterinarioRepository.DeletarVeterinario(veterinarioId);
        }

        public async Task<List<VeterinarioModel>> ListarVeterinarios()
        {
            var listaRetorno = await _veterinarioRepository.BuscarVeterinarios();
            if (listaRetorno == null || listaRetorno.Count() == 0)
                return null;

            return listaRetorno;
        }

        public async Task<VeterinarioModel> BuscarVeterinarioPorId(int idVeterinario)
        {
            var veterinarioDoBanco = await _veterinarioRepository.BuscarVeterinarioPorId(idVeterinario);
            if (veterinarioDoBanco == null)
                return null;

            return veterinarioDoBanco;
        }

        //public async Task<VeterinarioModel> BuscarVeterinarioPeloNome(string nomeVeterinario)
        //{
        //    var veterinarioDoBanco = await _veterinarioRepository.BuscarVeterinarioPeloNome(nomeVeterinario);
        //    if (veterinarioDoBanco == null)
        //        return null;

        //    return veterinarioDoBanco;
        //}
    }
}
