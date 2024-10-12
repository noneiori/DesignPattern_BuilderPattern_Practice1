namespace DesignPattern_BuilderPattern_Practice1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BurgerBuilder builder = new BurgerBuilder()
                .SetSource("Ketchup")
                .SetBread("White Bread")
                .SetIngredients("Orion");
            Director director = new Director();            
            
            var vegetBurger = director.BuilderVegetBurger(builder);
            var beefBurger = director.BuildBeefBurger(builder);
            Console.WriteLine(vegetBurger);
            Console.WriteLine("---");
            Console.WriteLine(beefBurger);
        }
    }

    class BurgerBuilder
    {
        Burger burger;

        public BurgerBuilder()
        {
            this.burger = new Burger();
        }

        public Burger Build()
        {
            if (string.IsNullOrEmpty(burger.Bread))
                throw new InvalidOperationException("Bread must be set.");
            return burger;
        }

        public BurgerBuilder SetMeat(string meatName)
        {
            this.burger.Meat = meatName;
            return this;
        }

        public BurgerBuilder SetBread(string bread)
        {
            this.burger.Bread = bread;
            return this;
        }

        public BurgerBuilder SetSource(string sauce)
        {
            this.burger.Sauce = sauce;
            return this;
        }

        public BurgerBuilder SetIngredients(string ingredients)
        {
            this.burger.Ingredients = ingredients;
            return this;
        }
    }

    class Director
    {
        public Burger BuildBurger(BurgerBuilder builder)
        {
            return builder.Build();
        }

        public Burger BuildBeefBurger(BurgerBuilder builder)
        {
            return builder
                .SetMeat("Beef")
                .Build();
        }

        public Burger BuilderVegetBurger(BurgerBuilder builder)
        {
            return builder
                .SetMeat("No Meat")
                .Build();
        }
    }

    class Burger
    {
        public string? Meat { get; set; }
        public string? Bread { get; set; }
        public string? Sauce { get; set; }
        public string? Ingredients { get; set; }

        public override string ToString()
        {
            return $"Meat:{Meat}\r\n" +
                $"Bread:{Bread}\r\n" +
                $"Sauce:{Sauce}\r\n" +
                $"Ingredients:{Ingredients}";
        }
    }
}