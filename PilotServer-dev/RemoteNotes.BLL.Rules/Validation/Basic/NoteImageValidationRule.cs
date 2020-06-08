using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using RemoteNotes.BLL.Contract.Rule.Base;

namespace RemoteNotes.BLL.Rules.Validation.Basic
{
    class NoteImageValidationRule : ValidationRuleBase
    {
        public NoteImageValidationRule() : base("Note image format exception!")
        {
        }

        public ValidationResult IsValid(byte[] imageBytes)
        {
            var validationResult = new ValidationResult();

            using (MemoryStream memstr = new MemoryStream(imageBytes))
            {
                try
                {
                    Image img = Image.FromStream(memstr);

                }
                catch (Exception e)
                {
                    var errorMessage = GetErrorMessage();
                    validationResult = new ValidationResult(false, errorMessage);
                }

            }
            return validationResult;
        }

    }
}
