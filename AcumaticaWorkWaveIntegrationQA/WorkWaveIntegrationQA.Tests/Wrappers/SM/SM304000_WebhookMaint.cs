using Api;
using Controls.Alert;
using Controls.Button;
using Controls.CheckBox;
using Controls.Container;
using Controls.Container.Extentions;
using Controls.Editors.DateSelector;
using Controls.Editors.DropDown;
using Controls.Editors.Selector;
using Controls.Grid;
using Controls.Grid.Filter;
using Controls.Grid.Upload;
using Controls.GroupBox;
using Controls.Input;
using Controls.Input.PXNumberEdit;
using Controls.Input.PXTextEdit;
using Controls.Label;
using Controls.PxControlCollection;
using Controls.ToolBarButton;
using Core;
using Core.ApiConnection;
using Core.Core.Browser;
using Core.Wait;
using System;


namespace WorkWaveIntegrationQA.Tests.Wrappers
{


    public class SM304000_WebhookMaint : Wrapper
    {

        public Note NotePanel;

        public SmartPanel_AttachFile FilesUploadDialog;

        public PxToolBar ToolBar;

        protected c_webhook_form Webhook_form { get; } = new c_webhook_form("ctl00_phF_form", "Webhook_form");
        protected c_webhook_form1 Webhook_form1 { get; } = new c_webhook_form1("ctl00_phG_tab_t0_form1", "Webhook_form1");
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
        protected c_webhookrequest_grid1 WebhookRequest_grid1 { get; } = new c_webhookrequest_grid1("ctl00_phG_tab_t0_grid1", "WebhookRequest_grid1");
        protected c_webhookrequest_lv0 WebhookRequest_lv0 { get; } = new c_webhookrequest_lv0("ctl00_phG_tab_t0_grid1_lv0", "WebhookRequest_lv0");
        protected c_webhookrequestcurrent_tab WebhookRequestCurrent_tab { get; } = new c_webhookrequestcurrent_tab("ctl00_phG_panelRequestDetails_formRequestDetails_tab", "WebhookRequestCurrent_tab");
        protected c_webhookrequestcurrent_formrequestdetails WebhookRequestCurrent_formRequestDetails { get; } = new c_webhookrequestcurrent_formrequestdetails("ctl00_phG_panelRequestDetails_formRequestDetails", "WebhookRequestCurrent_formRequestDetails");
        protected c_filterpreview_formpreview FilterPreview_FormPreview { get; } = new c_filterpreview_formpreview("ctl00_usrCaption_PanelDynamicForm_FormPreview", "FilterPreview_FormPreview");

        public SM304000_WebhookMaint()
        {
            ScreenId = "SM304000";
            ScreenUrl = "/Pages/SM/SM304000.aspx";
            NotePanel = new Note("ctl00_usrCaption_tlbDataView");
            FilesUploadDialog = new SmartPanel_AttachFile("ctl00_usrCaption_tlbDataView");
            ToolBar = new PxToolBar(null);
        }

        public virtual SM304000_WebhookMaint ReadOne(Gate gate, string Name)
        {
            new BiObject<SM304000_WebhookMaint>(gate).ReadOne(this, Name);
            return this;
        }

        public virtual SM304000_WebhookMaint ReadOne(string Name)
        {
            return this.ReadOne(ApiConnection.Source, Name);
        }

        public virtual void SyncTOC()
        {
            ToolBar.SyncTOC.Click();
        }

        public virtual void Note()
        {
            ToolBar.Note.Click();
        }

        public virtual void FilesMenuShow()
        {
            ToolBar.FilesMenuShow.Click();
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

        public virtual void Save()
        {
            ToolBar.Save.Click();
        }

        public virtual void Cancel()
        {
            ToolBar.Cancel.Click();
        }

        public virtual void Insert()
        {
            ToolBar.Insert.Click();
        }

        public virtual void Delete()
        {
            ToolBar.Delete.Click();
        }

        public virtual void First()
        {
            ToolBar.First.Click();
        }

        public virtual void Previous()
        {
            ToolBar.Previous.Click();
        }

        public virtual void Next()
        {
            ToolBar.Next.Click();
        }

        public virtual void Last()
        {
            ToolBar.Last.Click();
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
            public ToolBarButton Note { get; }
            public ToolBarButton FilesMenuShow { get; }
            public ToolBarButton Custom { get; }
            public ToolBarButton ActionSelectWorkingProject { get; }
            public ToolBarButton InspectElementCtrlAltClick { get; }
            public ToolBarButton MenuEditProj { get; }
            public ToolBarButton ManageCustomizations { get; }
            public ToolBarButton KeyBtnRefresh { get; }
            public ToolBarButton Help { get; }
            public ToolBarButton Save { get; }
            public ToolBarButton Cancel { get; }
            public ToolBarButton Insert { get; }
            public ToolBarButton Delete { get; }
            public ToolBarButton First { get; }
            public ToolBarButton Previous { get; }
            public ToolBarButton Next { get; }
            public ToolBarButton Last { get; }
            public ToolBarButton LongRun { get; }
            public ToolBarButton LongrunCancel { get; }
            public ToolBarButton LongrunTimer { get; }

            public PxToolBar(string locator)
            {
                SyncTOC = new ToolBarButton("css=#ctl00_usrCaption_tlbPath div[data-cmd=\'syncTOC\']", "Sync Navigation Pane", locator, null);
                Note = new ToolBarButton("css=#ctl00_usrCaption_tlbDataView div[data-cmd=\'NoteShow\']", "Add Note", locator, null);
                FilesMenuShow = new ToolBarButton("css=#ctl00_usrCaption_tlbDataView div[data-cmd=\'FilesMenuShow\']", "Files", locator, null);
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
                Save = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Save", "Save (Ctrl+S).", locator, null);
                Cancel = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Cancel", "Cancel (Esc)", locator, null);
                Cancel.ConfirmAction = () => Alert.AlertToException("Any unsaved changes will be discarded.");
                Insert = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Insert", "Add New Record (Ctrl+Ins)", locator, null);
                Delete = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Delete", "Delete (Ctrl+Del).", locator, null);
                Delete.ConfirmAction = () => Alert.AlertToException("The current WebHook record will be deleted.");
                First = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_First", "Go to First Record", locator, null);
                Previous = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Previous", "Go to Previous Record (PgUp)", locator, null);
                Next = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Next", "Go to Next Record (PgDn)", locator, null);
                Last = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Last", "Go to Last Record", locator, null);
                LongRun = new ToolBarButton("css=qp-long-run", "Nothing in progress", locator, null);
                LongrunCancel = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_cancel", "Cancel", locator, null);
                LongrunTimer = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_timer", "Elapsed Time", locator, null);
            }
        }

        public class c_webhook_form : Container
        {

            public Selector Name { get; }
            public Label NameLabel { get; }
            public Selector Handler { get; }
            public Label HandlerLabel { get; }
            public CheckBox IsActive { get; }
            public Label IsActiveLabel { get; }
            public CheckBox IsSystem { get; }
            public Label IsSystemLabel { get; }
            public PXTextEdit Url { get; }
            public Label UrlLabel { get; }

            public c_webhook_form(string locator, string name) :
                    base(locator, name)
            {
                Name = new Selector("ctl00_phF_form_PXSelector1", "Webhook Name", locator, null);
                NameLabel = new Label(Name);
                Name.DataField = "Name";
                Handler = new Selector("ctl00_phF_form_PXSelector2", "Implementation Class", locator, null);
                HandlerLabel = new Label(Handler);
                Handler.DataField = "Handler";
                IsActive = new CheckBox("ctl00_phF_form_PXCheckBox1", "Active", locator, null);
                IsActiveLabel = new Label(IsActive);
                IsActive.DataField = "IsActive";
                IsSystem = new CheckBox("ctl00_phF_form_PXCheckBox2", "Predefined", locator, null);
                IsSystemLabel = new Label(IsSystem);
                IsSystem.DataField = "IsSystem";
                Url = new PXTextEdit("ctl00_phF_form_PXTextEdit2", "URL", locator, null);
                UrlLabel = new Label(Url);
                Url.DataField = "Url";
                DataMemberName = "Webhook";
            }
        }

        public class c_webhook_form1 : Container
        {

            public DropDown RequestLogLevel { get; }
            public Label RequestLogLevelLabel { get; }
            public PXNumberEdit RequestRetainCount { get; }
            public Label RequestRetainCountLabel { get; }

            public c_webhook_form1(string locator, string name) :
                    base(locator, name)
            {
                RequestLogLevel = new DropDown("ctl00_phG_tab_t0_form1_PXDropDown1", "Requests to Keep", locator, null);
                RequestLogLevelLabel = new Label(RequestLogLevel);
                RequestLogLevel.DataField = "RequestLogLevel";
                RequestLogLevel.Items.Add("0", "None");
                RequestLogLevel.Items.Add("1", "Only Failed");
                RequestLogLevel.Items.Add("2", "All");
                RequestRetainCount = new PXNumberEdit("ctl00_phG_tab_t0_form1_PXNumberEdit1", "Maximum Number of Requests in History", locator, null);
                RequestRetainCountLabel = new Label(RequestRetainCount);
                RequestRetainCount.DataField = "RequestRetainCount";
                DataMemberName = "Webhook";
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
                    Delete.ConfirmAction = () => Alert.AlertToException("The current {0} record will be deleted.");
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

        public class c_webhookrequest_grid1 : Grid<c_webhookrequest_grid1.c_grid_row, c_webhookrequest_grid1.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_webhookrequest_grid1(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t0_grid1");
                DataMemberName = "WebhookRequest";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t0_grid1_fe_gf", "FilterForm");
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

            public virtual void ShowRequestDetails()
            {
                ToolBar.ShowRequestDetails.Click();
            }

            public virtual void ClearRequestsLog()
            {
                ToolBar.ClearRequestsLog.Click();
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
                public ToolBarButtonGrid ShowRequestDetails { get; }
                public ToolBarButtonGrid ClearRequestsLog { get; }
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Delete.ConfirmAction = () => Alert.AlertToException("The current {0} record will be deleted.");
                    ShowRequestDetails = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_at_tlb div[data-cmd=\'ShowRequestDetails\']", "Show Request Details", locator, null);
                    ClearRequestsLog = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_at_tlb div[data-cmd=\'ClearRequestsLog\']", "Clear History", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid1_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public PXTextEdit Type { get; }
                public PXTextEdit ReceivedFrom { get; }
                public DateSelector ReceiveDate { get; }
                public PXNumberEdit ResponseStatus { get; }
                public PXTextEdit WebHookID { get; }
                public PXNumberEdit RequestID { get; }

                public c_grid_row(c_webhookrequest_grid1 grid) :
                        base(grid)
                {
                    Type = new PXTextEdit("ctl00_phG_tab_t0_grid1_ei", "Request", grid.Locator, "Type");
                    Type.DataField = "Type";
                    ReceivedFrom = new PXTextEdit("ctl00_phG_tab_t0_grid1_ei", "Received From", grid.Locator, "ReceivedFrom");
                    ReceivedFrom.DataField = "ReceivedFrom";
                    ReceiveDate = new DateSelector("_ctl00_phG_tab_t0_grid1_lv0_ed2", "Date", grid.Locator, "ReceiveDate");
                    ReceiveDate.DataField = "ReceiveDate";
                    ResponseStatus = new PXNumberEdit("ctl00_phG_tab_t0_grid1_en", "Response Status", grid.Locator, "ResponseStatus");
                    ResponseStatus.DataField = "ResponseStatus";
                    WebHookID = new PXTextEdit("ctl00_phG_tab_t0_grid1_ei", "WebHookID", grid.Locator, "WebHookID");
                    WebHookID.DataField = "WebHookID";
                    RequestID = new PXNumberEdit("ctl00_phG_tab_t0_grid1_en", "RequestID", grid.Locator, "RequestID");
                    RequestID.DataField = "RequestID";
                }
            }

            public class c_grid_header : GridHeader
            {

                public PXTextEditColumnFilter Type { get; }
                public PXTextEditColumnFilter ReceivedFrom { get; }
                public DateSelectorColumnFilter ReceiveDate { get; }
                public PXNumberEditColumnFilter ResponseStatus { get; }
                public PXTextEditColumnFilter WebHookID { get; }
                public PXNumberEditColumnFilter RequestID { get; }

                public c_grid_header(c_webhookrequest_grid1 grid) :
                        base(grid)
                {
                    Type = new PXTextEditColumnFilter(grid.Row.Type);
                    ReceivedFrom = new PXTextEditColumnFilter(grid.Row.ReceivedFrom);
                    ReceiveDate = new DateSelectorColumnFilter(grid.Row.ReceiveDate);
                    ResponseStatus = new PXNumberEditColumnFilter(grid.Row.ResponseStatus);
                    WebHookID = new PXTextEditColumnFilter(grid.Row.WebHookID);
                    RequestID = new PXNumberEditColumnFilter(grid.Row.RequestID);
                }
            }
        }

        public class c_webhookrequest_lv0 : Container
        {

            public DateSelector Ed { get; }
            public Label EdLabel { get; }

            public c_webhookrequest_lv0(string locator, string name) :
                    base(locator, name)
            {
                Ed = new DateSelector("ctl00_phG_tab_t0_grid1_lv0_ed", "Ed", locator, null);
                EdLabel = new Label(Ed);
                DataMemberName = "WebhookRequest";
            }
        }

        public class c_webhookrequestcurrent_tab : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit Response { get; }
            public Label ResponseLabel { get; }
            public PXTextEdit Error { get; }
            public Label ErrorLabel { get; }

            public c_webhookrequestcurrent_tab(string locator, string name) :
                    base(locator, name)
            {
                Response = new PXTextEdit("ctl00_phG_panelRequestDetails_formRequestDetails_tab_t0_PXTextEdit2", "Response", locator, null);
                ResponseLabel = new Label(Response);
                Response.DataField = "Response";
                Error = new PXTextEdit("ctl00_phG_panelRequestDetails_formRequestDetails_tab_t1_PXTextEdit3", "Error", locator, null);
                ErrorLabel = new Label(Error);
                Error.DataField = "Error";
                DataMemberName = "WebhookRequestCurrent";
                Buttons = new PxButtonCollection();
            }

            public virtual void Unnamed()
            {
                Buttons.Unnamed.Click();
            }

            public virtual void Close()
            {
                Buttons.Close.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Unnamed { get; }
                public Button Close { get; }

                public PxButtonCollection()
                {
                    Unnamed = new Button("ctl00_phG_panelRequestDetails_formRequestDetails_tab_oi", "", "ctl00_phG_panelRequestDetails_formRequestDetails_tab");
                    Close = new Button("ctl00_phG_panelRequestDetails_btnClose", "Close", "ctl00_phG_panelRequestDetails_formRequestDetails_tab");
                }
            }
        }

        public class c_webhookrequestcurrent_formrequestdetails : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit Type { get; }
            public Label TypeLabel { get; }
            public PXTextEdit Request { get; }
            public Label RequestLabel { get; }
            public PXTextEdit ResponseStatus { get; }
            public Label ResponseStatusLabel { get; }
            public PXTextEdit ProcessingTime { get; }
            public Label ProcessingTimeLabel { get; }
            public Label PXLabel1_r0 { get; }

            public c_webhookrequestcurrent_formrequestdetails(string locator, string name) :
                    base(locator, name)
            {
                Type = new PXTextEdit("ctl00_phG_panelRequestDetails_formRequestDetails_PXTextEdit1", "Request", locator, null);
                TypeLabel = new Label(Type);
                Type.DataField = "Type";
                Request = new PXTextEdit("ctl00_phG_panelRequestDetails_formRequestDetails_PXHtmlView1", "Request", locator, null);
                RequestLabel = new Label(Request);
                Request.DataField = "Request";
                ResponseStatus = new PXTextEdit("ctl00_phG_panelRequestDetails_formRequestDetails_PXNumberEdit1", "Response Status", locator, null);
                ResponseStatusLabel = new Label(ResponseStatus);
                ResponseStatus.DataField = "ResponseStatus";
                ProcessingTime = new PXTextEdit("ctl00_phG_panelRequestDetails_formRequestDetails_PXNumberEdit2", "Processing Time (ms)", locator, null);
                ProcessingTimeLabel = new Label(ProcessingTime);
                ProcessingTime.DataField = "ProcessingTime";
                PXLabel1_r0 = new Label("ctl00_phG_panelRequestDetails_formRequestDetails_PXLabel1", "PX Label 1_r 0", locator, null);
                DataMemberName = "WebhookRequestCurrent";
                Buttons = new PxButtonCollection();
            }

            public virtual void Unnamed()
            {
                Buttons.Unnamed.Click();
            }

            public virtual void Close()
            {
                Buttons.Close.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Unnamed { get; }
                public Button Close { get; }

                public PxButtonCollection()
                {
                    Unnamed = new Button("ctl00_phG_panelRequestDetails_formRequestDetails_tab_oi", "", "ctl00_phG_panelRequestDetails_formRequestDetails");
                    Close = new Button("ctl00_phG_panelRequestDetails_btnClose", "Close", "ctl00_phG_panelRequestDetails_formRequestDetails");
                }
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
    }
}
