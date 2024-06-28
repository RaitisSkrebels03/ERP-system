namespace Dollibar.Cllient.Dtos.SetupDto
{
    public class ShippingMethodDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Tracking { get; set; }
        public string Module { get; set; }
    }
}
