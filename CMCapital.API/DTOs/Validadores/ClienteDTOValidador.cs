using FluentValidation;

namespace CMCapital.API.DTOs.Validadores;

public class ClienteDTOValidador : AbstractValidator<ClienteDTO>
{
    public ClienteDTOValidador()
    {
        RuleFor(x => x.Nome)
            .NotNull().WithMessage("O nome não pode ser nulo")
            .NotEmpty().WithMessage("O nome não pode estar vazio")
            .MinimumLength(4).WithMessage("O nome deve ter no minimo 4 caracteres");

        RuleFor(x => x.Telefone)
            .NotNull().WithMessage("O telefone não pode ser nulo")
            .NotEmpty().WithMessage("O telefone não pode estar vazio")
            .MinimumLength(11).WithMessage("O nome deve ter no minimo 11 caracteres");

        RuleFor(x => x.CapacidadeComprar)
            .NotNull().WithMessage("A capacidade de compra não pode ser nula");
    }
}
