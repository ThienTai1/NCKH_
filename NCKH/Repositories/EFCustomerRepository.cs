/*using NCKH.Data;*/
using NCKH.Models;
using Microsoft.EntityFrameworkCore;
using NCKH.Repositories;

namespace WebsiteFashion.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly CustomerChurnContext _context;
        public EFCustomerRepository(CustomerChurnContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetByIdAsync(string id)
        {
            return await _context.Customers.FindAsync(id);
        }
        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}