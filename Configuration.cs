using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LedGeekBox
{
    public static class Helper
    {
        static bool _init = false;

        public static bool[, ]EmptyMatrix  = new bool[8,8];

        private static void LoadFontCollectionFromResource()
        {
            if (_init)
                return;
            Assembly aAssem = Assembly.GetExecutingAssembly();
            Stream srXmlStream = File.Open(@"Datas.xml", FileMode.Open);// aAssem.GetManifestResourceStream(sResourceName);
            XmlTextReader rxReaderXml = new XmlTextReader(srXmlStream);

            LoadFontCollectionFromXmlReader(rxReaderXml);

            _init = true;

            return;
        }

        public static bool[,] Get(string key)
        {
            LoadFontCollectionFromResource();

            var r = m_fcFontCollection.lstFontList[0].lstSymbolList.First(x => x.sDescription == key);

            return r.bLedOnMatrix;

        }

        private static LedMatrixSymbolFontCollection m_fcFontCollection;

        private static bool LoadFontCollectionFromXmlReader(XmlTextReader p_rxReaderXml)
        {
            LedMatrixSymbolFontCollection lmsfcReturnCollection;
            List<LedMatrixSymbolFont> lstFontList = new List<LedMatrixSymbolFont>();

            //---------------------------------------------------
            // Initialisations

            // Init the reader
            p_rxReaderXml.WhitespaceHandling = WhitespaceHandling.None;

            //---------------------------------------------------
            // Read the file

            // While there is somthing to read
            while (p_rxReaderXml.Read())
            {
                LedMatrixSymbolFont lmsfNewFont;
                string sFontName;
                List<LedMatrixSymbol> lstSymbolList = new List<LedMatrixSymbol>();


                // End of font ?
                if (p_rxReaderXml.Name != "LedMatrixSymbolFont")
                {
                    // Next one
                    continue;
                }

                // New font
                sFontName = p_rxReaderXml.GetAttribute("FontName");

                // Identify the symbols of the font
                while (p_rxReaderXml.Read())
                {
                    uint uiSmbCode = 0;
                    string sDescription;
                    bool[,] bLedOnMatrix;
                    LedMatrixSymbol lmsNewSymbol;
                    List<LedOnLine> lstLedOnLine = new List<LedOnLine>();

                    // End of sybmols ?
                    if (p_rxReaderXml.Name != "LedMatrixSymbol")
                    {
                        // Next one
                        break;
                    }

                    // New symbol
                    uiSmbCode = Convert.ToUInt32(p_rxReaderXml.GetAttribute("SymbolCode"));
                    sDescription = p_rxReaderXml.GetAttribute("Description");

                    // Identify the Led matrix of the symbol
                    while (p_rxReaderXml.Read())
                    {
                        int iLineNumber = 0;
                        string sLedOn;
                        LedOnLine lolLedOnLine;

                        // End of Led line
                        if (p_rxReaderXml.Name != "LedLine")
                        {
                            // Next one
                            break;
                        }

                        // New Led line
                        iLineNumber = Convert.ToInt32(p_rxReaderXml.GetAttribute("LineNumber"));
                        sLedOn = p_rxReaderXml.GetAttribute("LineLedOn");

                        // Add the line to the list
                        lolLedOnLine = new LedOnLine(iLineNumber, sLedOn);
                        lstLedOnLine.Add(lolLedOnLine);

                    }// Loop ont line processing

                    // Convert the led lines to led matrix
                    bLedOnMatrix = ConvertLedOnLineToLedOnMatrix(lstLedOnLine);

                    // Create and add the symbol
                    lmsNewSymbol = new LedMatrixSymbol(uiSmbCode, sDescription, bLedOnMatrix);
                    lstSymbolList.Add(lmsNewSymbol);

                }// Loop on symbol processing

                // Create and add the font
                lmsfNewFont = new LedMatrixSymbolFont(sFontName, lstSymbolList);
                lstFontList.Add(lmsfNewFont);

            }// Loop on font processing

            // Create the return font collection
            lmsfcReturnCollection = new LedMatrixSymbolFontCollection(lstFontList);

            // Valid font collection ?
            if (lstFontList.Count == 0)
            {
                return false;
            }
            else if (lstFontList[0].lstSymbolList.Count == 0)
            {
                return false;
            }

            // Ok => copy the collection
            m_fcFontCollection = lmsfcReturnCollection;
            return true;
        }

        private static bool[,] ConvertLedOnLineToLedOnMatrix(List<LedOnLine> p_lstLedOnLine)
        {
            int iMaxLineSize = 0;
            int iMaxLineNb = 0;
            bool[,] bReturnLedOnMatrix;

            // Get the size of the matrix
            foreach (LedOnLine lolLine in p_lstLedOnLine)
            {
                if (lolLine.sLedOn.Length > iMaxLineSize)
                {
                    iMaxLineSize = lolLine.sLedOn.Length;
                }

                if (lolLine.iLineNo > iMaxLineNb)
                {
                    iMaxLineNb = lolLine.iLineNo;
                }
            }

            // Creation of the return matrix
            bReturnLedOnMatrix = new bool[iMaxLineNb + 1, iMaxLineSize];

            // Build the matix
            foreach (LedOnLine lolLine in p_lstLedOnLine)
            {
                for (int iIdxChar = 0; iIdxChar < lolLine.sLedOn.Length; iIdxChar++)
                {
                    if (lolLine.sLedOn[iIdxChar] == '#')
                    {
                        bReturnLedOnMatrix[lolLine.iLineNo, iIdxChar] = true;
                    }
                }
            }

            // Return the led on matrix
            return bReturnLedOnMatrix;
        }
    }


    struct LedOnLine
    {
        public int iLineNo;///<!-- Line number in the symbol composition-->
        public string sLedOn; ///<!-- String which represents the led On -->

        /// <summary>
        /// Structure constructor
        /// </summary>
        /// <param name="p_iLineNo">Line number</param>
        /// <param name="p_sLedOn">Line string code</param>
        public LedOnLine(int p_iLineNo,
                         string p_sLedOn)
        {
            iLineNo = p_iLineNo;
            sLedOn = p_sLedOn;
        }
    }
    struct LedMatrixSymbolFontCollection
    {
        public List<LedMatrixSymbolFont> lstFontList;///<!-- The list of fonts -->

        /// <summary>
        /// Structure constructor
        /// </summary>
        /// <param name="p_lstFontList">List of fonts</param>
        public LedMatrixSymbolFontCollection(List<LedMatrixSymbolFont> p_lstFontList)
        {
            lstFontList = p_lstFontList;
        }
    }

    struct LedMatrixSymbolFont
    {
        public string sName;        ///<!-- The font name                  -->
        public List<LedMatrixSymbol> lstSymbolList;///<!-- The list of symbols in the font -->

        /// <summary>
        /// Structure constructor
        /// </summary>
        /// <param name="p_sName">Font name  </param>
        /// <param name="p_lstSymbolList">List of symbols in the font</param>
        public LedMatrixSymbolFont(string p_sName,
                                   List<LedMatrixSymbol> p_lstSymbolList)
        {
            sName = p_sName;
            lstSymbolList = p_lstSymbolList;
        }

    }

    struct LedMatrixSymbol
    {
        public bool[,] bLedOnMatrix;///<!-- The led On definition         -->
        public string sDescription;///<!-- The description of the symbol -->
        public uint uiCode;      ///<!-- The code of the symbol        -->


        /// <summary>
        /// Structure constructor
        /// </summary>
        /// <param name="p_uiCode">Code of the symbol</param>
        /// <param name="p_sDescription">Description of the symbol</param>
        /// <param name="p_bLedOnMatrix">Led On definition</param>
        public LedMatrixSymbol(uint p_uiCode,
                               string p_sDescription,
                               bool[,] p_bLedOnMatrix)
        {
            uiCode = p_uiCode;
            sDescription = p_sDescription;
            bLedOnMatrix = p_bLedOnMatrix;
        }
    }
}
