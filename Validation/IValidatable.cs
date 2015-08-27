using System.Collections.Generic;
using FluentValidation;

namespace Validation
{
    public interface IValidatable<T>
    {
        //bool Validate(AbstractValidator<T> validator, IEnumerable<string> brokenRules);
        bool Validate(IEnumerable<string> brokenRules);
    }
}
    