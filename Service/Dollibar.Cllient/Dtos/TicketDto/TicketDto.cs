namespace Dollibar.Cllient.Dtos.TicketDto
{
    public class TicketDto
    {
        public string? Module { get; set; }
        public int Id { get; set; }
        public string? Entity { get; set; }
        public string? Import_key { get; set; }
        public string? Fk_project { get; set; }
        public string Ref { get; set; }
        public string? Status { get; set; } = "0";
        public int? Date_creation { get; set; }
        public string? Date_validation { get; set; }
        public int? Date_modification { get; set; }
        public int? Date_update { get; set; }
        public int? Specimen { get; set; }
        public string? Track_id { get; set; }
        public string? Fk_user_create { get; set; }
        public int? Fk_user_assign { get; set; }
        public string Subject { get; set; }
        public string? Message { get; set; }
        public string? Fk_statut { get; set; }
        public string? Progress { get; set; }
        public string? Type_code { get; set; }
        public string? Category_code { get; set; }
        public string? Severity_code { get; set; }
        public string? Type_label { get; set; }
        public string? Category_label { get; set; }
        public string? Severity_label { get; set; }
        public string? Date_close { get; set; }
        public int? Socid { get; set; } = 1;
    }
}
