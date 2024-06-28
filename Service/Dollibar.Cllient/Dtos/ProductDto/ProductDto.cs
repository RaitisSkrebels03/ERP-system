﻿namespace Dollibar.Cllient.Dtos.ProductDto
{
    public class ProductDto
    {
        public string? Module { get; set; }
        public int Id { get; set; }
        public string? Entity { get; set; }
        public string Ref { get; set; }
        public string? Status { get; set; }
        public string? Country_id { get; set; }
        public string? Country_code { get; set; }
        public string? State_id { get; set; }
        public string? Region_id { get; set; }
        public string? Note_public { get; set; }
        public string? Note_private { get; set; }
        public string? Date_creation { get; set; }
        public string? Date_validation { get; set; }
        public string? Date_modification { get; set; }
        public string? Date_update { get; set; }
        public int? User_creation_id { get; set; }
        public int? User_valid { get; set; }
        public int? User_validation_id { get; set; }
        public int? User_closing_id { get; set; }
        public int? User_modification_id { get; set; }
        public int? Specimen { get; set; }
        public string? LabelStatus { get; set; }
        public string? Label { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Price { get; set; }
        public string? Price_formated { get; set; }
        public string? Price_ttc { get; set; }
        public string? Price_ttc_formated { get; set; }
        public string? Price_min { get; set; }
        public string? Price_min_ttc { get; set; }
        public string? Price_base_type { get; set; }
        public string? Default_vat_code { get; set; }
        public string? Tva_tx { get; set; }
        public string? Remise_percent { get; set; }
        public string? Localtax1_tx { get; set; }
        public string? Localtax2_tx { get; set; }
        public string? Localtax1_type { get; set; }
        public string? Localtax2_type { get; set; }
        public string? Pmp { get; set; }
        public string? Seuil_stock_alerte { get; set; }
        public string? Desiredstock { get; set; }
        public string? Duration { get; set; }
        public int? Fk_default_workstation { get; set; }
        public string? Status_buy { get; set; }
        public string? Finished { get; set; }
        public string? Status_batch { get; set; }
        public string? Batch_mask { get; set; }
        public string? Customcode { get; set; }
        public string? Url { get; set; }
        public string? Weight { get; set; }
        public string? Weight_units { get; set; }
        public string? Length { get; set; }
        public string? Length_units { get; set; }
        public string? Width { get; set; }
        public string? Width_units { get; set; }
        public string? Height { get; set; }
        public string? Height_units { get; set; }
        public string? Surface { get; set; }
        public string? Surface_units { get; set; }
        public string? Volume { get; set; }
        public string? Volume_units { get; set; }
        public string? Accountancy_code_sell { get; set; }
        public string? Accountancy_code_sell_intra { get; set; }
        public string? Accountancy_code_sell_export { get; set; }
        public string? Accountancy_code_buy { get; set; }
        public string? Accountancy_code_buy_intra { get; set; }
        public string? Accountancy_code_buy_export { get; set; }
        public string? Barcode { get; set; }
        public string? Price_autogen { get; set; }
        public string? Mandatory_period { get; set; }
    }
}
