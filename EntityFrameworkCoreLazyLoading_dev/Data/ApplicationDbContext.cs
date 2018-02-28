using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreLazyLoading_dev.Data;

namespace EntityFrameworkCoreLazyLoading_dev.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

	    public DbSet<Category> Categories { get; set; }

	    public DbSet<Note> Note { get; set; }
    }

	public class Note
	{
		public string Id { get; set; }

		public string Title { get; set; }

		public string CategoryId { get; set; }

		public virtual Category Category { get; set; }
	}

	public class Category
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Note> Notes { get; set; }
	}
}
