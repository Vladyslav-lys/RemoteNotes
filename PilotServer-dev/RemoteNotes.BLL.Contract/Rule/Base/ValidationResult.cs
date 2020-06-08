using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RemoteNotes.BLL.Contract.Rule.Base
{
    public class ValidationResult : ITraceable
    {
        /// <summary>
        ///     Makes valid result as default
        /// </summary>
        public ValidationResult()
        {
        }

        /// <summary>
        ///     Merges a number of results into one total summary.
        /// </summary>
        /// <param name="validationResultCollection"></param>
        public ValidationResult(List<ValidationResult> validationResultCollection)
        {
            foreach (var validationResult in validationResultCollection)
                if (validationResult.IsValid == false)
                {
                    IsValid = false;
                    ErrorMessageCollection.AddRange(validationResult.ErrorMessageCollection);
                }
        }

        /// <summary>
        ///     Makes invalid result as default
        /// </summary>
        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;

            if (isValid && errorMessage != string.Empty)
                throw new InvalidDataException("Valid validation result connot have any error messages");
            if (!isValid && errorMessage == string.Empty)
                throw new InvalidDataException("Invalid validation result should have at least one error message");

            if (errorMessage != string.Empty) ErrorMessageCollection.Add(errorMessage);
        }

        public bool IsValid { get; } = true;

        public List<string> ErrorMessageCollection { get; } = new List<string>();

        public string GetTrace()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Validation result: {0}\r\n", IsValid);

            if (ErrorMessageCollection.Count > 0)
            {
                stringBuilder.AppendLine("Broken rules:");
                var errorMessage = GetErrorMessage();
                stringBuilder.AppendLine(errorMessage);
            }

            return stringBuilder.ToString();
        }

        public string GetErrorMessage()
        {
            var stringBuilder = new StringBuilder();

            foreach (var errorMessage in ErrorMessageCollection) stringBuilder.AppendLine(errorMessage);

            return stringBuilder.ToString();
        }
    }
}