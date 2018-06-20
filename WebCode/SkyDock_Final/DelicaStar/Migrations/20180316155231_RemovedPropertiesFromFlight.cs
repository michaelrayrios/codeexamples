using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkyDock.Migrations
{
    public partial class RemovedPropertiesFromFlight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FCharter_Details",
                table: "_Flights");

            migrationBuilder.DropColumn(
                name: "FCharter_Name_First",
                table: "_Flights");

            migrationBuilder.DropColumn(
                name: "FCharter_Name_Last",
                table: "_Flights");

            migrationBuilder.DropColumn(
                name: "FCharter_Organization",
                table: "_Flights");

            migrationBuilder.DropColumn(
                name: "FContractor_Details",
                table: "_Flights");

            migrationBuilder.DropColumn(
                name: "FContractor_Name_First",
                table: "_Flights");

            migrationBuilder.DropColumn(
                name: "FContractor_Name_Last",
                table: "_Flights");

            migrationBuilder.DropColumn(
                name: "FContractor_Organization",
                table: "_Flights");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FCharter_Details",
                table: "_Flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FCharter_Name_First",
                table: "_Flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FCharter_Name_Last",
                table: "_Flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FCharter_Organization",
                table: "_Flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FContractor_Details",
                table: "_Flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FContractor_Name_First",
                table: "_Flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FContractor_Name_Last",
                table: "_Flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FContractor_Organization",
                table: "_Flights",
                nullable: true);
        }
    }
}
