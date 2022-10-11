using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items = new List<Item> {

                new Regular { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Aged { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Regular { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Legendary { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Legendary { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new BackstagePass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new BackstagePass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new BackstagePass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5,Quality = 49},
				// this conjured item does not work properly yet
				new Conjured { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program();

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (Item v in app.Items)
                {
                    Console.WriteLine(v.Name + ", " + v.SellIn + ", " + v.Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }

        }
        
        public void UpdateQuality()
        {
            foreach (Item v in Items)
            {
                v.Update();
            }
        }

    }

    /*We have decided to create an Update method on the Goblins Item.
    The alternative was having a sub class of Item with this method, but having an extra class as middle step would not be a very
    elegant solution, and we have therefore feel it's a valid refactoring.
    We are sure the Goblin would be happy to see this change to his beloved Item    
    */
    public abstract class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    
        public virtual void Update(){}
    }

}