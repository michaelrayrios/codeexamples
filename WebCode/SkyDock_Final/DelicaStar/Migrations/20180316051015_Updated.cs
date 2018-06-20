using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkyDock.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharterID",
                table: "_Flights");

            migrationBuilder.DropColumn(
                name: "ContractorID",
                table: "_Flights");

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

            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "_Contractors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "_Charters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX__Contractors_FlightID",
                table: "_Contractors",
                column: "FlightID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__Charters_FlightID",
                table: "_Charters",
                column: "FlightID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Charters__Flights_FlightID",
                table: "_Charters",
                column: "FlightID",
                principalTable: "_Flights",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Contractors__Flights_FlightID",
                table: "_Contractors",
                column: "FlightID",
                principalTable: "_Flights",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Charters__Flights_FlightID",
                table: "_Charters");

            migrationBuilder.DropForeignKey(
                name: "FK__Contractors__Flights_FlightID",
                table: "_Contractors");

            migrationBuilder.DropIndex(
                name: "IX__Contractors_FlightID",
                table: "_Contractors");

            migrationBuilder.DropIndex(
                name: "IX__Charters_FlightID",
                table: "_Charters");

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

            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "_Contractors");

            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "_Charters");

            migrationBuilder.AddColumn<int>(
                name: "CharterID",
                table: "_Flights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContractorID",
                table: "_Flights",
                nullable: false,
                defaultValue: 0);
        }
    }
}
