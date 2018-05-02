using SmartRm.Models.databases;
using SmartRm.Models.databases.entity;
using System;
using System.Web.Http;

namespace SmartRm.Controllers
{
    public class PushController : ApiController
    {
        /// <summary>
        /// Hàm này dùng để lưu RegistrationId từ GCM gửi về cho mỗi thiết bị
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        public bool insertRegID(string regId, string deviceName,string deviceId)
        {
            try
            {
                tbl_deviceRegistration device = new tbl_deviceRegistration();
                device.id = Guid.NewGuid();
                device.gcm_regId = regId;
                device.device_name = deviceName;
                device.device_id = deviceId;

                int result = Repository.getInstance().Create<tbl_deviceRegistration>(device);

                return result>0;
            }
            catch (Exception e)
            {

            }
            return false;
        }

    }
}
