using FluentValidation;
using LogElasticAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogElasticAPI.Service.Validators
{
    public class LogValidator : AbstractValidator<Log>
    {
        public void UserValidator()
        {
            RuleFor(c => c.ApplicationName)
                .NotEmpty().WithMessage("Por favor insira o nome da aplicação.")
                .NotNull().WithMessage("Por favor insira o nome da aplicação.");

            RuleFor(c => c.Message)
                .NotEmpty().WithMessage("Por favor insira a mensagem.")
                .NotNull().WithMessage("Por favor insira a mensagem.");

            //RuleFor(c => c.InnerMessage)
            //    .NotEmpty().WithMessage("Por favor insira a mensagem.")
            //    .NotNull().WithMessage("Por favor insira a mensagem.");

            //RuleFor(c => c.Stacktrace)
            //    .NotEmpty().WithMessage("Por favor insira a mensagem.")
            //    .NotNull().WithMessage("Por favor insira a mensagem.");

        }
    }
}
