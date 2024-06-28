namespace Dollibar.Cllient.Dtos.SetupDto
{
    public class RegionDto
    {
        public int Id { get; set; }
        public int Code_region {  get; set; }
        public int Fk_pays { get; set; }
        public string Name { get; set; }
        public string Cheflieu { get; set; }
        public int Active { get; set; }
    }
}
