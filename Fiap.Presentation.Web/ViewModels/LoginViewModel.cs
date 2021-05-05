using System.ComponentModel;

namespace Fiap.Presentation.Web.ViewModels
{
    public class LoginViewModel
    {
        public string UserName{ get; set; }
        public string Password { get; set; }
        
        [DisplayName("Salvar login")]
        public bool IsPersistent { get; set; }
    }
}
