using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Types;

namespace Core.Entities; 

public class MunicipalityTax
{
	[Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get;set;}

	public string MunicipalityTitle { get; set; } = string.Empty;
	public DateTime TaxFrom { get; set; }
	public DateTime TaxUp { get; set; }
	public decimal Tax { get; set; }
    public int Type {get; set; }

	public TaxType TaxType { get => this.Type.ToTaxType(); }

    public MunicipalityTax()
	{
		
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