using System.Collections.Generic;
using FluentValidation;

namespace Validation
{
    public interface IValidatable<T>
    {
        bool Validate(out IEnumerable<string> brokenRules);
    }
}
