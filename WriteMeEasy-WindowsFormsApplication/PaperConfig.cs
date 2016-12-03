using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMeEasy_WindowsFormsApplication
{
    public class PaperConfig
    {
        public string titleOfPaper;
        public bool isAPA;
        public bool isMLA;
        public bool includeTitlePage;
        public bool includeSummary;
        public bool includeAbstract;
        public bool includeHeader;
        public bool includeFooter;
        public bool includeConclusion;
        public bool includeReferences;
        public TitlePageConfig titlePage;
        public SummaryAbstractConfig summary;
        public SummaryAbstractConfig abstractConfig;
        public HeaderFooterConfig header;
        public HeaderFooterConfig footer;
        public SectionsConfig sectionsConfig;
        public List<Section> sections;
        public ConclusionConfig conclusion;
        public ReferencesConfig references;

        public PaperConfig()
        {
            titlePage = new TitlePageConfig();
            summary = new SummaryAbstractConfig();
            abstractConfig = new SummaryAbstractConfig();
            sections = new List<Section>();
            conclusion = new ConclusionConfig();
            sectionsConfig = new SectionsConfig();
            header = new HeaderFooterConfig();
            footer = new HeaderFooterConfig();
            sections = new List<Section>();
            references = new ReferencesConfig();
            titleOfPaper = "";
            isAPA = true;
            isMLA = false;
            includeTitlePage = false;
            includeSummary = false;
            includeAbstract = false;
            includeHeader = false;
            includeFooter = false;
            includeConclusion = false;
            includeReferences = false;
        }
    }
}
