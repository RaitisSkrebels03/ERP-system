namespace Dollibar.Cllient.Dtos.InvoiceDto
{
    public class InvoiceDto
    {
        public string? Module { get; set; }
        public int Id { get; set; }
        public string? Entity { get; set; }
        public List<string>? Contacts_ids { get; set; }
        public string? Fk_project { get; set; }
        public string? Contact_id { get; set; }
        public string? Ref { get; set; }
        public string? Statut { get; set; }
        public string? Status { get; set; }
        public string? Mode_reglement_id { get; set; }
        public string? Cond_reglement_id { get; set; }
        public string? Multicurrency_code { get; set; }
        public string? Multicurrency_tx { get; set; }
        public string? Model_pdf { get; set; }
        public int? Fk_bank { get; set; }
        public int? Fk_account { get; set; }
        public string? Note_public { get; set; }
        public string? Note_private { get; set; }
        public string? Total_ht { get; set; }
        public string? Total_tva { get; set; }
        public string? Total_localtax1 { get; set; }
        public string? Total_localtax2 { get; set; }
        public string? Total_ttc { get; set; }
        public int? Date_creation { get; set; }
        public string? Date_validation { get; set; }
        public int? Date_modification { get; set; }
        public string? User_author { get; set; }
        public int? Specimen { get; set; }
        public string? Type { get; set; }
        public int? Totalpaid { get; set; }
        public string? Remaintopay { get; set; }
        public string? Fk_incoterms { get; set; }
        public string? Location_incoterms { get; set; }
        public int? Brouillon { get; set; }
        public string? Socid { get; set; }
        public string? Fk_user_author { get; set; }
        public int? Date { get; set; }
        public int? Datem { get; set; }
        public string? Revenuestamp { get; set; }
        public string? Paye { get; set; }
        public int? Date_lim_reglement { get; set; }
        public string? Cond_reglement_code { get; set; }
        public string? Cond_reglement_doc { get; set; }
        public string? Mode_reglement_code { get; set; }
        public string? Date_pointoftax { get; set; }
        public string? Fk_multicurrency { get; set; }
        public string? Multicurrency_total_ht { get; set; }
        public string? Multicurrency_total_tva { get; set; }
        public string? Multicurrency_total_ttc { get; set; }
        public string? Situation_final { get; set; }
        public string? Retained_warranty { get; set; }
        public int? Retained_warranty_date_limit { get; set; }
        public string? Retained_warranty_fk_cond_reglement { get; set; }
    }
}
