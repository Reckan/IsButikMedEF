namespace DataClass
{
    public class Vare
    {
            public int Id { get; set; }
            public string Navn { get; set; }
            public string Beskrivelse { get; set; }
            public double Pris { get; set; }
            public List<Bestilling> Bestillinger { get; set; }
    }
}