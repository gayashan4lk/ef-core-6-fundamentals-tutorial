﻿using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData
{
	public class PubContext:DbContext
	{
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=pubDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}
	}
}