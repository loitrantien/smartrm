using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SmartRmApi.Models
{
    public class Utils
    {

        public static string sendNotifocation(string message,string deviceID, string collapse_key)
        {
            try
            {
                //đây chính là API Key: (copy paste từ Google developer nhé)
                string applicationID = "293174915834";
                //lấy danh sách Registration Id
                string[] arrRegid = getListRegIDs(deviceID).ToArray();

                //đây chính là Sender ID: (copy paste từ Google developer nhé)
                string SENDER_ID = "AIzaSyAsyoaPiAVYeJeQbzvDabfZidZsggMjz5Y";
                //lấy nội dung thông báo
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
                \"message\": \"" + message + "\",
                "score": "223/3",
                "time": \""+System.DateTime.Now.ToString()+"\""
                },
                "registration_ids":["dh4dhdfh", "dfhjj8", "gjgj", "fdhfdjgfj", "đfjdfj25", "dhdfdj38"]
                }
                */
                string postData = "{ \"registration_ids\": [ \"" + RegArr + "\" ],\"data\": {\"message\": \"" + message + "\",\"collapse_key\":\"" + collapse_key + "\"}}";

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
                return sResponseFromServer;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        /// <summary>
        /// Hàm dùng để trả về danh sách Registration đã được lưu vào Server của ta
        /// để cung cấp cho việc gửi tin nhắn hàng loạt, chú ý là danh sách không nằm trong sọt rác
        /// </summary>
        /// <returns></returns>
        public static List<string> getListRegIDs(string deviceId)
        {
            try
            {
                List<tbl_deviceRegistration> list = new SmartRmDBModel().tbl_deviceRegistration.ToList();
                List<string> getListRegIDs = new List<string>();

                foreach (var item in list)
                {
                    if(item.device_id.Contains(deviceId))
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