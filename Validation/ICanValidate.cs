using System;
using System.Collections.Generic;

namespace Validation
{
    public interface ICanValidate<in T>
    {
        bool Validate(out IEnumerable<Tuple<string, string>> brokenRules);
    }
}
    