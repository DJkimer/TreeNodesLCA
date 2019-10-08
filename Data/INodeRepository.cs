using System.Collections.Generic;
using System.Threading.Tasks;
using TreesAPI.Models;

namespace TreesAPI.Data
{
    public interface INodeRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Node>> GetNodes();
         Task<Node> GetNode(int id);
         Task<Node> GetNodeByValue(int value);
         Task<Node> GetFisrtNode();

    }
}