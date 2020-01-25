using System;

namespace JSONValidatorAlternativeVersion
{
    interface IPattern
    {
        IMatch Match(string text);
    }
}
