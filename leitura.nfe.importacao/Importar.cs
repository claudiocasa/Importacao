using biblioteca.importacao;
using entity.sql.importacao.Models;
using repository.importacao.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leitura.nfe.importacao
{
    public class Importar : IDisposable
    {
        private bool disposedValue;
        private EFContext _context;
        public int IdNfe = 0;
        public Importar(EFContext context)
        {
            _context = context;
        }

        public bool Gravar(string caminho)
        {
            try
            {

                var objNota = Xml.LerArquivoXml<nfeProc>(new nfeProc(), caminho);

                var objNFe = objNota.NFe.infNFe;
                var objIde = objNFe.ide;
                var objEmit = objNFe.emit;
                var objEndEmi = objNFe.emit.enderEmit;
                var objTotalIcms = objNFe.total;
                var objInfAdic = objNota.NFe.infNFe.infAdic;
                var objInfNFeSupl = objNota.NFe.infNFeSupl;
                var objSignature = objNota.NFe.Signature;
                var objProtNfe = objNota.protNFe;
                var objTransp = objNota.NFe.infNFe.transp;
                var objPag = objNota.NFe.infNFe.pag;

                var listDetItem = objNota.NFe.infNFe.det.ToList();

                NotaFiscal objNotaFiscal;
                NFeIde objNFeIde;
                NFeEmi objNFeEmi;
                NFeEndEmi objNFeEndEmi;
                NFeDetItem objNFeDetItem;
                NFeImpPis objNFeImpPis;
                NFeImpCofins objNFeImpCofins;
                NFeTotalIcms objNFeTotalIcms;
                NFeInfAdic objNFeInfAdic;
                NFeInfSupl objNFeInfSupl;
                NFeSignature objNFeSignature;
                NFeProtNfe objNFeProtNfe;
                NFeTransp objNFeTransp;
                NFePag objNFePag;
                NFeDetPag objNFeDetPag;

                #region .: Entidade : NotaFiscal :.

                using (NotaFiscalRepositorio db = new NotaFiscalRepositorio(new EFContext()))
                {

                    objNotaFiscal = db.Add(new NotaFiscal()
                    {
                        InfNfe = objNFe.Id,
                        Versao = objNFe.versao

                    });
                };

                #endregion

                #region .: Entidade : NFeInfAdic :.

                using (NFeInfAdicRepositorio db = new NFeInfAdicRepositorio(new EFContext()))
                {

                    objNFeInfAdic = db.Add(new NFeInfAdic()
                    {
                        InfAdFisco = objInfAdic.infAdFisco,
                        InfCpl = objInfAdic.infCpl,
                        NotaFiscalId = objNotaFiscal.Id
                    });
                }

                #endregion

                #region .: Entidade : NFeInfSupl :.

                using (NFeSuplRepositorio db = new NFeSuplRepositorio(new EFContext()))
                {

                    objNFeInfSupl = db.Add(new NFeInfSupl()
                    {
                        QrCode = objInfNFeSupl.qrCode,
                        UrlChave = objInfNFeSupl.urlChave,
                        NotaFiscalId = objNotaFiscal.Id
                    });
                }

                #endregion

                #region .: Entidade : NFeSignature :.

                using (NFeSignatureRepositorio db = new NFeSignatureRepositorio(new EFContext()))
                {

                    objNFeSignature = db.Add(new NFeSignature()
                    {
                        CanonicalizationMethod = objSignature.SignedInfo.CanonicalizationMethod.Algorithm,
                        SignatureMethod = objSignature.SignedInfo.SignatureMethod.Algorithm,
                        DigestMethod = objSignature.SignedInfo.Reference.DigestMethod.Algorithm,
                        DigestValue = objSignature.SignedInfo.Reference.DigestValue,
                        SignatureValue = objSignature.SignatureValue,
                        Transform1 = objSignature.SignedInfo.Reference.Transforms[0].Algorithm,
                        Transform2 = objSignature.SignedInfo.Reference.Transforms[1].Algorithm,
                        X509certificate = objSignature.KeyInfo.X509Data.X509Certificate,
                        Reference = objSignature.SignedInfo.Reference.URI,
                        NotaFiscalId = objNotaFiscal.Id
                    });
                }

                #endregion

                #region .: Entidade : NFeProtNfe :.

                using (NFeProtNfeRepositorio db = new NFeProtNfeRepositorio(new EFContext()))
                {

                    objNFeProtNfe = db.Add(new NFeProtNfe()
                    {
                        ChNfe = objProtNfe.infProt.chNFe,
                        CStat = objProtNfe.infProt.cStat,
                        DhRecbto = objProtNfe.infProt.dhRecbto,
                        DigVal = objProtNfe.infProt.digVal,
                        NProt = objProtNfe.infProt.nProt,
                        TpAmb = objProtNfe.infProt.tpAmb,
                        VerAplic = objProtNfe.infProt.verAplic,
                        XMotivo = objProtNfe.infProt.xMotivo,
                        NotaFiscalId = objNotaFiscal.Id
                    });
                }

                #endregion

                #region .: Entidade : NFeTransp :.

                using (NFeTranspRepositorio db = new NFeTranspRepositorio(new EFContext()))
                {

                    objNFeTransp = db.Add(new NFeTransp()
                    {
                        modFrete = objTransp.modFrete,
                        NotaFiscalId = objNotaFiscal.Id
                    });
                }

                #endregion

                #region .: Entidade : NFePag :.

                using (NFePagRepositorio db = new NFePagRepositorio(new EFContext()))
                {

                    objNFePag = db.Add(new NFePag()
                    {
                        VTroco = objPag.vTroco,
                        NotaFiscalId = objNotaFiscal.Id
                    });
                }

                #endregion

                #region .: Entidade : NFeDetPag :.

                using (NFeDetPagRepositorio db = new NFeDetPagRepositorio(new EFContext()))
                {

                    objNFeDetPag = db.Add(new NFeDetPag()
                    {
                        TPag = objPag.detPag.tPag,
                        TpIntegra = objPag.detPag.card.tpIntegra,
                        VPag = objPag.detPag.vPag,
                        IndPag = objPag.detPag.indPag,
                        NFePagId = objNFePag.Id
                    });
                }

                #endregion

                #region .: Entidade : NFeIde :.

                using (NFeIdeRepositorio db = new NFeIdeRepositorio(new EFContext()))
                {

                    objNFeIde = db.Add(new NFeIde()
                    {
                        CUf = objIde.cUF,
                        CNf = objIde.cNF,
                        NatOp = objIde.natOp,
                        Mod = objIde.mod,
                        Serie = objIde.serie,
                        CDv = objIde.cDV,
                        ProcEmi = objIde.procEmi,
                        TpAmb = objIde.tpAmb,
                        TpEmis = objIde.tpEmis,
                        CMunFg = objIde.cMunFG,
                        DhEmi = objIde.dhEmi,
                        FinNfe = objIde.finNFe,
                        IdDest = objIde.idDest,
                        IndFinal = objIde.indFinal,
                        IndPres = objIde.indPres,
                        NNf = objIde.nNF,
                        VerProc = objIde.verProc,
                        TpNf = objIde.tpNF,
                        TpImp = objIde.tpImp,
                        NotaFiscalId = objNotaFiscal.Id
                    });
                }

                #endregion

                #region .: Entidade : NFeEmi :.

                using (NFeEmiRepositorio db = new NFeEmiRepositorio(new EFContext()))
                {

                    objNFeEmi = db.Add(new NFeEmi()
                    {
                        Cnpj = objEmit.CNPJ,
                        Crt = objEmit.CRT,
                        Ie = objEmit.IE,
                        XFant = objEmit.xFant,
                        XNome = objEmit.xNome,
                        NotaFiscalId = objNotaFiscal.Id

                    });
                };

                #endregion

                #region .: Entidade : NFeEndEmi :.

                using (NFeEndEmiRepositorio db = new NFeEndEmiRepositorio(new EFContext()))
                {
                    objNFeEndEmi = db.Add(new NFeEndEmi()
                    {
                        Cep = objEndEmi.CEP,
                        CMun = objEndEmi.cMun,
                        Nro = objEndEmi.nro,
                        Uf = objEndEmi.UF,
                        XBairro = objEndEmi.xBairro,
                        XCpl = objEndEmi.xCpl,
                        XLgr = objEndEmi.xLgr,
                        XMun = objEndEmi.xMun,
                        NFeEmiId = objNFeEmi.Id
                    });
                };

                #endregion

                #region .: Entidade : NFeDetItem :.

                using (NFeDetItemRepositorio db = new NFeDetItemRepositorio(new EFContext()))
                {
                    foreach (var item in listDetItem)
                    {
                        var objIcms = item.imposto.ICMS.ICMSSN102;
                        var objPis = item.imposto.PIS.PISAliq;
                        var objCofins = item.imposto.COFINS.COFINSAliq;

                        objNFeDetItem = db.Add(new NFeDetItem()
                        {
                            CEan = item.prod.cEAN,
                            CEantrib = item.prod.cEANTrib,
                            Cest = item.prod.CEST,
                            Cfop = item.prod.CFOP,
                            CProd = item.prod.cProd,
                            Ncm = item.prod.NCM,
                            IndEscala = item.prod.indEscala,
                            IndTot = item.prod.indTot,
                            QCom = item.prod.qCom,
                            QTrib = item.prod.qTrib,
                            UCom = item.prod.uCom,
                            UTrib = item.prod.uTrib,
                            VProd = item.prod.vProd,
                            VUnTrib = item.prod.vUnTrib,
                            VUnCom = item.prod.vUnCom,
                            XProd = item.prod.xProd,
                            VTotTrib = item.imposto.vTotTrib,
                            NotaFiscalId = objNotaFiscal.Id
                        });

                        #region .: Entidade : NFeImpIcms :.

                        using (NFeImpIcmsRepositorio db2 = new NFeImpIcmsRepositorio(new EFContext()))
                        {
                            db2.Add(new NFeImpIcms()
                            {
                                Csosn = objIcms.CSOSN,
                                Orig = objIcms.orig,
                                NFeDetItemId = objNFeDetItem.Id
                            });

                        }

                        #endregion

                        #region .: Entidade : NFeImpPis :.

                        using (NFeImpPisRepositorio db2 = new NFeImpPisRepositorio(new EFContext()))
                        {
                            objNFeImpPis = db2.Add(new NFeImpPis()
                            {
                                NFeDetItemId = objNFeDetItem.Id
                            });

                        }

                        #endregion

                        if (item.imposto.PIS.PISAliq != null)
                        {
                            #region .: Entidade : NFeImpPisAliq :.

                            using (NFeImpPisAliqRepositorio db2 = new NFeImpPisAliqRepositorio(new EFContext()))
                            {
                                db2.Add(new NFeImpPisAliq()
                                {
                                    Cst = objPis.CST,
                                    PPis = objPis.pPIS,
                                    VBc = objPis.vBC,
                                    VPis = objPis.vPIS,
                                    NFeImpPisId = objNFeImpPis.Id
                                });

                            }

                            #endregion
                        }

                        if (item.imposto.PIS.PISNT != null)
                        {
                            #region .: Entidade : NFeImpPisNt :.

                            using (NFeImpPisNtRepositorio db2 = new NFeImpPisNtRepositorio(new EFContext()))
                            {
                                db2.Add(new NFeImpPisNt()
                                {
                                    Cst = item.imposto.PIS.PISNT.CST,
                                    NFeImpPisId = objNFeImpPis.Id
                                });

                            }

                            #endregion
                        }

                        #region .: Entidade : NFeImpCofins :.

                        using (NFeImpCofinsRepositorio db2 = new NFeImpCofinsRepositorio(new EFContext()))
                        {
                            objNFeImpCofins = db2.Add(new NFeImpCofins()
                            {
                                NFeDetItemId = objNFeDetItem.Id
                            });
                        }

                        #endregion

                        if (item.imposto.COFINS.COFINSAliq != null)
                        {
                            #region .: Entidade : NFeImpCofinsAliq :.

                            using (NFeImpCofinsAliqRepositorio db2 = new NFeImpCofinsAliqRepositorio(new EFContext()))
                            {
                                db2.Add(new NFeImpCofinsAliq()
                                {
                                    Cst = objCofins.CST,
                                    VBc = objCofins.vBC,
                                    PCofins = objCofins.pCOFINS,
                                    VCofins = objCofins.vCOFINS,
                                    NFeImpCofinsId = objNFeImpCofins.Id

                                });

                            }

                            #endregion
                        }

                        if (item.imposto.COFINS.COFINSNT != null)
                        {
                            #region .: Entidade : NFeImpCofinsNt :.

                            using (NFeImpCofinsNtRepositorio db2 = new NFeImpCofinsNtRepositorio(new EFContext()))
                            {
                                db2.Add(new NFeImpCofinsNt()
                                {
                                    Cst = item.imposto.COFINS.COFINSNT.CST,
                                    NFeImpCofinsId = objNFeImpCofins.Id
                                });

                            }

                            #endregion
                        }
                    }
                };

                #endregion

                #region .: Entidade : NFeTotalIcms :.

                using (NFeTotalIcmsRepositorio db = new NFeTotalIcmsRepositorio(new EFContext()))
                {
                    objNFeTotalIcms = db.Add(new NFeTotalIcms()
                    {
                        VBc = objTotalIcms.ICMSTot.vBC,
                        VIcms = objTotalIcms.ICMSTot.vICMS,
                        VBcst = objTotalIcms.ICMSTot.vBCST,
                        VCofins = objTotalIcms.ICMSTot.vCOFINS,
                        VDesc = objTotalIcms.ICMSTot.vDesc,
                        VFcp = objTotalIcms.ICMSTot.vFCP,
                        VFcpst = objTotalIcms.ICMSTot.vFCPST,
                        VFcpstret = objTotalIcms.ICMSTot.vFCPSTRet,
                        VFrete = objTotalIcms.ICMSTot.vFrete,
                        VIi = objTotalIcms.ICMSTot.vII,
                        VIcmsdeson = objTotalIcms.ICMSTot.vICMSDeson,
                        VIpi = objTotalIcms.ICMSTot.vIPI,
                        VIpidevol = objTotalIcms.ICMSTot.vIPIDevol,
                        VNf = objTotalIcms.ICMSTot.vNF,
                        VOutro = objTotalIcms.ICMSTot.vOutro,
                        VPis = objTotalIcms.ICMSTot.vPIS,
                        VProd = objTotalIcms.ICMSTot.vProd,
                        VSeg = objTotalIcms.ICMSTot.vSeg,
                        VSt = objTotalIcms.ICMSTot.vST,
                        VTotTrib = objTotalIcms.ICMSTot.vTotTrib,
                        NotaFiscalId = objNotaFiscal.Id
                    });
                };

                #endregion
                
                IdNfe = objNotaFiscal.Id;

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        #region .: Dispose :.

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                }

                // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
                // Tarefa pendente: definir campos grandes como nulos
                disposedValue = true;
            }
        }

        // // Tarefa pendente: substituir o finalizador somente se 'Dispose(bool disposing)' tiver o código para liberar recursos não gerenciados
        ~Importar()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
