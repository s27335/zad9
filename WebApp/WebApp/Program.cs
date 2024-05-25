using WebApp.Services;

public class Program
{

    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Registering services
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddScoped<ITripService,TripService>();
        builder.Services.AddScoped<IClientService,ClientService>();

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}

// insert into Client(IdClient,FirstName, LastName, Email, Telephone, Pesel) VALUES (1,'John', 'Doe', 'doe@wp.pl', '543-323-542','91040294554');
// insert into trip(IdTrip,Name, Description, DateFrom, DateTo, MaxPeople) VALUES (1,'ABC','Lorem ipsum...', '25-MAY-2024', '31-MAY-2024', 20);
// insert into trip(IdTrip,Name, Description, DateFrom, DateTo, MaxPeople) VALUES (2,'ABC','Lorem ipsum...', '10-MAY-2024', '17-MAY-2024', 20);
// Insert into country(IdCountry, Name) values (1, 'Poland');
// Insert into country(IdCountry, Name) values (2, 'Germany');
// insert into Country_Trip(IdCountry, IdTrip) values (2,1);