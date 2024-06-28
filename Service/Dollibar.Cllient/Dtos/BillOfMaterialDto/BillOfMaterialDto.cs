namespace Dollibar.Cllient.Dtos.BillOfMaterialDto
{
    public class BillOfMaterialDto
    {
        public string? Module {  get; set; }
        public int Id { get; set; }
        public string? Ref {  get; set; }
        public int? Status { get; set; } = 0;
        public int? Specimen {  get; set; } = 0;
        public string? Label { get; set; }
        public int? Bomtype { get; set; } = 0;
        public string? Description { get; set; }
        public int? Tms { get; set; }
        public int? Fk_warehouse { get; set; }
        public int? Fk_product {  get; set; }
        public int? Qty { get; set; }
        public string? Duration { get; set; }
        public int? Total_cost { get; set; } = 0;
        public int? Unit_cost { get; set; } = 0;
    }
}
