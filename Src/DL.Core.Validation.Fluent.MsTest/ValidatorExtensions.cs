using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Validation.Fluent.MsTest
{
    /// <summary>
    /// Thank you zen developer!
    /// </summary>
    public static class ValidatorExtensions
    {
        public static void ContainsRuleFor<T>(this IValidator validator, Expression<Func<T, object>> propertyExpression)
        {
            string propertyToTest = ConvertExpressionToString(propertyExpression);
            ContainsRuleFor(validator, propertyToTest);
        }

        public static void ContainsRuleFor(this IValidator validator, string propertyToTest)
        {
            var descriptor = validator.CreateDescriptor();
            var validationRules = descriptor.GetValidatorsForMember(propertyToTest);
            var listToTest = new List<IPropertyValidator>(validationRules);
            Assert.IsTrue(listToTest.Count > 0, "No validation rules have been defined for " + propertyToTest);
        }

        public static void AssertValidationFails(this ValidationResult results, string errorMessage)
        {
            Assert.IsFalse(results.IsValid, "Object is valid");
            Assert.IsTrue(results.Errors.Count > 0, "No validation errors were reported");
            Assert.AreEqual(errorMessage, results.Errors[0].ErrorMessage);
        }

        public static void AssertValidationPasses(this ValidationResult results)
        {
            Assert.IsTrue(results.IsValid, "Object is not valid");
            Assert.AreEqual(0, results.Errors.Count, "Validation errors were reported");
        }

        private static string ConvertExpressionToString<T>(Expression<Func<T, object>> propertyExpression)
        {
            if (propertyExpression.Body is UnaryExpression)
            {
                var operand = ((UnaryExpression)propertyExpression.Body).Operand;
                return ((MemberExpression)operand).Member.Name;
            }

            return ((MemberExpression)propertyExpression.Body).Member.Name;
        }
    }
}
