﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnfrageDaten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KundenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjektName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeuesProjekt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nachricht = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ansprechpartner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Erledigt = table.Column<bool>(type: "bit", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kommentar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mitarbeiter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KommentarUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KommentarZeit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TicketMitarbeiterListe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnfrageDaten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginDaten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rolle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IstEingeloggt = table.Column<bool>(type: "bit", nullable: false),
                    VollerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KommentierZeit = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDaten", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnfrageDaten");

            migrationBuilder.DropTable(
                name: "LoginDaten");
        }
    }
}
