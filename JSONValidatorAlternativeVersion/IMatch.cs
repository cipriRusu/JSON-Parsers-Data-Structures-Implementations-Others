using System;
using System.Collections.Generic;
using System.Text;

namespace JSONValidatorAlternativeVersion
{
    interface IMatch
    {
        bool Success();
        string RemainingText();
    }
}
