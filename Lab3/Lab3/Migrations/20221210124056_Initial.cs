using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workcatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workcatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Typeofworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ordernumber = table.Column<int>(name: "Order_number", type: "int", nullable: false),
                    Joblinenumber = table.Column<int>(name: "Job_line_number", type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jobid = table.Column<int>(name: "Job_id", type: "int", nullable: false),
                    workcatalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typeofworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Typeofworks_Workcatalogs_workcatalogId",
                        column: x => x.workcatalogId,
                        principalTable: "Workcatalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Typeofworks_workcatalogId",
                table: "Typeofworks",
                column: "workcatalogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Typeofworks");

            migrationBuilder.DropTable(
                name: "Workcatalogs");
        }
    }
}
