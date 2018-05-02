using SmartRm.Models.databases;
using SmartRm.Models.databases.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SmartRm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected void btnGuiThongBao_Click()
        {
            try
            {
                //đây chính là API Key: (copy paste từ Google developer nhé)
                string applicationID = "<Bạn copy API KEY vào đây nha>";
                //lấy danh sách Registration Id
                string[] arrRegid = getListRegIDs("").ToArray();

                //đây chính là Sender ID: (copy paste từ Google developer nhé)
                string SENDER_ID = "<Bạn copy Sender ID vào đây nha>";
                //lấy nội dung thông báo
                string value = "hello world";
                WebRequest tRequest;
                //thiết lập GCM send
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                tRequest.Method = "POST";
                tRequest.UseDefaultCredentials = true;

                tRequest.PreAuthenticate = true;

                tRequest.Credentials = CredentialCache.DefaultNetworkCredentials;

                //định dạng JSON
                tRequest.ContentType = "application/json";
                //tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                string RegArr = string.Empty;

                RegArr = string.Join("\",\"", arrRegid);
                //Post Data có định dạng JSON như sau:
                /*
                *  { "collapse_key": "score_update",     "time_to_live": 108,       "delay_while_idle": true,
                "data": {
                "score": "223/3",
                "time": "14:13.2252"
                },
                "registration_ids":["dh4dhdfh", "dfhjj8", "gjgj", "fdhfdjgfj", "đfjdfj25", "dhdfdj38"]
                }
                */
                string postData = "{ \"registration_ids\": [ \"" + RegArr + "\" ],\"data\": {\"message\": \"" + value + "\",\"collapse_key\":\"" + value + "\"}}";

                Console.WriteLine(postData);
                Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                tRequest.ContentLength = byteArray.Length;

                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();
                tReader.Close();
                dataStream.Close();
                tResponse.Close();

            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Hàm dùng để trả về danh sách Registration đã được lưu vào Server của ta
        /// để cung cấp cho việc gửi tin nhắn hàng loạt, chú ý là danh sách không nằm trong sọt rác
        /// </summary>
        /// <returns></returns>
        public List<string> getListRegIDs(string deviceId)
        {
            try
            {
                List<tbl_deviceRegistration> list = Repository.getInstance().GetAll<tbl_deviceRegistration>().ToList();
                List<string> getListRegIDs = new List<string>();

                foreach (var item in list)
                {
                    getListRegIDs.Add(item.gcm_regId);
                }

                return getListRegIDs;
            }
            catch (Exception e)
            {

            }
            return null;
        }
    }
}