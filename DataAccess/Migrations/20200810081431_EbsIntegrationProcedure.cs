using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class EbsIntegrationProcedure : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			string procedure = @"
							CREATE OR ALTER PROCEDURE EbsDataIntegration
							AS
							BEGIN
								DECLARE @SourceTable TABLE
								( 
									CreatedBy VARCHAR(MAX), 
									CreatedDate DATETIME, 
									FirstName VARCHAR(50),
									LastName VARCHAR(50),
									Email NVARCHAR(50) NOT NULL,
									Password VARCHAR(MAX),
									RoleId UNIQUEIDENTIFIER NOT NULL,
									Address VARCHAR(MAX),
									IsDeleted BIT NOT NULL,
									Status INT NULL
								);

								INSERT INTO @SourceTable
								SELECT * FROM 
								OPENQUERY([DESKTOP-5J1MT1O\SQLEXPRESS01], 
									'SELECT * FROM [AdventureWorks2019].[dbo].[EmployeeListForEBS]');

								MERGE INTO ebsContext.dbo.Users AS TGT
								USING @SourceTable AS SRC
								ON TGT.Email = SRC.Email
								WHEN MATCHED AND TGT.IsDeleted = 1
									THEN UPDATE SET IsDeleted = 0
								WHEN NOT MATCHED
									THEN INSERT (CreatedBy, CreatedDate, FirstName, LastName, Email, Password, RoleId, Address, IsDeleted, Status)
									VALUES (SRC.CreatedBy, SRC.CreatedDate, SRC.FirstName, SRC.LastName, SRC.Email, SRC.Password, SRC.RoleId, SRC.Address, SRC.IsDeleted, SRC.Status)
								OUTPUT $action, deleted.*, inserted.*;
							END;
							";
			migrationBuilder.Sql(procedure);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			string procedure = @"DROP PROCEDURE IF EXISTS EbsDataIntegration";
			migrationBuilder.Sql(procedure);
		}
	}
}
