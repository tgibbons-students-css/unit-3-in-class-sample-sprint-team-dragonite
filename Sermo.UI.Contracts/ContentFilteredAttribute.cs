﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sermo.UI.Contracts
{
    // Changes for Sprint 2 -- “I want to filter message content so that it is appropriate.” -- Shawn Pohlmann
    // Changes Sprint 2 --  I want to create rooms for categorizing conversations -- Shawn Pohlmann
    public class ContentFilteredAttribute : ValidationAttribute
    {
        // Changes Sprint 2 --  I want to create rooms for categorizing conversations -- Shawn Pohlmann
        private readonly string[] blacklist = new string[] 
        {
            "hefferlump",
            "woozle",
            "jabberwocky",
            "frabjous",
            "bandersnatch"
        };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationResult = ValidationResult.Success;

            if (value != null && value is string)
            {
                var valueString = (string)value;
                if(blacklist.Any(inappropriateWord => valueString.ToLowerInvariant().Contains(inappropriateWord.ToLowerInvariant())))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    validationResult = new ValidationResult(errorMessage);
                }
            }

            return validationResult;
        }
    }
}
