﻿// <auto-generated />
using System;
using DEVinCar.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEVinCar.Infra.Data.Migrations
{
    [DbContext(typeof(DevInCarDbContext))]
    partial class DevInCarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Complement")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cep = "89260200",
                            CityId = 1,
                            Complement = "avenida dos javeiros",
                            Number = 55,
                            Street = "Bertha weege"
                        },
                        new
                        {
                            Id = 2,
                            Cep = "99260450",
                            CityId = 2,
                            Complement = "bóson de higgs",
                            Number = 44,
                            Street = "Macarena    "
                        },
                        new
                        {
                            Id = 3,
                            Cep = "88245640",
                            CityId = 3,
                            Complement = "rutherford bohr ",
                            Number = 787,
                            Street = "Mundial frei"
                        },
                        new
                        {
                            Id = 4,
                            Cep = "79260500",
                            CityId = 4,
                            Complement = "paradoxo dos gemeos",
                            Number = 554,
                            Street = "Alvin Bross"
                        },
                        new
                        {
                            Id = 5,
                            Cep = "87289890",
                            CityId = 5,
                            Complement = "paradoxo de bootstrap",
                            Number = 578,
                            Street = "Nickson nelma"
                        },
                        new
                        {
                            Id = 6,
                            Cep = "49245500",
                            CityId = 6,
                            Complement = "gato de schrödinger",
                            Number = 544,
                            Street = "jk matilda"
                        },
                        new
                        {
                            Id = 7,
                            Cep = "89567520",
                            CityId = 7,
                            Complement = "efeito fantasmagorico",
                            Number = 33,
                            Street = "horizons blue"
                        },
                        new
                        {
                            Id = 8,
                            Cep = "84256500",
                            CityId = 8,
                            Complement = "max plank",
                            Number = 323,
                            Street = "apargatas"
                        },
                        new
                        {
                            Id = 9,
                            Cep = "86260560",
                            CityId = 9,
                            Complement = "stephen hawking",
                            Number = 678,
                            Street = "medianeira"
                        },
                        new
                        {
                            Id = 10,
                            Cep = "89960450",
                            CityId = 10,
                            Complement = "de volta para o futuro",
                            Number = 123,
                            Street = "bartinduum"
                        });
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("SuggestedPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cars", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Camaro Chevrolet",
                            SuggestedPrice = 60000m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Maverick Ford",
                            SuggestedPrice = 20000m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Astra Chevrolet",
                            SuggestedPrice = 30000m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hilux Toyota",
                            SuggestedPrice = 20000m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bravo Fiat",
                            SuggestedPrice = 20000m
                        },
                        new
                        {
                            Id = 6,
                            Name = "BR800 Gurgel",
                            SuggestedPrice = 10000m
                        },
                        new
                        {
                            Id = 7,
                            Name = "147 Fiat",
                            SuggestedPrice = 50000m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Del Rey Ford",
                            SuggestedPrice = 10000m
                        },
                        new
                        {
                            Id = 9,
                            Name = "Mustang Ford",
                            SuggestedPrice = 70000m
                        },
                        new
                        {
                            Id = 10,
                            Name = "Belina Ford",
                            SuggestedPrice = 20000m
                        });
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jaragua do sul",
                            StateId = 24
                        },
                        new
                        {
                            Id = 2,
                            Name = "Joinville",
                            StateId = 24
                        },
                        new
                        {
                            Id = 3,
                            Name = "Florianopolis",
                            StateId = 24
                        },
                        new
                        {
                            Id = 4,
                            Name = "Lages",
                            StateId = 24
                        },
                        new
                        {
                            Id = 5,
                            Name = "São Paulo",
                            StateId = 25
                        },
                        new
                        {
                            Id = 6,
                            Name = "Maringá",
                            StateId = 16
                        },
                        new
                        {
                            Id = 7,
                            Name = "Curitiba",
                            StateId = 16
                        },
                        new
                        {
                            Id = 8,
                            Name = "Manaus",
                            StateId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "Porto Alegre",
                            StateId = 21
                        },
                        new
                        {
                            Id = 10,
                            Name = "Charqueadas",
                            StateId = 21
                        });
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveryForecast")
                        .HasColumnType("datetime2");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("SaleId");

                    b.ToTable("Deliveries", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            DeliveryForecast = new DateTime(2000, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 10
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            DeliveryForecast = new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 9
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            DeliveryForecast = new DateTime(2005, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 8
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 4,
                            DeliveryForecast = new DateTime(2001, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 7
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 5,
                            DeliveryForecast = new DateTime(2011, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 6
                        },
                        new
                        {
                            Id = 6,
                            AddressId = 6,
                            DeliveryForecast = new DateTime(2008, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 5
                        },
                        new
                        {
                            Id = 7,
                            AddressId = 7,
                            DeliveryForecast = new DateTime(2005, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 4
                        },
                        new
                        {
                            Id = 8,
                            AddressId = 8,
                            DeliveryForecast = new DateTime(2002, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 3
                        },
                        new
                        {
                            Id = 9,
                            AddressId = 9,
                            DeliveryForecast = new DateTime(2000, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 2
                        },
                        new
                        {
                            Id = 10,
                            AddressId = 10,
                            DeliveryForecast = new DateTime(2011, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SaleId = 1
                        });
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Sales", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuyerId = 1,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 2
                        },
                        new
                        {
                            Id = 2,
                            BuyerId = 3,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 4
                        },
                        new
                        {
                            Id = 3,
                            BuyerId = 5,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 6
                        },
                        new
                        {
                            Id = 4,
                            BuyerId = 7,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 8
                        },
                        new
                        {
                            Id = 5,
                            BuyerId = 9,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 10
                        },
                        new
                        {
                            Id = 6,
                            BuyerId = 3,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 2
                        },
                        new
                        {
                            Id = 7,
                            BuyerId = 5,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 4
                        },
                        new
                        {
                            Id = 8,
                            BuyerId = 7,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 6
                        },
                        new
                        {
                            Id = 9,
                            BuyerId = 9,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 8
                        },
                        new
                        {
                            Id = 10,
                            BuyerId = 1,
                            SaleDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellerId = 10
                        });
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.SaleCar", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<decimal?>("UnitPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("SaleCars", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1,
                            CarId = 1,
                            SaleId = 1,
                            UnitPrice = 60000m
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1,
                            CarId = 2,
                            SaleId = 2,
                            UnitPrice = 20000m
                        },
                        new
                        {
                            Id = 3,
                            Amount = 1,
                            CarId = 3,
                            SaleId = 3,
                            UnitPrice = 30000m
                        },
                        new
                        {
                            Id = 4,
                            Amount = 3,
                            CarId = 1,
                            SaleId = 4,
                            UnitPrice = 60000m
                        },
                        new
                        {
                            Id = 5,
                            Amount = 1,
                            CarId = 4,
                            SaleId = 5,
                            UnitPrice = 20000m
                        },
                        new
                        {
                            Id = 6,
                            Amount = 1,
                            CarId = 7,
                            SaleId = 6,
                            UnitPrice = 50000m
                        },
                        new
                        {
                            Id = 7,
                            Amount = 2,
                            CarId = 9,
                            SaleId = 7,
                            UnitPrice = 70000m
                        },
                        new
                        {
                            Id = 8,
                            Amount = 1,
                            CarId = 6,
                            SaleId = 8,
                            UnitPrice = 10000m
                        },
                        new
                        {
                            Id = 9,
                            Amount = 2,
                            CarId = 3,
                            SaleId = 9,
                            UnitPrice = 30000m
                        },
                        new
                        {
                            Id = 10,
                            Amount = 1,
                            CarId = 9,
                            SaleId = 10,
                            UnitPrice = 70000m
                        });
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("States", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Initials = "AC",
                            Name = "Acre"
                        },
                        new
                        {
                            Id = 2,
                            Initials = "AL",
                            Name = "Alagoas"
                        },
                        new
                        {
                            Id = 3,
                            Initials = "AP",
                            Name = "Amapá"
                        },
                        new
                        {
                            Id = 4,
                            Initials = "AM",
                            Name = "Amazonas"
                        },
                        new
                        {
                            Id = 5,
                            Initials = "BA",
                            Name = "Bahia"
                        },
                        new
                        {
                            Id = 6,
                            Initials = "CE",
                            Name = "Ceará"
                        },
                        new
                        {
                            Id = 7,
                            Initials = "DF",
                            Name = "Distrito Federal"
                        },
                        new
                        {
                            Id = 8,
                            Initials = "ES",
                            Name = "Espírito Santo"
                        },
                        new
                        {
                            Id = 9,
                            Initials = "GO",
                            Name = "Goiás"
                        },
                        new
                        {
                            Id = 10,
                            Initials = "MA",
                            Name = "Maranhão"
                        },
                        new
                        {
                            Id = 11,
                            Initials = "MT",
                            Name = "Mato Grosso"
                        },
                        new
                        {
                            Id = 12,
                            Initials = "MS",
                            Name = "Mato Grosso do Sul"
                        },
                        new
                        {
                            Id = 13,
                            Initials = "MG",
                            Name = "Minas Gerais"
                        },
                        new
                        {
                            Id = 14,
                            Initials = "PA",
                            Name = "Pará"
                        },
                        new
                        {
                            Id = 15,
                            Initials = "PB",
                            Name = "Paraíba"
                        },
                        new
                        {
                            Id = 16,
                            Initials = "PR",
                            Name = "Paraná"
                        },
                        new
                        {
                            Id = 17,
                            Initials = "PE",
                            Name = "Pernambuco"
                        },
                        new
                        {
                            Id = 18,
                            Initials = "PI",
                            Name = "Piauí"
                        },
                        new
                        {
                            Id = 19,
                            Initials = "RJ",
                            Name = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = 20,
                            Initials = "RN",
                            Name = "Rio Grande do Norte"
                        },
                        new
                        {
                            Id = 21,
                            Initials = "RS",
                            Name = "Rio Grande do Sul"
                        },
                        new
                        {
                            Id = 22,
                            Initials = "RO",
                            Name = "Rondônia"
                        },
                        new
                        {
                            Id = 23,
                            Initials = "RR",
                            Name = "Roraima"
                        },
                        new
                        {
                            Id = 24,
                            Initials = "SC",
                            Name = "Santa Catarina"
                        },
                        new
                        {
                            Id = 25,
                            Initials = "SP",
                            Name = "São Paulo"
                        },
                        new
                        {
                            Id = 26,
                            Initials = "SE",
                            Name = "Sergipe"
                        },
                        new
                        {
                            Id = 27,
                            Initials = "TO",
                            Name = "Tocantins"
                        });
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2000, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jose@email.com",
                            Name = "Jose",
                            Password = "123456opp78dfg",
                            Permission = 2
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "andrea@email.com",
                            Name = "Andrea",
                            Password = "987dasd654321d",
                            Permission = 0
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2005, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "adao@email.com",
                            Name = "Adao",
                            Password = "2589as89898ddf",
                            Permission = 1
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(2001, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "andre@email.com",
                            Name = "andre",
                            Password = "asasdd45uiodfg",
                            Permission = 1
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(2011, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Marcos@email.com",
                            Name = "Marcos",
                            Password = "asd45uidfg121o",
                            Permission = 0
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(2008, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Manuela@email.com",
                            Name = "Manuela",
                            Password = "asd45dfgu789io",
                            Permission = 0
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(2005, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Vania@email.com",
                            Name = "Vania",
                            Password = "asd454563213ui",
                            Permission = 0
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(2002, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "carla@email.com",
                            Name = "carla",
                            Password = "asdfgd45ui121o",
                            Permission = 0
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTime(2000, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Malena@email.com",
                            Name = "Malena",
                            Password = "asd45ui898odfg",
                            Permission = 0
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTime(2011, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Marize@email.com",
                            Name = "Marize",
                            Password = "asd45uidfgdfgo",
                            Permission = 0
                        });
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Address", b =>
                {
                    b.HasOne("DEVinCar.Domain.Entities.Models.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.City", b =>
                {
                    b.HasOne("DEVinCar.Domain.Entities.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Delivery", b =>
                {
                    b.HasOne("DEVinCar.Domain.Entities.Models.Address", "Address")
                        .WithMany("Deliveries")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinCar.Domain.Entities.Models.Sale", "Sale")
                        .WithMany("Deliveries")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Sale", b =>
                {
                    b.HasOne("DEVinCar.Domain.Entities.Models.User", "UserBuyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DEVinCar.Domain.Entities.Models.User", "UserSeller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserBuyer");

                    b.Navigation("UserSeller");
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.SaleCar", b =>
                {
                    b.HasOne("DEVinCar.Domain.Entities.Models.Car", "Car")
                        .WithMany("Sales")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinCar.Domain.Entities.Models.Sale", "Sale")
                        .WithMany("Cars")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Address", b =>
                {
                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Car", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.Sale", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("DEVinCar.Domain.Entities.Models.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
