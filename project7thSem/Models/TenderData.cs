using Microsoft.EntityFrameworkCore;

namespace project7thSem.Models
{
    public class TenderData
    {
        public List<pageData> TotalData { get; set; }
        public List<tenderDetailModel> IdData { get; set; }
    }
}
