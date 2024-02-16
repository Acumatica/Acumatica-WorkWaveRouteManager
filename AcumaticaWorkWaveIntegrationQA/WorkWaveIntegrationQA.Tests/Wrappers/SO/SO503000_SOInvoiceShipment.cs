using Controls.Alert;
using Controls.Button;
using Controls.CheckBox;
using Controls.Container;
using Controls.Container.Extentions;
using Controls.Editors.DateSelector;
using Controls.Editors.DropDown;
using Controls.Editors.QuickSearch;
using Controls.Editors.Selector;
using Controls.FileColumnButton;
using Controls.Grid;
using Controls.Grid.Filter;
using Controls.Grid.Upload;
using Controls.GroupBox;
using Controls.Input;
using Controls.Input.PXNumberEdit;
using Controls.Input.PXTextEdit;
using Controls.Label;
using Controls.NoteColumnButton;
using Controls.PxControlCollection;
using Controls.ToolBarButton;
using Core;
using Core.Core.Browser;
using Core.Wait;
using System;


namespace WorkWaveIntegrationQA.Tests.Wrappers
{


    public class SO503000_SOInvoiceShipment : Wrapper
    {

        public PxToolBar ToolBar;

        public QuickSearch QuickSearch { get; }
        protected c_filter_form Filter_form { get; } = new c_filter_form("ctl00_phF_form", "Filter_form");
        protected c_parameters_gridwizard Parameters_gridWizard { get; } = new c_parameters_gridwizard("ctl00_usrCaption_shareColumnsDlg_gridWizard", "Parameters_gridWizard");
        protected c_profilerinfoview_formprofiler ProfilerInfoView_formProfiler { get; } = new c_profilerinfoview_formprofiler("ctl00_usrCaption_pnlProfiler_formProfiler", "ProfilerInfoView_formProfiler");
        protected c_firstselect_formactions FirstSelect_FormActions { get; } = new c_firstselect_formactions("ctl00_usrCaption_CustomizationDialogs_PXSmartPanel1_FormActions", "FirstSelect_FormActions");
        protected c_comboboxvalues_gridcombos ComboBoxValues_gridCombos { get; } = new c_comboboxvalues_gridcombos("ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos", "ComboBoxValues_gridCombos");
        protected c_vieweleminfo_formeleminfo ViewElemInfo_FormElemInfo { get; } = new c_vieweleminfo_formeleminfo("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo", "ViewElemInfo_FormElemInfo");
        protected c_filterworkingproject_formnewproject FilterWorkingProject_FormNewProject { get; } = new c_filterworkingproject_formnewproject("ctl00_usrCaption_CustomizationDialogs_DlgNewProject_FormNewProject", "FilterWorkingProject_FormNewProject");
        protected c_filterworkingproject_formselectproject FilterWorkingProject_FormSelectProject { get; } = new c_filterworkingproject_formselectproject("ctl00_usrCaption_CustomizationDialogs_WizardSelectProject_FormSelectProject", "FilterWorkingProject_FormSelectProject");
        protected c_gridlist_gridgrid GridList_gridGrid { get; } = new c_gridlist_gridgrid("ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid", "GridList_gridGrid");
        protected c_userlist_usergrid UserList_userGrid { get; } = new c_userlist_usergrid("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid", "UserList_userGrid");
        protected c_userlist_lv0 UserList_lv0 { get; } = new c_userlist_lv0("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_lv0", "UserList_lv0");
        protected c_processingview_griddetails ProcessingView_gridDetails { get; } = new c_processingview_griddetails("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails", "ProcessingView_gridDetails");
        protected c_orders_grid Orders_grid { get; } = new c_orders_grid("ctl00_phG_grid", "Orders_grid");
        protected c_orders_lv0 Orders_lv0 { get; } = new c_orders_lv0("ctl00_phG_grid_lv0", "Orders_lv0");
        protected c_filterpreview_formpreview FilterPreview_FormPreview { get; } = new c_filterpreview_formpreview("ctl00_usrCaption_PanelDynamicForm_FormPreview", "FilterPreview_FormPreview");
        public c_processing Processing { get; } = new c_processing("ctl00_usrCaption_ProcessingDialogs_PanelProgress", "Processing");

        public SO503000_SOInvoiceShipment()
        {
            ScreenId = "SO503000";
            ScreenUrl = "/Pages/SO/SO503000.aspx";
            ToolBar = new PxToolBar(null);
            QuickSearch = new QuickSearch("ctl00_phDS_ds_ToolBar_fb", "QuickSearch", null, null);
        }

        public virtual void SyncTOC()
        {
            ToolBar.SyncTOC.Click();
        }

        public virtual void Custom()
        {
            ToolBar.Custom.Click();
        }

        public virtual void ActionSelectWorkingProject()
        {
            ToolBar.ActionSelectWorkingProject.Click();
        }

        public virtual void InspectElementCtrlAltClick()
        {
            ToolBar.InspectElementCtrlAltClick.Click();
        }

        public virtual void MenuEditProj()
        {
            ToolBar.MenuEditProj.Click();
        }

        public virtual void ManageCustomizations()
        {
            ToolBar.ManageCustomizations.Click();
        }

        public virtual void KeyBtnRefresh()
        {
            ToolBar.KeyBtnRefresh.Click();
        }

        public virtual void Help()
        {
            ToolBar.Help.Click();
        }

        public virtual void Refresh()
        {
            ToolBar.Refresh.Click();
        }

        public virtual void Cancel()
        {
            ToolBar.Cancel.Click();
        }

        public virtual void Process()
        {
            ToolBar.Process.Click();
        }

        public virtual void Process(bool status, string message = null)
        {
            ToolBar.Process.WaitActionOverride = () => Wait.WaitForLongOperationToComplete(status, message);
            ToolBar.Process.Click();
        }

        public virtual void ProcessAll()
        {
            ToolBar.ProcessAll.Click();
        }

        public virtual void ProcessAll(bool status, string message = null)
        {
            ToolBar.ProcessAll.WaitActionOverride = () => Wait.WaitForLongOperationToComplete(status, message);
            ToolBar.ProcessAll.Click();
        }

        public virtual void Schedule()
        {
            ToolBar.Schedule.Click();
        }

        public virtual void ScheduleAdd()
        {
            ToolBar.ScheduleAdd.Click();
        }

        public virtual void ScheduleView()
        {
            ToolBar.ScheduleView.Click();
        }

        public virtual void ScheduleHistory()
        {
            ToolBar.ScheduleHistory.Click();
        }

        public virtual void Adjust()
        {
            ToolBar.Adjust.Click();
        }

        public virtual void Export()
        {
            ToolBar.Export.Click();
        }

        public virtual void Filter()
        {
            ToolBar.Filter.Click();
        }

        public virtual void LongRun()
        {
            ToolBar.LongRun.Click();
        }

        public virtual void LongrunCancel()
        {
            ToolBar.LongrunCancel.Click();
        }

        public virtual void LongrunTimer()
        {
            ToolBar.LongrunTimer.Click();
        }

        public class PxToolBar : PxControlCollection
        {

            public ToolBarButton SyncTOC { get; }
            public ToolBarButton Custom { get; }
            public ToolBarButton ActionSelectWorkingProject { get; }
            public ToolBarButton InspectElementCtrlAltClick { get; }
            public ToolBarButton MenuEditProj { get; }
            public ToolBarButton ManageCustomizations { get; }
            public ToolBarButton KeyBtnRefresh { get; }
            public ToolBarButton Help { get; }
            public ToolBarButton Refresh { get; }
            public ToolBarButton Cancel { get; }
            public ToolBarButton Process { get; }
            public ToolBarButton ProcessAll { get; }
            public ToolBarButton Schedule { get; }
            public ToolBarButton ScheduleAdd { get; }
            public ToolBarButton ScheduleView { get; }
            public ToolBarButton ScheduleHistory { get; }
            public ToolBarButton Adjust { get; }
            public ToolBarButton Export { get; }
            public ToolBarButton Filter { get; }
            public ToolBarButton LongRun { get; }
            public ToolBarButton LongrunCancel { get; }
            public ToolBarButton LongrunTimer { get; }

            public PxToolBar(string locator)
            {
                SyncTOC = new ToolBarButton("css=#ctl00_usrCaption_tlbPath div[data-cmd=\'syncTOC\']", "Sync Navigation Pane", locator, null);
                Custom = new ToolBarButton("css=#ctl00_usrCaption_CustomizationDialogs_PXToolBar1 div[data-cmd=\'Custom\']", "Customization", locator, null);
                ActionSelectWorkingProject = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li[data-cmd=\'" +
                        "ActionSelectWorkingProject\']", "Select Project...", locator, Custom);
                InspectElementCtrlAltClick = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li.menuItem d" +
                        "iv:textEqual(\"Inspect Element (Ctrl+Alt+Click)\")", "Inspect Element (Ctrl+Alt+Click)", locator, Custom);
                MenuEditProj = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li[data-cmd=\'" +
                        "menuEditProj\']", "Edit Project...", locator, Custom);
                ManageCustomizations = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li.menuItem d" +
                        "iv:textEqual(\"Manage Customizations...\")", "Manage Customizations...", locator, Custom);
                KeyBtnRefresh = new ToolBarButton("css=#ctl00_usrCaption_tlbTools div[data-cmd=\'keyBtnRefresh\']", "Click to refresh page.", locator, null);
                Help = new ToolBarButton("css=#ctl00_usrCaption_tlbTools div[data-cmd=\'help\']", "View Tools", locator, null);
                Refresh = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Refresh", "Refresh", locator, null);
                Cancel = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Cancel", "Cancel (Esc)", locator, null);
                Cancel.ConfirmAction = () => Alert.AlertToException("Any unsaved changes will be discarded.");
                Process = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Process", "Process", locator, null);
                Process.WaitAction = Wait.WaitForLongOperationToComplete;
                ProcessAll = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ProcessAll", "Process All", locator, null);
                ProcessAll.WaitAction = Wait.WaitForLongOperationToComplete;
                Schedule = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Schedule", "Schedules", locator, null);
                ScheduleAdd = new ToolBarButton("css=[id=\'ctl00_phDS_ds_ToolBar__ScheduleAdd_\']", "_ScheduleAdd_", locator, Schedule);
                ScheduleView = new ToolBarButton("css=[id=\'ctl00_phDS_ds_ToolBar__ScheduleView_\']", "_ScheduleView_", locator, Schedule);
                ScheduleHistory = new ToolBarButton("css=[id=\'ctl00_phDS_ds_ToolBar__ScheduleHistory_\']", "_ScheduleHistory_", locator, Schedule);
                Adjust = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_AdjustColumns", "Fit to Screen", locator, null);
                Export = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ExportExcel", "Export to Excel", locator, null);
                Filter = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_FilterShow", "Filter Settings", locator, null);
                LongRun = new ToolBarButton("css=qp-long-run", "Nothing in progress", locator, null);
                LongrunCancel = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_cancel", "Cancel", locator, null);
                LongrunTimer = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_timer", "Elapsed Time", locator, null);
            }
        }

        public class c_filter_form : Container
        {

            public DropDown Action { get; }
            public Label ActionLabel { get; }
            public DateSelector StartDate { get; }
            public Label StartDateLabel { get; }
            public DateSelector EndDate { get; }
            public Label EndDateLabel { get; }
            public DateSelector InvoiceDate { get; }
            public Label InvoiceDateLabel { get; }
            public CheckBox ShowPrinted { get; }
            public Label ShowPrintedLabel { get; }
            public Selector CustomerID { get; }
            public Label CustomerIDLabel { get; }
            public Selector CarrierPluginID { get; }
            public Label CarrierPluginIDLabel { get; }
            public Selector ShipVia { get; }
            public Label ShipViaLabel { get; }
            public Selector SiteID { get; }
            public Label SiteIDLabel { get; }
            public DropDown PackagingType { get; }
            public Label PackagingTypeLabel { get; }
            public CheckBox PrintWithDeviceHub { get; }
            public Label PrintWithDeviceHubLabel { get; }
            public CheckBox DefinePrinterManually { get; }
            public Label DefinePrinterManuallyLabel { get; }
            public Selector PrinterID { get; }
            public Label PrinterIDLabel { get; }
            public PXTextEdit NumberOfCopies { get; }
            public Label NumberOfCopiesLabel { get; }

            public c_filter_form(string locator, string name) :
                    base(locator, name)
            {
                Action = new DropDown("ctl00_phF_form_edAction", "Action", locator, null);
                ActionLabel = new Label(Action);
                Action.DataField = "Action";
                Action.Items.Add("<SELECT>", "<SELECT>");
                Action.Items.Add("SO302000$createWokWaveOrder", "Create WorkWave Order");
                Action.Items.Add("SO302000$getDeliveryStatus", "Get Delivery Status");
                Action.Items.Add("SO302000$createInvoice", "Prepare Invoice");
                Action.Items.Add("SO302000$createDropshipInvoice", "Prepare Drop-Ship Invoice");
                Action.Items.Add("SO302000$printPickListAction", "Print Pick List");
                Action.Items.Add("SO302000$printShipmentConfirmation", "Print Shipment Confirmation");
                Action.Items.Add("SO302000$emailShipment", "Email Shipment");
                Action.Items.Add("SO302000$UpdateIN", "Update IN");
                Action.Items.Add("SO302000$confirmShipmentAction", "Confirm Shipment");
                Action.Items.Add("SO302000$printLabels", "Print Labels");
                StartDate = new DateSelector("ctl00_phF_form_edStartDate", "Start Date", locator, null);
                StartDateLabel = new Label(StartDate);
                StartDate.DataField = "StartDate";
                EndDate = new DateSelector("ctl00_phF_form_edEndDate", "End Date", locator, null);
                EndDateLabel = new Label(EndDate);
                EndDate.DataField = "EndDate";
                InvoiceDate = new DateSelector("ctl00_phF_form_edInvoiceDate", "Invoice Date", locator, null);
                InvoiceDateLabel = new Label(InvoiceDate);
                InvoiceDate.DataField = "InvoiceDate";
                ShowPrinted = new CheckBox("ctl00_phF_form_chkShowPrinted", "Show Printed", locator, null);
                ShowPrintedLabel = new Label(ShowPrinted);
                ShowPrinted.DataField = "ShowPrinted";
                CustomerID = new Selector("ctl00_phF_form_edCustomerID", "Customer", locator, null);
                CustomerIDLabel = new Label(CustomerID);
                CustomerID.DataField = "CustomerID";
                CarrierPluginID = new Selector("ctl00_phF_form_edCarrierPlugin", "Carrier", locator, null);
                CarrierPluginIDLabel = new Label(CarrierPluginID);
                CarrierPluginID.DataField = "CarrierPluginID";
                ShipVia = new Selector("ctl00_phF_form_edShipVia", "Ship Via", locator, null);
                ShipViaLabel = new Label(ShipVia);
                ShipVia.DataField = "ShipVia";
                SiteID = new Selector("ctl00_phF_form_edSiteID", "Warehouse", locator, null);
                SiteIDLabel = new Label(SiteID);
                SiteID.DataField = "SiteID";
                PackagingType = new DropDown("ctl00_phF_form_edPackagingType", "Packaging Type", locator, null);
                PackagingTypeLabel = new Label(PackagingType);
                PackagingType.DataField = "PackagingType";
                PackagingType.Items.Add("B", "Auto and Manual");
                PackagingType.Items.Add("A", "Auto");
                PackagingType.Items.Add("M", "Manual");
                PrintWithDeviceHub = new CheckBox("ctl00_phF_form_chkPrintWithDeviceHub", "Print with DeviceHub", locator, null);
                PrintWithDeviceHubLabel = new Label(PrintWithDeviceHub);
                PrintWithDeviceHub.DataField = "PrintWithDeviceHub";
                DefinePrinterManually = new CheckBox("ctl00_phF_form_chkDefinePrinterManually", "Define Printer Manually", locator, null);
                DefinePrinterManuallyLabel = new Label(DefinePrinterManually);
                DefinePrinterManually.DataField = "DefinePrinterManually";
                PrinterID = new Selector("ctl00_phF_form_edPrinterID", "Printer", locator, null);
                PrinterIDLabel = new Label(PrinterID);
                PrinterID.DataField = "PrinterID";
                NumberOfCopies = new PXTextEdit("ctl00_phF_form_edNumberOfCopies", "Number of Copies", locator, null);
                NumberOfCopiesLabel = new Label(NumberOfCopies);
                NumberOfCopies.DataField = "NumberOfCopies";
                DataMemberName = "Filter";
            }
        }

        public class c_parameters_gridwizard : Container
        {

            public PxButtonCollection Buttons;

            public CheckBox IsDefault { get; }
            public Label IsDefaultLabel { get; }
            public CheckBox Override { get; }
            public Label OverrideLabel { get; }
            public Selector RoleName { get; }
            public Label RoleNameLabel { get; }

            public c_parameters_gridwizard(string locator, string name) :
                    base(locator, name)
            {
                IsDefault = new CheckBox("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_defaultCkbx", "Is Default", locator, null);
                IsDefaultLabel = new Label(IsDefault);
                IsDefault.DataField = "IsDefault";
                Override = new CheckBox("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_overrideCkbx", "Override", locator, null);
                OverrideLabel = new Label(Override);
                Override.DataField = "Override";
                RoleName = new Selector("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_edRole", "Role Name", locator, null);
                RoleNameLabel = new Label(RoleName);
                RoleName.DataField = "RoleName";
                DataMemberName = "Parameters";
                Buttons = new PxButtonCollection();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public virtual void Prev()
            {
                Buttons.Prev.Click();
            }

            public virtual void Next()
            {
                Buttons.Next.Click();
            }

            public virtual void Finish()
            {
                Buttons.Finish.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Cancel { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Finish { get; }

                public PxButtonCollection()
                {
                    Cancel = new Button("ctl00_usrCaption_shareColumnsDlg_gridWizard_cancel", "Cancel", "ctl00_usrCaption_shareColumnsDlg_gridWizard");
                    Prev = new Button("ctl00_usrCaption_shareColumnsDlg_gridWizard_prev", "Prev", "ctl00_usrCaption_shareColumnsDlg_gridWizard");
                    Next = new Button("ctl00_usrCaption_shareColumnsDlg_gridWizard_next", "Next", "ctl00_usrCaption_shareColumnsDlg_gridWizard");
                    Finish = new Button("ctl00_usrCaption_shareColumnsDlg_gridWizard_save", "Finish", "ctl00_usrCaption_shareColumnsDlg_gridWizard");
                }
            }
        }

        public class c_profilerinfoview_formprofiler : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit StartText { get; }
            public Label StartTextLabel { get; }
            public PXTextEdit Started { get; }
            public Label StartedLabel { get; }
            public PXTextEdit RequestsLogged { get; }
            public Label RequestsLoggedLabel { get; }
            public PXTextEdit ExportText { get; }
            public Label ExportTextLabel { get; }
            public Label PXLabel1_ { get; }
            public Label LblPlace_ { get; }

            public c_profilerinfoview_formprofiler(string locator, string name) :
                    base(locator, name)
            {
                StartText = new PXTextEdit("ctl00_usrCaption_pnlProfiler_formProfiler_lblStartText", "Start Text", locator, null);
                StartTextLabel = new Label(StartText);
                StartText.DataField = "StartText";
                Started = new PXTextEdit("ctl00_usrCaption_pnlProfiler_formProfiler_lblStartedAt", "Started", locator, null);
                StartedLabel = new Label(Started);
                Started.DataField = "Started";
                RequestsLogged = new PXTextEdit("ctl00_usrCaption_pnlProfiler_formProfiler_lblRequestsLogged", "Requests Logged", locator, null);
                RequestsLoggedLabel = new Label(RequestsLogged);
                RequestsLogged.DataField = "RequestsLogged";
                ExportText = new PXTextEdit("ctl00_usrCaption_pnlProfiler_formProfiler_lblExportText", "Export Text", locator, null);
                ExportTextLabel = new Label(ExportText);
                ExportText.DataField = "ExportText";
                PXLabel1_ = new Label("ctl00_usrCaption_pnlProfiler_formProfiler_PXLabel1", "PX Label 1_", locator, null);
                LblPlace_ = new Label("ctl00_usrCaption_pnlProfiler_formProfiler_lblPlace", "Lbl Place _", locator, null);
                DataMemberName = "ProfilerInfoView";
                Buttons = new PxButtonCollection();
            }

            public virtual void BtnStartProfiler()
            {
                Buttons.BtnStartProfiler.Click();
            }

            public virtual void BtnStopProfiler()
            {
                Buttons.BtnStopProfiler.Click();
            }

            public virtual void BtnLastRequest()
            {
                Buttons.BtnLastRequest.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button BtnStartProfiler { get; }
                public Button BtnStopProfiler { get; }
                public Button BtnLastRequest { get; }

                public PxButtonCollection()
                {
                    BtnStartProfiler = new Button("ctl00_usrCaption_pnlProfiler_formProfiler_btnStartProfiler", "btnStartProfiler", "ctl00_usrCaption_pnlProfiler_formProfiler");
                    BtnStopProfiler = new Button("ctl00_usrCaption_pnlProfiler_formProfiler_btnStopProfiler", "btnStopProfiler", "ctl00_usrCaption_pnlProfiler_formProfiler");
                    BtnLastRequest = new Button("ctl00_usrCaption_pnlProfiler_formProfiler_btnLastRequest", "btnLastRequest", "ctl00_usrCaption_pnlProfiler_formProfiler");
                }
            }
        }

        public class c_firstselect_formactions : Container
        {

            public PXTextEdit Key { get; }
            public Label KeyLabel { get; }

            public c_firstselect_formactions(string locator, string name) :
                    base(locator, name)
            {
                Key = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_PXSmartPanel1_FormActions_edKey", "Key", locator, null);
                KeyLabel = new Label(Key);
                Key.DataField = "Key";
                DataMemberName = "FirstSelect";
            }
        }

        public class c_comboboxvalues_gridcombos : Grid<c_comboboxvalues_gridcombos.c_grid_row, c_comboboxvalues_gridcombos.c_grid_header>
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            public c_grid_filter FilterForm { get; }

            public c_comboboxvalues_gridcombos(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos");
                DataMemberName = "ComboBoxValues";
                Buttons = new PxButtonCollection();
                FilterForm = new c_grid_filter("ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos_fe_gf", "FilterForm");
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

            public virtual void Hi()
            {
                ToolBar.Hi.Click();
            }

            public virtual void Close()
            {
                Buttons.Close.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid PageFirst { get; }
                public ToolBarButtonGrid PagePrev { get; }
                public ToolBarButtonGrid PageNext { get; }
                public ToolBarButtonGrid PageLast { get; }
                public ToolBarButtonGrid Hi { get; }

                public PxToolBar(string locator)
                {
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos_ab" +
                            "_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos_ab" +
                            "_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos_ab" +
                            "_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos_ab" +
                            "_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos_ab" +
                            "_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Close { get; }

                public PxButtonCollection()
                {
                    Close = new Button("ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_PXButton5", "Close", "ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos");
                }
            }

            public class c_grid_row : GridRow
            {

                public PXTextEdit Value { get; }
                public PXTextEdit Description { get; }

                public c_grid_row(c_comboboxvalues_gridcombos grid) :
                        base(grid)
                {
                    Value = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos_ei", "Value", grid.Locator, "Value");
                    Value.DataField = "Value";
                    Description = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_ComboBoxValuesDictDialog_gridCombos_ei", "Description", grid.Locator, "Description");
                    Description.DataField = "Description";
                }
            }

            public class c_grid_header : GridHeader
            {

                public PXTextEditColumnFilter Value { get; }
                public PXTextEditColumnFilter Description { get; }

                public c_grid_header(c_comboboxvalues_gridcombos grid) :
                        base(grid)
                {
                    Value = new PXTextEditColumnFilter(grid.Row.Value);
                    Description = new PXTextEditColumnFilter(grid.Row.Description);
                }
            }
        }

        public class c_vieweleminfo_formeleminfo : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit AspxControl { get; }
            public Label AspxControlLabel { get; }
            public GroupBox IsComboBox { get; }
            public Label IsComboBoxLabel { get; }
            public PXTextEdit CacheType { get; }
            public Label CacheTypeLabel { get; }
            public PXTextEdit FieldName { get; }
            public Label FieldNameLabel { get; }
            public PXTextEdit ViewName { get; }
            public Label ViewNameLabel { get; }
            public PXTextEdit GraphName { get; }
            public Label GraphNameLabel { get; }
            public PXTextEdit ActionName { get; }
            public Label ActionNameLabel { get; }

            public c_vieweleminfo_formeleminfo(string locator, string name) :
                    base(locator, name)
            {
                AspxControl = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo_edAspxControl", "Control Type", locator, null);
                AspxControlLabel = new Label(AspxControl);
                AspxControl.DataField = "AspxControl";
                IsComboBox = new GroupBox("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo_panelPXBUtton1", "Is Combo Box", locator, null);
                IsComboBoxLabel = new Label(IsComboBox);
                IsComboBox.DataField = "IsComboBox";
                CacheType = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo_CacheType", "Data Class", locator, null);
                CacheTypeLabel = new Label(CacheType);
                CacheType.DataField = "CacheType";
                FieldName = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo_FieldName", "Data Field", locator, null);
                FieldNameLabel = new Label(FieldName);
                FieldName.DataField = "FieldName";
                ViewName = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo_ViewName", "View Name", locator, null);
                ViewNameLabel = new Label(ViewName);
                ViewName.DataField = "ViewName";
                GraphName = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo_GraphName", "Business Logic", locator, null);
                GraphNameLabel = new Label(GraphName);
                GraphName.DataField = "GraphName";
                ActionName = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo_ActionName", "Action Name", locator, null);
                ActionNameLabel = new Label(ActionName);
                ActionName.DataField = "ActionName";
                DataMemberName = "ViewElemInfo";
                Buttons = new PxButtonCollection();
            }

            public virtual void Drop_downValues()
            {
                Buttons.Drop_downValues.Click();
            }

            public virtual void Customize()
            {
                Buttons.Customize.Click();
            }

            public virtual void Actions()
            {
                Buttons.Actions.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Drop_downValues { get; }
                public Button Customize { get; }
                public Button Actions { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    Drop_downValues = new Button("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo_panelPXBUtton1_P" +
                            "XButton1", "Drop-down Values", "ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo");
                    Customize = new Button("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_PXButton3", "Customize", "ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo");
                    Actions = new Button("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_ButtonGraphActions", "Actions", "ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo");
                    Cancel = new Button("ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_PXButton4", "Cancel", "ctl00_usrCaption_CustomizationDialogs_PanelElemInfo_FormElemInfo");
                }
            }
        }

        public class c_filterworkingproject_formnewproject : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit NewProject { get; }
            public Label NewProjectLabel { get; }

            public c_filterworkingproject_formnewproject(string locator, string name) :
                    base(locator, name)
            {
                NewProject = new PXTextEdit("ctl00_usrCaption_CustomizationDialogs_DlgNewProject_FormNewProject_edNewProject", "Project Name", locator, null);
                NewProjectLabel = new Label(NewProject);
                NewProject.DataField = "NewProject";
                DataMemberName = "FilterWorkingProject";
                Buttons = new PxButtonCollection();
            }

            public virtual void Ok()
            {
                Buttons.Ok.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Ok { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    Ok = new Button("ctl00_usrCaption_CustomizationDialogs_DlgNewProject_DlgNewProjectButtonOk", "OK", "ctl00_usrCaption_CustomizationDialogs_DlgNewProject_FormNewProject");
                    Cancel = new Button("ctl00_usrCaption_CustomizationDialogs_DlgNewProject_DlgNewProjectButtonCancel", "Cancel", "ctl00_usrCaption_CustomizationDialogs_DlgNewProject_FormNewProject");
                }
            }
        }

        public class c_filterworkingproject_formselectproject : Container
        {

            public PxButtonCollection Buttons;

            public Selector Name { get; }
            public Label NameLabel { get; }

            public c_filterworkingproject_formselectproject(string locator, string name) :
                    base(locator, name)
            {
                Name = new Selector("ctl00_usrCaption_CustomizationDialogs_WizardSelectProject_FormSelectProject_edWP", "Project Name", locator, null);
                NameLabel = new Label(Name);
                Name.DataField = "Name";
                DataMemberName = "FilterWorkingProject";
                Buttons = new PxButtonCollection();
            }

            public virtual void Ok()
            {
                Buttons.Ok.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public virtual void New()
            {
                Buttons.New.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Ok { get; }
                public Button Cancel { get; }
                public Button New { get; }

                public PxButtonCollection()
                {
                    Ok = new Button("ctl00_usrCaption_CustomizationDialogs_WizardSelectProject_SelectProjectOk", "OK", "ctl00_usrCaption_CustomizationDialogs_WizardSelectProject_FormSelectProject");
                    Cancel = new Button("ctl00_usrCaption_CustomizationDialogs_WizardSelectProject_SelectProjectCancel", "Cancel", "ctl00_usrCaption_CustomizationDialogs_WizardSelectProject_FormSelectProject");
                    New = new Button("ctl00_usrCaption_CustomizationDialogs_WizardSelectProject_BtnNewProject", "New...", "ctl00_usrCaption_CustomizationDialogs_WizardSelectProject_FormSelectProject");
                }
            }
        }

        public class c_gridlist_gridgrid : Grid<c_gridlist_gridgrid.c_grid_row, c_gridlist_gridgrid.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_gridlist_gridgrid(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid");
                DataMemberName = "GridList";
                FilterForm = new c_grid_filter("ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid_fe_gf", "FilterForm");
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

            public virtual void Hi()
            {
                ToolBar.Hi.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid PageFirst { get; }
                public ToolBarButtonGrid PagePrev { get; }
                public ToolBarButtonGrid PageNext { get; }
                public ToolBarButtonGrid PageLast { get; }
                public ToolBarButtonGrid Hi { get; }

                public PxToolBar(string locator)
                {
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid_ab_tlb div[data-cmd=" +
                            "\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid_ab_tlb div[data-cmd=" +
                            "\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid_ab_tlb div[data-cmd=" +
                            "\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid_ab_tlb div[data-cmd=" +
                            "\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid_ab_tlb div[data-cmd=" +
                            "\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public CheckBox Selected { get; }
                public PXTextEdit View { get; }
                public PXTextEdit Id { get; }

                public c_grid_row(c_gridlist_gridgrid grid) :
                        base(grid)
                {
                    Selected = new CheckBox("ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid_ef", "Included", grid.Locator, "Selected");
                    Selected.DataField = "Selected";
                    View = new PXTextEdit("ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid_ei", "Table ID", grid.Locator, "View");
                    View.DataField = "View";
                    Id = new PXTextEdit("ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid_ei", "Grid ID", grid.Locator, "Id");
                    Id.DataField = "Id";
                }
            }

            public class c_grid_header : GridHeader
            {

                public CheckBoxColumnFilter Selected { get; }
                public PXTextEditColumnFilter View { get; }
                public PXTextEditColumnFilter Id { get; }

                public c_grid_header(c_gridlist_gridgrid grid) :
                        base(grid)
                {
                    Selected = new CheckBoxColumnFilter(grid.Row.Selected);
                    View = new PXTextEditColumnFilter(grid.Row.View);
                    Id = new PXTextEditColumnFilter(grid.Row.Id);
                }
            }
        }

        public class c_userlist_usergrid : Grid<c_userlist_usergrid.c_grid_row, c_userlist_usergrid.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_userlist_usergrid(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid");
                DataMemberName = "UserList";
                FilterForm = new c_grid_filter("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_fe_gf", "FilterForm");
            }

            public virtual void Refresh()
            {
                ToolBar.Refresh.Click();
            }

            public virtual void New()
            {
                ToolBar.New.Click();
            }

            public virtual void Delete()
            {
                ToolBar.Delete.Click();
            }

            public virtual void Adjust()
            {
                ToolBar.Adjust.Click();
            }

            public virtual void Export()
            {
                ToolBar.Export.Click();
            }

            public virtual void Hi()
            {
                ToolBar.Hi.Click();
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

            public virtual void Hi1()
            {
                ToolBar.Hi1.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid New { get; }
                public ToolBarButtonGrid Delete { get; }
                public ToolBarButtonGrid Adjust { get; }
                public ToolBarButtonGrid Export { get; }
                public ToolBarButtonGrid Hi { get; }
                public ToolBarButtonGrid PageFirst { get; }
                public ToolBarButtonGrid PagePrev { get; }
                public ToolBarButtonGrid PageNext { get; }
                public ToolBarButtonGrid PageLast { get; }
                public ToolBarButtonGrid Hi1 { get; }

                public PxToolBar(string locator)
                {
                    Refresh = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_at_tlb div[data-cmd=" +
                            "\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_at_tlb div[data-cmd=" +
                            "\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_at_tlb div[data-cmd=" +
                            "\'Delete\']", "Delete Row", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_at_tlb div[data-cmd=" +
                            "\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_at_tlb div[data-cmd=" +
                            "\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_at_tlb div[data-cmd=" +
                            "\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_ab_tlb div[data-cmd=" +
                            "\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_ab_tlb div[data-cmd=" +
                            "\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_ab_tlb div[data-cmd=" +
                            "\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_ab_tlb div[data-cmd=" +
                            "\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_ab_tlb div[data-cmd=" +
                            "\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public CheckBox Included { get; }
                public Selector Username { get; }
                public PXTextEdit DisplayName { get; }
                public PXTextEdit Email { get; }
                public PXTextEdit Guest { get; }
                public DropDown State { get; }

                public c_grid_row(c_userlist_usergrid grid) :
                        base(grid)
                {
                    Included = new CheckBox("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_ef", "Included", grid.Locator, "Included");
                    Included.DataField = "Included";
                    Username = new Selector("_ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_lv0_es", "Login", grid.Locator, "Username");
                    Username.DataField = "Username";
                    DisplayName = new PXTextEdit("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_ei", "Display Name", grid.Locator, "DisplayName");
                    DisplayName.DataField = "DisplayName";
                    Email = new PXTextEdit("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_ei", "Email", grid.Locator, "Email");
                    Email.DataField = "Email";
                    Guest = new PXTextEdit("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_ef", "Guest Account", grid.Locator, "Guest");
                    Guest.DataField = "Guest";
                    State = new DropDown("_ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_lv0_ec", "Status", grid.Locator, "State");
                    State.DataField = "State";
                    State.Items.Add("N", "Not Created");
                    State.Items.Add("O", "Online");
                    State.Items.Add("P", "Pending Activation");
                    State.Items.Add("D", "Disabled");
                    State.Items.Add("A", "Active");
                    State.Items.Add("L", "Temporarily Locked");
                }
            }

            public class c_grid_header : GridHeader
            {

                public CheckBoxColumnFilter Included { get; }
                public SelectorColumnFilter Username { get; }
                public PXTextEditColumnFilter DisplayName { get; }
                public PXTextEditColumnFilter Email { get; }
                public PXTextEditColumnFilter Guest { get; }
                public DropDownColumnFilter State { get; }

                public c_grid_header(c_userlist_usergrid grid) :
                        base(grid)
                {
                    Included = new CheckBoxColumnFilter(grid.Row.Included);
                    Username = new SelectorColumnFilter(grid.Row.Username);
                    DisplayName = new PXTextEditColumnFilter(grid.Row.DisplayName);
                    Email = new PXTextEditColumnFilter(grid.Row.Email);
                    Guest = new PXTextEditColumnFilter(grid.Row.Guest);
                    State = new DropDownColumnFilter(grid.Row.State);
                }
            }
        }

        public class c_userlist_lv0 : Container
        {

            public Selector Es { get; }
            public Label EsLabel { get; }
            public DropDown Ec { get; }

            public c_userlist_lv0(string locator, string name) :
                    base(locator, name)
            {
                Es = new Selector("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Ec = new DropDown("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_lv0_ec", "Ec", locator, null);
                DataMemberName = "UserList";
            }
        }

        public class c_processingview_griddetails : Grid<c_processingview_griddetails.c_grid_row, c_processingview_griddetails.c_grid_header>
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            public c_grid_filter FilterForm { get; }
            public SmartPanel_AttachFile FilesUploadDialog { get; }
            public Note NotePanel { get; }

            public c_processingview_griddetails(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails");
                DataMemberName = "ProcessingView";
                Buttons = new PxButtonCollection();
                FilterForm = new c_grid_filter("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_fe_gf", "FilterForm");
                FilesUploadDialog = new SmartPanel_AttachFile(locator);
                NotePanel = new Note(locator);
            }

            public virtual void Refresh()
            {
                ToolBar.Refresh.Click();
            }

            public virtual void Adjust()
            {
                ToolBar.Adjust.Click();
            }

            public virtual void Export()
            {
                ToolBar.Export.Click();
            }

            public virtual void Hi()
            {
                ToolBar.Hi.Click();
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

            public virtual void Hi1()
            {
                ToolBar.Hi1.Click();
            }

            public virtual void CancelProcessing()
            {
                Buttons.CancelProcessing.Click();
            }

            public virtual void Close()
            {
                Buttons.Close.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid Adjust { get; }
                public ToolBarButtonGrid Export { get; }
                public ToolBarButtonGrid Hi { get; }
                public ToolBarButtonGrid PageFirst { get; }
                public ToolBarButtonGrid PagePrev { get; }
                public ToolBarButtonGrid PageNext { get; }
                public ToolBarButtonGrid PageLast { get; }
                public ToolBarButtonGrid Hi1 { get; }

                public PxToolBar(string locator)
                {
                    Refresh = new ToolBarButtonGrid("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_at_tlb div[data" +
                            "-cmd=\'Refresh\']", "Refresh", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_at_tlb div[data" +
                            "-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_at_tlb div[data" +
                            "-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_at_tlb div[data" +
                            "-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ab_tlb div[data" +
                            "-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ab_tlb div[data" +
                            "-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ab_tlb div[data" +
                            "-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ab_tlb div[data" +
                            "-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ab_tlb div[data" +
                            "-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button CancelProcessing { get; }
                public Button Close { get; }

                public PxButtonCollection()
                {
                    CancelProcessing = new Button("ctl00_usrCaption_ProcessingDialogs_PanelProgress_BtnCancelProcessing", "Cancel Processing", "ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails");
                    Close = new Button("ctl00_usrCaption_ProcessingDialogs_PanelProgress_BtnDone", "Close", "ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails");
                }
            }

            public class c_grid_row : GridRow
            {

                public FileColumnButton Files { get; }
                public NoteColumnButton Notes { get; }
                public PXTextEdit ProcessingStatus { get; }
                public PXTextEdit ProcessingMessage { get; }
                public Selector ShipmentNbr { get; }
                public DropDown Status { get; }
                public DateSelector ShipDate { get; }
                public Selector CustomerID { get; }
                public PXTextEdit CustomerID_BAccountR_acctName { get; }
                public Selector CustomerLocationID { get; }
                public PXTextEdit CustomerLocationID_Location_descr { get; }
                public PXTextEdit CustomerOrderNbr { get; }
                public CheckBox BillSeparately { get; }
                public Selector SiteID { get; }
                public PXTextEdit SiteID_INSite_descr { get; }
                public Selector WorkgroupID { get; }
                public Selector OwnerID { get; }
                public PXNumberEdit ShipmentQty { get; }
                public Selector ShipVia { get; }
                public PXTextEdit ShipVia_Carrier_description { get; }
                public PXNumberEdit ShipmentWeight { get; }
                public PXNumberEdit ShipmentVolume { get; }
                public CheckBox LabelsPrinted { get; }

                public c_grid_row(c_processingview_griddetails grid) :
                        base(grid)
                {
                    Files = new FileColumnButton(null, "Files", grid.Locator, "Files");
                    Notes = new NoteColumnButton(null, "Notes", grid.Locator, "Notes");
                    ProcessingStatus = new PXTextEdit("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ei", "Status", grid.Locator, "ProcessingStatus");
                    ProcessingStatus.DataField = "ProcessingStatus";
                    ProcessingMessage = new PXTextEdit("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ei", "Message", grid.Locator, "ProcessingMessage");
                    ProcessingMessage.DataField = "ProcessingMessage";
                    ShipmentNbr = new Selector("_ctl00_phG_grid_lv0_edShipmentNbr", "Shipment Nbr.", grid.Locator, "ShipmentNbr");
                    ShipmentNbr.DataField = "ShipmentNbr";
                    Status = new DropDown("_ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_lv0_ec", "Status", grid.Locator, "Status");
                    Status.DataField = "Status";
                    Status.Items.Add("N", "Open");
                    Status.Items.Add("H", "On Hold");
                    Status.Items.Add("C", "Completed");
                    Status.Items.Add("L", "Canceled");
                    Status.Items.Add("F", "Confirmed");
                    Status.Items.Add("I", "Invoiced");
                    Status.Items.Add("Y", "Partially Invoiced");
                    Status.Items.Add("R", "Receipted");
                    Status.Items.Add("A", "Auto-Generated");
                    Status.Items.Add("W", "Partially Routed");
                    Status.Items.Add("P", "Route Planning");
                    Status.Items.Add("S", "Route Assigned");
                    Status.Items.Add("D", "Route Delivered");
                    Status.Items.Add("E", "Route Error");
                    ShipDate = new DateSelector("_ctl00_phG_grid_lv0_edShipDate", "Shipment Date", grid.Locator, "ShipDate");
                    ShipDate.DataField = "ShipDate";
                    CustomerID = new Selector("_ctl00_phG_grid_lv0_edCustomerID", "Customer", grid.Locator, "CustomerID");
                    CustomerID.DataField = "CustomerID";
                    CustomerID_BAccountR_acctName = new PXTextEdit("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ei", "Customer Name", grid.Locator, "CustomerID_BAccountR_acctName");
                    CustomerID_BAccountR_acctName.DataField = "CustomerID_BAccountR_acctName";
                    CustomerLocationID = new Selector("_ctl00_phG_grid_lv0_edCustomerLocationID", "Location", grid.Locator, "CustomerLocationID");
                    CustomerLocationID.DataField = "CustomerLocationID";
                    CustomerLocationID_Location_descr = new PXTextEdit("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ei", "Location Name", grid.Locator, "CustomerLocationID_Location_descr");
                    CustomerLocationID_Location_descr.DataField = "CustomerLocationID_Location_descr";
                    CustomerOrderNbr = new PXTextEdit("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ei", "Customer Order Nbr.", grid.Locator, "CustomerOrderNbr");
                    CustomerOrderNbr.DataField = "CustomerOrderNbr";
                    BillSeparately = new CheckBox("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails", "Bill Separately", grid.Locator, "BillSeparately");
                    BillSeparately.DataField = "BillSeparately";
                    SiteID = new Selector("_ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_lv0_es", "Warehouse ID", grid.Locator, "SiteID");
                    SiteID.DataField = "SiteID";
                    SiteID_INSite_descr = new PXTextEdit("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ei", "Warehouse Description", grid.Locator, "SiteID_INSite_descr");
                    SiteID_INSite_descr.DataField = "SiteID_INSite_descr";
                    WorkgroupID = new Selector("_ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_lv0_es", "Workgroup", grid.Locator, "WorkgroupID");
                    WorkgroupID.DataField = "WorkgroupID";
                    OwnerID = new Selector("_ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_lv0_es", "Owner", grid.Locator, "OwnerID");
                    OwnerID.DataField = "OwnerID";
                    ShipmentQty = new PXNumberEdit("_ctl00_phG_grid_lv0_edShipmentQty", "Shipped Quantity", grid.Locator, "ShipmentQty");
                    ShipmentQty.DataField = "ShipmentQty";
                    ShipVia = new Selector("_ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_lv0_es", "Ship Via", grid.Locator, "ShipVia");
                    ShipVia.DataField = "ShipVia";
                    ShipVia_Carrier_description = new PXTextEdit("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_ei", "Ship Via Description", grid.Locator, "ShipVia_Carrier_description");
                    ShipVia_Carrier_description.DataField = "ShipVia_Carrier_description";
                    ShipmentWeight = new PXNumberEdit("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_en", "Shipped Weight", grid.Locator, "ShipmentWeight");
                    ShipmentWeight.DataField = "ShipmentWeight";
                    ShipmentVolume = new PXNumberEdit("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails_en", "Shipped Volume", grid.Locator, "ShipmentVolume");
                    ShipmentVolume.DataField = "ShipmentVolume";
                    LabelsPrinted = new CheckBox("ctl00_usrCaption_ProcessingDialogs_PanelProgress_gridDetails", "Labels Printed", grid.Locator, "LabelsPrinted");
                    LabelsPrinted.DataField = "LabelsPrinted";
                }
            }

            public class c_grid_header : GridHeader
            {

                public GridColumnHeader Files { get; }
                public GridColumnHeader Notes { get; }
                public PXTextEditColumnFilter ProcessingStatus { get; }
                public PXTextEditColumnFilter ProcessingMessage { get; }
                public SelectorColumnFilter ShipmentNbr { get; }
                public DropDownColumnFilter Status { get; }
                public DateSelectorColumnFilter ShipDate { get; }
                public SelectorColumnFilter CustomerID { get; }
                public PXTextEditColumnFilter CustomerID_BAccountR_acctName { get; }
                public SelectorColumnFilter CustomerLocationID { get; }
                public PXTextEditColumnFilter CustomerLocationID_Location_descr { get; }
                public PXTextEditColumnFilter CustomerOrderNbr { get; }
                public CheckBoxColumnFilter BillSeparately { get; }
                public SelectorColumnFilter SiteID { get; }
                public PXTextEditColumnFilter SiteID_INSite_descr { get; }
                public SelectorColumnFilter WorkgroupID { get; }
                public SelectorColumnFilter OwnerID { get; }
                public PXNumberEditColumnFilter ShipmentQty { get; }
                public SelectorColumnFilter ShipVia { get; }
                public PXTextEditColumnFilter ShipVia_Carrier_description { get; }
                public PXNumberEditColumnFilter ShipmentWeight { get; }
                public PXNumberEditColumnFilter ShipmentVolume { get; }
                public CheckBoxColumnFilter LabelsPrinted { get; }

                public c_grid_header(c_processingview_griddetails grid) :
                        base(grid)
                {
                    Files = new GridColumnHeader(grid.Row.Files);
                    Notes = new GridColumnHeader(grid.Row.Notes);
                    ProcessingStatus = new PXTextEditColumnFilter(grid.Row.ProcessingStatus);
                    ProcessingMessage = new PXTextEditColumnFilter(grid.Row.ProcessingMessage);
                    ShipmentNbr = new SelectorColumnFilter(grid.Row.ShipmentNbr);
                    Status = new DropDownColumnFilter(grid.Row.Status);
                    ShipDate = new DateSelectorColumnFilter(grid.Row.ShipDate);
                    CustomerID = new SelectorColumnFilter(grid.Row.CustomerID);
                    CustomerID_BAccountR_acctName = new PXTextEditColumnFilter(grid.Row.CustomerID_BAccountR_acctName);
                    CustomerLocationID = new SelectorColumnFilter(grid.Row.CustomerLocationID);
                    CustomerLocationID_Location_descr = new PXTextEditColumnFilter(grid.Row.CustomerLocationID_Location_descr);
                    CustomerOrderNbr = new PXTextEditColumnFilter(grid.Row.CustomerOrderNbr);
                    BillSeparately = new CheckBoxColumnFilter(grid.Row.BillSeparately);
                    SiteID = new SelectorColumnFilter(grid.Row.SiteID);
                    SiteID_INSite_descr = new PXTextEditColumnFilter(grid.Row.SiteID_INSite_descr);
                    WorkgroupID = new SelectorColumnFilter(grid.Row.WorkgroupID);
                    OwnerID = new SelectorColumnFilter(grid.Row.OwnerID);
                    ShipmentQty = new PXNumberEditColumnFilter(grid.Row.ShipmentQty);
                    ShipVia = new SelectorColumnFilter(grid.Row.ShipVia);
                    ShipVia_Carrier_description = new PXTextEditColumnFilter(grid.Row.ShipVia_Carrier_description);
                    ShipmentWeight = new PXNumberEditColumnFilter(grid.Row.ShipmentWeight);
                    ShipmentVolume = new PXNumberEditColumnFilter(grid.Row.ShipmentVolume);
                    LabelsPrinted = new CheckBoxColumnFilter(grid.Row.LabelsPrinted);
                }
            }
        }

        public class c_orders_grid : Grid<c_orders_grid.c_grid_row, c_orders_grid.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }
            public SmartPanel_AttachFile FilesUploadDialog { get; }
            public Note NotePanel { get; }

            public c_orders_grid(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_grid");
                DataMemberName = "Orders";
                FilterForm = new c_grid_filter("ctl00_phG_grid_fe_gf", "FilterForm");
                FilesUploadDialog = new SmartPanel_AttachFile(locator);
                NotePanel = new Note(locator);
            }

            public virtual void AllRecords()
            {
                ToolBar.AllRecords.Click();
            }

            public virtual void Edit()
            {
                ToolBar.Edit.Click();
            }

            public virtual void Hi()
            {
                ToolBar.Hi.Click();
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

            public virtual void Hi1()
            {
                ToolBar.Hi1.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid AllRecords { get; }
                public ToolBarButtonGrid Edit { get; }
                public ToolBarButtonGrid Hi { get; }
                public ToolBarButtonGrid PageFirst { get; }
                public ToolBarButtonGrid PagePrev { get; }
                public ToolBarButtonGrid PageNext { get; }
                public ToolBarButtonGrid PageLast { get; }
                public ToolBarButtonGrid Hi1 { get; }

                public PxToolBar(string locator)
                {
                    AllRecords = new ToolBarButtonGrid("css=#ctl00_phG_grid_at_ft div[data-cmd=\'all\']", "All Records", locator, null);
                    Edit = new ToolBarButtonGrid("css=#ctl00_phG_grid_at_ft div[data-cmd=\'edit\']", "Edit", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_grid_at_ft div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_grid_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_grid_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_grid_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_grid_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_grid_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public FileColumnButton Files { get; }
                public NoteColumnButton Notes { get; }
                public CheckBox Selected { get; }
                public Selector ShipmentNbr { get; }
                public DropDown Status { get; }
                public DateSelector ShipDate { get; }
                public Selector CustomerID { get; }
                public PXTextEdit CustomerID_BAccountR_acctName { get; }
                public Selector CustomerLocationID { get; }
                public PXTextEdit CustomerLocationID_Location_descr { get; }
                public PXTextEdit CustomerOrderNbr { get; }
                public CheckBox BillSeparately { get; }
                public Selector SiteID { get; }
                public PXTextEdit SiteID_INSite_descr { get; }
                public Selector WorkgroupID { get; }
                public Selector OwnerID { get; }
                public PXNumberEdit ShipmentQty { get; }
                public Selector ShipVia { get; }
                public PXTextEdit ShipVia_Carrier_description { get; }
                public PXNumberEdit ShipmentWeight { get; }
                public PXNumberEdit ShipmentVolume { get; }
                public CheckBox LabelsPrinted { get; }

                public c_grid_row(c_orders_grid grid) :
                        base(grid)
                {
                    Files = new FileColumnButton(null, "Files", grid.Locator, "Files");
                    Notes = new NoteColumnButton(null, "Notes", grid.Locator, "Notes");
                    Selected = new CheckBox("_ctl00_phG_grid_lv0_chkSelected", "Selected", grid.Locator, "Selected");
                    Selected.DataField = "Selected";
                    ShipmentNbr = new Selector("_ctl00_phG_grid_lv0_edShipmentNbr", "Shipment Nbr.", grid.Locator, "ShipmentNbr");
                    ShipmentNbr.DataField = "ShipmentNbr";
                    Status = new DropDown("_ctl00_phG_grid_lv0_ec", "Status", grid.Locator, "Status");
                    Status.DataField = "Status";
                    Status.Items.Add("N", "Open");
                    Status.Items.Add("H", "On Hold");
                    Status.Items.Add("C", "Completed");
                    Status.Items.Add("L", "Canceled");
                    Status.Items.Add("F", "Confirmed");
                    Status.Items.Add("I", "Invoiced");
                    Status.Items.Add("Y", "Partially Invoiced");
                    Status.Items.Add("R", "Receipted");
                    Status.Items.Add("A", "Auto-Generated");
                    Status.Items.Add("W", "Partially Routed");
                    Status.Items.Add("P", "Route Planning");
                    Status.Items.Add("S", "Route Assigned");
                    Status.Items.Add("D", "Route Delivered");
                    Status.Items.Add("E", "Route Error");
                    ShipDate = new DateSelector("_ctl00_phG_grid_lv0_edShipDate", "Shipment Date", grid.Locator, "ShipDate");
                    ShipDate.DataField = "ShipDate";
                    CustomerID = new Selector("_ctl00_phG_grid_lv0_edCustomerID", "Customer", grid.Locator, "CustomerID");
                    CustomerID.DataField = "CustomerID";
                    CustomerID_BAccountR_acctName = new PXTextEdit("ctl00_phG_grid_ei", "Customer Name", grid.Locator, "CustomerID_BAccountR_acctName");
                    CustomerID_BAccountR_acctName.DataField = "CustomerID_BAccountR_acctName";
                    CustomerLocationID = new Selector("_ctl00_phG_grid_lv0_edCustomerLocationID", "Location", grid.Locator, "CustomerLocationID");
                    CustomerLocationID.DataField = "CustomerLocationID";
                    CustomerLocationID_Location_descr = new PXTextEdit("ctl00_phG_grid_ei", "Location Name", grid.Locator, "CustomerLocationID_Location_descr");
                    CustomerLocationID_Location_descr.DataField = "CustomerLocationID_Location_descr";
                    CustomerOrderNbr = new PXTextEdit("ctl00_phG_grid_ei", "Customer Order Nbr.", grid.Locator, "CustomerOrderNbr");
                    CustomerOrderNbr.DataField = "CustomerOrderNbr";
                    BillSeparately = new CheckBox("ctl00_phG_grid", "Bill Separately", grid.Locator, "BillSeparately");
                    BillSeparately.DataField = "BillSeparately";
                    SiteID = new Selector("_ctl00_phG_grid_lv0_es", "Warehouse ID", grid.Locator, "SiteID");
                    SiteID.DataField = "SiteID";
                    SiteID_INSite_descr = new PXTextEdit("ctl00_phG_grid_ei", "Warehouse Description", grid.Locator, "SiteID_INSite_descr");
                    SiteID_INSite_descr.DataField = "SiteID_INSite_descr";
                    WorkgroupID = new Selector("_ctl00_phG_grid_lv0_es", "Workgroup", grid.Locator, "WorkgroupID");
                    WorkgroupID.DataField = "WorkgroupID";
                    OwnerID = new Selector("_ctl00_phG_grid_lv0_es", "Owner", grid.Locator, "OwnerID");
                    OwnerID.DataField = "OwnerID";
                    ShipmentQty = new PXNumberEdit("_ctl00_phG_grid_lv0_edShipmentQty", "Shipped Quantity", grid.Locator, "ShipmentQty");
                    ShipmentQty.DataField = "ShipmentQty";
                    ShipVia = new Selector("_ctl00_phG_grid_lv0_es", "Ship Via", grid.Locator, "ShipVia");
                    ShipVia.DataField = "ShipVia";
                    ShipVia_Carrier_description = new PXTextEdit("ctl00_phG_grid_ei", "Ship Via Description", grid.Locator, "ShipVia_Carrier_description");
                    ShipVia_Carrier_description.DataField = "ShipVia_Carrier_description";
                    ShipmentWeight = new PXNumberEdit("ctl00_phG_grid_en", "Shipped Weight", grid.Locator, "ShipmentWeight");
                    ShipmentWeight.DataField = "ShipmentWeight";
                    ShipmentVolume = new PXNumberEdit("ctl00_phG_grid_en", "Shipped Volume", grid.Locator, "ShipmentVolume");
                    ShipmentVolume.DataField = "ShipmentVolume";
                    LabelsPrinted = new CheckBox("ctl00_phG_grid", "Labels Printed", grid.Locator, "LabelsPrinted");
                    LabelsPrinted.DataField = "LabelsPrinted";
                }
            }

            public class c_grid_header : GridHeader
            {

                public GridColumnHeader Files { get; }
                public GridColumnHeader Notes { get; }
                public CheckBoxColumnFilter Selected { get; }
                public SelectorColumnFilter ShipmentNbr { get; }
                public DropDownColumnFilter Status { get; }
                public DateSelectorColumnFilter ShipDate { get; }
                public SelectorColumnFilter CustomerID { get; }
                public PXTextEditColumnFilter CustomerID_BAccountR_acctName { get; }
                public SelectorColumnFilter CustomerLocationID { get; }
                public PXTextEditColumnFilter CustomerLocationID_Location_descr { get; }
                public PXTextEditColumnFilter CustomerOrderNbr { get; }
                public CheckBoxColumnFilter BillSeparately { get; }
                public SelectorColumnFilter SiteID { get; }
                public PXTextEditColumnFilter SiteID_INSite_descr { get; }
                public SelectorColumnFilter WorkgroupID { get; }
                public SelectorColumnFilter OwnerID { get; }
                public PXNumberEditColumnFilter ShipmentQty { get; }
                public SelectorColumnFilter ShipVia { get; }
                public PXTextEditColumnFilter ShipVia_Carrier_description { get; }
                public PXNumberEditColumnFilter ShipmentWeight { get; }
                public PXNumberEditColumnFilter ShipmentVolume { get; }
                public CheckBoxColumnFilter LabelsPrinted { get; }

                public c_grid_header(c_orders_grid grid) :
                        base(grid)
                {
                    Files = new GridColumnHeader(grid.Row.Files);
                    Notes = new GridColumnHeader(grid.Row.Notes);
                    Selected = new CheckBoxColumnFilter(grid.Row.Selected);
                    ShipmentNbr = new SelectorColumnFilter(grid.Row.ShipmentNbr);
                    Status = new DropDownColumnFilter(grid.Row.Status);
                    ShipDate = new DateSelectorColumnFilter(grid.Row.ShipDate);
                    CustomerID = new SelectorColumnFilter(grid.Row.CustomerID);
                    CustomerID_BAccountR_acctName = new PXTextEditColumnFilter(grid.Row.CustomerID_BAccountR_acctName);
                    CustomerLocationID = new SelectorColumnFilter(grid.Row.CustomerLocationID);
                    CustomerLocationID_Location_descr = new PXTextEditColumnFilter(grid.Row.CustomerLocationID_Location_descr);
                    CustomerOrderNbr = new PXTextEditColumnFilter(grid.Row.CustomerOrderNbr);
                    BillSeparately = new CheckBoxColumnFilter(grid.Row.BillSeparately);
                    SiteID = new SelectorColumnFilter(grid.Row.SiteID);
                    SiteID_INSite_descr = new PXTextEditColumnFilter(grid.Row.SiteID_INSite_descr);
                    WorkgroupID = new SelectorColumnFilter(grid.Row.WorkgroupID);
                    OwnerID = new SelectorColumnFilter(grid.Row.OwnerID);
                    ShipmentQty = new PXNumberEditColumnFilter(grid.Row.ShipmentQty);
                    ShipVia = new SelectorColumnFilter(grid.Row.ShipVia);
                    ShipVia_Carrier_description = new PXTextEditColumnFilter(grid.Row.ShipVia_Carrier_description);
                    ShipmentWeight = new PXNumberEditColumnFilter(grid.Row.ShipmentWeight);
                    ShipmentVolume = new PXNumberEditColumnFilter(grid.Row.ShipmentVolume);
                    LabelsPrinted = new CheckBoxColumnFilter(grid.Row.LabelsPrinted);
                }
            }
        }

        public class c_orders_lv0 : Container
        {

            public CheckBox Selected { get; }
            public Label SelectedLabel { get; }
            public Selector ShipmentNbr { get; }
            public Label ShipmentNbrLabel { get; }
            public Selector CustomerID { get; }
            public Label CustomerIDLabel { get; }
            public Selector CustomerLocationID { get; }
            public Label CustomerLocationIDLabel { get; }
            public DateSelector ShipDate { get; }
            public Label ShipDateLabel { get; }
            public Selector CuryID { get; }
            public Label CuryIDLabel { get; }
            public PXNumberEdit ShipmentQty { get; }
            public Label ShipmentQtyLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }
            public DropDown Ec { get; }

            public c_orders_lv0(string locator, string name) :
                    base(locator, name)
            {
                Selected = new CheckBox("ctl00_phG_grid_lv0_chkSelected", "Selected", locator, null);
                SelectedLabel = new Label(Selected);
                Selected.DataField = "Selected";
                ShipmentNbr = new Selector("ctl00_phG_grid_lv0_edShipmentNbr", "Shipment Nbr.", locator, null);
                ShipmentNbrLabel = new Label(ShipmentNbr);
                ShipmentNbr.DataField = "ShipmentNbr";
                CustomerID = new Selector("ctl00_phG_grid_lv0_edCustomerID", "Customer", locator, null);
                CustomerIDLabel = new Label(CustomerID);
                CustomerID.DataField = "CustomerID";
                CustomerLocationID = new Selector("ctl00_phG_grid_lv0_edCustomerLocationID", "Location", locator, null);
                CustomerLocationIDLabel = new Label(CustomerLocationID);
                CustomerLocationID.DataField = "CustomerLocationID";
                ShipDate = new DateSelector("ctl00_phG_grid_lv0_edShipDate", "Shipment Date", locator, null);
                ShipDateLabel = new Label(ShipDate);
                ShipDate.DataField = "ShipDate";
                CuryID = new Selector("ctl00_phG_grid_lv0_edCuryID", "Freight Currency", locator, null);
                CuryIDLabel = new Label(CuryID);
                CuryID.DataField = "CuryID";
                ShipmentQty = new PXNumberEdit("ctl00_phG_grid_lv0_edShipmentQty", "Shipped Quantity", locator, null);
                ShipmentQtyLabel = new Label(ShipmentQty);
                ShipmentQty.DataField = "ShipmentQty";
                Es = new Selector("ctl00_phG_grid_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Ec = new DropDown("ctl00_phG_grid_lv0_ec", "Ec", locator, null);
                DataMemberName = "Orders";
            }
        }

        public class c_filterpreview_formpreview : Container
        {

            public PxButtonCollection Buttons;

            public c_filterpreview_formpreview(string locator, string name) :
                    base(locator, name)
            {
                DataMemberName = "FilterPreview";
                Buttons = new PxButtonCollection();
            }

            public virtual void Ok()
            {
                Buttons.Ok.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Ok { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    Ok = new Button("ctl00_usrCaption_PanelDynamicForm_PXButtonOK", "OK", "ctl00_usrCaption_PanelDynamicForm_FormPreview");
                    Cancel = new Button("ctl00_usrCaption_PanelDynamicForm_PXButtonCancel", "Cancel", "ctl00_usrCaption_PanelDynamicForm_FormPreview");
                }
            }
        }

        public class c_processing : Container
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            public c_processing(string locator, string name) :
                    base(locator, name)
            {
                DataMemberName = "ViewProcessingResults";
                ToolBar = new PxToolBar("ctl00_usrCaption_ProcessingDialogs_PanelProgress");
                Buttons = new PxButtonCollection();
            }

            public virtual void Processed()
            {
                ToolBar.Processed.Click();
            }

            public virtual void Errors()
            {
                ToolBar.Errors.Click();
            }

            public virtual void Warnings()
            {
                ToolBar.Warnings.Click();
            }

            public virtual void Remains()
            {
                ToolBar.Remains.Click();
            }

            public virtual void Total()
            {
                ToolBar.Total.Click();
            }

            public virtual void CancelProcessing()
            {
                Buttons.CancelProcessing.Click();
            }

            public virtual void Close()
            {
                Buttons.Close.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButton Processed { get; }
                public ToolBarButton Errors { get; }
                public ToolBarButton Warnings { get; }
                public ToolBarButton Remains { get; }
                public ToolBarButton Total { get; }

                public PxToolBar(string locator)
                {
                    Processed = new ToolBarButton("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_ToolbarProcessing div[data-" +
                            "cmd=\'Processed\']", "Processed", locator, null);
                    Errors = new ToolBarButton("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_ToolbarProcessing div[data-" +
                            "cmd=\'Errors\']", "Errors", locator, null);
                    Warnings = new ToolBarButton("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_ToolbarProcessing div[data-" +
                            "cmd=\'Warnings\']", "Warnings", locator, null);
                    Remains = new ToolBarButton("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_ToolbarProcessing div[data-" +
                            "cmd=\'Remains\']", "Remains", locator, null);
                    Total = new ToolBarButton("css=#ctl00_usrCaption_ProcessingDialogs_PanelProgress_ToolbarProcessing div[data-" +
                            "cmd=\'Total\']", "Total", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button CancelProcessing { get; }
                public Button Close { get; }

                public PxButtonCollection()
                {
                    CancelProcessing = new Button("ctl00_usrCaption_ProcessingDialogs_PanelProgress_BtnCancelProcessing", "Cancel Processing", "ctl00_usrCaption_ProcessingDialogs_PanelProgress");
                    Close = new Button("ctl00_usrCaption_ProcessingDialogs_PanelProgress_BtnDone", "Close", "ctl00_usrCaption_ProcessingDialogs_PanelProgress");
                }
            }
        }
    }
}
