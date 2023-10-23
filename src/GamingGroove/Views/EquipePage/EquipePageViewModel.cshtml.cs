using GamingGroove.Data;
using GamingGroove.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GamingGroove.Views.EquipePage
{
    public class EquipePageViewModel : PageModel
    {
        private readonly GamingGrooveDbContext _cc;

        public EquipePageViewModel(GamingGrooveDbContext cc)
        {
            _cc = cc;
        }

        public IEnumerable<EquipeModel> getEquipes { get; set; }
        public UsuarioModel getUsuario { get; set; }
        public IEnumerable<UsuarioEquipeModel> getEquipesUsuario { get; set; }
        public List<string> NomeDasEquipes { get; set; }

        public void GetEquipesUsuario(int usuario)
        {
            getEquipesUsuario = _cc.UsuariosEquipes
                .Where(ue => ue.usuarioId == usuario)
                .Include(ue => ue.equipe)
                .ToList();        

            NomeDasEquipes = getEquipesUsuario.Select(ue => ue.equipe.nomeEquipe).ToList();
        }
    }
}