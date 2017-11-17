using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stypendium.Models;

namespace Stypendium.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        
        
         
        
        
        // GET /api/student
        [HttpGet]
        public  ActionResult Index()
        {
            IEnumerable<Person> students = null;
            
            using (HttpClient client = new HttpClient())
            {
            client.BaseAddress = new Uri
                ("http://localhost:5050");
            MediaTypeWithQualityHeaderValue contentType = 
                new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync
                ("/api/person").Result;
            string stringData = response.Content.
                ReadAsStringAsync().Result;
            IEnumerable<Person> data = JsonConvert.DeserializeObject
                <IEnumerable<Person>>(stringData);
            return View(data);
        }
            
            
        }
        
        
        public List<Przedmiot> metoda()
        {
            var przedmioty = new List<Przedmiot>
            {
                new Przedmiot("Java",4.5),
                new Przedmiot("C#",4.0)
            };

            return przedmioty;
        }
        
        
        
    }
}