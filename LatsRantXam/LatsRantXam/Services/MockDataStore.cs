using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LatsRantXam.Models;

[assembly: Xamarin.Forms.Dependency(typeof(LatsRantXam.Services.MockDataStore))]
namespace LatsRantXam.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "VIT, Screens", Description="Guess who thinks keeping super bright hording screens in college at night is a good idea? #LetsRant #VIT" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "VIT, Vellore", Description="Why the hell do we even have the attendance criteria ? :/ #LetsRant #CollegeLife" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Code2Create", Description="All good, BUT MAGGIE IS NOT DINNER ! #LetsRant" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "VIT, Screens", Description="These screens are a pain is the a** #LetsRant" },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}