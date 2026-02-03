using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Communication.Validator;

public class FutureOrTodayDateAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date)
        {
            if (date.Date < DateTime.Today)
                return new ValidationResult("A data de vencimento não pode ser anterior à data atual.");
        }

        return ValidationResult.Success;
    }
}