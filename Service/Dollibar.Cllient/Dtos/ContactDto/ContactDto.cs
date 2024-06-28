namespace Dollibar.Cllient.Dtos.ContactDto
{
    public class ContactDto
    {
        public string? Module { get; set; }
        public int Id { get; set; }
        public string? Entity { get; set; }
        public string? Socid { get; set; }
        public string? Lastname { get; set; } 
        public string? Firstname { get; set; } 
        public string? Poste {  get; set; }
        public string? Civility_code { get; set; }
        public string? Fk_soc { get; set; }
        public string? Socname { get; set; }
        public string? Address { get; set; } 
        public string? Zip { get; set; } 
        public string? Town { get; set; } 
        public int? Country_id { get; set; } 
        public string? Country_code { get; set; }
        public int? State_id { get; set; }
        public string? Email { get; set; }
        public int? No_email { get; set; }
        public string? Phone_pro { get; set; }
        public string? Phone_perso { get; set; }
        public string? Phone_mobile { get; set; }
        public string? Fax { get; set; }
        public int? Priv { get; set; }
        public string? Note_public { get; set; }
        public string? Note_private { get; set; }
        public int? Statut { get; set; } = 1;
        public string? Birthday { get; set; }
        public int? Birthday_alert { get; set; }
        public string? Default_lang { get; set; }

    }
}
