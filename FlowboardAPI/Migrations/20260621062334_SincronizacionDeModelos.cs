using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace FlowboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class SincronizacionDeModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pay_slip",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    collaborator_id = table.Column<int>(type: "int", nullable: false),
                    collaborator_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    collaborator_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    area = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    period = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    payment_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    gross_income = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    deductions = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    issue_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    pdf_file_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pay_slip", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pay_slip");
        }
    }
}
