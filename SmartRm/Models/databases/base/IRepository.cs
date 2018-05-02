using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRm.Models.databases
{
    /// <summary>
    /// Interface mô tả các hành động cần thao tác với dữ liệu CRUD
    ///  
    /// create by tloi 15/12/2017
    /// </summary>
    /// <typeparam name="T">Giới hạn kiểu class</typeparam>
    public interface IRepository
    {
        /// <summary>
        /// lấy ra một danh sách kiêu T từ database
        /// </summary>
        /// <see cref=""/>
        /// <returns>trả về một danh sách T</returns>
        List<T> GetAll<T> () where T : class;

        /// <summary>
        /// cập nhật một đối tượng kiểu T
        /// </summary>
        /// <param name="item">nhận vào một đối tượng</param>
        /// <returns></returns>
        int Update<T>(T item) where T : class;

        /// <summary>
        /// xóa một đối tượng theo id cho trước
        /// </summary>
        /// <param name="id">id của đối tượng</param>
        /// <returns></returns>
        int Delete<T>(T item) where T : class;

        Dictionary<Guid, string> Delete<T>(Guid[] lstid) where T : class;

        /// <summary>
        /// tạo mới một đối tượng T
        /// </summary>
        /// <param name="item">nhận vào mội đối tượng</param>
        /// <returns></returns>
        int Create<T>(T item) where T : class;
        /// <summary>
        /// gọi query
        /// </summary>
        /// <param name="query">nhận vào câu query </param>
        /// <returns></returns>
        List<T> query<T>(String query) where T : class;

    }
}
