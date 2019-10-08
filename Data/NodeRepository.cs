using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreesAPI.Models;

namespace TreesAPI.Data
{
    public class NodeRepository : INodeRepository
    {
        private readonly DataContext _context;
        public NodeRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Node> GetFisrtNode()
        {
            return await _context.Nodes.FirstOrDefaultAsync();
        }

        public async Task<Node> GetNode(int id)
        {
            return await _context.Nodes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Node> GetNodeByValue(int value)
        {
             return await _context.Nodes.FirstOrDefaultAsync(x => x.Value == value);
        }

        public async Task<IEnumerable<Node>> GetNodes()
        {
            return await _context.Nodes.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}