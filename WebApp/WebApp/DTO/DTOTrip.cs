namespace WebApp.DTO;

public class DTOTrip
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public IEnumerable<DTOCountry> Countries { get; set; }
    public IEnumerable<DTOClient> Clients { get; set; }
}