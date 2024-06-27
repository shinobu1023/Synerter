using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Dapper;
using Model;

public class ProductDetilRepository
{
    private readonly DapperContext _context;

    public ProductDetilRepository()
    {
        _context = new DapperContext();
    }
    /// <summary>
    /// 查詢
    /// </summary>
    /// <returns></returns>
    public List<Product> GetProducts()
    {
        using (var connection = _context.GetConnection())
        {
            string sql = @"SELECT * FROM Product_Index";
            var result = connection.Query<Product>(sql).AsList();
            return result;
        }
    }

    /// <summary>
    /// 模糊查詢
    /// </summary>
    /// <param name="productName"></param>
    /// <returns></returns>
    public List<Product> GetIdFromProducts(Product productName)
    {
        using (var connection = _context.GetConnection())
        {
            string sql = @"SELECT * FROM Product_Detil ";
            if (productName.ProductName != null)
            {
                sql += "WHERE ProductName Like %@ProductName%";
            }
            var result = connection.Query<Product>(sql, productName).ToList();
            return result;
        }
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="create"></param>
    /// <returns></returns>
    public bool CreateProduct(Product create)
    {
        using (var connection = _context.GetConnection())
        {
            string sql = @"INSERT INTO Product_Detil (Id ,Image,ProductName,SellerName,Price)
                           VALUE  (@Id ,@Image ,@ProductName ,@SellerName ,@Price)";
            var result = connection.Execute(sql, create) > 0 ? true : false;
            return result;
        }
    }

    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public bool UpdateProduct(Product product) 
    {
        using (var connection = _context.GetConnection())
        {
            string sql = @"UPDATE Product_Detil
                           SET ProductName = @ProductName
                           WHERE Id = @Id";
            var result = connection.Execute(sql, product) > 0 ? true : false;
            return result;
        }
    }

    /// <summary>
    /// 刪除
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public int DeleteProduct(Product product)
    {
        using (var connection = _context.GetConnection())
        {
            string sql = @"DELETE FROM  Product_Detil
                           WHERE Id = @Id";
            var result = connection.Execute(sql, product);
            return result;
        }
    }
}
