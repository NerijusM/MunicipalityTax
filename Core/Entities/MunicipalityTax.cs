using Core.Types;

namespace Core.Entities; 

public class MunicipalityTax
{
	public string MunicipalityTitle { get; set; } = string.Empty;
	public DateTime TaxFrom { get; set; }
	public DateTime TaxUp { get; set; }
	public decimal Tax { get; set; }
    public int Type {get; set; }

	public TaxType TaxType { get => this.Type.ToTaxType(); }

    public MunicipalityTax()
	{
	}
}