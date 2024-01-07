using FluentValidation;

namespace CMCapital.API.DTOs.Validadores;

public class ProdutoDTOValidador : AbstractValidator<ProdutoDTO>
{
    public ProdutoDTOValidador()
    {
        RuleFor(x => x.Descricao)
            .NotNull().WithMessage("A descrição não pode ser nula.")
            .NotEmpty().WithMessage("A descrição não pode estar vazia.")
            .MinimumLength(5).WithMessage("A descrição deve ter no minimo 5 caracteres.");

        RuleFor(x => x.ValorUnitario)
            .NotNull().WithMessage("O valor unitário não pode ser nulo.");
    }
}
