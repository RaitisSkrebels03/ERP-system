namespace Dollibar.API.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Ref { get; set; }
        public int? Fk_parent { get; set; }

        public string? Label { get; set; }

        public string? Description { get; set; }

        public string? Color { get; set; }

        public int? Position { get; set; }

        public int? Visible { get; set; }

        public int? Socid { get; set; }

        public string? Type { get; set; }

    }
}
