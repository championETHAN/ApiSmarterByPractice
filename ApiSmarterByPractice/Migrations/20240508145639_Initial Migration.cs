using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSmarterByPractice.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserScoress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReactionTime = table.Column<int>(type: "int", nullable: false),
                    SequenceMemory = table.Column<int>(type: "int", nullable: false),
                    AimTrainer = table.Column<int>(type: "int", nullable: false),
                    NumberMemory = table.Column<int>(type: "int", nullable: false),
                    VerbalMemory = table.Column<int>(type: "int", nullable: false),
                    ChimpTest = table.Column<int>(type: "int", nullable: false),
                    VisualMemory = table.Column<int>(type: "int", nullable: false),
                    TypingTest = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScoress", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserScoress");
        }
    }
}
