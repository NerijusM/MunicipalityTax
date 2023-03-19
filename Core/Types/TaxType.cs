namespace Core.Types;

public enum TaxType
{
   Unknow = 0,  Daily = 1, Weekly = 2, Monthly = 3, Yearly = 4
}


public static class TaxTypeExtensions
{
    public static int Priority(this TaxType type) {
        return type switch
        {
            TaxType.Daily => 1,
            TaxType.Weekly => 2,
            TaxType.Monthly => 3,
            TaxType.Yearly => 4,
            _ => 0,
        };
    }
}

public static class IntExtensions {
    public static TaxType ToTaxType(this int type) {
        return type switch {
            1 => TaxType.Daily,
            2 => TaxType.Weekly,
            3 => TaxType.Monthly,
            4 => TaxType.Yearly,
            _ => TaxType.Unknow
        };
    }
}
