using PublisherData;

using (PubContext context = new PubContext())
{
	context.Database.EnsureCreated();
}

GetAuthors();

void GetAuthors()
{
	using var context = new PubContext();
	var authors = context.Authors.ToList();

	foreach (var author in authors)
	{
		Console.WriteLine($"{author.FirstName} {author.LastName}");
	}
}