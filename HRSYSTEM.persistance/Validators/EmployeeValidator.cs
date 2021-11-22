using FluentValidation;
using HRSYSTEM.domain;

namespace HRSYSTEM.persistance
{
    /// <summary>
    /// These are the validators rules for Employee Entity
    /// </summary>
    public class EmployeeValidator : AbstractValidator<EmployeeEntity>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeID).NotNull().GreaterThan(0);
            RuleFor(x => x.FirstName).NotEmpty().Length(3, 50);
            RuleFor(x => x.LastName).NotEmpty().Length(3, 100);
            RuleFor(x => x.WorkEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.Telephone).MaximumLength(10).MinimumLength(10);
        }
    }
}
