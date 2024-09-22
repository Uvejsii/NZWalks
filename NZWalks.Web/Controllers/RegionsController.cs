using Microsoft.AspNetCore.Mvc;
using NZWalks.Web.Models;
using NZWalks.Web.Models.DTO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace NZWalks.Web.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();

            try
            {
                // Get All Regions From Web API
                var client = _httpClientFactory.CreateClient();

                var httResponseMessage = await client.GetAsync("https://localhost:7115/api/Regions");

                httResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());
            }
            catch (Exception ex)
            {
                throw;
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var httpReqMsg = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7115/api/Regions"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var httpResMsg = await client.SendAsync(httpReqMsg);

            httpResMsg.EnsureSuccessStatusCode();
            
            var res = await httpResMsg.Content.ReadFromJsonAsync<RegionDto>();

            if (res != null)
            {
                return RedirectToAction("Index", "Regions");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();

            var res = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7115/api/Regions/{id.ToString()}");

            if (res != null)
            {
                return View(res);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDto request)
        {
            var client = _httpClientFactory.CreateClient();

            var httRequestMsg = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7115/api/Regions/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };

            var httpResMsg = await client.SendAsync(httRequestMsg);

            httpResMsg.EnsureSuccessStatusCode();

            var res = await httpResMsg.Content.ReadFromJsonAsync<RegionDto>();

            if(res != null)
            {
                return RedirectToAction("Index", "Regions");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient();

            var res = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7115/api/Regions/{id.ToString()}");

            if (res != null)
            {
                return View(res);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionDto request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                var httpResMsg = await client.DeleteAsync($"https://localhost:7115/api/Regions/{request.Id}");

                httpResMsg.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Regions");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
