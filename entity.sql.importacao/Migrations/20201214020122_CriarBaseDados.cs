using Microsoft.EntityFrameworkCore.Migrations;

namespace entity.sql.importacao.Migrations
{
    public partial class CriarBaseDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_nota_fiscal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfNfe = table.Column<string>(maxLength: 256, nullable: true),
                    Versao = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nota_fiscal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_det_item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CProd = table.Column<string>(nullable: true),
                    CEan = table.Column<string>(nullable: true),
                    XProd = table.Column<string>(nullable: true),
                    Ncm = table.Column<string>(nullable: true),
                    Cest = table.Column<string>(nullable: true),
                    IndEscala = table.Column<string>(nullable: true),
                    Cfop = table.Column<string>(nullable: true),
                    UCom = table.Column<string>(nullable: true),
                    QCom = table.Column<string>(nullable: true),
                    VUnCom = table.Column<string>(nullable: true),
                    VProd = table.Column<string>(nullable: true),
                    CEantrib = table.Column<string>(nullable: true),
                    UTrib = table.Column<string>(nullable: true),
                    QTrib = table.Column<string>(nullable: true),
                    VUnTrib = table.Column<string>(nullable: true),
                    IndTot = table.Column<string>(nullable: true),
                    VTotTrib = table.Column<string>(nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_det_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_det_item_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_emitente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(nullable: true),
                    XNome = table.Column<string>(nullable: true),
                    XFant = table.Column<string>(nullable: true),
                    Ie = table.Column<string>(nullable: true),
                    Crt = table.Column<string>(nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_emitente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_emitente_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_ide",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUf = table.Column<string>(maxLength: 256, nullable: true),
                    CNf = table.Column<string>(maxLength: 256, nullable: true),
                    NatOp = table.Column<string>(maxLength: 256, nullable: true),
                    Mod = table.Column<string>(maxLength: 256, nullable: true),
                    Serie = table.Column<string>(maxLength: 256, nullable: true),
                    NNf = table.Column<string>(maxLength: 256, nullable: true),
                    DhEmi = table.Column<string>(maxLength: 256, nullable: true),
                    TpNf = table.Column<string>(maxLength: 256, nullable: true),
                    IdDest = table.Column<string>(maxLength: 256, nullable: true),
                    CMunFg = table.Column<string>(maxLength: 256, nullable: true),
                    TpImp = table.Column<string>(maxLength: 256, nullable: true),
                    TpEmis = table.Column<string>(maxLength: 256, nullable: true),
                    CDv = table.Column<string>(maxLength: 256, nullable: true),
                    TpAmb = table.Column<string>(maxLength: 256, nullable: true),
                    FinNfe = table.Column<string>(maxLength: 256, nullable: true),
                    IndFinal = table.Column<string>(maxLength: 256, nullable: true),
                    IndPres = table.Column<string>(maxLength: 256, nullable: true),
                    ProcEmi = table.Column<string>(maxLength: 256, nullable: true),
                    VerProc = table.Column<string>(maxLength: 256, nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_ide", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_ide_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_inf_adicional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfAdFisco = table.Column<string>(nullable: true),
                    InfCpl = table.Column<string>(nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_inf_adicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_inf_adicional_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_inf_suplementar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QrCode = table.Column<string>(nullable: true),
                    UrlChave = table.Column<string>(nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_inf_suplementar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_inf_suplementar_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VTroco = table.Column<string>(nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_pagamento_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_protocolo_nfe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TpAmb = table.Column<string>(nullable: true),
                    VerAplic = table.Column<string>(nullable: true),
                    ChNfe = table.Column<string>(nullable: true),
                    DhRecbto = table.Column<string>(nullable: true),
                    NProt = table.Column<string>(nullable: true),
                    DigVal = table.Column<string>(nullable: true),
                    CStat = table.Column<string>(nullable: true),
                    XMotivo = table.Column<string>(nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_protocolo_nfe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_protocolo_nfe_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_signature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanonicalizationMethod = table.Column<string>(nullable: true),
                    SignatureMethod = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    Transform1 = table.Column<string>(nullable: true),
                    Transform2 = table.Column<string>(nullable: true),
                    DigestMethod = table.Column<string>(nullable: true),
                    DigestValue = table.Column<string>(nullable: true),
                    SignatureValue = table.Column<string>(nullable: true),
                    X509certificate = table.Column<string>(nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_signature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_signature_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_total_icms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QrCode = table.Column<string>(nullable: true),
                    VBc = table.Column<string>(nullable: true),
                    VIcms = table.Column<string>(nullable: true),
                    VIcmsdeson = table.Column<string>(nullable: true),
                    VFcp = table.Column<string>(nullable: true),
                    VBcst = table.Column<string>(nullable: true),
                    VSt = table.Column<string>(nullable: true),
                    VFcpst = table.Column<string>(nullable: true),
                    VFcpstret = table.Column<string>(nullable: true),
                    VProd = table.Column<string>(nullable: true),
                    VFrete = table.Column<string>(nullable: true),
                    VSeg = table.Column<string>(nullable: true),
                    VDesc = table.Column<string>(nullable: true),
                    VIi = table.Column<string>(nullable: true),
                    VIpi = table.Column<string>(nullable: true),
                    VIpidevol = table.Column<string>(nullable: true),
                    VPis = table.Column<string>(nullable: true),
                    VCofins = table.Column<string>(nullable: true),
                    VOutro = table.Column<string>(nullable: true),
                    VNf = table.Column<string>(nullable: true),
                    VTotTrib = table.Column<string>(nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_total_icms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_total_icms_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_transportadora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modFrete = table.Column<string>(nullable: true),
                    NotaFiscalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_transportadora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_transportadora_tb_nota_fiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "tb_nota_fiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_imp_cofins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NFeDetItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_imp_cofins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_imp_cofins_tb_nfe_det_item_NFeDetItemId",
                        column: x => x.NFeDetItemId,
                        principalTable: "tb_nfe_det_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_imp_icms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orig = table.Column<string>(nullable: true),
                    Csosn = table.Column<string>(nullable: true),
                    NFeDetItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_imp_icms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_imp_icms_tb_nfe_det_item_NFeDetItemId",
                        column: x => x.NFeDetItemId,
                        principalTable: "tb_nfe_det_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_imp_pis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NFeDetItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_imp_pis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_imp_pis_tb_nfe_det_item_NFeDetItemId",
                        column: x => x.NFeDetItemId,
                        principalTable: "tb_nfe_det_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_end_emitente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XLgr = table.Column<string>(nullable: true),
                    Nro = table.Column<string>(nullable: true),
                    XCpl = table.Column<string>(nullable: true),
                    XBairro = table.Column<string>(nullable: true),
                    CMun = table.Column<string>(nullable: true),
                    XMun = table.Column<string>(nullable: true),
                    Uf = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    NFeEmiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_end_emitente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_end_emitente_tb_nfe_emitente_NFeEmiId",
                        column: x => x.NFeEmiId,
                        principalTable: "tb_nfe_emitente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_detalhe_pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndPag = table.Column<string>(nullable: true),
                    TPag = table.Column<string>(nullable: true),
                    VPag = table.Column<string>(nullable: true),
                    TpIntegra = table.Column<string>(nullable: true),
                    NFePagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_detalhe_pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_detalhe_pagamento_tb_nfe_pagamento_NFePagId",
                        column: x => x.NFePagId,
                        principalTable: "tb_nfe_pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_imp_cofins_aliq",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cst = table.Column<string>(nullable: true),
                    VBc = table.Column<string>(nullable: true),
                    PCofins = table.Column<string>(nullable: true),
                    VCofins = table.Column<string>(nullable: true),
                    NFeImpCofinsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_imp_cofins_aliq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_imp_cofins_aliq_tb_nfe_imp_cofins_NFeImpCofinsId",
                        column: x => x.NFeImpCofinsId,
                        principalTable: "tb_nfe_imp_cofins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_imp_cofins_nt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cst = table.Column<string>(nullable: true),
                    NFeImpCofinsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_imp_cofins_nt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_imp_cofins_nt_tb_nfe_imp_cofins_NFeImpCofinsId",
                        column: x => x.NFeImpCofinsId,
                        principalTable: "tb_nfe_imp_cofins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_imp_pis_aliq",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cst = table.Column<string>(nullable: true),
                    VBc = table.Column<string>(nullable: true),
                    PPis = table.Column<string>(nullable: true),
                    VPis = table.Column<string>(nullable: true),
                    NFeImpPisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_imp_pis_aliq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_imp_pis_aliq_tb_nfe_imp_pis_NFeImpPisId",
                        column: x => x.NFeImpPisId,
                        principalTable: "tb_nfe_imp_pis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nfe_imp_pis_nt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cst = table.Column<string>(nullable: true),
                    NFeImpPisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nfe_imp_pis_nt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_nfe_imp_pis_nt_tb_nfe_imp_pis_NFeImpPisId",
                        column: x => x.NFeImpPisId,
                        principalTable: "tb_nfe_imp_pis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_det_item_NotaFiscalId",
                table: "tb_nfe_det_item",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_detalhe_pagamento_NFePagId",
                table: "tb_nfe_detalhe_pagamento",
                column: "NFePagId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_emitente_NotaFiscalId",
                table: "tb_nfe_emitente",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_end_emitente_NFeEmiId",
                table: "tb_nfe_end_emitente",
                column: "NFeEmiId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_ide_NotaFiscalId",
                table: "tb_nfe_ide",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_imp_cofins_NFeDetItemId",
                table: "tb_nfe_imp_cofins",
                column: "NFeDetItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_imp_cofins_aliq_NFeImpCofinsId",
                table: "tb_nfe_imp_cofins_aliq",
                column: "NFeImpCofinsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_imp_cofins_nt_NFeImpCofinsId",
                table: "tb_nfe_imp_cofins_nt",
                column: "NFeImpCofinsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_imp_icms_NFeDetItemId",
                table: "tb_nfe_imp_icms",
                column: "NFeDetItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_imp_pis_NFeDetItemId",
                table: "tb_nfe_imp_pis",
                column: "NFeDetItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_imp_pis_aliq_NFeImpPisId",
                table: "tb_nfe_imp_pis_aliq",
                column: "NFeImpPisId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_imp_pis_nt_NFeImpPisId",
                table: "tb_nfe_imp_pis_nt",
                column: "NFeImpPisId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_inf_adicional_NotaFiscalId",
                table: "tb_nfe_inf_adicional",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_inf_suplementar_NotaFiscalId",
                table: "tb_nfe_inf_suplementar",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_pagamento_NotaFiscalId",
                table: "tb_nfe_pagamento",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_protocolo_nfe_NotaFiscalId",
                table: "tb_nfe_protocolo_nfe",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_signature_NotaFiscalId",
                table: "tb_nfe_signature",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_total_icms_NotaFiscalId",
                table: "tb_nfe_total_icms",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nfe_transportadora_NotaFiscalId",
                table: "tb_nfe_transportadora",
                column: "NotaFiscalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_nfe_detalhe_pagamento");

            migrationBuilder.DropTable(
                name: "tb_nfe_end_emitente");

            migrationBuilder.DropTable(
                name: "tb_nfe_ide");

            migrationBuilder.DropTable(
                name: "tb_nfe_imp_cofins_aliq");

            migrationBuilder.DropTable(
                name: "tb_nfe_imp_cofins_nt");

            migrationBuilder.DropTable(
                name: "tb_nfe_imp_icms");

            migrationBuilder.DropTable(
                name: "tb_nfe_imp_pis_aliq");

            migrationBuilder.DropTable(
                name: "tb_nfe_imp_pis_nt");

            migrationBuilder.DropTable(
                name: "tb_nfe_inf_adicional");

            migrationBuilder.DropTable(
                name: "tb_nfe_inf_suplementar");

            migrationBuilder.DropTable(
                name: "tb_nfe_protocolo_nfe");

            migrationBuilder.DropTable(
                name: "tb_nfe_signature");

            migrationBuilder.DropTable(
                name: "tb_nfe_total_icms");

            migrationBuilder.DropTable(
                name: "tb_nfe_transportadora");

            migrationBuilder.DropTable(
                name: "tb_nfe_pagamento");

            migrationBuilder.DropTable(
                name: "tb_nfe_emitente");

            migrationBuilder.DropTable(
                name: "tb_nfe_imp_cofins");

            migrationBuilder.DropTable(
                name: "tb_nfe_imp_pis");

            migrationBuilder.DropTable(
                name: "tb_nfe_det_item");

            migrationBuilder.DropTable(
                name: "tb_nota_fiscal");
        }
    }
}
