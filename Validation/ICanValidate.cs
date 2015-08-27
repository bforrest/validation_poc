using System.Collections.Generic;

namespace Validation
{
    public interface ICanValidate<T>
    {
        bool Validate(out IEnumerable<string> brokenRules);
    }
}
    