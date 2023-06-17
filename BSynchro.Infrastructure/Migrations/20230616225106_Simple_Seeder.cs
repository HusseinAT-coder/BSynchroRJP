using BSynchro.Domain.Shared;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSynchro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Simple_Seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers", // table name
                columns: new[] { "Id", "Name", "SurName", "Balance", "Email", "CreationDate", "IsDeleted", "DeletionDate", "LastUpdateDate" },
                values: new object[] { BSynchroConsts.HussienCustomerId, "Hussein", "Atiah", 0, "hussein.atiah1t@gmail.com", DateTime.UtcNow, false, null, null }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers", // table name
                keyColumn: "Id",
                keyValue: BSynchroConsts.HussienCustomerId);
        }
    }
}
