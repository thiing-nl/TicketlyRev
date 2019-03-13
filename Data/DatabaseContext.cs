using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using screend.Entities;
using screend.Entities.Movie;
using screend.Entities.Order;
using screend.Entities.Schedule;
using screend.Entities.Theater;

namespace screend.Data
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
        
        public DbSet<MovieTicket> MovieTickets { get; set; }
        
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
                        #region Theater 1 seed

            modelBuilder.Entity<Theater>().HasData(new Theater
            {
                Id = 1,
                Name = "Zaal 1",
                Rows = new TheaterRow[0],
                Has3D = true,
                WheelchairAccessible = true
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
                WheelchairAccessible = true
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
                WheelchairAccessible = true
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
                WheelchairAccessible = true
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
                WheelchairAccessible = false
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
                WheelchairAccessible = false
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