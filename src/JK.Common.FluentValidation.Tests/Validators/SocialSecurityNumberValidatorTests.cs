﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JK.Common.FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests.Validators
{
    public class SocialSecurityNumberValidatorTests
    {
        internal MockModelStringValidator MockValidator
        {
            get
            {
                var validator = new SocialSecurityNumberValidator();
                return new MockModelStringValidator(validator);
            }
        }

        [Theory]
        [InlineData("078051120")]
        [InlineData("078 05 1120")]
        [InlineData("078-05-1120")]
        [InlineData("899-05-1120")] // left less than 900
        
        public void IsValid_TrueTheories(string value)
        {
            var result = value.GetTestValidationResult(this.MockValidator);
            result.ShouldNotHaveValidationErrorFor(x => x.StringValue);
        }

        [Theory]
        [InlineData("000000000")]
        [InlineData("000 00 0000")]
        [InlineData("000-00-0000")]
        [InlineData("111-00-1111")] // middle all 0
        [InlineData("111-11-0000")] // right all 0
        [InlineData("666-12-4321")] // left 666
        [InlineData("900-12-4321")] // left greater than equal 900
        public void IsValid_FalseTheories(string value)
        {
            var result = value.GetTestValidationResult(this.MockValidator);
            result.ShouldHaveValidationErrorFor(x => x.StringValue);
        }
    }
}
