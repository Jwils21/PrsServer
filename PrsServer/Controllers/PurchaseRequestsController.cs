using PrsServer.Models;
using PrsServer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PrsServer.Controllers
{
    public class PurchaseRequestsController : ApiController
    {

		private PrsDbContext db = new PrsDbContext();

		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.PurchaseRequests.ToList()
			};
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse PurchaseRequest(int? id) {
			if(id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Id does not exist"
				};
			}
			return new JsonResponse {
				Data = db.PurchaseRequests.Find(id)
			};
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(PurchaseRequest purchaseRequest) {
			if(purchaseRequest == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PurchaseRequest"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}

			db.PurchaseRequests.Add(purchaseRequest);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = purchaseRequest
			};
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(PurchaseRequest purchaseRequest) {
			if(purchaseRequest == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PurchaseRequest"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(purchaseRequest).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = purchaseRequest
			};
		}

		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(PurchaseRequest purchaseRequest) {
			if(purchaseRequest == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PurchaseRequest"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(purchaseRequest).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();

			return new JsonResponse {
				Message = "Remove successful.",
				Data = purchaseRequest
			};
		}

		//REMOVE/ID
		[HttpPost]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if(id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a PurchaseRequest.Id"
				};
			var purchaseRequest = db.PurchaseRequests.Find(id);
			if(purchaseRequest == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No Purchase Requests have Id of {id}"
				};
			db.PurchaseRequests.Remove(purchaseRequest);
			db.SaveChanges();

			return new JsonResponse {
				Message = "Remove successful.",
				Data = purchaseRequest
			};
		}



	}

}
