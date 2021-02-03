using Microsoft.EntityFrameworkCore.Migrations;

namespace WebapiKodig.Migrations
{
    public partial class Produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    CODIGO = table.Column<string>(maxLength: 15, nullable: false),
                    PRODUTO = table.Column<string>(maxLength: 20, nullable: true),
                    QUANTIDADE = table.Column<decimal>(nullable: false),
                    SALDO = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.CODIGO);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    CODIGO = table.Column<string>(maxLength: 20, nullable: false),
                    TIPO = table.Column<string>(maxLength: 2, nullable: false),
                    UM = table.Column<string>(maxLength: 2, nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.CODIGO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "produtos");
        }
    }
}
