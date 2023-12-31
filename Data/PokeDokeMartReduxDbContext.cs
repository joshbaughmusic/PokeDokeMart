using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PokeDokeMartRedux.Models;
using Microsoft.AspNetCore.Identity;

namespace PokeDokeMartRedux.Data;
public class PokeDokeMartReduxDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Move> Moves { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<DamageClass> DamageClasses { get; set; }
    public DbSet<PokeType> PokeTypes { get; set; }
    public DbSet<Pokemon> Pokemon { get; set; }
    public DbSet<PokemonLearnableMove> PokemonLearnableMoves { get; set; }
    public DbSet<PokemonType> PokemonTypes { get; set; }
    public DbSet<UserPokemon> UserPokemon { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<City> Cities { get; set; }

    public PokeDokeMartReduxDbContext(DbContextOptions<PokeDokeMartReduxDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "ash@pokenet.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Ash",
            LastName = "Ketchum",
            ProfilePictureUrl = "https://i.pinimg.com/474x/55/30/81/5530812c4d781a3c13cf47184ec3c0ec.jpg",
            Address = "101 Poke St",
            RegionId = 1,
            CityId = 89,
        });
        modelBuilder.Entity<Order>().HasData(new Order
        {
            Id = 1,
            Date = new DateTime(2023, 06, 28),
            UserProfileId = 1,
            FirstName = "Ash",
            LastName = "Ketchum",
            Address = "101 Poke St",
            RegionId = 1,
            CityId = 89,
        });

        modelBuilder.Entity<Region>().HasData(
            new Region
            {
                Id = 1,
                Name = "Kanto"
            },
            new Region
            {
                Id = 2,
                Name = "Johto"
            },
            new Region
            {
                Id = 3,
                Name = "Hoenn"
            },
            new Region
            {
                Id = 4,
                Name = "Sinnoh"
            },
            new Region
            {
                Id = 5,
                Name = "Unova"
            },
            new Region
            {
                Id = 6,
                Name = "Kalos"
            },
            new Region
            {
                Id = 7,
                Name = "Alola"
            },
            new Region
            {
                Id = 8,
                Name = "Galar"
            },
            new Region
            {
                Id = 9,
                Name = "Paldea"
            },
            new Region
            {
                Id = 10,
                Name = "Hisui"
            }
        );

        modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = 1,
                Name = "Accumula Town",
                RegionId = 5 // Unova
            },
    new City
    {
        Id = 2,
        Name = "Alfornada",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 3,
        Name = "Ambrette Town",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 4,
        Name = "Anistar City",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 5,
        Name = "Anville Town",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 6,
        Name = "Aquacorde Town",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 7,
        Name = "Artazon",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 8,
        Name = "Aspertia City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 9,
        Name = "Azalea Town",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 10,
        Name = "Ballonlea",
        RegionId = 8 // Galar
    },
    new City
    {
        Id = 11,
        Name = "Black City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 12,
        Name = "Blackthorn City",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 13,
        Name = "Cabo Poco",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 14,
        Name = "Camphrier Town",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 15,
        Name = "Canalave City",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 16,
        Name = "Cascarrafa",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 17,
        Name = "Castelia City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 18,
        Name = "Celadon City",
        RegionId = 1 // Kanto
    },
    new City
    {
        Id = 19,
        Name = "Celestic Town",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 20,
        Name = "Cerulean City",
        RegionId = 1 // Kanto
    },
    new City
    {
        Id = 21,
        Name = "Cherrygrove City",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 22,
        Name = "Cianwood City",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 23,
        Name = "Circhester",
        RegionId = 8 // Galar
    },
    new City
    {
        Id = 24,
        Name = "Cinnabar Island",
        RegionId = 1 // Kanto
    },
    new City
    {
        Id = 25,
        Name = "Cortondo",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 26,
        Name = "Coumarine City",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 27,
        Name = "Couriway Town",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 28,
        Name = "Cyllage City",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 29,
        Name = "Dendemille Town",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 30,
        Name = "Dewford Town",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 31,
        Name = "Diamond Settlement",
        RegionId = 10 // Hisui
    },
    new City
    {
        Id = 32,
        Name = "Driftveil City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 33,
        Name = "Ecruteak City",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 34,
        Name = "Eterna City",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 35,
        Name = "Ever Grande City",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 36,
        Name = "Fallarbor Town",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 37,
        Name = "Fight Area",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 38,
        Name = "Five Island",
        RegionId = 7 // Sevii Islands
    },
    new City
    {
        Id = 39,
        Name = "Floaroma Town",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 40,
        Name = "Floccesy Town",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 41,
        Name = "Fortree City",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 42,
        Name = "Four Island",
        RegionId = 7 // Sevii Islands
    },
    new City
    {
        Id = 43,
        Name = "Freezington",
        RegionId = 8 // Galar
    },
    new City
    {
        Id = 44,
        Name = "Frontier Access",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 45,
        Name = "Fuchsia City",
        RegionId = 1 // Kanto
    },
    new City
    {
        Id = 46,
        Name = "Geosenge Town",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 47,
        Name = "Goldenrod City",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 48,
        Name = "Hammerlocke",
        RegionId = 8 // Galar
    },
    new City
    {
        Id = 49,
        Name = "Hau'oli City",
        RegionId = 7 // Alola
    },
    new City
    {
        Id = 50,
        Name = "Heahea City",
        RegionId = 7 // Alola
    },
    new City
    {
        Id = 51,
        Name = "Hearthome City",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 52,
        Name = "Hulbury",
        RegionId = 8 // Galar
    },
    new City
    {
        Id = 53,
        Name = "Humilau City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 54,
        Name = "Icirrus City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 55,
        Name = "Iki Town",
        RegionId = 7 // Alola
    },
    new City
    {
        Id = 56,
        Name = "Jubilife City",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 57,
        Name = "Jubilife Village",
        RegionId = 10 // Hisui
    },
    new City
    {
        Id = 58,
        Name = "Kiloude City",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 59,
        Name = "Konikoni City",
        RegionId = 7 // Alola
    },
    new City
    {
        Id = 60,
        Name = "Lacunosa Town",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 61,
        Name = "Lavaridge Town",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 62,
        Name = "Lavender Town",
        RegionId = 1 // Kanto
    },
    new City
    {
        Id = 63,
        Name = "Laverre City",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 64,
        Name = "Lentimas Town",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 65,
        Name = "Levincia",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 66,
        Name = "Littleroot Town",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 67,
        Name = "Lilycove City",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 68,
        Name = "Los Platos",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 69,
        Name = "Lumiose City",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 70,
        Name = "Mahogany Town",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 71,
        Name = "Malie City",
        RegionId = 7 // Alola
    },
    new City
    {
        Id = 72,
        Name = "Mauville City",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 73,
        Name = "Medali",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 74,
        Name = "Mesagoza",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 75,
        Name = "Mistralton City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 76,
        Name = "Montenevera",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 77,
        Name = "Mossdeep City",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 78,
        Name = "Motostoke",
        RegionId = 8 // Galar
    },
    new City
    {
        Id = 79,
        Name = "Nacrene City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 80,
        Name = "New Bark Town",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 81,
        Name = "Nimbasa City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 82,
        Name = "Nuvema Town",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 83,
        Name = "Oldale Town",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 84,
        Name = "Olivine City",
        RegionId = 2 // Johto
    },
    new City
    {
        Id = 85,
        Name = "One Island",
        RegionId = 7 // Sevii Islands
    },
    new City
    {
        Id = 86,
        Name = "Opelucid City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 87,
        Name = "Oreburgh City",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 88,
        Name = "Pacifidlog Town",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 89,
        Name = "Pallet Town",
        RegionId = 1 // Kanto
    },
    new City
    {
        Id = 90,
        Name = "Paniola Town",
        RegionId = 7 // Alola
    },
    new City
    {
        Id = 91,
        Name = "Pastoria City",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 92,
        Name = "Pearl Settlement",
        RegionId = 10 // Hisui
    },
    new City
    {
        Id = 93,
        Name = "Pewter City",
        RegionId = 1 // Kanto
    },
    new City
    {
        Id = 94,
        Name = "Phenac City",
        RegionId = 7 // Orre
    },
    new City
    {
        Id = 95,
        Name = "Pompona",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 96,
        Name = "Prairie",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 97,
        Name = "Profanity",
        RegionId = 10 // Hisui
    },
    new City
    {
        Id = 98,
        Name = "Pueblo",
        RegionId = 10 // Hisui
    },
    new City
    {
        Id = 99,
        Name = "Pueblo Soledad",
        RegionId = 7 // Orre
    },
    new City
    {
        Id = 100,
        Name = "Punta Brigal",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 101,
        Name = "Punto Isla",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 102,
        Name = "Punta Sonorama",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 103,
        Name = "Quicksand Castle",
        RegionId = 10 // Hisui
    },
    new City
    {
        Id = 104,
        Name = "Raihon",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 105,
        Name = "Relic Town",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 106,
        Name = "Revive Town",
        RegionId = 10 // Hisui
    },
    new City
    {
        Id = 107,
        Name = "Rustboro City",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 108,
        Name = "Santalune City",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 109,
        Name = "Saraltar",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 110,
        Name = "Seafoam Islands",
        RegionId = 1 // Kanto
    },
    new City
    {
        Id = 111,
        Name = "Sootopolis City",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 112,
        Name = "Snowbelle City",
        RegionId = 6 // Kalos
    },
    new City
    {
        Id = 113,
        Name = "Solaceon Town",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 114,
        Name = "Spearmint",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 115,
        Name = "Slateport City",
        RegionId = 3 // Hoenn
    },
    new City
    {
        Id = 116,
        Name = "Snowpoint City",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 117,
        Name = "Snowy City",
        RegionId = 10 // Hisui
    },
    new City
    {
        Id = 118,
        Name = "Spikemuth",
        RegionId = 8 // Galar
    },
    new City
    {
        Id = 119,
        Name = "Spindle",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 120,
        Name = "Spikestown",
        RegionId = 10 // Hisui
    },
    new City
    {
        Id = 121,
        Name = "Stark Mountain",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 122,
        Name = "Striaton City",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 123,
        Name = "Sunyshore City",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 124,
        Name = "Tarroco",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 125,
        Name = "Tempo Tiempo",
        RegionId = 9 // Paldea
    },
    new City
    {
        Id = 126,
        Name = "Three Island",
        RegionId = 7 // Sevii Islands
    },
    new City
    {
        Id = 127,
        Name = "Twinleaf Town",
        RegionId = 4 // Sinnoh
    },
    new City
    {
        Id = 128,
        Name = "Undella Town",
        RegionId = 5 // Unova
    },
    new City
    {
        Id = 129,
        Name = "Vaniville Town",
        RegionId = 6 // Kalos
    },
        new City
        {
            Id = 130,
            Name = "Veilstone City",
            RegionId = 4 // Sinnoh
        },
        new City
        {
            Id = 131,
            Name = "Verdanturf Town",
            RegionId = 3 // Hoenn
        },
        new City
        {
            Id = 132,
            Name = "Vermilion City",
            RegionId = 1 // Kanto
        },
        new City
        {
            Id = 133,
            Name = "Violet City",
            RegionId = 2 // Johto
        },
        new City
        {
            Id = 134,
            Name = "Virbank City",
            RegionId = 5 // Unova
        },
        new City
        {
            Id = 135,
            Name = "Viridian City",
            RegionId = 1 // Kanto
        },
        new City
        {
            Id = 136,
            Name = "Wedgehurst",
            RegionId = 8 // Galar
        },
        new City
        {
            Id = 137,
            Name = "White Forest",
            RegionId = 5 // Unova
        },
        new City
        {
            Id = 138,
            Name = "Wyndon",
            RegionId = 8 // Galar
        },
        new City
        {
            Id = 139,
            Name = "Zapapico",
            RegionId = 9 // Paldea
        }

        );

        modelBuilder.Entity<OrderItem>().HasData(new OrderItem
        {
            Id = 1,
            OrderId = 1,
            ItemId = 1,
            Quantity = 3,

        },
       new OrderItem
       {
           Id = 2,
           OrderId = 1,
           ItemId = 3,
           Quantity = 2,

       });

        modelBuilder.Entity<Review>().HasData(new Review
        {
            Id = 1,
            UserProfileId = 1,
            ItemId = 1,
            Rating = 4,
            Body = "It's great!",
            Date = new DateTime(2023, 06, 28),

        },
        new Review
        {
            Id = 2,
            UserProfileId = 1,
            ItemId = 3,
            Rating = 3,
            Body = "It's good!",
            Date = new DateTime(2023, 06, 28),
        });

        modelBuilder.Entity<UserPokemon>().HasData(new UserPokemon
        {
            Id = 1,
            NickName = "LeeroyJenkins",
            UserProfileId = 1,
            PokemonId = 6,
            Level = 40,
        },
        new UserPokemon
        {
            Id = 2,
            NickName = "Bobert",
            UserProfileId = 1,
            PokemonId = 26,
            Level = 30,
        });

        modelBuilder.Entity<PokeType>().HasData(new PokeType[]
      {
        new PokeType
        {
            Id = 1,
            Name = "Normal",
        },
        new PokeType
        {
            Id = 2,
            Name = "Fighting",
        },
        new PokeType
        {
            Id = 3,
            Name = "Flying",
        },
        new PokeType
        {
            Id = 4,
            Name = "Poison",
        },
        new PokeType
        {
            Id = 5,
            Name = "Ground",
        },
        new PokeType
        {
            Id = 6,
            Name = "Rock",
        },
        new PokeType
        {
            Id = 7,
            Name = "Bug",
        },
        new PokeType
        {
            Id = 8,
            Name = "Ghost",
        },
        new PokeType
        {
            Id = 9,
            Name = "Steel",
        },
        new PokeType
        {
            Id = 10,
            Name = "Fire",
        },
        new PokeType
        {
            Id = 11,
            Name = "Water",
        },
        new PokeType
        {
            Id = 12,
            Name = "Grass",
        },
        new PokeType
        {
            Id = 13,
            Name = "Electric",
        },
        new PokeType
        {
            Id = 14,
            Name = "Psychic",
        },
        new PokeType
        {
            Id = 15,
            Name = "Ice",
        },
        new PokeType
        {
            Id = 16,
            Name = "Dragon",
        },
        new PokeType
        {
            Id = 17,
            Name = "Dark",
        },
        new PokeType
        {
            Id = 18,
            Name = "Fairy",
        },
        new PokeType
        {
            Id = 19,
            Name = "Unknown",
        },
        new PokeType
        {
            Id = 20,
            Name = "Shadow",
        },

      }
      );
        modelBuilder.Entity<Category>().HasData(new Category[]
       {
        new Category
        {
            Id = 1,
            Name = "Standard Poke Balls",
        },
        new Category
        {
            Id = 2,
            Name = "Special Poke Balls",
        },
        new Category
        {
            Id = 3,
            Name = "Healing Items",
        },
        new Category
        {
            Id = 4,
            Name = "Status Cure Items",
        },
        new Category
        {
            Id = 5,
            Name = "Revial Items",
        },
        new Category
        {
            Id = 6,
            Name = "PP-Recovery Items",
        },
        new Category
        {
            Id = 7,
            Name = "Vitamins",
        },
        new Category
        {
            Id = 8,
            Name = "Stat-Boost Items",
        },
        new Category
        {
            Id = 9,
            Name = "Evolution Items",
        },
        new Category
        {
            Id = 10,
            Name = "Adventuring Items",
        },
        new Category
        {
            Id = 11,
            Name = "TMs",
        },
        new Category
        {
            Id = 12,
            Name = "Berries",
        }

       }
       );
        modelBuilder.Entity<DamageClass>().HasData(new DamageClass[]
       {
        new DamageClass
        {
            Id = 1,
            Name = "Status",
        },
        new DamageClass
        {
            Id = 2,
            Name = "Physical",
        },
        new DamageClass
        {
            Id = 3,
            Name = "Special",
        }
       }
       );

        modelBuilder.Entity<Item>().HasData(
    new Item
    {
        Id = 1,
        Name = "Ultra Ball",
        Cost = 800,
        Effect = "Used in battle: Attempts to catch a wild Pokémon, using a catch rate of 2×. If used in a trainer battle, nothing happens and the ball is lost.",
        ShortEffect = "Tries to catch a wild Pokémon. Success rate is 2×.",
        Description = "An ultra-high-performance Poké Ball that provides a higher success rate for catching Pokémon than a Great Ball.",
        MoveId = null,
        CategoryId = 1,
        Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/ultra-ball.png",
    },
new Item
{
    Id = 2,
    Name = "Great Ball",
    Cost = 600,
    Effect = "Used in battle: Attempts to catch a wild Pokémon, using a catch rate of 1.5×. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Success rate is 1.5×.",
    Description = "A good, high-performance Poké Ball that provides a higher success rate for catching Pokémon than a standard Poké Ball.",
    MoveId = null,
    CategoryId = 1,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/great-ball.png",
},
new Item
{
    Id = 3,
    Name = "Poké Ball",
    Cost = 200,
    Effect = "Used in battle: Attempts to catch a wild Pokémon, using a catch rate of 1×. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon.",
    Description = "A device for catching wild Pokémon. It’s thrown like a ball at a Pokémon, comfortably encapsulating its target.",
    MoveId = null,
    CategoryId = 1,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/poke-ball.png",
},
new Item
{
    Id = 4,
    Name = "Net Ball",
    Cost = 1000,
    Effect = "Used in battle: Attempts to catch a wild Pokémon. If the wild Pokémon is water- or bug-type, this ball has a catch rate of 3×. Otherwise, it has a catch rate of 1×. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Success rate is 3× for water and bug Pokémon.",
    Description = "A somewhat different Poké Ball that is more effective when attempting to catch Water- or Bug-type Pokémon.",
    MoveId = null,
    CategoryId = 2,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/net-ball.png",
},
new Item
{
    Id = 5,
    Name = "Dive Ball",
    Cost = 1000,
    Effect = "Used in battle: Attempts to catch a wild Pokémon. If the wild Pokémon was encountered by surfing or fishing, this ball has a catch rate of 3.5×. Otherwise, it has a catch rate of 1×. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Success rate is 3.5× when underwater, fishing, or surfing.",
    Description = "A somewhat different Poké Ball that works especially well when catching Pokémon that live underwater.",
    MoveId = null,
    CategoryId = 2,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/dive-ball.png",
},
new Item
{
    Id = 6,
    Name = "Nest Ball",
    Cost = 1000,
    Effect = "Used in battle: Attempts to catch a wild Pokémon. Has a catch rate given by `(40 - level) / 10`, where `level` is the wild Pokémon's level, to a maximum of 3.9× for level 1 Pokémon. If the wild Pokémon's level is higher than 30, this ball has a catch rate of 1×. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Success rate is 3.9× for level 1 Pokémon, and drops steadily to 1× at level 30.",
    Description = "A somewhat different Poké Ball that becomes more effective the lower the level of the wild Pokémon.",
    MoveId = null,
    CategoryId = 2,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/nest-ball.png",
},
new Item
{
    Id = 7,
    Name = "Repeat Ball",
    Cost = 1000,
    Effect = "Used in battle: Attempts to catch a wild Pokémon. If the wild Pokémon's species is marked as caught in the trainer's Pokédex, this ball has a catch rate of 3×. Otherwise, it has a catch rate of 1×. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Success rate is 3× for previously-caught Pokémon.",
    Description = "A somewhat different Poké Ball that works especially well on a Pokémon species that has been caught before.",
    MoveId = null,
    CategoryId = 2,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/repeat-ball.png",
},
new Item
{
    Id = 8,
    Name = "Timer Ball",
    Cost = 1000,
    Effect = "Used in battle: Attempts to catch a wild Pokémon. Has a catch rate of 1.1× on the first turn of the battle and increases by 0.1× every turn, to a maximum of 4× on turn 30. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Success rate increases by 0.1× (Gen V: 0.3×) every turn, to a max of 4×.",
    Description = "A somewhat different Poké Ball that becomes progressively more effective at catching Pokémon the more turns that are taken in battle.",
    MoveId = null,
    CategoryId = 2,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/timer-ball.png",
},
new Item
{
    Id = 9,
    Name = "Luxury Ball",
    Cost = 3000,
    Effect = "Used in battle: Attempts to catch a wild Pokémon, using a catch rate of 1×. Whenever the caught Pokémon's happiness increases, it increases by one extra point. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Caught Pokémon start with 200 happiness.",
    Description = "A particularly comfortable Poké Ball that makes a wild Pokémon quickly grow friendlier after being caught.",
    MoveId = null,
    CategoryId = 2,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/luxury-ball.png",
},
new Item
{
    Id = 10,
    Name = "Premier Ball",
    Cost = 2000,
    Effect = "Used in battle: Attempts to catch a wild Pokémon, using a catch rate of 1×. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon.",
    Description = "A somewhat rare Poké Ball that was made as a commemorative item used to celebrate an event of some sort.",
    MoveId = null,
    CategoryId = 2,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/premier-ball.png",
},
new Item
{
    Id = 11,
    Name = "Dusk Ball",
    Cost = 1000,
    Effect = "Used in battle: Attempts to catch a wild Pokémon. If it's currently nighttime or the wild Pokémon was encountered while walking in a cave, this ball has a catch rate of 3.5×. Otherwise, it has a catch rate of 1×. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Success rate is 3.5× at night and in caves.",
    Description = "A somewhat different Poké Ball that makes it easier to catch wild Pokémon at night or in dark places such as caves.",
    MoveId = null,
    CategoryId = 2,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/dusk-ball.png",
},
new Item
{
    Id = 12,
    Name = "Heal Ball",
    Cost = 300,
    Effect = "Used in battle: Attempts to catch a wild Pokémon, using a catch rate of 1×. The caught Pokémon's HP is immediately restored, PP for all its moves is restored, and any status ailment is cured. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Caught Pokémon are immediately healed.",
    Description = "A remedial Poké Ball that restores the HP of a Pokémon caught with it and eliminates any status conditions.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/heal-ball.png",
},
new Item
{
    Id = 13,
    Name = "Quick Ball",
    Cost = 1000,
    Effect = "Used in battle: Attempts to catch a wild Pokémon, using a catch rate of 4× on the first turn of a battle, but 1× any other time. If used in a trainer battle, nothing happens and the ball is lost.",
    ShortEffect = "Tries to catch a wild Pokémon. Success rate is 4× (Gen V: 5×), but only on the first turn.",
    Description = "A somewhat different Poké Ball that has a more successful catch rate if used at the start of a wild encounter.",
    MoveId = null,
    CategoryId = 2,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/quick-ball.png",
},
new Item
{
    Id = 14,
    Name = "Potion",
    Cost = 200,
    Effect = "Used on a friendly Pokémon: Restores 20 HP.",
    ShortEffect = "Restores 20 HP.",
    Description = "A spray-type medicine for treating wounds. It can be used to restore 20 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/potion.png",
},
new Item
{
    Id = 15,
    Name = "Antidote",
    Cost = 200,
    Effect = "Used on a party Pokémon: Cures poison.",
    ShortEffect = "Cures poison.",
    Description = "A spray-type medicine for treating poisoning. It can be used to lift the effects of being poisoned from a single Pokémon.",
    MoveId = null,
    CategoryId = 4,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/antidote.png",
},
new Item
{
    Id = 16,
    Name = "Burn Heal",
    Cost = 200,
    Effect = "Used on a party Pokémon: Cures a burn.",
    ShortEffect = "Cures a burn.",
    Description = "A spray-type medicine for treating burns. It can be used to heal a single Pokémon suffering from a burn.",
    MoveId = null,
    CategoryId = 4,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/burn-heal.png",
},
new Item
{
    Id = 17,
    Name = "Ice Heal",
    Cost = 200,
    Effect = "Used on a party Pokémon: Cures freezing.",
    ShortEffect = "Cures freezing.",
    Description = "A spray-type medicine for treating freezing. It can be used to thaw out a single Pokémon that has been frozen solid.",
    MoveId = null,
    CategoryId = 4,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/ice-heal.png",
},
new Item
{
    Id = 18,
    Name = "Awakening",
    Cost = 200,
    Effect = "Used on a party Pokémon: Cures sleep.",
    ShortEffect = "Cures sleep.",
    Description = "A spray-type medicine to wake the sleeping. It can be used to rouse a single Pokémon from the clutches of sleep.",
    MoveId = null,
    CategoryId = 4,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/awakening.png",
},
new Item
{
    Id = 19,
    Name = "Paralyze Heal",
    Cost = 200,
    Effect = "Used on a party Pokémon: Cures paralysis.",
    ShortEffect = "Cures paralysis.",
    Description = "A spray-type medicine for treating paralysis. It can be used to free a single Pokémon that has been paralyzed.",
    MoveId = null,
    CategoryId = 4,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/paralyze-heal.png",
},
new Item
{
    Id = 20,
    Name = "Full Restore",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Restores HP to full and cures any status ailment and confusion.",
    ShortEffect = "Restores HP to full and cures any status ailment and confusion.",
    Description = "A medicine that can be used to fully restore the HP of a single Pokémon and heal any status conditions it has.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/full-restore.png",
},
new Item
{
    Id = 21,
    Name = "Max Potion",
    Cost = 2500,
    Effect = "Used on a party Pokémon: Restores HP to full.",
    ShortEffect = "Restores HP to full.",
    Description = "A spray-type medicine for treating wounds. It can be used to completely restore the max HP of a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/max-potion.png",
},
new Item
{
    Id = 22,
    Name = "Hyper Potion",
    Cost = 1500,
    Effect = "Used on a party Pokémon: Restores 200 HP.",
    ShortEffect = "Restores 200 HP.",
    Description = "A spray-type medicine for treating wounds. It can be used to restore 200 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/hyper-potion.png",
},
new Item
{
    Id = 23,
    Name = "Super Potion",
    Cost = 700,
    Effect = "Used on a party Pokémon: Restores 50 HP.",
    ShortEffect = "Restores 50 HP.",
    Description = "A spray-type medicine for treating wounds. It can be used to restore 50 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/super-potion.png",
},
new Item
{
    Id = 24,
    Name = "Full Heal",
    Cost = 400,
    Effect = "Used on a party Pokémon: Cures any status ailment and confusion.",
    ShortEffect = "Cures any status ailment and confusion.",
    Description = "A spray-type medicine that is broadly effective. It can be used to heal all the status conditions of a single Pokémon.",
    MoveId = null,
    CategoryId = 4,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/full-heal.png",
},
new Item
{
    Id = 25,
    Name = "Revive",
    Cost = 2000,
    Effect = "Used on a party Pokémon: Revives the Pokémon and restores half its HP.",
    ShortEffect = "Revives with half HP.",
    Description = "A medicine that can be used to revive a single Pokémon that has fainted. It also restores half of the Pokémon’s max HP.",
    MoveId = null,
    CategoryId = 5,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/revive.png",
},
new Item
{
    Id = 26,
    Name = "Max Revive",
    Cost = 4000,
    Effect = "Used on a party Pokémon: Revives the Pokémon and restores its HP to full.",
    ShortEffect = "Revives with full HP.",
    Description = "A medicine that can be used to revive a single Pokémon that has fainted. It also fully restores the Pokémon’s max HP.",
    MoveId = null,
    CategoryId = 5,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/max-revive.png",
},
new Item
{
    Id = 27,
    Name = "Fresh Water",
    Cost = 200,
    Effect = "Used on a party Pokémon: Restores 50 HP.",
    ShortEffect = "Restores 50 HP.",
    Description = "Water with high mineral content. It can be used to restore 50 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/fresh-water.png",
},
new Item
{
    Id = 28,
    Name = "Soda Pop",
    Cost = 300,
    Effect = "Used on a party Pokémon: Restores 60 HP.",
    ShortEffect = "Restores 60 HP.",
    Description = "A highly carbonated soda drink. It can be used to restore 60 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/soda-pop.png",
},
new Item
{
    Id = 29,
    Name = "Lemonade",
    Cost = 400,
    Effect = "Used on a party Pokémon: Restores 80 HP.",
    ShortEffect = "Restores 80 HP.",
    Description = "A very sweet and refreshing drink. It can be used to restore 80 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/lemonade.png",
},
new Item
{
    Id = 30,
    Name = "Moomoo Milk",
    Cost = 600,
    Effect = "Used on a party Pokémon: Restores 100 HP.",
    ShortEffect = "Restores 100 HP.",
    Description = "A bottle of highly nutritious milk. It can be used to restore 100 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/moomoo-milk.png",
},
new Item
{
    Id = 31,
    Name = "Energy Powder",
    Cost = 500,
    Effect = "Used on a party Pokémon: Restores 50 HP. Decreases happiness by 5/5/10.",
    ShortEffect = "Restores 50 HP, but lowers happiness.",
    Description = "A very bitter medicinal powder. It can be used to restore 50 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/energy-powder.png",
},
new Item
{
    Id = 32,
    Name = "Energy Root",
    Cost = 1200,
    Effect = "Used on a party Pokémon: Restores 200 HP. Decreases happiness by 10/10/15.",
    ShortEffect = "Restores 200 HP, but lowers happiness.",
    Description = "An extremely bitter medicinal root. It can be used to restore 200 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/energy-root.png",
},
new Item
{
    Id = 33,
    Name = "Heal Powder",
    Cost = 300,
    Effect = "Used on a party Pokémon: Cures any status ailment. Decreases happiness by 5/5/10.",
    ShortEffect = "Cures any status ailment, but lowers happiness.",
    Description = "A very bitter medicinal powder. It can be used once to heal all the status conditions of a Pokémon.",
    MoveId = null,
    CategoryId = 4,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/heal-powder.png",
},
new Item
{
    Id = 34,
    Name = "Revival Herb",
    Cost = 2800,
    Effect = "Used on a party Pokémon: Revives a fainted Pokémon and restores its HP to full. Decreases happiness by 10/10/15.",
    ShortEffect = "Revives with full HP, but lowers happiness.",
    Description = "A terribly bitter medicinal herb. It revives a fainted Pokémon and fully restores its max HP.",
    MoveId = null,
    CategoryId = 5,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/revival-herb.png",
},
new Item
{
    Id = 35,
    Name = "Ether",
    Cost = 1200,
    Effect = "Used on a party Pokémon: Restores 10 PP for a selected move.",
    ShortEffect = "Restores 10 PP for one move.",
    Description = "This medicine can be used to restore 10 PP to a single selected move that has been learned by a Pokémon.",
    MoveId = null,
    CategoryId = 6,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/ether.png",
},
new Item
{
    Id = 36,
    Name = "Max Ether",
    Cost = 2000,
    Effect = "Used on a party Pokémon: Restores PP to full for a selected move.",
    ShortEffect = "Restores PP to full for one move.",
    Description = "This medicine can be used to fully restore the PP of a single selected move that has been learned by a Pokémon.",
    MoveId = null,
    CategoryId = 6,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/max-ether.png",
},
new Item
{
    Id = 37,
    Name = "Elixir",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Restores 10 PP for each move.",
    ShortEffect = "Restores 10 PP for each move.",
    Description = "This medicine can be used to restore 10 PP to each of the moves that have been learned by a Pokémon.",
    MoveId = null,
    CategoryId = 6,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/elixir.png",
},
new Item
{
    Id = 38,
    Name = "Max Elixir",
    Cost = 4500,
    Effect = "Used on a party Pokémon: Restores PP to full for each move.",
    ShortEffect = "Restores PP to full for each move.",
    Description = "This medicine can be used to fully restore the PP of all of the moves that have been learned by a Pokémon.",
    MoveId = null,
    CategoryId = 6,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/max-elixir.png",
},
new Item
{
    Id = 39,
    Name = "Lava Cookie",
    Cost = 350,
    Effect = "Used on a party Pokémon: Cures any status ailment and confusion.",
    ShortEffect = "Cures any status ailment and confusion.",
    Description = "Lavaridge Town’s local specialty. It can be used once to heal all the status conditions of a Pokémon.",
    MoveId = null,
    CategoryId = 4,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/lava-cookie.png",
},
new Item
{
    Id = 40,
    Name = "Berry Juice",
    Cost = 200,
    Effect = "Used on a party Pokémon: Restores 20 HP.",
    ShortEffect = "Restores 20 HP.",
    Description = "A 100 percent pure juice made of Berries. It can be used to restore 20 HP to a single Pokémon.",
    MoveId = null,
    CategoryId = 3,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/berry-juice.png",
},
new Item
{
    Id = 41,
    Name = "Sacred Ash",
    Cost = 50000,
    Effect = "Used on a party Pokémon: Revives all fainted Pokémon in the party and restores their HP to full.",
    ShortEffect = "Revives all fainted Pokémon with full HP.",
    Description = "This rare ash can revive all fainted Pokémon in a party. In doing so, it also fully restores their max HP.",
    MoveId = null,
    CategoryId = 5,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/sacred-ash.png",
},
new Item
{
    Id = 42,
    Name = "HP Up",
    Cost = 10000,
    Effect = "Used on a party Pokémon: Increases HP effort by 10, but won't increase it beyond 100. Increases happiness by 5/3/2.",
    ShortEffect = "Raises HP effort and happiness.",
    Description = "A nutritious drink for Pokémon. When consumed, it raises the HP base points of a single Pokémon.",
    MoveId = null,
    CategoryId = 7,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/hp-up.png",
},
new Item
{
    Id = 43,
    Name = "Protein",
    Cost = 10000,
    Effect = "Used on a party Pokémon: Increases Attack effort by 10, but won't increase it beyond 100. Increases happiness by 5/3/2.",
    ShortEffect = "Raises Attack effort and happiness.",
    Description = "A nutritious drink for Pokémon. When consumed, it raises the Attack base points of a single Pokémon.",
    MoveId = null,
    CategoryId = 7,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/protein.png",
},
new Item
{
    Id = 44,
    Name = "Iron",
    Cost = 10000,
    Effect = "Used on a party Pokémon: Increases Defense effort by 10, but won't increase it beyond 100. Increases happiness by 5/3/2.",
    ShortEffect = "Raises Defense effort and happiness.",
    Description = "A nutritious drink for Pokémon. When consumed, it raises the Defense base points of a single Pokémon.",
    MoveId = null,
    CategoryId = 7,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/iron.png",
},
new Item
{
    Id = 45,
    Name = "Carbos",
    Cost = 10000,
    Effect = "Used on a party Pokémon: Increases Speed effort by 10, but won't increase it beyond 100. Increases happiness by 5/3/2.",
    ShortEffect = "Raises Speed effort and happiness.",
    Description = "A nutritious drink for Pokémon. When consumed, it raises the Speed base points of a single Pokémon.",
    MoveId = null,
    CategoryId = 7,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/carbos.png",
},
new Item
{
    Id = 46,
    Name = "Calcium",
    Cost = 10000,
    Effect = "Used on a party Pokémon: Increases Special Attack effort by 10, but won't increase it beyond 100. Increases happiness by 5/3/2.",
    ShortEffect = "Raises Special Attack effort and happiness.",
    Description = "A nutritious drink for Pokémon. When consumed, it raises the Sp. Atk base points of a single Pokémon.",
    MoveId = null,
    CategoryId = 7,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/calcium.png",
},
new Item
{
    Id = 47,
    Name = "Rare Candy",
    Cost = 10000,
    Effect = "Used on a party Pokémon: Increases level by 1. Increases happiness by 5/3/2.",
    ShortEffect = "Causes a level-up and raises happiness.",
    Description = "A candy that is packed with energy. When consumed, it will instantly raise the level of a single Pokémon by one.",
    MoveId = null,
    CategoryId = 7,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/rare-candy.png",
},
new Item
{
    Id = 48,
    Name = "PP Up",
    Cost = 10000,
    Effect = "Used on a party Pokémon: Increases a selected move's max PP by 20% its original max PP, to a maximum of 1.6×. Increases happiness by 5/3/2.",
    ShortEffect = "Raises a move's max PP by 20%.",
    Description = "A medicine that slightly raises the max PP of a single selected move that has been learned by a Pokémon.",
    MoveId = null,
    CategoryId = 7,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/pp-up.png",
},
new Item
{
    Id = 49,
    Name = "Zinc",
    Cost = 10000,
    Effect = "Used on a party Pokémon: Increases Special Defense effort by 10, but won't increase it beyond 100. Increases happiness by 5/3/2.",
    ShortEffect = "Raises Special Defense and happiness.",
    Description = "A nutritious drink for Pokémon. When consumed, it raises the Sp. Def base points of a single Pokémon.",
    MoveId = null,
    CategoryId = 7,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/zinc.png",
},
new Item
{
    Id = 50,
    Name = "PP Max",
    Cost = 10000,
    Effect = "Used on a party Pokémon: Increases a selected move's max PP to 1.6× its original max PP. Increases happiness by 5/3/2.",
    ShortEffect = "Raises a move's max PP by 60%.",
    Description = "A medicine that optimally raises the max PP of a single selected move that has been learned by a Pokémon.",
    MoveId = null,
    CategoryId = 7,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/pp-max.png",
},
new Item
{
    Id = 51,
    Name = "Old Gateau",
    Cost = 350,
    Effect = "Used on a party Pokémon: Cures any status ailment and confusion.",
    ShortEffect = "Cures any status ailment and confusion.",
    Description = "The Old Chateau’s hidden specialty. It can be used once to heal all the status conditions of a Pokémon.",
    MoveId = null,
    CategoryId = 4,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/old-gateau.png",
},
new Item
{
    Id = 52,
    Name = "Guard Spec.",
    Cost = 1500,
    Effect = "Used on a party Pokémon in battle: Protects the target's stats from being lowered for the next five turns. Increases happiness by 1/1/0.",
    ShortEffect = "Prevents stat changes in battle for five turns in battle. Raises happiness.",
    Description = "An item that prevents stat reduction among the Trainer’s party Pokémon for five turns after it is used in battle.",
    MoveId = null,
    CategoryId = 8,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/guard-spec.png",
},
new Item
{
    Id = 53,
    Name = "Dire Hit",
    Cost = 1000,
    Effect = "Used on a party Pokémon in battle: Increases the target's critical hit chance by one stage until it leaves the field. Increases happiness by 1/1/0.",
    ShortEffect = "Increases the chance of a critical hit in battle. Raises happiness.",
    Description = "An item that greatly raises the critical-hit ratio of a Pokémon during a battle. It can be used only once and wears off if the Pokémon is withdrawn.",
    MoveId = null,
    CategoryId = 8,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/dire-hit.png",
},
new Item
{
    Id = 54,
    Name = "X Attack",
    Cost = 1000,
    Effect = "Used on a party Pokémon in battle: Raises the target's Attack by one stage. Increases happiness by 1/1/0.",
    ShortEffect = "Raises Attack by one stage in battle. Raises happiness.",
    Description = "An item that sharply boosts the Attack stat of a Pokémon during a battle. It wears off once the Pokémon is withdrawn.",
    MoveId = null,
    CategoryId = 8,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/x-attack.png",
},
new Item
{
    Id = 55,
    Name = "X Defense",
    Cost = 2000,
    Effect = "Used on a party Pokémon in battle: Raises the target's Defense by one stage. Increases happiness by 1/1/0.",
    ShortEffect = "Raises Defense by one stage in battle. Raises happiness.",
    Description = "An item that sharply boosts the Defense stat of a Pokémon during a battle. It wears off once the Pokémon is withdrawn.",
    MoveId = null,
    CategoryId = 8,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/x-defense.png",
},
new Item
{
    Id = 56,
    Name = "X Speed",
    Cost = 1000,
    Effect = "Used on a party Pokémon in battle: Raises the target's Speed by one stage. Increases happiness by 1/1/0.",
    ShortEffect = "Raises Speed by one stage in battle. Raises happiness.",
    Description = "An item that sharply boosts the Speed stat of a Pokémon during a battle. It wears off once the Pokémon is withdrawn.",
    MoveId = null,
    CategoryId = 8,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/x-speed.png",
},
new Item
{
    Id = 57,
    Name = "X Accuracy",
    Cost = 1000,
    Effect = "Used on a party Pokémon in battle: Raises the target's accuracy by one stage. Increases happiness by 1/1/0.",
    ShortEffect = "Raises accuracy by one stage in battle. Raises happiness.",
    Description = "An item that sharply boosts the accuracy of a Pokémon during a battle. It wears off once the Pokémon is withdrawn.",
    MoveId = null,
    CategoryId = 8,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/x-accuracy.png",
},
new Item
{
    Id = 58,
    Name = "X Sp. Atk",
    Cost = 1000,
    Effect = "Used on a party Pokémon in battle: Raises the target's Special Attack by one stage. Increases happiness by 1/1/0.",
    ShortEffect = "Raises Special Attack by one stage in battle. Raises happiness.",
    Description = "An item that sharply boosts the Sp. Atk stat of a Pokémon during a battle. It wears off once the Pokémon is withdrawn.",
    MoveId = null,
    CategoryId = 8,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/x-sp-atk.png",
},
new Item
{
    Id = 59,
    Name = "X Sp. Def",
    Cost = 2000,
    Effect = "Used on a party Pokémon in battle: Raises the target's Special Defense by one stage. Increases happiness by 1/1/0.",
    ShortEffect = "Raises Special Defense by one stage in battle. Raises happiness.",
    Description = "An item that sharply boosts the Sp. Def stat of a Pokémon during a battle. It wears off once the Pokémon is withdrawn.",
    MoveId = null,
    CategoryId = 8,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/x-sp-def.png",
},
new Item
{
    Id = 60,
    Name = "Poké Doll",
    Cost = 300,
    Effect = "Used in battle: Ends a wild battle. Cannot be used in trainer battles.",
    ShortEffect = "Ends a wild battle.",
    Description = "A doll that attracts the attention of a Pokémon. It guarantees escape from any battle with wild Pokémon.",
    MoveId = null,
    CategoryId = 10,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/poke-doll.png",
},
new Item
{
    Id = 61,
    Name = "Fluffy Tail",
    Cost = 100,
    Effect = "Used in battle: Ends a wild battle. Cannot be used in trainer battles.",
    ShortEffect = "Ends a wild battle.",
    Description = "A toy that attracts the attention of a Pokémon. It guarantees escape from any battle with wild Pokémon.",
    MoveId = null,
    CategoryId = 10,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/fluffy-tail.png",
},
new Item
{
    Id = 62,
    Name = "Black Flute",
    Cost = 20,
    Effect = "Used outside of battle: Decreases the wild Pokémon encounter rate by 50%.",
    ShortEffect = "Halves the wild Pokémon encounter rate.",
    Description = "A flute made from black glass. It makes it easier to encounter strong Pokémon in the place you use it.",
    MoveId = null,
    CategoryId = 10,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/black-flute.png",
},
new Item
{
    Id = 63,
    Name = "White Flute",
    Cost = 20,
    Effect = "Used outside of battle: Doubles the wild Pokémon encounter rate.",
    ShortEffect = "Doubles the wild Pokémon encounter rate.",
    Description = "A flute made from white glass. It makes it easier to encounter weak Pokémon in the place you use it.",
    MoveId = null,
    CategoryId = 10,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/white-flute.png",
},
new Item
{
    Id = 64,
    Name = "Super Repel",
    Cost = 700,
    Effect = "Used outside of battle: Trainer will skip encounters with wild Pokémon of a lower level than the lead party Pokémon. This effect wears off after the trainer takes 200 steps.",
    ShortEffect = "For 200 steps, prevents wild encounters of level lower than your party's lead Pokémon.",
    Description = "An item that prevents any low-level wild Pokémon from jumping out at you for a while. It lasts longer than Repel.",
    MoveId = null,
    CategoryId = 10,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/super-repel.png",
},
new Item
{
    Id = 65,
    Name = "Max Repel",
    Cost = 900,
    Effect = "Used outside of battle: Trainer will skip encounters with wild Pokémon of a lower level than the lead party Pokémon. This effect wears off after the trainer takes 250 steps.",
    ShortEffect = "For 250 steps, prevents wild encounters of level lower than your party's lead Pokémon.",
    Description = "An item that prevents any low-level wild Pokémon from jumping out at you for a while. It lasts longer than Super Repel.",
    MoveId = null,
    CategoryId = 10,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/max-repel.png",
},
new Item
{
    Id = 66,
    Name = "Escape Rope",
    Cost = 300,
    Effect = "Used outside of battle: Transports the trainer to the last-entered dungeon entrance. Cannot be used outside, in buildings, or in distortion world, sinnoh hall of origin 1, spear pillar, or turnback cave.",
    ShortEffect = "Transports user to the outside entrance of a cave.",
    Description = "A long and durable rope. Use it to escape instantly from locations like caves or dungeons. It can be used any number of times.",
    MoveId = null,
    CategoryId = 10,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/escape-rope.png",
},
new Item
{
    Id = 67,
    Name = "Repel",
    Cost = 400,
    Effect = "Used outside of battle: Trainer will skip encounters with wild Pokémon of a lower level than the lead party Pokémon. This effect wears off after the trainer takes 100 steps.",
    ShortEffect = "For 100 steps, prevents wild encounters of level lower than your party's lead Pokémon.",
    Description = "An item that prevents any low-level wild Pokémon from jumping out at you for a while.",
    MoveId = null,
    CategoryId = 10,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/repel.png",
},
new Item
{
    Id = 68,
    Name = "Sun Stone",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Evolves a Cottonee into Whimsicott, a Gloom into Bellossom, a Petilil into Lilligant, or a Sunkern into Sunflora.",
    ShortEffect = "Evolves a Cottonee into Whimsicott, a Gloom into Bellossom, a Petilil into Lilligant, or a Sunkern into Sunflora.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. It burns as red as the evening sun.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/sun-stone.png",
},
new Item
{
    Id = 69,
    Name = "Moon Stone",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Evolves a Clefairy into Clefable, a Jigglypuff into Wigglytuff, a Munna into Musharna, a Nidorina into Nidoqueen, a Nidorino into Nidoking, or a Skitty into Delcatty.",
    ShortEffect = "Evolves a Clefairy into Clefable, a Jigglypuff into Wigglytuff, a Munna into Musharna, a Nidorina into Nidoqueen, a Nidorino into Nidoking, or a Skitty into Delcatty.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. It is as black as the night sky.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/moon-stone.png",
},
new Item
{
    Id = 70,
    Name = "Fire Stone",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Evolves an Eevee into Flareon, a Growlithe into Arcanine, a Pansear into Simisear, or a Vulpix into Ninetales.",
    ShortEffect = "Evolves an Eevee into Flareon, a Growlithe into Arcanine, a Pansear into Simisear, or a Vulpix into Ninetales.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. The stone has a fiery orange heart.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/fire-stone.png",
},
new Item
{
    Id = 71,
    Name = "Thunder Stone",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Evolves an Eelektrik into Eelektross, an Eevee into Jolteon, or a Pikachu into Raichu.",
    ShortEffect = "Evolves an Eelektrik into Eelektross, an Eevee into Jolteon, or a Pikachu into Raichu.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. It has a distinct thunderbolt pattern.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/thunder-stone.png",
},
new Item
{
    Id = 72,
    Name = "Water Stone",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Evolves an Eevee into Vaporeon, a Lombre into Ludicolo, a Panpour into Simipour, a Poliwhirl into Poliwrath, a Shellder into Cloyster, or a Staryu into Starmie.",
    ShortEffect = "Evolves an Eevee into Vaporeon, a Lombre into Ludicolo, a Panpour into Simipour, a Poliwhirl into Poliwrath, a Shellder into Cloyster, or a Staryu into Starmie.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. It is the blue of a pool of clear water.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/water-stone.png",
},
new Item
{
    Id = 73,
    Name = "Leaf Stone",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Evolves an Exeggcute into Exeggutor, a Gloom into Vileplume, a Nuzleaf into Shiftry, a Pansage into Simisage, or a Weepinbell into Victreebel.",
    ShortEffect = "Evolves an Exeggcute into Exeggutor, a Gloom into Vileplume, a Nuzleaf into Shiftry, a Pansage into Simisage, or a Weepinbell into Victreebel.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. It has an unmistakable leaf pattern.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/leaf-stone.png",
},
new Item
{
    Id = 74,
    Name = "Shiny Stone",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Evolves a Minccino into Cinccino, a Roselia into Roserade, or a Togetic into Togekiss.",
    ShortEffect = "Evolves a Minccino into Cinccino, a Roselia into Roserade, or a Togetic into Togekiss.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. It shines with a dazzling light.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/shiny-stone.png",
},
new Item
{
    Id = 75,
    Name = "Dusk Stone",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Evolves a Lampent into Chandelure, a Misdreavus into Mismagius, or a Murkrow into Honchkrow.",
    ShortEffect = "Evolves a Lampent into Chandelure, a Misdreavus into Mismagius, or a Murkrow into Honchkrow.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. It holds shadows as dark as can be.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/dusk-stone.png",
},
new Item
{
    Id = 76,
    Name = "Dawn Stone",
    Cost = 3000,
    Effect = "Used on a party Pokémon: Evolves a male Kirlia into Gallade or a female Snorunt into Froslass.",
    ShortEffect = "Evolves a male Kirlia into Gallade or a female Snorunt into Froslass.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. It sparkles like a glittering eye.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/dawn-stone.png",
},
new Item
{
    Id = 77,
    Name = "Oval Stone",
    Cost = 2000,
    Effect = "Held by Happiny: Holder evolves into Chansey when it levels up during the daytime.",
    ShortEffect = "Level-up during the day on a Happiny: Holder evolves into Chansey.",
    Description = "A peculiar stone that can make certain species of Pokémon evolve. It's as round as a Pokémon Egg.",
    MoveId = null,
    CategoryId = 9,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/oval-stone.png",
},
new Item
{
    Id = 78,
    Name = "Cheri Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder is paralyzed, it consumes this item to cure the paralysis. Used on a party Pokémon: Cures paralysis.",
    ShortEffect = "Held: Consumed when paralyzed to cure paralysis.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can recover from paralysis on its own in battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/cheri-berry.png",
},
new Item
{
    Id = 79,
    Name = "Chesto Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder is asleep, it consumes this item to wake up. Used on a party Pokémon: Cures sleep.",
    ShortEffect = "Held: Consumed when asleep to cure sleep.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can recover from sleep on its own in battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/chesto-berry.png",
},
new Item
{
    Id = 80,
    Name = "Pecha Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder is poisoned, it consumes this item to cure the poison. Used on a party Pokémon: Cures poison.",
    ShortEffect = "Held: Consumed when poisoned to cure poison.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can recover from poisoning on its own in battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/pecha-berry.png",
},
new Item
{
    Id = 81,
    Name = "Rawst Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder is burned, it consumes this item to cure the burn. Used on a party Pokémon: Cures a burn.",
    ShortEffect = "Held: Consumed when burned to cure a burn.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can recover from a burn on its own in battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/rawst-berry.png",
},
new Item
{
    Id = 82,
    Name = "Aspear Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder is frozen, it consumes this item to thaw itself. Used on a party Pokémon: Cures freezing.",
    ShortEffect = "Held: Consumed when frozen to cure frozen.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can recover from being frozen on its own in battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/aspear-berry.png",
},
new Item
{
    Id = 83,
    Name = "Leppa Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder is out of PP for one of its moves, it consumes this item to restore 10 of that move's PP. Used on a party Pokémon: Restores 10 PP for a selected move.",
    ShortEffect = "Held: Consumed when a move runs out of PP to restore its PP by 10.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can restore 10 PP to a depleted move during battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/leppa-berry.png",
},
new Item
{
    Id = 84,
    Name = "Oran Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder has 1/2 its max HP remaining or less, it consumes this item to restore 10 HP. Used on a party Pokémon: Restores 10 HP.",
    ShortEffect = "Held: Consumed at 1/2 max HP to recover 10 HP.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can restore its own HP by 10 points during battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/oran-berry.png",
},
new Item
{
    Id = 85,
    Name = "Persim Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder is confused, it consumes this item to cure the confusion. Used on a party Pokémon: Cures confusion.",
    ShortEffect = "Held: Consumed when confused to cure confusion.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can recover from confusion on its own in battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/persim-berry.png",
},
new Item
{
    Id = 86,
    Name = "Lum Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder is afflicted with a major status ailment, it consumes this item to cure the ailment. Used on a party Pokémon: Cures any major status ailment.",
    ShortEffect = "Held: Consumed to cure any status condition or confusion.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can recover from any status condition during battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/lum-berry.png",
},
new Item
{
    Id = 87,
    Name = "Sitrus Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder has 1/2 its max HP remaining or less, it consumes this item to restore 1/4 its max HP. Used on a party Pokémon: Restores 1/4 the Pokémon's max HP.",
    ShortEffect = "Held: Consumed at 1/2 max HP to recover 1/4 max HP.",
    Description = "A Berry to be consumed by Pokémon. If a Pokémon holds one, it can restore its own HP by a small amount during battle.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/sitrus-berry.png",
},
new Item
{
    Id = 88,
    Name = "Figy Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder has 1/2 its max HP remaining or less, it consumes this item to restore 1/8 its max HP. If the holder dislikes spicy flavors (i.e., has a nature that lowers Attack), it will also become confused.",
    ShortEffect = "Held: Consumed at 1/2 max HP to restore 1/8 max HP. Confuses Pokémon that dislike spicy flavor.",
    Description = "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates the taste.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/figy-berry.png",
},
new Item
{
    Id = 89,
    Name = "Wiki Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder has 1/2 its max HP remaining or less, it consumes this item to restore 1/8 its max HP. If the holder dislikes dry flavors (i.e., has a nature that lowers Special Attack), it will also become confused.",
    ShortEffect = "Held: Consumed at 1/2 max HP to restore 1/8 max HP. Confuses Pokémon that dislike dry flavor.",
    Description = "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates the taste.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/wiki-berry.png",
},
new Item
{
    Id = 90,
    Name = "Mago Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder has 1/2 its max HP remaining or less, it consumes this item to restore 1/8 its max HP. If the holder dislikes sweet flavors (i.e., has a nature that lowers Speed), it will also become confused.",
    ShortEffect = "Held: Consumed at 1/2 max HP to restore 1/8 max HP. Confuses Pokémon that dislike sweet flavor.",
    Description = "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates the taste.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/mago-berry.png",
},
new Item
{
    Id = 91,
    Name = "Aguav Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder has 1/2 its max HP remaining or less, it consumes this item to restore 1/8 its max HP. If the holder dislikes bitter flavors (i.e., has a nature that lowers Special Defense), it will also become confused.",
    ShortEffect = "Held: Consumed at 1/2 max HP to restore 1/8 max HP. Confuses Pokémon that dislike bitter flavor.",
    Description = "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates the taste.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/aguav-berry.png",
},
new Item
{
    Id = 92,
    Name = "Iapapa Berry",
    Cost = 80,
    Effect = "Held in battle: When the holder has 1/2 its max HP remaining or less, it consumes this item to restore 1/8 its max HP. If the holder dislikes sour flavors (i.e., has a nature that lowers Defense), it will also become confused.",
    ShortEffect = "Held: Consumed at 1/2 max HP to restore 1/8 max HP. Confuses Pokémon that dislike sour flavor.",
    Description = "If held by a Pokémon, it restores the user's HP in a pinch, but it will cause confusion if the user hates the taste.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/iapapa-berry.png",
},
new Item
{
    Id = 93,
    Name = "Razz Berry",
    Cost = 200,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Coolness. Its red flesh is spicy when eaten.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/razz-berry.png",
},
new Item
{
    Id = 94,
    Name = "Bluk Berry",
    Cost = 20,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Beauty. Its blue flesh is dry when eaten.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/bluk-berry.png",
},
new Item
{
    Id = 95,
    Name = "Nanab Berry",
    Cost = 200,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Cuteness. Its pink flesh is sweet when eaten.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/nanab-berry.png",
},
new Item
{
    Id = 96,
    Name = "Wepear Berry",
    Cost = 20,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Cleverness. Its green flesh is bitter when eaten.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/wepear-berry.png",
},
new Item
{
    Id = 97,
    Name = "Pinap Berry",
    Cost = 200,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Toughness. Its spiky skin is tough when eaten.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/pinap-berry.png",
},
new Item
{
    Id = 98,
    Name = "Pomeg Berry",
    Cost = 20,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Beauty. Poffin cooking. Firm, dry, and sour.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/pomeg-berry.png",
},
new Item
{
    Id = 99,
    Name = "Kelpsy Berry",
    Cost = 200,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Cuteness. Poffin cooking. Hard, sour, and dry.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/kelpsy-berry.png",
},
new Item
{
    Id = 100,
    Name = "Qualot Berry",
    Cost = 20,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Cleverness. Poffin cooking. Very dry and smoky.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/qualot-berry.png",
},
new Item
{
    Id = 101,
    Name = "Hondew Berry",
    Cost = 200,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Toughness. Poffin cooking. Hard and dry.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/hondew-berry.png",
},
new Item
{
    Id = 102,
    Name = "Grepa Berry",
    Cost = 20,
    Effect = "No effect; only useful for planting and cooking.",
    ShortEffect = "Used for creating PokéBlocks and Poffins.",
    Description = "Used to make Pokéblocks that will enhance your Beauty. Poffin cooking. Very dry.",
    MoveId = null,
    CategoryId = 12,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/grepa-berry.png",
},
new Item
{
    Id = 103,
    Name = "TM01",
    Cost = 40000,
    Effect = "Teaches Mega Punch to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage with no additional effect.",
    Description = "The foe is slugged by a punch thrown with muscle-packed power.",
    MoveId = 1,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 104,
    Name = "TM02",
    Cost = 1000,
    Effect = "Teaches Razor Wind to a compatible Pokémon.",
    ShortEffect = "Requires a turn to charge before attacking.",
    Description = "Inflicts regular damage.  User's critical hit rate is one level higher when using this move.  User charges for one turn before attacking. This move cannot be selected by sleep talk.",
    MoveId = 2,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 105,
    Name = "TM03",
    Cost = 50000,
    Effect = "Teaches Swords Dance to a compatible Pokémon.",
    ShortEffect = "Raises the user's Attack by 2 stages.",
    Description = "Raises the user's Attack by 2 stages.",
    MoveId = 3,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 106,
    Name = "TM04",
    Cost = 50000,
    Effect = "Teaches Whirl Wind to a compatible Pokémon.",
    ShortEffect = "Immediately ends wild battles. Forces trainers to switch Pokémon.",
    Description = "Switches the target out for another of its trainer's Pokémon selected at random.  Wild battles end immediately. Doesn't affect Pokémon with suction cups or under the effect of ingrain.",
    MoveId = 4,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 107,
    Name = "TM05",
    Cost = 50000,
    Effect = "Teaches Mega Kick to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage with no additional effect.",
    Description = "The foe is attacked by a kick launched with muscle-packed power.",
    MoveId = 5,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 108,
    Name = "TM06",
    Cost = 1000,
    Effect = "Teaches Toxic to a compatible Pokémon.",
    ShortEffect = "Badly poisons the target, inflicting more damage every turn.",
    Description = "The target is badly poisoned, with the damage caused by poison doubling after each turn.",
    MoveId = 6,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 109,
    Name = "TM07",
    Cost = 1000,
    Effect = "Teaches Horn Drill to a compatible Pokémon.",
    ShortEffect = "Inflicts damage equal to the target's max HP. Ignores accuracy and evasion modifiers.",
    Description = "The target faints; doesn't work on faster or higher-leveled Pokemon.",
    MoveId = 7,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 110,
    Name = "TM08",
    Cost = 1000,
    Effect = "Teaches Body Slam to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage with no additional effect. Has a chance to paralyze the target.",
    Description = "The user attacks by dropping onto the target with its full body weight. This may also leave the target with paralysis.",
    MoveId = 8,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 111,
    Name = "TM09",
    Cost = 10000,
    Effect = "Teaches Take Down to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. User takes 1/4 the damage it inflicts in recoil.",
    Description = "A reckless, full-body charge attack for slamming into the foe. It also damages the user a little.",
    MoveId = 9,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 112,
    Name = "TM10",
    Cost = 1000,
    Effect = "Teaches Double Edge to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. User takes 1/3 the damage it inflicts in recoil.",
    Description = "A life-risking tackle that also hurts the user.",
    MoveId = 10,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 113,
    Name = "TM11",
    Cost = 10000,
    Effect = "Teaches Bubble Beam to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Has a chance to lower the target's speed by one stage.",
    Description = "Forcefully sprays bubbles that may lower speed.",
    MoveId = 11,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 114,
    Name = "TM12",
    Cost = 50000,
    Effect = "Teaches Water Gun to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage with no additional effect.",
    Description = "The foe is struck with a lot of water expelled forcibly from the mouth.",
    MoveId = 12,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 115,
    Name = "TM13",
    Cost = 10000,
    Effect = "Teaches Ice Beam to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage.  Has a chance to freeze the target.",
    Description = "Blasts the foe with an icy beam that may freeze it.",
    MoveId = 13,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 116,
    Name = "TM14",
    Cost = 1000,
    Effect = "Teaches Blizzard to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage.  Has a chance to freeze the target.",
    Description = "A howling blizzard is summoned to strike the foe. It may also freeze the target solid.",
    MoveId = 14,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 117,
    Name = "TM15",
    Cost = 1000,
    Effect = "Teaches Hyper Beam to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. User loses its next turn to recharge, and cannot attack or switch out during that turn.",
    Description = "A severely damaging attack that makes the user rest on the next turn.",
    MoveId = 15,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 118,
    Name = "TM16",
    Cost = 1000,
    Effect = "Teaches Pay Day to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage.  After the battle ends, the winner receives five times the user's level in extra money for each time this move was used.",
    Description = "Numerous coins are hurled at the foe to inflict damage. Money is earned after battle.",
    MoveId = 16,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 119,
    Name = "TM17",
    Cost = 10000,
    Effect = "Teaches Submission to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. User takes 1/4 the damage it inflicts in recoil.",
    Description = "The user grabs the foe and recklessly dives for the ground. It also hurts the user slightly.",
    MoveId = 17,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 120,
    Name = "TM18",
    Cost = 10000,
    Effect = "Teaches Counter to a compatible Pokémon.",
    ShortEffect = "Targets the last opposing Pokémon to hit the user with a physical move this turn.  Inflicts twice the damage that move did to the user.",
    Description = "A retaliation move that counters any physical attack, inflicting double the damage taken.",
    MoveId = 18,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 121,
    Name = "TM19",
    Cost = 10000,
    Effect = "Teaches Seismic Toss to a compatible Pokémon.",
    ShortEffect = "Inflicts damage equal to the user's level. Type immunity applies, but other type effects are ignored.",
    Description = "The foe is thrown using the power of gravity. It inflicts damage equal to the user's level.",
    MoveId = 19,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 122,
    Name = "TM20",
    Cost = 100000,
    Effect = "Teaches Rage to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Every time the user is hit after it uses this move but before its next action, its Attack raises by one stage.",
    Description = "While this move is in use, it gains attack power each time the user is hit in battle.",
    MoveId = 20,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 123,
    Name = "TM21",
    Cost = 1000,
    Effect = "Teaches Mega Darin to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Drains half the damage inflicted to heal the user.",
    Description = "A nutrient-draining attack. The user's HP is restored by half the damage taken by the target.",
    MoveId = 21,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 124,
    Name = "TM22",
    Cost = 1000,
    Effect = "Teaches SolarBeam to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. User charges for one turn before attacking.",
    Description = "A two-turn attack. The user gathers light, then blasts a bundled beam on the second turn.",
    MoveId = 22,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 125,
    Name = "TM23",
    Cost = 10000,
    Effect = "Teaches Dragon Rage to a compatible Pokémon.",
    ShortEffect = "Always deals 40 points of damage.",
    Description = "The user attacks with a dragon-like force that always inflicts 40 points of damage.",
    MoveId = 23,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 126,
    Name = "TM24",
    Cost = 1000,
    Effect = "Teaches Thunderbolt to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Has a chance to paralyze the target.",
    Description = "A strong electric blast is loosed at the foe. It may also leave the foe paralyzed.",
    MoveId = 24,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 127,
    Name = "TM25",
    Cost = 10000,
    Effect = "Teaches Thunder to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Has a chance to paralyze the target.",
    Description = "A wicked thunderbolt is dropped on the foe to inflict damage. It may also leave the target paralyzed.",
    MoveId = 25,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 128,
    Name = "TM26",
    Cost = 1000,
    Effect = "Teaches Earthquake to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. If the target is in the first turn of dig, this move will hit with double power.",
    Description = "The user sets off an earthquake that hits all the Pokémon in the battle.",
    MoveId = 26,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 129,
    Name = "TM27",
    Cost = 1000,
    Effect = "Teaches Fissure to a compatible Pokémon.",
    ShortEffect = "Inflicts damage equal to the target's max HP. Ignores accuracy and evasion modifiers.",
    Description = "The user opens up a fissure in the ground and drops the foe in. The target instantly faints if it hits.",
    MoveId = 27,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 130,
    Name = "TM28",
    Cost = 100000,
    Effect = "Teaches Dig to a compatible Pokémon.",
    ShortEffect = "Swift can hit the user while underground, and no other moves can.",
    Description = "The user burrows, then attacks on the second turn. It can also be used to exit dungeons.",
    MoveId = 28,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 131,
    Name = "TM29",
    Cost = 1000,
    Effect = "Teaches Psychic to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Has a chance to lower the target's Special Defense by one stage.",
    Description = "The foe is hit by a strong telekinetic force. It may also reduce the foe's Sp. Def stat.",
    MoveId = 29,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 132,
    Name = "TM30",
    Cost = 1000,
    Effect = "Teaches Teleport to a compatible Pokémon.",
    ShortEffect = "Does nothing. Wild battles end immediately.",
    Description = "Use it to flee from any wild Pokémon. It may also be used to warp to the last Poké Center visited.",
    MoveId = 30,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 133,
    Name = "TM31",
    Cost = 1000,
    Effect = "Teaches Mimic to a compatible Pokémon.",
    ShortEffect = "This move is replaced by the target's last successfully used move, and its PP changes to 5.",
    Description = "The user copies the move last used by the foe. The move can be used for the rest of the battle.",
    MoveId = 31,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 134,
    Name = "TM32",
    Cost = 10000,
    Effect = "Teaches Double Team to a compatible Pokémon.",
    ShortEffect = "Raises the user's evasion by one stage.",
    Description = "By moving rapidly, the user makes illusory copies of itself to raise its evasiveness.",
    MoveId = 32,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 135,
    Name = "TM33",
    Cost = 10000,
    Effect = "Teaches Reflect to a compatible Pokémon.",
    ShortEffect = "Erects a barrier around the user's side of the field that reduces damage from physical attacks by half for five turns",
    Description = "A wondrous wall of light is put up to suppress damage from physical attacks for five turns.",
    MoveId = 33,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 136,
    Name = "TM34",
    Cost = 10000,
    Effect = "Teaches Bide to a compatible Pokémon.",
    ShortEffect = "The user endures attacks for two turns, then strikes back double.",
    Description = "User waits for two turns.  On the second turn, the user inflicts twice the damage it accumulated on the last Pokémon to hit it.",
    MoveId = 34,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 137,
    Name = "TM35",
    Cost = 10000,
    Effect = "Teaches Metronome to a compatible Pokémon.",
    ShortEffect = "The user performs a random move; almost any known move can be selected.",
    Description = "The user performs a random move; almost any known move can be selected.",
    MoveId = 35,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 138,
    Name = "TM36",
    Cost = 10000,
    Effect = "Teaches Self-Destruct to a compatible Pokémon.",
    ShortEffect = "User faints, even if the attack fails or misses.  Inflicts regular damage.",
    Description = "The user blows up to inflict damage on all Pokémon in battle. The user faints upon using this move.",
    MoveId = 36,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 139,
    Name = "TM37",
    Cost = 10000,
    Effect = "Teaches Eggbomb to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage with no additional effect.",
    Description = "A large egg is hurled with maximum force at the foe to inflict damage.",
    MoveId = 37,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 140,
    Name = "TM38",
    Cost = 10000,
    Effect = "Teaches Fire Blast to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Has a chance to burn the target.",
    Description = "The foe is attacked with an intense blast of all-consuming fire. It may also leave the target with a burn.",
    MoveId = 38,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 141,
    Name = "TM39",
    Cost = 1000,
    Effect = "Teaches Swift to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Ignores accuracy and evasion modifiers.",
    Description = "Star-shaped rays are shot at the foe. This attack never misses.",
    MoveId = 39,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 142,
    Name = "TM40",
    Cost = 1000,
    Effect = "Teaches Skull Bash to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Raises the user's Defense by one stage.  User then charges for one turn before attacking.",
    Description = "The user tucks in its head to raise its Defense in the first turn, then rams the foe on the next turn.",
    MoveId = 40,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 143,
    Name = "TM41",
    Cost = 1000,
    Effect = "Teaches Soft-Boiled to a compatible Pokémon.",
    ShortEffect = "Restores 1/2 of the user's max HP. However, this move fails if the user's current HP is 511 or 255 HP below its value at full health.",
    Description = "Restores 1/2 of the user's max HP. However, this move fails if the user's current HP is 511 or 255 HP below its value at full health.",
    MoveId = 41,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 144,
    Name = "TM42",
    Cost = 1000,
    Effect = "Teaches Dream Eater to a compatible Pokémon.",
    ShortEffect = "Restores the user's HP by 1/2 of the damage inflicted on the target but only works on a sleeping target.",
    Description = "An attack that works only on a sleeping foe. It absorbs half the damage caused to heal the user's HP.",
    MoveId = 42,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 145,
    Name = "TM43",
    Cost = 1000,
    Effect = "Teaches Sky Attack to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. User charges for one turn before attacking.",
    Description = "A second-turn attack move with a high critical-hit ratio. It may also make the target flinch.",
    MoveId = 43,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 146,
    Name = "TM44",
    Cost = 1000,
    Effect = "Teaches Rest to a compatible Pokémon.",
    ShortEffect = "User falls to sleep and immediately regains all its HP.  If the user has another major status effect, sleep will replace it.",
    Description = "User falls to sleep and immediately regains all its HP.  If the user has another major status effect, sleep will replace it.",
    MoveId = 44,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 147,
    Name = "TM45",
    Cost = 1000,
    Effect = "Teaches Thunder Wave to a compatible Pokémon.",
    ShortEffect = "A weak jolt of electricity that paralyzes the foe.",
    Description = "A weak electric charge is launched at the target. It causes paralysis if it hits.",
    MoveId = 45,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 148,
    Name = "TM46",
    Cost = 1000,
    Effect = "Teaches Psywave to a compatible Pokémon.",
    ShortEffect = "Inflicts typeless damage between 50% and 150% of the user's level, selected at random in increments of 10%.",
    Description = "The foe is attacked with an odd, hot energy wave. The attack varies in intensity.",
    MoveId = 46,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 149,
    Name = "TM47",
    Cost = 1000,
    Effect = "Teaches Explosion to a compatible Pokémon.",
    ShortEffect = "Halves the target's Defense for damage calculation, which is similar to doubling the attack's power.",
    Description = "The user explodes to inflict terrible damage even while fainting itself.",
    MoveId = 47,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 150,
    Name = "TM48",
    Cost = 10000,
    Effect = "Teaches Rock Slide to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage.  Has a chance to make the target flinch.",
    Description = "The user slams a barrage of rocks down on the target from above.",
    MoveId = 48,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 151,
    Name = "TM49",
    Cost = 10000,
    Effect = "Teaches Echoed Voice to a compatible Pokémon.",
    ShortEffect = "Inflicts regular damage. Has a chance to burn, freeze, or paralyze the target.",
    Description = "The user strikes with a simultaneous three- beam attack. May also paralyze, burn, or freeze the target.",
    MoveId = 49,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
},
new Item
{
    Id = 152,
    Name = "TM50",
    Cost = 1000,
    Effect = "Teaches Substitute to a compatible Pokémon.",
    ShortEffect = "The user takes one-fourth of its maximum HP to create a substitute.",
    Description = "The user takes one-fourth of its maximum HP to create a substitute; this move fails if the user does not have enough HP for this.",
    MoveId = 50,
    CategoryId = 11,
    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/items/tm-normal.png",
}


);
        modelBuilder.Entity<Move>().HasData(

    new Move { Id = 1, Name = "Mega Punch", Accuracy = 85, Power = 80, PP = 20, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 2, Name = "Razor Wind", Accuracy = 100, Power = 80, PP = 10, DamageClassId = 3, PokeTypeId = 1 },
    new Move { Id = 3, Name = "Swords Dance", PP = 20, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 4, Name = "Whirlwind", PP = 20, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 5, Name = "Mega Kick", Accuracy = 75, Power = 120, PP = 5, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 6, Name = "Toxic", Accuracy = 90, PP = 10, DamageClassId = 1, PokeTypeId = 4 },
    new Move { Id = 7, Name = "Horn Drill", Accuracy = 30, PP = 5, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 8, Name = "Body Slam", Accuracy = 100, Power = 85, PP = 15, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 9, Name = "Take Down", Accuracy = 85, Power = 90, PP = 20, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 10, Name = "Double-Edge", Accuracy = 100, Power = 120, PP = 15, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 11, Name = "Bubble Beam", Accuracy = 100, Power = 65, PP = 20, DamageClassId = 3, PokeTypeId = 11 },
    new Move { Id = 12, Name = "Water Gun", Accuracy = 100, Power = 40, PP = 25, DamageClassId = 3, PokeTypeId = 11 },
    new Move { Id = 13, Name = "Ice Beam", Accuracy = 100, Power = 90, PP = 10, DamageClassId = 3, PokeTypeId = 15 },
    new Move { Id = 14, Name = "Blizzard", Accuracy = 70, Power = 110, PP = 5, DamageClassId = 3, PokeTypeId = 15 },
    new Move { Id = 15, Name = "Hyper Beam", Accuracy = 90, Power = 150, PP = 5, DamageClassId = 3, PokeTypeId = 1 },
    new Move { Id = 16, Name = "Pay Day", Accuracy = 100, Power = 40, PP = 20, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 17, Name = "Submission", Accuracy = 80, Power = 80, PP = 20, DamageClassId = 2, PokeTypeId = 2 },
    new Move { Id = 18, Name = "Counter", Accuracy = 100, PP = 20, DamageClassId = 2, PokeTypeId = 2 },
    new Move { Id = 19, Name = "Seismic Toss", Accuracy = 100, PP = 20, DamageClassId = 2, PokeTypeId = 2 },
    new Move { Id = 20, Name = "Rage", Accuracy = 100, Power = 20, PP = 20, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 21, Name = "Mega Drain", Accuracy = 100, Power = 40, PP = 15, DamageClassId = 3, PokeTypeId = 12 },
    new Move { Id = 22, Name = "Solar Beam", Accuracy = 100, Power = 120, PP = 10, DamageClassId = 3, PokeTypeId = 12 },
    new Move { Id = 23, Name = "Dragon Rage", Accuracy = 100, PP = 10, DamageClassId = 3, PokeTypeId = 16 },
    new Move { Id = 24, Name = "Thunderbolt", Accuracy = 100, Power = 90, PP = 15, DamageClassId = 3, PokeTypeId = 13 },
    new Move { Id = 25, Name = "Thunder", Accuracy = 70, Power = 110, PP = 10, DamageClassId = 3, PokeTypeId = 13 },
    new Move { Id = 26, Name = "Earthquake", Accuracy = 100, Power = 100, PP = 10, DamageClassId = 2, PokeTypeId = 5 },
    new Move { Id = 27, Name = "Fissure", Accuracy = 30, PP = 5, DamageClassId = 2, PokeTypeId = 5 },
    new Move { Id = 28, Name = "Dig", Accuracy = 100, Power = 80, PP = 10, DamageClassId = 2, PokeTypeId = 5 },
    new Move { Id = 29, Name = "Psychic", Accuracy = 100, Power = 90, PP = 10, DamageClassId = 3, PokeTypeId = 14 },
    new Move { Id = 30, Name = "Teleport", PP = 20, DamageClassId = 1, PokeTypeId = 14 },
    new Move { Id = 31, Name = "Mimic", PP = 10, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 32, Name = "Double Team", PP = 15, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 33, Name = "Reflect", PP = 20, DamageClassId = 1, PokeTypeId = 14 },
    new Move { Id = 34, Name = "Bide", PP = 10, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 35, Name = "Metronome", PP = 10, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 36, Name = "Self-Destruct", Accuracy = 100, Power = 200, PP = 5, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 37, Name = "Egg Bomb", Accuracy = 75, Power = 100, PP = 10, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 38, Name = "Fire Blast", Accuracy = 85, Power = 110, PP = 5, DamageClassId = 3, PokeTypeId = 10 },
    new Move { Id = 39, Name = "Swift", Power = 20, PP = 3, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 40, Name = "Skull Bash", Accuracy = 100, Power = 130, PP = 10, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 41, Name = "Soft-Boiled", PP = 10, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 42, Name = "Dream Eater", Accuracy = 100, Power = 100, PP = 15, DamageClassId = 3, PokeTypeId = 14 },
    new Move { Id = 43, Name = "Sky Attack", Accuracy = 90, Power = 140, PP = 5, DamageClassId = 2, PokeTypeId = 3 },
    new Move { Id = 44, Name = "Rest", PP = 10, DamageClassId = 1, PokeTypeId = 14 },
    new Move { Id = 45, Name = "Thunder Wave", Accuracy = 90, PP = 20, DamageClassId = 1, PokeTypeId = 13 },
    new Move { Id = 46, Name = "Psywave", Accuracy = 100, PP = 15, DamageClassId = 3, PokeTypeId = 14 },
    new Move { Id = 47, Name = "Explosion", Accuracy = 100, Power = 250, PP = 5, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 48, Name = "Rock Slide", Accuracy = 90, Power = 75, PP = 10, DamageClassId = 2, PokeTypeId = 6 },
    new Move { Id = 49, Name = "Tri Attack", Accuracy = 100, Power = 80, PP = 10, DamageClassId = 3, PokeTypeId = 1 },
    new Move { Id = 50, Name = "Substitute", PP = 10, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 51, Name = "Roost", PP = 10, DamageClassId = 1, PokeTypeId = 3 },
    new Move { Id = 52, Name = "Focus Blast", Accuracy = 70, Power = 120, PP = 5, DamageClassId = 3, PokeTypeId = 2 },
    new Move { Id = 53, Name = "Energy Ball", Accuracy = 100, Power = 90, PP = 10, DamageClassId = 3, PokeTypeId = 12 },
    new Move { Id = 54, Name = "False Swipe", Accuracy = 100, Power = 40, PP = 40, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 55, Name = "Brine", Accuracy = 100, Power = 65, PP = 10, DamageClassId = 3, PokeTypeId = 11 },
    new Move { Id = 56, Name = "Fling", PP = 10, DamageClassId = 2, PokeTypeId = 17 },
    new Move { Id = 57, Name = "Charge Beam", Accuracy = 90, Power = 50, PP = 10, DamageClassId = 3, PokeTypeId = 13 },
    new Move { Id = 58, Name = "Endure", PP = 10, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 59, Name = "Dragon Pulse", Accuracy = 100, Power = 85, PP = 10, DamageClassId = 3, PokeTypeId = 16 },
    new Move { Id = 60, Name = "Drain Punch", Accuracy = 100, Power = 75, PP = 10, DamageClassId = 2, PokeTypeId = 2 },
    new Move { Id = 61, Name = "Will-O-Wisp", Accuracy = 85, PP = 15, DamageClassId = 1, PokeTypeId = 10 },
    new Move { Id = 62, Name = "Silver Wind", Accuracy = 100, Power = 60, PP = 5, DamageClassId = 3, PokeTypeId = 7 },
    new Move { Id = 63, Name = "Embargo", Accuracy = 100, PP = 15, DamageClassId = 1, PokeTypeId = 17 },
    new Move { Id = 64, Name = "Explosion", Accuracy = 100, Power = 250, PP = 5, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 65, Name = "Shadow Claw", Accuracy = 100, Power = 70, PP = 15, DamageClassId = 2, PokeTypeId = 8 },
    new Move { Id = 66, Name = "Payback", Accuracy = 100, Power = 50, PP = 10, DamageClassId = 2, PokeTypeId = 17 },
    new Move { Id = 67, Name = "Recycle", PP = 10, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 68, Name = "Giga Impact", Accuracy = 90, Power = 150, PP = 5, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 69, Name = "Rock Polish", PP = 20, DamageClassId = 1, PokeTypeId = 6 },
    new Move { Id = 70, Name = "Flash", Accuracy = 100, PP = 20, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 71, Name = "Stone Edge", Accuracy = 80, Power = 100, PP = 5, DamageClassId = 2, PokeTypeId = 6 },
    new Move { Id = 72, Name = "Avalanche", Accuracy = 100, Power = 60, PP = 10, DamageClassId = 2, PokeTypeId = 15 },
    new Move { Id = 73, Name = "Thunder Wave", Accuracy = 90, PP = 20, DamageClassId = 1, PokeTypeId = 13 },
    new Move { Id = 74, Name = "Gyro Ball", Accuracy = 100, PP = 5, DamageClassId = 2, PokeTypeId = 9 },
    new Move { Id = 75, Name = "Swords Dance", PP = 20, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 76, Name = "Stealth Rock", PP = 20, DamageClassId = 1, PokeTypeId = 6 },
    new Move { Id = 77, Name = "Psych Up", PP = 10, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 78, Name = "Captivate", Accuracy = 100, PP = 20, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 79, Name = "Dark Pulse", Accuracy = 100, Power = 80, PP = 15, DamageClassId = 3, PokeTypeId = 17 },
    new Move { Id = 80, Name = "Rock Slide", Accuracy = 90, Power = 75, PP = 10, DamageClassId = 2, PokeTypeId = 6 },
    new Move { Id = 81, Name = "X-Scissor", Accuracy = 100, Power = 80, PP = 15, DamageClassId = 2, PokeTypeId = 7 },
    new Move { Id = 82, Name = "Sleep Talk", PP = 10, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 83, Name = "Natural Gift", Accuracy = 100, PP = 15, DamageClassId = 2, PokeTypeId = 1 },
    new Move { Id = 84, Name = "Poison Jab", Accuracy = 100, Power = 80, PP = 20, DamageClassId = 2, PokeTypeId = 4 },
    new Move { Id = 85, Name = "Dream Eater", Accuracy = 100, Power = 100, PP = 15, DamageClassId = 3, PokeTypeId = 14 },
    new Move { Id = 86, Name = "Grass Knot", Accuracy = 100, PP = 20, DamageClassId = 3, PokeTypeId = 12 },
    new Move { Id = 87, Name = "Swagger", Accuracy = 85, PP = 15, DamageClassId = 1, PokeTypeId = 1 },
    new Move { Id = 88, Name = "Pluck", Accuracy = 100, Power = 60, PP = 20, DamageClassId = 2, PokeTypeId = 3 },
    new Move { Id = 89, Name = "U-turn", Accuracy = 100, Power = 70, PP = 20, DamageClassId = 2, PokeTypeId = 7 },
    new Move { Id = 90, Name = "Substitute", PP = 10, DamageClassId = 1, PokeTypeId = 1 }

        );
        modelBuilder.Entity<Pokemon>().HasData(

     new Pokemon { Id = 1, Name = "Bulbasaur", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png" },
    new Pokemon { Id = 2, Name = "Ivysaur", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/2.png" },
    new Pokemon { Id = 3, Name = "Venusaur", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/3.png" },
    new Pokemon { Id = 4, Name = "Charmander", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png" },
    new Pokemon { Id = 5, Name = "Charmeleon", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/5.png" },
    new Pokemon { Id = 6, Name = "Charizard", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/6.png" },
    new Pokemon { Id = 7, Name = "Squirtle", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png" },
    new Pokemon { Id = 8, Name = "Wartortle", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/8.png" },
    new Pokemon { Id = 9, Name = "Blastoise", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/9.png" },
    new Pokemon { Id = 10, Name = "Caterpie", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/10.png" },
    new Pokemon { Id = 11, Name = "Metapod", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/11.png" },
    new Pokemon { Id = 12, Name = "Butterfree", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/12.png" },
    new Pokemon { Id = 13, Name = "Weedle", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/13.png" },
    new Pokemon { Id = 14, Name = "Kakuna", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/14.png" },
    new Pokemon { Id = 15, Name = "Beedrill", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/15.png" },
    new Pokemon { Id = 16, Name = "Pidgey", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/16.png" },
    new Pokemon { Id = 17, Name = "Pidgeotto", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/17.png" },
    new Pokemon { Id = 18, Name = "Pidgeot", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/18.png" },
    new Pokemon { Id = 19, Name = "Rattata", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/19.png" },
    new Pokemon { Id = 20, Name = "Raticate", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/20.png" },
    new Pokemon { Id = 21, Name = "Spearow", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/21.png" },
    new Pokemon { Id = 22, Name = "Fearow", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/22.png" },
    new Pokemon { Id = 23, Name = "Ekans", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/23.png" },
    new Pokemon { Id = 24, Name = "Arbok", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/24.png" },
    new Pokemon { Id = 25, Name = "Pikachu", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png" },
    new Pokemon { Id = 26, Name = "Raichu", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/26.png" },
    new Pokemon { Id = 27, Name = "Sandshrew", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/27.png" },
    new Pokemon { Id = 28, Name = "Sandslash", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/28.png" },
    new Pokemon { Id = 29, Name = "Nidoran-f", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/29.png" },
    new Pokemon { Id = 30, Name = "Nidorina", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/30.png" },
    new Pokemon { Id = 31, Name = "Nidoqueen", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/31.png" },
    new Pokemon { Id = 32, Name = "Nidoran-m", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/32.png" },
    new Pokemon { Id = 33, Name = "Nidorino", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/33.png" },
    new Pokemon { Id = 34, Name = "Nidoking", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/34.png" },
    new Pokemon { Id = 35, Name = "Clefairy", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/35.png" },
    new Pokemon { Id = 36, Name = "Clefable", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/36.png" },
    new Pokemon { Id = 37, Name = "Vulpix", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/37.png" },
    new Pokemon { Id = 38, Name = "Ninetales", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/38.png" },
    new Pokemon { Id = 39, Name = "Jigglypuff", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/39.png" },
    new Pokemon { Id = 40, Name = "Wigglytuff", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/40.png" },
    new Pokemon { Id = 41, Name = "Zubat", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/41.png" },
    new Pokemon { Id = 42, Name = "Golbat", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/42.png" },
    new Pokemon { Id = 43, Name = "Oddish", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/43.png" },
    new Pokemon { Id = 44, Name = "Gloom", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/44.png" },
    new Pokemon { Id = 45, Name = "Vileplume", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/45.png" },
    new Pokemon { Id = 46, Name = "Paras", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/46.png" },
    new Pokemon { Id = 47, Name = "Parasect", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/47.png" },
    new Pokemon { Id = 48, Name = "Venonat", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/48.png" },
    new Pokemon { Id = 49, Name = "Venomoth", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/49.png" },
    new Pokemon { Id = 50, Name = "Diglett", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/50.png" },
    new Pokemon { Id = 51, Name = "Dugtrio", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/51.png" },
    new Pokemon { Id = 52, Name = "Meowth", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/52.png" },
    new Pokemon { Id = 53, Name = "Persian", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/53.png" },
    new Pokemon { Id = 54, Name = "Psyduck", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/54.png" },
    new Pokemon { Id = 55, Name = "Golduck", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/55.png" },
    new Pokemon { Id = 56, Name = "Mankey", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/56.png" },
    new Pokemon { Id = 57, Name = "Primeape", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/57.png" },
    new Pokemon { Id = 58, Name = "Growlithe", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/58.png" },
    new Pokemon { Id = 59, Name = "Arcanine", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/59.png" },
    new Pokemon { Id = 60, Name = "Poliwag", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/60.png" },
    new Pokemon { Id = 61, Name = "Poliwhirl", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/61.png" },
    new Pokemon { Id = 62, Name = "Poliwrath", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/62.png" },
    new Pokemon { Id = 63, Name = "Abra", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/63.png" },
    new Pokemon { Id = 64, Name = "Kadabra", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/64.png" },
    new Pokemon { Id = 65, Name = "Alakazam", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/65.png" },
    new Pokemon { Id = 66, Name = "Machop", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/66.png" },
    new Pokemon { Id = 67, Name = "Machoke", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/67.png" },
    new Pokemon { Id = 68, Name = "Machamp", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/68.png" },
    new Pokemon { Id = 69, Name = "Bellsprout", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/69.png" },
    new Pokemon { Id = 70, Name = "Weepinbell", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/70.png" },
    new Pokemon { Id = 71, Name = "Victreebel", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/71.png" },
    new Pokemon { Id = 72, Name = "Tentacool", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/72.png" },
    new Pokemon { Id = 73, Name = "Tentacruel", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/73.png" },
    new Pokemon { Id = 74, Name = "Geodude", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/74.png" },
    new Pokemon { Id = 75, Name = "Graveler", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/75.png" },
    new Pokemon { Id = 76, Name = "Golem", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/76.png" },
    new Pokemon { Id = 77, Name = "Ponyta", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/77.png" },
    new Pokemon { Id = 78, Name = "Rapidash", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/78.png" },
    new Pokemon { Id = 79, Name = "Slowpoke", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/79.png" },
    new Pokemon { Id = 80, Name = "Slowbro", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/80.png" },
    new Pokemon { Id = 81, Name = "Magnemite", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/81.png" },
    new Pokemon { Id = 82, Name = "Magneton", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/82.png" },
    new Pokemon { Id = 83, Name = "Farfetch'd", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/83.png" },
    new Pokemon { Id = 84, Name = "Doduo", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/84.png" },
    new Pokemon { Id = 85, Name = "Dodrio", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/85.png" },
    new Pokemon { Id = 86, Name = "Seel", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/86.png" },
    new Pokemon { Id = 87, Name = "Dewgong", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/87.png" },
    new Pokemon { Id = 88, Name = "Grimer", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/88.png" },
    new Pokemon { Id = 89, Name = "Muk", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/89.png" },
    new Pokemon { Id = 90, Name = "Shellder", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/90.png" },
    new Pokemon { Id = 91, Name = "Cloyster", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/91.png" },
    new Pokemon { Id = 92, Name = "Gastly", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/92.png" },
    new Pokemon { Id = 93, Name = "Haunter", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/93.png" },
    new Pokemon { Id = 94, Name = "Gengar", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/94.png" },
    new Pokemon { Id = 95, Name = "Onix", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/95.png" },
    new Pokemon { Id = 96, Name = "Drowzee", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/96.png" },
    new Pokemon { Id = 97, Name = "Hypno", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/97.png" },
    new Pokemon { Id = 98, Name = "Krabby", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/98.png" },
    new Pokemon { Id = 99, Name = "Kingler", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/99.png" },
    new Pokemon { Id = 100, Name = "Voltorb", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/100.png" },
    new Pokemon { Id = 101, Name = "Electrode", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/101.png" },
    new Pokemon { Id = 102, Name = "Exeggcute", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/102.png" },
    new Pokemon { Id = 103, Name = "Exeggutor", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/103.png" },
    new Pokemon { Id = 104, Name = "Cubone", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/104.png" },
    new Pokemon { Id = 105, Name = "Marowak", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/105.png" },
    new Pokemon { Id = 106, Name = "Hitmonlee", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/106.png" },
    new Pokemon { Id = 107, Name = "Hitmonchan", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/107.png" },
    new Pokemon { Id = 108, Name = "Lickitung", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/108.png" },
    new Pokemon { Id = 109, Name = "Koffing", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/109.png" },
    new Pokemon { Id = 110, Name = "Weezing", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/110.png" },
    new Pokemon { Id = 111, Name = "Rhyhorn", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/111.png" },
    new Pokemon { Id = 112, Name = "Rhydon", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/112.png" },
    new Pokemon { Id = 113, Name = "Chansey", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/113.png" },
    new Pokemon { Id = 114, Name = "Tangela", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/114.png" },
    new Pokemon { Id = 115, Name = "Kangaskhan", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/115.png" },
    new Pokemon { Id = 116, Name = "Horsea", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/116.png" },
    new Pokemon { Id = 117, Name = "Seadra", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/117.png" },
    new Pokemon { Id = 118, Name = "Goldeen", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/118.png" },
    new Pokemon { Id = 119, Name = "Seaking", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/119.png" },
    new Pokemon { Id = 120, Name = "Staryu", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/120.png" },
    new Pokemon { Id = 121, Name = "Starmie", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/121.png" },
    new Pokemon { Id = 122, Name = "Mr. Mime", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/122.png" },
    new Pokemon { Id = 123, Name = "Scyther", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/123.png" },
    new Pokemon { Id = 124, Name = "Jynx", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/124.png" },
    new Pokemon { Id = 125, Name = "Electabuzz", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/125.png" },
    new Pokemon { Id = 126, Name = "Magmar", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/126.png" },
    new Pokemon { Id = 127, Name = "Pinsir", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/127.png" },
    new Pokemon { Id = 128, Name = "Tauros", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/128.png" },
    new Pokemon { Id = 129, Name = "Magikarp", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/129.png" },
    new Pokemon { Id = 130, Name = "Gyarados", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/130.png" },
    new Pokemon { Id = 131, Name = "Lapras", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/131.png" },
    new Pokemon { Id = 132, Name = "Ditto", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png" },
    new Pokemon { Id = 133, Name = "Eevee", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/133.png" },
    new Pokemon { Id = 134, Name = "Vaporeon", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/134.png" },
    new Pokemon { Id = 135, Name = "Jolteon", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/135.png" },
    new Pokemon { Id = 136, Name = "Flareon", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/136.png" },
    new Pokemon { Id = 137, Name = "Porygon", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/137.png" },
    new Pokemon { Id = 138, Name = "Omanyte", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/138.png" },
    new Pokemon { Id = 139, Name = "Omastar", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/139.png" },
    new Pokemon { Id = 140, Name = "Kabuto", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/140.png" },
    new Pokemon { Id = 141, Name = "Kabutops", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/141.png" },
    new Pokemon { Id = 142, Name = "Aerodactyl", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/142.png" },
    new Pokemon { Id = 143, Name = "Snorlax", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/143.png" },
    new Pokemon { Id = 144, Name = "Articuno", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/144.png" },
    new Pokemon { Id = 145, Name = "Zapdos", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/145.png" },
    new Pokemon { Id = 146, Name = "Moltres", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/146.png" },
    new Pokemon { Id = 147, Name = "Dratini", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/147.png" },
    new Pokemon { Id = 148, Name = "Dragonair", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/148.png" },
    new Pokemon { Id = 149, Name = "Dragonite", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/149.png" },
    new Pokemon { Id = 150, Name = "Mewtwo", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/150.png" },
    new Pokemon { Id = 151, Name = "Mew", Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/151.png" }

        );
        modelBuilder.Entity<PokemonType>().HasData(

    new PokemonType { Id = 1, PokemonId = 1, PokeTypeId = 12 },
    new PokemonType { Id = 2, PokemonId = 1, PokeTypeId = 4 },
    new PokemonType { Id = 3, PokemonId = 2, PokeTypeId = 12 },
    new PokemonType { Id = 4, PokemonId = 2, PokeTypeId = 4 },
    new PokemonType { Id = 5, PokemonId = 3, PokeTypeId = 12 },
    new PokemonType { Id = 6, PokemonId = 3, PokeTypeId = 4 },
    new PokemonType { Id = 7, PokemonId = 4, PokeTypeId = 10 },
    new PokemonType { Id = 8, PokemonId = 5, PokeTypeId = 10 },
    new PokemonType { Id = 9, PokemonId = 6, PokeTypeId = 10 },
    new PokemonType { Id = 10, PokemonId = 6, PokeTypeId = 3 },
    new PokemonType { Id = 11, PokemonId = 7, PokeTypeId = 11 },
    new PokemonType { Id = 12, PokemonId = 8, PokeTypeId = 11 },
    new PokemonType { Id = 13, PokemonId = 9, PokeTypeId = 11 },
    new PokemonType { Id = 14, PokemonId = 10, PokeTypeId = 7 },
    new PokemonType { Id = 15, PokemonId = 11, PokeTypeId = 7 },
    new PokemonType { Id = 16, PokemonId = 12, PokeTypeId = 7 },
    new PokemonType { Id = 17, PokemonId = 12, PokeTypeId = 3 },
    new PokemonType { Id = 18, PokemonId = 13, PokeTypeId = 7 },
    new PokemonType { Id = 19, PokemonId = 13, PokeTypeId = 4 },
    new PokemonType { Id = 20, PokemonId = 14, PokeTypeId = 7 },
    new PokemonType { Id = 21, PokemonId = 14, PokeTypeId = 4 },
    new PokemonType { Id = 22, PokemonId = 15, PokeTypeId = 7 },
    new PokemonType { Id = 23, PokemonId = 15, PokeTypeId = 4 },
    new PokemonType { Id = 24, PokemonId = 16, PokeTypeId = 1 },
    new PokemonType { Id = 25, PokemonId = 16, PokeTypeId = 3 },
    new PokemonType { Id = 26, PokemonId = 17, PokeTypeId = 1 },
    new PokemonType { Id = 27, PokemonId = 17, PokeTypeId = 3 },
    new PokemonType { Id = 28, PokemonId = 18, PokeTypeId = 1 },
    new PokemonType { Id = 29, PokemonId = 18, PokeTypeId = 3 },
    new PokemonType { Id = 30, PokemonId = 19, PokeTypeId = 1 },
    new PokemonType { Id = 31, PokemonId = 20, PokeTypeId = 1 },
    new PokemonType { Id = 32, PokemonId = 21, PokeTypeId = 1 },
    new PokemonType { Id = 33, PokemonId = 21, PokeTypeId = 3 },
    new PokemonType { Id = 34, PokemonId = 22, PokeTypeId = 1 },
    new PokemonType { Id = 35, PokemonId = 22, PokeTypeId = 3 },
    new PokemonType { Id = 36, PokemonId = 23, PokeTypeId = 4 },
    new PokemonType { Id = 37, PokemonId = 24, PokeTypeId = 4 },
    new PokemonType { Id = 38, PokemonId = 25, PokeTypeId = 13 },
    new PokemonType { Id = 39, PokemonId = 26, PokeTypeId = 13 },
    new PokemonType { Id = 40, PokemonId = 27, PokeTypeId = 5 },
    new PokemonType { Id = 41, PokemonId = 28, PokeTypeId = 5 },
    new PokemonType { Id = 42, PokemonId = 29, PokeTypeId = 4 },
    new PokemonType { Id = 43, PokemonId = 30, PokeTypeId = 4 },
    new PokemonType { Id = 44, PokemonId = 31, PokeTypeId = 4 },
    new PokemonType { Id = 45, PokemonId = 31, PokeTypeId = 5 },
    new PokemonType { Id = 46, PokemonId = 32, PokeTypeId = 4 },
    new PokemonType { Id = 47, PokemonId = 33, PokeTypeId = 4 },
    new PokemonType { Id = 48, PokemonId = 34, PokeTypeId = 4 },
    new PokemonType { Id = 49, PokemonId = 34, PokeTypeId = 5 },
    new PokemonType { Id = 50, PokemonId = 35, PokeTypeId = 18 },
    new PokemonType { Id = 51, PokemonId = 36, PokeTypeId = 18 },
    new PokemonType { Id = 52, PokemonId = 37, PokeTypeId = 10 },
    new PokemonType { Id = 53, PokemonId = 38, PokeTypeId = 10 },
    new PokemonType { Id = 54, PokemonId = 39, PokeTypeId = 1 },
    new PokemonType { Id = 55, PokemonId = 39, PokeTypeId = 18 },
    new PokemonType { Id = 56, PokemonId = 40, PokeTypeId = 1 },
    new PokemonType { Id = 57, PokemonId = 40, PokeTypeId = 18 },
    new PokemonType { Id = 58, PokemonId = 41, PokeTypeId = 4 },
    new PokemonType { Id = 59, PokemonId = 41, PokeTypeId = 3 },
    new PokemonType { Id = 60, PokemonId = 42, PokeTypeId = 4 },
    new PokemonType { Id = 61, PokemonId = 42, PokeTypeId = 3 },
    new PokemonType { Id = 62, PokemonId = 43, PokeTypeId = 12 },
    new PokemonType { Id = 63, PokemonId = 43, PokeTypeId = 4 },
    new PokemonType { Id = 64, PokemonId = 44, PokeTypeId = 12 },
    new PokemonType { Id = 65, PokemonId = 44, PokeTypeId = 4 },
    new PokemonType { Id = 66, PokemonId = 45, PokeTypeId = 12 },
    new PokemonType { Id = 67, PokemonId = 45, PokeTypeId = 4 },
    new PokemonType { Id = 68, PokemonId = 46, PokeTypeId = 7 },
    new PokemonType { Id = 69, PokemonId = 46, PokeTypeId = 12 },
    new PokemonType { Id = 70, PokemonId = 47, PokeTypeId = 7 },
    new PokemonType { Id = 71, PokemonId = 47, PokeTypeId = 12 },
    new PokemonType { Id = 72, PokemonId = 48, PokeTypeId = 7 },
    new PokemonType { Id = 73, PokemonId = 48, PokeTypeId = 4 },
    new PokemonType { Id = 74, PokemonId = 49, PokeTypeId = 7 },
    new PokemonType { Id = 75, PokemonId = 49, PokeTypeId = 4 },
    new PokemonType { Id = 76, PokemonId = 50, PokeTypeId = 5 },
    new PokemonType { Id = 77, PokemonId = 51, PokeTypeId = 5 },
    new PokemonType { Id = 78, PokemonId = 52, PokeTypeId = 1 },
    new PokemonType { Id = 79, PokemonId = 53, PokeTypeId = 1 },
    new PokemonType { Id = 80, PokemonId = 54, PokeTypeId = 11 },
    new PokemonType { Id = 81, PokemonId = 55, PokeTypeId = 11 },
    new PokemonType { Id = 82, PokemonId = 56, PokeTypeId = 2 },
    new PokemonType { Id = 83, PokemonId = 57, PokeTypeId = 2 },
    new PokemonType { Id = 84, PokemonId = 58, PokeTypeId = 10 },
    new PokemonType { Id = 85, PokemonId = 59, PokeTypeId = 10 },
    new PokemonType { Id = 86, PokemonId = 60, PokeTypeId = 11 },
    new PokemonType { Id = 87, PokemonId = 61, PokeTypeId = 11 },
    new PokemonType { Id = 88, PokemonId = 62, PokeTypeId = 11 },
    new PokemonType { Id = 89, PokemonId = 62, PokeTypeId = 2 },
    new PokemonType { Id = 90, PokemonId = 63, PokeTypeId = 14 },
    new PokemonType { Id = 91, PokemonId = 64, PokeTypeId = 14 },
    new PokemonType { Id = 92, PokemonId = 65, PokeTypeId = 14 },
    new PokemonType { Id = 93, PokemonId = 66, PokeTypeId = 2 },
    new PokemonType { Id = 94, PokemonId = 67, PokeTypeId = 2 },
    new PokemonType { Id = 95, PokemonId = 68, PokeTypeId = 2 },
    new PokemonType { Id = 96, PokemonId = 69, PokeTypeId = 12 },
    new PokemonType { Id = 97, PokemonId = 69, PokeTypeId = 4 },
    new PokemonType { Id = 98, PokemonId = 70, PokeTypeId = 12 },
    new PokemonType { Id = 99, PokemonId = 70, PokeTypeId = 4 },
    new PokemonType { Id = 100, PokemonId = 71, PokeTypeId = 12 },
    new PokemonType { Id = 101, PokemonId = 71, PokeTypeId = 4 },
    new PokemonType { Id = 102, PokemonId = 72, PokeTypeId = 11 },
    new PokemonType { Id = 103, PokemonId = 72, PokeTypeId = 4 },
    new PokemonType { Id = 104, PokemonId = 73, PokeTypeId = 11 },
    new PokemonType { Id = 105, PokemonId = 73, PokeTypeId = 4 },
    new PokemonType { Id = 106, PokemonId = 74, PokeTypeId = 6 },
    new PokemonType { Id = 107, PokemonId = 74, PokeTypeId = 5 },
    new PokemonType { Id = 108, PokemonId = 75, PokeTypeId = 6 },
    new PokemonType { Id = 109, PokemonId = 75, PokeTypeId = 5 },
    new PokemonType { Id = 110, PokemonId = 76, PokeTypeId = 6 },
    new PokemonType { Id = 111, PokemonId = 76, PokeTypeId = 5 },
    new PokemonType { Id = 112, PokemonId = 77, PokeTypeId = 10 },
    new PokemonType { Id = 113, PokemonId = 78, PokeTypeId = 10 },
    new PokemonType { Id = 114, PokemonId = 79, PokeTypeId = 11 },
    new PokemonType { Id = 115, PokemonId = 79, PokeTypeId = 14 },
    new PokemonType { Id = 116, PokemonId = 80, PokeTypeId = 11 },
    new PokemonType { Id = 117, PokemonId = 80, PokeTypeId = 14 },
    new PokemonType { Id = 118, PokemonId = 81, PokeTypeId = 13 },
    new PokemonType { Id = 119, PokemonId = 81, PokeTypeId = 9 },
    new PokemonType { Id = 120, PokemonId = 82, PokeTypeId = 13 },
    new PokemonType { Id = 121, PokemonId = 82, PokeTypeId = 9 },
    new PokemonType { Id = 122, PokemonId = 83, PokeTypeId = 1 },
    new PokemonType { Id = 123, PokemonId = 83, PokeTypeId = 3 },
    new PokemonType { Id = 124, PokemonId = 84, PokeTypeId = 1 },
    new PokemonType { Id = 125, PokemonId = 84, PokeTypeId = 3 },
    new PokemonType { Id = 126, PokemonId = 85, PokeTypeId = 1 },
    new PokemonType { Id = 127, PokemonId = 85, PokeTypeId = 3 },
    new PokemonType { Id = 128, PokemonId = 86, PokeTypeId = 11 },
    new PokemonType { Id = 129, PokemonId = 87, PokeTypeId = 11 },
    new PokemonType { Id = 130, PokemonId = 87, PokeTypeId = 15 },
    new PokemonType { Id = 131, PokemonId = 88, PokeTypeId = 4 },
    new PokemonType { Id = 132, PokemonId = 89, PokeTypeId = 4 },
    new PokemonType { Id = 133, PokemonId = 90, PokeTypeId = 11 },
    new PokemonType { Id = 134, PokemonId = 91, PokeTypeId = 11 },
    new PokemonType { Id = 135, PokemonId = 91, PokeTypeId = 15 },
    new PokemonType { Id = 136, PokemonId = 92, PokeTypeId = 8 },
    new PokemonType { Id = 137, PokemonId = 92, PokeTypeId = 4 },
    new PokemonType { Id = 138, PokemonId = 93, PokeTypeId = 8 },
    new PokemonType { Id = 139, PokemonId = 93, PokeTypeId = 4 },
    new PokemonType { Id = 140, PokemonId = 94, PokeTypeId = 8 },
    new PokemonType { Id = 141, PokemonId = 94, PokeTypeId = 4 },
    new PokemonType { Id = 142, PokemonId = 95, PokeTypeId = 6 },
    new PokemonType { Id = 143, PokemonId = 95, PokeTypeId = 5 },
    new PokemonType { Id = 144, PokemonId = 96, PokeTypeId = 14 },
    new PokemonType { Id = 145, PokemonId = 97, PokeTypeId = 14 },
    new PokemonType { Id = 146, PokemonId = 98, PokeTypeId = 11 },
    new PokemonType { Id = 147, PokemonId = 99, PokeTypeId = 11 },
    new PokemonType { Id = 148, PokemonId = 100, PokeTypeId = 13 },
    new PokemonType { Id = 149, PokemonId = 101, PokeTypeId = 13 },
    new PokemonType { Id = 150, PokemonId = 102, PokeTypeId = 12 },
    new PokemonType { Id = 151, PokemonId = 102, PokeTypeId = 14 },
    new PokemonType { Id = 152, PokemonId = 103, PokeTypeId = 12 },
    new PokemonType { Id = 153, PokemonId = 103, PokeTypeId = 14 },
    new PokemonType { Id = 154, PokemonId = 104, PokeTypeId = 5 },
    new PokemonType { Id = 155, PokemonId = 105, PokeTypeId = 5 },
    new PokemonType { Id = 156, PokemonId = 106, PokeTypeId = 2 },
    new PokemonType { Id = 157, PokemonId = 107, PokeTypeId = 2 },
    new PokemonType { Id = 158, PokemonId = 108, PokeTypeId = 1 },
    new PokemonType { Id = 159, PokemonId = 109, PokeTypeId = 4 },
    new PokemonType { Id = 160, PokemonId = 110, PokeTypeId = 4 },
    new PokemonType { Id = 161, PokemonId = 111, PokeTypeId = 5 },
    new PokemonType { Id = 162, PokemonId = 111, PokeTypeId = 6 },
    new PokemonType { Id = 163, PokemonId = 112, PokeTypeId = 5 },
    new PokemonType { Id = 164, PokemonId = 112, PokeTypeId = 6 },
    new PokemonType { Id = 165, PokemonId = 113, PokeTypeId = 1 },
    new PokemonType { Id = 166, PokemonId = 114, PokeTypeId = 12 },
    new PokemonType { Id = 167, PokemonId = 115, PokeTypeId = 1 },
    new PokemonType { Id = 168, PokemonId = 116, PokeTypeId = 11 },
    new PokemonType { Id = 169, PokemonId = 117, PokeTypeId = 11 },
    new PokemonType { Id = 170, PokemonId = 118, PokeTypeId = 11 },
    new PokemonType { Id = 171, PokemonId = 119, PokeTypeId = 11 },
    new PokemonType { Id = 172, PokemonId = 120, PokeTypeId = 11 },
    new PokemonType { Id = 173, PokemonId = 121, PokeTypeId = 11 },
    new PokemonType { Id = 174, PokemonId = 121, PokeTypeId = 14 },
    new PokemonType { Id = 175, PokemonId = 122, PokeTypeId = 14 },
    new PokemonType { Id = 176, PokemonId = 122, PokeTypeId = 18 },
    new PokemonType { Id = 177, PokemonId = 123, PokeTypeId = 7 },
    new PokemonType { Id = 178, PokemonId = 123, PokeTypeId = 3 },
    new PokemonType { Id = 179, PokemonId = 124, PokeTypeId = 15 },
    new PokemonType { Id = 180, PokemonId = 124, PokeTypeId = 14 },
    new PokemonType { Id = 181, PokemonId = 125, PokeTypeId = 13 },
    new PokemonType { Id = 182, PokemonId = 126, PokeTypeId = 10 },
    new PokemonType { Id = 183, PokemonId = 127, PokeTypeId = 7 },
    new PokemonType { Id = 184, PokemonId = 128, PokeTypeId = 1 },
    new PokemonType { Id = 185, PokemonId = 129, PokeTypeId = 11 },
    new PokemonType { Id = 186, PokemonId = 130, PokeTypeId = 11 },
    new PokemonType { Id = 187, PokemonId = 130, PokeTypeId = 3 },
    new PokemonType { Id = 188, PokemonId = 131, PokeTypeId = 11 },
    new PokemonType { Id = 189, PokemonId = 131, PokeTypeId = 15 },
    new PokemonType { Id = 190, PokemonId = 132, PokeTypeId = 1 },
    new PokemonType { Id = 191, PokemonId = 133, PokeTypeId = 1 },
    new PokemonType { Id = 192, PokemonId = 134, PokeTypeId = 11 },
    new PokemonType { Id = 193, PokemonId = 135, PokeTypeId = 13 },
    new PokemonType { Id = 194, PokemonId = 136, PokeTypeId = 10 },
    new PokemonType { Id = 195, PokemonId = 137, PokeTypeId = 1 },
    new PokemonType { Id = 196, PokemonId = 138, PokeTypeId = 6 },
    new PokemonType { Id = 197, PokemonId = 138, PokeTypeId = 11 },
    new PokemonType { Id = 198, PokemonId = 139, PokeTypeId = 6 },
    new PokemonType { Id = 199, PokemonId = 139, PokeTypeId = 11 },
    new PokemonType { Id = 200, PokemonId = 140, PokeTypeId = 6 },
    new PokemonType { Id = 201, PokemonId = 140, PokeTypeId = 11 },
    new PokemonType { Id = 202, PokemonId = 141, PokeTypeId = 6 },
    new PokemonType { Id = 203, PokemonId = 141, PokeTypeId = 11 },
    new PokemonType { Id = 204, PokemonId = 142, PokeTypeId = 6 },
    new PokemonType { Id = 205, PokemonId = 142, PokeTypeId = 3 },
    new PokemonType { Id = 206, PokemonId = 143, PokeTypeId = 1 },
    new PokemonType { Id = 207, PokemonId = 144, PokeTypeId = 15 },
    new PokemonType { Id = 208, PokemonId = 144, PokeTypeId = 3 },
    new PokemonType { Id = 209, PokemonId = 145, PokeTypeId = 13 },
    new PokemonType { Id = 210, PokemonId = 145, PokeTypeId = 3 },
    new PokemonType { Id = 211, PokemonId = 146, PokeTypeId = 10 },
    new PokemonType { Id = 212, PokemonId = 146, PokeTypeId = 3 },
    new PokemonType { Id = 213, PokemonId = 147, PokeTypeId = 16 },
    new PokemonType { Id = 214, PokemonId = 148, PokeTypeId = 16 },
    new PokemonType { Id = 215, PokemonId = 149, PokeTypeId = 16 },
    new PokemonType { Id = 216, PokemonId = 149, PokeTypeId = 3 },
    new PokemonType { Id = 217, PokemonId = 150, PokeTypeId = 14 },
    new PokemonType { Id = 218, PokemonId = 151, PokeTypeId = 14 }

        );
        modelBuilder.Entity<PokemonLearnableMove>().HasData(

    new PokemonLearnableMove
    {
        Id = 1,
        PokemonId = 1,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 2,
        PokemonId = 1,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 3,
        PokemonId = 1,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 4,
        PokemonId = 1,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 5,
        PokemonId = 1,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 6,
        PokemonId = 1,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 7,
        PokemonId = 1,
        MoveId = 70
    },
    new PokemonLearnableMove
    {
        Id = 8,
        PokemonId = 1,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 9,
        PokemonId = 1,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 10,
        PokemonId = 1,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 11,
        PokemonId = 1,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 12,
        PokemonId = 1,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 13,
        PokemonId = 2,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 14,
        PokemonId = 2,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 15,
        PokemonId = 2,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 16,
        PokemonId = 2,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 17,
        PokemonId = 2,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 18,
        PokemonId = 2,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 19,
        PokemonId = 2,
        MoveId = 70
    },
    new PokemonLearnableMove
    {
        Id = 20,
        PokemonId = 2,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 21,
        PokemonId = 2,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 22,
        PokemonId = 2,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 23,
        PokemonId = 2,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 24,
        PokemonId = 2,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 25,
        PokemonId = 3,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 26,
        PokemonId = 3,
        MoveId = 26
    },
    new PokemonLearnableMove
    {
        Id = 27,
        PokemonId = 3,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 28,
        PokemonId = 3,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 29,
        PokemonId = 3,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 30,
        PokemonId = 3,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 31,
        PokemonId = 3,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 32,
        PokemonId = 3,
        MoveId = 70
    },
    new PokemonLearnableMove
    {
        Id = 33,
        PokemonId = 3,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 34,
        PokemonId = 3,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 35,
        PokemonId = 3,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 36,
        PokemonId = 3,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 37,
        PokemonId = 3,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 38,
        PokemonId = 4,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 39,
        PokemonId = 4,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 40,
        PokemonId = 4,
        MoveId = 18
    },
    new PokemonLearnableMove
    {
        Id = 41,
        PokemonId = 4,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 42,
        PokemonId = 4,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 43,
        PokemonId = 4,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 44,
        PokemonId = 4,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 45,
        PokemonId = 4,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 46,
        PokemonId = 4,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 47,
        PokemonId = 4,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 48,
        PokemonId = 4,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 49,
        PokemonId = 4,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 50,
        PokemonId = 4,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 51,
        PokemonId = 4,
        MoveId = 61
    },
    new PokemonLearnableMove
    {
        Id = 52,
        PokemonId = 4,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 53,
        PokemonId = 4,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 54,
        PokemonId = 5,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 55,
        PokemonId = 5,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 56,
        PokemonId = 5,
        MoveId = 18
    },
    new PokemonLearnableMove
    {
        Id = 57,
        PokemonId = 5,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 58,
        PokemonId = 5,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 59,
        PokemonId = 5,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 60,
        PokemonId = 5,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 61,
        PokemonId = 5,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 62,
        PokemonId = 5,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 63,
        PokemonId = 5,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 64,
        PokemonId = 5,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 65,
        PokemonId = 5,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 66,
        PokemonId = 5,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 67,
        PokemonId = 5,
        MoveId = 61
    },
    new PokemonLearnableMove
    {
        Id = 68,
        PokemonId = 5,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 69,
        PokemonId = 5,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 70,
        PokemonId = 6,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 71,
        PokemonId = 6,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 72,
        PokemonId = 6,
        MoveId = 18
    },
    new PokemonLearnableMove
    {
        Id = 73,
        PokemonId = 6,
        MoveId = 26
    },
    new PokemonLearnableMove
    {
        Id = 74,
        PokemonId = 6,
        MoveId = 27
    },
    new PokemonLearnableMove
    {
        Id = 75,
        PokemonId = 6,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 76,
        PokemonId = 6,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 77,
        PokemonId = 6,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 78,
        PokemonId = 6,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 79,
        PokemonId = 6,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 80,
        PokemonId = 6,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 81,
        PokemonId = 6,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 82,
        PokemonId = 6,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 83,
        PokemonId = 6,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 84,
        PokemonId = 6,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 85,
        PokemonId = 6,
        MoveId = 61
    },
    new PokemonLearnableMove
    {
        Id = 86,
        PokemonId = 6,
        MoveId = 51
    },
    new PokemonLearnableMove
    {
        Id = 87,
        PokemonId = 6,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 88,
        PokemonId = 6,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 89,
        PokemonId = 7,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 90,
        PokemonId = 7,
        MoveId = 14
    },
    new PokemonLearnableMove
    {
        Id = 91,
        PokemonId = 7,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 92,
        PokemonId = 7,
        MoveId = 18
    },
    new PokemonLearnableMove
    {
        Id = 93,
        PokemonId = 7,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 94,
        PokemonId = 7,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 95,
        PokemonId = 7,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 96,
        PokemonId = 7,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 97,
        PokemonId = 7,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 98,
        PokemonId = 7,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 99,
        PokemonId = 7,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 100,
        PokemonId = 7,
        MoveId = 50
    },
new PokemonLearnableMove
{
    Id = 101,
    PokemonId = 7,
    MoveId = 58
},
    new PokemonLearnableMove
    {
        Id = 102,
        PokemonId = 7,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 103,
        PokemonId = 7,
        MoveId = 55
    },
    new PokemonLearnableMove
    {
        Id = 104,
        PokemonId = 7,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 105,
        PokemonId = 7,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 106,
        PokemonId = 8,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 107,
        PokemonId = 8,
        MoveId = 14
    },
    new PokemonLearnableMove
    {
        Id = 108,
        PokemonId = 8,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 109,
        PokemonId = 8,
        MoveId = 18
    },
    new PokemonLearnableMove
    {
        Id = 110,
        PokemonId = 8,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 111,
        PokemonId = 8,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 112,
        PokemonId = 8,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 113,
        PokemonId = 8,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 114,
        PokemonId = 8,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 115,
        PokemonId = 8,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 116,
        PokemonId = 8,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 117,
        PokemonId = 8,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 118,
        PokemonId = 8,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 119,
        PokemonId = 8,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 120,
        PokemonId = 8,
        MoveId = 55
    },
    new PokemonLearnableMove
    {
        Id = 121,
        PokemonId = 8,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 122,
        PokemonId = 8,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 123,
        PokemonId = 9,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 124,
        PokemonId = 9,
        MoveId = 14
    },
    new PokemonLearnableMove
    {
        Id = 125,
        PokemonId = 9,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 126,
        PokemonId = 9,
        MoveId = 18
    },
    new PokemonLearnableMove
    {
        Id = 127,
        PokemonId = 9,
        MoveId = 26
    },
    new PokemonLearnableMove
    {
        Id = 128,
        PokemonId = 9,
        MoveId = 27
    },
    new PokemonLearnableMove
    {
        Id = 129,
        PokemonId = 9,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 130,
        PokemonId = 9,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 131,
        PokemonId = 9,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 132,
        PokemonId = 9,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 133,
        PokemonId = 9,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 134,
        PokemonId = 9,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 135,
        PokemonId = 9,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 136,
        PokemonId = 9,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 137,
        PokemonId = 9,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 138,
        PokemonId = 9,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 139,
        PokemonId = 9,
        MoveId = 55
    },
    new PokemonLearnableMove
    {
        Id = 140,
        PokemonId = 9,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 141,
        PokemonId = 9,
        MoveId = 72
    },
    new PokemonLearnableMove
    {
        Id = 142,
        PokemonId = 9,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 143,
        PokemonId = 12,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 144,
        PokemonId = 12,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 145,
        PokemonId = 12,
        MoveId = 29
    },
    new PokemonLearnableMove
    {
        Id = 146,
        PokemonId = 12,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 147,
        PokemonId = 12,
        MoveId = 30
    },
    new PokemonLearnableMove
    {
        Id = 148,
        PokemonId = 12,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 149,
        PokemonId = 12,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 150,
        PokemonId = 12,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 151,
        PokemonId = 12,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 152,
        PokemonId = 12,
        MoveId = 70
    },
    new PokemonLearnableMove
    {
        Id = 153,
        PokemonId = 12,
        MoveId = 46
    },
    new PokemonLearnableMove
    {
        Id = 154,
        PokemonId = 12,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 155,
        PokemonId = 12,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 156,
        PokemonId = 12,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 157,
        PokemonId = 12,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 158,
        PokemonId = 12,
        MoveId = 51
    },
    new PokemonLearnableMove
    {
        Id = 159,
        PokemonId = 12,
        MoveId = 89
    },
    new PokemonLearnableMove
    {
        Id = 160,
        PokemonId = 15,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 161,
        PokemonId = 15,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 162,
        PokemonId = 15,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 163,
        PokemonId = 15,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 164,
        PokemonId = 15,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 165,
        PokemonId = 15,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 166,
        PokemonId = 15,
        MoveId = 70
    },
    new PokemonLearnableMove
    {
        Id = 167,
        PokemonId = 15,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 168,
        PokemonId = 15,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 169,
        PokemonId = 15,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 170,
        PokemonId = 15,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 171,
        PokemonId = 15,
        MoveId = 51
    },
    new PokemonLearnableMove
    {
        Id = 172,
        PokemonId = 15,
        MoveId = 89
    },
    new PokemonLearnableMove
    {
        Id = 173,
        PokemonId = 15,
        MoveId = 66
    },
    new PokemonLearnableMove
    {
        Id = 174,
        PokemonId = 15,
        MoveId = 81
    },
    new PokemonLearnableMove
    {
        Id = 175,
        PokemonId = 15,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 176,
        PokemonId = 16,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 177,
        PokemonId = 16,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 178,
        PokemonId = 16,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 179,
        PokemonId = 16,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 180,
        PokemonId = 16,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 181,
        PokemonId = 16,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 182,
        PokemonId = 16,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 183,
        PokemonId = 16,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 184,
        PokemonId = 16,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 185,
        PokemonId = 16,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 186,
        PokemonId = 16,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 187,
        PokemonId = 16,
        MoveId = 88
    },
    new PokemonLearnableMove
    {
        Id = 188,
        PokemonId = 16,
        MoveId = 89
    },
    new PokemonLearnableMove
    {
        Id = 189,
        PokemonId = 16,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 190,
        PokemonId = 17,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 191,
        PokemonId = 17,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 192,
        PokemonId = 17,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 193,
        PokemonId = 17,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 194,
        PokemonId = 17,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 195,
        PokemonId = 17,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 196,
        PokemonId = 17,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 197,
        PokemonId = 17,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 198,
        PokemonId = 17,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 199,
        PokemonId = 17,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 200,
        PokemonId = 17,
        MoveId = 87
    },
new PokemonLearnableMove
{
    Id = 201,
    PokemonId = 17,
    MoveId = 88
},
    new PokemonLearnableMove
    {
        Id = 202,
        PokemonId = 17,
        MoveId = 89
    },
    new PokemonLearnableMove
    {
        Id = 203,
        PokemonId = 17,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 204,
        PokemonId = 18,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 205,
        PokemonId = 18,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 206,
        PokemonId = 18,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 207,
        PokemonId = 18,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 208,
        PokemonId = 18,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 209,
        PokemonId = 18,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 210,
        PokemonId = 18,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 211,
        PokemonId = 18,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 212,
        PokemonId = 18,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 213,
        PokemonId = 18,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 214,
        PokemonId = 18,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 215,
        PokemonId = 18,
        MoveId = 88
    },
    new PokemonLearnableMove
    {
        Id = 216,
        PokemonId = 18,
        MoveId = 89
    },
    new PokemonLearnableMove
    {
        Id = 217,
        PokemonId = 18,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 218,
        PokemonId = 19,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 219,
        PokemonId = 19,
        MoveId = 14
    },
    new PokemonLearnableMove
    {
        Id = 220,
        PokemonId = 19,
        MoveId = 24
    },
    new PokemonLearnableMove
    {
        Id = 221,
        PokemonId = 19,
        MoveId = 25
    },
    new PokemonLearnableMove
    {
        Id = 222,
        PokemonId = 19,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 223,
        PokemonId = 19,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 224,
        PokemonId = 19,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 225,
        PokemonId = 19,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 226,
        PokemonId = 19,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 227,
        PokemonId = 19,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 228,
        PokemonId = 19,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 229,
        PokemonId = 19,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 230,
        PokemonId = 19,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 231,
        PokemonId = 19,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 232,
        PokemonId = 19,
        MoveId = 88
    },
    new PokemonLearnableMove
    {
        Id = 233,
        PokemonId = 19,
        MoveId = 89
    },
    new PokemonLearnableMove
    {
        Id = 234,
        PokemonId = 19,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 235,
        PokemonId = 20,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 236,
        PokemonId = 20,
        MoveId = 14
    },
    new PokemonLearnableMove
    {
        Id = 237,
        PokemonId = 20,
        MoveId = 24
    },
    new PokemonLearnableMove
    {
        Id = 238,
        PokemonId = 20,
        MoveId = 25
    },
    new PokemonLearnableMove
    {
        Id = 239,
        PokemonId = 20,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 240,
        PokemonId = 20,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 241,
        PokemonId = 20,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 242,
        PokemonId = 20,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 243,
        PokemonId = 20,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 244,
        PokemonId = 20,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 245,
        PokemonId = 20,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 246,
        PokemonId = 20,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 247,
        PokemonId = 20,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 248,
        PokemonId = 20,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 249,
        PokemonId = 20,
        MoveId = 88
    },
    new PokemonLearnableMove
    {
        Id = 250,
        PokemonId = 20,
        MoveId = 89
    },
    new PokemonLearnableMove
    {
        Id = 251,
        PokemonId = 20,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 252,
        PokemonId = 21,
        MoveId = 4
    },
    new PokemonLearnableMove
    {
        Id = 253,
        PokemonId = 21,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 254,
        PokemonId = 21,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 255,
        PokemonId = 21,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 256,
        PokemonId = 21,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 257,
        PokemonId = 21,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 258,
        PokemonId = 21,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 259,
        PokemonId = 21,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 260,
        PokemonId = 21,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 261,
        PokemonId = 21,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 262,
        PokemonId = 21,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 263,
        PokemonId = 21,
        MoveId = 88
    },
    new PokemonLearnableMove
    {
        Id = 264,
        PokemonId = 21,
        MoveId = 89
    },
    new PokemonLearnableMove
    {
        Id = 265,
        PokemonId = 21,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 266,
        PokemonId = 22,
        MoveId = 4
    },
    new PokemonLearnableMove
    {
        Id = 267,
        PokemonId = 22,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 268,
        PokemonId = 22,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 269,
        PokemonId = 22,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 270,
        PokemonId = 22,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 271,
        PokemonId = 22,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 272,
        PokemonId = 22,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 273,
        PokemonId = 22,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 274,
        PokemonId = 22,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 275,
        PokemonId = 22,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 276,
        PokemonId = 22,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 277,
        PokemonId = 22,
        MoveId = 89
    },
    new PokemonLearnableMove
    {
        Id = 278,
        PokemonId = 22,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 279,
        PokemonId = 23,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 280,
        PokemonId = 23,
        MoveId = 26
    },
    new PokemonLearnableMove
    {
        Id = 281,
        PokemonId = 23,
        MoveId = 27
    },
    new PokemonLearnableMove
    {
        Id = 282,
        PokemonId = 23,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 283,
        PokemonId = 23,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 284,
        PokemonId = 23,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 285,
        PokemonId = 23,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 286,
        PokemonId = 23,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 287,
        PokemonId = 23,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 288,
        PokemonId = 23,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 289,
        PokemonId = 23,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 290,
        PokemonId = 23,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 291,
        PokemonId = 23,
        MoveId = 66
    },
    new PokemonLearnableMove
    {
        Id = 292,
        PokemonId = 23,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 293,
        PokemonId = 24,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 294,
        PokemonId = 24,
        MoveId = 26
    },
    new PokemonLearnableMove
    {
        Id = 295,
        PokemonId = 24,
        MoveId = 27
    },
    new PokemonLearnableMove
    {
        Id = 296,
        PokemonId = 24,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 297,
        PokemonId = 24,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 298,
        PokemonId = 24,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 299,
        PokemonId = 24,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 300,
        PokemonId = 24,
        MoveId = 34
    },
 new PokemonLearnableMove
 {
     Id = 301,
     PokemonId = 24,
     MoveId = 44
 },
    new PokemonLearnableMove
    {
        Id = 302,
        PokemonId = 24,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 303,
        PokemonId = 24,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 304,
        PokemonId = 24,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 305,
        PokemonId = 24,
        MoveId = 66
    },
    new PokemonLearnableMove
    {
        Id = 306,
        PokemonId = 24,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 307,
        PokemonId = 25,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 308,
        PokemonId = 25,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 309,
        PokemonId = 25,
        MoveId = 24
    },
    new PokemonLearnableMove
    {
        Id = 310,
        PokemonId = 25,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 311,
        PokemonId = 25,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 312,
        PokemonId = 25,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 313,
        PokemonId = 25,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 314,
        PokemonId = 25,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 315,
        PokemonId = 25,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 316,
        PokemonId = 25,
        MoveId = 70
    },
    new PokemonLearnableMove
    {
        Id = 317,
        PokemonId = 25,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 318,
        PokemonId = 25,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 319,
        PokemonId = 25,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 320,
        PokemonId = 25,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 321,
        PokemonId = 25,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 322,
        PokemonId = 25,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 323,
        PokemonId = 26,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 324,
        PokemonId = 26,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 325,
        PokemonId = 26,
        MoveId = 24
    },
    new PokemonLearnableMove
    {
        Id = 326,
        PokemonId = 26,
        MoveId = 25
    },
    new PokemonLearnableMove
    {
        Id = 327,
        PokemonId = 26,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 328,
        PokemonId = 26,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 329,
        PokemonId = 26,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 330,
        PokemonId = 26,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 331,
        PokemonId = 26,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 332,
        PokemonId = 26,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 333,
        PokemonId = 26,
        MoveId = 39
    },
    new PokemonLearnableMove
    {
        Id = 334,
        PokemonId = 26,
        MoveId = 70
    },
    new PokemonLearnableMove
    {
        Id = 335,
        PokemonId = 26,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 336,
        PokemonId = 26,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 337,
        PokemonId = 26,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 338,
        PokemonId = 26,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 339,
        PokemonId = 26,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 340,
        PokemonId = 26,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 341,
        PokemonId = 27,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 342,
        PokemonId = 27,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 343,
        PokemonId = 27,
        MoveId = 26
    },
    new PokemonLearnableMove
    {
        Id = 344,
        PokemonId = 27,
        MoveId = 27
    },
    new PokemonLearnableMove
    {
        Id = 345,
        PokemonId = 27,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 346,
        PokemonId = 27,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 347,
        PokemonId = 27,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 348,
        PokemonId = 27,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 349,
        PokemonId = 27,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 350,
        PokemonId = 27,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 351,
        PokemonId = 27,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 352,
        PokemonId = 27,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 353,
        PokemonId = 27,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 354,
        PokemonId = 27,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 355,
        PokemonId = 27,
        MoveId = 81
    },
    new PokemonLearnableMove
    {
        Id = 356,
        PokemonId = 27,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 357,
        PokemonId = 28,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 358,
        PokemonId = 28,
        MoveId = 17
    },
    new PokemonLearnableMove
    {
        Id = 359,
        PokemonId = 28,
        MoveId = 26
    },
    new PokemonLearnableMove
    {
        Id = 360,
        PokemonId = 28,
        MoveId = 27
    },
    new PokemonLearnableMove
    {
        Id = 361,
        PokemonId = 28,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 362,
        PokemonId = 28,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 363,
        PokemonId = 28,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 364,
        PokemonId = 28,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 365,
        PokemonId = 28,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 366,
        PokemonId = 28,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 367,
        PokemonId = 28,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 368,
        PokemonId = 28,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 369,
        PokemonId = 28,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 370,
        PokemonId = 28,
        MoveId = 56
    },
    new PokemonLearnableMove
    {
        Id = 371,
        PokemonId = 28,
        MoveId = 81
    },
    new PokemonLearnableMove
    {
        Id = 372,
        PokemonId = 28,
        MoveId = 78
    },
    new PokemonLearnableMove
    {
        Id = 373,
        PokemonId = 29,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 374,
        PokemonId = 29,
        MoveId = 14
    },
    new PokemonLearnableMove
    {
        Id = 375,
        PokemonId = 29,
        MoveId = 24
    },
    new PokemonLearnableMove
    {
        Id = 376,
        PokemonId = 29,
        MoveId = 25
    },
    new PokemonLearnableMove
    {
        Id = 377,
        PokemonId = 29,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 378,
        PokemonId = 29,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 379,
        PokemonId = 29,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 380,
        PokemonId = 29,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 381,
        PokemonId = 29,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 382,
        PokemonId = 29,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 383,
        PokemonId = 29,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 384,
        PokemonId = 29,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 385,
        PokemonId = 29,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 386,
        PokemonId = 29,
        MoveId = 87
    },
    new PokemonLearnableMove
    {
        Id = 387,
        PokemonId = 30,
        MoveId = 10
    },
    new PokemonLearnableMove
    {
        Id = 388,
        PokemonId = 30,
        MoveId = 14
    },
    new PokemonLearnableMove
    {
        Id = 389,
        PokemonId = 30,
        MoveId = 24
    },
    new PokemonLearnableMove
    {
        Id = 390,
        PokemonId = 30,
        MoveId = 25
    },
    new PokemonLearnableMove
    {
        Id = 391,
        PokemonId = 30,
        MoveId = 28
    },
    new PokemonLearnableMove
    {
        Id = 392,
        PokemonId = 30,
        MoveId = 6
    },
    new PokemonLearnableMove
    {
        Id = 393,
        PokemonId = 30,
        MoveId = 20
    },
    new PokemonLearnableMove
    {
        Id = 394,
        PokemonId = 30,
        MoveId = 31
    },
    new PokemonLearnableMove
    {
        Id = 395,
        PokemonId = 30,
        MoveId = 33
    },
    new PokemonLearnableMove
    {
        Id = 396,
        PokemonId = 30,
        MoveId = 34
    },
    new PokemonLearnableMove
    {
        Id = 397,
        PokemonId = 30,
        MoveId = 44
    },
    new PokemonLearnableMove
    {
        Id = 398,
        PokemonId = 30,
        MoveId = 50
    },
    new PokemonLearnableMove
    {
        Id = 399,
        PokemonId = 30,
        MoveId = 58
    },
    new PokemonLearnableMove
    {
        Id = 400,
        PokemonId = 30,
        MoveId = 87
    },
new PokemonLearnableMove
{
    Id = 401,
    PokemonId = 31,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 402,
    PokemonId = 31,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 403,
    PokemonId = 31,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 404,
    PokemonId = 31,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 405,
    PokemonId = 31,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 406,
    PokemonId = 31,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 407,
    PokemonId = 31,
    MoveId = 26
},
new PokemonLearnableMove
{
    Id = 408,
    PokemonId = 31,
    MoveId = 27
},
new PokemonLearnableMove
{
    Id = 409,
    PokemonId = 31,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 410,
    PokemonId = 31,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 411,
    PokemonId = 31,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 412,
    PokemonId = 31,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 413,
    PokemonId = 31,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 414,
    PokemonId = 31,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 415,
    PokemonId = 31,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 416,
    PokemonId = 31,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 417,
    PokemonId = 31,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 418,
    PokemonId = 31,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 419,
    PokemonId = 31,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 420,
    PokemonId = 31,
    MoveId = 72
},
new PokemonLearnableMove
{
    Id = 421,
    PokemonId = 31,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 422,
    PokemonId = 32,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 423,
    PokemonId = 32,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 424,
    PokemonId = 32,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 425,
    PokemonId = 32,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 426,
    PokemonId = 32,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 427,
    PokemonId = 32,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 428,
    PokemonId = 32,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 429,
    PokemonId = 32,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 430,
    PokemonId = 32,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 431,
    PokemonId = 32,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 432,
    PokemonId = 32,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 433,
    PokemonId = 32,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 434,
    PokemonId = 32,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 435,
    PokemonId = 32,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 436,
    PokemonId = 33,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 437,
    PokemonId = 33,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 438,
    PokemonId = 33,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 439,
    PokemonId = 33,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 440,
    PokemonId = 33,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 441,
    PokemonId = 33,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 442,
    PokemonId = 33,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 443,
    PokemonId = 33,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 444,
    PokemonId = 33,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 445,
    PokemonId = 33,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 446,
    PokemonId = 33,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 447,
    PokemonId = 33,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 448,
    PokemonId = 33,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 449,
    PokemonId = 33,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 450,
    PokemonId = 34,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 451,
    PokemonId = 34,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 452,
    PokemonId = 34,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 453,
    PokemonId = 34,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 454,
    PokemonId = 34,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 455,
    PokemonId = 34,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 456,
    PokemonId = 34,
    MoveId = 26
},
new PokemonLearnableMove
{
    Id = 457,
    PokemonId = 34,
    MoveId = 27
},
new PokemonLearnableMove
{
    Id = 458,
    PokemonId = 34,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 459,
    PokemonId = 34,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 460,
    PokemonId = 34,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 461,
    PokemonId = 34,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 462,
    PokemonId = 34,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 463,
    PokemonId = 34,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 464,
    PokemonId = 34,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 465,
    PokemonId = 34,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 466,
    PokemonId = 34,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 467,
    PokemonId = 34,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 468,
    PokemonId = 34,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 469,
    PokemonId = 34,
    MoveId = 72
},
new PokemonLearnableMove
{
    Id = 470,
    PokemonId = 34,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 471,
    PokemonId = 35,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 472,
    PokemonId = 35,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 473,
    PokemonId = 35,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 474,
    PokemonId = 35,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 475,
    PokemonId = 35,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 476,
    PokemonId = 35,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 477,
    PokemonId = 35,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 478,
    PokemonId = 35,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 479,
    PokemonId = 35,
    MoveId = 29
},
new PokemonLearnableMove
{
    Id = 480,
    PokemonId = 35,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 481,
    PokemonId = 35,
    MoveId = 30
},
new PokemonLearnableMove
{
    Id = 482,
    PokemonId = 35,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 483,
    PokemonId = 35,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 484,
    PokemonId = 35,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 485,
    PokemonId = 35,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 486,
    PokemonId = 35,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 487,
    PokemonId = 35,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 488,
    PokemonId = 35,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 489,
    PokemonId = 35,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 490,
    PokemonId = 35,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 491,
    PokemonId = 35,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 492,
    PokemonId = 35,
    MoveId = 67
},
new PokemonLearnableMove
{
    Id = 493,
    PokemonId = 35,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 494,
    PokemonId = 35,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 495,
    PokemonId = 36,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 496,
    PokemonId = 36,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 497,
    PokemonId = 36,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 498,
    PokemonId = 36,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 499,
    PokemonId = 36,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 500,
    PokemonId = 36,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 501,
    PokemonId = 36,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 502,
    PokemonId = 36,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 503,
    PokemonId = 36,
    MoveId = 29
},
new PokemonLearnableMove
{
    Id = 504,
    PokemonId = 36,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 505,
    PokemonId = 36,
    MoveId = 30
},
new PokemonLearnableMove
{
    Id = 506,
    PokemonId = 36,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 507,
    PokemonId = 36,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 508,
    PokemonId = 36,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 509,
    PokemonId = 36,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 510,
    PokemonId = 36,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 511,
    PokemonId = 36,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 512,
    PokemonId = 36,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 513,
    PokemonId = 36,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 514,
    PokemonId = 36,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 515,
    PokemonId = 36,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 516,
    PokemonId = 36,
    MoveId = 67
},
new PokemonLearnableMove
{
    Id = 517,
    PokemonId = 36,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 518,
    PokemonId = 36,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 519,
    PokemonId = 37,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 520,
    PokemonId = 37,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 521,
    PokemonId = 37,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 522,
    PokemonId = 37,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 523,
    PokemonId = 37,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 524,
    PokemonId = 37,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 525,
    PokemonId = 37,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 526,
    PokemonId = 37,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 527,
    PokemonId = 37,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 528,
    PokemonId = 37,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 529,
    PokemonId = 37,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 530,
    PokemonId = 37,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 531,
    PokemonId = 38,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 532,
    PokemonId = 38,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 533,
    PokemonId = 38,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 534,
    PokemonId = 38,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 535,
    PokemonId = 38,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 536,
    PokemonId = 38,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 537,
    PokemonId = 38,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 538,
    PokemonId = 38,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 539,
    PokemonId = 38,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 540,
    PokemonId = 38,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 541,
    PokemonId = 38,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 542,
    PokemonId = 38,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 543,
    PokemonId = 38,
    MoveId = 61
},
new PokemonLearnableMove
{
    Id = 544,
    PokemonId = 38,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 545,
    PokemonId = 38,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 546,
    PokemonId = 39,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 547,
    PokemonId = 39,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 548,
    PokemonId = 39,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 549,
    PokemonId = 39,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 550,
    PokemonId = 39,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 551,
    PokemonId = 39,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 552,
    PokemonId = 39,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 553,
    PokemonId = 39,
    MoveId = 29
},
new PokemonLearnableMove
{
    Id = 554,
    PokemonId = 39,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 555,
    PokemonId = 39,
    MoveId = 30
},
new PokemonLearnableMove
{
    Id = 556,
    PokemonId = 39,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 557,
    PokemonId = 39,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 558,
    PokemonId = 39,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 559,
    PokemonId = 39,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 560,
    PokemonId = 39,
    MoveId = 36
},
new PokemonLearnableMove
{
    Id = 561,
    PokemonId = 39,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 562,
    PokemonId = 39,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 563,
    PokemonId = 39,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 564,
    PokemonId = 39,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 565,
    PokemonId = 39,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 566,
    PokemonId = 39,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 567,
    PokemonId = 39,
    MoveId = 67
},
new PokemonLearnableMove
{
    Id = 568,
    PokemonId = 39,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 569,
    PokemonId = 39,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 570,
    PokemonId = 40,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 571,
    PokemonId = 40,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 572,
    PokemonId = 40,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 573,
    PokemonId = 40,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 574,
    PokemonId = 40,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 575,
    PokemonId = 40,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 576,
    PokemonId = 40,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 577,
    PokemonId = 40,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 578,
    PokemonId = 40,
    MoveId = 29
},
new PokemonLearnableMove
{
    Id = 579,
    PokemonId = 40,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 580,
    PokemonId = 40,
    MoveId = 30
},
new PokemonLearnableMove
{
    Id = 581,
    PokemonId = 40,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 582,
    PokemonId = 40,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 583,
    PokemonId = 40,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 584,
    PokemonId = 40,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 585,
    PokemonId = 40,
    MoveId = 36
},
new PokemonLearnableMove
{
    Id = 586,
    PokemonId = 40,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 587,
    PokemonId = 40,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 588,
    PokemonId = 40,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 589,
    PokemonId = 40,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 590,
    PokemonId = 40,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 591,
    PokemonId = 40,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 592,
    PokemonId = 40,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 593,
    PokemonId = 40,
    MoveId = 67
},
new PokemonLearnableMove
{
    Id = 594,
    PokemonId = 40,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 595,
    PokemonId = 40,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 596,
    PokemonId = 41,
    MoveId = 4
},
new PokemonLearnableMove
{
    Id = 597,
    PokemonId = 41,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 598,
    PokemonId = 41,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 599,
    PokemonId = 41,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 600,
    PokemonId = 41,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 601,
    PokemonId = 41,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 602,
    PokemonId = 41,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 603,
    PokemonId = 41,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 604,
    PokemonId = 41,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 605,
    PokemonId = 41,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 606,
    PokemonId = 41,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 607,
    PokemonId = 41,
    MoveId = 51
},
new PokemonLearnableMove
{
    Id = 608,
    PokemonId = 41,
    MoveId = 88
},
new PokemonLearnableMove
{
    Id = 609,
    PokemonId = 41,
    MoveId = 89
},
new PokemonLearnableMove
{
    Id = 610,
    PokemonId = 41,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 611,
    PokemonId = 41,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 612,
    PokemonId = 42,
    MoveId = 4
},
new PokemonLearnableMove
{
    Id = 613,
    PokemonId = 42,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 614,
    PokemonId = 42,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 615,
    PokemonId = 42,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 616,
    PokemonId = 42,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 617,
    PokemonId = 42,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 618,
    PokemonId = 42,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 619,
    PokemonId = 42,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 620,
    PokemonId = 42,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 621,
    PokemonId = 42,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 622,
    PokemonId = 42,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 623,
    PokemonId = 42,
    MoveId = 51
},
new PokemonLearnableMove
{
    Id = 624,
    PokemonId = 42,
    MoveId = 88
},
new PokemonLearnableMove
{
    Id = 625,
    PokemonId = 42,
    MoveId = 89
},
new PokemonLearnableMove
{
    Id = 626,
    PokemonId = 42,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 627,
    PokemonId = 42,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 628,
    PokemonId = 43,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 629,
    PokemonId = 43,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 630,
    PokemonId = 43,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 631,
    PokemonId = 43,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 632,
    PokemonId = 43,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 633,
    PokemonId = 43,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 634,
    PokemonId = 43,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 635,
    PokemonId = 43,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 636,
    PokemonId = 43,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 637,
    PokemonId = 43,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 638,
    PokemonId = 43,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 639,
    PokemonId = 43,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 640,
    PokemonId = 44,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 641,
    PokemonId = 44,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 642,
    PokemonId = 44,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 643,
    PokemonId = 44,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 644,
    PokemonId = 44,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 645,
    PokemonId = 44,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 646,
    PokemonId = 44,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 647,
    PokemonId = 44,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 648,
    PokemonId = 44,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 649,
    PokemonId = 44,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 650,
    PokemonId = 44,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 651,
    PokemonId = 44,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 652,
    PokemonId = 44,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 653,
    PokemonId = 45,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 654,
    PokemonId = 45,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 655,
    PokemonId = 45,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 656,
    PokemonId = 45,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 657,
    PokemonId = 45,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 658,
    PokemonId = 45,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 659,
    PokemonId = 45,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 660,
    PokemonId = 45,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 661,
    PokemonId = 45,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 662,
    PokemonId = 45,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 663,
    PokemonId = 45,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 664,
    PokemonId = 45,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 665,
    PokemonId = 45,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 666,
    PokemonId = 46,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 667,
    PokemonId = 46,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 668,
    PokemonId = 46,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 669,
    PokemonId = 46,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 670,
    PokemonId = 46,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 671,
    PokemonId = 46,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 672,
    PokemonId = 46,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 673,
    PokemonId = 46,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 674,
    PokemonId = 46,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 675,
    PokemonId = 46,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 676,
    PokemonId = 46,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 677,
    PokemonId = 46,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 678,
    PokemonId = 46,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 679,
    PokemonId = 47,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 680,
    PokemonId = 47,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 681,
    PokemonId = 47,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 682,
    PokemonId = 47,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 683,
    PokemonId = 47,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 684,
    PokemonId = 47,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 685,
    PokemonId = 47,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 686,
    PokemonId = 47,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 687,
    PokemonId = 47,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 688,
    PokemonId = 47,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 689,
    PokemonId = 47,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 690,
    PokemonId = 47,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 691,
    PokemonId = 47,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 692,
    PokemonId = 48,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 693,
    PokemonId = 48,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 694,
    PokemonId = 48,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 695,
    PokemonId = 48,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 696,
    PokemonId = 48,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 697,
    PokemonId = 48,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 698,
    PokemonId = 48,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 699,
    PokemonId = 48,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 700,
    PokemonId = 48,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 701,
    PokemonId = 48,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 702,
    PokemonId = 48,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 703,
    PokemonId = 48,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 704,
    PokemonId = 48,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 705,
    PokemonId = 48,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 706,
    PokemonId = 49,
    MoveId = 4
},
new PokemonLearnableMove
{
    Id = 707,
    PokemonId = 49,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 708,
    PokemonId = 49,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 709,
    PokemonId = 49,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 710,
    PokemonId = 49,
    MoveId = 30
},
new PokemonLearnableMove
{
    Id = 711,
    PokemonId = 49,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 712,
    PokemonId = 49,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 713,
    PokemonId = 49,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 714,
    PokemonId = 49,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 715,
    PokemonId = 49,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 716,
    PokemonId = 49,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 717,
    PokemonId = 49,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 718,
    PokemonId = 49,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 719,
    PokemonId = 49,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 720,
    PokemonId = 49,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 721,
    PokemonId = 49,
    MoveId = 51
},
new PokemonLearnableMove
{
    Id = 722,
    PokemonId = 49,
    MoveId = 89
},
new PokemonLearnableMove
{
    Id = 723,
    PokemonId = 49,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 724,
    PokemonId = 50,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 725,
    PokemonId = 50,
    MoveId = 27
},
new PokemonLearnableMove
{
    Id = 726,
    PokemonId = 50,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 727,
    PokemonId = 50,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 728,
    PokemonId = 50,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 729,
    PokemonId = 50,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 730,
    PokemonId = 50,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 731,
    PokemonId = 50,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 732,
    PokemonId = 50,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 733,
    PokemonId = 50,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 734,
    PokemonId = 50,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 735,
    PokemonId = 51,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 736,
    PokemonId = 51,
    MoveId = 27
},
new PokemonLearnableMove
{
    Id = 737,
    PokemonId = 51,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 738,
    PokemonId = 51,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 739,
    PokemonId = 51,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 740,
    PokemonId = 51,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 741,
    PokemonId = 51,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 742,
    PokemonId = 51,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 743,
    PokemonId = 51,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 744,
    PokemonId = 51,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 745,
    PokemonId = 51,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 746,
    PokemonId = 52,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 747,
    PokemonId = 52,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 748,
    PokemonId = 52,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 749,
    PokemonId = 52,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 750,
    PokemonId = 52,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 751,
    PokemonId = 52,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 752,
    PokemonId = 52,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 753,
    PokemonId = 52,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 754,
    PokemonId = 52,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 755,
    PokemonId = 52,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 756,
    PokemonId = 52,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 757,
    PokemonId = 52,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 758,
    PokemonId = 52,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 759,
    PokemonId = 52,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 760,
    PokemonId = 52,
    MoveId = 89
},
new PokemonLearnableMove
{
    Id = 761,
    PokemonId = 52,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 762,
    PokemonId = 53,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 763,
    PokemonId = 53,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 764,
    PokemonId = 53,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 765,
    PokemonId = 53,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 766,
    PokemonId = 53,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 767,
    PokemonId = 53,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 768,
    PokemonId = 53,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 769,
    PokemonId = 53,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 770,
    PokemonId = 53,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 771,
    PokemonId = 53,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 772,
    PokemonId = 53,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 773,
    PokemonId = 53,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 774,
    PokemonId = 53,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 775,
    PokemonId = 53,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 776,
    PokemonId = 53,
    MoveId = 89
},
new PokemonLearnableMove
{
    Id = 777,
    PokemonId = 53,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 778,
    PokemonId = 53,
    MoveId = 63
},
new PokemonLearnableMove
{
    Id = 779,
    PokemonId = 54,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 780,
    PokemonId = 54,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 781,
    PokemonId = 54,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 782,
    PokemonId = 54,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 783,
    PokemonId = 54,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 784,
    PokemonId = 54,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 785,
    PokemonId = 54,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 786,
    PokemonId = 54,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 787,
    PokemonId = 54,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 788,
    PokemonId = 54,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 789,
    PokemonId = 54,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 790,
    PokemonId = 54,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 791,
    PokemonId = 54,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 792,
    PokemonId = 54,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 793,
    PokemonId = 54,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 794,
    PokemonId = 54,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 795,
    PokemonId = 54,
    MoveId = 55
},
new PokemonLearnableMove
{
    Id = 796,
    PokemonId = 54,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 797,
    PokemonId = 54,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 798,
    PokemonId = 55,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 799,
    PokemonId = 55,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 800,
    PokemonId = 55,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 801,
    PokemonId = 55,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 802,
    PokemonId = 55,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 803,
    PokemonId = 55,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 804,
    PokemonId = 55,
    MoveId = 29
},
new PokemonLearnableMove
{
    Id = 805,
    PokemonId = 55,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 806,
    PokemonId = 55,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 807,
    PokemonId = 55,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 808,
    PokemonId = 55,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 809,
    PokemonId = 55,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 810,
    PokemonId = 55,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 811,
    PokemonId = 55,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 812,
    PokemonId = 55,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 813,
    PokemonId = 55,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 814,
    PokemonId = 55,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 815,
    PokemonId = 55,
    MoveId = 55
},
new PokemonLearnableMove
{
    Id = 816,
    PokemonId = 55,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 817,
    PokemonId = 55,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 818,
    PokemonId = 56,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 819,
    PokemonId = 56,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 820,
    PokemonId = 56,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 821,
    PokemonId = 56,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 822,
    PokemonId = 56,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 823,
    PokemonId = 56,
    MoveId = 26
},
new PokemonLearnableMove
{
    Id = 824,
    PokemonId = 56,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 825,
    PokemonId = 56,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 826,
    PokemonId = 56,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 827,
    PokemonId = 56,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 828,
    PokemonId = 56,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 829,
    PokemonId = 56,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 830,
    PokemonId = 56,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 831,
    PokemonId = 56,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 832,
    PokemonId = 56,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 833,
    PokemonId = 56,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 834,
    PokemonId = 56,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 835,
    PokemonId = 56,
    MoveId = 89
},
new PokemonLearnableMove
{
    Id = 836,
    PokemonId = 56,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 837,
    PokemonId = 56,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 838,
    PokemonId = 56,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 839,
    PokemonId = 57,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 840,
    PokemonId = 57,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 841,
    PokemonId = 57,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 842,
    PokemonId = 57,
    MoveId = 24
},
new PokemonLearnableMove
{
    Id = 843,
    PokemonId = 57,
    MoveId = 25
},
new PokemonLearnableMove
{
    Id = 844,
    PokemonId = 57,
    MoveId = 26
},
new PokemonLearnableMove
{
    Id = 845,
    PokemonId = 57,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 846,
    PokemonId = 57,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 847,
    PokemonId = 57,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 848,
    PokemonId = 57,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 849,
    PokemonId = 57,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 850,
    PokemonId = 57,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 851,
    PokemonId = 57,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 852,
    PokemonId = 57,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 853,
    PokemonId = 57,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 854,
    PokemonId = 57,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 855,
    PokemonId = 57,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 856,
    PokemonId = 57,
    MoveId = 89
},
new PokemonLearnableMove
{
    Id = 857,
    PokemonId = 57,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 858,
    PokemonId = 57,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 859,
    PokemonId = 58,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 860,
    PokemonId = 58,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 861,
    PokemonId = 58,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 862,
    PokemonId = 58,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 863,
    PokemonId = 58,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 864,
    PokemonId = 58,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 865,
    PokemonId = 58,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 866,
    PokemonId = 58,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 867,
    PokemonId = 58,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 868,
    PokemonId = 58,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 869,
    PokemonId = 58,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 870,
    PokemonId = 58,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 871,
    PokemonId = 58,
    MoveId = 61
},
new PokemonLearnableMove
{
    Id = 872,
    PokemonId = 58,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 873,
    PokemonId = 59,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 874,
    PokemonId = 59,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 875,
    PokemonId = 59,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 876,
    PokemonId = 59,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 877,
    PokemonId = 59,
    MoveId = 30
},
new PokemonLearnableMove
{
    Id = 878,
    PokemonId = 59,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 879,
    PokemonId = 59,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 880,
    PokemonId = 59,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 881,
    PokemonId = 59,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 882,
    PokemonId = 59,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 883,
    PokemonId = 59,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 884,
    PokemonId = 59,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 885,
    PokemonId = 59,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 886,
    PokemonId = 59,
    MoveId = 61
},
new PokemonLearnableMove
{
    Id = 887,
    PokemonId = 59,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 888,
    PokemonId = 60,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 889,
    PokemonId = 60,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 890,
    PokemonId = 60,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 891,
    PokemonId = 60,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 892,
    PokemonId = 60,
    MoveId = 29
},
new PokemonLearnableMove
{
    Id = 893,
    PokemonId = 60,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 894,
    PokemonId = 60,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 895,
    PokemonId = 60,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 896,
    PokemonId = 60,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 897,
    PokemonId = 60,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 898,
    PokemonId = 60,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 899,
    PokemonId = 60,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 900,
    PokemonId = 60,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 901,
    PokemonId = 60,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 902,
    PokemonId = 60,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 903,
    PokemonId = 61,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 904,
    PokemonId = 61,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 905,
    PokemonId = 61,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 906,
    PokemonId = 61,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 907,
    PokemonId = 61,
    MoveId = 26
},
new PokemonLearnableMove
{
    Id = 908,
    PokemonId = 61,
    MoveId = 27
},
new PokemonLearnableMove
{
    Id = 909,
    PokemonId = 61,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 910,
    PokemonId = 61,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 911,
    PokemonId = 61,
    MoveId = 29
},
new PokemonLearnableMove
{
    Id = 912,
    PokemonId = 61,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 913,
    PokemonId = 61,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 914,
    PokemonId = 61,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 915,
    PokemonId = 61,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 916,
    PokemonId = 61,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 917,
    PokemonId = 61,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 918,
    PokemonId = 61,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 919,
    PokemonId = 61,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 920,
    PokemonId = 61,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 921,
    PokemonId = 61,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 922,
    PokemonId = 61,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 923,
    PokemonId = 61,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 924,
    PokemonId = 62,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 925,
    PokemonId = 62,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 926,
    PokemonId = 62,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 927,
    PokemonId = 62,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 928,
    PokemonId = 62,
    MoveId = 26
},
new PokemonLearnableMove
{
    Id = 929,
    PokemonId = 62,
    MoveId = 27
},
new PokemonLearnableMove
{
    Id = 930,
    PokemonId = 62,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 931,
    PokemonId = 62,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 932,
    PokemonId = 62,
    MoveId = 29
},
new PokemonLearnableMove
{
    Id = 933,
    PokemonId = 62,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 934,
    PokemonId = 62,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 935,
    PokemonId = 62,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 936,
    PokemonId = 62,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 937,
    PokemonId = 62,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 938,
    PokemonId = 62,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 939,
    PokemonId = 62,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 940,
    PokemonId = 62,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 941,
    PokemonId = 62,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 942,
    PokemonId = 62,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 943,
    PokemonId = 62,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 944,
    PokemonId = 62,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 945,
    PokemonId = 62,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 946,
    PokemonId = 63,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 947,
    PokemonId = 63,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 948,
    PokemonId = 63,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 949,
    PokemonId = 63,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 950,
    PokemonId = 63,
    MoveId = 29
},
new PokemonLearnableMove
{
    Id = 951,
    PokemonId = 63,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 952,
    PokemonId = 63,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 953,
    PokemonId = 63,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 954,
    PokemonId = 63,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 955,
    PokemonId = 63,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 956,
    PokemonId = 63,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 957,
    PokemonId = 63,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 958,
    PokemonId = 63,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 959,
    PokemonId = 63,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 960,
    PokemonId = 63,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 961,
    PokemonId = 63,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 962,
    PokemonId = 63,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 963,
    PokemonId = 63,
    MoveId = 67
},
new PokemonLearnableMove
{
    Id = 964,
    PokemonId = 63,
    MoveId = 63
},
new PokemonLearnableMove
{
    Id = 965,
    PokemonId = 63,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 966,
    PokemonId = 63,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 967,
    PokemonId = 64,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 968,
    PokemonId = 64,
    MoveId = 17
},
new PokemonLearnableMove
{
    Id = 969,
    PokemonId = 64,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 970,
    PokemonId = 64,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 971,
    PokemonId = 64,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 972,
    PokemonId = 64,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 973,
    PokemonId = 64,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 974,
    PokemonId = 64,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 975,
    PokemonId = 64,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 976,
    PokemonId = 64,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 977,
    PokemonId = 64,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 978,
    PokemonId = 64,
    MoveId = 46
},
new PokemonLearnableMove
{
    Id = 979,
    PokemonId = 64,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 980,
    PokemonId = 64,
    MoveId = 50
},
new PokemonLearnableMove { Id = 981, PokemonId = 64, MoveId = 58 },
new PokemonLearnableMove { Id = 982, PokemonId = 64, MoveId = 87 },
new PokemonLearnableMove { Id = 983, PokemonId = 64, MoveId = 67 },
new PokemonLearnableMove { Id = 984, PokemonId = 64, MoveId = 63 },
new PokemonLearnableMove { Id = 985, PokemonId = 64, MoveId = 56 },
new PokemonLearnableMove { Id = 986, PokemonId = 64, MoveId = 78 },
new PokemonLearnableMove { Id = 987, PokemonId = 65, MoveId = 10 },
new PokemonLearnableMove { Id = 988, PokemonId = 65, MoveId = 17 },
new PokemonLearnableMove { Id = 989, PokemonId = 65, MoveId = 18 },
new PokemonLearnableMove { Id = 990, PokemonId = 65, MoveId = 28 },
new PokemonLearnableMove { Id = 991, PokemonId = 65, MoveId = 6 },
new PokemonLearnableMove { Id = 992, PokemonId = 65, MoveId = 20 },
new PokemonLearnableMove { Id = 993, PokemonId = 65, MoveId = 31 },
new PokemonLearnableMove { Id = 994, PokemonId = 65, MoveId = 34 },
new PokemonLearnableMove { Id = 995, PokemonId = 65, MoveId = 35 },
new PokemonLearnableMove { Id = 996, PokemonId = 65, MoveId = 39 },
new PokemonLearnableMove { Id = 997, PokemonId = 65, MoveId = 70 },
new PokemonLearnableMove { Id = 998, PokemonId = 65, MoveId = 46 },
new PokemonLearnableMove { Id = 999, PokemonId = 65, MoveId = 44 },
new PokemonLearnableMove { Id = 1000, PokemonId = 65, MoveId = 50 },
new PokemonLearnableMove
{
    Id = 1001,
    PokemonId = 65,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 1002,
    PokemonId = 65,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 1003,
    PokemonId = 65,
    MoveId = 67
},
new PokemonLearnableMove
{
    Id = 1004,
    PokemonId = 65,
    MoveId = 63
},
new PokemonLearnableMove
{
    Id = 1005,
    PokemonId = 65,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 1006,
    PokemonId = 65,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 1007,
    PokemonId = 66,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 1008,
    PokemonId = 66,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 1009,
    PokemonId = 66,
    MoveId = 26
},
new PokemonLearnableMove
{
    Id = 1010,
    PokemonId = 66,
    MoveId = 27
},
new PokemonLearnableMove
{
    Id = 1011,
    PokemonId = 66,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 1012,
    PokemonId = 66,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 1013,
    PokemonId = 66,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 1014,
    PokemonId = 66,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 1015,
    PokemonId = 66,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 1016,
    PokemonId = 66,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 1017,
    PokemonId = 66,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 1018,
    PokemonId = 66,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 1019,
    PokemonId = 66,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 1020,
    PokemonId = 66,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 1021,
    PokemonId = 66,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 1022,
    PokemonId = 66,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 1023,
    PokemonId = 66,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 1024,
    PokemonId = 67,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 1025,
    PokemonId = 67,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 1026,
    PokemonId = 67,
    MoveId = 26
},
new PokemonLearnableMove
{
    Id = 1027,
    PokemonId = 67,
    MoveId = 27
},
new PokemonLearnableMove
{
    Id = 1028,
    PokemonId = 67,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 1029,
    PokemonId = 67,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 1030,
    PokemonId = 67,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 1031,
    PokemonId = 67,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 1032,
    PokemonId = 67,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 1033,
    PokemonId = 67,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 1034,
    PokemonId = 67,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 1035,
    PokemonId = 67,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 1036,
    PokemonId = 67,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 1037,
    PokemonId = 67,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 1038,
    PokemonId = 67,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 1039,
    PokemonId = 67,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 1040,
    PokemonId = 67,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 1041,
    PokemonId = 68,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 1042,
    PokemonId = 68,
    MoveId = 18
},
new PokemonLearnableMove
{
    Id = 1043,
    PokemonId = 68,
    MoveId = 26
},
new PokemonLearnableMove
{
    Id = 1044,
    PokemonId = 68,
    MoveId = 27
},
new PokemonLearnableMove
{
    Id = 1045,
    PokemonId = 68,
    MoveId = 28
},
new PokemonLearnableMove
{
    Id = 1046,
    PokemonId = 68,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 1047,
    PokemonId = 68,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 1048,
    PokemonId = 68,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 1049,
    PokemonId = 68,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 1050,
    PokemonId = 68,
    MoveId = 35
},
new PokemonLearnableMove
{
    Id = 1051,
    PokemonId = 68,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 1052,
    PokemonId = 68,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 1053,
    PokemonId = 68,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 1054,
    PokemonId = 68,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 1055,
    PokemonId = 68,
    MoveId = 66
},
new PokemonLearnableMove
{
    Id = 1056,
    PokemonId = 68,
    MoveId = 56
},
new PokemonLearnableMove
{
    Id = 1057,
    PokemonId = 68,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 1058,
    PokemonId = 69,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 1059,
    PokemonId = 69,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 1060,
    PokemonId = 69,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 1061,
    PokemonId = 69,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 1062,
    PokemonId = 69,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 1063,
    PokemonId = 69,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 1064,
    PokemonId = 69,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 1065,
    PokemonId = 69,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 1066,
    PokemonId = 69,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 1067,
    PokemonId = 69,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 1068,
    PokemonId = 69,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 1069,
    PokemonId = 69,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 1070,
    PokemonId = 70,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 1071,
    PokemonId = 70,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 1072,
    PokemonId = 70,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 1073,
    PokemonId = 70,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 1074,
    PokemonId = 70,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 1075,
    PokemonId = 70,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 1076,
    PokemonId = 70,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 1077,
    PokemonId = 70,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 1078,
    PokemonId = 70,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 1079,
    PokemonId = 70,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 1080,
    PokemonId = 70,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 1081,
    PokemonId = 70,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 1082,
    PokemonId = 70,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 1083,
    PokemonId = 71,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 1084,
    PokemonId = 71,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 1085,
    PokemonId = 71,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 1086,
    PokemonId = 71,
    MoveId = 31
},
new PokemonLearnableMove
{
    Id = 1087,
    PokemonId = 71,
    MoveId = 33
},
new PokemonLearnableMove
{
    Id = 1088,
    PokemonId = 71,
    MoveId = 34
},
new PokemonLearnableMove
{
    Id = 1089,
    PokemonId = 71,
    MoveId = 39
},
new PokemonLearnableMove
{
    Id = 1090,
    PokemonId = 71,
    MoveId = 70
},
new PokemonLearnableMove
{
    Id = 1091,
    PokemonId = 71,
    MoveId = 44
},
new PokemonLearnableMove
{
    Id = 1092,
    PokemonId = 71,
    MoveId = 50
},
new PokemonLearnableMove
{
    Id = 1093,
    PokemonId = 71,
    MoveId = 58
},
new PokemonLearnableMove
{
    Id = 1094,
    PokemonId = 71,
    MoveId = 87
},
new PokemonLearnableMove
{
    Id = 1095,
    PokemonId = 71,
    MoveId = 78
},
new PokemonLearnableMove
{
    Id = 1096,
    PokemonId = 72,
    MoveId = 10
},
new PokemonLearnableMove
{
    Id = 1097,
    PokemonId = 72,
    MoveId = 14
},
new PokemonLearnableMove
{
    Id = 1098,
    PokemonId = 72,
    MoveId = 6
},
new PokemonLearnableMove
{
    Id = 1099,
    PokemonId = 72,
    MoveId = 20
},
new PokemonLearnableMove
{
    Id = 1100,
    PokemonId = 72,
    MoveId = 31
},
new PokemonLearnableMove { Id = 1101, PokemonId = 72, MoveId = 33 },
new PokemonLearnableMove { Id = 1102, PokemonId = 72, MoveId = 34 },
new PokemonLearnableMove { Id = 1103, PokemonId = 72, MoveId = 44 },
new PokemonLearnableMove { Id = 1104, PokemonId = 72, MoveId = 50 },
new PokemonLearnableMove { Id = 1105, PokemonId = 72, MoveId = 58 },
new PokemonLearnableMove { Id = 1106, PokemonId = 72, MoveId = 87 },
new PokemonLearnableMove { Id = 1107, PokemonId = 72, MoveId = 55 },
new PokemonLearnableMove { Id = 1108, PokemonId = 72, MoveId = 66 },
new PokemonLearnableMove { Id = 1109, PokemonId = 72, MoveId = 78 },
new PokemonLearnableMove { Id = 1110, PokemonId = 73, MoveId = 10 },
new PokemonLearnableMove { Id = 1111, PokemonId = 73, MoveId = 14 },
new PokemonLearnableMove { Id = 1112, PokemonId = 73, MoveId = 6 },
new PokemonLearnableMove { Id = 1113, PokemonId = 73, MoveId = 20 },
new PokemonLearnableMove { Id = 1114, PokemonId = 73, MoveId = 31 },
new PokemonLearnableMove { Id = 1115, PokemonId = 73, MoveId = 33 },
new PokemonLearnableMove { Id = 1116, PokemonId = 73, MoveId = 34 },
new PokemonLearnableMove { Id = 1117, PokemonId = 73, MoveId = 44 },
new PokemonLearnableMove { Id = 1118, PokemonId = 73, MoveId = 50 },
new PokemonLearnableMove { Id = 1119, PokemonId = 73, MoveId = 58 },
new PokemonLearnableMove { Id = 1120, PokemonId = 73, MoveId = 87 },
new PokemonLearnableMove { Id = 1121, PokemonId = 73, MoveId = 55 },
new PokemonLearnableMove { Id = 1122, PokemonId = 73, MoveId = 66 },
new PokemonLearnableMove { Id = 1123, PokemonId = 73, MoveId = 78 },
new PokemonLearnableMove { Id = 1124, PokemonId = 74, MoveId = 10 },
new PokemonLearnableMove { Id = 1125, PokemonId = 74, MoveId = 17 },
new PokemonLearnableMove { Id = 1126, PokemonId = 74, MoveId = 18 },
new PokemonLearnableMove { Id = 1127, PokemonId = 74, MoveId = 27 },
new PokemonLearnableMove { Id = 1128, PokemonId = 74, MoveId = 28 },
new PokemonLearnableMove { Id = 1129, PokemonId = 74, MoveId = 6 },
new PokemonLearnableMove { Id = 1130, PokemonId = 74, MoveId = 20 },
new PokemonLearnableMove { Id = 1131, PokemonId = 74, MoveId = 31 },
new PokemonLearnableMove { Id = 1132, PokemonId = 74, MoveId = 34 },
new PokemonLearnableMove { Id = 1133, PokemonId = 74, MoveId = 35 },
new PokemonLearnableMove { Id = 1134, PokemonId = 74, MoveId = 44 },
new PokemonLearnableMove { Id = 1135, PokemonId = 74, MoveId = 50 },
new PokemonLearnableMove { Id = 1136, PokemonId = 74, MoveId = 58 },
new PokemonLearnableMove { Id = 1137, PokemonId = 74, MoveId = 87 },
new PokemonLearnableMove { Id = 1138, PokemonId = 74, MoveId = 56 },
new PokemonLearnableMove { Id = 1139, PokemonId = 74, MoveId = 78 },
new PokemonLearnableMove { Id = 1140, PokemonId = 75, MoveId = 10 },
new PokemonLearnableMove { Id = 1141, PokemonId = 75, MoveId = 17 },
new PokemonLearnableMove { Id = 1142, PokemonId = 75, MoveId = 18 },
new PokemonLearnableMove { Id = 1143, PokemonId = 75, MoveId = 27 },
new PokemonLearnableMove { Id = 1144, PokemonId = 75, MoveId = 28 },
new PokemonLearnableMove { Id = 1145, PokemonId = 75, MoveId = 6 },
new PokemonLearnableMove { Id = 1146, PokemonId = 75, MoveId = 20 },
new PokemonLearnableMove { Id = 1147, PokemonId = 75, MoveId = 31 },
new PokemonLearnableMove { Id = 1148, PokemonId = 75, MoveId = 34 },
new PokemonLearnableMove { Id = 1149, PokemonId = 75, MoveId = 35 },
new PokemonLearnableMove { Id = 1150, PokemonId = 75, MoveId = 44 },
new PokemonLearnableMove { Id = 1151, PokemonId = 75, MoveId = 50 },
new PokemonLearnableMove { Id = 1152, PokemonId = 75, MoveId = 58 },
new PokemonLearnableMove { Id = 1153, PokemonId = 75, MoveId = 87 },
new PokemonLearnableMove { Id = 1154, PokemonId = 75, MoveId = 56 },
new PokemonLearnableMove { Id = 1155, PokemonId = 75, MoveId = 78 },
new PokemonLearnableMove { Id = 1156, PokemonId = 76, MoveId = 10 },
new PokemonLearnableMove { Id = 1157, PokemonId = 76, MoveId = 17 },
new PokemonLearnableMove { Id = 1158, PokemonId = 76, MoveId = 18 },
new PokemonLearnableMove { Id = 1159, PokemonId = 76, MoveId = 27 },
new PokemonLearnableMove { Id = 1160, PokemonId = 76, MoveId = 28 },
new PokemonLearnableMove { Id = 1161, PokemonId = 76, MoveId = 6 },
new PokemonLearnableMove { Id = 1162, PokemonId = 76, MoveId = 20 },
new PokemonLearnableMove { Id = 1163, PokemonId = 76, MoveId = 31 },
new PokemonLearnableMove { Id = 1164, PokemonId = 76, MoveId = 34 },
new PokemonLearnableMove { Id = 1165, PokemonId = 76, MoveId = 35 },
new PokemonLearnableMove { Id = 1166, PokemonId = 76, MoveId = 44 },
new PokemonLearnableMove { Id = 1167, PokemonId = 76, MoveId = 50 },
new PokemonLearnableMove { Id = 1168, PokemonId = 76, MoveId = 58 },
new PokemonLearnableMove { Id = 1169, PokemonId = 76, MoveId = 87 },
new PokemonLearnableMove { Id = 1170, PokemonId = 76, MoveId = 56 },
new PokemonLearnableMove { Id = 1171, PokemonId = 76, MoveId = 78 },
new PokemonLearnableMove { Id = 1172, PokemonId = 77, MoveId = 10 },
new PokemonLearnableMove { Id = 1173, PokemonId = 77, MoveId = 6 },
new PokemonLearnableMove { Id = 1174, PokemonId = 77, MoveId = 20 },
new PokemonLearnableMove { Id = 1175, PokemonId = 77, MoveId = 31 },
new PokemonLearnableMove { Id = 1176, PokemonId = 77, MoveId = 33 },
new PokemonLearnableMove { Id = 1177, PokemonId = 77, MoveId = 34 },
new PokemonLearnableMove { Id = 1178, PokemonId = 77, MoveId = 39 },
new PokemonLearnableMove { Id = 1179, PokemonId = 77, MoveId = 44 },
new PokemonLearnableMove { Id = 1180, PokemonId = 77, MoveId = 50 },
new PokemonLearnableMove { Id = 1181, PokemonId = 77, MoveId = 58 },
new PokemonLearnableMove { Id = 1182, PokemonId = 77, MoveId = 87 },
new PokemonLearnableMove { Id = 1183, PokemonId = 77, MoveId = 61 },
new PokemonLearnableMove { Id = 1184, PokemonId = 77, MoveId = 78 },
new PokemonLearnableMove { Id = 1185, PokemonId = 78, MoveId = 10 },
new PokemonLearnableMove { Id = 1186, PokemonId = 78, MoveId = 6 },
new PokemonLearnableMove { Id = 1187, PokemonId = 78, MoveId = 20 },
new PokemonLearnableMove { Id = 1188, PokemonId = 78, MoveId = 31 },
new PokemonLearnableMove { Id = 1189, PokemonId = 78, MoveId = 33 },
new PokemonLearnableMove { Id = 1190, PokemonId = 78, MoveId = 34 },
new PokemonLearnableMove { Id = 1191, PokemonId = 78, MoveId = 39 },
new PokemonLearnableMove { Id = 1192, PokemonId = 78, MoveId = 44 },
new PokemonLearnableMove { Id = 1193, PokemonId = 78, MoveId = 50 },
new PokemonLearnableMove { Id = 1194, PokemonId = 78, MoveId = 58 },
new PokemonLearnableMove { Id = 1195, PokemonId = 78, MoveId = 87 },
new PokemonLearnableMove { Id = 1196, PokemonId = 78, MoveId = 61 },
new PokemonLearnableMove { Id = 1197, PokemonId = 78, MoveId = 78 },
new PokemonLearnableMove { Id = 1198, PokemonId = 79, MoveId = 10 },
new PokemonLearnableMove { Id = 1199, PokemonId = 79, MoveId = 14 },
new PokemonLearnableMove { Id = 1200, PokemonId = 79, MoveId = 26 },
 new PokemonLearnableMove { Id = 1201, PokemonId = 79, MoveId = 27 },
    new PokemonLearnableMove { Id = 1202, PokemonId = 79, MoveId = 28 },
    new PokemonLearnableMove { Id = 1203, PokemonId = 79, MoveId = 6 },
    new PokemonLearnableMove { Id = 1204, PokemonId = 79, MoveId = 20 },
    new PokemonLearnableMove { Id = 1205, PokemonId = 79, MoveId = 30 },
    new PokemonLearnableMove { Id = 1206, PokemonId = 79, MoveId = 31 },
    new PokemonLearnableMove { Id = 1207, PokemonId = 79, MoveId = 33 },
    new PokemonLearnableMove { Id = 1208, PokemonId = 79, MoveId = 34 },
    new PokemonLearnableMove { Id = 1209, PokemonId = 79, MoveId = 39 },
    new PokemonLearnableMove { Id = 1210, PokemonId = 79, MoveId = 70 },
    new PokemonLearnableMove { Id = 1211, PokemonId = 79, MoveId = 46 },
    new PokemonLearnableMove { Id = 1212, PokemonId = 79, MoveId = 44 },
    new PokemonLearnableMove { Id = 1213, PokemonId = 79, MoveId = 50 },
    new PokemonLearnableMove { Id = 1214, PokemonId = 79, MoveId = 58 },
    new PokemonLearnableMove { Id = 1215, PokemonId = 79, MoveId = 87 },
    new PokemonLearnableMove { Id = 1216, PokemonId = 79, MoveId = 67 },
    new PokemonLearnableMove { Id = 1217, PokemonId = 79, MoveId = 55 },
    new PokemonLearnableMove { Id = 1218, PokemonId = 79, MoveId = 72 },
    new PokemonLearnableMove { Id = 1219, PokemonId = 79, MoveId = 78 },
    new PokemonLearnableMove { Id = 1220, PokemonId = 80, MoveId = 10 },
    new PokemonLearnableMove { Id = 1221, PokemonId = 80, MoveId = 14 },
    new PokemonLearnableMove { Id = 1222, PokemonId = 80, MoveId = 17 },
    new PokemonLearnableMove { Id = 1223, PokemonId = 80, MoveId = 18 },
    new PokemonLearnableMove { Id = 1224, PokemonId = 80, MoveId = 26 },
    new PokemonLearnableMove { Id = 1225, PokemonId = 80, MoveId = 27 },
    new PokemonLearnableMove { Id = 1226, PokemonId = 80, MoveId = 28 },
    new PokemonLearnableMove { Id = 1227, PokemonId = 80, MoveId = 6 },
    new PokemonLearnableMove { Id = 1228, PokemonId = 80, MoveId = 20 },
    new PokemonLearnableMove { Id = 1229, PokemonId = 80, MoveId = 30 },
    new PokemonLearnableMove { Id = 1230, PokemonId = 80, MoveId = 31 },
    new PokemonLearnableMove { Id = 1231, PokemonId = 80, MoveId = 33 },
    new PokemonLearnableMove { Id = 1232, PokemonId = 80, MoveId = 34 },
    new PokemonLearnableMove { Id = 1233, PokemonId = 80, MoveId = 35 },
    new PokemonLearnableMove { Id = 1234, PokemonId = 80, MoveId = 39 },
    new PokemonLearnableMove { Id = 1235, PokemonId = 80, MoveId = 70 },
    new PokemonLearnableMove { Id = 1236, PokemonId = 80, MoveId = 46 },
    new PokemonLearnableMove { Id = 1237, PokemonId = 80, MoveId = 44 },
    new PokemonLearnableMove { Id = 1238, PokemonId = 80, MoveId = 50 },
    new PokemonLearnableMove { Id = 1239, PokemonId = 80, MoveId = 58 },
    new PokemonLearnableMove { Id = 1240, PokemonId = 80, MoveId = 87 },
    new PokemonLearnableMove { Id = 1241, PokemonId = 80, MoveId = 67 },
    new PokemonLearnableMove { Id = 1242, PokemonId = 80, MoveId = 55 },
    new PokemonLearnableMove { Id = 1243, PokemonId = 80, MoveId = 56 },
    new PokemonLearnableMove { Id = 1244, PokemonId = 80, MoveId = 72 },
    new PokemonLearnableMove { Id = 1245, PokemonId = 80, MoveId = 78 },
    new PokemonLearnableMove { Id = 1246, PokemonId = 81, MoveId = 10 },
    new PokemonLearnableMove { Id = 1247, PokemonId = 81, MoveId = 24 },
    new PokemonLearnableMove { Id = 1248, PokemonId = 81, MoveId = 25 },
    new PokemonLearnableMove { Id = 1249, PokemonId = 81, MoveId = 6 },
    new PokemonLearnableMove { Id = 1250, PokemonId = 81, MoveId = 20 },
    new PokemonLearnableMove { Id = 1251, PokemonId = 81, MoveId = 30 },
    new PokemonLearnableMove { Id = 1252, PokemonId = 81, MoveId = 31 },
    new PokemonLearnableMove { Id = 1253, PokemonId = 81, MoveId = 33 },
    new PokemonLearnableMove { Id = 1254, PokemonId = 81, MoveId = 34 },
    new PokemonLearnableMove { Id = 1255, PokemonId = 81, MoveId = 70 },
    new PokemonLearnableMove { Id = 1256, PokemonId = 81, MoveId = 47 },
    new PokemonLearnableMove { Id = 1257, PokemonId = 81, MoveId = 44 },
    new PokemonLearnableMove { Id = 1258, PokemonId = 81, MoveId = 50 },
    new PokemonLearnableMove { Id = 1259, PokemonId = 81, MoveId = 58 },
    new PokemonLearnableMove { Id = 1260, PokemonId = 81, MoveId = 87 },
    new PokemonLearnableMove { Id = 1261, PokemonId = 81, MoveId = 67 },
    new PokemonLearnableMove { Id = 1262, PokemonId = 82, MoveId = 10 },
    new PokemonLearnableMove { Id = 1263, PokemonId = 82, MoveId = 24 },
    new PokemonLearnableMove { Id = 1264, PokemonId = 82, MoveId = 25 },
    new PokemonLearnableMove { Id = 1265, PokemonId = 82, MoveId = 6 },
    new PokemonLearnableMove { Id = 1266, PokemonId = 82, MoveId = 20 },
    new PokemonLearnableMove { Id = 1267, PokemonId = 82, MoveId = 30 },
    new PokemonLearnableMove { Id = 1268, PokemonId = 82, MoveId = 31 },
    new PokemonLearnableMove { Id = 1269, PokemonId = 82, MoveId = 33 },
    new PokemonLearnableMove { Id = 1270, PokemonId = 82, MoveId = 34 },
    new PokemonLearnableMove { Id = 1271, PokemonId = 82, MoveId = 70 },
    new PokemonLearnableMove { Id = 1272, PokemonId = 82, MoveId = 47 },
    new PokemonLearnableMove { Id = 1273, PokemonId = 82, MoveId = 44 },
    new PokemonLearnableMove { Id = 1274, PokemonId = 82, MoveId = 50 },
    new PokemonLearnableMove { Id = 1275, PokemonId = 82, MoveId = 58 },
    new PokemonLearnableMove { Id = 1276, PokemonId = 82, MoveId = 87 },
    new PokemonLearnableMove { Id = 1277, PokemonId = 82, MoveId = 67 },
    new PokemonLearnableMove { Id = 1278, PokemonId = 83, MoveId = 4 },
    new PokemonLearnableMove { Id = 1279, PokemonId = 83, MoveId = 10 },
    new PokemonLearnableMove { Id = 1280, PokemonId = 83, MoveId = 6 },
    new PokemonLearnableMove { Id = 1281, PokemonId = 83, MoveId = 20 },
    new PokemonLearnableMove { Id = 1282, PokemonId = 83, MoveId = 31 },
    new PokemonLearnableMove { Id = 1283, PokemonId = 83, MoveId = 33 },
    new PokemonLearnableMove { Id = 1284, PokemonId = 83, MoveId = 34 },
    new PokemonLearnableMove { Id = 1285, PokemonId = 83, MoveId = 39 },
    new PokemonLearnableMove { Id = 1286, PokemonId = 83, MoveId = 44 },
    new PokemonLearnableMove { Id = 1287, PokemonId = 83, MoveId = 50 },
    new PokemonLearnableMove { Id = 1288, PokemonId = 83, MoveId = 58 },
    new PokemonLearnableMove { Id = 1289, PokemonId = 83, MoveId = 87 },
    new PokemonLearnableMove { Id = 1290, PokemonId = 83, MoveId = 51 },
    new PokemonLearnableMove { Id = 1291, PokemonId = 83, MoveId = 88 },
    new PokemonLearnableMove { Id = 1292, PokemonId = 83, MoveId = 89 },
    new PokemonLearnableMove { Id = 1293, PokemonId = 83, MoveId = 78 },
    new PokemonLearnableMove { Id = 1294, PokemonId = 84, MoveId = 4 },
    new PokemonLearnableMove { Id = 1295, PokemonId = 84, MoveId = 10 },
    new PokemonLearnableMove { Id = 1296, PokemonId = 84, MoveId = 6 },
    new PokemonLearnableMove { Id = 1297, PokemonId = 84, MoveId = 31 },
    new PokemonLearnableMove { Id = 1298, PokemonId = 84, MoveId = 33 },
    new PokemonLearnableMove { Id = 1299, PokemonId = 84, MoveId = 34 },
    new PokemonLearnableMove { Id = 1300, PokemonId = 84, MoveId = 39 },
new PokemonLearnableMove { Id = 1301, PokemonId = 84, MoveId = 44 },
    new PokemonLearnableMove { Id = 1302, PokemonId = 84, MoveId = 50 },
    new PokemonLearnableMove { Id = 1303, PokemonId = 84, MoveId = 58 },
    new PokemonLearnableMove { Id = 1304, PokemonId = 84, MoveId = 87 },
    new PokemonLearnableMove { Id = 1305, PokemonId = 84, MoveId = 51 },
    new PokemonLearnableMove { Id = 1306, PokemonId = 84, MoveId = 88 },
    new PokemonLearnableMove { Id = 1307, PokemonId = 84, MoveId = 78 },
    new PokemonLearnableMove { Id = 1308, PokemonId = 85, MoveId = 4 },
    new PokemonLearnableMove { Id = 1309, PokemonId = 85, MoveId = 10 },
    new PokemonLearnableMove { Id = 1310, PokemonId = 85, MoveId = 6 },
    new PokemonLearnableMove { Id = 1311, PokemonId = 85, MoveId = 31 },
    new PokemonLearnableMove { Id = 1312, PokemonId = 85, MoveId = 33 },
    new PokemonLearnableMove { Id = 1313, PokemonId = 85, MoveId = 34 },
    new PokemonLearnableMove { Id = 1314, PokemonId = 85, MoveId = 39 },
    new PokemonLearnableMove { Id = 1315, PokemonId = 85, MoveId = 44 },
    new PokemonLearnableMove { Id = 1316, PokemonId = 85, MoveId = 50 },
    new PokemonLearnableMove { Id = 1317, PokemonId = 85, MoveId = 58 },
    new PokemonLearnableMove { Id = 1318, PokemonId = 85, MoveId = 87 },
    new PokemonLearnableMove { Id = 1319, PokemonId = 85, MoveId = 51 },
    new PokemonLearnableMove { Id = 1320, PokemonId = 85, MoveId = 66 },
    new PokemonLearnableMove { Id = 1321, PokemonId = 85, MoveId = 78 },
    new PokemonLearnableMove { Id = 1322, PokemonId = 86, MoveId = 10 },
    new PokemonLearnableMove { Id = 1323, PokemonId = 86, MoveId = 14 },
    new PokemonLearnableMove { Id = 1324, PokemonId = 86, MoveId = 6 },
    new PokemonLearnableMove { Id = 1325, PokemonId = 86, MoveId = 20 },
    new PokemonLearnableMove { Id = 1326, PokemonId = 86, MoveId = 31 },
    new PokemonLearnableMove { Id = 1327, PokemonId = 86, MoveId = 34 },
    new PokemonLearnableMove { Id = 1328, PokemonId = 86, MoveId = 50 },
    new PokemonLearnableMove { Id = 1329, PokemonId = 86, MoveId = 58 },
    new PokemonLearnableMove { Id = 1330, PokemonId = 86, MoveId = 87 },
    new PokemonLearnableMove { Id = 1331, PokemonId = 86, MoveId = 56 },
    new PokemonLearnableMove { Id = 1332, PokemonId = 86, MoveId = 78 },
    new PokemonLearnableMove { Id = 1333, PokemonId = 87, MoveId = 10 },
    new PokemonLearnableMove { Id = 1334, PokemonId = 87, MoveId = 14 },
    new PokemonLearnableMove { Id = 1335, PokemonId = 87, MoveId = 6 },
    new PokemonLearnableMove { Id = 1336, PokemonId = 87, MoveId = 20 },
    new PokemonLearnableMove { Id = 1337, PokemonId = 87, MoveId = 31 },
    new PokemonLearnableMove { Id = 1338, PokemonId = 87, MoveId = 34 },
    new PokemonLearnableMove { Id = 1339, PokemonId = 87, MoveId = 50 },
    new PokemonLearnableMove { Id = 1340, PokemonId = 87, MoveId = 58 },
    new PokemonLearnableMove { Id = 1341, PokemonId = 87, MoveId = 87 },
    new PokemonLearnableMove { Id = 1342, PokemonId = 87, MoveId = 56 },
    new PokemonLearnableMove { Id = 1343, PokemonId = 87, MoveId = 72 },
    new PokemonLearnableMove { Id = 1344, PokemonId = 87, MoveId = 78 },
    new PokemonLearnableMove { Id = 1345, PokemonId = 88, MoveId = 24 },
    new PokemonLearnableMove { Id = 1346, PokemonId = 88, MoveId = 25 },
    new PokemonLearnableMove { Id = 1347, PokemonId = 88, MoveId = 28 },
    new PokemonLearnableMove { Id = 1348, PokemonId = 88, MoveId = 6 },
    new PokemonLearnableMove { Id = 1349, PokemonId = 88, MoveId = 20 },
    new PokemonLearnableMove { Id = 1350, PokemonId = 88, MoveId = 31 },
    new PokemonLearnableMove { Id = 1351, PokemonId = 88, MoveId = 34 },
    new PokemonLearnableMove { Id = 1352, PokemonId = 88, MoveId = 35 },
    new PokemonLearnableMove { Id = 1353, PokemonId = 88, MoveId = 36 },
    new PokemonLearnableMove { Id = 1354, PokemonId = 88, MoveId = 47 },
    new PokemonLearnableMove { Id = 1355, PokemonId = 88, MoveId = 44 },
    new PokemonLearnableMove { Id = 1356, PokemonId = 88, MoveId = 50 },
    new PokemonLearnableMove { Id = 1357, PokemonId = 88, MoveId = 58 },
    new PokemonLearnableMove { Id = 1358, PokemonId = 88, MoveId = 87 },
    new PokemonLearnableMove { Id = 1359, PokemonId = 88, MoveId = 66 },
    new PokemonLearnableMove { Id = 1360, PokemonId = 88, MoveId = 78 },
    new PokemonLearnableMove { Id = 1361, PokemonId = 89, MoveId = 24 },
    new PokemonLearnableMove { Id = 1362, PokemonId = 89, MoveId = 25 },
    new PokemonLearnableMove { Id = 1363, PokemonId = 89, MoveId = 28 },
    new PokemonLearnableMove { Id = 1364, PokemonId = 89, MoveId = 6 },
    new PokemonLearnableMove { Id = 1365, PokemonId = 89, MoveId = 20 },
    new PokemonLearnableMove { Id = 1366, PokemonId = 89, MoveId = 31 },
    new PokemonLearnableMove { Id = 1367, PokemonId = 89, MoveId = 34 },
    new PokemonLearnableMove { Id = 1368, PokemonId = 89, MoveId = 35 },
    new PokemonLearnableMove { Id = 1369, PokemonId = 89, MoveId = 36 },
    new PokemonLearnableMove { Id = 1370, PokemonId = 89, MoveId = 39 },
    new PokemonLearnableMove { Id = 1371, PokemonId = 89, MoveId = 47 },
    new PokemonLearnableMove { Id = 1372, PokemonId = 89, MoveId = 44 },
    new PokemonLearnableMove { Id = 1373, PokemonId = 89, MoveId = 50 },
    new PokemonLearnableMove { Id = 1374, PokemonId = 89, MoveId = 58 },
    new PokemonLearnableMove { Id = 1375, PokemonId = 89, MoveId = 87 },
    new PokemonLearnableMove { Id = 1376, PokemonId = 89, MoveId = 66 },
    new PokemonLearnableMove { Id = 1377, PokemonId = 89, MoveId = 78 },
    new PokemonLearnableMove { Id = 1378, PokemonId = 90, MoveId = 10 },
    new PokemonLearnableMove { Id = 1379, PokemonId = 90, MoveId = 14 },
    new PokemonLearnableMove { Id = 1380, PokemonId = 90, MoveId = 6 },
    new PokemonLearnableMove { Id = 1381, PokemonId = 90, MoveId = 20 },
    new PokemonLearnableMove { Id = 1382, PokemonId = 90, MoveId = 30 },
    new PokemonLearnableMove { Id = 1383, PokemonId = 90, MoveId = 31 },
    new PokemonLearnableMove { Id = 1384, PokemonId = 90, MoveId = 33 },
    new PokemonLearnableMove { Id = 1385, PokemonId = 90, MoveId = 34 },
    new PokemonLearnableMove { Id = 1386, PokemonId = 90, MoveId = 36 },
    new PokemonLearnableMove { Id = 1387, PokemonId = 90, MoveId = 39 },
    new PokemonLearnableMove { Id = 1388, PokemonId = 90, MoveId = 47 },
    new PokemonLearnableMove { Id = 1389, PokemonId = 90, MoveId = 44 },
    new PokemonLearnableMove { Id = 1390, PokemonId = 90, MoveId = 50 },
    new PokemonLearnableMove { Id = 1391, PokemonId = 90, MoveId = 58 },
    new PokemonLearnableMove { Id = 1392, PokemonId = 90, MoveId = 87 },
    new PokemonLearnableMove { Id = 1393, PokemonId = 90, MoveId = 66 },
    new PokemonLearnableMove { Id = 1394, PokemonId = 90, MoveId = 78 },
    new PokemonLearnableMove { Id = 1395, PokemonId = 91, MoveId = 10 },
    new PokemonLearnableMove { Id = 1396, PokemonId = 91, MoveId = 14 },
    new PokemonLearnableMove { Id = 1397, PokemonId = 91, MoveId = 6 },
    new PokemonLearnableMove { Id = 1398, PokemonId = 91, MoveId = 20 },
    new PokemonLearnableMove { Id = 1399, PokemonId = 91, MoveId = 30 },
    new PokemonLearnableMove { Id = 1400, PokemonId = 91, MoveId = 31 },
    new PokemonLearnableMove { Id = 1401, PokemonId = 91, MoveId = 33 },
    new PokemonLearnableMove { Id = 1402, PokemonId = 91, MoveId = 34 },
    new PokemonLearnableMove { Id = 1403, PokemonId = 91, MoveId = 36 },
    new PokemonLearnableMove { Id = 1404, PokemonId = 91, MoveId = 39 },
    new PokemonLearnableMove { Id = 1405, PokemonId = 91, MoveId = 47 },
    new PokemonLearnableMove { Id = 1406, PokemonId = 91, MoveId = 44 },
    new PokemonLearnableMove { Id = 1407, PokemonId = 91, MoveId = 50 },
    new PokemonLearnableMove { Id = 1408, PokemonId = 91, MoveId = 58 },
    new PokemonLearnableMove { Id = 1409, PokemonId = 91, MoveId = 87 },
    new PokemonLearnableMove { Id = 1410, PokemonId = 91, MoveId = 55 },
    new PokemonLearnableMove { Id = 1411, PokemonId = 91, MoveId = 66 },
    new PokemonLearnableMove { Id = 1412, PokemonId = 91, MoveId = 72 },
    new PokemonLearnableMove { Id = 1413, PokemonId = 91, MoveId = 78 },
    new PokemonLearnableMove { Id = 1414, PokemonId = 92, MoveId = 24 },
    new PokemonLearnableMove { Id = 1415, PokemonId = 92, MoveId = 25 },
    new PokemonLearnableMove { Id = 1416, PokemonId = 92, MoveId = 6 },
    new PokemonLearnableMove { Id = 1417, PokemonId = 92, MoveId = 29 },
    new PokemonLearnableMove { Id = 1418, PokemonId = 92, MoveId = 20 },
    new PokemonLearnableMove { Id = 1419, PokemonId = 92, MoveId = 31 },
    new PokemonLearnableMove { Id = 1420, PokemonId = 92, MoveId = 34 },
    new PokemonLearnableMove { Id = 1421, PokemonId = 92, MoveId = 36 },
    new PokemonLearnableMove { Id = 1422, PokemonId = 92, MoveId = 46 },
    new PokemonLearnableMove { Id = 1423, PokemonId = 92, MoveId = 47 },
    new PokemonLearnableMove { Id = 1424, PokemonId = 92, MoveId = 44 },
    new PokemonLearnableMove { Id = 1425, PokemonId = 92, MoveId = 50 },
    new PokemonLearnableMove { Id = 1426, PokemonId = 92, MoveId = 58 },
    new PokemonLearnableMove { Id = 1427, PokemonId = 92, MoveId = 87 },
    new PokemonLearnableMove { Id = 1428, PokemonId = 92, MoveId = 63 },
    new PokemonLearnableMove { Id = 1429, PokemonId = 92, MoveId = 78 },
    new PokemonLearnableMove { Id = 1430, PokemonId = 93, MoveId = 24 },
    new PokemonLearnableMove { Id = 1431, PokemonId = 93, MoveId = 25 },
    new PokemonLearnableMove { Id = 1432, PokemonId = 93, MoveId = 6 },
    new PokemonLearnableMove { Id = 1433, PokemonId = 93, MoveId = 29 },
    new PokemonLearnableMove { Id = 1434, PokemonId = 93, MoveId = 20 },
    new PokemonLearnableMove { Id = 1435, PokemonId = 93, MoveId = 31 },
    new PokemonLearnableMove { Id = 1436, PokemonId = 93, MoveId = 34 },
    new PokemonLearnableMove { Id = 1437, PokemonId = 93, MoveId = 35 },
    new PokemonLearnableMove { Id = 1438, PokemonId = 93, MoveId = 36 },
    new PokemonLearnableMove { Id = 1439, PokemonId = 93, MoveId = 46 },
    new PokemonLearnableMove { Id = 1440, PokemonId = 93, MoveId = 47 },
    new PokemonLearnableMove { Id = 1441, PokemonId = 93, MoveId = 44 },
    new PokemonLearnableMove { Id = 1442, PokemonId = 93, MoveId = 50 },
    new PokemonLearnableMove { Id = 1443, PokemonId = 93, MoveId = 58 },
    new PokemonLearnableMove { Id = 1444, PokemonId = 93, MoveId = 87 },
    new PokemonLearnableMove { Id = 1445, PokemonId = 93, MoveId = 61 },
    new PokemonLearnableMove { Id = 1446, PokemonId = 93, MoveId = 63 },
    new PokemonLearnableMove { Id = 1447, PokemonId = 93, MoveId = 56 },
    new PokemonLearnableMove { Id = 1448, PokemonId = 93, MoveId = 78 },
    new PokemonLearnableMove { Id = 1449, PokemonId = 94, MoveId = 10 },
    new PokemonLearnableMove { Id = 1450, PokemonId = 94, MoveId = 17 },
    new PokemonLearnableMove { Id = 1451, PokemonId = 94, MoveId = 18 },
    new PokemonLearnableMove { Id = 1452, PokemonId = 94, MoveId = 24 },
    new PokemonLearnableMove { Id = 1453, PokemonId = 94, MoveId = 25 },
    new PokemonLearnableMove { Id = 1454, PokemonId = 94, MoveId = 6 },
    new PokemonLearnableMove { Id = 1455, PokemonId = 94, MoveId = 29 },
    new PokemonLearnableMove { Id = 1456, PokemonId = 94, MoveId = 20 },
    new PokemonLearnableMove { Id = 1457, PokemonId = 94, MoveId = 31 },
    new PokemonLearnableMove { Id = 1458, PokemonId = 94, MoveId = 34 },
    new PokemonLearnableMove { Id = 1459, PokemonId = 94, MoveId = 35 },
    new PokemonLearnableMove { Id = 1460, PokemonId = 94, MoveId = 36 },
    new PokemonLearnableMove { Id = 1461, PokemonId = 94, MoveId = 46 },
    new PokemonLearnableMove { Id = 1462, PokemonId = 94, MoveId = 47 },
    new PokemonLearnableMove { Id = 1463, PokemonId = 94, MoveId = 44 },
    new PokemonLearnableMove { Id = 1464, PokemonId = 94, MoveId = 50 },
    new PokemonLearnableMove { Id = 1465, PokemonId = 94, MoveId = 58 },
    new PokemonLearnableMove { Id = 1466, PokemonId = 94, MoveId = 87 },
    new PokemonLearnableMove { Id = 1467, PokemonId = 94, MoveId = 61 },
    new PokemonLearnableMove { Id = 1468, PokemonId = 94, MoveId = 63 },
    new PokemonLearnableMove { Id = 1469, PokemonId = 94, MoveId = 56 },
    new PokemonLearnableMove { Id = 1470, PokemonId = 94, MoveId = 78 },
    new PokemonLearnableMove { Id = 1471, PokemonId = 95, MoveId = 10 },
    new PokemonLearnableMove { Id = 1472, PokemonId = 95, MoveId = 26 },
    new PokemonLearnableMove { Id = 1473, PokemonId = 95, MoveId = 27 },
    new PokemonLearnableMove { Id = 1474, PokemonId = 95, MoveId = 28 },
    new PokemonLearnableMove { Id = 1475, PokemonId = 95, MoveId = 6 },
    new PokemonLearnableMove { Id = 1476, PokemonId = 95, MoveId = 31 },
    new PokemonLearnableMove { Id = 1477, PokemonId = 95, MoveId = 34 },
    new PokemonLearnableMove { Id = 1478, PokemonId = 95, MoveId = 36 },
    new PokemonLearnableMove { Id = 1479, PokemonId = 95, MoveId = 47 },
    new PokemonLearnableMove { Id = 1480, PokemonId = 95, MoveId = 44 },
    new PokemonLearnableMove { Id = 1481, PokemonId = 95, MoveId = 50 },
    new PokemonLearnableMove { Id = 1482, PokemonId = 95, MoveId = 58 },
    new PokemonLearnableMove { Id = 1483, PokemonId = 95, MoveId = 87 },
    new PokemonLearnableMove { Id = 1484, PokemonId = 95, MoveId = 66 },
    new PokemonLearnableMove { Id = 1485, PokemonId = 95, MoveId = 78 },
    new PokemonLearnableMove { Id = 1486, PokemonId = 96, MoveId = 10 },
    new PokemonLearnableMove { Id = 1487, PokemonId = 96, MoveId = 17 },
    new PokemonLearnableMove { Id = 1488, PokemonId = 96, MoveId = 18 },
    new PokemonLearnableMove { Id = 1489, PokemonId = 96, MoveId = 6 },
    new PokemonLearnableMove { Id = 1490, PokemonId = 96, MoveId = 20 },
    new PokemonLearnableMove { Id = 1491, PokemonId = 96, MoveId = 30 },
    new PokemonLearnableMove { Id = 1492, PokemonId = 96, MoveId = 31 },
    new PokemonLearnableMove { Id = 1493, PokemonId = 96, MoveId = 33 },
    new PokemonLearnableMove { Id = 1494, PokemonId = 96, MoveId = 34 },
    new PokemonLearnableMove { Id = 1495, PokemonId = 96, MoveId = 35 },
    new PokemonLearnableMove { Id = 1496, PokemonId = 96, MoveId = 39 },
    new PokemonLearnableMove { Id = 1497, PokemonId = 96, MoveId = 70 },
    new PokemonLearnableMove { Id = 1498, PokemonId = 96, MoveId = 46 },
    new PokemonLearnableMove { Id = 1499, PokemonId = 96, MoveId = 44 },
    new PokemonLearnableMove { Id = 1500, PokemonId = 96, MoveId = 50 },
    new PokemonLearnableMove { Id = 1501, PokemonId = 96, MoveId = 58 },
    new PokemonLearnableMove { Id = 1502, PokemonId = 96, MoveId = 87 },
    new PokemonLearnableMove { Id = 1503, PokemonId = 96, MoveId = 67 },
    new PokemonLearnableMove { Id = 1504, PokemonId = 96, MoveId = 56 },
    new PokemonLearnableMove { Id = 1505, PokemonId = 96, MoveId = 78 },
    new PokemonLearnableMove { Id = 1506, PokemonId = 97, MoveId = 10 },
    new PokemonLearnableMove { Id = 1507, PokemonId = 97, MoveId = 17 },
    new PokemonLearnableMove { Id = 1508, PokemonId = 97, MoveId = 18 },
    new PokemonLearnableMove { Id = 1509, PokemonId = 97, MoveId = 6 },
    new PokemonLearnableMove { Id = 1510, PokemonId = 97, MoveId = 20 },
    new PokemonLearnableMove { Id = 1511, PokemonId = 97, MoveId = 30 },
    new PokemonLearnableMove { Id = 1512, PokemonId = 97, MoveId = 31 },
    new PokemonLearnableMove { Id = 1513, PokemonId = 97, MoveId = 33 },
    new PokemonLearnableMove { Id = 1514, PokemonId = 97, MoveId = 34 },
    new PokemonLearnableMove { Id = 1515, PokemonId = 97, MoveId = 35 },
    new PokemonLearnableMove { Id = 1516, PokemonId = 97, MoveId = 39 },
    new PokemonLearnableMove { Id = 1517, PokemonId = 97, MoveId = 70 },
    new PokemonLearnableMove { Id = 1518, PokemonId = 97, MoveId = 46 },
    new PokemonLearnableMove { Id = 1519, PokemonId = 97, MoveId = 44 },
    new PokemonLearnableMove { Id = 1520, PokemonId = 97, MoveId = 50 },
    new PokemonLearnableMove { Id = 1521, PokemonId = 97, MoveId = 58 },
    new PokemonLearnableMove { Id = 1522, PokemonId = 97, MoveId = 87 },
    new PokemonLearnableMove { Id = 1523, PokemonId = 97, MoveId = 67 },
    new PokemonLearnableMove { Id = 1524, PokemonId = 97, MoveId = 56 },
    new PokemonLearnableMove { Id = 1525, PokemonId = 97, MoveId = 78 },
    new PokemonLearnableMove { Id = 1526, PokemonId = 98, MoveId = 10 },
    new PokemonLearnableMove { Id = 1527, PokemonId = 98, MoveId = 14 },
    new PokemonLearnableMove { Id = 1528, PokemonId = 98, MoveId = 6 },
    new PokemonLearnableMove { Id = 1529, PokemonId = 98, MoveId = 20 },
    new PokemonLearnableMove { Id = 1530, PokemonId = 98, MoveId = 31 },
    new PokemonLearnableMove { Id = 1531, PokemonId = 98, MoveId = 34 },
    new PokemonLearnableMove { Id = 1532, PokemonId = 98, MoveId = 44 },
    new PokemonLearnableMove { Id = 1533, PokemonId = 98, MoveId = 50 },
    new PokemonLearnableMove { Id = 1534, PokemonId = 98, MoveId = 58 },
    new PokemonLearnableMove { Id = 1535, PokemonId = 98, MoveId = 87 },
    new PokemonLearnableMove { Id = 1536, PokemonId = 98, MoveId = 56 },
    new PokemonLearnableMove { Id = 1537, PokemonId = 98, MoveId = 81 },
    new PokemonLearnableMove { Id = 1538, PokemonId = 98, MoveId = 78 },
    new PokemonLearnableMove { Id = 1539, PokemonId = 99, MoveId = 10 },
    new PokemonLearnableMove { Id = 1540, PokemonId = 99, MoveId = 14 },
    new PokemonLearnableMove { Id = 1541, PokemonId = 99, MoveId = 28 },
    new PokemonLearnableMove { Id = 1542, PokemonId = 99, MoveId = 6 },
    new PokemonLearnableMove { Id = 1543, PokemonId = 99, MoveId = 20 },
    new PokemonLearnableMove { Id = 1544, PokemonId = 99, MoveId = 31 },
    new PokemonLearnableMove { Id = 1545, PokemonId = 99, MoveId = 34 },
    new PokemonLearnableMove { Id = 1546, PokemonId = 99, MoveId = 44 },
    new PokemonLearnableMove { Id = 1547, PokemonId = 99, MoveId = 50 },
    new PokemonLearnableMove { Id = 1548, PokemonId = 99, MoveId = 58 },
    new PokemonLearnableMove { Id = 1549, PokemonId = 99, MoveId = 87 },
    new PokemonLearnableMove { Id = 1550, PokemonId = 99, MoveId = 56 },
    new PokemonLearnableMove { Id = 1551, PokemonId = 99, MoveId = 81 },
    new PokemonLearnableMove { Id = 1552, PokemonId = 99, MoveId = 78 },
    new PokemonLearnableMove { Id = 1553, PokemonId = 100, MoveId = 24 },
    new PokemonLearnableMove { Id = 1554, PokemonId = 100, MoveId = 25 },
    new PokemonLearnableMove { Id = 1555, PokemonId = 100, MoveId = 6 },
    new PokemonLearnableMove { Id = 1556, PokemonId = 100, MoveId = 20 },
    new PokemonLearnableMove { Id = 1557, PokemonId = 100, MoveId = 30 },
    new PokemonLearnableMove { Id = 1558, PokemonId = 100, MoveId = 31 },
    new PokemonLearnableMove { Id = 1559, PokemonId = 100, MoveId = 33 },
    new PokemonLearnableMove { Id = 1560, PokemonId = 100, MoveId = 34 },
    new PokemonLearnableMove { Id = 1561, PokemonId = 100, MoveId = 70 },
    new PokemonLearnableMove { Id = 1562, PokemonId = 100, MoveId = 44 },
    new PokemonLearnableMove { Id = 1563, PokemonId = 100, MoveId = 50 },
    new PokemonLearnableMove { Id = 1564, PokemonId = 100, MoveId = 58 },
    new PokemonLearnableMove { Id = 1565, PokemonId = 100, MoveId = 87 },
    new PokemonLearnableMove { Id = 1566, PokemonId = 101, MoveId = 24 },
    new PokemonLearnableMove { Id = 1567, PokemonId = 101, MoveId = 25 },
    new PokemonLearnableMove { Id = 1568, PokemonId = 101, MoveId = 6 },
    new PokemonLearnableMove { Id = 1569, PokemonId = 101, MoveId = 20 },
    new PokemonLearnableMove { Id = 1570, PokemonId = 101, MoveId = 30 },
    new PokemonLearnableMove { Id = 1571, PokemonId = 101, MoveId = 31 },
    new PokemonLearnableMove { Id = 1572, PokemonId = 101, MoveId = 33 },
    new PokemonLearnableMove { Id = 1573, PokemonId = 101, MoveId = 34 },
    new PokemonLearnableMove { Id = 1574, PokemonId = 101, MoveId = 70 },
    new PokemonLearnableMove { Id = 1575, PokemonId = 101, MoveId = 44 },
    new PokemonLearnableMove { Id = 1576, PokemonId = 101, MoveId = 50 },
    new PokemonLearnableMove { Id = 1577, PokemonId = 101, MoveId = 58 },
    new PokemonLearnableMove { Id = 1578, PokemonId = 101, MoveId = 87 },
    new PokemonLearnableMove { Id = 1579, PokemonId = 102, MoveId = 10 },
    new PokemonLearnableMove { Id = 1580, PokemonId = 102, MoveId = 6 },
    new PokemonLearnableMove { Id = 1581, PokemonId = 102, MoveId = 29 },
    new PokemonLearnableMove { Id = 1582, PokemonId = 102, MoveId = 20 },
    new PokemonLearnableMove { Id = 1583, PokemonId = 102, MoveId = 30 },
    new PokemonLearnableMove { Id = 1584, PokemonId = 102, MoveId = 31 },
    new PokemonLearnableMove { Id = 1585, PokemonId = 102, MoveId = 34 },
    new PokemonLearnableMove { Id = 1586, PokemonId = 102, MoveId = 36 },
    new PokemonLearnableMove { Id = 1587, PokemonId = 102, MoveId = 70 },
    new PokemonLearnableMove { Id = 1588, PokemonId = 102, MoveId = 46 },
    new PokemonLearnableMove { Id = 1589, PokemonId = 102, MoveId = 47 },
    new PokemonLearnableMove { Id = 1590, PokemonId = 102, MoveId = 44 },
    new PokemonLearnableMove { Id = 1591, PokemonId = 102, MoveId = 50 },
    new PokemonLearnableMove { Id = 1592, PokemonId = 102, MoveId = 58 },
    new PokemonLearnableMove { Id = 1593, PokemonId = 102, MoveId = 87 },
    new PokemonLearnableMove { Id = 1594, PokemonId = 102, MoveId = 78 },
    new PokemonLearnableMove { Id = 1595, PokemonId = 103, MoveId = 10 },
    new PokemonLearnableMove { Id = 1596, PokemonId = 103, MoveId = 6 },
    new PokemonLearnableMove { Id = 1597, PokemonId = 103, MoveId = 29 },
    new PokemonLearnableMove { Id = 1598, PokemonId = 103, MoveId = 20 },
    new PokemonLearnableMove { Id = 1599, PokemonId = 103, MoveId = 30 },
    new PokemonLearnableMove { Id = 1600, PokemonId = 103, MoveId = 31 },
new PokemonLearnableMove { Id = 1601, PokemonId = 103, MoveId = 33 },
    new PokemonLearnableMove { Id = 1602, PokemonId = 103, MoveId = 34 },
    new PokemonLearnableMove { Id = 1603, PokemonId = 103, MoveId = 36 },
    new PokemonLearnableMove { Id = 1604, PokemonId = 103, MoveId = 70 },
    new PokemonLearnableMove { Id = 1605, PokemonId = 103, MoveId = 46 },
    new PokemonLearnableMove { Id = 1606, PokemonId = 103, MoveId = 47 },
    new PokemonLearnableMove { Id = 1607, PokemonId = 103, MoveId = 44 },
    new PokemonLearnableMove { Id = 1608, PokemonId = 103, MoveId = 50 },
    new PokemonLearnableMove { Id = 1609, PokemonId = 103, MoveId = 58 },
    new PokemonLearnableMove { Id = 1610, PokemonId = 103, MoveId = 87 },
    new PokemonLearnableMove { Id = 1611, PokemonId = 103, MoveId = 78 },
    new PokemonLearnableMove { Id = 1612, PokemonId = 104, MoveId = 10 },
    new PokemonLearnableMove { Id = 1613, PokemonId = 104, MoveId = 14 },
    new PokemonLearnableMove { Id = 1614, PokemonId = 104, MoveId = 17 },
    new PokemonLearnableMove { Id = 1615, PokemonId = 104, MoveId = 18 },
    new PokemonLearnableMove { Id = 1616, PokemonId = 104, MoveId = 26 },
    new PokemonLearnableMove { Id = 1617, PokemonId = 104, MoveId = 27 },
    new PokemonLearnableMove { Id = 1618, PokemonId = 104, MoveId = 28 },
    new PokemonLearnableMove { Id = 1619, PokemonId = 104, MoveId = 6 },
    new PokemonLearnableMove { Id = 1620, PokemonId = 104, MoveId = 31 },
    new PokemonLearnableMove { Id = 1621, PokemonId = 104, MoveId = 34 },
    new PokemonLearnableMove { Id = 1622, PokemonId = 104, MoveId = 39 },
    new PokemonLearnableMove { Id = 1623, PokemonId = 104, MoveId = 44 },
    new PokemonLearnableMove { Id = 1624, PokemonId = 104, MoveId = 50 },
    new PokemonLearnableMove { Id = 1625, PokemonId = 104, MoveId = 58 },
    new PokemonLearnableMove { Id = 1626, PokemonId = 104, MoveId = 87 },
    new PokemonLearnableMove { Id = 1627, PokemonId = 104, MoveId = 78 },
    new PokemonLearnableMove { Id = 1628, PokemonId = 105, MoveId = 10 },
    new PokemonLearnableMove { Id = 1629, PokemonId = 105, MoveId = 14 },
    new PokemonLearnableMove { Id = 1630, PokemonId = 105, MoveId = 17 },
    new PokemonLearnableMove { Id = 1631, PokemonId = 105, MoveId = 18 },
    new PokemonLearnableMove { Id = 1632, PokemonId = 105, MoveId = 26 },
    new PokemonLearnableMove { Id = 1633, PokemonId = 105, MoveId = 27 },
    new PokemonLearnableMove { Id = 1634, PokemonId = 105, MoveId = 28 },
    new PokemonLearnableMove { Id = 1635, PokemonId = 105, MoveId = 6 },
    new PokemonLearnableMove { Id = 1636, PokemonId = 105, MoveId = 31 },
    new PokemonLearnableMove { Id = 1637, PokemonId = 105, MoveId = 34 },
    new PokemonLearnableMove { Id = 1638, PokemonId = 105, MoveId = 39 },
    new PokemonLearnableMove { Id = 1639, PokemonId = 105, MoveId = 44 },
    new PokemonLearnableMove { Id = 1640, PokemonId = 105, MoveId = 50 },
    new PokemonLearnableMove { Id = 1641, PokemonId = 105, MoveId = 58 },
    new PokemonLearnableMove { Id = 1642, PokemonId = 105, MoveId = 87 },
    new PokemonLearnableMove { Id = 1643, PokemonId = 105, MoveId = 78 },
    new PokemonLearnableMove { Id = 1644, PokemonId = 106, MoveId = 10 },
    new PokemonLearnableMove { Id = 1645, PokemonId = 106, MoveId = 17 },
    new PokemonLearnableMove { Id = 1646, PokemonId = 106, MoveId = 18 },
    new PokemonLearnableMove { Id = 1647, PokemonId = 106, MoveId = 26 },
    new PokemonLearnableMove { Id = 1648, PokemonId = 106, MoveId = 6 },
    new PokemonLearnableMove { Id = 1649, PokemonId = 106, MoveId = 20 },
    new PokemonLearnableMove { Id = 1650, PokemonId = 106, MoveId = 31 },
    new PokemonLearnableMove { Id = 1651, PokemonId = 106, MoveId = 34 },
    new PokemonLearnableMove { Id = 1652, PokemonId = 106, MoveId = 35 },
    new PokemonLearnableMove { Id = 1653, PokemonId = 106, MoveId = 39 },
    new PokemonLearnableMove { Id = 1654, PokemonId = 106, MoveId = 44 },
    new PokemonLearnableMove { Id = 1655, PokemonId = 106, MoveId = 50 },
    new PokemonLearnableMove { Id = 1656, PokemonId = 106, MoveId = 87 },
    new PokemonLearnableMove { Id = 1657, PokemonId = 106, MoveId = 56 },
    new PokemonLearnableMove { Id = 1658, PokemonId = 106, MoveId = 78 },
    new PokemonLearnableMove { Id = 1659, PokemonId = 107, MoveId = 10 },
    new PokemonLearnableMove { Id = 1660, PokemonId = 107, MoveId = 17 },
    new PokemonLearnableMove { Id = 1661, PokemonId = 107, MoveId = 26 },
    new PokemonLearnableMove { Id = 1662, PokemonId = 107, MoveId = 6 },
    new PokemonLearnableMove { Id = 1663, PokemonId = 107, MoveId = 20 },
    new PokemonLearnableMove { Id = 1664, PokemonId = 107, MoveId = 31 },
    new PokemonLearnableMove { Id = 1665, PokemonId = 107, MoveId = 34 },
    new PokemonLearnableMove { Id = 1666, PokemonId = 107, MoveId = 35 },
    new PokemonLearnableMove { Id = 1667, PokemonId = 107, MoveId = 39 },
    new PokemonLearnableMove { Id = 1668, PokemonId = 107, MoveId = 44 },
    new PokemonLearnableMove { Id = 1669, PokemonId = 107, MoveId = 50 },
    new PokemonLearnableMove { Id = 1670, PokemonId = 107, MoveId = 58 },
    new PokemonLearnableMove { Id = 1671, PokemonId = 107, MoveId = 87 },
    new PokemonLearnableMove { Id = 1672, PokemonId = 107, MoveId = 56 },
    new PokemonLearnableMove { Id = 1673, PokemonId = 107, MoveId = 78 },
    new PokemonLearnableMove { Id = 1674, PokemonId = 108, MoveId = 10 },
    new PokemonLearnableMove { Id = 1675, PokemonId = 108, MoveId = 14 },
    new PokemonLearnableMove { Id = 1676, PokemonId = 108, MoveId = 17 },
    new PokemonLearnableMove { Id = 1677, PokemonId = 108, MoveId = 18 },
    new PokemonLearnableMove { Id = 1678, PokemonId = 108, MoveId = 24 },
    new PokemonLearnableMove { Id = 1679, PokemonId = 108, MoveId = 25 },
    new PokemonLearnableMove { Id = 1680, PokemonId = 108, MoveId = 26 },
    new PokemonLearnableMove { Id = 1681, PokemonId = 108, MoveId = 27 },
    new PokemonLearnableMove { Id = 1682, PokemonId = 108, MoveId = 28 },
    new PokemonLearnableMove { Id = 1683, PokemonId = 108, MoveId = 6 },
    new PokemonLearnableMove { Id = 1684, PokemonId = 108, MoveId = 20 },
    new PokemonLearnableMove { Id = 1685, PokemonId = 108, MoveId = 31 },
    new PokemonLearnableMove { Id = 1686, PokemonId = 108, MoveId = 34 },
    new PokemonLearnableMove { Id = 1687, PokemonId = 108, MoveId = 44 },
    new PokemonLearnableMove { Id = 1688, PokemonId = 108, MoveId = 50 },
    new PokemonLearnableMove { Id = 1689, PokemonId = 108, MoveId = 58 },
    new PokemonLearnableMove { Id = 1690, PokemonId = 108, MoveId = 87 },
    new PokemonLearnableMove { Id = 1691, PokemonId = 108, MoveId = 56 },
    new PokemonLearnableMove { Id = 1692, PokemonId = 108, MoveId = 78 },
    new PokemonLearnableMove { Id = 1693, PokemonId = 109, MoveId = 24 },
    new PokemonLearnableMove { Id = 1694, PokemonId = 109, MoveId = 25 },
    new PokemonLearnableMove { Id = 1695, PokemonId = 109, MoveId = 6 },
    new PokemonLearnableMove { Id = 1696, PokemonId = 109, MoveId = 20 },
    new PokemonLearnableMove { Id = 1697, PokemonId = 109, MoveId = 31 },
    new PokemonLearnableMove { Id = 1698, PokemonId = 109, MoveId = 34 },
    new PokemonLearnableMove { Id = 1699, PokemonId = 109, MoveId = 70 },
new PokemonLearnableMove { Id = 1700, PokemonId = 109, MoveId = 44 },
new PokemonLearnableMove { Id = 1701, PokemonId = 109, MoveId = 50 },
    new PokemonLearnableMove { Id = 1702, PokemonId = 109, MoveId = 58 },
    new PokemonLearnableMove { Id = 1703, PokemonId = 109, MoveId = 87 },
    new PokemonLearnableMove { Id = 1704, PokemonId = 109, MoveId = 66 },
    new PokemonLearnableMove { Id = 1705, PokemonId = 109, MoveId = 78 },
    new PokemonLearnableMove { Id = 1706, PokemonId = 110, MoveId = 24 },
    new PokemonLearnableMove { Id = 1707, PokemonId = 110, MoveId = 25 },
    new PokemonLearnableMove { Id = 1708, PokemonId = 110, MoveId = 6 },
    new PokemonLearnableMove { Id = 1709, PokemonId = 110, MoveId = 20 },
    new PokemonLearnableMove { Id = 1710, PokemonId = 110, MoveId = 31 },
    new PokemonLearnableMove { Id = 1711, PokemonId = 110, MoveId = 34 },
    new PokemonLearnableMove { Id = 1712, PokemonId = 110, MoveId = 70 },
    new PokemonLearnableMove { Id = 1713, PokemonId = 110, MoveId = 44 },
    new PokemonLearnableMove { Id = 1714, PokemonId = 110, MoveId = 50 },
    new PokemonLearnableMove { Id = 1715, PokemonId = 110, MoveId = 58 },
    new PokemonLearnableMove { Id = 1716, PokemonId = 110, MoveId = 87 },
    new PokemonLearnableMove { Id = 1717, PokemonId = 110, MoveId = 61 },
    new PokemonLearnableMove { Id = 1718, PokemonId = 110, MoveId = 66 },
    new PokemonLearnableMove { Id = 1719, PokemonId = 110, MoveId = 78 },
    new PokemonLearnableMove { Id = 1720, PokemonId = 111, MoveId = 10 },
    new PokemonLearnableMove { Id = 1721, PokemonId = 111, MoveId = 14 },
    new PokemonLearnableMove { Id = 1722, PokemonId = 111, MoveId = 24 },
    new PokemonLearnableMove { Id = 1723, PokemonId = 111, MoveId = 25 },
    new PokemonLearnableMove { Id = 1724, PokemonId = 111, MoveId = 26 },
    new PokemonLearnableMove { Id = 1725, PokemonId = 111, MoveId = 27 },
    new PokemonLearnableMove { Id = 1726, PokemonId = 111, MoveId = 28 },
    new PokemonLearnableMove { Id = 1727, PokemonId = 111, MoveId = 6 },
    new PokemonLearnableMove { Id = 1728, PokemonId = 111, MoveId = 20 },
    new PokemonLearnableMove { Id = 1729, PokemonId = 111, MoveId = 31 },
    new PokemonLearnableMove { Id = 1730, PokemonId = 111, MoveId = 34 },
    new PokemonLearnableMove { Id = 1731, PokemonId = 111, MoveId = 44 },
    new PokemonLearnableMove { Id = 1732, PokemonId = 111, MoveId = 50 },
    new PokemonLearnableMove { Id = 1733, PokemonId = 111, MoveId = 58 },
    new PokemonLearnableMove { Id = 1734, PokemonId = 111, MoveId = 87 },
    new PokemonLearnableMove { Id = 1735, PokemonId = 111, MoveId = 66 },
    new PokemonLearnableMove { Id = 1736, PokemonId = 111, MoveId = 78 },
    new PokemonLearnableMove { Id = 1737, PokemonId = 112, MoveId = 10 },
    new PokemonLearnableMove { Id = 1738, PokemonId = 112, MoveId = 14 },
    new PokemonLearnableMove { Id = 1739, PokemonId = 112, MoveId = 17 },
    new PokemonLearnableMove { Id = 1740, PokemonId = 112, MoveId = 18 },
    new PokemonLearnableMove { Id = 1741, PokemonId = 112, MoveId = 24 },
    new PokemonLearnableMove { Id = 1742, PokemonId = 112, MoveId = 25 },
    new PokemonLearnableMove { Id = 1743, PokemonId = 112, MoveId = 26 },
    new PokemonLearnableMove { Id = 1744, PokemonId = 112, MoveId = 27 },
    new PokemonLearnableMove { Id = 1745, PokemonId = 112, MoveId = 28 },
    new PokemonLearnableMove { Id = 1746, PokemonId = 112, MoveId = 6 },
    new PokemonLearnableMove { Id = 1747, PokemonId = 112, MoveId = 20 },
    new PokemonLearnableMove { Id = 1748, PokemonId = 112, MoveId = 31 },
    new PokemonLearnableMove { Id = 1749, PokemonId = 112, MoveId = 34 },
    new PokemonLearnableMove { Id = 1750, PokemonId = 112, MoveId = 44 },
    new PokemonLearnableMove { Id = 1751, PokemonId = 112, MoveId = 50 },
    new PokemonLearnableMove { Id = 1752, PokemonId = 112, MoveId = 58 },
    new PokemonLearnableMove { Id = 1753, PokemonId = 112, MoveId = 87 },
    new PokemonLearnableMove { Id = 1754, PokemonId = 112, MoveId = 66 },
    new PokemonLearnableMove { Id = 1755, PokemonId = 112, MoveId = 56 },
    new PokemonLearnableMove { Id = 1756, PokemonId = 112, MoveId = 72 },
    new PokemonLearnableMove { Id = 1757, PokemonId = 112, MoveId = 78 },
    new PokemonLearnableMove { Id = 1758, PokemonId = 113, MoveId = 14 },
    new PokemonLearnableMove { Id = 1759, PokemonId = 113, MoveId = 17 },
    new PokemonLearnableMove { Id = 1760, PokemonId = 113, MoveId = 18 },
    new PokemonLearnableMove { Id = 1761, PokemonId = 113, MoveId = 24 },
    new PokemonLearnableMove { Id = 1762, PokemonId = 113, MoveId = 25 },
    new PokemonLearnableMove { Id = 1763, PokemonId = 113, MoveId = 26 },
    new PokemonLearnableMove { Id = 1764, PokemonId = 113, MoveId = 6 },
    new PokemonLearnableMove { Id = 1765, PokemonId = 113, MoveId = 29 },
    new PokemonLearnableMove { Id = 1766, PokemonId = 113, MoveId = 20 },
    new PokemonLearnableMove { Id = 1767, PokemonId = 113, MoveId = 30 },
    new PokemonLearnableMove { Id = 1768, PokemonId = 113, MoveId = 31 },
    new PokemonLearnableMove { Id = 1769, PokemonId = 113, MoveId = 33 },
    new PokemonLearnableMove { Id = 1770, PokemonId = 113, MoveId = 34 },
    new PokemonLearnableMove { Id = 1771, PokemonId = 113, MoveId = 35 },
    new PokemonLearnableMove { Id = 1772, PokemonId = 113, MoveId = 39 },
    new PokemonLearnableMove { Id = 1773, PokemonId = 113, MoveId = 41 },
    new PokemonLearnableMove { Id = 1774, PokemonId = 113, MoveId = 70 },
    new PokemonLearnableMove { Id = 1775, PokemonId = 113, MoveId = 46 },
    new PokemonLearnableMove { Id = 1776, PokemonId = 113, MoveId = 44 },
    new PokemonLearnableMove { Id = 1777, PokemonId = 113, MoveId = 50 },
    new PokemonLearnableMove { Id = 1778, PokemonId = 113, MoveId = 58 },
    new PokemonLearnableMove { Id = 1779, PokemonId = 113, MoveId = 87 },
    new PokemonLearnableMove { Id = 1780, PokemonId = 113, MoveId = 67 },
    new PokemonLearnableMove { Id = 1781, PokemonId = 113, MoveId = 78 },
    new PokemonLearnableMove { Id = 1782, PokemonId = 114, MoveId = 10 },
    new PokemonLearnableMove { Id = 1783, PokemonId = 114, MoveId = 14 },
    new PokemonLearnableMove { Id = 1784, PokemonId = 114, MoveId = 17 },
    new PokemonLearnableMove { Id = 1785, PokemonId = 114, MoveId = 18 },
    new PokemonLearnableMove { Id = 1786, PokemonId = 114, MoveId = 26 },
    new PokemonLearnableMove { Id = 1787, PokemonId = 114, MoveId = 6 },
    new PokemonLearnableMove { Id = 1788, PokemonId = 114, MoveId = 20 },
    new PokemonLearnableMove { Id = 1789, PokemonId = 114, MoveId = 31 },
    new PokemonLearnableMove { Id = 1790, PokemonId = 114, MoveId = 34 },
    new PokemonLearnableMove { Id = 1791, PokemonId = 114, MoveId = 70 },
    new PokemonLearnableMove { Id = 1792, PokemonId = 114, MoveId = 44 },
    new PokemonLearnableMove { Id = 1793, PokemonId = 114, MoveId = 50 },
    new PokemonLearnableMove { Id = 1794, PokemonId = 114, MoveId = 58 },
    new PokemonLearnableMove { Id = 1795, PokemonId = 114, MoveId = 87 },
    new PokemonLearnableMove { Id = 1796, PokemonId = 114, MoveId = 78 },
    new PokemonLearnableMove { Id = 1797, PokemonId = 115, MoveId = 10 },
    new PokemonLearnableMove { Id = 1798, PokemonId = 115, MoveId = 14 },
    new PokemonLearnableMove { Id = 1799, PokemonId = 115, MoveId = 17 },
    new PokemonLearnableMove { Id = 1800, PokemonId = 115, MoveId = 18 },
new PokemonLearnableMove { Id = 1801, PokemonId = 115, MoveId = 28 },
    new PokemonLearnableMove { Id = 1802, PokemonId = 115, MoveId = 6 },
    new PokemonLearnableMove { Id = 1803, PokemonId = 115, MoveId = 31 },
    new PokemonLearnableMove { Id = 1804, PokemonId = 115, MoveId = 34 },
    new PokemonLearnableMove { Id = 1805, PokemonId = 115, MoveId = 44 },
    new PokemonLearnableMove { Id = 1806, PokemonId = 115, MoveId = 50 },
    new PokemonLearnableMove { Id = 1807, PokemonId = 115, MoveId = 87 },
    new PokemonLearnableMove { Id = 1808, PokemonId = 115, MoveId = 56 },
    new PokemonLearnableMove { Id = 1809, PokemonId = 115, MoveId = 72 },
    new PokemonLearnableMove { Id = 1810, PokemonId = 115, MoveId = 78 },
    new PokemonLearnableMove { Id = 1811, PokemonId = 116, MoveId = 10 },
    new PokemonLearnableMove { Id = 1812, PokemonId = 116, MoveId = 14 },
    new PokemonLearnableMove { Id = 1813, PokemonId = 116, MoveId = 6 },
    new PokemonLearnableMove { Id = 1814, PokemonId = 116, MoveId = 20 },
    new PokemonLearnableMove { Id = 1815, PokemonId = 116, MoveId = 31 },
    new PokemonLearnableMove { Id = 1816, PokemonId = 116, MoveId = 34 },
    new PokemonLearnableMove { Id = 1817, PokemonId = 116, MoveId = 39 },
    new PokemonLearnableMove { Id = 1818, PokemonId = 116, MoveId = 44 },
    new PokemonLearnableMove { Id = 1819, PokemonId = 116, MoveId = 50 },
    new PokemonLearnableMove { Id = 1820, PokemonId = 116, MoveId = 58 },
    new PokemonLearnableMove { Id = 1821, PokemonId = 116, MoveId = 87 },
    new PokemonLearnableMove { Id = 1822, PokemonId = 116, MoveId = 78 },
    new PokemonLearnableMove { Id = 1823, PokemonId = 117, MoveId = 10 },
    new PokemonLearnableMove { Id = 1824, PokemonId = 117, MoveId = 14 },
    new PokemonLearnableMove { Id = 1825, PokemonId = 117, MoveId = 6 },
    new PokemonLearnableMove { Id = 1826, PokemonId = 117, MoveId = 20 },
    new PokemonLearnableMove { Id = 1827, PokemonId = 117, MoveId = 31 },
    new PokemonLearnableMove { Id = 1828, PokemonId = 117, MoveId = 34 },
    new PokemonLearnableMove { Id = 1829, PokemonId = 117, MoveId = 39 },
    new PokemonLearnableMove { Id = 1830, PokemonId = 117, MoveId = 44 },
    new PokemonLearnableMove { Id = 1831, PokemonId = 117, MoveId = 50 },
    new PokemonLearnableMove { Id = 1832, PokemonId = 117, MoveId = 58 },
    new PokemonLearnableMove { Id = 1833, PokemonId = 117, MoveId = 87 },
    new PokemonLearnableMove { Id = 1834, PokemonId = 117, MoveId = 78 },
    new PokemonLearnableMove { Id = 1835, PokemonId = 118, MoveId = 10 },
    new PokemonLearnableMove { Id = 1836, PokemonId = 118, MoveId = 14 },
    new PokemonLearnableMove { Id = 1837, PokemonId = 118, MoveId = 6 },
    new PokemonLearnableMove { Id = 1838, PokemonId = 118, MoveId = 20 },
    new PokemonLearnableMove { Id = 1839, PokemonId = 118, MoveId = 31 },
    new PokemonLearnableMove { Id = 1840, PokemonId = 118, MoveId = 34 },
    new PokemonLearnableMove { Id = 1841, PokemonId = 118, MoveId = 39 },
    new PokemonLearnableMove { Id = 1842, PokemonId = 118, MoveId = 44 },
    new PokemonLearnableMove { Id = 1843, PokemonId = 118, MoveId = 50 },
    new PokemonLearnableMove { Id = 1844, PokemonId = 118, MoveId = 58 },
    new PokemonLearnableMove { Id = 1845, PokemonId = 118, MoveId = 87 },
    new PokemonLearnableMove { Id = 1846, PokemonId = 118, MoveId = 78 },
    new PokemonLearnableMove { Id = 1847, PokemonId = 119, MoveId = 10 },
    new PokemonLearnableMove { Id = 1848, PokemonId = 119, MoveId = 14 },
    new PokemonLearnableMove { Id = 1849, PokemonId = 119, MoveId = 6 },
    new PokemonLearnableMove { Id = 1850, PokemonId = 119, MoveId = 20 },
    new PokemonLearnableMove { Id = 1851, PokemonId = 119, MoveId = 31 },
    new PokemonLearnableMove { Id = 1852, PokemonId = 119, MoveId = 34 },
    new PokemonLearnableMove { Id = 1853, PokemonId = 119, MoveId = 39 },
    new PokemonLearnableMove { Id = 1854, PokemonId = 119, MoveId = 44 },
    new PokemonLearnableMove { Id = 1855, PokemonId = 119, MoveId = 50 },
    new PokemonLearnableMove { Id = 1856, PokemonId = 119, MoveId = 58 },
    new PokemonLearnableMove { Id = 1857, PokemonId = 119, MoveId = 87 },
    new PokemonLearnableMove { Id = 1858, PokemonId = 119, MoveId = 78 },
    new PokemonLearnableMove { Id = 1859, PokemonId = 120, MoveId = 10 },
    new PokemonLearnableMove { Id = 1860, PokemonId = 120, MoveId = 14 },
    new PokemonLearnableMove { Id = 1861, PokemonId = 120, MoveId = 24 },
    new PokemonLearnableMove { Id = 1862, PokemonId = 120, MoveId = 25 },
    new PokemonLearnableMove { Id = 1863, PokemonId = 120, MoveId = 6 },
    new PokemonLearnableMove { Id = 1864, PokemonId = 120, MoveId = 29 },
    new PokemonLearnableMove { Id = 1865, PokemonId = 120, MoveId = 20 },
    new PokemonLearnableMove { Id = 1866, PokemonId = 120, MoveId = 30 },
    new PokemonLearnableMove { Id = 1867, PokemonId = 120, MoveId = 31 },
    new PokemonLearnableMove { Id = 1868, PokemonId = 120, MoveId = 33 },
    new PokemonLearnableMove { Id = 1869, PokemonId = 120, MoveId = 34 },
    new PokemonLearnableMove { Id = 1870, PokemonId = 120, MoveId = 70 },
    new PokemonLearnableMove { Id = 1871, PokemonId = 120, MoveId = 46 },
    new PokemonLearnableMove { Id = 1872, PokemonId = 120, MoveId = 44 },
    new PokemonLearnableMove { Id = 1873, PokemonId = 120, MoveId = 50 },
    new PokemonLearnableMove { Id = 1874, PokemonId = 120, MoveId = 58 },
    new PokemonLearnableMove { Id = 1875, PokemonId = 120, MoveId = 87 },
    new PokemonLearnableMove { Id = 1876, PokemonId = 120, MoveId = 67 },
    new PokemonLearnableMove { Id = 1877, PokemonId = 120, MoveId = 55 },
    new PokemonLearnableMove { Id = 1878, PokemonId = 121, MoveId = 10 },
    new PokemonLearnableMove { Id = 1879, PokemonId = 121, MoveId = 14 },
    new PokemonLearnableMove { Id = 1880, PokemonId = 121, MoveId = 24 },
    new PokemonLearnableMove { Id = 1881, PokemonId = 121, MoveId = 25 },
    new PokemonLearnableMove { Id = 1882, PokemonId = 121, MoveId = 6 },
    new PokemonLearnableMove { Id = 1883, PokemonId = 121, MoveId = 29 },
    new PokemonLearnableMove { Id = 1884, PokemonId = 121, MoveId = 20 },
    new PokemonLearnableMove { Id = 1885, PokemonId = 121, MoveId = 30 },
    new PokemonLearnableMove { Id = 1886, PokemonId = 121, MoveId = 31 },
    new PokemonLearnableMove { Id = 1887, PokemonId = 121, MoveId = 33 },
    new PokemonLearnableMove { Id = 1888, PokemonId = 121, MoveId = 34 },
    new PokemonLearnableMove { Id = 1889, PokemonId = 121, MoveId = 39 },
    new PokemonLearnableMove { Id = 1890, PokemonId = 121, MoveId = 70 },
    new PokemonLearnableMove { Id = 1891, PokemonId = 121, MoveId = 46 },
    new PokemonLearnableMove { Id = 1892, PokemonId = 121, MoveId = 44 },
    new PokemonLearnableMove { Id = 1893, PokemonId = 121, MoveId = 50 },
    new PokemonLearnableMove { Id = 1894, PokemonId = 121, MoveId = 58 },
    new PokemonLearnableMove { Id = 1895, PokemonId = 121, MoveId = 87 },
    new PokemonLearnableMove { Id = 1896, PokemonId = 121, MoveId = 67 },
    new PokemonLearnableMove { Id = 1897, PokemonId = 121, MoveId = 55 },
    new PokemonLearnableMove { Id = 1898, PokemonId = 121, MoveId = 72 },
    new PokemonLearnableMove { Id = 1899, PokemonId = 122, MoveId = 10 },
    new PokemonLearnableMove { Id = 1900, PokemonId = 122, MoveId = 17 },
new PokemonLearnableMove { Id = 1901, PokemonId = 122, MoveId = 18 },
    new PokemonLearnableMove { Id = 1902, PokemonId = 122, MoveId = 24 },
    new PokemonLearnableMove { Id = 1903, PokemonId = 122, MoveId = 25 },
    new PokemonLearnableMove { Id = 1904, PokemonId = 122, MoveId = 6 },
    new PokemonLearnableMove { Id = 1905, PokemonId = 122, MoveId = 29 },
    new PokemonLearnableMove { Id = 1906, PokemonId = 122, MoveId = 20 },
    new PokemonLearnableMove { Id = 1907, PokemonId = 122, MoveId = 30 },
    new PokemonLearnableMove { Id = 1908, PokemonId = 122, MoveId = 31 },
    new PokemonLearnableMove { Id = 1909, PokemonId = 122, MoveId = 33 },
    new PokemonLearnableMove { Id = 1910, PokemonId = 122, MoveId = 34 },
    new PokemonLearnableMove { Id = 1911, PokemonId = 122, MoveId = 35 },
    new PokemonLearnableMove { Id = 1912, PokemonId = 122, MoveId = 70 },
    new PokemonLearnableMove { Id = 1913, PokemonId = 122, MoveId = 46 },
    new PokemonLearnableMove { Id = 1914, PokemonId = 122, MoveId = 44 },
    new PokemonLearnableMove { Id = 1915, PokemonId = 122, MoveId = 58 },
    new PokemonLearnableMove { Id = 1916, PokemonId = 122, MoveId = 87 },
    new PokemonLearnableMove { Id = 1917, PokemonId = 122, MoveId = 66 },
    new PokemonLearnableMove { Id = 1918, PokemonId = 122, MoveId = 56 },
    new PokemonLearnableMove { Id = 1919, PokemonId = 122, MoveId = 78 },
    new PokemonLearnableMove { Id = 1920, PokemonId = 123, MoveId = 10 },
    new PokemonLearnableMove { Id = 1921, PokemonId = 123, MoveId = 6 },
    new PokemonLearnableMove { Id = 1922, PokemonId = 123, MoveId = 20 },
    new PokemonLearnableMove { Id = 1923, PokemonId = 123, MoveId = 31 },
    new PokemonLearnableMove { Id = 1924, PokemonId = 123, MoveId = 34 },
    new PokemonLearnableMove { Id = 1925, PokemonId = 123, MoveId = 39 },
    new PokemonLearnableMove { Id = 1926, PokemonId = 123, MoveId = 44 },
    new PokemonLearnableMove { Id = 1927, PokemonId = 123, MoveId = 50 },
    new PokemonLearnableMove { Id = 1928, PokemonId = 123, MoveId = 58 },
    new PokemonLearnableMove { Id = 1929, PokemonId = 123, MoveId = 87 },
    new PokemonLearnableMove { Id = 1930, PokemonId = 123, MoveId = 51 },
    new PokemonLearnableMove { Id = 1931, PokemonId = 123, MoveId = 89 },
    new PokemonLearnableMove { Id = 1932, PokemonId = 123, MoveId = 78 },
    new PokemonLearnableMove { Id = 1933, PokemonId = 124, MoveId = 10 },
    new PokemonLearnableMove { Id = 1934, PokemonId = 124, MoveId = 17 },
    new PokemonLearnableMove { Id = 1935, PokemonId = 124, MoveId = 18 },
    new PokemonLearnableMove { Id = 1936, PokemonId = 124, MoveId = 6 },
    new PokemonLearnableMove { Id = 1937, PokemonId = 124, MoveId = 29 },
    new PokemonLearnableMove { Id = 1938, PokemonId = 124, MoveId = 20 },
    new PokemonLearnableMove { Id = 1939, PokemonId = 124, MoveId = 30 },
    new PokemonLearnableMove { Id = 1940, PokemonId = 124, MoveId = 31 },
    new PokemonLearnableMove { Id = 1941, PokemonId = 124, MoveId = 33 },
    new PokemonLearnableMove { Id = 1942, PokemonId = 124, MoveId = 34 },
    new PokemonLearnableMove { Id = 1943, PokemonId = 124, MoveId = 35 },
    new PokemonLearnableMove { Id = 1944, PokemonId = 124, MoveId = 70 },
    new PokemonLearnableMove { Id = 1945, PokemonId = 124, MoveId = 46 },
    new PokemonLearnableMove { Id = 1946, PokemonId = 124, MoveId = 44 },
    new PokemonLearnableMove { Id = 1947, PokemonId = 124, MoveId = 50 },
    new PokemonLearnableMove { Id = 1948, PokemonId = 124, MoveId = 58 },
    new PokemonLearnableMove { Id = 1949, PokemonId = 124, MoveId = 87 },
    new PokemonLearnableMove { Id = 1950, PokemonId = 124, MoveId = 67 },
    new PokemonLearnableMove { Id = 1951, PokemonId = 124, MoveId = 66 },
    new PokemonLearnableMove { Id = 1952, PokemonId = 124, MoveId = 56 },
    new PokemonLearnableMove { Id = 1953, PokemonId = 124, MoveId = 78 },
    new PokemonLearnableMove { Id = 1954, PokemonId = 125, MoveId = 10 },
    new PokemonLearnableMove { Id = 1955, PokemonId = 125, MoveId = 17 },
    new PokemonLearnableMove { Id = 1956, PokemonId = 125, MoveId = 18 },
    new PokemonLearnableMove { Id = 1957, PokemonId = 125, MoveId = 24 },
    new PokemonLearnableMove { Id = 1958, PokemonId = 125, MoveId = 6 },
    new PokemonLearnableMove { Id = 1959, PokemonId = 125, MoveId = 29 },
    new PokemonLearnableMove { Id = 1960, PokemonId = 125, MoveId = 20 },
    new PokemonLearnableMove { Id = 1961, PokemonId = 125, MoveId = 30 },
    new PokemonLearnableMove { Id = 1962, PokemonId = 125, MoveId = 31 },
    new PokemonLearnableMove { Id = 1963, PokemonId = 125, MoveId = 33 },
    new PokemonLearnableMove { Id = 1964, PokemonId = 125, MoveId = 34 },
    new PokemonLearnableMove { Id = 1965, PokemonId = 125, MoveId = 35 },
    new PokemonLearnableMove { Id = 1966, PokemonId = 125, MoveId = 39 },
    new PokemonLearnableMove { Id = 1967, PokemonId = 125, MoveId = 70 },
    new PokemonLearnableMove { Id = 1968, PokemonId = 125, MoveId = 46 },
    new PokemonLearnableMove { Id = 1969, PokemonId = 125, MoveId = 44 },
    new PokemonLearnableMove { Id = 1970, PokemonId = 125, MoveId = 50 },
    new PokemonLearnableMove { Id = 1971, PokemonId = 125, MoveId = 58 },
    new PokemonLearnableMove { Id = 1972, PokemonId = 125, MoveId = 87 },
    new PokemonLearnableMove { Id = 1973, PokemonId = 125, MoveId = 56 },
    new PokemonLearnableMove { Id = 1974, PokemonId = 125, MoveId = 78 },
    new PokemonLearnableMove { Id = 1975, PokemonId = 126, MoveId = 10 },
    new PokemonLearnableMove { Id = 1976, PokemonId = 126, MoveId = 17 },
    new PokemonLearnableMove { Id = 1977, PokemonId = 126, MoveId = 18 },
    new PokemonLearnableMove { Id = 1978, PokemonId = 126, MoveId = 6 },
    new PokemonLearnableMove { Id = 1979, PokemonId = 126, MoveId = 29 },
    new PokemonLearnableMove { Id = 1980, PokemonId = 126, MoveId = 20 },
    new PokemonLearnableMove { Id = 1981, PokemonId = 126, MoveId = 30 },
    new PokemonLearnableMove { Id = 1982, PokemonId = 126, MoveId = 31 },
    new PokemonLearnableMove { Id = 1983, PokemonId = 126, MoveId = 34 },
    new PokemonLearnableMove { Id = 1984, PokemonId = 126, MoveId = 35 },
    new PokemonLearnableMove { Id = 1985, PokemonId = 126, MoveId = 46 },
    new PokemonLearnableMove { Id = 1986, PokemonId = 126, MoveId = 44 },
    new PokemonLearnableMove { Id = 1987, PokemonId = 126, MoveId = 50 },
    new PokemonLearnableMove { Id = 1988, PokemonId = 126, MoveId = 58 },
    new PokemonLearnableMove { Id = 1989, PokemonId = 126, MoveId = 87 },
    new PokemonLearnableMove { Id = 1990, PokemonId = 126, MoveId = 61 },
    new PokemonLearnableMove { Id = 1991, PokemonId = 126, MoveId = 56 },
    new PokemonLearnableMove { Id = 1992, PokemonId = 126, MoveId = 78 },
    new PokemonLearnableMove { Id = 1993, PokemonId = 127, MoveId = 10 },
    new PokemonLearnableMove { Id = 1994, PokemonId = 127, MoveId = 17 },
    new PokemonLearnableMove { Id = 1995, PokemonId = 127, MoveId = 26 },
    new PokemonLearnableMove { Id = 1996, PokemonId = 127, MoveId = 28 },
    new PokemonLearnableMove { Id = 1997, PokemonId = 127, MoveId = 6 },
    new PokemonLearnableMove { Id = 1998, PokemonId = 127, MoveId = 20 },
    new PokemonLearnableMove { Id = 1999, PokemonId = 127, MoveId = 31 },
    new PokemonLearnableMove { Id = 2000, PokemonId = 127, MoveId = 34 },
new PokemonLearnableMove { Id = 2001, PokemonId = 127, MoveId = 44 },
    new PokemonLearnableMove { Id = 2002, PokemonId = 127, MoveId = 50 },
    new PokemonLearnableMove { Id = 2003, PokemonId = 127, MoveId = 58 },
    new PokemonLearnableMove { Id = 2004, PokemonId = 127, MoveId = 87 },
    new PokemonLearnableMove { Id = 2005, PokemonId = 127, MoveId = 56 },
    new PokemonLearnableMove { Id = 2006, PokemonId = 127, MoveId = 78 },
    new PokemonLearnableMove { Id = 2007, PokemonId = 128, MoveId = 10 },
    new PokemonLearnableMove { Id = 2008, PokemonId = 128, MoveId = 14 },
    new PokemonLearnableMove { Id = 2009, PokemonId = 128, MoveId = 24 },
    new PokemonLearnableMove { Id = 2010, PokemonId = 128, MoveId = 25 },
    new PokemonLearnableMove { Id = 2011, PokemonId = 128, MoveId = 26 },
    new PokemonLearnableMove { Id = 2012, PokemonId = 128, MoveId = 27 },
    new PokemonLearnableMove { Id = 2013, PokemonId = 128, MoveId = 28 },
    new PokemonLearnableMove { Id = 2014, PokemonId = 128, MoveId = 6 },
    new PokemonLearnableMove { Id = 2015, PokemonId = 128, MoveId = 31 },
    new PokemonLearnableMove { Id = 2016, PokemonId = 128, MoveId = 34 },
    new PokemonLearnableMove { Id = 2017, PokemonId = 128, MoveId = 44 },
    new PokemonLearnableMove { Id = 2018, PokemonId = 128, MoveId = 50 },
    new PokemonLearnableMove { Id = 2019, PokemonId = 128, MoveId = 58 },
    new PokemonLearnableMove { Id = 2020, PokemonId = 128, MoveId = 87 },
    new PokemonLearnableMove { Id = 2021, PokemonId = 128, MoveId = 78 },
    new PokemonLearnableMove { Id = 2022, PokemonId = 130, MoveId = 10 },
    new PokemonLearnableMove { Id = 2023, PokemonId = 130, MoveId = 14 },
    new PokemonLearnableMove { Id = 2024, PokemonId = 130, MoveId = 24 },
    new PokemonLearnableMove { Id = 2025, PokemonId = 130, MoveId = 25 },
    new PokemonLearnableMove { Id = 2026, PokemonId = 130, MoveId = 26 },
    new PokemonLearnableMove { Id = 2027, PokemonId = 130, MoveId = 6 },
    new PokemonLearnableMove { Id = 2028, PokemonId = 130, MoveId = 20 },
    new PokemonLearnableMove { Id = 2029, PokemonId = 130, MoveId = 31 },
    new PokemonLearnableMove { Id = 2030, PokemonId = 130, MoveId = 33 },
    new PokemonLearnableMove { Id = 2031, PokemonId = 130, MoveId = 34 },
    new PokemonLearnableMove { Id = 2032, PokemonId = 130, MoveId = 44 },
    new PokemonLearnableMove { Id = 2033, PokemonId = 130, MoveId = 50 },
    new PokemonLearnableMove { Id = 2034, PokemonId = 130, MoveId = 58 },
    new PokemonLearnableMove { Id = 2035, PokemonId = 130, MoveId = 87 },
    new PokemonLearnableMove { Id = 2036, PokemonId = 130, MoveId = 55 },
    new PokemonLearnableMove { Id = 2037, PokemonId = 130, MoveId = 66 },
    new PokemonLearnableMove { Id = 2038, PokemonId = 130, MoveId = 72 },
    new PokemonLearnableMove { Id = 2039, PokemonId = 130, MoveId = 78 },
    new PokemonLearnableMove { Id = 2040, PokemonId = 131, MoveId = 10 },
    new PokemonLearnableMove { Id = 2041, PokemonId = 131, MoveId = 14 },
    new PokemonLearnableMove { Id = 2042, PokemonId = 131, MoveId = 24 },
    new PokemonLearnableMove { Id = 2043, PokemonId = 131, MoveId = 25 },
    new PokemonLearnableMove { Id = 2044, PokemonId = 131, MoveId = 6 },
    new PokemonLearnableMove { Id = 2045, PokemonId = 131, MoveId = 29 },
    new PokemonLearnableMove { Id = 2046, PokemonId = 131, MoveId = 20 },
    new PokemonLearnableMove { Id = 2047, PokemonId = 131, MoveId = 31 },
    new PokemonLearnableMove { Id = 2048, PokemonId = 131, MoveId = 33 },
    new PokemonLearnableMove { Id = 2049, PokemonId = 131, MoveId = 34 },
    new PokemonLearnableMove { Id = 2050, PokemonId = 131, MoveId = 46 },
    new PokemonLearnableMove { Id = 2051, PokemonId = 131, MoveId = 44 },
    new PokemonLearnableMove { Id = 2052, PokemonId = 131, MoveId = 50 },
    new PokemonLearnableMove { Id = 2053, PokemonId = 131, MoveId = 58 },
    new PokemonLearnableMove { Id = 2054, PokemonId = 131, MoveId = 87 },
    new PokemonLearnableMove { Id = 2055, PokemonId = 131, MoveId = 72 },
    new PokemonLearnableMove { Id = 2056, PokemonId = 131, MoveId = 78 },
    new PokemonLearnableMove { Id = 2057, PokemonId = 133, MoveId = 10 },
    new PokemonLearnableMove { Id = 2058, PokemonId = 133, MoveId = 28 },
    new PokemonLearnableMove { Id = 2059, PokemonId = 133, MoveId = 6 },
    new PokemonLearnableMove { Id = 2060, PokemonId = 133, MoveId = 20 },
    new PokemonLearnableMove { Id = 2061, PokemonId = 133, MoveId = 31 },
    new PokemonLearnableMove { Id = 2062, PokemonId = 133, MoveId = 33 },
    new PokemonLearnableMove { Id = 2063, PokemonId = 133, MoveId = 34 },
    new PokemonLearnableMove { Id = 2064, PokemonId = 133, MoveId = 39 },
    new PokemonLearnableMove { Id = 2065, PokemonId = 133, MoveId = 44 },
    new PokemonLearnableMove { Id = 2066, PokemonId = 133, MoveId = 50 },
    new PokemonLearnableMove { Id = 2067, PokemonId = 133, MoveId = 58 },
    new PokemonLearnableMove { Id = 2068, PokemonId = 133, MoveId = 87 },
    new PokemonLearnableMove { Id = 2069, PokemonId = 133, MoveId = 78 },
    new PokemonLearnableMove { Id = 2070, PokemonId = 134, MoveId = 10 },
    new PokemonLearnableMove { Id = 2071, PokemonId = 134, MoveId = 14 },
    new PokemonLearnableMove { Id = 2072, PokemonId = 134, MoveId = 28 },
    new PokemonLearnableMove { Id = 2073, PokemonId = 134, MoveId = 6 },
    new PokemonLearnableMove { Id = 2074, PokemonId = 134, MoveId = 20 },
    new PokemonLearnableMove { Id = 2075, PokemonId = 134, MoveId = 31 },
    new PokemonLearnableMove { Id = 2076, PokemonId = 134, MoveId = 33 },
    new PokemonLearnableMove { Id = 2077, PokemonId = 134, MoveId = 34 },
    new PokemonLearnableMove { Id = 2078, PokemonId = 134, MoveId = 39 },
    new PokemonLearnableMove { Id = 2079, PokemonId = 134, MoveId = 44 },
    new PokemonLearnableMove { Id = 2080, PokemonId = 134, MoveId = 50 },
    new PokemonLearnableMove { Id = 2081, PokemonId = 134, MoveId = 58 },
    new PokemonLearnableMove { Id = 2082, PokemonId = 134, MoveId = 87 },
    new PokemonLearnableMove { Id = 2083, PokemonId = 134, MoveId = 55 },
    new PokemonLearnableMove { Id = 2084, PokemonId = 134, MoveId = 78 },
    new PokemonLearnableMove { Id = 2085, PokemonId = 135, MoveId = 10 },
    new PokemonLearnableMove { Id = 2086, PokemonId = 135, MoveId = 24 },
    new PokemonLearnableMove { Id = 2087, PokemonId = 135, MoveId = 28 },
    new PokemonLearnableMove { Id = 2088, PokemonId = 135, MoveId = 6 },
    new PokemonLearnableMove { Id = 2089, PokemonId = 135, MoveId = 20 },
    new PokemonLearnableMove { Id = 2090, PokemonId = 135, MoveId = 31 },
    new PokemonLearnableMove { Id = 2091, PokemonId = 135, MoveId = 33 },
    new PokemonLearnableMove { Id = 2092, PokemonId = 135, MoveId = 34 },
    new PokemonLearnableMove { Id = 2093, PokemonId = 135, MoveId = 39 },
    new PokemonLearnableMove { Id = 2094, PokemonId = 135, MoveId = 70 },
    new PokemonLearnableMove { Id = 2095, PokemonId = 135, MoveId = 44 },
    new PokemonLearnableMove { Id = 2096, PokemonId = 135, MoveId = 50 },
    new PokemonLearnableMove { Id = 2097, PokemonId = 135, MoveId = 58 },
    new PokemonLearnableMove { Id = 2098, PokemonId = 135, MoveId = 87 },
    new PokemonLearnableMove { Id = 2099, PokemonId = 135, MoveId = 78 },
    new PokemonLearnableMove { Id = 2100, PokemonId = 136, MoveId = 10 },
 new PokemonLearnableMove { Id = 2101, PokemonId = 136, MoveId = 28 },
    new PokemonLearnableMove { Id = 2102, PokemonId = 136, MoveId = 6 },
    new PokemonLearnableMove { Id = 2103, PokemonId = 136, MoveId = 31 },
    new PokemonLearnableMove { Id = 2104, PokemonId = 136, MoveId = 33 },
    new PokemonLearnableMove { Id = 2105, PokemonId = 136, MoveId = 34 },
    new PokemonLearnableMove { Id = 2106, PokemonId = 136, MoveId = 39 },
    new PokemonLearnableMove { Id = 2107, PokemonId = 136, MoveId = 44 },
    new PokemonLearnableMove { Id = 2108, PokemonId = 136, MoveId = 50 },
    new PokemonLearnableMove { Id = 2109, PokemonId = 136, MoveId = 58 },
    new PokemonLearnableMove { Id = 2110, PokemonId = 136, MoveId = 87 },
    new PokemonLearnableMove { Id = 2111, PokemonId = 136, MoveId = 61 },
    new PokemonLearnableMove { Id = 2112, PokemonId = 136, MoveId = 78 },
    new PokemonLearnableMove { Id = 2113, PokemonId = 137, MoveId = 10 },
    new PokemonLearnableMove { Id = 2114, PokemonId = 137, MoveId = 14 },
    new PokemonLearnableMove { Id = 2115, PokemonId = 137, MoveId = 24 },
    new PokemonLearnableMove { Id = 2116, PokemonId = 137, MoveId = 25 },
    new PokemonLearnableMove { Id = 2117, PokemonId = 137, MoveId = 6 },
    new PokemonLearnableMove { Id = 2118, PokemonId = 137, MoveId = 29 },
    new PokemonLearnableMove { Id = 2119, PokemonId = 137, MoveId = 20 },
    new PokemonLearnableMove { Id = 2120, PokemonId = 137, MoveId = 30 },
    new PokemonLearnableMove { Id = 2121, PokemonId = 137, MoveId = 31 },
    new PokemonLearnableMove { Id = 2122, PokemonId = 137, MoveId = 33 },
    new PokemonLearnableMove { Id = 2123, PokemonId = 137, MoveId = 34 },
    new PokemonLearnableMove { Id = 2124, PokemonId = 137, MoveId = 39 },
    new PokemonLearnableMove { Id = 2125, PokemonId = 137, MoveId = 70 },
    new PokemonLearnableMove { Id = 2126, PokemonId = 137, MoveId = 46 },
    new PokemonLearnableMove { Id = 2127, PokemonId = 137, MoveId = 44 },
    new PokemonLearnableMove { Id = 2128, PokemonId = 137, MoveId = 50 },
    new PokemonLearnableMove { Id = 2129, PokemonId = 137, MoveId = 58 },
    new PokemonLearnableMove { Id = 2130, PokemonId = 137, MoveId = 87 },
    new PokemonLearnableMove { Id = 2131, PokemonId = 138, MoveId = 10 },
    new PokemonLearnableMove { Id = 2132, PokemonId = 138, MoveId = 14 },
    new PokemonLearnableMove { Id = 2133, PokemonId = 138, MoveId = 6 },
    new PokemonLearnableMove { Id = 2134, PokemonId = 138, MoveId = 20 },
    new PokemonLearnableMove { Id = 2135, PokemonId = 138, MoveId = 31 },
    new PokemonLearnableMove { Id = 2136, PokemonId = 138, MoveId = 33 },
    new PokemonLearnableMove { Id = 2137, PokemonId = 138, MoveId = 34 },
    new PokemonLearnableMove { Id = 2138, PokemonId = 138, MoveId = 44 },
    new PokemonLearnableMove { Id = 2139, PokemonId = 138, MoveId = 50 },
    new PokemonLearnableMove { Id = 2140, PokemonId = 138, MoveId = 58 },
    new PokemonLearnableMove { Id = 2141, PokemonId = 138, MoveId = 87 },
    new PokemonLearnableMove { Id = 2142, PokemonId = 138, MoveId = 78 },
    new PokemonLearnableMove { Id = 2143, PokemonId = 139, MoveId = 10 },
    new PokemonLearnableMove { Id = 2144, PokemonId = 139, MoveId = 14 },
    new PokemonLearnableMove { Id = 2145, PokemonId = 139, MoveId = 17 },
    new PokemonLearnableMove { Id = 2146, PokemonId = 139, MoveId = 6 },
    new PokemonLearnableMove { Id = 2147, PokemonId = 139, MoveId = 20 },
    new PokemonLearnableMove { Id = 2148, PokemonId = 139, MoveId = 31 },
    new PokemonLearnableMove { Id = 2149, PokemonId = 139, MoveId = 33 },
    new PokemonLearnableMove { Id = 2150, PokemonId = 139, MoveId = 34 },
    new PokemonLearnableMove { Id = 2151, PokemonId = 139, MoveId = 44 },
    new PokemonLearnableMove { Id = 2152, PokemonId = 139, MoveId = 50 },
    new PokemonLearnableMove { Id = 2153, PokemonId = 139, MoveId = 58 },
    new PokemonLearnableMove { Id = 2154, PokemonId = 139, MoveId = 87 },
    new PokemonLearnableMove { Id = 2155, PokemonId = 139, MoveId = 78 },
    new PokemonLearnableMove { Id = 2156, PokemonId = 140, MoveId = 10 },
    new PokemonLearnableMove { Id = 2157, PokemonId = 140, MoveId = 14 },
    new PokemonLearnableMove { Id = 2158, PokemonId = 140, MoveId = 6 },
    new PokemonLearnableMove { Id = 2159, PokemonId = 140, MoveId = 20 },
    new PokemonLearnableMove { Id = 2160, PokemonId = 140, MoveId = 31 },
    new PokemonLearnableMove { Id = 2161, PokemonId = 140, MoveId = 33 },
    new PokemonLearnableMove { Id = 2162, PokemonId = 140, MoveId = 34 },
    new PokemonLearnableMove { Id = 2163, PokemonId = 140, MoveId = 44 },
    new PokemonLearnableMove { Id = 2164, PokemonId = 140, MoveId = 50 },
    new PokemonLearnableMove { Id = 2165, PokemonId = 140, MoveId = 87 },
    new PokemonLearnableMove { Id = 2166, PokemonId = 140, MoveId = 55 },
    new PokemonLearnableMove { Id = 2167, PokemonId = 140, MoveId = 78 },
    new PokemonLearnableMove { Id = 2168, PokemonId = 141, MoveId = 10 },
    new PokemonLearnableMove { Id = 2169, PokemonId = 141, MoveId = 14 },
    new PokemonLearnableMove { Id = 2170, PokemonId = 141, MoveId = 17 },
    new PokemonLearnableMove { Id = 2171, PokemonId = 141, MoveId = 28 },
    new PokemonLearnableMove { Id = 2172, PokemonId = 141, MoveId = 6 },
    new PokemonLearnableMove { Id = 2173, PokemonId = 141, MoveId = 20 },
    new PokemonLearnableMove { Id = 2174, PokemonId = 141, MoveId = 31 },
    new PokemonLearnableMove { Id = 2175, PokemonId = 141, MoveId = 33 },
    new PokemonLearnableMove { Id = 2176, PokemonId = 141, MoveId = 34 },
    new PokemonLearnableMove { Id = 2177, PokemonId = 141, MoveId = 44 },
    new PokemonLearnableMove { Id = 2178, PokemonId = 141, MoveId = 50 },
    new PokemonLearnableMove { Id = 2179, PokemonId = 141, MoveId = 87 },
    new PokemonLearnableMove { Id = 2180, PokemonId = 141, MoveId = 55 },
    new PokemonLearnableMove { Id = 2181, PokemonId = 141, MoveId = 81 },
    new PokemonLearnableMove { Id = 2182, PokemonId = 141, MoveId = 78 },
    new PokemonLearnableMove { Id = 2183, PokemonId = 142, MoveId = 4 },
    new PokemonLearnableMove { Id = 2184, PokemonId = 142, MoveId = 10 },
    new PokemonLearnableMove { Id = 2185, PokemonId = 142, MoveId = 26 },
    new PokemonLearnableMove { Id = 2186, PokemonId = 142, MoveId = 6 },
    new PokemonLearnableMove { Id = 2187, PokemonId = 142, MoveId = 20 },
    new PokemonLearnableMove { Id = 2188, PokemonId = 142, MoveId = 31 },
    new PokemonLearnableMove { Id = 2189, PokemonId = 142, MoveId = 33 },
    new PokemonLearnableMove { Id = 2190, PokemonId = 142, MoveId = 34 },
    new PokemonLearnableMove { Id = 2191, PokemonId = 142, MoveId = 39 },
    new PokemonLearnableMove { Id = 2192, PokemonId = 142, MoveId = 44 },
    new PokemonLearnableMove { Id = 2193, PokemonId = 142, MoveId = 50 },
    new PokemonLearnableMove { Id = 2194, PokemonId = 142, MoveId = 58 },
    new PokemonLearnableMove { Id = 2195, PokemonId = 142, MoveId = 87 },
    new PokemonLearnableMove { Id = 2196, PokemonId = 142, MoveId = 51 },
    new PokemonLearnableMove { Id = 2197, PokemonId = 142, MoveId = 66 },
    new PokemonLearnableMove { Id = 2198, PokemonId = 142, MoveId = 78 },
    new PokemonLearnableMove { Id = 2199, PokemonId = 143, MoveId = 14 },
    new PokemonLearnableMove { Id = 2200, PokemonId = 143, MoveId = 17 },
 new PokemonLearnableMove { Id = 2201, PokemonId = 143, MoveId = 18 },
    new PokemonLearnableMove { Id = 2202, PokemonId = 143, MoveId = 24 },
    new PokemonLearnableMove { Id = 2203, PokemonId = 143, MoveId = 25 },
    new PokemonLearnableMove { Id = 2204, PokemonId = 143, MoveId = 26 },
    new PokemonLearnableMove { Id = 2205, PokemonId = 143, MoveId = 27 },
    new PokemonLearnableMove { Id = 2206, PokemonId = 143, MoveId = 28 },
    new PokemonLearnableMove { Id = 2207, PokemonId = 143, MoveId = 6 },
    new PokemonLearnableMove { Id = 2208, PokemonId = 143, MoveId = 29 },
    new PokemonLearnableMove { Id = 2209, PokemonId = 143, MoveId = 20 },
    new PokemonLearnableMove { Id = 2210, PokemonId = 143, MoveId = 31 },
    new PokemonLearnableMove { Id = 2211, PokemonId = 143, MoveId = 33 },
    new PokemonLearnableMove { Id = 2212, PokemonId = 143, MoveId = 34 },
    new PokemonLearnableMove { Id = 2213, PokemonId = 143, MoveId = 35 },
    new PokemonLearnableMove { Id = 2214, PokemonId = 143, MoveId = 36 },
    new PokemonLearnableMove { Id = 2215, PokemonId = 143, MoveId = 46 },
    new PokemonLearnableMove { Id = 2216, PokemonId = 143, MoveId = 50 },
    new PokemonLearnableMove { Id = 2217, PokemonId = 143, MoveId = 58 },
    new PokemonLearnableMove { Id = 2218, PokemonId = 143, MoveId = 87 },
    new PokemonLearnableMove { Id = 2219, PokemonId = 143, MoveId = 67 },
    new PokemonLearnableMove { Id = 2220, PokemonId = 143, MoveId = 56 },
    new PokemonLearnableMove { Id = 2221, PokemonId = 143, MoveId = 78 },
    new PokemonLearnableMove { Id = 2222, PokemonId = 144, MoveId = 4 },
    new PokemonLearnableMove { Id = 2223, PokemonId = 144, MoveId = 10 },
    new PokemonLearnableMove { Id = 2224, PokemonId = 144, MoveId = 6 },
    new PokemonLearnableMove { Id = 2225, PokemonId = 144, MoveId = 20 },
    new PokemonLearnableMove { Id = 2226, PokemonId = 144, MoveId = 31 },
    new PokemonLearnableMove { Id = 2227, PokemonId = 144, MoveId = 33 },
    new PokemonLearnableMove { Id = 2228, PokemonId = 144, MoveId = 34 },
    new PokemonLearnableMove { Id = 2229, PokemonId = 144, MoveId = 39 },
    new PokemonLearnableMove { Id = 2230, PokemonId = 144, MoveId = 44 },
    new PokemonLearnableMove { Id = 2231, PokemonId = 144, MoveId = 50 },
    new PokemonLearnableMove { Id = 2232, PokemonId = 144, MoveId = 58 },
    new PokemonLearnableMove { Id = 2233, PokemonId = 144, MoveId = 87 },
    new PokemonLearnableMove { Id = 2234, PokemonId = 144, MoveId = 88 },
    new PokemonLearnableMove { Id = 2235, PokemonId = 144, MoveId = 89 },
    new PokemonLearnableMove { Id = 2236, PokemonId = 144, MoveId = 72 },
    new PokemonLearnableMove { Id = 2237, PokemonId = 145, MoveId = 4 },
    new PokemonLearnableMove { Id = 2238, PokemonId = 145, MoveId = 10 },
    new PokemonLearnableMove { Id = 2239, PokemonId = 145, MoveId = 24 },
    new PokemonLearnableMove { Id = 2240, PokemonId = 145, MoveId = 6 },
    new PokemonLearnableMove { Id = 2241, PokemonId = 145, MoveId = 20 },
    new PokemonLearnableMove { Id = 2242, PokemonId = 145, MoveId = 31 },
    new PokemonLearnableMove { Id = 2243, PokemonId = 145, MoveId = 33 },
    new PokemonLearnableMove { Id = 2244, PokemonId = 145, MoveId = 34 },
    new PokemonLearnableMove { Id = 2245, PokemonId = 145, MoveId = 39 },
    new PokemonLearnableMove { Id = 2246, PokemonId = 145, MoveId = 70 },
    new PokemonLearnableMove { Id = 2247, PokemonId = 145, MoveId = 44 },
    new PokemonLearnableMove { Id = 2248, PokemonId = 145, MoveId = 50 },
    new PokemonLearnableMove { Id = 2249, PokemonId = 145, MoveId = 58 },
    new PokemonLearnableMove { Id = 2250, PokemonId = 145, MoveId = 87 },
    new PokemonLearnableMove { Id = 2251, PokemonId = 145, MoveId = 89 },
    new PokemonLearnableMove { Id = 2252, PokemonId = 146, MoveId = 4 },
    new PokemonLearnableMove { Id = 2253, PokemonId = 146, MoveId = 10 },
    new PokemonLearnableMove { Id = 2254, PokemonId = 146, MoveId = 6 },
    new PokemonLearnableMove { Id = 2255, PokemonId = 146, MoveId = 20 },
    new PokemonLearnableMove { Id = 2256, PokemonId = 146, MoveId = 31 },
    new PokemonLearnableMove { Id = 2257, PokemonId = 146, MoveId = 33 },
    new PokemonLearnableMove { Id = 2258, PokemonId = 146, MoveId = 34 },
    new PokemonLearnableMove { Id = 2259, PokemonId = 146, MoveId = 39 },
    new PokemonLearnableMove { Id = 2260, PokemonId = 146, MoveId = 44 },
    new PokemonLearnableMove { Id = 2261, PokemonId = 146, MoveId = 50 },
    new PokemonLearnableMove { Id = 2262, PokemonId = 146, MoveId = 87 },
    new PokemonLearnableMove { Id = 2263, PokemonId = 146, MoveId = 61 },
    new PokemonLearnableMove { Id = 2264, PokemonId = 146, MoveId = 88 },
    new PokemonLearnableMove { Id = 2265, PokemonId = 146, MoveId = 89 },
    new PokemonLearnableMove { Id = 2266, PokemonId = 147, MoveId = 10 },
    new PokemonLearnableMove { Id = 2267, PokemonId = 147, MoveId = 14 },
    new PokemonLearnableMove { Id = 2268, PokemonId = 147, MoveId = 24 },
    new PokemonLearnableMove { Id = 2269, PokemonId = 147, MoveId = 25 },
    new PokemonLearnableMove { Id = 2270, PokemonId = 147, MoveId = 6 },
    new PokemonLearnableMove { Id = 2271, PokemonId = 147, MoveId = 20 },
    new PokemonLearnableMove { Id = 2272, PokemonId = 147, MoveId = 31 },
    new PokemonLearnableMove { Id = 2273, PokemonId = 147, MoveId = 33 },
    new PokemonLearnableMove { Id = 2274, PokemonId = 147, MoveId = 34 },
    new PokemonLearnableMove { Id = 2275, PokemonId = 147, MoveId = 39 },
    new PokemonLearnableMove { Id = 2276, PokemonId = 147, MoveId = 44 },
    new PokemonLearnableMove { Id = 2277, PokemonId = 147, MoveId = 50 },
    new PokemonLearnableMove { Id = 2278, PokemonId = 147, MoveId = 58 },
    new PokemonLearnableMove { Id = 2279, PokemonId = 147, MoveId = 87 },
    new PokemonLearnableMove { Id = 2280, PokemonId = 147, MoveId = 78 },
    new PokemonLearnableMove { Id = 2281, PokemonId = 148, MoveId = 10 },
    new PokemonLearnableMove { Id = 2282, PokemonId = 148, MoveId = 14 },
    new PokemonLearnableMove { Id = 2283, PokemonId = 148, MoveId = 24 },
    new PokemonLearnableMove { Id = 2284, PokemonId = 148, MoveId = 25 },
    new PokemonLearnableMove { Id = 2285, PokemonId = 148, MoveId = 6 },
    new PokemonLearnableMove { Id = 2286, PokemonId = 148, MoveId = 20 },
    new PokemonLearnableMove { Id = 2287, PokemonId = 148, MoveId = 31 },
    new PokemonLearnableMove { Id = 2288, PokemonId = 148, MoveId = 33 },
    new PokemonLearnableMove { Id = 2289, PokemonId = 148, MoveId = 34 },
    new PokemonLearnableMove { Id = 2290, PokemonId = 148, MoveId = 39 },
    new PokemonLearnableMove { Id = 2291, PokemonId = 148, MoveId = 44 },
    new PokemonLearnableMove { Id = 2292, PokemonId = 148, MoveId = 50 },
    new PokemonLearnableMove { Id = 2293, PokemonId = 148, MoveId = 58 },
    new PokemonLearnableMove { Id = 2294, PokemonId = 148, MoveId = 87 },
    new PokemonLearnableMove { Id = 2295, PokemonId = 148, MoveId = 78 },
    new PokemonLearnableMove { Id = 2296, PokemonId = 149, MoveId = 10 },
    new PokemonLearnableMove { Id = 2297, PokemonId = 149, MoveId = 14 },
    new PokemonLearnableMove { Id = 2298, PokemonId = 149, MoveId = 24 },
    new PokemonLearnableMove { Id = 2299, PokemonId = 149, MoveId = 25 },
    new PokemonLearnableMove { Id = 2300, PokemonId = 149, MoveId = 26 },
new PokemonLearnableMove { Id = 2301, PokemonId = 149, MoveId = 6 },
    new PokemonLearnableMove { Id = 2302, PokemonId = 149, MoveId = 20 },
    new PokemonLearnableMove { Id = 2303, PokemonId = 149, MoveId = 31 },
    new PokemonLearnableMove { Id = 2304, PokemonId = 149, MoveId = 33 },
    new PokemonLearnableMove { Id = 2305, PokemonId = 149, MoveId = 34 },
    new PokemonLearnableMove { Id = 2306, PokemonId = 149, MoveId = 35 },
    new PokemonLearnableMove { Id = 2307, PokemonId = 149, MoveId = 39 },
    new PokemonLearnableMove { Id = 2308, PokemonId = 149, MoveId = 44 },
    new PokemonLearnableMove { Id = 2309, PokemonId = 149, MoveId = 50 },
    new PokemonLearnableMove { Id = 2310, PokemonId = 149, MoveId = 58 },
    new PokemonLearnableMove { Id = 2311, PokemonId = 149, MoveId = 87 },
    new PokemonLearnableMove { Id = 2312, PokemonId = 149, MoveId = 56 },
    new PokemonLearnableMove { Id = 2313, PokemonId = 149, MoveId = 78 },
    new PokemonLearnableMove { Id = 2314, PokemonId = 150, MoveId = 10 },
    new PokemonLearnableMove { Id = 2315, PokemonId = 150, MoveId = 14 },
    new PokemonLearnableMove { Id = 2316, PokemonId = 150, MoveId = 17 },
    new PokemonLearnableMove { Id = 2317, PokemonId = 150, MoveId = 18 },
    new PokemonLearnableMove { Id = 2318, PokemonId = 150, MoveId = 24 },
    new PokemonLearnableMove { Id = 2319, PokemonId = 150, MoveId = 25 },
    new PokemonLearnableMove { Id = 2320, PokemonId = 150, MoveId = 26 },
    new PokemonLearnableMove { Id = 2321, PokemonId = 150, MoveId = 6 },
    new PokemonLearnableMove { Id = 2322, PokemonId = 150, MoveId = 20 },
    new PokemonLearnableMove { Id = 2323, PokemonId = 150, MoveId = 30 },
    new PokemonLearnableMove { Id = 2324, PokemonId = 150, MoveId = 31 },
    new PokemonLearnableMove { Id = 2325, PokemonId = 150, MoveId = 33 },
    new PokemonLearnableMove { Id = 2326, PokemonId = 150, MoveId = 34 },
    new PokemonLearnableMove { Id = 2327, PokemonId = 150, MoveId = 35 },
    new PokemonLearnableMove { Id = 2328, PokemonId = 150, MoveId = 36 },
    new PokemonLearnableMove { Id = 2329, PokemonId = 150, MoveId = 70 },
    new PokemonLearnableMove { Id = 2330, PokemonId = 150, MoveId = 46 },
    new PokemonLearnableMove { Id = 2331, PokemonId = 150, MoveId = 44 },
    new PokemonLearnableMove { Id = 2332, PokemonId = 150, MoveId = 50 },
    new PokemonLearnableMove { Id = 2333, PokemonId = 150, MoveId = 58 },
    new PokemonLearnableMove { Id = 2334, PokemonId = 150, MoveId = 87 },
    new PokemonLearnableMove { Id = 2335, PokemonId = 150, MoveId = 61 },
    new PokemonLearnableMove { Id = 2336, PokemonId = 150, MoveId = 67 },
    new PokemonLearnableMove { Id = 2337, PokemonId = 150, MoveId = 63 },
    new PokemonLearnableMove { Id = 2338, PokemonId = 150, MoveId = 56 },
    new PokemonLearnableMove { Id = 2339, PokemonId = 150, MoveId = 72 },
    new PokemonLearnableMove { Id = 2340, PokemonId = 151, MoveId = 4 },
    new PokemonLearnableMove { Id = 2341, PokemonId = 151, MoveId = 10 },
    new PokemonLearnableMove { Id = 2342, PokemonId = 151, MoveId = 14 },
    new PokemonLearnableMove { Id = 2343, PokemonId = 151, MoveId = 17 },
    new PokemonLearnableMove { Id = 2344, PokemonId = 151, MoveId = 18 },
    new PokemonLearnableMove { Id = 2345, PokemonId = 151, MoveId = 24 },
    new PokemonLearnableMove { Id = 2346, PokemonId = 151, MoveId = 25 },
    new PokemonLearnableMove { Id = 2347, PokemonId = 151, MoveId = 26 },
    new PokemonLearnableMove { Id = 2348, PokemonId = 151, MoveId = 27 },
    new PokemonLearnableMove { Id = 2349, PokemonId = 151, MoveId = 28 },
    new PokemonLearnableMove { Id = 2350, PokemonId = 151, MoveId = 6 },
    new PokemonLearnableMove { Id = 2351, PokemonId = 151, MoveId = 20 },
    new PokemonLearnableMove { Id = 2352, PokemonId = 151, MoveId = 30 },
    new PokemonLearnableMove { Id = 2353, PokemonId = 151, MoveId = 31 },
    new PokemonLearnableMove { Id = 2354, PokemonId = 151, MoveId = 33 },
    new PokemonLearnableMove { Id = 2355, PokemonId = 151, MoveId = 34 },
    new PokemonLearnableMove { Id = 2356, PokemonId = 151, MoveId = 36 },
    new PokemonLearnableMove { Id = 2357, PokemonId = 151, MoveId = 39 },
    new PokemonLearnableMove { Id = 2358, PokemonId = 151, MoveId = 41 },
    new PokemonLearnableMove { Id = 2359, PokemonId = 151, MoveId = 70 },
    new PokemonLearnableMove { Id = 2360, PokemonId = 151, MoveId = 46 },
    new PokemonLearnableMove { Id = 2361, PokemonId = 151, MoveId = 47 },
    new PokemonLearnableMove { Id = 2362, PokemonId = 151, MoveId = 44 },
    new PokemonLearnableMove { Id = 2363, PokemonId = 151, MoveId = 50 },
    new PokemonLearnableMove { Id = 2364, PokemonId = 151, MoveId = 58 },
    new PokemonLearnableMove { Id = 2365, PokemonId = 151, MoveId = 87 },
    new PokemonLearnableMove { Id = 2366, PokemonId = 151, MoveId = 61 },
    new PokemonLearnableMove { Id = 2367, PokemonId = 151, MoveId = 67 },
    new PokemonLearnableMove { Id = 2368, PokemonId = 151, MoveId = 51 },
    new PokemonLearnableMove { Id = 2369, PokemonId = 151, MoveId = 55 },
    new PokemonLearnableMove { Id = 2370, PokemonId = 151, MoveId = 88 },
    new PokemonLearnableMove { Id = 2371, PokemonId = 151, MoveId = 89 },
    new PokemonLearnableMove { Id = 2372, PokemonId = 151, MoveId = 66 },
    new PokemonLearnableMove { Id = 2373, PokemonId = 151, MoveId = 63 },
    new PokemonLearnableMove { Id = 2374, PokemonId = 151, MoveId = 56 },
    new PokemonLearnableMove { Id = 2375, PokemonId = 151, MoveId = 81 },
    new PokemonLearnableMove { Id = 2376, PokemonId = 151, MoveId = 72 },
    new PokemonLearnableMove { Id = 2377, PokemonId = 151, MoveId = 78 }
        );
    }
}