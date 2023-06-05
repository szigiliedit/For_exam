namespace IskolaWebAPI.Models
{
    public class DiakokDto
    {
        public int Id { get; set; }
        public string Tanev { get; set; } = null!;
        public int IskolaId { get; set; }
        public string OktatasiAzonosito { get; set; } = null!;
        public string Nev { get; set; } = null!;
        public string Osztaly { get; set; } = null!;
    }
}
