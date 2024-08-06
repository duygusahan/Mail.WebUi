using Mail.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.DataAccessLayer.Context
{
	public class MailContext:IdentityDbContext<AppUser , AppRole , int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-QI6ELCD;initial catalog=DbMailBox;integrated security=true;");
		}
		public DbSet<Message> Messages { get; set; }
		public DbSet<Draft> Drafts { get; set; }
	}
}

