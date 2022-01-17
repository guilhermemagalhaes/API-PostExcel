using FluentValidation;
using PostExcel.API.Message.Request;
using System;


namespace PostExcel.API.Message.Validator
{
    public class ProdutorRequestValidator : AbstractValidator<ProdutoRequest>
    {
        public ProdutorRequestValidator()
        {
            RuleFor(cp => cp.NomeProduto)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();

            RuleFor(cp => cp.Quantidade)
                .Must(x => x > 0)
                .NotNull()
                .NotEmpty();

            RuleFor(cp => cp.ValorUnitario)
                .Must(x => x > 0)
                .NotNull()
                .NotEmpty();

            RuleFor(cp => cp.DataEntrega)
                .Must(x => x <= DateTime.Now)
                .NotNull()
                .NotEmpty();
        }
    }
}
