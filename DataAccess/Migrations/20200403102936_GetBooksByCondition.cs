using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class GetBooksByCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			string procedure = @"
							CREATE PROCEDURE GetBooksByCondition
								@inGoodCondition bit
							AS
							BEGIN
								SELECT
								b.Author,
								b.Title, 

									(	SELECT TOP 1 c.Text 
										FROM Comments as c 
										WHERE b.Id = c.BookId 
										ORDER BY CreatedDate DESC) as LastCommentText, 

									(	SELECT TOP 1 c.CreatedDate 
										FROM Comments as c 
										WHERE b.Id = c.BookId
										ORDER BY CreatedDate DESC) as LastCommentTime 

								FROM Books AS b
								WHERE b.InGoodCondition = @inGoodCondition
								ORDER BY Author;
							END
							";
			migrationBuilder.Sql(procedure);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			string procedure = @"DROP PROCEDURE GetBooksByCondition";
			migrationBuilder.Sql(procedure);
		}
    }
}
