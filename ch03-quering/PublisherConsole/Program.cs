using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
	context.Database.EnsureDeleted();
	context.Database.EnsureCreated();
}

// AddAuthors();
// GetAuthors();
AddAuthorWithBooks();
GetAuthorsWithBooks();
QueryFilters("Eon");

void QueryFilters(string name)
{
	using var context = new PubContext();

	var authors = context.Authors
		.Where(s => s.FirstName == name)
		.Include(author => author.Books)
		.ToList();

	Console.WriteLine("== Search Results ==");

	foreach (var author in authors)
	{
		Console.WriteLine($"{author.FirstName} {author.LastName}");
		Console.WriteLine($"No of books {author.Books.Count}");
	}
}

void GetAuthors()
{
	using var context = new PubContext();
	var authors = context.Authors.ToList();

	foreach (var author in authors)
	{
		Console.WriteLine($"{author.FirstName} {author.LastName}");
	}
}

void AddAuthors()
{
	var authors = new Author { FirstName = "John", LastName = "King" };
	using var context = new PubContext();
	context.Authors.Add(authors);
	context.SaveChanges();
}

void AddAuthorWithBooks()
{
	var author = new Author { FirstName = "Eon", LastName = "Mark" };
	author.Books.Add(new Book {Title = "Entity Framework Core", PublishDate = new DateTime(2010,1,1)});
	author.Books.Add(new Book { Title = "Java Programming For Dummies", PublishDate = new DateTime(1995, 8, 15) });

	using var context = new PubContext();
	context.Authors.Add(author);
	context.SaveChanges();
}

void GetAuthorsWithBooks()
{
	using var context = new PubContext();
	var authors = context.Authors.Include(a => a.Books).ToList();

	foreach (var author in authors)
	{
		Console.WriteLine($"{author.FirstName} {author.LastName}");
		foreach (var authorBook in author.Books)
		{
			Console.WriteLine($"* {authorBook.Title}");
		}
	}
}