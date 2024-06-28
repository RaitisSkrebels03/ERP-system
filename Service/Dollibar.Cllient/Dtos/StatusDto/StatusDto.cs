using System.Security;

namespace Dollibar.Cllient.Dtos.StatusDto
{
    public class StatusDto
    {
        public string Code { get; set; }
        public string Dolibarr_version { get; set; }
        public string Access_locked { get; set; }
    }
}
