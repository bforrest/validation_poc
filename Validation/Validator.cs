using System;
using System.Collections.Generic;

namespace Validation
{
    public static class Validator
    {
        private static readonly Dictionary<Type, object> Validators = new Dictionary<Type, object>();

        public static void RegisterValidatorFor<T>(T entity, IValidator<T> validator)
            where T : IValidatable<T>
        {
            Validators.Add(entity.GetType(), validator);
        }

        public static IValidator<T> GetValidatorFor<T>(T entity)
            where T : IValidatable<T>
        {
            return Validators[entity.GetType()] as IValidator<T>;
        }

        public static bool Validate<T>(this T entity, out IEnumerable<string> brokenRules)
            where T : IValidatable<T>
        {
            var validator = Validator.GetValidatorFor(entity);

            return entity.Validate(validator, out brokenRules);
        }
    }
}