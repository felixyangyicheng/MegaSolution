using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaSolution.Migrations
{
    public partial class ArtistProfileLineOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineOffers_Carts_CartId",
                table: "LineOffers");

            migrationBuilder.DropIndex(
                name: "IX_LineOffers_CartId",
                table: "LineOffers");

            migrationBuilder.AddColumn<Guid>(
                name: "ArtistProfileId",
                table: "LineOffers",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineOffers_ArtistProfileId",
                table: "LineOffers",
                column: "ArtistProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineOffers_Carts_ArtistProfileId",
                table: "LineOffers",
                column: "ArtistProfileId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineOffers_Carts_ArtistProfileId",
                table: "LineOffers");

            migrationBuilder.DropIndex(
                name: "IX_LineOffers_ArtistProfileId",
                table: "LineOffers");

            migrationBuilder.DropColumn(
                name: "ArtistProfileId",
                table: "LineOffers");

            migrationBuilder.CreateIndex(
                name: "IX_LineOffers_CartId",
                table: "LineOffers",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineOffers_Carts_CartId",
                table: "LineOffers",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
