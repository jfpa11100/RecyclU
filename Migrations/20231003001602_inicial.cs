using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecyclU.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Negocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversidadEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpresaEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Negocio_Usuario_EmpresaEmail",
                        column: x => x.EmpresaEmail,
                        principalTable: "Usuario",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Negocio_Usuario_UniversidadEmail",
                        column: x => x.UniversidadEmail,
                        principalTable: "Usuario",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    UniversidadEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Usuario_UniversidadEmail",
                        column: x => x.UniversidadEmail,
                        principalTable: "Usuario",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_EmpresaEmail",
                table: "Negocio",
                column: "EmpresaEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_UniversidadEmail",
                table: "Negocio",
                column: "UniversidadEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UniversidadEmail",
                table: "Post",
                column: "UniversidadEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Negocio");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
