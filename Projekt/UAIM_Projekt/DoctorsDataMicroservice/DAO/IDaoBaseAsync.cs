namespace DoctorsDataMicroservice.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDaoBaseAsync<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task<IEnumerable<T>> DeleteAsync(Guid id);
        
    }
}