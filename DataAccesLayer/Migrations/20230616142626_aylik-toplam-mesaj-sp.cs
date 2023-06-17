using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class ayliktoplammesajsp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
CREATE PROCEDURE AylikToplamMesaj

AS
BEGIN
	SELECT 
		SUBSTRING (convert(varchar,(FORMAT([Date], 'MMMM')),100),1,3) AS Aylar,COUNT(*) AS Toplam
	FROM [dbMyCV_Proje].[dbo].[Messages] where datepart(year,[Date]) = 2023
	GROUP BY [Date]
END
GO

            ";
            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
