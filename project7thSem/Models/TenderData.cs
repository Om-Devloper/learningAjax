using Microsoft.EntityFrameworkCore;

namespace project7thSem.Models
{
    public class TenderData
    {
        public List<pageData> tenderDetailsInfo { get; set; }
        public List<tenderDetailModel> shortInfo { get; set; }
        //public List<UserEmailOptions> UserEmailInfo { get; set; }

    }
}
