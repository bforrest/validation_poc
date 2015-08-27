using System.Collections.Generic;

namespace Validation
{
    public interface IValidatable<T>
    {
        bool Validate(IValidator<T> validator, out IEnumerable<string> brokenRules);
    }
}
