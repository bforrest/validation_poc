using System.Collections.Generic;

namespace Validation
{
    public interface IValidatable<T>
    {
        bool Validate(out IEnumerable<string> brokenRules);
    }
}
    