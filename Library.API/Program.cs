using Library.API.DB;
using Library.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDB>(options =>
{
    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LibraryDB;Trusted_Connection=True");
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
app.MapPost("/books/add", (LibraryDB db, Book book) =>
{
    db.Books.Add(book);
    db.SaveChanges();
});
app.MapPost("/books/list", (LibraryDB db) =>
{
    return db.Books.ToList();
});
app.MapPost("/books/update", (LibraryDB db, Book book) =>
{
    db.Books.Update(book);
    db.SaveChanges();
});
app.MapPost("/books/remove/{BookId}", (LibraryDB db, int BookId) =>
{
    var book = db.Books.Find(BookId);
    if (book != null)
    {

        db.Books.Remove(book);
        db.SaveChanges();
    }
});


app.MapPost("/members/add", (LibraryDB db, Member member) =>
{
    db.Members.Add(member);
    db.SaveChanges();
});
app.MapPost("/members/list", (LibraryDB db) =>
{
    return db.Members.ToList();
});
app.MapPost("/members/update", (LibraryDB db, Member member) =>
{
    db.Members.Update(member);
    db.SaveChanges();
});
app.MapPost("/members/remove/{MemberId}", (LibraryDB db, int MemberId) =>
{
    var member = db.Members.Find(MemberId);
    if (member != null)
    {

        db.Members.Remove(member);
        db.SaveChanges();
    }
});

app.Run();
