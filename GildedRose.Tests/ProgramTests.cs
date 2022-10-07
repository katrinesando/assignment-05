using System.Reflection;

namespace GildedRose.Tests;


public class ProgramTests
{
    [Fact]
    public void output_test_from_txt_file(){
        using var writer = new StringWriter();
        Console.SetOut(writer);
        var expected = System.IO.File.ReadAllText("C:/Users/sando/Documents/1 Uni/2 år/3 semester/BDSA/Assignment5/assignment-05/GildedRose/output.txt");

        // Program.Main(Array.Empty<string>);

        var program = Assembly.Load(nameof(GildedRose));
        program.EntryPoint?.Invoke(null, new[] { Array.Empty<string>() });

        writer.ToString().Should().Be(expected);
    }
    //expired selldate <0 decrease double 
    [Fact]
    public void sellDate_passed_returns_Quality_degrades_twice_fast(){
        var item = new Item{Name = "Product", SellIn=1,Quality=10};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.SellIn.Should().Be(-1);
        item.Quality.Should().Be(7);
    }

    //quality can never go below zero
    [Fact]
    public void Quality_never_below_zero_returns_true(){
        var item = new Item{Name = "Product", SellIn=1,Quality=0};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.Quality.Should().Be(0);
    }

    //Aged bried test
    [Fact]
    public void Aged_brie_better_quality_with_time(){
        var item = new Item{Name = "Aged Brie", SellIn=3,Quality=1};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.Quality.Should().Be(3);
    }
    [Fact]
    public void Aged_brie_quality_of_item_should_not_exceed_50(){
        var item = new Item{Name = "Aged Brie", SellIn=3,Quality=49};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.Quality.Should().Be(50);
    }
  
    //sulfuras test
    [Fact]
    public void Sulfuras_Sellin_stays_the_same(){
        var item = new Item{Name = "Sulfuras, Hand of Ragnaros", SellIn=3,Quality=1};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.SellIn.Should().Be(3);
    }
    [Fact]
    public void Sulfuras_Quality_stays_the_same(){
        var item = new Item{Name = "Sulfuras, Hand of Ragnaros", SellIn=3,Quality=30};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.Quality.Should().Be(30);
    }

    //backstage test
    [Fact]
    public void backstage_should_increase_quality_normal(){
        var item = new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn=20,Quality=0};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.Quality.Should().Be(2);

    }
    [Fact]
    public void backstage_should_increase_quality_until_6(){
        var item = new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn=10,Quality=0};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.Quality.Should().Be(4);

    }

    [Fact]
    public void backstage_should_increase_quality_until_0(){
        var item = new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn=5,Quality=0};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.Quality.Should().Be(6);
    }
    
    [Fact]
    public void backstage_should_drop_quality_to_0_when_sellIn_negative(){
        var item = new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn=0,Quality=30};
        var app = new Program();
        app.Items.Add(item);
        app.UpdateQuality();
        app.UpdateQuality();
        item.Quality.Should().Be(0);
    }

}