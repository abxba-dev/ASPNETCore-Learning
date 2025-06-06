using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class InsertPerson_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_InsertPerson = @"
    CREATE PROCEDURE [dbo].[InsertPerson]
        @PersonId UNIQUEIDENTIFIER,
        @PersonName NVARCHAR(40), 
        @Email NVARCHAR(50), 
        @DateOfBirth DATETIME2(7), 
        @Gender VARCHAR(10), 
        @CountryID UNIQUEIDENTIFIER, 
        @Address NVARCHAR(1000), 
        @ReceiveNewsLetters BIT
    AS
    BEGIN
        INSERT INTO [dbo].[Persons] (
            PersonID, PersonName, Email, DateOfBirth, Gender, CountryID, Address, ReceiveNewsLetters
        ) 
        VALUES (
            @PersonId, @PersonName, @Email, @DateOfBirth, @Gender, @CountryID, @Address, @ReceiveNewsLetters
        );
    END
";


            migrationBuilder.Sql(sp_InsertPerson);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_InsertPerson = @"
                DROP PROCEDURE [dbo].[InsertPerson]
            ";

            migrationBuilder.Sql(sp_InsertPerson);
        }
    }
}
