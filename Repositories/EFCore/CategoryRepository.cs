﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneCategory(Category category) =>
            Create(category);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) => 
            await FindAll(trackChanges).OrderBy(c => c.CategoryName).ToListAsync();

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges) => 
            await FindByCondition(c => c.CategoryId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneCategory(Category category)
        {
            Update(category);
        }

        public void DeleteOneCategory(Category category)
        {
            Delete(category);
        }
    }
}
