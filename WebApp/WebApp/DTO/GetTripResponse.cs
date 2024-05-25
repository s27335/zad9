namespace WebApp.DTO;

public class GetTripResponse
{
    public int PageNum { get; set; }
    public int PageSize { get; set; }
    public int AllPages { get; set; }
    public IEnumerable<DTOTrip> Trips { get; set; }
}