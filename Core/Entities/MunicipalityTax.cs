using System.ComponentModel.DataAnnotations;
using Core.Types;

namespace Core.Entities; 

public class MunicipalityTax
{
	[Key]
	public string Id {get;set;} = Guid.NewGuid().ToString();
	public string MunicipalityTitle { get; set; } = string.Empty;
	public DateTime TaxFrom { get; set; }
	public DateTime TaxUp { get; set; }
	public decimal Tax { get; set; }
    public int Type {get; set; }

	public TaxType TaxType { get => this.Type.ToTaxType(); }

    public MunicipalityTax()
	{
		
    }

	public void SetNewId()
	{
        if (Id == string.Empty) { Id = Guid.NewGuid().ToString(); };
    }

	public void UpdateValue(MunicipalityTax municipalityTax)
	{
		MunicipalityTitle = municipalityTax.MunicipalityTitle;
		TaxFrom = municipalityTax.TaxFrom;
		TaxUp = municipalityTax.TaxUp;
		Tax = municipalityTax.Tax;
		Type = municipalityTax.Type;
    }
}