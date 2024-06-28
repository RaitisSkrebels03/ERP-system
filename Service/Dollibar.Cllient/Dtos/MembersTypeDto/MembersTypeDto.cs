namespace Dollibar.Cllient.Dtos.MembersTypeDto
{
    public class MembersTypeDto
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Status { get; set; }
        public int? Specimen { get; set; } = 0;
        public string Label {  get; set; }
        public string Morphy { get; set; }
        public string? Vote {  get; set; }
        public string? Description { get; set; } 
        public string? Mail_valid {  get; set; }
    }
}
