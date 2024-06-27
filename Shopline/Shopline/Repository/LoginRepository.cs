using System.Collections.Generic;
using System.Xml.Linq;
using Dapper;

public class LoginRepository
{
    private readonly DapperContext _context;

    public LoginRepository()
    {
        _context = new DapperContext();
    }

    /// <summary>
    /// 查多筆
    /// </summary>
    /// <returns></returns>
    public List<User> GetAllUsers()
    {
        using (var connection = _context.GetConnection())
        {
            string sql = "SELECT * FROM LOGIN";
            return connection.Query<User>(sql).AsList();
        }
    }

    /// <summary>
    /// 查單筆
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public User GetUserById(int id)
    {
        User user = new User()
        {
            Id = id.ToString(),
            UserName= "BW"
        };
        using (var connection = _context.GetConnection())
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id AND UserName = @UserName";
            return connection.QueryFirstOrDefault<User>(sql, user);
        }
    }

    public void AddUser(User user)
    {
        using (var connection = _context.GetConnection())
        {
            string sql = "INSERT INTO ";
            connection.Execute(sql, user);
        }
    }

    // 根據需要添加更多的方法
}
