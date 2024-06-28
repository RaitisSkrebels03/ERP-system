namespace Dollibar.Cllient.Dtos.MemberDto
{
    public class MemberDto
    {
        public string? Module { get; set; }
        public int Id { get; set; }
        public int? Entity { get; set; } = 1;
        public int? Fk_project { get; set; }
        public int? Contact_id { get; set; }
        public string? Ref { get; set; }
        public int? Country_id { get; set; }
        public string? Country_code { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Fullname { get; set; }
        public string? Company { get; set; }
        public string? Societe { get; set; }
        public string? Address { get; set; }
        public string? Zip { get; set; }
        public string? Town { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }  
        public string Morphy { get; set; }
        public string? Gender { get; set; }
        public string? Birth { get; set; }
        public string Typeid { get; set; }
        public string Type { get; set; }

    }
}
