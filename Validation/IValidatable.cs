using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;

namespace Validation
{
    public interface IValidatable<T>
    {
        bool Validate(AbstractValidator<T> validator, IEnumerable<string> brokenRules);
    }
}
    