using GenericTech.ASPNETCoreWebApp.Entities;

namespace GenericTech.ASPNETCoreWebApp.Data;

public class ContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext dbContext, ILoggerFactory loggerFactory, int? retry = 0)
    {
        int retryForAvailability = retry.Value;

        try
        {
            // TODO: Only run this if using a real database
            // dbContext.Database.Migrate();
            // dbContext.Database.EnsureCreated();

            if (!dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(GetPreconfiguredCategories());
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Products.Any())
            {
                dbContext.Products.AddRange(GetPreconfiguredProducts());
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception exception)
        {
            if (retryForAvailability < 10)
            {
                retryForAvailability++;
                var log = loggerFactory.CreateLogger<ContextSeed>();
                log.LogError(exception.Message);
                await SeedAsync(dbContext, loggerFactory, retryForAvailability);
            }
            throw;
        }
    }

    private static IEnumerable<Category> GetPreconfiguredCategories()
    {
        return new List<Category>()
        {
            new Category()
            {
                Name = "White Appliances",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                ImageName = "one"
            },
            new Category()
            {
                Name = "Smart Watches",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                ImageName = "two"
            },
            new Category()
            {
                Name = "Home & Kitchen",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                ImageName = "tree"
            }
        };
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Name = "IPhone X",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-1.png",
                Price = 950.00M,
                CategoryId = 1
            },
            new Product()
            {
                Name = "Samsung 10",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-2.png",
                Price = 840.00M,
                CategoryId = 1
            },
            new Product()
            {
                Name = "Huawei Plus",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-3.png",
                Price = 650.00M,
                CategoryId = 2
            },
            new Product()
            {
                Name = "Xiaomi Mi 9",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-4.png",
                Price = 470.00M,
                CategoryId = 1
            },
            new Product()
            {
                Name = "HTC U11+ Plus",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-5.png",
                Price = 380.00M,
                CategoryId = 1
            },
            new Product()
            {
                Name = "LG G7 ThinQ",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-6.png",
                Price = 240.00M,
                CategoryId = 1
            }
        };
    }
}
