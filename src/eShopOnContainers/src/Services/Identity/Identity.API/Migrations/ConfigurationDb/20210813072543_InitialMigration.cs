namespace Identity.API.Migrations.ConfigurationDb
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "ApiResources",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>("bit", nullable: false),
                    Name = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>("nvarchar(1000)", maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>("datetime2", nullable: false),
                    Updated = table.Column<DateTime>("datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>("datetime2", nullable: true),
                    NonEditable = table.Column<bool>("bit", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "Clients",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>("bit", nullable: false),
                    ClientId = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    ProtocolType = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>("bit", nullable: false),
                    ClientName = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>("nvarchar(1000)", maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>("bit", nullable: false),
                    AllowRememberConsent = table.Column<bool>("bit", nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>("bit", nullable: false),
                    RequirePkce = table.Column<bool>("bit", nullable: false),
                    AllowPlainTextPkce = table.Column<bool>("bit", nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>("bit", nullable: false),
                    FrontChannelLogoutUri = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>("bit", nullable: false),
                    BackChannelLogoutUri = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>("bit", nullable: false),
                    AllowOfflineAccess = table.Column<bool>("bit", nullable: false),
                    IdentityTokenLifetime = table.Column<int>("int", nullable: false),
                    AccessTokenLifetime = table.Column<int>("int", nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>("int", nullable: false),
                    ConsentLifetime = table.Column<int>("int", nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>("int", nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>("int", nullable: false),
                    RefreshTokenUsage = table.Column<int>("int", nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>("bit", nullable: false),
                    RefreshTokenExpiration = table.Column<int>("int", nullable: false),
                    AccessTokenType = table.Column<int>("int", nullable: false),
                    EnableLocalLogin = table.Column<bool>("bit", nullable: false),
                    IncludeJwtId = table.Column<bool>("bit", nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>("bit", nullable: false),
                    ClientClaimsPrefix = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>("datetime2", nullable: false),
                    Updated = table.Column<DateTime>("datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>("datetime2", nullable: true),
                    UserSsoLifetime = table.Column<int>("int", nullable: true),
                    UserCodeType = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>("int", nullable: false),
                    NonEditable = table.Column<bool>("bit", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "IdentityResources",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>("bit", nullable: false),
                    Name = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>("nvarchar(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>("bit", nullable: false),
                    Emphasize = table.Column<bool>("bit", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>("bit", nullable: false),
                    Created = table.Column<DateTime>("datetime2", nullable: false),
                    Updated = table.Column<DateTime>("datetime2", nullable: true),
                    NonEditable = table.Column<bool>("bit", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "ApiClaims",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>("int", nullable: false),
                    Type = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiClaims_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "ApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiProperties",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>("int", nullable: false),
                    Key = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiProperties_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "ApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiScopes",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>("nvarchar(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>("bit", nullable: false),
                    Emphasize = table.Column<bool>("bit", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>("bit", nullable: false),
                    ApiResourceId = table.Column<int>("int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopes", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiScopes_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "ApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiSecrets",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>("int", nullable: false),
                    Description = table.Column<string>("nvarchar(1000)", maxLength: 1000, nullable: true),
                    Value = table.Column<string>("nvarchar(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>("datetime2", nullable: true),
                    Type = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>("datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiSecrets", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiSecrets_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "ApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientClaims",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>("int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientClaims_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientCorsOrigins",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>("nvarchar(150)", maxLength: 150, nullable: false),
                    ClientId = table.Column<int>("int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCorsOrigins", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientCorsOrigins_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientGrantTypes",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrantType = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>("int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGrantTypes", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientGrantTypes_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientIdPRestrictions",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>("int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdPRestrictions", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientIdPRestrictions_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientPostLogoutRedirectUris",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostLogoutRedirectUri = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>("int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPostLogoutRedirectUris", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientPostLogoutRedirectUris_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientProperties",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>("int", nullable: false),
                    Key = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientProperties_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientRedirectUris",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedirectUri = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>("int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRedirectUris", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientRedirectUris_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientScopes",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>("int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientScopes_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientSecrets",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>("int", nullable: false),
                    Description = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: true),
                    Value = table.Column<string>("nvarchar(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>("datetime2", nullable: true),
                    Type = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>("datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSecrets", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientSecrets_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityClaims",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityResourceId = table.Column<int>("int", nullable: false),
                    Type = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityClaims_IdentityResources_IdentityResourceId",
                        x => x.IdentityResourceId,
                        "IdentityResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityProperties",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityResourceId = table.Column<int>("int", nullable: false),
                    Key = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityProperties_IdentityResources_IdentityResourceId",
                        x => x.IdentityResourceId,
                        "IdentityResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiScopeClaims",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiScopeId = table.Column<int>("int", nullable: false),
                    Type = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiScopeClaims_ApiScopes_ApiScopeId",
                        x => x.ApiScopeId,
                        "ApiScopes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_ApiClaims_ApiResourceId",
                "ApiClaims",
                "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ApiProperties_ApiResourceId",
                "ApiProperties",
                "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ApiResources_Name",
                "ApiResources",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ApiScopeClaims_ApiScopeId",
                "ApiScopeClaims",
                "ApiScopeId");

            migrationBuilder.CreateIndex(
                "IX_ApiScopes_ApiResourceId",
                "ApiScopes",
                "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ApiScopes_Name",
                "ApiScopes",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ApiSecrets_ApiResourceId",
                "ApiSecrets",
                "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ClientClaims_ClientId",
                "ClientClaims",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientCorsOrigins_ClientId",
                "ClientCorsOrigins",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientGrantTypes_ClientId",
                "ClientGrantTypes",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientIdPRestrictions_ClientId",
                "ClientIdPRestrictions",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientPostLogoutRedirectUris_ClientId",
                "ClientPostLogoutRedirectUris",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientProperties_ClientId",
                "ClientProperties",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientRedirectUris_ClientId",
                "ClientRedirectUris",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_Clients_ClientId",
                "Clients",
                "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ClientScopes_ClientId",
                "ClientScopes",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientSecrets_ClientId",
                "ClientSecrets",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityClaims_IdentityResourceId",
                "IdentityClaims",
                "IdentityResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityProperties_IdentityResourceId",
                "IdentityProperties",
                "IdentityResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityResources_Name",
                "IdentityResources",
                "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiClaims");

            migrationBuilder.DropTable(
                name: "ApiProperties");

            migrationBuilder.DropTable(
                name: "ApiScopeClaims");

            migrationBuilder.DropTable(
                name: "ApiSecrets");

            migrationBuilder.DropTable(
                name: "ClientClaims");

            migrationBuilder.DropTable(
                name: "ClientCorsOrigins");

            migrationBuilder.DropTable(
                name: "ClientGrantTypes");

            migrationBuilder.DropTable(
                name: "ClientIdPRestrictions");

            migrationBuilder.DropTable(
                name: "ClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                name: "ClientProperties");

            migrationBuilder.DropTable(
                name: "ClientRedirectUris");

            migrationBuilder.DropTable(
                name: "ClientScopes");

            migrationBuilder.DropTable(
                name: "ClientSecrets");

            migrationBuilder.DropTable(
                name: "IdentityClaims");

            migrationBuilder.DropTable(
                name: "IdentityProperties");

            migrationBuilder.DropTable(
                name: "ApiScopes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "IdentityResources");

            migrationBuilder.DropTable(
                name: "ApiResources");
        }
    }
}
