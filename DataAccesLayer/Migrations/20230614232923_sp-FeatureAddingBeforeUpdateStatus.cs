using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class spFeatureAddingBeforeUpdateStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[FeatureAddingBeforeUpdateStatus]
                   
                AS
                BEGIN
                    SET NOCOUNT ON;
                 	UPDATE [dbMyCV_Proje].[dbo].[Features] SET [Status] = 0
                END";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
