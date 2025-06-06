﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.DAL;
using Entity_class;
using Interface;

namespace BLL
{
    internal class RequestManagement : IRequestManagement
    {
        private readonly RequestDAO _repo;
        private readonly IInventoryManagement iM;

        public RequestManagement(IInventoryManagement im , RequestDAO repo)
        {
            iM = im;
            _repo = repo;
        }
        public async Task<ReturnRequest> CreateReturnRequestAsync(int orderId,int productId,int quantity, string reason
        , IEnumerable<string> imagePaths)
        {
            var returnRequest = new ReturnRequest(orderId, productId, quantity, reason, imagePaths); 
            _repo.InsertAsync(returnRequest);
            Console.WriteLine("Đã tạo yêu cầu trả hàng!");
            return await Task.FromResult(returnRequest);
        }
        public async Task<List<ReturnRequest>> GetPendingRequestsAsync()
        {
            return await _repo.GetByStatusAsync(RequestStatus.Pending);
        }
        public async Task<bool> ApproveRequestAsync(int requestId)
        {
            var returnRequests = await _repo.GetAllAsync();
            var req = returnRequests.FirstOrDefault(r => r.ReturnId == requestId);
            if (req == null || req.Status != RequestStatus.Pending)
            {
                Console.WriteLine("Lỗi k thấy yêu cầu!");
                return false;
            }
            req.Approve();
            Console.WriteLine("Đã duyệt yêu cầu!");

                
            return await iM.ImportOrReturnStock(req.ProductId,req.Quantity,"RETURN");

        }
        public async Task<bool> RejectRequestAsync(int requestId)
        {
            var returnRequests = await _repo.GetAllAsync();
            var req = returnRequests.FirstOrDefault(r => r.ReturnId==requestId);
            if (req == null || req.Status != RequestStatus.Pending)
            {
                Console.WriteLine("Lỗi");
                return false;
            }
            req.Reject();
            Console.WriteLine("Từ chối yêu cầu");
            return await Task.FromResult(true);

        }
        public void DisplayRequest()
        {
            //foreach (var req in returnRequests)
            //{
            //    Console.WriteLine(req);
            //}
        }
        public void DisplayPendingRequest()
        {
            //    foreach (var req in returnRequests)
            //    {
            //        if (req.Status == RequestStatus.Pending)
            //        Console.WriteLine(req);
            //    }
        }
    }
}
