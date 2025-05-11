//// Day one 
//// ORM 
//// install 2 Packages 
//// Database First vs Code First
//// to map Class to table Strcture "DataAnnotations"

//// Day Two
//// to map Class to table Strcture "Fluent API"
//// Migrations Commands MUST Install (2 Packages TOOLS, Desgin)
//// Add-Migration init 
//// Add-Migration update......
//// Remove-Migration // remove last migartion (BUT NOT implemented Migratios)
//// Update-database  // implement All Migration To Database
//// update-database productvendorrelation //Undo Till productvendorrelation
//// get-migration // list all migration with status 

////Day Three
//// Models Configration
//// Data Seeding
//// Execution 
////Eager
////Implicit
////Lazy

////Day Five
////Query Filter 

//using EF_Core.Models;
//using Microsoft.EntityFrameworkCore;

//namespace EF_Core
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {

//            EShopContext context = new EShopContext();



//            //Eager Loading
//            //var data = context.Categories
//            //.Include(c => c.Products)
//            //.ThenInclude(p => p.Attachments)
//            //.ToList();


//            //impicit Loading
//            //var data = context.Categories.Where(i=>i.Name.ToLower().Contains("l")).ToList();
//            //foreach (var item in data)
//            //{
//            //Console.WriteLine($"{item.Name} ");
//            //if (!context.Entry(item).Collection(i => i.Products).IsLoaded)
//            //    context.Entry(item).Collection(i => i.Products).Load();
//            //foreach (var prd in item.Products)
//            //{
//            //    Console.WriteLine($"{prd.Name}");
//            //}
//            //}

//            //Lazy Loading
//            //var data = context.Categories
//            //.Where(i => i.Name.ToLower().Contains("l")).ToList();
//            //foreach (var item in data)
//            //{
//            //    Console.WriteLine($"{item.Name} ");
//            //    foreach (var prd in item.Products)
//            //    {
//            //        Console.WriteLine($"{prd.Name} {prd.Attachments.Count}");
//            //    }
//            //}


//            //Product product = new Product { CategoryId = 2 , Description = "ttttt",
//            //Name = "Teeeet",Price = 100,Quantity = 20, VendorId = 1, };

//            //context.Products.Add(product);

//            //context.SaveChanges();

//            //NO DML
//            //var data = context.Products.Where(p => p.Id == 3).AsNoTracking().FirstOrDefault();

//            //var data = context.Products.Where(p => p.Id == 3).FirstOrDefault();

//            //data.Quantity = 1;

//            //context.Products.Update(data);

//            //context.SaveChanges();




//            #region Transaction
//            //var trans = context.Database.BeginTransaction();
//            //try
//            //{
//            //    List<int> cart = [2,3] ;
//            //    //1 = get products
//            //    var products = context.Products.Where(i=> cart.Contains(i.Id)).ToList();

//            //    //2 = If Stock contain vaild QTY
//            //    if (products.Any() && products[0].Quantity >= 1 && products[1].Quantity >= 1) {

//            //        //3 = make order (Take Token Signed in User => Get UserID)
//            //        //4 = add Order Item
//            //        var order = new Order
//            //        {
//            //            ClientId = 1,
//            //            Date = DateTime.Now,
//            //            Status = Enums.OrderStatus.Pending,
//            //            TotalPrice = products.Sum(i => i.Price),
//            //            TotalQuantity = 2,
//            //            //Items = products.Select(i=> new OrderItem { ProductId = i.Id, Quantity = 1}).ToList()
//            //        };
//            //        context.Orders.Add(order);
//            //        context.SaveChanges();

//            //        context.OrderItems.AddRange(
//            //            new OrderItem { OrderId = order.Id, Quantity = 1, ProductId = products[0].Id },
//            //            new OrderItem { OrderId = order.Id, Quantity = 1, ProductId = products[1].Id }
//            //            );
//            //        context.SaveChanges();

//            //        //5 = Quantity -- 
//            //        products[0].Quantity--;
//            //        products[1].Quantity--;
//            //        //Error will Happend
//            //        //products[0].Name = null;

//            //        context.SaveChanges();


//            //    }

//            //    trans.Commit();
//            //}
//            //catch (Exception ex) { 
//            //    Console.WriteLine(ex.ToString());
//            //    trans.Rollback();
//            //} 
//            #endregion

//            //var dare=  context.Products.FromSqlRaw("select * from Products where Id=2 ");


//            // context.Database.ExecuteSqlRaw("Update [Orders] set Status = 1 go ");


//            var data = context.Products.IgnoreQueryFilters().Where(p=>p.Id == 1).ToList();
//        }
//    }
//}