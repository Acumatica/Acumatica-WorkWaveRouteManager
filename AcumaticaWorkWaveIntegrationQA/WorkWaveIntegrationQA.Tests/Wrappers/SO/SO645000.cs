using Controls.CheckBox;
using Controls.Container;
using Controls.Editors.DateSelector;
using Controls.Editors.DropDown;
using Controls.Editors.Selector;
using Controls.Grid;
using Controls.Grid.Upload;
using Controls.Input.PXNumberEdit;
using Controls.Input.PXTextEdit;
using Controls.Label;
using Controls.PxControlCollection;
using Controls.ToolBarButton;
using Controls.TreeView;
using Core;
using Core.Core.Browser;
using Core.Wait;
using System;


namespace WorkWaveIntegrationQA.Tests.Wrappers
{


    public class SO645000 : Report
    {

        public PxToolBar ToolBar;

        protected c__pform _pForm { get; } = new c__pform("viewer_par_tab_t0_s0", "_pForm");
        protected c__grids _gridS { get; } = new c__grids("viewer_par_tab_t1_gridS", "_gridS");
        protected c__gridf _gridF { get; } = new c__gridf("viewer_par_tab_t1_gridF", "_gridF");
        protected c_printandemailsettings PrintAndEmailSettings { get; } = new c_printandemailsettings("viewer_par_tab_t2", "PrintAndEmailSettings");
        protected c_viewreports_gridv ViewReports_gridV { get; } = new c_viewreports_gridv("viewer_par_tab_t3_gridV", "ViewReports_gridV");
        protected c_parameters Parameters { get; } = new c_parameters("viewer_gt", "parameters");

        public SO645000()
        {
            ScreenId = "SO645000";
            ScreenUrl = "/Frames/ReportLauncher.aspx?ID=SO645000.rpx";
            ToolBar = new PxToolBar(null);
        }

        public virtual void Params()
        {
            ToolBar.Params.Click();
        }

        public virtual void LoadParams()
        {
            ToolBar.LoadParams.Click();
        }

        public virtual void Refresh()
        {
            ToolBar.Refresh.Click();
        }

        public virtual void PdfMode()
        {
            ToolBar.PdfMode.Click();
        }

        public virtual void HtmlMode()
        {
            ToolBar.HtmlMode.Click();
        }

        public virtual void Groups()
        {
            ToolBar.Groups.Click();
        }

        public virtual void PageFirst()
        {
            ToolBar.PageFirst.Click();
        }

        public virtual void PagePrev()
        {
            ToolBar.PagePrev.Click();
        }

        public virtual void PageNext()
        {
            ToolBar.PageNext.Click();
        }

        public virtual void PageLast()
        {
            ToolBar.PageLast.Click();
        }

        public virtual void Run()
        {
            ToolBar.Run.Click();
        }

        public virtual void TemplateSave()
        {
            ToolBar.TemplateSave.Click();
        }

        public virtual void TemplateRemove()
        {
            ToolBar.TemplateRemove.Click();
        }

        public virtual void TemplateSchedule()
        {
            ToolBar.TemplateSchedule.Click();
        }

        public virtual void Edit()
        {
            ToolBar.Edit.Click();
        }

        public virtual void Print()
        {
            ToolBar.Print.Click();
        }

        public virtual void MailSend()
        {
            ToolBar.MailSend.Click();
        }

        public virtual void Export()
        {
            ToolBar.Export.Click();
        }

        public virtual void Excel()
        {
            ToolBar.Excel.Click();
        }

        public virtual void PDF()
        {
            ToolBar.PDF.Click();
        }

        public virtual void Zoom()
        {
            ToolBar.Zoom.Click();
        }

        public virtual void FullPage()
        {
            ToolBar.FullPage.Click();
        }

        public virtual void PageWidth()
        {
            ToolBar.PageWidth.Click();
        }

        public virtual void Percent25()
        {
            ToolBar.Percent25.Click();
        }

        public virtual void Percent50()
        {
            ToolBar.Percent50.Click();
        }

        public virtual void Percent75()
        {
            ToolBar.Percent75.Click();
        }

        public virtual void Percent100()
        {
            ToolBar.Percent100.Click();
        }

        public virtual void Percent150()
        {
            ToolBar.Percent150.Click();
        }

        public virtual void Percent200()
        {
            ToolBar.Percent200.Click();
        }

        public virtual void Percent400()
        {
            ToolBar.Percent400.Click();
        }

        public virtual void SyncTOC()
        {
            ToolBar.SyncTOC.Click();
        }

        public virtual void KeyBtnRefresh()
        {
            ToolBar.KeyBtnRefresh.Click();
        }

        public virtual void Help()
        {
            ToolBar.Help.Click();
        }

        public class PxToolBar : PxControlCollection
        {

            public ToolBarButton Params { get; }
            public ToolBarButton LoadParams { get; }
            public ToolBarButton Refresh { get; }
            public ToolBarButton PdfMode { get; }
            public ToolBarButton HtmlMode { get; }
            public ToolBarButton Groups { get; }
            public ToolBarButton PageFirst { get; }
            public ToolBarButton PagePrev { get; }
            public ToolBarButton PageNext { get; }
            public ToolBarButton PageLast { get; }
            public ToolBarButton Run { get; }
            public ToolBarButton TemplateSave { get; }
            public ToolBarButton TemplateRemove { get; }
            public ToolBarButton TemplateSchedule { get; }
            public ToolBarButton Edit { get; }
            public ToolBarButton Print { get; }
            public ToolBarButton MailSend { get; }
            public ToolBarButton Export { get; }
            public ToolBarButton Excel { get; }
            public ToolBarButton PDF { get; }
            public ToolBarButton Zoom { get; }
            public ToolBarButton FullPage { get; }
            public ToolBarButton PageWidth { get; }
            public ToolBarButton Percent25 { get; }
            public ToolBarButton Percent50 { get; }
            public ToolBarButton Percent75 { get; }
            public ToolBarButton Percent100 { get; }
            public ToolBarButton Percent150 { get; }
            public ToolBarButton Percent200 { get; }
            public ToolBarButton Percent400 { get; }
            public ToolBarButton SyncTOC { get; }
            public ToolBarButton KeyBtnRefresh { get; }
            public ToolBarButton Help { get; }

            public PxToolBar(string locator)
            {
                Params = new ToolBarButton("css=#tlbReport div[data-cmd=\'Params\']", "Parameters", locator, null);
                LoadParams = new ToolBarButton("css=#tlbReport div[data-cmd=\'LoadParams\']", "Cancel", locator, null);
                Refresh = new ToolBarButton("css=#tlbReport div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                PdfMode = new ToolBarButton("css=#tlbReport div[data-cmd=\'PdfMode\']", "View PDF", locator, null);
                HtmlMode = new ToolBarButton("css=#tlbReport div[data-cmd=\'HtmlMode\']", "View HTML", locator, null);
                Groups = new ToolBarButton("css=#tlbReport div[data-cmd=\'Groups\']", "Groups", locator, null);
                PageFirst = new ToolBarButton("css=#tlbReport div[data-cmd=\'PageFirst\']", "Go to First Page", locator, null);
                PagePrev = new ToolBarButton("css=#tlbReport div[data-cmd=\'PagePrev\']", "Go to Previous Page", locator, null);
                PageNext = new ToolBarButton("css=#tlbReport div[data-cmd=\'PageNext\']", "Go to Next Page", locator, null);
                PageLast = new ToolBarButton("css=#tlbReport div[data-cmd=\'PageLast\']", "Go to Last Page", locator, null);
                Run = new ToolBarButton("css=#tlbReport div[data-cmd=\'Run\']", "Run Report", locator, null);
                TemplateSave = new ToolBarButton("css=#tlbReport div[data-cmd=\'TemplateSave\']", "Save Template", locator, null);
                TemplateRemove = new ToolBarButton("css=#tlbReport div[data-cmd=\'TemplateRemove\']", "Remove Template", locator, null);
                TemplateSchedule = new ToolBarButton("css=#tlbReport div[data-cmd=\'TemplateSchedule\']", "Schedule Template", locator, null);
                Edit = new ToolBarButton("css=#tlbReport div[data-cmd=\'Edit\']", "Edit Report", locator, null);
                Print = new ToolBarButton("css=#tlbReport div[data-cmd=\'Print\']", "Print", locator, null);
                MailSend = new ToolBarButton("css=#tlbReport div[data-cmd=\'MailSend\']", "Send", locator, null);
                Export = new ToolBarButton("css=#tlbReport div[data-cmd=\'Export\']", "Export", locator, null);
                Excel = new ToolBarButton("css=div#tlbReport_menuExport li.menuItem div:textEqual(\"Excel\")", "Excel", locator, Export);
                PDF = new ToolBarButton("css=div#tlbReport_menuExport li.menuItem div:textEqual(\"PDF\")", "PDF", locator, Export);
                Zoom = new ToolBarButton("css=#tlbReport div[data-cmd=\'Zoom\']", "Zoom", locator, null);
                FullPage = new ToolBarButton("css=div#tlbReport_menu21 li.menuItem div:textEqual(\"FullPage\")", "FullPage", locator, Zoom);
                PageWidth = new ToolBarButton("css=div#tlbReport_menu21 li.menuItem div:textEqual(\"PageWidth\")", "PageWidth", locator, Zoom);
                Percent25 = new ToolBarButton("css=div#tlbReport_menu21 li.menuItem div:textEqual(\"25%\")", "25%", locator, Zoom);
                Percent50 = new ToolBarButton("css=div#tlbReport_menu21 li.menuItem div:textEqual(\"50%\")", "50%", locator, Zoom);
                Percent75 = new ToolBarButton("css=div#tlbReport_menu21 li.menuItem div:textEqual(\"75%\")", "75%", locator, Zoom);
                Percent100 = new ToolBarButton("css=div#tlbReport_menu21 li.menuItem div:textEqual(\"100%\")", "100%", locator, Zoom);
                Percent150 = new ToolBarButton("css=div#tlbReport_menu21 li.menuItem div:textEqual(\"150%\")", "150%", locator, Zoom);
                Percent200 = new ToolBarButton("css=div#tlbReport_menu21 li.menuItem div:textEqual(\"200%\")", "200%", locator, Zoom);
                Percent400 = new ToolBarButton("css=div#tlbReport_menu21 li.menuItem div:textEqual(\"400%\")", "400%", locator, Zoom);
                SyncTOC = new ToolBarButton("css=#usrCaption_tlbPath div[data-cmd=\'syncTOC\']", "Sync Navigation Pane", locator, null);
                KeyBtnRefresh = new ToolBarButton("css=#usrCaption_tlbTools div[data-cmd=\'keyBtnRefresh\']", "Click to refresh page.", locator, null);
                Help = new ToolBarButton("css=#usrCaption_tlbTools div[data-cmd=\'help\']", "View Tools", locator, null);
            }
        }

        public class c__pform : Container
        {

            public Selector EdshipmentNbr { get; }
            public Label EdshipmentNbrLabel { get; }
            public PXTextEdit EdisDelimiter { get; }
            public Label EdisDelimiterLabel { get; }

            public c__pform(string locator, string name) :
                    base(locator, name)
            {
                EdshipmentNbr = new Selector("viewer_par_tab_t0_pForm_edshipmentNbr", "Shipment Nbr.", locator, null);
                EdshipmentNbrLabel = new Label(EdshipmentNbr);
                EdisDelimiter = new PXTextEdit("viewer_par_tab_t0_pForm_edisDelimiter", "Edis Delimiter", locator, null);
                EdisDelimiterLabel = new Label(EdisDelimiter);
                DataMemberName = null;
            }
        }

        public class c__grids : Grid<c__grids.c_grid_row, c__grids.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c__grids(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("viewer_par_tab_t1_gridS");
                DataMemberName = null;
            }

            public virtual void New()
            {
                ToolBar.New.Click();
            }

            public virtual void Delete()
            {
                ToolBar.Delete.Click();
            }

            public virtual void Hi()
            {
                ToolBar.Hi.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid New { get; }
                public ToolBarButtonGrid Delete { get; }
                public ToolBarButtonGrid Hi { get; }

                public PxToolBar(string locator)
                {
                    New = new ToolBarButtonGrid("css=#viewer_par_tab_t1_gridS_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#viewer_par_tab_t1_gridS_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Hi = new ToolBarButtonGrid("css=#viewer_par_tab_t1_gridS_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public DropDown DataField { get; }
                public DropDown SortOrder { get; }

                public c_grid_row(c__grids grid) :
                        base(grid)
                {
                    DataField = new DropDown("_viewer_par_tab_t1_gridS_lv0_ec", "Property", grid.Locator, "DataField");
                    DataField.DataField = "DataField";
                    DataField.Items.Add("Address.AddressLine1", "Address.Address Line 1");
                    DataField.Items.Add("Address.City", "Address.City");
                    DataField.Items.Add("Address.PostalCode", "Address.Postal Code");
                    DataField.Items.Add("Address.State", "Address.State");
                    DataField.Items.Add("CarrierPluginDetail.Value", "Carrier Plugin Detail.Value");
                    DataField.Items.Add("SOPackageDetail.BoxID", "SO Package Detail.Box ID");
                    DataField.Items.Add("SOPackageDetail.LineNbr", "SO Package Detail.Line Nbr.");
                    DataField.Items.Add("SOPackageDetail.NoteFiles", "SO Package Detail.NoteText");
                    DataField.Items.Add("SOPackageDetail.ShipmentNbr", "SO Package Detail.Shipment Nbr.");
                    DataField.Items.Add("SOShipment.ShipDate", "Shipment.Shipment Date");
                    DataField.Items.Add("SOShipment.ShipmentNbr", "Shipment.Shipment Nbr.");
                    DataField.Items.Add("SOShipment.ShipmentQty", "Shipment.Shipped Quantity");
                    DataField.Items.Add("SOShipment.ShipmentType", "Shipment.Type");
                    DataField.Items.Add("SOShipment.ShipmentWeight", "Shipment.Shipped Weight");
                    DataField.Items.Add("SOShipment.SiteID", "Shipment.Warehouse ID");
                    DataField.Items.Add("SOShipment.UsrIsWorkWave", "Shipment.IsWorkWave");
                    DataField.Items.Add("SOShipmentAddress.AddressLine1", "Shipment Address.Address Line 1");
                    DataField.Items.Add("SOShipmentAddress.City", "Shipment Address.City");
                    DataField.Items.Add("SOShipmentAddress.PostalCode", "Shipment Address.Postal Code");
                    DataField.Items.Add("SOShipmentAddress.State", "Shipment Address.State");
                    SortOrder = new DropDown("_viewer_par_tab_t1_gridS_lv0_ec", "Condition", grid.Locator, "SortOrder");
                    SortOrder.DataField = "SortOrder";
                    SortOrder.Items.Add("Ascending", "Ascending");
                    SortOrder.Items.Add("Descending", "Descending");
                }
            }

            public class c_grid_header : GridHeader
            {

                public DropDownColumnFilter DataField { get; }
                public DropDownColumnFilter SortOrder { get; }

                public c_grid_header(c__grids grid) :
                        base(grid)
                {
                    DataField = new DropDownColumnFilter(grid.Row.DataField);
                    SortOrder = new DropDownColumnFilter(grid.Row.SortOrder);
                }
            }
        }

        public class c__gridf : Grid<c__gridf.c_grid_row, c__gridf.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c__gridf(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("viewer_par_tab_t1_gridF");
                DataMemberName = null;
            }

            public virtual void New()
            {
                ToolBar.New.Click();
            }

            public virtual void Delete()
            {
                ToolBar.Delete.Click();
            }

            public virtual void Hi()
            {
                ToolBar.Hi.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid New { get; }
                public ToolBarButtonGrid Delete { get; }
                public ToolBarButtonGrid Hi { get; }

                public PxToolBar(string locator)
                {
                    New = new ToolBarButtonGrid("css=#viewer_par_tab_t1_gridF_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#viewer_par_tab_t1_gridF_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Hi = new ToolBarButtonGrid("css=#viewer_par_tab_t1_gridF_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public DropDown OpenBraces { get; }
                public DropDown DataField { get; }
                public DropDown Condition { get; }
                public PXTextEdit Value { get; }
                public PXTextEdit Value2 { get; }
                public DropDown CloseBraces { get; }
                public DropDown Operator { get; }

                public c_grid_row(c__gridf grid) :
                        base(grid)
                {
                    OpenBraces = new DropDown("_viewer_par_tab_t1_gridF_lv0_ec", "Brackets", grid.Locator, "OpenBraces");
                    OpenBraces.DataField = "OpenBraces";
                    OpenBraces.Items.Add("0", " ");
                    OpenBraces.Items.Add("1", "(");
                    OpenBraces.Items.Add("2", "((");
                    OpenBraces.Items.Add("3", "(((");
                    OpenBraces.Items.Add("4", "((((");
                    OpenBraces.Items.Add("5", "(((((");
                    DataField = new DropDown("_viewer_par_tab_t1_gridF_lv0_ec", "Property", grid.Locator, "DataField");
                    DataField.DataField = "DataField";
                    DataField.Items.Add("Address.AddressLine1", "Address.Address Line 1");
                    DataField.Items.Add("Address.City", "Address.City");
                    DataField.Items.Add("Address.PostalCode", "Address.Postal Code");
                    DataField.Items.Add("Address.State", "Address.State");
                    DataField.Items.Add("CarrierPluginDetail.Value", "Carrier Plugin Detail.Value");
                    DataField.Items.Add("SOPackageDetail.BoxID", "SO Package Detail.Box ID");
                    DataField.Items.Add("SOPackageDetail.LineNbr", "SO Package Detail.Line Nbr.");
                    DataField.Items.Add("SOPackageDetail.NoteFiles", "SO Package Detail.NoteText");
                    DataField.Items.Add("SOPackageDetail.ShipmentNbr", "SO Package Detail.Shipment Nbr.");
                    DataField.Items.Add("SOShipment.ShipDate", "Shipment.Shipment Date");
                    DataField.Items.Add("SOShipment.ShipmentNbr", "Shipment.Shipment Nbr.");
                    DataField.Items.Add("SOShipment.ShipmentQty", "Shipment.Shipped Quantity");
                    DataField.Items.Add("SOShipment.ShipmentType", "Shipment.Type");
                    DataField.Items.Add("SOShipment.ShipmentWeight", "Shipment.Shipped Weight");
                    DataField.Items.Add("SOShipment.SiteID", "Shipment.Warehouse ID");
                    DataField.Items.Add("SOShipment.UsrIsWorkWave", "Shipment.IsWorkWave");
                    DataField.Items.Add("SOShipmentAddress.AddressLine1", "Shipment Address.Address Line 1");
                    DataField.Items.Add("SOShipmentAddress.City", "Shipment Address.City");
                    DataField.Items.Add("SOShipmentAddress.PostalCode", "Shipment Address.Postal Code");
                    DataField.Items.Add("SOShipmentAddress.State", "Shipment Address.State");
                    Condition = new DropDown("_viewer_par_tab_t1_gridF_lv0_ec", "Condition", grid.Locator, "Condition");
                    Condition.DataField = "Condition";
                    Condition.Items.Add("Equal", "Equals");
                    Condition.Items.Add("NotEqual", "Does Not Equal");
                    Condition.Items.Add("Greater", "Is Greater Than");
                    Condition.Items.Add("GreaterOrEqual", "Is Greater Than or Equal To");
                    Condition.Items.Add("Less", "Is Less Than");
                    Condition.Items.Add("LessOrEqual", "Is Less Than or Equal To");
                    Condition.Items.Add("Like", "Contains");
                    Condition.Items.Add("LLike", "Ends With");
                    Condition.Items.Add("RLike", "Starts With");
                    Condition.Items.Add("NotLike", "Does Not Contain");
                    Condition.Items.Add("Between", "Is Between");
                    Condition.Items.Add("IsNull", "Is Empty");
                    Condition.Items.Add("IsNotNull", "Is Not Empty");
                    Condition.Items.Add("Today", "Today");
                    Condition.Items.Add("Overdue", "Overdue");
                    Condition.Items.Add("TodayOverdue", "Today+Overdue");
                    Condition.Items.Add("Tomorrow", "Tomorrow");
                    Condition.Items.Add("ThisWeek", "This Week");
                    Condition.Items.Add("NextWeek", "Next Week");
                    Condition.Items.Add("ThisMonth", "This Month");
                    Condition.Items.Add("NextMonth", "Next Month");
                    Value = new PXTextEdit("viewer_par_tab_t1_gridF_ei", "Value", grid.Locator, "Value");
                    Value.DataField = "Value";
                    Value2 = new PXTextEdit("viewer_par_tab_t1_gridF_ei", "Second Value", grid.Locator, "Value2");
                    Value2.DataField = "Value2";
                    CloseBraces = new DropDown("_viewer_par_tab_t1_gridF_lv0_ec", "Brackets", grid.Locator, "CloseBraces");
                    CloseBraces.DataField = "CloseBraces";
                    CloseBraces.Items.Add("0", " ");
                    CloseBraces.Items.Add("1", ")");
                    CloseBraces.Items.Add("2", "))");
                    CloseBraces.Items.Add("3", ")))");
                    CloseBraces.Items.Add("4", "))))");
                    CloseBraces.Items.Add("5", ")))))");
                    Operator = new DropDown("_viewer_par_tab_t1_gridF_lv0_ec", "Operator", grid.Locator, "Operator");
                    Operator.DataField = "Operator";
                    Operator.Items.Add("And", "And");
                    Operator.Items.Add("Or", "Or");
                }
            }

            public class c_grid_header : GridHeader
            {

                public DropDownColumnFilter OpenBraces { get; }
                public DropDownColumnFilter DataField { get; }
                public DropDownColumnFilter Condition { get; }
                public PXTextEditColumnFilter Value { get; }
                public PXTextEditColumnFilter Value2 { get; }
                public DropDownColumnFilter CloseBraces { get; }
                public DropDownColumnFilter Operator { get; }

                public c_grid_header(c__gridf grid) :
                        base(grid)
                {
                    OpenBraces = new DropDownColumnFilter(grid.Row.OpenBraces);
                    DataField = new DropDownColumnFilter(grid.Row.DataField);
                    Condition = new DropDownColumnFilter(grid.Row.Condition);
                    Value = new PXTextEditColumnFilter(grid.Row.Value);
                    Value2 = new PXTextEditColumnFilter(grid.Row.Value2);
                    CloseBraces = new DropDownColumnFilter(grid.Row.CloseBraces);
                    Operator = new DropDownColumnFilter(grid.Row.Operator);
                }
            }
        }

        public class c_printandemailsettings : Container
        {

            public DropDown EdcmDeletedRecords { get; }
            public CheckBox EdcmPrintAllPages { get; }
            public CheckBox EdcmViewPdf { get; }
            public CheckBox EdcmPdfCompressed { get; }
            public CheckBox EdcmPdfFontEmbedded { get; }
            public DropDown EdmlFormat { get; }
            public PXTextEdit EdmlEMail { get; }
            public Label EdmlEMailLabel { get; }
            public PXTextEdit EdmlCc { get; }
            public Label EdmlCcLabel { get; }
            public PXTextEdit EdmlBcc { get; }
            public Label EdmlBccLabel { get; }
            public PXTextEdit EdmlSubject { get; }
            public Label EdmlSubjectLabel { get; }

            public c_printandemailsettings(string locator, string name) :
                    base(locator, name)
            {
                EdcmDeletedRecords = new DropDown("viewer_par_tab_t2_CM_edcmDeletedRecords", "Deleted Records", locator, null);
                EdcmDeletedRecords.Items.Add("H", "Hide");
                EdcmDeletedRecords.Items.Add("P", "Print");
                EdcmDeletedRecords.Items.Add("O", "Only");
                EdcmPrintAllPages = new CheckBox("viewer_par_tab_t2_CM_edcmPrintAllPages", "Print all pages", locator, null);
                EdcmViewPdf = new CheckBox("viewer_par_tab_t2_CM_edcmViewPdf", "Print in PDF format", locator, null);
                EdcmPdfCompressed = new CheckBox("viewer_par_tab_t2_CM_edcmPdfCompressed", "Compress PDF file", locator, null);
                EdcmPdfFontEmbedded = new CheckBox("viewer_par_tab_t2_CM_edcmPdfFontEmbedded", "Embed fonts in PDF file", locator, null);
                EdmlFormat = new DropDown("viewer_par_tab_t2_MS_edmlFormat", "Format", locator, null);
                EdmlFormat.Items.Add("PDF", "PDF");
                EdmlFormat.Items.Add("HTML", "HTML");
                EdmlFormat.Items.Add("Excel", "Excel");
                EdmlEMail = new PXTextEdit("viewer_par_tab_t2_MS_edmlEMail", "To", locator, null);
                EdmlEMailLabel = new Label(EdmlEMail);
                EdmlCc = new PXTextEdit("viewer_par_tab_t2_MS_edmlCc", "CC", locator, null);
                EdmlCcLabel = new Label(EdmlCc);
                EdmlBcc = new PXTextEdit("viewer_par_tab_t2_MS_edmlBcc", "BCC", locator, null);
                EdmlBccLabel = new Label(EdmlBcc);
                EdmlSubject = new PXTextEdit("viewer_par_tab_t2_MS_edmlSubject", "Subject", locator, null);
                EdmlSubjectLabel = new Label(EdmlSubject);
                DataMemberName = null;
            }
        }

        public class c_viewreports_gridv : Grid<c_viewreports_gridv.c_grid_row, c_viewreports_gridv.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_viewreports_gridv(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("viewer_par_tab_t3_gridV");
                DataMemberName = null;
            }

            public virtual void Refresh()
            {
                ToolBar.Refresh.Click();
            }

            public virtual void Delete()
            {
                ToolBar.Delete.Click();
            }

            public virtual void Edit()
            {
                ToolBar.Edit.Click();
            }

            public virtual void Select()
            {
                ToolBar.Select.Click();
            }

            public virtual void Hi()
            {
                ToolBar.Hi.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid Delete { get; }
                public ToolBarButtonGrid Edit { get; }
                public ToolBarButtonGrid Select { get; }
                public ToolBarButtonGrid Hi { get; }

                public PxToolBar(string locator)
                {
                    Refresh = new ToolBarButtonGrid("css=#viewer_par_tab_t3_gridV_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    Delete = new ToolBarButtonGrid("css=#viewer_par_tab_t3_gridV_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Edit = new ToolBarButtonGrid("css=#viewer_par_tab_t3_gridV_at_tlb div[data-cmd=\'Edit\']", "Edit version", locator, null);
                    Select = new ToolBarButtonGrid("css=#viewer_par_tab_t3_gridV_at_tlb div[data-cmd=\'Select\']", "Activate the selected version", locator, null);
                    Hi = new ToolBarButtonGrid("css=#viewer_par_tab_t3_gridV_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public PXNumberEdit Version { get; }
                public PXTextEdit Description { get; }
                public CheckBox IsActive { get; }
                public DateSelector DateCreated { get; }
                public PXTextEdit ReportFileName { get; }

                public c_grid_row(c_viewreports_gridv grid) :
                        base(grid)
                {
                    Version = new PXNumberEdit("viewer_par_tab_t3_gridV_en", "Version", grid.Locator, "Version");
                    Version.DataField = "Version";
                    Description = new PXTextEdit("viewer_par_tab_t3_gridV_ei", "Description", grid.Locator, "Description");
                    Description.DataField = "Description";
                    IsActive = new CheckBox("viewer_par_tab_t3_gridV_ef", "Active", grid.Locator, "IsActive");
                    IsActive.DataField = "IsActive";
                    DateCreated = new DateSelector("_viewer_par_tab_t3_gridV_lv0_ed3", "Created", grid.Locator, "DateCreated");
                    DateCreated.DataField = "DateCreated";
                    ReportFileName = new PXTextEdit("viewer_par_tab_t3_gridV_ei", "ReportFileName", grid.Locator, "ReportFileName");
                    ReportFileName.DataField = "ReportFileName";
                }
            }

            public class c_grid_header : GridHeader
            {

                public PXNumberEditColumnFilter Version { get; }
                public PXTextEditColumnFilter Description { get; }
                public CheckBoxColumnFilter IsActive { get; }
                public DateSelectorColumnFilter DateCreated { get; }
                public PXTextEditColumnFilter ReportFileName { get; }

                public c_grid_header(c_viewreports_gridv grid) :
                        base(grid)
                {
                    Version = new PXNumberEditColumnFilter(grid.Row.Version);
                    Description = new PXTextEditColumnFilter(grid.Row.Description);
                    IsActive = new CheckBoxColumnFilter(grid.Row.IsActive);
                    DateCreated = new DateSelectorColumnFilter(grid.Row.DateCreated);
                    ReportFileName = new PXTextEditColumnFilter(grid.Row.ReportFileName);
                }
            }
        }

        public class c_parameters : Container
        {

            public TreeView Gt { get; }

            public c_parameters(string locator, string name) :
                    base(locator, name)
            {
                Gt = new TreeView("viewer_gt", "Gt", locator, null);
                DataMemberName = "";
            }
        }
    }
}
