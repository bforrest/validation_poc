﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Validation
{
    public static class Validator
    {
        public static void RegisterValidatorFor<T>(T entity, AbstractValidator<T> validator)
            where T : IValidatable<T>
        {
            Validators.Add(entity.GetType(), validator);
        }

        public static AbstractValidator<T> GetValidatorFor<T>(T entity)
            where T : IValidatable<T>
        {
            return Validators[entity.GetType()] as AbstractValidator<T>;
        }

        public static bool IsValid<T>(this T entity, out IEnumerable<string> brokenRules)
            where T : IValidatable<T>
        {
            var validator = GetValidatorFor(entity);
            var result = validator.Validate(entity);
            brokenRules = result.Errors.Select(x => x.ErrorMessage);
            return result.IsValid;
        }

        private static readonly Dictionary<Type, object> Validators = new Dictionary<Type, object>();
    }
}