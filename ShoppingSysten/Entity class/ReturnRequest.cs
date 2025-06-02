using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace entity_class
{
    public enum RequestStatus { Approved, Pending, Rejected}
    public class ReturnRequest
    {
        public int ReturnId {get; set;}
        public int OrderId {  get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public DateTime RequestAt {  get; set; }
        public DateTime? ProcessAt { get; set; }
        public RequestStatus Status { get; set; }
        public List<string> ImagePaths { get; } = new List<string>();
        public ReturnRequest(int orderId, int productId, int quantity, string reason, IEnumerable<string> imagePaths
             ) //
        {

            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Reason = reason;
            RequestAt = DateTime.Now;
            
            Status = RequestStatus.Pending;
            if (imagePaths != null) ImagePaths.AddRange(imagePaths);
        }
        public ReturnRequest(int orderId, int productId, int quantity, string reason,DateTime RequestAt, DateTime ProcessAt, IEnumerable<string> imagePaths
             ) //
        {

            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Reason = reason;
            RequestAt = DateTime.Now;

            Status = RequestStatus.Pending;
            if (imagePaths != null) ImagePaths.AddRange(imagePaths);
        }
        public void Approve()
        {
            Status = RequestStatus.Approved;
            ProcessAt = DateTime.Now;
        }   
        public void Reject()
        {
            Status = RequestStatus.Rejected;
            ProcessAt = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Id yêu cầu: {ReturnId}, Đơn hàng: {OrderId}, Sản phẩm: {ProductId}, Số lượng: {Quantity}, Ngày tạo yêu cầu: " +
                $"{RequestAt}, Ngày xử lý: {ProcessAt}, \n Lý do trả hàng: {Reason}, Trạng thái: {Status}.";
        }
    }
}
