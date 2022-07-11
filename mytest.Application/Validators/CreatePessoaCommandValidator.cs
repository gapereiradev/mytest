using FluentValidation;
using mytest.Application.Commands.CreatePessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Validators
{
    public class CreatePessoaCommandValidator : AbstractValidator<CreatePessoaCommand>
    {
        public CreatePessoaCommandValidator()
        {
            RuleFor(p => p.Nome).NotNull().NotEmpty().WithMessage("É necessário informar o nome de uma pessoa");
        }
    }
}
