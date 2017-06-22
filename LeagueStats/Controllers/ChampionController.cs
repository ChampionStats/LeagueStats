using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeagueStats.Data;
using System.Net.Http;
using Newtonsoft.Json;
using LeagueStats.Models;

namespace LeagueStats.Controllers
{
    public class ChampionController : Controller
    { 
        // Db Context
        private readonly ApplicationDbContext db;

        public ChampionController(ApplicationDbContext context)
        {
            db = context;
        }

        private class Info
        {
            public int difficulty { get; set; }
            public int attack { get; set; }
            public int defense { get; set; }
            public int magic { get; set; }
        }

        private class RootObject
        {
            public Info info { get; set; }
            public string title { get; set; }
            public int id { get; set; }
            public string key { get; set; }
            public string name { get; set; }
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> Refresh(int id)
        {
            DataController data = new DataController();

            string key = data.Key();
            string status;

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://na1.api.riotgames.com/");
                    var response = await client.GetAsync("lol/static-data/v3/champions/" + id.ToString() +"?champData=info&api_key=" + key);
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var champion = JsonConvert.DeserializeObject<RootObject>(stringResult);

                    Champion c = new Champion();

                    c.ID = champion.id;
                    c.Title = champion.title;
                    c.Key = champion.key;
                    c.Name = champion.name;

                    db.Champion.Add(c);
                    db.SaveChanges();

                    status = "Adding " + c.Name + "...";

                }
                catch (HttpRequestException httpRequestException)
                {
                    Console.WriteLine(httpRequestException);
                    status = "Scanning database...";
                }

                return (status);
            }
        }

        public bool ClearChampions()
        {
            try
            {
                var rows = from o in db.Champion
                           select o;

                foreach (var row in rows)
                {
                    db.Champion.Remove(row);
                }
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Error removing champions.");
                return false;
            }

            return true;
            

        }
    }
}