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
    public class ItemController : Controller
    {
        // Db Context
        private readonly ApplicationDbContext db;

        public ItemController(ApplicationDbContext context)
        {
            db = context;
        }

        public class Gold
        {
            public int @base { get; set; }
            public int total { get; set; }
            public int sell { get; set; }
            public bool purchasable { get; set; }
        }

        public class Image
        {
            public string full { get; set; }
            public string sprite { get; set; }
            public string group { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int w { get; set; }
            public int h { get; set; }
        }

        public class Maps
        {
            public bool __invalid_name__11 { get; set; }
            public bool __invalid_name__12 { get; set; }
            public bool __invalid_name__14 { get; set; }
            public bool __invalid_name__16 { get; set; }
            public bool __invalid_name__8 { get; set; }
            public bool __invalid_name__10 { get; set; }
        }

        public class Stats
        {
            public double FlatMovementSpeedMod { get; set; }
        }

        public class RootObject
        {
            public Gold gold { get; set; }
            public Image image { get; set; }
            public List<string> into { get; set; }
            public Maps maps { get; set; }
            public Stats stats { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string plaintext { get; set; }
            public int id { get; set; }
            public string sanitizedDescription { get; set; }
            public List<string> tags { get; set; }
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
                    var response = await client.GetAsync("lol/static-data/v3/items/" + id.ToString() + "?locale=en_US&tags=all&api_key=" + key);
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var item = JsonConvert.DeserializeObject<RootObject>(stringResult);

                    Item i = new Item();
                    ItemGold itemGold = new ItemGold();
                    ItemImage itemImage = new ItemImage();
                    List<ItemInto> itemInto = new List<ItemInto>();
                    ItemMaps itemMaps = new ItemMaps();
                    ItemStats itemStats = new ItemStats();
                    ItemTags itemTags = new ItemTags();

                    i.ItemID = item.id;
                    i.Description = item.description;
                    i.Plaintext = item.plaintext;
                    i.Name = item.name;
                    i.SanitizedDescription = item.sanitizedDescription;

                    itemGold.ItemID = i.ItemID;
                    itemGold.Base = item.gold.@base;
                    itemGold.Total = item.gold.total;
                    itemGold.Sell = item.gold.sell;
                    itemGold.Purchasable = item.gold.purchasable;

                    itemImage.ItemID = i.ItemID;
                    itemImage.Full = item.image.full;
                    itemImage.Sprite = item.image.sprite;
                    itemImage.Group = item.image.group;
                    itemImage.X = item.image.x;
                    itemImage.Y = item.image.y;
                    itemImage.W = item.image.w;
                    itemImage.H = item.image.h;

                    List<int> itemIntoItems = new List<int>();
                    for (int c = 0; c < item.into.Count(); c++)
                    {
                        itemIntoItems.Add(Convert.ToInt32(item.into[c]));
                    }
                    foreach(int itemIntoItemID in itemIntoItems)
                    {
                        itemInto.Add(new ItemInto
                        {
                            ItemID = item.id,
                            ItemIntoItemID = itemIntoItemID
                        });
                    }

                       



                    db.Item.Add(i);
                    db.SaveChanges();

                    status = "Adding " + i.Name + "...";

                }
                catch (HttpRequestException httpRequestException)
                {
                    Console.WriteLine(httpRequestException);
                    status = "Scanning database...";
                }

                return (status);
            }
           
        }
        
    }
}