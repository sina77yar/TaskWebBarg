using API.Helpers;
using API.Models;
using Application.Interfaces;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;


namespace API.Controllers
{    
    public class PersonsController : Controller
    {
		private readonly IPersonService personService;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public PersonsController(IPersonService personService,ICountryService countryService,ICityService cityService,IWebHostEnvironment hostingEnvironment)
        {
			this.personService = personService;
            this.countryService = countryService;
            this.cityService = cityService;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
		{
			var result =  personService.GetAll();
			var Countries =  countryService.GetAll();
			var cities =  cityService.GetAll();
            var provider = Path.Combine( hostingEnvironment.WebRootPath);
            foreach (var item in result)
            {
                //var content = provider.GetDirectoryContents(Path.Combine("Uploads")).Where(a=>a.Name == item.ImageName).FirstOrDefault();
                DirectoryInfo dir = new DirectoryInfo(provider);
                item.FileInfo =dir.GetFiles();
            }
            int IranCount = result.FindAll(p=>p.Country.CountryName =="Iran").Count();
            int USCount = result.FindAll(p=>p.Country.CountryName =="US").Count();
            int ENCount = result.FindAll(p=>p.Country.CountryName =="England").Count();
            int UAECount = result.FindAll(p=>p.Country.CountryName =="UAE").Count();
            int IrCount = result.FindAll(p=>p.Country.CountryName == "Iraq").Count();
            Chart pieChart = GeneratePieChart(IranCount, USCount, ENCount, UAECount, IrCount);
            ViewData["PieChart"] = pieChart;
            ViewData["Countries"] = Countries;
            ViewData["Cities"] = cities;


            return View(result);
        }
        [HttpPost]
        public  JsonResult Insert(IFormCollection formcollection,IEnumerable<IFormFile> files)
        {
            string path = Path.Combine(this.hostingEnvironment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filename = "";
            foreach (var file in files)
            {
                if(file!=null && file.Length>0)
                {
                    filename = file.FileName;
                    using (var fs = new FileStream(Path.Combine(path, filename), FileMode.Create ,FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }
                }
            }
            PersonDto person = new PersonDto();
            person.FirstName = formcollection["FirstName"];
            person.LastName = formcollection["LastName"];
            person.CountryId =Convert.ToInt32( formcollection["CountryId"]);
            person.CityId = Convert.ToInt32(formcollection["CityId"]);
            person.ImageName = filename;
            var res = personService.Add(person);
            return Json(res);
        }
        [HttpPost]
        public IActionResult getCity(int id)
        {
            var cities = cityService.GetAll();

            var cityList = cities.FindAll(p => p.CountryId == id).ToList();
          
            return Json(new { status = "success", cityList });
        }
        [HttpPost]
        public JsonResult Search(IFormCollection formcollection)
        {
            PersonDto person = new PersonDto();
            person.LastName = formcollection["searchfield"];

            var res = personService.GetAll();

           var a= from c in res
            where c.LastName.Contains(person.LastName)
            select c;
            return Json(a);
        }
        public class GetChartData
        {
            
        }
        public static  Chart GeneratePieChart(int IranCount, int USCount,int ENCount, int UAECount , int IrCount)
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Pie;

            Data data = new Data();
            data.Labels = new List<string>() { "Iran", "US","EN","UAE","Iraq" };

            PieDataset dataset = new PieDataset()
            {
                Label = "My dataset",
                BackgroundColor = new List<ChartColor>() {
                   ChartColor.FromHexString("#FF6384"),
                   ChartColor.FromHexString("#36A2EB"),
                   ChartColor.FromHexString("#FFCE56")
               },
                HoverBackgroundColor = new List<ChartColor>() {
                   ChartColor.FromHexString("#FF6384"),
                   ChartColor.FromHexString("#36A2EB"),
                   ChartColor.FromHexString("#FFCE56")  
               },
                Data = new List<double?>() { IranCount, USCount ,ENCount,UAECount,IrCount }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            return chart;
        }

    }
}
