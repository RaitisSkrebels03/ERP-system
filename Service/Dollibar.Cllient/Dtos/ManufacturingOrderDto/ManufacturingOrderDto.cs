namespace Dollibar.Cllient.Dtos.ManufacturingOrderDto
{
    public class ManufacturingOrderDto
    {
        public string? Module {  get; set; }
        public int Id { get; set; }
        public int? Fk_project { get; set; }
        public string Ref { get; set; }
        public int? Status { get; set; } = 0;
        public string? Note_public { get; set; }
        public string? Note_private { get; set; }
        public List<object>? Lines { get; set; } = [];
        public int? Specimen { get; set; } = 0;
        public int? Mrptype { get; set; } = 0;
        public string? Label { get; set; }
        public int? Qty { get; set; }
        public int? Fk_soc {  get; set; }
        public int? Socid { get; set; }
        public int? Tms { get; set; }
        public int? Fk_product { get; set; }
        public int? Date_start_planned { get; set; }
        public int? Date_end_planned { get; set; }
        public int? Fk_bom { get; set; }
        public List<object>? Line { get; set; } = [];
    }
}
