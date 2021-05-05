﻿using Fiap.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Application.Validations
{
    public class AlunoValidation: AbstractValidator<Aluno>
    {
        public AlunoValidation()
        {
            RuleFor(a => a.Nome).NotNull().WithMessage("confirme  o {PropertyName}");
            RuleFor(a => a.Idade).InclusiveBetween(18, 75).WithMessage("tem que ter pelo menos {MinLength}");
        }
    }
}
