using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceRegister.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameColumnsInInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Subjects_IssuerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Subjects_PurchaseId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "Invoices",
                newName: "PurchaseNip");

            migrationBuilder.RenameColumn(
                name: "IssuerId",
                table: "Invoices",
                newName: "IssuerNip");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_PurchaseId",
                table: "Invoices",
                newName: "IX_Invoices_PurchaseNip");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_IssuerId",
                table: "Invoices",
                newName: "IX_Invoices_IssuerNip");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Subjects_IssuerNip",
                table: "Invoices",
                column: "IssuerNip",
                principalTable: "Subjects",
                principalColumn: "Nip",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Subjects_PurchaseNip",
                table: "Invoices",
                column: "PurchaseNip",
                principalTable: "Subjects",
                principalColumn: "Nip",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Subjects_IssuerNip",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Subjects_PurchaseNip",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "PurchaseNip",
                table: "Invoices",
                newName: "PurchaseId");

            migrationBuilder.RenameColumn(
                name: "IssuerNip",
                table: "Invoices",
                newName: "IssuerId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_PurchaseNip",
                table: "Invoices",
                newName: "IX_Invoices_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_IssuerNip",
                table: "Invoices",
                newName: "IX_Invoices_IssuerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Subjects_IssuerId",
                table: "Invoices",
                column: "IssuerId",
                principalTable: "Subjects",
                principalColumn: "Nip",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Subjects_PurchaseId",
                table: "Invoices",
                column: "PurchaseId",
                principalTable: "Subjects",
                principalColumn: "Nip",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
