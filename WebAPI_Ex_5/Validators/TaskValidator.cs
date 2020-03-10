using FluentValidation;
using WebAPI_Ex_5.Models;

namespace WebAPI_Ex_5.Validators
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100).WithMessage("El campo 'name' no puede estar vacio y con un numero de caracteres menor o igual a 0 ");
            RuleFor(x => x.Complete).NotEmpty().WithMessage("El campo 'Complete' no debe estar vacio y debe ser un valor booleano.");
            RuleFor(x => x.CreateDate).NotEmpty().WithMessage("El campo 'CreateDate' no debe estar vacio y debe ser un valor dateTime."); ;
            RuleFor(x => x.ModifiedDate).NotEmpty().WithMessage("El campo 'ModifiedDate' no debe estar vacio y debe ser un valor dateTime."); ; ;
            RuleFor(x => x.Type).NotEmpty().WithMessage("El campo 'Type' no debe estar vacio.");
        }
    }
}