using Microsoft.EntityFrameworkCore;
using BlogApp.Domain;
using BlogApp.Application.Contracts.Persistence;

namespace BlogApp.Persistence.Repositories;

public class BlogRepository: IBlogRepository
{
    private BlogAppDbContext _context;
    
    public BlogRepository(BlogAppDbContext context)
    {
        _context = context;
    }
        
    public async Task<Blog> Get(int id)
    {
        return await _context.Blogs.FindAsync(id);
    }

    public async Task<IReadOnlyList<Blog>> GetAll()
    {
        return await _context.Blogs.ToListAsync();
    }

    public async Task<Blog> Add(Blog blog)
    {
        await _context.Blogs.AddAsync(blog);

        
        return blog;
    }

    public async Task<bool> Exists(int id)
    {
        return (await _context.Blogs.FindAsync(id)) != null;
    }

    public async Task Update(Blog blog)
    {
        _context.Blogs.Update(blog);
    }
    
    public async Task Delete(Blog blog)
    {
        _context.Blogs.Remove(blog);
        
    }
}