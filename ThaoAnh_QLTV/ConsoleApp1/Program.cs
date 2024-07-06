// See https://aka.ms/new-console-template for more information
using Dapper;
using DemoDapper;
using QLTV.CoreBusiness.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;

var connectStr = "Data Source=LAPTOP-GBGAMHDQ\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;TrustServerCertificate=True";

var da = new DataAccess(connectStr);
var results1 = da.Query<BOOK, dynamic>("Select * from BOOK", new { });

var results2 = da.QuerySingle<BOOK, dynamic>("Select * from BOOK  where BookId = @BookId",
    new { BookId = "DTN1" });

var sql = "";


//using (IDbConnection conn = new SqlConnection(connectStr))
//{
//var sql = @"INSERT INTO Product (ProductId, Brand, Name, Price)
//               values (@ProductId, @Brand, @Name, @Price)";

//var prod = new Product { ProductId = 10002, Brand = "His Brand", Name = "His Product", Price = 25.5 };
//conn.Execute(sql, prod);

//   var sql = @"Update Product 
//                SET ImageLink = @Url
//			 where Name = @Name";
//conn.Execute(sql, new { Url = "http://www.google.com/images", Name = "His Product" });

//var sql = @"DELETE FROM Product WHERE Name = @Name";
//conn.Execute(sql,new {Name = "His Product"});


//var results = conn.Query<Product>("Select * from Product");
//foreach (var record in results)
//{
//	Console.WriteLine($"{ record.Name}:{record.Price}:{record.ImageLink}");
//}
//HELPER/WRAPPER
//}