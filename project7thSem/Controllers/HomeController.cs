using ConnectionLibrary.Interface;
using ConnectionLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using project7thSem.Model;
using project7thSem.Models;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace project7thSem.Controllers
{
    public class HomeController : Controller
    {
        IConnectionClass connectionClass;
        public HomeController(IConnectionClass DbConnectionClass)
        {
            connectionClass = DbConnectionClass;
        }

        public IActionResult Index(int pageNo = 1)
        {
            var model = new TenderData();
            var query = connectionClass.Select("SELECT top 100 OurRefNo,TenderAmount,SubmDate,WorkDesc,AgencyName,(SELECT Name fROM Country_Mast cm WHERE cm.CountryID=gi.CountryId) as Countryname FROM GlobalFreshTenderInfo gi");
            model.tenderDetailsInfo = Helper.ConvertDataTable<pageData>(query);
            int TenderCount = model.tenderDetailsInfo.Count();
            const int pageSize = 10;
            if (pageNo < 1)
                pageNo = 1;

            int recsCount = model.tenderDetailsInfo.Count();
            var pager = new Pager(recsCount, pageNo, pageSize);
            int recSkip = (pageNo - 1) * pageSize;
            model.tenderDetailsInfo = model.tenderDetailsInfo.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(model);
        }

        public IActionResult Notice(string OurRefNo)
        {
            var model = new TenderData();
            var query = connectionClass.Select($"select * from GlobalFreshTenderInfo where OurRefNo ={OurRefNo}");
            model.shortInfo = Helper.ConvertDataTable<tenderDetailModel>(query);
            return View(model);
        }
        public IActionResult sendmailotp(string name, string mobile, string email)
        {
            Random _rdm = new Random();
            var _Otp = _rdm.Next(1000, 9999);
            var htmlbody = $"<style type=\'text/css\'>#outlook a {{ padding:0; }}\r\n          body {{ margin:0;padding:0;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%; }}\r\n          table, td {{ border-collapse:collapse;mso-table-lspace:0pt;mso-table-rspace:0pt; }}\r\n          img {{ border:0;height:auto;line-height:100%; outline:none;text-decoration:none;-ms-interpolation-mode:bicubic; }}\r\n          p {{ display:block;margin:13px 0; }}</style><!--[if mso]>\r\n        <noscript>\r\n        <xml>\r\n        <o:OfficeDocumentSettings>\r\n          <o:AllowPNG/>\r\n          <o:PixelsPerInch>96</o:PixelsPerInch>\r\n        </o:OfficeDocumentSettings>\r\n        </xml>\r\n        </noscript>\r\n        <![endif]--><!--[if lte mso 11]>\r\n        <style type=\'text/css\'>\r\n          .mj-outlook-group-fix {{ width:100% !important; }}\r\n        </style>\r\n        <![endif]--><!--[if !mso]><!--><link href=\'https://fonts.googleapis.com/css?family=Open+Sans:300,400,500,700\' rel=\'stylesheet\' type=\'text/css\'><style type=\'text/css\'>@import url(https://fonts.googleapis.com/css?family=Open+Sans:300,400,500,700);</style><!--<![endif]--><style type=\'text/css\'>@media only screen and (min-width:480px) {{\r\n        .mj-column-per-100 {{ width:100% !important; max-width: 100%; }}\r\n      }}</style><style media=\'screen and (min-width:480px)\'>.moz-text-html .mj-column-per-100 {{ width:100% !important; max-width: 100%; }}</style><style type=\'text/css\'>@media only screen and (max-width:480px) {{\r\n      table.mj-full-width-mobile {{ width: 100% !important; }}\r\n      td.mj-full-width-mobile {{ width: auto !important; }}\r\n    }}</style></head><body style=\'word-spacing:normal;background-color:#fafbfc;\'><div style=\'background-color:#fafbfc;\'><!--[if mso | IE]><table align=\'center\' border=\'0\' cellpadding=\'0\' cellspacing=\'0\' class=\'\' style=\'width:600px;\' width=\'600\' ><tr><td style=\'line-height:0px;font-size:0px;mso-line-height-rule:exactly;\'><![endif]--><div style=\'margin:0px auto;max-width:600px;\'><table align=\'center\' border=\'0\' cellpadding=\'0\' cellspacing=\'0\' role=\'presentation\' style=\'width:100%;\'><tbody><tr><td style=\'direction:ltr;font-size:0px;padding:20px 0;padding-bottom:20px;padding-top:20px;text-align:center;\'><!--[if mso | IE]><table role=\'presentation\' border=\'0\' cellpadding=\'0\' cellspacing=\'0\'><tr><td class=\'\' style=\'vertical-align:middle;width:600px;\' ><![endif]--><div class=\'mj-column-per-100 mj-outlook-group-fix\' style=\'font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:middle;width:100%;\'><table border=\'0\' cellpadding=\'0\' cellspacing=\'0\' role=\'presentation\' style=\'vertical-align:middle;\' width=\'100%\'><tbody><tr><td align=\'center\' style=\'font-size:0px;padding:25px;word-break:break-word;\'><table border=\'0\' cellpadding=\'0\' cellspacing=\'0\' role=\'presentation\' style=\'border-collapse:collapse;border-spacing:0px;\'><tbody><tr><td style=\'width:550px;\'><img height=\'auto\' src=\'https://www.tenderdetail.com/Content/img/TenderDetail.png\' style=\'border:0;display:block;outline:none;text-decoration:none;height:auto;width:100%;font-size:13px;\' width=\'550\'></td></tr></tbody></table></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><table align=\'center\' border=\'0\' cellpadding=\'0\' cellspacing=\'0\' class=\'\' style=\'width:600px;\' width=\'600\' bgcolor=\'#ffffff\' ><tr><td style=\'line-height:0px;font-size:0px;mso-line-height-rule:exactly;\'><![endif]--><div style=\'background:#ffffff;background-color:#ffffff;margin:0px auto;max-width:600px;\'><table align=\'center\' border=\'0\' cellpadding=\'0\' cellspacing=\'0\' role=\'presentation\' style=\'background:#ffffff;background-color:#ffffff;width:100%;\'><tbody><tr><td style=\'direction:ltr;font-size:0px;padding:20px 0;padding-bottom:20px;padding-top:20px;text-align:center;\'><!--[if mso | IE]><table role=\'presentation\' border=\'0\' cellpadding=\'0\' cellspacing=\'0\'><tr><td class=\'\' style=\'vertical-align:middle;width:600px;\' ><![endif]--><div class=\'mj-column-per-100 mj-outlook-group-fix\' style=\'font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:middle;width:100%;\'><table border=\'0\' cellpadding=\'0\' cellspacing=\'0\' role=\'presentation\' style=\'vertical-align:middle;\' width=\'100%\'><tbody><tr><td align=\'center\' style=\'font-size:0px;padding:10px 25px;padding-right:25px;padding-left:25px;word-break:break-word;\'><div style=\'font-family:open Sans Helvetica, Arial, sans-serif;font-size:16px;line-height:1;text-align:center;color:#000000;\'><span>Hello,</span></div></td></tr><tr><td align=\'center\' style=\'font-size:0px;padding:10px 25px;padding-right:25px;padding-left:25px;word-break:break-word;\'><div style=\'font-family:open Sans Helvetica, Arial, sans-serif;font-size:16px;line-height:1;text-align:center;color:#000000;\'>Please use the verification code below on the <b>Tender Detail</b> website:</div></td></tr><tr><td align=\'center\' style=\'font-size:0px;padding:10px 25px;word-break:break-word;\'><div style=\'font-family:open Sans Helvetica, Arial, sans-serif;font-size:24px;font-weight:bold;line-height:1;text-align:center;color:#000000;\'>{_Otp}</div></td></tr><tr><td align=\'center\' style=\'font-size:0px;padding:10px 25px;padding-right:16px;padding-left:25px;word-break:break-word;\'><div style=\'font-family:open Sans Helvetica, Arial, sans-serif;font-size:16px;line-height:1;text-align:center;color:#000000;\'>If you didn't request this, you can ignore this email or let us know.</div></td></tr><tr><td align=\'center\' style=\'font-size:0px;padding:10px 25px;padding-right:25px;padding-left:25px;word-break:break-word;\'><div style=\'font-family:open Sans Helvetica, Arial, sans-serif;font-size:16px;line-height:1;text-align:center;color:#000000;\'>Thanks!<br><b>Tender Detail Team</b></div></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></div></body></html>";
            var subjectline = "testing";
            var query = connectionClass.Select($"select Id from userDetailsInfo  where emailId = '{email}' ");
            if (query == null)
            {

                bool mailSending = mailsend(email, htmlbody, subjectline);

                if (mailSending)
                {
                    var queryID = "";
                    try
                    {

                        queryID = connectionClass.Select($"Insert into userDetailsInfo ( [name],[emailId],[contactNo]) values ('{name}','{email}','{mobile}');select SCOPE_IDENTITY() as Id").Rows[0].ItemArray.FirstOrDefault().ToString();
                       

                        // model.Id =Convert.ToInt32( Helper.ConvertDataTable<UserEmailOptions>(query).FirstOrDefault().Id);
                    }
                    catch (Exception)
                    {

                    }
                    return Json(new { Result = true, email_new = email, otp = _Otp, id = 1, userid = queryID });
                }
            }
            else
            {
                return Json(new { Result = true, id = 2 });
            }
            return Json(new { Result = true, id = 0 });
        }
        [HttpPost]
        public bool mailsend(string email, string htmlbody, string subjectline)
        {
          
            var tstaus = true;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("root42155@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = subjectline;
            mailMessage.Body = htmlbody;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("root42155@gmail.com", "pxwgliaoyztyoala");
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                tstaus = true;
            }
            catch (Exception ex)
            {
                tstaus = false;
            }
            return tstaus;
        }
        
        public IActionResult emailVerify(string email , string OurRefNo, string UserID)
        {
            try
            {
                var model = new UserEmailOptions();
                var query = connectionClass.Update($"update userDetailsInfo set isVerified = 1 , inquiredTenderNo = '{OurRefNo}' where id={UserID}");

                return Json(new { Result = true, email_new = email, ref_no = OurRefNo, id = 1, userid = UserID });
            }
            catch (Exception)
            {
                return Json(new { Result = true, id = 0 });
            }

        }
        
        [Route("Home/FullNotice/{userClientid}")]
        public IActionResult FullNotice(string userClientid)
        {
            var query = connectionClass.Select($"SELECT (SELECT (SELECT name fROM Country_Mast cm WHERE cm.CountryID=gi.CountryId) )as Countryname,\r\n*\r\n,(SELECT (SELECT name fROM GeographyRegion_Mast gm WHERE gm.ID=gi.GeoRegID))as geoRegion\r\nFROM GlobalFreshTenderInfo gi right JOIN userDetailsInfo udi ON gi.OurRefNo= udi.inquiredTenderNo  Where id = '{userClientid}'");
            var model = new TenderData();
            model.tenderDetailsInfo = Helper.ConvertDataTable<pageData>(query);
            if(model.tenderDetailsInfo.FirstOrDefault().PoliRegID != null)
            {
                var poliregion = model.tenderDetailsInfo.FirstOrDefault().PoliRegID.Split(",");
                var totalPolireg = "";
                foreach (var item in poliregion)
                {
                    var poliregionQuery = connectionClass.Select($"select (select name from PoliticalRegion_Mast where ID = {item}) as poliRegionName");
                    if (totalPolireg == "")
                    {
                        totalPolireg = poliregionQuery.Rows[0][0].ToString();
                    }
                    else
                    {
                        totalPolireg += "," + poliregionQuery.Rows[0][0].ToString();
                    }

                }
                model.tenderDetailsInfo.FirstOrDefault().poliRegionName = totalPolireg;
                return View(model);
            }
            
            

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
