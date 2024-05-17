namespace NCKH.Repositories

{
    using System.Collections.Generic;
    using NCKH.Models;
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer product);
        Task UpdateAsync(Customer product);
        Task DeleteAsync(int id);
    }
}
