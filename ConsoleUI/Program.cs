using Business.Concrete;
using DataAccess.Concrete.InMemoryDb;
using Entities.Concrete;

CarManager carManager = new CarManager(new InMemoryDbCarDal());

Console.WriteLine("Cars in Data");
foreach (var item in carManager.GetAll())
{
    Console.WriteLine($"{item.Id} {item.Description}");
}

Console.WriteLine("----Add-------");
carManager.Add(new Car() { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 800, ModelYear = 1990, Description = "1990 Model Bmw" });
carManager.Add(new Car() { Id = 6, BrandId = 1, ColorId = 1, DailyPrice = 800, ModelYear = 1990, Description = "1990 Model Bmw" });

foreach (var car in carManager.GetAll())
{
    Console.WriteLine($"{car.Id} {car.ColorId} {car.Description}");
}

Console.WriteLine("-----Update-----");
carManager.Update(new Car() { Id = 6, BrandId = 1, ColorId = 4, DailyPrice = 1200, ModelYear = 1997, Description = "1997 Model Bmw" });
foreach (var car in carManager.GetAll())
{
    Console.WriteLine($"{car.Id} {car.ColorId} {car.Description}");

}

Console.WriteLine("-----Delete-----");
carManager.Delete(6);
foreach (var car in carManager.GetAll())
{
    Console.WriteLine($"{car.Id} {car.ColorId} {car.Description}");

}

Console.WriteLine("--GetById--");
foreach (var item in carManager.GetById(1))
{
    Console.WriteLine($"{item.Id} {item.BrandId} {item.DailyPrice} {item.Description}");
}
