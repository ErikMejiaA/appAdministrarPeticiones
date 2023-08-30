using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationsCreateV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreGenero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    IdCodigo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombrePais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.IdCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSalon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.IdCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoPersonas",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionTipoPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersonas", x => x.IdCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    IdCodigo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreDep = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFK = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.IdCodigo);
                    table.ForeignKey(
                        name: "FK_Departamentos_Paises_IdPaisFK",
                        column: x => x.IdPaisFK,
                        principalTable: "Paises",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuariosRoles",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRoles", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    IdCodigo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCiudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepFk = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.IdCodigo);
                    table.ForeignKey(
                        name: "FK_Ciudades_Departamentos_IdDepFk",
                        column: x => x.IdDepFk,
                        principalTable: "Departamentos",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoPaterno = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoMaterno = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdGeneroFk = table.Column<int>(type: "int", nullable: false),
                    IdCiudadFk = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoPerFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdCodigo);
                    table.ForeignKey(
                        name: "FK_Personas_Ciudades_IdCiudadFk",
                        column: x => x.IdCiudadFk,
                        principalTable: "Ciudades",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Generos_IdGeneroFk",
                        column: x => x.IdGeneroFk,
                        principalTable: "Generos",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_TipoPersonas_IdTipoPerFk",
                        column: x => x.IdTipoPerFk,
                        principalTable: "TipoPersonas",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoVia = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Letra = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SufijoCardinal = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroViaSecundaria = table.Column<int>(type: "int", nullable: false),
                    LetraViaSecundaria = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SufijoCards = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.IdCodigo);
                    table.ForeignKey(
                        name: "FK_Direcciones_Personas_IdPersonaFk",
                        column: x => x.IdPersonaFk,
                        principalTable: "Personas",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersonaFK = table.Column<int>(type: "int", nullable: false),
                    IdSalonFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.IdCodigo);
                    table.ForeignKey(
                        name: "FK_Matriculas_Personas_IdPersonaFK",
                        column: x => x.IdPersonaFK,
                        principalTable: "Personas",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Salones_IdSalonFk",
                        column: x => x.IdSalonFk,
                        principalTable: "Salones",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonaRoles",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaRoles", x => new { x.PersonaId, x.RolId });
                    table.ForeignKey(
                        name: "FK_PersonaRoles_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaRoles_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrainerSalones",
                columns: table => new
                {
                    IdPerTrainerFk = table.Column<int>(type: "int", nullable: false),
                    IdSalonFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerSalones", x => new { x.IdPerTrainerFk, x.IdSalonFk });
                    table.ForeignKey(
                        name: "FK_TrainerSalones_Personas_IdPerTrainerFk",
                        column: x => x.IdPerTrainerFk,
                        principalTable: "Personas",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerSalones_Salones_IdSalonFk",
                        column: x => x.IdSalonFk,
                        principalTable: "Salones",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_IdCodigo",
                table: "Ciudades",
                column: "IdCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_IdDepFk",
                table: "Ciudades",
                column: "IdDepFk");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_NombreCiudad",
                table: "Ciudades",
                column: "NombreCiudad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_IdCodigo",
                table: "Departamentos",
                column: "IdCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_IdPaisFK",
                table: "Departamentos",
                column: "IdPaisFK");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_NombreDep",
                table: "Departamentos",
                column: "NombreDep",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_IdPersonaFk",
                table: "Direcciones",
                column: "IdPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_NombreGenero",
                table: "Generos",
                column: "NombreGenero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_IdPersonaFK",
                table: "Matriculas",
                column: "IdPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_IdSalonFk",
                table: "Matriculas",
                column: "IdSalonFk");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_IdCodigo",
                table: "Paises",
                column: "IdCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_NombrePais",
                table: "Paises",
                column: "NombrePais",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonaRoles_RolId",
                table: "PersonaRoles",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdCiudadFk",
                table: "Personas",
                column: "IdCiudadFk");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdCodigo",
                table: "Personas",
                column: "IdCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdGeneroFk",
                table: "Personas",
                column: "IdGeneroFk");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdTipoPerFk",
                table: "Personas",
                column: "IdTipoPerFk");

            migrationBuilder.CreateIndex(
                name: "IX_Salones_NombreSalon",
                table: "Salones",
                column: "NombreSalon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSalones_IdSalonFk",
                table: "TrainerSalones",
                column: "IdSalonFk");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_RolId",
                table: "UsuariosRoles",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "PersonaRoles");

            migrationBuilder.DropTable(
                name: "TrainerSalones");

            migrationBuilder.DropTable(
                name: "UsuariosRoles");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Salones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "TipoPersonas");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
