
using System.ComponentModel.DataAnnotations;

namespace BikeSC.Data;

public class ItemsModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string CreatedBy { get; set; }

    public string ApprovedBy { get; set; }
    public DateTime Date { get; set; }

}

