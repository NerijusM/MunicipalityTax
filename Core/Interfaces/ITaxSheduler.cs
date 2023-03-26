using System;
using Core.Types;

namespace Core.Interfaces;

public interface ITaxSheduler
{
    TaxType Type { get; }

    bool IsUsed();
    decimal TaxAmount();
}

