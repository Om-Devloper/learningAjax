using ConnectionLibrary.Interface;
using ConnectionLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using project7thSem.Model;
using project7thSem.Models;
using System.Data;
using System.Diagnostics;

namespace project7thSem.Controllers
{
    public class HomeController : Controller
    {
        IConnectionClass connectionClass;
        public HomeController(IConnectionClass DbConnectionClass)
        {
            connectionClass = DbConnectionClass;
        }

        public IActionResult Index(int pageNo=1)
        { 
            var model = new TenderData();
            var query = connectionClass.Select("SELECT OurRefNo,TenderAmount,SubmDate,WorkDesc,AgencyName,(SELECT Name fROM Country_Mast cm WHERE cm.CountryID=gi.CountryId) as Countryname FROM GlobalFreshTenderInfo gi");
            model.TotalData = Helper.ConvertDataTable<pageData>(query);
            int TenderCount = model.TotalData.Count();
            const int pageSize = 10;
            if (pageNo < 1)
                pageNo = 1;

            int recsCount = model.TotalData.Count();
            var pager = new Pager(recsCount, pageNo, pageSize);
            int recSkip = (pageNo - 1) * pageSize;
            model.TotalData = model.TotalData.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(model);
        }

        [Route("Notice")]
        public IActionResult Notice(string OurRefNo)
        { 
            var model = new TenderData();
            var query = connectionClass.Select($"select * from GlobalFreshTenderInfo where OurRefNo ={OurRefNo}");  
            model.IdData= Helper.ConvertDataTable<tenderDetailModel>(query);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}