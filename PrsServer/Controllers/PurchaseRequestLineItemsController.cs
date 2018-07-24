using PrsServer.Models;
using PrsServer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PrsServer.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class PurchaseRequestLineItemsController: ApiController 
	{

		private PrsDbContext db = new PrsDbContext();

		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.PurchaseRequestLineItems.ToList()
			};
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse PurchaseRequestLineItem(int? id) {
			if(id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Id does not exist"
				};
			}
			return new JsonResponse {
				Data = db.PurchaseRequestLineItems.Find(id)
			};
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(PurchaseRequestLineItem purchaseRequestLineItem) {
			if(purchaseRequestLineItem == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PurchaseRequestLineItem"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}

			db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
			db.SaveChanges();

			RecalcLineItemTotal(purchaseRequestLineItem.PurchaseRequestId);
			return new JsonResponse {
				Message = "Create successful.",
				Data = purchaseRequestLineItem
			};
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(PurchaseRequestLineItem purchaseRequestLineItem) {
			purchaseRequestLineItem.Product = null;
			purchaseRequestLineItem.PurchaseRequest = null;
			if(purchaseRequestLineItem == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PurchaseRequestLineItem"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(purchaseRequestLineItem).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();

			RecalcLineItemTotal(purchaseRequestLineItem.PurchaseRequestId);
			return new JsonResponse {
				Message = "Change successful.",
				Data = purchaseRequestLineItem
			};
		}

		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(PurchaseRequestLineItem purchaseRequestLineItem) {
			if(purchaseRequestLineItem == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PurchaseRequestLineItem"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(purchaseRequestLineItem).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();

			RecalcLineItemTotal(purchaseRequestLineItem.PurchaseRequestId);
			return new JsonResponse {
				Message = "Remove successful.",
				Data = purchaseRequestLineItem
			};
		}

		//REMOVE/ID
		[HttpPost]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if(id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a PurchaseRequestLineItem.Id"
				};
			var purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
			if(purchaseRequestLineItem == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No Purchase Request Line Items have Id of {id}"
				};
			db.PurchaseRequestLineItems.Remove(purchaseRequestLineItem);
			db.SaveChanges();

			RecalcLineItemTotal(purchaseRequestLineItem.PurchaseRequestId);
			return new JsonResponse {
				Message = "Remove successful.",
				Data = purchaseRequestLineItem
			};
		}

		private void RecalcLineItemTotal(int? purchaseRequestId) {
			if(purchaseRequestId == null) return;
			var pr = db.PurchaseRequests.Find(purchaseRequestId);
			if(pr == null) return;
			var lines = db.PurchaseRequestLineItems
				.Where(li => li.PurchaseRequestId == purchaseRequestId);
			pr.Total = lines.Sum(li => li.Quantity * li.Product.Price);
			db.SaveChanges();

		}
	}
}
