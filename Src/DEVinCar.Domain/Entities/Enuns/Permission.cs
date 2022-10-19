using System.ComponentModel.DataAnnotations;


namespace DEVinCar.Domain.Entities.Enuns
{
    public enum Permission
    {
        [Display(Name = "Funcionario")]
        Funcionario,

        [Display(Name = "Gerente")]
        Gerente,

        [Display(Name = "Administrador")]
        Administrador,
        [Display(Name = "CEO")]
         CEO,
        [Display(Name = "Estagiario")]
        Estagiario,

        [Display(Name = "Vendedor")]
        Vendedor,

        [Display(Name = "Chefe")]
        Chefe,
        [Display(Name = "Diretor")]
        Diretor,

        [Display(Name = "Avalista")]
        Avalista,

        
    }
}