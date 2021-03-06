// <auto-generated />
using System;
using CustomerManagement.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerManagement.Migrations
{
    [DbContext(typeof(CustomerDBContext))]
    partial class CustomerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerManagement.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            BusinessName = "OnlineService",
                            CreatedDate = new DateTime(2021, 8, 14, 23, 48, 21, 769, DateTimeKind.Local).AddTicks(4771),
                            DateofBirth = new DateTime(1960, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Mathew"
                        },
                        new
                        {
                            CustomerId = 2,
                            BusinessName = "Hotel",
                            CreatedDate = new DateTime(2021, 8, 14, 23, 48, 21, 770, DateTimeKind.Local).AddTicks(3796),
                            DateofBirth = new DateTime(2000, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Smith",
                            LastName = "Williams"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
