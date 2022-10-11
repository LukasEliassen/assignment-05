namespace GildedRose.Tests;

public class ProgramTests
{
    Program app;
    public ProgramTests(){
        var app = new Program(){
        };
    }
    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }
    [Fact]
    public void non_special_item_updateQuality_deteriorates_by_1(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(9);
        app.Items[0].Quality.Should().Be(19);
    }
    [Fact]
    public void expired_non_special_item_updateQuality_deteriorates_by_2(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(-1);
        app.Items[0].Quality.Should().Be(18);
    }
    [Fact]
    public void legendary_item_doesnt_decrease_in_quality(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(0);
        app.Items[0].Quality.Should().Be(80);
    }
    [Fact]
    public void brie_quality_increases_with_update(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new WellAgingItem { Name = "Aged Brie", SellIn = 5, Quality = 10 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(4);
        app.Items[0].Quality.Should().Be(11);
    }
    [Fact]
    public void quality_does_not_exceed_50(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new WellAgingItem { Name = "Aged Brie", SellIn = 5, Quality = 50 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(4);
        app.Items[0].Quality.Should().Be(50);
    }
    [Fact]
    public void backstage_quality_does_not_exceed_50(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new BackstageItem { Name = "Aged Brie", SellIn = 5, Quality = 50 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(4);
        app.Items[0].Quality.Should().Be(50);
    }
    [Fact]
    public void backstagepass_sellin_greater_than_10_increases_quality_by_one(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new BackstageItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 20 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(11);
        app.Items[0].Quality.Should().Be(21);
    }
    [Fact]
    public void backstagepass_sellin_greater_than_5_increases_quality_by_two(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new BackstageItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(6);
        app.Items[0].Quality.Should().Be(22);
    }
    [Fact]
    public void backstagepass_sellin_less_than_5_increases_quality_by_three(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new BackstageItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 20 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(3);
        app.Items[0].Quality.Should().Be(23);
    }
    [Fact]
    public void expired_backstagepass_is_worthless(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new BackstageItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(-1);
        app.Items[0].Quality.Should().Be(0);
    }
    [Fact]
    public void quality_is_never_negative(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(9);
        app.Items[0].Quality.Should().Be(0);
    }
    [Fact]
    public void backstagepass_loop(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new BackstageItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 0 }
            }
        };
        for(int i = 0; i < 16; i++){
            app.Items[0].UpdateQuality();
        }
        
        app.Items[0].SellIn.Should().Be(4);
        app.Items[0].Quality.Should().Be(23);
    }
    [Fact]
    public void brie_loop(){
        
        var app = new Program(){
            Items = new List<Item>(){
                new WellAgingItem { Name = "Aged Brie", SellIn = 20, Quality = 0 }
            }
        };
        for(int i = 0; i < 16; i++){
            app.Items[0].UpdateQuality();
        }
        
        app.Items[0].SellIn.Should().Be(4);
        app.Items[0].Quality.Should().Be(16);
    }
    [Fact]
    public void item_get_name(){
       var app = new Program(){
            Items = new List<Item>(){
                new Item { Name = "Aged Brie", SellIn = 20, Quality = 0 }
            }
        };
        app.Items[0].Name.Should().Be("Aged Brie");
    }
    [Fact]
    public void item_set_name(){
       var app = new Program(){
            Items = new List<Item>(){
                new Item { Name = "Item", SellIn = 20, Quality = 0 }
            }
        };
        app.Items[0].Name = "Aged Brie";
        app.Items[0].Name.Should().Be("Aged Brie");
    }
    [Fact]
    public void conjured_mana_cake_deteriorates_twice_as_fast(){
       var app = new Program(){
            Items = new List<Item>(){
                new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 20, Quality = 10 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(19);
        app.Items[0].Quality.Should().Be(8);
    }
    [Fact]
    public void expired_conjured_mana_cake_deteriorates_twice_as_fast(){
       var app = new Program(){
            Items = new List<Item>(){
                new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(-1);
        app.Items[0].Quality.Should().Be(6);
    }
    [Fact]
    public void conjured_mana_cake_quality_never_recedes_0(){
       var app = new Program(){
            Items = new List<Item>(){
                new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 20, Quality = 0 }
            }
        };
        app.Items[0].UpdateQuality();
        app.Items[0].SellIn.Should().Be(19);
        app.Items[0].Quality.Should().Be(0);
    }
}