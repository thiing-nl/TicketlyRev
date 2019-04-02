using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Screend.Entities.Location;
using Screend.Entities.Movie;
using Screend.Entities.Order;
using Screend.Entities.Schedule;
using Screend.Entities.Theater;
using Screend.Entities.Ticket;
using Screend.Entities.User;

namespace Screend.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {}
        
        // Register the entities
        
        // User
        public DbSet<User> Users { get; set; }

        // Movie
        public DbSet<Movie> Movies { get; set; }
        
        // Ticket
        public DbSet<Ticket> Tickets { get; set; }
        
        // Order
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderArticle> OrderArticles { get; set; }
        
        public DbSet<OrderChair> OrderChairs { get; set; }
        
        // Schedule
        public DbSet<Schedule> Schedules { get; set; }
        
        // Theater
        public DbSet<Theater> Theaters { get; set; }
        
        public DbSet<TheaterArticle> TheaterArticles { get; set; }
        
        public DbSet<TheaterChair> TheaterChairs { get; set; }
        
        public DbSet<TheaterRow> TheaterRows { get; set; }
        
        // Database seeders
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User seed
                
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "order",
                LastName = "order",
                Username = "order",
                Password = "order",
                AccountType = AccountType.User
            });
            
            #endregion
            
            #region Ticket seed

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 1,
                Title = "Normaal",
                Price = 8.50
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 2,
                Title = "Normaal",
                Price = 9.00
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 3,
                Title = "3D Film",
                Price = 11.00
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 4,
                Title = "3D Film",
                Price = 11.50
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 5,
                Title = "Normaal Kind",
                Price = 7.00
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 6,
                Title = "Normaal Kind",
                Price = 7.50
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 7,
                Title = "3D Kind",
                Price = 9.50
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 8,
                Title = "3D Kind",
                Price = 10.00
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 9,
                Title = "Normaal Student",
                Price = 7.00
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 10,
                Title = "Normaal Student",
                Price = 7.50
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 11,
                Title = "3D Student",
                Price = 9.50
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 12,
                Title = "3D Student",
                Price = 10.00
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 13,
                Title = "Normaal 65+",
                Price = 7.00
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 14,
                Title = "Normaal 65+",
                Price = 7.50
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 15,
                Title = "3D 65+",
                Price = 9.50
            });
            
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 16,
                Title = "3D 65+",
                Price = 10.00
            });
            
            #endregion
            
            #region Location Seeder
            
            modelBuilder.Entity<Location>().HasData(new Location
            {
                Id = 1,
                Name = "Tilburg",
                Address = "Pieter vreedeplein 174, 5038 BW Tilburg",
                Movies = new LocationMovie[0],
                Theaters = new Theater[0],
                Schedules = new Schedule[0]
            });
            
            modelBuilder.Entity<Location>().HasData(new Location
            {
                Id = 2,
                Name = "Breda",
                Address = "Chasséveld 15, 4811 DH Breda",
                Movies = new LocationMovie[0],
                Theaters = new Theater[0],
                Schedules = new Schedule[0]
            });
            
            #endregion
            
            #region Movie seeder
            
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 1,
                Title = "Interstellar",
                Description = "Earth's future has been riddled by disasters, famines, and droughts. There is only one way to ensure mankind's survival: Interstellar travel. A newly discovered wormhole in the far reaches of our solar system allows a team of astronauts to go where no man has gone before, a planet that may have the right environment to sustain human life.",
                Age = "PG-13",
                Director = "Christopher Nolan",
                Runtime = 169,
                Language = "EN",
                Genre = "Adventure,Drama,Sci-Fi",
                Rating = "",
                Img = "https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg"
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 1,
                MovieId = 1,
                LocationId = 1,
                Orders = new Order[0]
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 2,
                MovieId = 1,
                LocationId = 2,
                Orders = new Order[0]
            });
            
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 2,
                Title = "Inception",
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
                Age = "PG-13",
                Director = "Christopher Nolan",
                Runtime = 148,
                Language = "EN",
                Genre = "Action,Adventure,Sci-Fi,Thriller",
                Rating = "",
                Img = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg"
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 3,
                MovieId = 2,
                LocationId = 1,
                Orders = new Order[0]
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 4,
                MovieId = 2,
                LocationId = 2,
                Orders = new Order[0]
            });
            
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 3,
                Title = "Bohemian Rhapsody",
                Description = "The story of the legendary rock band Queen and lead singer Freddie Mercury, leading up to their famous performance at Live Aid (1985).",
                Age = "PG-13",
                Director = "Bryan Singer",
                Runtime = 134,
                Language = "EN",
                Genre = "Biography,Drama,Music",
                Rating = "",
                Img = "https://m.media-amazon.com/images/M/MV5BNDg2NjIxMDUyNF5BMl5BanBnXkFtZTgwMzEzNTE1NTM@._V1_SX300.jpg"
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 5,
                MovieId = 3,
                LocationId = 1,
                Orders = new Order[0]
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 6,
                MovieId = 3,
                LocationId = 2,
                Orders = new Order[0]
            });
            
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 4,
                Title = "The Judge",
                Description = "Hank Palmer is a successful defense attorney in Chicago, who is getting a divorce. When His brother calls with the news that their mother has died, Hank returns to his childhood home to attend the funeral. Despite the brittle bond between Hank and the Judge, Hank must come to his father's aid and defend him in court. Here, Hank discovers the truth behind the case, which binds together the dysfunctional family and reveals the struggles and secrecy of the family.",
                Age = "R",
                Director = "David Dobkin",
                Runtime = 141,
                Language = "EN",
                Genre = "Crime,Drama",
                Rating = "",
                Img = "https://m.media-amazon.com/images/M/MV5BMTcyNzIxOTIwMV5BMl5BanBnXkFtZTgwMzE0NjQwMjE@._V1_SX300.jpg"
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 7,
                MovieId = 4,
                LocationId = 1,
                Orders = new Order[0]
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 8,
                MovieId = 4,
                LocationId = 2,
                Orders = new Order[0]
            });
            
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 5,
                Title = "Harry Potter and the Deathly Hallows: Part 2",
                Description = "Harry, Ron, and Hermione continue their quest of finding and destroying the Dark Lord's three remaining Horcruxes, the magical items responsible for his immortality. But as the mystical Deathly Hallows are uncovered, and Voldemort finds out about their mission, the biggest battle begins and life as they know it will never be the same again.",
                Age = "PG-13",
                Director = "David Yates",
                Runtime = 130,
                Language = "EN",
                Genre = "Adventure,Drama,Fantasy,Mystery",
                Rating = "",
                Img = "https://m.media-amazon.com/images/M/MV5BMjIyZGU4YzUtNDkzYi00ZDRhLTljYzctYTMxMDQ4M2E0Y2YxXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg"
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 9,
                MovieId = 5,
                LocationId = 1,
                Orders = new Order[0]
            });
            
            modelBuilder.Entity<LocationMovie>().HasData(new LocationMovie
            {
                Id = 10,
                MovieId = 5,
                LocationId = 2,
                Orders = new Order[0]
            });
            
            #endregion
            
            #region Theater 1 seed

            modelBuilder.Entity<Theater>().HasData(new Theater
            {
                Id = 1,
                Name = "Zaal 1",
                Rows = new TheaterRow[0],
                Has3D = true,
                WheelchairAccessible = true,
                LocationId = 1
            });

            Dictionary<char, int> rowChairs = new Dictionary<char, int>();
            
            rowChairs.Add('A', 15);
            rowChairs.Add('B', 15);
            rowChairs.Add('C', 15);
            rowChairs.Add('D', 15);
            rowChairs.Add('E', 15);
            rowChairs.Add('F', 15);
            rowChairs.Add('G', 15);
            rowChairs.Add('H', 15);

            List<TheaterRow> theaterRows = new List<TheaterRow>();
            List<TheaterChair> theaterChairs = new List<TheaterChair>();
            
            int count = 1;
            int countRows = 1;
            
            foreach (KeyValuePair<char, int> row in rowChairs)
            {
                theaterRows.Add(new TheaterRow
                {
                    Id = count,
                    RowName = row.Key,
                    TheaterId = 1
                });
                
                for (int i = 1; i <= row.Value; i++)
                {
                    theaterChairs.Add(new TheaterChair
                    {
                        Id = countRows,
                        ChairNumber = i,
                        TheaterRowId = count
                    });
                    countRows++;
                }
                
                
                count++;
            }

            modelBuilder.Entity<TheaterRow>().HasData(theaterRows.ToArray());
            modelBuilder.Entity<TheaterChair>().HasData(theaterChairs.ToArray());

            #endregion
            
            #region Theater 2 seed

            modelBuilder.Entity<Theater>().HasData(new Theater
            {
                Id = 2,
                Name = "Zaal 2",
                Rows = new TheaterRow[0],
                Has3D = true,
                WheelchairAccessible = true,
                LocationId = 1
            });

            Dictionary<char, int> rowChairs1 = new Dictionary<char, int>();
            
            rowChairs1.Add('A', 15);
            rowChairs1.Add('B', 15);
            rowChairs1.Add('C', 15);
            rowChairs1.Add('D', 15);
            rowChairs1.Add('E', 15);
            rowChairs1.Add('F', 15);
            rowChairs1.Add('G', 15);
            rowChairs1.Add('H', 15);

            List<TheaterRow> theaterRows1 = new List<TheaterRow>();
            List<TheaterChair> theaterChairs1 = new List<TheaterChair>();
            
            foreach (KeyValuePair<char, int> row in rowChairs1)
            {
                theaterRows1.Add(new TheaterRow
                {
                    Id = count,
                    RowName = row.Key,
                    TheaterId = 2
                });
                
                for (int i = 1; i <= row.Value; i++)
                {
                    theaterChairs1.Add(new TheaterChair
                    {
                        Id = countRows,
                        ChairNumber = i,
                        TheaterRowId = count
                    });
                    countRows++;
                }
                count++;
            }

            modelBuilder.Entity<TheaterRow>().HasData(theaterRows1.ToArray());
            modelBuilder.Entity<TheaterChair>().HasData(theaterChairs1.ToArray());

            #endregion
            
            #region Theater 3 seed

            modelBuilder.Entity<Theater>().HasData(new Theater
            {
                Id = 3,
                Name = "Zaal 3",
                Rows = new TheaterRow[0],
                Has3D = false,
                WheelchairAccessible = true,
                LocationId = 1
            });

            Dictionary<char, int> rowChairs2 = new Dictionary<char, int>();
            
            rowChairs2.Add('A', 15);
            rowChairs2.Add('B', 15);
            rowChairs2.Add('C', 15);
            rowChairs2.Add('D', 15);
            rowChairs2.Add('E', 15);
            rowChairs2.Add('F', 15);
            rowChairs2.Add('G', 15);
            rowChairs2.Add('H', 15);

            List<TheaterRow> theaterRows2 = new List<TheaterRow>();
            List<TheaterChair> theaterChairs2 = new List<TheaterChair>();
            
            foreach (KeyValuePair<char, int> row in rowChairs2)
            {
                theaterRows2.Add(new TheaterRow
                {
                    Id = count,
                    RowName = row.Key,
                    TheaterId = 3
                });
                
                for (int i = 1; i <= row.Value; i++)
                {
                    theaterChairs2.Add(new TheaterChair
                    {
                        Id = countRows,
                        ChairNumber = i,
                        TheaterRowId = count
                    });
                    countRows++;
                }
                count++;
            }

            modelBuilder.Entity<TheaterRow>().HasData(theaterRows2.ToArray());
            modelBuilder.Entity<TheaterChair>().HasData(theaterChairs2.ToArray());

            #endregion
            
            #region Theater 4 seed

            modelBuilder.Entity<Theater>().HasData(new Theater
            {
                Id = 4,
                Name = "Zaal 4",
                Rows = new TheaterRow[0],
                Has3D = false,
                WheelchairAccessible = true,
                LocationId = 1
            });

            Dictionary<char, int> rowChairs3 = new Dictionary<char, int>();
            
            rowChairs3.Add('A', 10);
            rowChairs3.Add('B', 10);
            rowChairs3.Add('C', 10);
            rowChairs3.Add('D', 10);
            rowChairs3.Add('E', 10);
            rowChairs3.Add('F', 10);

            List<TheaterRow> theaterRows3 = new List<TheaterRow>();
            List<TheaterChair> theaterChairs3 = new List<TheaterChair>();
            
            foreach (KeyValuePair<char, int> row in rowChairs3)
            {
                theaterRows3.Add(new TheaterRow
                {
                    Id = count,
                    RowName = row.Key,
                    TheaterId = 4
                });
                
                for (int i = 1; i <= row.Value; i++)
                {
                    theaterChairs3.Add(new TheaterChair
                    {
                        Id = countRows,
                        ChairNumber = i,
                        TheaterRowId = count
                    });
                    countRows++;
                }
                count++;
            }

            modelBuilder.Entity<TheaterRow>().HasData(theaterRows3.ToArray());
            modelBuilder.Entity<TheaterChair>().HasData(theaterChairs3.ToArray());

            #endregion
            
            #region Theater 5 seed

            modelBuilder.Entity<Theater>().HasData(new Theater
            {
                Id = 5,
                Name = "Zaal 5",
                Rows = new TheaterRow[0],
                Has3D = false,
                WheelchairAccessible = false,
                LocationId = 1
            });

            Dictionary<char, int> rowChairs4 = new Dictionary<char, int>();
            
            rowChairs4.Add('A', 10);
            rowChairs4.Add('B', 10);
            rowChairs4.Add('C', 15);
            rowChairs4.Add('D', 15);

            List<TheaterRow> theaterRows4 = new List<TheaterRow>();
            List<TheaterChair> theaterChairs4 = new List<TheaterChair>();
            
            foreach (KeyValuePair<char, int> row in rowChairs4)
            {
                theaterRows4.Add(new TheaterRow
                {
                    Id = count,
                    RowName = row.Key,
                    TheaterId = 5
                });
                
                for (int i = 1; i <= row.Value; i++)
                {
                    theaterChairs4.Add(new TheaterChair
                    {
                        Id = countRows,
                        ChairNumber = i,
                        TheaterRowId = count
                    });
                    countRows++;
                }
                count++;
            }

            modelBuilder.Entity<TheaterRow>().HasData(theaterRows4.ToArray());
            modelBuilder.Entity<TheaterChair>().HasData(theaterChairs4.ToArray());

            #endregion
            
            #region Theater 6 seed

            modelBuilder.Entity<Theater>().HasData(new Theater
            {
                Id = 6,
                Name = "Zaal 6",
                Rows = new TheaterRow[0],
                Has3D = false,
                WheelchairAccessible = false,
                LocationId = 1
            });

            Dictionary<char, int> rowChairs5 = new Dictionary<char, int>();
            
            rowChairs5.Add('A', 10);
            rowChairs5.Add('B', 10);
            rowChairs5.Add('C', 15);
            rowChairs5.Add('D', 15);

            List<TheaterRow> theaterRows5 = new List<TheaterRow>();
            List<TheaterChair> theaterChairs5 = new List<TheaterChair>();
            
            foreach (KeyValuePair<char, int> row in rowChairs5)
            {
                theaterRows5.Add(new TheaterRow
                {
                    Id = count,
                    RowName = row.Key,
                    TheaterId = 6
                });
                
                for (int i = 1; i <= row.Value; i++)
                {
                    theaterChairs5.Add(new TheaterChair
                    {
                        Id = countRows,
                        ChairNumber = i,
                        TheaterRowId = count
                    });
                    countRows++;
                }
                count++;
            }

            modelBuilder.Entity<TheaterRow>().HasData(theaterRows5.ToArray());
            modelBuilder.Entity<TheaterChair>().HasData(theaterChairs5.ToArray());

            #endregion
        }
    }
}