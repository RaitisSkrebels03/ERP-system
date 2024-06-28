namespace Dollibar.Cllient.Dtos.SetupDto
{
    public class LegalFormDto
    {
        public int Rowid { get; set; }
        public int Code { get; set; }
        public int Fk_pays { get; set; }
        public string Libelle { get; set; }
        public int Isvatexempted { get; set; }
        public int Active { get; set; }
        public string Module { get; set; }
        public int Position { get; set; }
    }
}
