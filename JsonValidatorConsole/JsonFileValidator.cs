using System;
using System.Collections.Generic;
using System.Text;
using JSONValidatorAlternativeVersion;

namespace JsonValidatorConsole
{
    class JsonValidator
    {
        private readonly string textContent;

        public JsonValidator(string importedTextContent)
        { textContent = importedTextContent; }

        public bool IsValid()
        {
            var jsonValueValidator = new Value();

            return jsonValueValidator.Match(textContent).Success() &&
                jsonValueValidator.Match(textContent).RemainingText().Length == 0;
        }
    }
}
