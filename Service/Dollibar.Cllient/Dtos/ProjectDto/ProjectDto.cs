namespace Dollibar.Cllient.Dtos.ProjectDto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string? Ref { get; set; }
        public string? Fk_project { get; set; }
        public string? Title { get; set; }
        public int? Socid { get; set; }
        public string? Description { get; set; }
        public string? Public { get; set; }
        public string? Opp_amount { get; set; } 
        public string? Budget_amount { get; set; } 
        public int? Date_c { get; set; }
        public int? Date_start { get; set; }
        public int? Date_end { get; set;}
        public int? Date_start_event { get; set; }
        public int? Date_end_event { get; set; }
        public string? Location { get; set; }
        public int? Statut {  get; set; }
        public string? Opp_status { get; set; }
        public string? Opp_percent { get; set; }
        public int? Usage_opportunity { get; set; }
        public int? Usage_task { get; set; }
        public int? Usage_bill_time { get; set; }
        public int? Usage_organize_event { get; set; }

    }
}
