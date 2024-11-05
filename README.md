# Goodreads LINQ Excercises

The purpose of this repository is to train some simple EFC LINQ queries. 

I have a Queries class, with a number of unit test methods, each test is an exercise.

I have the DbContext, called GoodreadsContext, with defined DbSets for the entities.

You clone the repository, and then you probably need to change the Data Source path to the absolute path of the bookstore.db file.

I.e., you update the following in GoodreadsContext:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source = goodreads.db");
}
```

To something like:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source = C:\MyDrive\Projects\BookShopEfc\BookShopEfc\goodreads.db");
}
```

Here is the entity class diagram:

![d](https://github.com/TroelsMortensen/GoodreadsEfc/blob/master/GoodreadsEfc/GoodreadsEfc.png)
