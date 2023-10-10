using Lab1.Entity;

namespace Lab1.Interfaces
{
    public interface IShowTableService
    {
        string ShowTable(HttpContext context, DBContext dBContext);
    }
}
