using entity.sql.importacao.Models;
using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using repository.importacao.repository;
using System.Linq;
using System.IO;
using biblioteca.importacao;

namespace leitura.nfe.importacao
{
    public class Exportar : IDisposable
    {
        private bool disposedValue;
        private EFContext _context;
        private NotaFiscal objNotaFiscal;
        private NFeIde objNFeIde;
        private NFeEmi objNFeEmi;
        private NFeEndEmi objNFeEndEmi;
        private List<NFeDetItem> listNFeDetItem;
        private NFeImpIcms objNFeImpIcms;
        private NFeImpPis objNFeImpPis;
        private NFeImpPisAliq objNFeImpPisAliq;
        private NFeImpPisNt objNFeImpPisNt;
        private NFeImpCofins objNFeImpCofins;
        private NFeImpCofinsAliq objNFeImpCofinsAliq;
        private NFeImpCofinsNt objNFeImpCofinsNt;
        private NFeTotalIcms objNFeTotalIcms;
        private NFeInfAdic objNFeInfAdic;
        private NFeInfSupl objNFeInfSupl;
        private NFeSignature objNFeSignature;
        private NFeProtNfe objNFeProtNfe;
        private NFeTransp objNFeTransp;
        private NFePag objNFePag;
        private NFeDetPag objNFeDetPag;

        public Exportar(EFContext context)
        {
            _context = context;
        }

        public string ObterXmlNFe(int id)
        {
            string arquivo = $"{Path.GetTempPath()}xml.xml";
            try
            {
               
                using (NFeProtNfeRepositorio dbNFeProtNfe = new NFeProtNfeRepositorio(_context))
                using (NFeSignatureRepositorio dbNFeSignature = new NFeSignatureRepositorio(_context))
                using (NFeDetPagRepositorio dbNFeDetPag = new NFeDetPagRepositorio(_context))
                using (NFePagRepositorio dbNFePag = new NFePagRepositorio(_context))
                using (NFeIdeRepositorio dbNFeIde = new NFeIdeRepositorio(_context))
                using (NFeEmiRepositorio dbNFeEmi = new NFeEmiRepositorio(_context))
                using (NFeInfAdicRepositorio dbNFeInfAdic = new NFeInfAdicRepositorio(_context))
                using (NFeInfSuplRepositorio dbNFeInfSupl = new NFeInfSuplRepositorio(_context))
                using (NFeTranspRepositorio dbNFeTransp = new NFeTranspRepositorio(_context))
                using (NFeEndEmiRepositorio dbNFeEndEmi = new NFeEndEmiRepositorio(_context))
                using (NFeDetItemRepositorio dbNFeDetItem = new NFeDetItemRepositorio(_context))
                using (NFeImpIcmsRepositorio dbNFeImpIcms = new NFeImpIcmsRepositorio(_context))
                using (NFeImpPisRepositorio dbNFeImpPis = new NFeImpPisRepositorio(_context))
                using (NFeImpPisAliqRepositorio dbNFeImpPisAliq = new NFeImpPisAliqRepositorio(_context))
                using (NFeImpPisNtRepositorio dbNFeImpPisNt = new NFeImpPisNtRepositorio(_context))
                using (NFeImpCofinsRepositorio dbNFeImpCofins = new NFeImpCofinsRepositorio(_context))
                using (NFeImpCofinsAliqRepositorio dbNFeImpCofinsAliq = new NFeImpCofinsAliqRepositorio(_context))
                using (NFeImpCofinsNtRepositorio dbNFeImpCofinsNt = new NFeImpCofinsNtRepositorio(_context))
                using (NFeTotalIcmsRepositorio dbNFeTotalIcms = new NFeTotalIcmsRepositorio(_context))
                using (NotaFiscalRepositorio dbNFe = new NotaFiscalRepositorio(_context))
                {
                    objNotaFiscal = dbNFe.GetById(id);
                    objNFeIde = dbNFeIde.GetById(id);
                    objNFeEmi = dbNFeEmi.GetById(id);
                    objNFeEndEmi = dbNFeEndEmi.GetById(objNFeEmi.Id);
                    objNFeTotalIcms = dbNFeTotalIcms.GetById(id);
                    objNFeTransp = dbNFeTransp.GetById(id);
                    objNFePag = dbNFePag.GetById(id);
                    objNFeDetPag = dbNFeDetPag.GetById(objNFePag.Id);
                    objNFeInfAdic = dbNFeInfAdic.GetById(id);
                    objNFeInfSupl = dbNFeInfSupl.GetById(id);
                    objNFeSignature = dbNFeSignature.GetById(id);
                    objNFeProtNfe = dbNFeProtNfe.GetById(id);
                    listNFeDetItem = dbNFeDetItem.GetAllItems(objNotaFiscal.Id).ToList();

                   

                    UTF8Encoding utf = new UTF8Encoding();
                    XmlTextWriter textWriter = new XmlTextWriter(arquivo, utf);

                    textWriter.WriteStartDocument();

                    #region .: Tag nfeProc :.

                    textWriter.WriteStartElement("nfeProc");//nfeProc

                    textWriter.WriteStartAttribute("xmlns");
                    textWriter.WriteString("http://www.portalfiscal.inf.br/nfe");
                    textWriter.WriteEndAttribute();

                    textWriter.WriteStartAttribute("versao");
                    textWriter.WriteString(objNotaFiscal.Versao);
                    textWriter.WriteEndAttribute();

                    #region .: Tag NFe :.

                    textWriter.WriteStartElement("Nfe", "http://www.portalfiscal.inf.br/nfe");

                    #region .: Tag InfNFe :.

                    textWriter.WriteStartElement("infNFe");//infNFe

                    textWriter.WriteStartAttribute("Id");
                    textWriter.WriteString(objNotaFiscal.InfNfe);
                    textWriter.WriteEndAttribute();

                    textWriter.WriteStartAttribute("versao");
                    textWriter.WriteString(objNotaFiscal.Versao);
                    textWriter.WriteEndAttribute();

                    #region .: Tag ide :.

                    textWriter.WriteStartElement("ide");//ide

                    textWriter.WriteStartElement("cUF");
                    textWriter.WriteString(objNFeIde.CUf);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("cNF");
                    textWriter.WriteString(objNFeIde.CNf);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("natOp");
                    textWriter.WriteString(objNFeIde.NatOp);
                    // Natureza da Operação
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("mod");
                    textWriter.WriteString(objNFeIde.Mod);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("serie");
                    textWriter.WriteString(objNFeIde.Serie);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("nNF");
                    textWriter.WriteString(objNFeIde.NNf);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("dEmi");
                    textWriter.WriteString(objNFeIde.DhEmi);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("tpNF");
                    textWriter.WriteString(objNFeIde.TpNf);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("idDest");
                    textWriter.WriteString(objNFeIde.IdDest);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("cMunFG");
                    textWriter.WriteString(objNFeIde.CMunFg);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("tpImp");
                    textWriter.WriteString(objNFeIde.TpImp);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("tpEmis");
                    textWriter.WriteString(objNFeIde.TpEmis);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("cDV");
                    textWriter.WriteString(objNFeIde.CDv);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("tpAmb");
                    textWriter.WriteString(objNFeIde.TpAmb);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("finNFe");
                    textWriter.WriteString(objNFeIde.FinNfe);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("indFinal");
                    textWriter.WriteString(objNFeIde.IndFinal);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("indPres");
                    textWriter.WriteString(objNFeIde.IndPres);
                    textWriter.WriteEndElement();


                    textWriter.WriteStartElement("procEmi");
                    textWriter.WriteString(objNFeIde.ProcEmi);
                    textWriter.WriteEndElement();


                    textWriter.WriteStartElement("verProc");
                    textWriter.WriteString(objNFeIde.VerProc);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//ide

                    #endregion

                    #region .: Tag Emit :.

                    textWriter.WriteStartElement("emit");

                    textWriter.WriteStartElement("CNPJ");
                    textWriter.WriteString(objNFeEmi.Cnpj);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("xNome");
                    textWriter.WriteString(objNFeEmi.XNome);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("xFant");
                    textWriter.WriteString(objNFeEmi.XFant);
                    textWriter.WriteEndElement();

                    #region .: Tag EndEmit :.

                    textWriter.WriteStartElement("enderEmit");

                    textWriter.WriteStartElement("xLgr");
                    textWriter.WriteString(objNFeEndEmi.XLgr);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("nro");
                    textWriter.WriteString(objNFeEndEmi.Nro);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("xCpl");
                    textWriter.WriteString(objNFeEndEmi.XCpl);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("xBairro");
                    textWriter.WriteString(objNFeEndEmi.XBairro);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("cMun");
                    textWriter.WriteString(objNFeEndEmi.CMun);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("xMun");
                    textWriter.WriteString(objNFeEndEmi.XMun);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("UF");
                    textWriter.WriteString(objNFeEndEmi.Uf);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("CEP");
                    textWriter.WriteString(objNFeEndEmi.Cep);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//enderEmit

                    #endregion

                    textWriter.WriteStartElement("IE");
                    textWriter.WriteString(objNFeEmi.Ie);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("CRT");
                    textWriter.WriteString(objNFeEmi.Crt);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//emit

                    #endregion

                    #region .: Tag Det Item :.

                    int incrementoProd = 1;

                    foreach (var item in listNFeDetItem)
                    {
                        objNFeImpIcms = dbNFeImpIcms.GetById(item.Id);

                        objNFeImpPis = dbNFeImpPis.GetById(item.Id);
                        objNFeImpPisAliq = dbNFeImpPisAliq.GetById(objNFeImpPis.Id);
                        objNFeImpPisNt = dbNFeImpPisNt.GetById(objNFeImpPis.Id);

                        objNFeImpCofins = dbNFeImpCofins.GetById(item.Id);
                        objNFeImpCofinsAliq = dbNFeImpCofinsAliq.GetById(objNFeImpPis.Id);
                        objNFeImpCofinsNt = dbNFeImpCofinsNt.GetById(objNFeImpPis.Id);

                        #region .: Tag Det :.

                        textWriter.WriteStartElement("det");

                        textWriter.WriteStartAttribute("nItem");//Atributos do Nó
                        textWriter.WriteString(incrementoProd.ToString());
                        textWriter.WriteEndAttribute();// finalizando o atributo

                        #region .: Tag Prod :.

                        textWriter.WriteStartElement("prod");

                        textWriter.WriteStartElement("cProd");
                        textWriter.WriteString(item.CProd);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("cEAN");
                        textWriter.WriteString(item.CEan);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("xProd");
                        textWriter.WriteString(item.XProd);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("NCM");
                        textWriter.WriteString(item.Ncm);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("CEST");
                        textWriter.WriteString(item.Cest);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("indEscala");
                        textWriter.WriteString(item.IndEscala);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("CFOP");
                        textWriter.WriteString(item.Cfop);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("uCom");
                        textWriter.WriteString(item.UCom);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("qCom");
                        textWriter.WriteString(item.QCom);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("vUnCom");
                        textWriter.WriteString(item.VUnCom);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("vProd");
                        textWriter.WriteString(item.VProd);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("cEANTrib");
                        textWriter.WriteString(item.CEantrib);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("uTrib");
                        textWriter.WriteString(item.UTrib);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("qTrib");
                        textWriter.WriteString(item.QTrib);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("vUnTrib");
                        textWriter.WriteString(item.VUnTrib);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("indTot");
                        textWriter.WriteString(item.IndTot);
                        textWriter.WriteEndElement();

                        textWriter.WriteEndElement();

                        #endregion

                        #region .: Tag Imposto :.

                        textWriter.WriteStartElement("imposto");

                        textWriter.WriteStartElement("vTotTrib");
                        textWriter.WriteString(item.VTotTrib);
                        textWriter.WriteEndElement();

                        #region .: Tag ICMS :.

                        textWriter.WriteStartElement("ICMS");

                        textWriter.WriteStartElement("ICMSSN102");

                        textWriter.WriteStartElement("orig");
                        textWriter.WriteString(objNFeImpIcms.Orig);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("CSOSN");
                        textWriter.WriteString(objNFeImpIcms.Csosn);
                        textWriter.WriteEndElement();

                        textWriter.WriteEndElement();//ICMSSN102

                        textWriter.WriteEndElement();//ICMS

                        #endregion

                        #region.: Tag PIS :.

                        textWriter.WriteStartElement("PIS");

                        if (objNFeImpPisNt != null)
                        {
                            textWriter.WriteStartElement("PISNT");

                            textWriter.WriteStartElement("CST");
                            textWriter.WriteString(objNFeImpPisNt.Cst);
                            textWriter.WriteEndElement();

                            textWriter.WriteEndElement();//PISNT
                        }
                        else if (objNFeImpPisAliq != null)
                        {
                            textWriter.WriteStartElement("PISAliq");

                            textWriter.WriteStartElement("CST");
                            textWriter.WriteString(objNFeImpPisAliq.Cst);
                            textWriter.WriteEndElement();

                            textWriter.WriteStartElement("vBC");
                            textWriter.WriteString(objNFeImpPisAliq.VBc);
                            textWriter.WriteEndElement();

                            textWriter.WriteStartElement("pPIS");
                            textWriter.WriteString(objNFeImpPisAliq.PPis);
                            textWriter.WriteEndElement();

                            textWriter.WriteStartElement("vPIS");
                            textWriter.WriteString(objNFeImpPisAliq.VPis);
                            textWriter.WriteEndElement();

                            textWriter.WriteEndElement();//PISAliq
                        }

                        textWriter.WriteEndElement();//PIS

                        #endregion

                        #region.: Tag COFINS :.

                        textWriter.WriteStartElement("COFINS");

                        if (objNFeImpCofinsNt != null)
                        {
                            textWriter.WriteStartElement("COFINSNT");

                            textWriter.WriteStartElement("CST");
                            textWriter.WriteString(objNFeImpCofinsNt.Cst);
                            textWriter.WriteEndElement();

                            textWriter.WriteEndElement();//COFINSNT
                        }
                        else if (objNFeImpCofinsAliq != null)
                        {
                            textWriter.WriteStartElement("COFINSAliq");

                            textWriter.WriteStartElement("CST");
                            textWriter.WriteString(objNFeImpCofinsAliq.Cst);
                            textWriter.WriteEndElement();

                            textWriter.WriteStartElement("vBC");
                            textWriter.WriteString(objNFeImpCofinsAliq.VBc);
                            textWriter.WriteEndElement();

                            textWriter.WriteStartElement("pCOFINS");
                            textWriter.WriteString(objNFeImpCofinsAliq.PCofins);
                            textWriter.WriteEndElement();

                            textWriter.WriteStartElement("vCOFINS");
                            textWriter.WriteString(objNFeImpCofinsAliq.VCofins);
                            textWriter.WriteEndElement();

                            textWriter.WriteEndElement();//COFINSAliq
                        }

                        textWriter.WriteEndElement();//PIS

                        #endregion

                        textWriter.WriteEndElement();//imposto

                        #endregion

                        textWriter.WriteEndElement();//det

                        #endregion

                        incrementoProd++;
                    }

                    #endregion

                    #region .: Tag Total :.

                    textWriter.WriteStartElement("total");//total

                    #region .: Tag Icms Total :.

                    textWriter.WriteStartElement("ICMSTot");//ICMSTot

                    textWriter.WriteStartElement("vBC");
                    textWriter.WriteString(objNFeTotalIcms.VBc);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vICMS");
                    textWriter.WriteString(objNFeTotalIcms.VIcms);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vICMSDeson");
                    textWriter.WriteString(objNFeTotalIcms.VIcmsdeson);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vFCP");
                    textWriter.WriteString(objNFeTotalIcms.VFcp);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vBCST");
                    textWriter.WriteString(objNFeTotalIcms.VBcst);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vST");
                    textWriter.WriteString(objNFeTotalIcms.VSt);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vFCPST");
                    textWriter.WriteString(objNFeTotalIcms.VFcpst);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vFCPSTRet");
                    textWriter.WriteString(objNFeTotalIcms.VFcpstret);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vProd");
                    textWriter.WriteString(objNFeTotalIcms.VProd);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vFrete");
                    textWriter.WriteString(objNFeTotalIcms.VFrete);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vSeg");
                    textWriter.WriteString(objNFeTotalIcms.VSeg);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vDesc");
                    textWriter.WriteString(objNFeTotalIcms.VDesc);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vII");
                    textWriter.WriteString(objNFeTotalIcms.VIi);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vIPI");
                    textWriter.WriteString(objNFeTotalIcms.VIpi);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vIPIDevol");
                    textWriter.WriteString(objNFeTotalIcms.VIpidevol);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vPIS");
                    textWriter.WriteString(objNFeTotalIcms.VPis);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vCOFINS");
                    textWriter.WriteString(objNFeTotalIcms.VCofins);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vOutro");
                    textWriter.WriteString(objNFeTotalIcms.VOutro);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vNF");
                    textWriter.WriteString(objNFeTotalIcms.VNf);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vTotTrib");
                    textWriter.WriteString(objNFeTotalIcms.VTotTrib);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//ICMSTot

                    #endregion

                    textWriter.WriteEndElement();//total

                    #endregion

                    #region .: Tag Transp :.

                    textWriter.WriteStartElement("transp");

                    textWriter.WriteStartElement("modFrete");
                    textWriter.WriteString(objNFeTransp.modFrete);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//transp

                    #endregion

                    #region .: Tag pag :.

                    textWriter.WriteStartElement("pag");

                    textWriter.WriteStartElement("detPag");

                    textWriter.WriteStartElement("indPag");
                    textWriter.WriteString(objNFeDetPag.IndPag);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("tPag");
                    textWriter.WriteString(objNFeDetPag.TPag);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("vPag");
                    textWriter.WriteString(objNFeDetPag.VPag);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("card");

                    textWriter.WriteStartElement("tpIntegra");
                    textWriter.WriteString(objNFeDetPag.TpIntegra);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//detPag

                    textWriter.WriteStartElement("vTroco");
                    textWriter.WriteString(objNFePag.VTroco);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//pag

                    #endregion

                    #region .: Tag InfAdic :.

                    textWriter.WriteStartElement("infAdic");

                    textWriter.WriteStartElement("infAdFisco");
                    textWriter.WriteString(objNFeInfAdic.InfAdFisco);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("infCpl");
                    textWriter.WriteString(objNFeInfAdic.InfCpl);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//infAdic

                    #endregion


                    textWriter.WriteEndElement();//InfNFE

                    #endregion

                    #region .: Tag InfNFeSupl :.

                    textWriter.WriteStartElement("infNFeSupl");//infNFeSupl

                    textWriter.WriteStartElement("qrCode");
                    textWriter.WriteString(objNFeInfSupl.QrCode);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("urlChave");
                    textWriter.WriteString(objNFeInfSupl.UrlChave);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//infNFeSupl
                    #endregion

                    #region .: Tag Signature :.

                    textWriter.WriteStartElement("Signature");//Signature

                    textWriter.WriteStartAttribute("xmlns");
                    textWriter.WriteString("http://www.w3.org/2000/09/xmldsig#");
                    textWriter.WriteEndAttribute();

                    #region .: Tag SignedInfo :.

                    textWriter.WriteStartElement("SignedInfo");//SignedInfo

                    textWriter.WriteStartElement("CanonicalizationMethod");//CanonicalizationMethod
                    textWriter.WriteStartAttribute("Algorithm");
                    textWriter.WriteString(objNFeSignature.CanonicalizationMethod);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();//CanonicalizationMethod

                    textWriter.WriteStartElement("SignatureMethod");//SignatureMethod
                    textWriter.WriteStartAttribute("Algorithm");
                    textWriter.WriteString(objNFeSignature.SignatureMethod);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();//SignatureMethod

                    textWriter.WriteStartElement("Reference");//Reference
                    textWriter.WriteStartAttribute("URI");
                    textWriter.WriteString(objNFeSignature.Reference);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();//Reference

                    #region .: Tag Transforms :.

                    textWriter.WriteStartElement("Transforms");//Transforms

                    textWriter.WriteStartElement("Transform");//Transform
                    textWriter.WriteStartAttribute("Algorithm");
                    textWriter.WriteString(objNFeSignature.Transform1);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();//Transform

                    textWriter.WriteStartElement("Transform");//Transform
                    textWriter.WriteStartAttribute("Algorithm");
                    textWriter.WriteString(objNFeSignature.Transform2);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();//Transform

                    textWriter.WriteEndElement();//Transforms

                    #endregion

                    textWriter.WriteStartElement("DigestMethod");//DigestMethod
                    textWriter.WriteStartAttribute("Algorithm");
                    textWriter.WriteString(objNFeSignature.DigestMethod);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();//DigestMethod

                    textWriter.WriteStartElement("DigestValue");//DigestValue
                    textWriter.WriteStartAttribute("Algorithm");
                    textWriter.WriteString(objNFeSignature.DigestValue);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();//DigestMethod

                    textWriter.WriteEndElement();//SignedInfo

                    #endregion

                    textWriter.WriteStartElement("SignatureValue");//SignatureValue
                    textWriter.WriteString(objNFeSignature.SignatureValue);
                    textWriter.WriteEndElement();//SignatureValue

                    #region .: Tag KeyInfo :.

                    textWriter.WriteStartElement("KeyInfo");//KeyInfo

                    textWriter.WriteStartElement("X509Data");//X509Data

                    textWriter.WriteStartElement("X509Certificate");//X509Certificate
                    textWriter.WriteString(objNFeSignature.X509certificate);
                    textWriter.WriteEndElement();//X509Certificate

                    textWriter.WriteEndElement();//X509Data

                    textWriter.WriteEndElement();//KeyInfo

                    #endregion

                    textWriter.WriteEndElement();//Signature

                    #endregion

                    textWriter.WriteEndElement();//Nfe
                    #endregion

                    #region .: Tag protNFe :.

                    textWriter.WriteStartElement("protNFe");//protNFe

                    textWriter.WriteStartAttribute("versao");
                    textWriter.WriteString(objNotaFiscal.Versao);
                    textWriter.WriteEndAttribute();

                    textWriter.WriteStartElement("infProt");//infProt


                    textWriter.WriteStartElement("tpAmb");
                    textWriter.WriteString(objNFeProtNfe.TpAmb);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("verAplic");
                    textWriter.WriteString(objNFeProtNfe.VerAplic);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("chNFe");
                    textWriter.WriteString(objNFeProtNfe.ChNfe);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("dhRecbto");
                    textWriter.WriteString(objNFeProtNfe.DhRecbto);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("nProt");
                    textWriter.WriteString(objNFeProtNfe.NProt);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("digVal");
                    textWriter.WriteString(objNFeProtNfe.DigVal);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("cStat");
                    textWriter.WriteString(objNFeProtNfe.CStat);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("xMotivo");
                    textWriter.WriteString(objNFeProtNfe.XMotivo);
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();//infProt


                    textWriter.WriteEndElement();//protNFe
                    #endregion

                    textWriter.WriteEndElement();//nfeProc

                    #endregion

                    textWriter.Close();
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(arquivo);

                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                doc.WriteTo(xw);

                return  Xml.IdentXML(sw.ToString());

            }
            catch (Exception e)
            {
                return $"<xml>Erro: {e.Message} </xml>";
            }

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
        ~Exportar()
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
