namespace DataLayer.Migrations
{
    using DataLayer.Utils;
    using DomainClasses;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.AgileScrumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataLayer.AgileScrumContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Backlogs.AddOrUpdate(new Backlog());

            //context.Products.AddOrUpdate(
            //    p => p.Name,
            //    new Product { Name = "Test Product" , BacklogId = 1}
            //    );

            //context.Sprints.AddOrUpdate(p => p.Name, new Sprint { 
            //    Name = "First Sprint",
            //    StartDate = DateTime.Now,
            //    EndDate = DateTime.Now
            //});

            context.Users.AddOrUpdate(
                u => u.Email,
                new User
                {
                    Email = "admin@admin.com",
                    Password = Hash.GetHash("admin", Hash.HashType.SHA512), //"d61d004c03457bac7b90c1e8d4f51113be162346b27af5307caffe21ef88597ff15ab1569e07155302ff7b0af29f7f0431531004568da3849a5708176815a70f", //admin
                    UserType = DomainClasses.Enums.UserType.Admin
                }
                );

            context.Users.AddOrUpdate(
                u => u.Email,
                new User
                {
                    Email = "nick@yahoo.com",
                    Password = Hash.GetHash("nick", Hash.HashType.SHA512), //"d61d004c03457bac7b90c1e8d4f51113be162346b27af5307caffe21ef88597ff15ab1569e07155302ff7b0af29f7f0431531004568da3849a5708176815a70f", //admin
                    UserType = DomainClasses.Enums.UserType.None
                }
                );

            context.Users.AddOrUpdate(
                u => u.Email,
                new User
                {
                    Email = "test@google.com",
                    Password = Hash.GetHash("test", Hash.HashType.SHA512), //"d61d004c03457bac7b90c1e8d4f51113be162346b27af5307caffe21ef88597ff15ab1569e07155302ff7b0af29f7f0431531004568da3849a5708176815a70f", //admin
                    UserType = DomainClasses.Enums.UserType.None
                }
                );

            context.Users.AddOrUpdate(
                u => u.Email,
                new User
                {
                    Email = "po2@google.com",
                    Password = Hash.GetHash("po2", Hash.HashType.SHA512), //"d61d004c03457bac7b90c1e8d4f51113be162346b27af5307caffe21ef88597ff15ab1569e07155302ff7b0af29f7f0431531004568da3849a5708176815a70f", //admin
                    UserType = DomainClasses.Enums.UserType.None
                }
                );

            context.Users.AddOrUpdate(
                u => u.Email,
                new User
                {
                    Email = "user@google.com",
                    Password = Hash.GetHash("user", Hash.HashType.SHA512), //"d61d004c03457bac7b90c1e8d4f51113be162346b27af5307caffe21ef88597ff15ab1569e07155302ff7b0af29f7f0431531004568da3849a5708176815a70f", //admin
                    UserType = DomainClasses.Enums.UserType.None
                }
                );

            context.Users.AddOrUpdate(
                u => u.Email,
                new User
                {
                    Email = "client@google.com",
                    Password = Hash.GetHash("client", Hash.HashType.SHA512), //"d61d004c03457bac7b90c1e8d4f51113be162346b27af5307caffe21ef88597ff15ab1569e07155302ff7b0af29f7f0431531004568da3849a5708176815a70f", //admin
                    UserType = DomainClasses.Enums.UserType.None
                }
                );

            //context.Tasks.AddOrUpdate(
            //   p => p.Title,
            //   new Task
            //   {
            //       Title = "Add validation to user info",
            //       Description = "Validate input from client",
            //       TaskPriority = DomainClasses.Enums.TaskPriority.P4,
            //       TaskStatus = DomainClasses.Enums.TaskStatus.Open,
            //       TaskType = DomainClasses.Enums.TaskType.Story,
            //       CreatedAt = DateTime.Now,
            //       EditedAt = DateTime.Now,
            //       EpicId = 3
            //   }
            //   );

            //context.Tasks.AddOrUpdate(
            //   p => p.Title,
            //   new Task
            //   {
            //       Title = "As an user, I want to be able to upload a profile photo",
            //       Description = "Add capability for adding photo and displaying it on user profile.",
            //       TaskPriority = DomainClasses.Enums.TaskPriority.P1,
            //       TaskStatus = DomainClasses.Enums.TaskStatus.Open,
            //       TaskType = DomainClasses.Enums.TaskType.Story,
            //       CreatedAt = DateTime.Now,
            //       EditedAt = DateTime.Now,
            //       EpicId = 3
            //   }
            //   );

            //context.Tasks.AddOrUpdate(
            //   p => p.Title,
            //   new Task
            //   {
            //       Title = "Broken layout on user profile page",
            //       Description = "Broken layout on user profile page",
            //       TaskPriority = DomainClasses.Enums.TaskPriority.P3,
            //       TaskStatus = DomainClasses.Enums.TaskStatus.Open,
            //       TaskType = DomainClasses.Enums.TaskType.Bug,
            //       CreatedAt = DateTime.Now,
            //       EditedAt = DateTime.Now,
            //       EpicId = 3
            //   }
            //   );

            //context.Tasks.AddOrUpdate(
            //   p => p.Title,
            //   new Task
            //   {
            //       Title = "Add new icon for the edit profile task",
            //       Description = "Add new icon for the edit profile task",
            //       TaskPriority = DomainClasses.Enums.TaskPriority.P4,
            //       TaskStatus = DomainClasses.Enums.TaskStatus.Open,
            //       TaskType = DomainClasses.Enums.TaskType.Improvement,
            //       CreatedAt = DateTime.Now,
            //       EditedAt = DateTime.Now,
            //       EpicId = 3
            //   }
            //   );

            //context.Tasks.AddOrUpdate(
            //   p => p.Title,
            //   new Task
            //   {
            //       Title = "As an admin, I want to be able to filter the sales history.",
            //       Description = "Broken layout on user profile page",
            //       TaskPriority = DomainClasses.Enums.TaskPriority.P3,
            //       TaskStatus = DomainClasses.Enums.TaskStatus.Open,
            //       TaskType = DomainClasses.Enums.TaskType.Story,
            //       CreatedAt = DateTime.Now,
            //       EditedAt = DateTime.Now,
            //       EpicId = 2
            //   }
            //   );

            //context.Tasks.AddOrUpdate(
            //  p => p.Title,
            //  new Task
            //  {
            //      Title = "As an user, I want to have the same layout for pages on all browsers.",
            //      Description = "As an user, I want to have the same layout for pages on all browsers",
            //      TaskPriority = DomainClasses.Enums.TaskPriority.P2,
            //      TaskStatus = DomainClasses.Enums.TaskStatus.Open,
            //      TaskType = DomainClasses.Enums.TaskType.Story,
            //      CreatedAt = DateTime.Now,
            //      EditedAt = DateTime.Now,
            //      EpicId = 1
            //  }
            //  );

            //#region Add sprint tasks

            //context.Tasks.AddOrUpdate(
            //  p => p.Title,
            //  new Task
            //  {
            //      Title = "Order create date is not regionalized.",
            //      Description = "The order create date has a hardcoded format, it is not regionalized",
            //      TaskPriority = DomainClasses.Enums.TaskPriority.P3,
            //      TaskStatus = DomainClasses.Enums.TaskStatus.Testing,
            //      TaskType = DomainClasses.Enums.TaskType.Bug,
            //      CreatedAt = DateTime.Now,
            //      EditedAt = DateTime.Now,
            //      SprintId = 1,
            //      StoryPoints = 1
            //  }
            //  );

            //context.Tasks.AddOrUpdate(
            //  p => p.Title,
            //  new Task
            //  {
            //      Title = "As an admin, I want to be able to see a graph representing daily sales",
            //      Description = "As an admin, I want to be able to see a graph representing daily sales",
            //      TaskPriority = DomainClasses.Enums.TaskPriority.P1,
            //      TaskStatus = DomainClasses.Enums.TaskStatus.Open,
            //      TaskType = DomainClasses.Enums.TaskType.Story,
            //      CreatedAt = DateTime.Now,
            //      EditedAt = DateTime.Now,
            //      SprintId = 1,
            //      StoryPoints = 3
            //  }
            //  );

            //context.Tasks.AddOrUpdate(
            //  p => p.Title,
            //  new Task
            //  {
            //      Title = "As an user, I want to be able to save an item to view later",
            //      Description = "Add option to save items and add a new page where users can see their saved items",
            //      TaskPriority = DomainClasses.Enums.TaskPriority.P1,
            //      TaskStatus = DomainClasses.Enums.TaskStatus.Development,
            //      TaskType = DomainClasses.Enums.TaskType.Story,
            //      CreatedAt = DateTime.Now,
            //      EditedAt = DateTime.Now,
            //      SprintId = 1,
            //      StoryPoints = 5
            //  }
            //  );

            //context.Tasks.AddOrUpdate(
            //  p => p.Title,
            //  new Task
            //  {
            //      Title = "As an user, I want to be notified when a product reaches a certain price",
            //      Description = "Add notifications to user profile when the items they want reach a certain price",
            //      TaskPriority = DomainClasses.Enums.TaskPriority.P2,
            //      TaskStatus = DomainClasses.Enums.TaskStatus.Open,
            //      TaskType = DomainClasses.Enums.TaskType.Story,
            //      CreatedAt = DateTime.Now,
            //      EditedAt = DateTime.Now,
            //      SprintId = 1,
            //      StoryPoints = 8
            //  }
            //  );

            //context.Tasks.AddOrUpdate(
            //  p => p.Title,
            //  new Task
            //  {
            //      Title = "As an admin, I want to be able to view logs through the app",
            //      Description = "Add page for admin displaying logs in a paged table.",
            //      TaskPriority = DomainClasses.Enums.TaskPriority.P2,
            //      TaskStatus = DomainClasses.Enums.TaskStatus.Closed,
            //      TaskType = DomainClasses.Enums.TaskType.Story,
            //      CreatedAt = DateTime.Now,
            //      EditedAt = DateTime.Now,
            //      SprintId = 1,
            //      StoryPoints = 2
            //  }
            //  );

            //#endregion

            //#region Add epics
            //context.Epics.AddOrUpdate(p => p.Name, new Epic
            //{
            //    Name = "Browser support",
            //    ColorAdnotation = "warning"
            //});

            //context.Epics.AddOrUpdate(p => p.Name, new Epic
            //{
            //    Name = "Management system",
            //    ColorAdnotation = "success"
            //});

            //context.Epics.AddOrUpdate(p => p.Name, new Epic
            //{
            //    Name = "User info",
            //    ColorAdnotation = "info"
            //});

            //#endregion
        }

       
    }
}
