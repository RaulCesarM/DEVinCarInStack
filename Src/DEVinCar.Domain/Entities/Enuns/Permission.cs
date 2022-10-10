using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.Entities.Enuns
{
    public enum Permission
    {
        [Display(Name = "Funcionario")]
        Funcionario,

        [Display(Name = "Gerente Geral")]
        Gerente,

        [Display(Name = "Administrador do Sistema")]
        Administrador,
    }
}