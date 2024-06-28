namespace Dollibar.Cllient.Dtos.TaskDto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string? Fk_project { get; set; }
        public string? Entity { get; set; }
        public string? Ref { get; set; }
        public string? Label { get; set; }
        public string? Description { get; set; }
        public string? Planned_workload { get; set; }
        public string? Fk_task_parent { get; set; }
        public int? Date_c { get; set; }
        public int? Date_start { get; set; }
        public int? Date_end { get; set; }
        public string? Progress { get; set; }
        public string? Budget_amount { get; set; }
    }
}
