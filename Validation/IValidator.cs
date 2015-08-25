using System.Collections.Generic;

namespace Validation
{
    public interface IValidator<T>
    {
        bool IsValid();
        IEnumerable<string> BrokenRules();
    }
}
