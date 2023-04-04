using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.FoodItems;
using Newtonsoft;
using Newtonsoft.Json;
using System.Text;

namespace ThAmCo.Events.Controllers
{   
    public class FoodMenuController : Controller
    {
        // View fooditems
            Uri baseAddress = new Uri("localhost:7173/api");
            HttpClient client;
        public FoodMenuController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult index()
        {
            List<FoodItem> modelList = new List<FoodItem>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/foodItem").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<FoodItem>>(data);
            }
            return View(modelList);
    }

        public ActionResult Create()
        {
            return View();
        }
        //Create a foodItem
        [HttpPost]

        public ActionResult Create(FoodItem model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/user", content).Result;
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //public ActionResult Edit(int id)
        //{
        //    FoodItem model = new FoodItem();
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/foodItem/" + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;
        //        model = JsonConvert.DeserializeObject<FoodItem>(data);

        //        return View("Create",model);
        //    }
        //}

        //[HttpPost]

        //public ActionResult Edit(FoodItem model)
        //{
        //    string data = JsonConvert.SerializeObject(model);
        //    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/user", +model.FoodItemId, content).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View("Create",model);
        //}
    }
}
