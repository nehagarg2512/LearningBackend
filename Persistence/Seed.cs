﻿using Domain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Activities.Any())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Past Activity 1",
                        OnDate = DateTime.Now.AddMonths(-2),
                        Description = "Activity 2 months ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                    new Activity
                    {
                        Title = "Past Activity 2",
                        OnDate = DateTime.Now.AddMonths(-1),
                        Description = "Activity 1 month ago",
                        Category = "culture",
                        City = "Paris",
                        Venue = "Louvre",
                    },
                    new Activity
                    {
                        Title = "Future Activity 1",
                        OnDate = DateTime.Now.AddMonths(1),
                        Description = "Activity 1 month in future",
                        Category = "culture",
                        City = "London",
                        Venue = "Natural History Museum",
                    },
                    new Activity
                    {
                        Title = "Future Activity 2",
                        OnDate = DateTime.Now.AddMonths(2),
                        Description = "Activity 2 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "O2 Arena",
                    },
                    new Activity
                    {
                        Title = "Future Activity 3",
                        OnDate = DateTime.Now.AddMonths(3),
                        Description = "Activity 3 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 4",
                        OnDate = DateTime.Now.AddMonths(4),
                        Description = "Activity 4 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Yet another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 5",
                        OnDate = DateTime.Now.AddMonths(5),
                        Description = "Activity 5 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Just another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 6",
                        OnDate = DateTime.Now.AddMonths(6),
                        Description = "Activity 6 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "Roundhouse Camden",
                    },
                    new Activity
                    {
                        Title = "Future Activity 7",
                        OnDate = DateTime.Now.AddMonths(7),
                        Description = "Activity 2 months ago",
                        Category = "travel",
                        City = "London",
                        Venue = "Somewhere on the Thames",
                    },
                    new Activity
                    {
                        Title = "Future Activity 8",
                        OnDate = DateTime.Now.AddMonths(8),
                        Description = "Activity 8 months in future",
                        Category = "film",
                        City = "London",
                        Venue = "Cinema",
                    }
                };

                context.Activities.AddRange(activities);

                context.SaveChanges();
            }
        }
    }
}
