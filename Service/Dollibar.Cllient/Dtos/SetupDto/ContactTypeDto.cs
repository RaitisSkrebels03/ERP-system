namespace Dollibar.Cllient.Dtos.SetupDto
{
    public class ContactTypeDto
    {
        public int Rowid { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Source { get; set; }
        public string? Module { get; set; }
        public int? Position { get; set; }
    }
}
