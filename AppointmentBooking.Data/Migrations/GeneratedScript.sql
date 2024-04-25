CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Appointment" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Appointment" PRIMARY KEY AUTOINCREMENT,
    "Date" TEXT NOT NULL,
    "CustomerName" TEXT NOT NULL,
    "Token" TEXT NOT NULL
);

CREATE TABLE "Configuration" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Configuration" PRIMARY KEY AUTOINCREMENT,
    "MaxAppointmentPerDay" INTEGER NOT NULL,
    "PublicHolidays" TEXT NOT NULL,
    "CreatedDate" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240425061517_InitialCreate', '8.0.4');

COMMIT;

