using FluentValidation;
using WebApiMongoDB.Models;

namespace WebApiMongoDB.Validators
{
    public class AddStudentValidator : AbstractValidator<Cadastro>
    {
        public AddStudentValidator()
        {
            RuleFor(m => m.Nome)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor digite nome completo")
                .MaximumLength(80)
                    .WithMessage(" Não pode passar de 80 caracteres")
                .MinimumLength(2)
                .WithMessage("Não pode ter menos de 2 caracteres");

            RuleFor(m => m.CPF)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor digite um cpf")
                .MaximumLength(11)
                    .WithMessage("Não pode passar de 11 caracteres")
                .Matches("[0-9]{11}")
                    .WithMessage("CPF Invalido");

            RuleFor(m => m.Email)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor digite um Email")
                .MaximumLength(256)
                    .WithMessage(" Não pode passar de 256 caracteres");


            RuleFor(m => m.Endereco)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor digite um Endereço")
                .MaximumLength(80)
                    .WithMessage(" Não pode passar de 80 caracteres")
                .MinimumLength(2)
                .WithMessage("Não pode ter menos de 2 caracteres");

            RuleFor(m => m.TelefoneCelular)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor digite um Telefone/Celular")
                .MaximumLength(12)
                    .WithMessage(" Não pode passar de 12 caracteres")
                .MinimumLength(11)
                .WithMessage("Não pode ter menos de 11 caracteres");
        }
    }
}
