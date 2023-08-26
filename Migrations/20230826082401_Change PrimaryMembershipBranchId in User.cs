using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EI_Task.Migrations
{
    /// <inheritdoc />
    public partial class ChangePrimaryMembershipBranchIdinUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryMembershipBranchId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryMembershipBranchId",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}
