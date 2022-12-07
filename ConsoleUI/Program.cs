using Business.Concrete;
using DataAccess.Concrete.InMemoryDb;
using Entities.Concrete;
using System.Drawing;
using DataAccess.Concrete.EntityFramework;
using Color = Entities.Concrete.Color;

CarManager carManager = new CarManager(new EfCarDal());
Console.WriteLine("Cars in Data");
foreach (var item in carManager.GetAll().Data)
{
    Console.WriteLine($"{item.Id} {item.Description}");
}


Console.WriteLine("----Add-------");
var car1 = new Car() { BrandId = 4, ColorId = 1, DailyPrice = 2350, ModelYear = 2014, Description = "2014 Model Volvo" };
Console.WriteLine(carManager.Add(car1).Message);
Console.WriteLine(carManager.Add(new Car() { BrandId = 3, ColorId = 3, DailyPrice = 2500, ModelYear = 2017, Description = "2017 Model RangeRover" }).Message);
Console.WriteLine(carManager.Add(new Car() { BrandId = 1, ColorId = 1, DailyPrice = -12, ModelYear = 1990, Description = "1990 Model Bmw" }).Message);

var result = carManager.GetAll();
foreach (var car in result.Data)
{
    Console.WriteLine($"{car.Id} {car.BrandId} {car.Description}");
}

Console.WriteLine(result.Message);

Console.WriteLine("-----");

foreach (var car in carManager.GetCarsByBrandId(2).Data)
{
    Console.WriteLine($"{car.Id} {car.BrandId} {car.Description}");
}

Console.WriteLine("--------");
foreach (var car in carManager.GetCarsByColorId(3).Data)
{
    Console.WriteLine($"{car.Id} {car.ColorId} {car.Description}");
}


Console.WriteLine("---Update---");
Console.WriteLine(
    carManager.Update(new Car() { Id = 3009, BrandId = 3, ColorId = 3, DailyPrice = 2500, ModelYear = 2002, Description = "2002 Model RangeRover" }).Message);

foreach (var car in carManager.GetAll().Data)
{
    Console.WriteLine($"{car.Id} {car.ModelYear} {car.Description}");
}

Console.WriteLine("--Delete--");
Console.WriteLine(carManager.Delete(new Car()
{
    Id = 3009,
    BrandId = 3,
    ColorId = 3,
    DailyPrice = 2500,
    ModelYear = 2002,
    Description = "2002 Model RangeRover"
}).Message);
foreach (var car in carManager.GetAll().Data)
{
    Console.WriteLine($"{car.Id} {car.ModelYear} {car.Description}");
}

Console.WriteLine("---CarDetails---");
foreach (var carDetails in carManager.GetCarDetails().Data)
{
    Console.WriteLine($"{carDetails.CarName,-25} {carDetails.BrandName} {carDetails.ColorName} {carDetails.DailyPrice}");
}
Console.WriteLine(carManager.GetCarDetails().Message);

BrandManager brandManager = new BrandManager(new EfBrandDal()); 
Console.WriteLine("Brands in Data");
foreach (var item in brandManager.GetAll().Data)
{
    Console.WriteLine($"{item.Id} {item.BrandName}");
}

Console.WriteLine("--Add--");
brandManager.Add(new Brand() { BrandName = "Wolkswagen" });
foreach (var brand in brandManager.GetAll().Data)
{
    Console.WriteLine($"{brand.Id} {brand.BrandName}");
}
Console.WriteLine("-GetById--");
Console.WriteLine(brandManager.GetById(4).Data.BrandName);

Console.WriteLine("--Update--");
brandManager.Update(new Brand() { Id = 2, BrandName = "Audi" });
foreach (var brand in brandManager.GetAll().Data)
{
    Console.WriteLine($"{brand.Id} {brand.BrandName}");
}

Console.WriteLine("--Delete--");
brandManager.Delete(new Brand() { Id = 1003, BrandName = "Wolkswagen" });
foreach (var brand in brandManager.GetAll().Data)
{
    Console.WriteLine($"{brand.Id} {brand.BrandName}");
}


ColorManager colorManager = new ColorManager(new EfColorDal());
Console.WriteLine("Colors in Data");
foreach (var item in colorManager.GetAll().Data)
{
    Console.WriteLine($"{item.Id} {item.ColorName}");
}

Console.WriteLine("--Add--");
colorManager.Add(new Color() { ColorName = "Orange" });
foreach (var color in colorManager.GetAll().Data)
{
    Console.WriteLine($"{color.Id} {color.ColorName}");
}

Console.WriteLine("--Update--");
colorManager.Update(new Color() { Id = 1003, ColorName = "Purple" });
foreach (var color in colorManager.GetAll().Data)
{
    Console.WriteLine($"{color.Id} {color.ColorName}");
}

Console.WriteLine("--Delete--");
colorManager.Delete(new Color() { Id = 1003, ColorName = "Purple" });
foreach (var color in colorManager.GetAll().Data)
{
    Console.WriteLine($"{color.Id} {color.ColorName}");
}
