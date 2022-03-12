namespace Packt.Shared
{

    public record ImmutableVehicle
    {
        public int Wheels { get; init; }
        public string Color { get; init; }
        public string Brand { get; init; }
    }
}

