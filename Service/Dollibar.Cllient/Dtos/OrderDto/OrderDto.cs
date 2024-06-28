namespace Dollibar.Cllient.Dtos.OrderDto
{
    public class OrderDto
    {
        public string? Module { get; set; }
        public int Id { get; set; }
        public string? Entity { get; set; }
        public string? Import_key { get; set; }
        public int? Fk_project { get; set; }
        public int? Contact_id { get; set; }
        public string? Ref { get; set; }
        public string? Ref_ext { get; set; }
        public string? Int { get; set; }
        public int? Country_id { get; set; }
        public string? Country_code { get; set; }
        public int? State_id { get; set; }
        public int? Region_id { get; set; }
        public int? Mode_reglement_id { get; set; }
        public int? Cond_reglement_id { get; set; }
        public int? Demand_reason_id { get; set; }
        public int? Transport_mode_id { get; set; }
        public int? Shipping_method_id { get; set; }
        public int? Shipping_method { get; set; }
        public string? Multicurrency_code { get; set; }
        public string? Multicurrency_tx { get; set; }
        public int? Fk_bank { get; set; }
        public int? Fk_account { get; set; }
        public string? Note_public { get; set; }
        public string? Note_private { get; set; }
        public string? Total_ht { get; set; }
        public string? Total_tva { get; set; }
        public string? Total_localtax1 { get; set; }
        public string? Total_localtax2 { get; set; }
        public string? Total_ttc { get; set; }
        public List<object>? Lines { get; set; } = [];
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public int? Civility_id { get; set; }
        public int? Date_creation { get; set; }
        public int? Date_validation { get; set; }
        public int? Date_modification { get; set; }
        public string? User_author { get; set; }
        public string? User_creation { get; set; }
        public int? User_creation_id { get; set; }
        public string? User_valid { get; set; }
        public string? User_validation { get; set; }
        public int? User_validation_id { get; set; }
        public int? User_closing_id { get; set; }
        public int? Specimen { get; set; }
        public string? Code { get; set; }
        public string? Fk_incoterms { get; set; }
        public int? Socid { get; set; } = 1;
        public string? Ref_client { get; set; }
        public string? Ref_customer { get; set; }
        public int? ContactId { get; set; }
        public int? Billed { get; set; }
        public string? Cond_reglement_code { get; set; }
        public string? Cond_reglement_doc { get; set; }
        public string? Deposit_percent { get; set; }
        public string? Mode_reglement_code { get; set; }
        public int? Availability_id { get; set; }
        public string? Availability_code { get; set; }
        public string? Availability { get; set; }
        public string? Demand_reason_code { get; set; }
        public int? Date { get; set; }
        public int? Date_commande { get; set; }
        public int? Delivery_date { get; set; }
        public int? Fk_remise_except { get; set; }
        public string? Remise_percent { get; set; }
        public string? Remise_absolue { get; set; }
        public int? Info_bits { get; set; }
        public int? Rang { get; set; }
        public int? Special_code { get; set; }
        public int? Warehouse_id { get; set; }
        public int? User_author_id { get; set; }
        public string? Module_source { get; set; }
        public string? Pos_source { get; set; }
        public string? Online_payment_url { get; set; }

    }
}
