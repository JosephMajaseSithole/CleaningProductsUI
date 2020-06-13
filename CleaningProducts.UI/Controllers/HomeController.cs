using CleaningProducts.UI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CleaningProducts.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly string baseUrl = "http://localhost:52530/api/supplier";

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult AddSupplier(Supplier supplier)
		{
			using (var client = new HttpClient())
			{
				var result = client.PostAsync(baseUrl, new StringContent(new JavaScriptSerializer().Serialize(supplier), Encoding.UTF8,"application/json")).Result;
			}

			return RedirectToAction("Index");
		}

		[ChildActionOnly]
		public ActionResult _AllSuppliers()
		{
			using (var client = new HttpClient())
			{

				var result = client.GetAsync(baseUrl).Result;

				if (result.IsSuccessStatusCode)
				{
					var jsonString = result.Content.ReadAsStringAsync().Result;
					var data = JsonConvert.DeserializeObject<List<Supplier>>(jsonString);

					return PartialView("_AllSuppliers", data);
				}
			}
			return PartialView();
		}

		public ActionResult SearchSupplier()
		{
			return View();
		}

		public ActionResult _SearchedSupplier(string companyName)
		{

			using (var client = new HttpClient())
			{

				var result = client.GetAsync(baseUrl + "?CompanyName=" + companyName).Result;

				if (result.IsSuccessStatusCode)
				{
					var jsonString = result.Content.ReadAsStringAsync().Result;
					var data = JsonConvert.DeserializeObject<List<Supplier>>(jsonString);

					return PartialView("_SearchedSupplier", data);

				}
			}

			return PartialView();
		}
	}
}