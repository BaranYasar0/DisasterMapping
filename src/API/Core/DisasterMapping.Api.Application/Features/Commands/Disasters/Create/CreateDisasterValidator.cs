using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Commands.Disasters.Create
{
    public class CreateDisasterValidator:AbstractValidator<CreateDisasterCommand>
    {
        public CreateDisasterValidator()
        {
            RuleFor(c => c.AddressDto.FullAddress).NotEmpty()
                .WithMessage("Adres boş olamaz!")
                .MinimumLength(3)
                .WithMessage("Minimum 3 karakter olmalı!")
                .MaximumLength(75)
                .WithMessage("Maximum 75 karakter olmalı");

            
        }
    }
}
