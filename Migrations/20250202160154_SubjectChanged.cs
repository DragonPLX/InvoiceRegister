using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceRegister.Migrations
{
    /// <inheritdoc />
    public partial class SubjectChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Invoices_InvoiceId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_InvoiceId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Subjects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_InvoiceId",
                table: "Subjects",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Invoices_InvoiceId",
                table: "Subjects",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
