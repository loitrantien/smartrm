using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartRm.Models.service
{
    /// <summary>
    /// Mô tả dữ liệu trả về của server
    /// </summary>
    /// createby ttloi 28/12/2017
    public class ServiceResult
    {
        /// <summary>
        /// Ma loi: 0 thanh cong, 1: loi runtime exception, 2: loi nghiep vu
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Thông báo trả về client
        /// </summary>
        ///createby ttloi 28/12/2017
        public string Message { get; set; }
        /// <summary>
        /// dữ liệu trả về client
        /// </summary>
        ///createby ttloi 28/12/2017
        public string data { get; set; }
    }
}