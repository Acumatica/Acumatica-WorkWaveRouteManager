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
using Controls.Input;
using Controls.Input.PXNumberEdit;
using Controls.Input.PXTextEdit;
using Controls.Label;
using Controls.NoteColumnButton;
using Controls.Pivot;
using Controls.PxControlCollection;
using Controls.ToolBarButton;
using Core;
using Core.Core.Browser;
using Core.Wait;
using System;


namespace WorkWaveIntegrationQA.Tests.Wrappers
{


    public class SO3020PL_PXGenericInqGrph : Wrapper
    {

        public PxToolBar ToolBar;

        protected c_filter_form Filter_form { get; } = new c_filter_form("ctl00_phF_form", "Filter_form");
        protected c_parameters_gridwizard Parameters_gridWizard { get; } = new c_parameters_gridwizard("ctl00_usrCaption_shareColumnsDlg_gridWizard", "Parameters_gridWizard");
        protected c_profilerinfoview_formprofiler ProfilerInfoView_formProfiler { get; } = new c_profilerinfoview_formprofiler("ctl00_usrCaption_pnlProfiler_formProfiler", "ProfilerInfoView_formProfiler");
        protected c_gridlist_gridgrid GridList_gridGrid { get; } = new c_gridlist_gridgrid("ctl00_usrCaption_shareColumnsDlg_gridWizard_p0_gridGrid", "GridList_gridGrid");
        protected c_userlist_usergrid UserList_userGrid { get; } = new c_userlist_usergrid("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid", "UserList_userGrid");
        protected c_userlist_lv0 UserList_lv0 { get; } = new c_userlist_lv0("ctl00_usrCaption_shareColumnsDlg_gridWizard_p1_userGrid_lv0", "UserList_lv0");
        protected c_results_grid Results_grid { get; } = new c_results_grid("ctl00_phG_grid", "Results_grid");
        protected c_results_lv0 Results_lv0 { get; } = new c_results_lv0("ctl00_phG_grid_lv0", "Results_lv0");
        protected c_addnewkeys_grdkeys AddNewKeys_grdKeys { get; } = new c_addnewkeys_grdkeys("ctl00_phG_dlgEnterKeys_grdKeys", "AddNewKeys_grdKeys");
        protected c_addnewkeys_lv0 AddNewKeys_lv0 { get; } = new c_addnewkeys_lv0("ctl00_phG_dlgEnterKeys_grdKeys_lv0", "AddNewKeys_lv0");
        protected c_fields_grdfields Fields_grdFields { get; } = new c_fields_grdfields("ctl00_phG_dlgUpdateParams_grdFields", "Fields_grdFields");
        protected c_fields_lv0 Fields_lv0 { get; } = new c_fields_lv0("ctl00_phG_dlgUpdateParams_grdFields_lv0", "Fields_lv0");
        protected c_filterpreview_formpreview FilterPreview_FormPreview { get; } = new c_filterpreview_formpreview("ctl00_usrCaption_PanelDynamicForm_FormPreview", "FilterPreview_FormPreview");
        protected c_pivot_grid Pivot_Grid { get; } = new c_pivot_grid("ctl00_phG_grid_pivotT", "Pivot_Grid");

        public SO3020PL_PXGenericInqGrph()
        {
            ScreenId = "SO3020PL";
            ScreenUrl = "/GenericInquiry/GenericInquiry.aspx?ID=CB567D54-187B-4466-A2E5-8776831CA6E9";
            ToolBar = new PxToolBar(null);
        }

        public virtual void SyncTOC()
        {
            ToolBar.SyncTOC.Click();
        }

        public virtual void KeyBtnRefresh()
        {
            ToolBar.KeyBtnRefresh.Click();
        }

        public virtual void KeyBtnGenericInquiryCustomize()
        {
            ToolBar.KeyBtnGenericInquiryCustomize.Click();
        }

        public virtual void EditGenericInquiry()
        {
            ToolBar.EditGenericInquiry.Click();
        }

        public virtual void PivotTables()
        {
            ToolBar.PivotTables.Click();
        }

        public virtual void Help()
        {
            ToolBar.Help.Click();
        }

        public virtual void MenuOpener()
        {
            ToolBar.MenuOpener.Click();
        }

        public virtual void Refresh()
        {
            ToolBar.Refresh.Click();
        }

        public virtual void Cancel()
        {
            ToolBar.Cancel.Click();
        }

        public virtual void Insert()
        {
            ToolBar.Insert.Click();
        }

        public virtual void EditDetail()
        {
            ToolBar.EditDetail.Click();
        }

        public virtual void SyncGridPosition()
        {
            ToolBar.SyncGridPosition.Click();
        }

        public virtual void ActionsMenu()
        {
            ToolBar.ActionsMenu.Click();
        }

        public virtual void Adjust()
        {
            ToolBar.Adjust.Click();
        }

        public virtual void Export()
        {
            ToolBar.Export.Click();
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
            public ToolBarButton KeyBtnRefresh { get; }
            public ToolBarButton KeyBtnGenericInquiryCustomize { get; }
            public ToolBarButton EditGenericInquiry { get; }
            public ToolBarButton PivotTables { get; }
            public ToolBarButton Help { get; }
            public ToolBarButton MenuOpener { get; }
            public ToolBarButton Refresh { get; }
            public ToolBarButton Cancel { get; }
            public ToolBarButton Insert { get; }
            public ToolBarButton EditDetail { get; }
            public ToolBarButton SyncGridPosition { get; }
            public ToolBarButton ActionsMenu { get; }
            public ToolBarButton Adjust { get; }
            public ToolBarButton Export { get; }
            public ToolBarButton LongRun { get; }
            public ToolBarButton LongrunCancel { get; }
            public ToolBarButton LongrunTimer { get; }

            public PxToolBar(string locator)
            {
                SyncTOC = new ToolBarButton("css=#ctl00_usrCaption_tlbPath div[data-cmd=\'syncTOC\']", "Sync Navigation Pane", locator, null);
                KeyBtnRefresh = new ToolBarButton("css=#ctl00_usrCaption_tlbTools div[data-cmd=\'keyBtnRefresh\']", "Click to refresh page.", locator, null);
                KeyBtnGenericInquiryCustomize = new ToolBarButton("css=#ctl00_usrCaption_tlbTools div:textEqual(\"Customization\") > div[data-type=\'dr" +
                        "op\']", "Customization", locator, null);
                EditGenericInquiry = new ToolBarButton("css=div#ctl00_usrCaption_tlbTools_menukeyBtnGenericInquiryCustomize li.menuItem d" +
                        "iv:textEqual(\"Edit Generic Inquiry\")", "Edit Generic Inquiry", locator, KeyBtnGenericInquiryCustomize);
                PivotTables = new ToolBarButton("css=div#ctl00_usrCaption_tlbTools_menukeyBtnGenericInquiryCustomize li.menuItem d" +
                        "iv:textEqual(\"Pivot Tables\")", "Pivot Tables", locator, KeyBtnGenericInquiryCustomize);
                Help = new ToolBarButton("css=#ctl00_usrCaption_tlbTools div[data-cmd=\'help\']", "View Tools", locator, null);
                MenuOpener = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_MenuOpener", "Menu", locator, null);
                Refresh = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Refresh", "Refresh", locator, null);
                Cancel = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Cancel", "Cancel (Esc)", locator, null);
                Cancel.ConfirmAction = () => Alert.AlertToException("Any unsaved changes will be discarded.");
                Insert = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_insert", "New Record", locator, null);
                EditDetail = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_editDetail", "Edit Record", locator, null);
                SyncGridPosition = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_SyncGridPosition,#ctl00_phDS_ds_ToolBar_SyncGridPositi" +
                        "on_item", "SyncGridPosition", locator, MenuOpener);
                ActionsMenu = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_actionsMenu", "Actions", locator, MenuOpener);
                Adjust = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_AdjustColumns", "Fit to Screen", locator, null);
                Export = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ExportExcel", "Export to Excel", locator, null);
                LongRun = new ToolBarButton("css=qp-long-run", "Nothing in progress", locator, null);
                LongrunCancel = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_cancel", "Cancel", locator, null);
                LongrunTimer = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_timer", "Elapsed Time", locator, null);
            }
        }

        public class c_filter_form : Container
        {

            public c_filter_form(string locator, string name) :
                    base(locator, name)
            {
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

        public class c_results_grid : Grid<c_results_grid.c_grid_row, c_results_grid.c_grid_header>
        {

            public PxToolBar ToolBar;

            public QuickSearch QuickSearch { get; }
            public c_grid_filter FilterForm { get; }
            public SmartPanel_AttachFile FilesUploadDialog { get; }
            public Note NotePanel { get; }

            public c_results_grid(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_grid");
                DataMemberName = "Results";
                QuickSearch = new QuickSearch("ctl00_phG_grid_tf_fb", "QuickSearch", locator, null);
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

            public virtual void EditPivot()
            {
                ToolBar.EditPivot.Click();
            }

            public virtual void Filter()
            {
                ToolBar.Filter.Click();
            }

            public virtual void FilterSave()
            {
                ToolBar.FilterSave.Click();
            }

            public virtual void More()
            {
                ToolBar.More.Click();
            }

            public virtual void FilterSave1()
            {
                ToolBar.FilterSave1.Click();
            }

            public virtual void FilterSavePivot()
            {
                ToolBar.FilterSavePivot.Click();
            }

            public virtual void FilterRemove()
            {
                ToolBar.FilterRemove.Click();
            }

            public virtual void CollapseAll()
            {
                ToolBar.CollapseAll.Click();
            }

            public virtual void ExpandAll()
            {
                ToolBar.ExpandAll.Click();
            }

            public virtual void YPageFirst()
            {
                ToolBar.YPageFirst.Click();
            }

            public virtual void YPagePrev()
            {
                ToolBar.YPagePrev.Click();
            }

            public virtual void YPageNext()
            {
                ToolBar.YPageNext.Click();
            }

            public virtual void YPageLast()
            {
                ToolBar.YPageLast.Click();
            }

            public virtual void XPageFirst()
            {
                ToolBar.XPageFirst.Click();
            }

            public virtual void XPagePrev()
            {
                ToolBar.XPagePrev.Click();
            }

            public virtual void XPageNext()
            {
                ToolBar.XPageNext.Click();
            }

            public virtual void XPageLast()
            {
                ToolBar.XPageLast.Click();
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
                public ToolBarButtonGrid EditPivot { get; }
                public ToolBarButtonGrid Filter { get; }
                public ToolBarButtonGrid FilterSave { get; }
                public ToolBarButtonGrid More { get; }
                public ToolBarButtonGrid FilterSave1 { get; }
                public ToolBarButtonGrid FilterSavePivot { get; }
                public ToolBarButtonGrid FilterRemove { get; }
                public ToolBarButtonGrid CollapseAll { get; }
                public ToolBarButtonGrid ExpandAll { get; }
                public ToolBarButtonGrid YPageFirst { get; }
                public ToolBarButtonGrid YPagePrev { get; }
                public ToolBarButtonGrid YPageNext { get; }
                public ToolBarButtonGrid YPageLast { get; }
                public ToolBarButtonGrid XPageFirst { get; }
                public ToolBarButtonGrid XPagePrev { get; }
                public ToolBarButtonGrid XPageNext { get; }
                public ToolBarButtonGrid XPageLast { get; }
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
                    EditPivot = new ToolBarButtonGrid("css=#ctl00_phG_grid_tf div[data-cmd=\'EditPivot\']", "Edit pivot table", locator, null);
                    Filter = new ToolBarButtonGrid("css=#ctl00_phG_grid_tf div[data-cmd=\'FilterShow\']", "Filter Settings", locator, null);
                    FilterSave = new ToolBarButtonGrid("css=#ctl00_phG_grid_tf div[data-cmd=\'FilterSave\']", "Save", locator, null);
                    More = new ToolBarButtonGrid("css=#ctl00_phG_grid_tf div[data-cmd=\'more\']", "...", locator, null);
                    FilterSave1 = new ToolBarButtonGrid("css=div#ctl00_phG_grid_tf_menumore li[data-cmd=\'FilterSave\']", "Save As", locator, More);
                    FilterSavePivot = new ToolBarButtonGrid("css=div#ctl00_phG_grid_tf_menumore li[data-cmd=\'FilterSavePivot\']", "Save As Pivot", locator, More);
                    FilterRemove = new ToolBarButtonGrid("css=div#ctl00_phG_grid_tf_menumore li[data-cmd=\'FilterRemove\']", "Remove", locator, More);
                    CollapseAll = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'CollapseAll\']", "Collapse All", locator, null);
                    ExpandAll = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'ExpandAll\']", "Expand All", locator, null);
                    YPageFirst = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'YPageFirst\']", "YPageFirst", locator, null);
                    YPagePrev = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'YPagePrev\']", "YPagePrev", locator, null);
                    YPageNext = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'YPageNext\']", "YPageNext", locator, null);
                    YPageLast = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'YPageLast\']", "YPageLast", locator, null);
                    XPageFirst = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'XPageFirst\']", "XPageFirst", locator, null);
                    XPagePrev = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'XPagePrev\']", "XPagePrev", locator, null);
                    XPageNext = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'XPageNext\']", "XPageNext", locator, null);
                    XPageLast = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'XPageLast\']", "XPageLast", locator, null);
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
                public DropDown SOShipment_shipmentType { get; }
                public Selector SOShipment_shipmentNbr { get; }
                public DropDown SOShipment_status { get; }
                public DateSelector SOShipment_shipDate { get; }
                public DropDown SOShipment_operation { get; }
                public Selector SOShipment_customerID { get; }
                public Selector SOShipment_customerID_description { get; }
                public Selector SOShipment_siteID { get; }
                public Selector SOShipment_destinationSiteID { get; }
                public PXNumberEdit SOShipment_shipmentQty { get; }
                public PXNumberEdit SOShipment_shipmentWeight { get; }
                public PXNumberEdit SOShipment_shipmentVolume { get; }
                public PXNumberEdit SOShipment_packageCount { get; }
                public PXNumberEdit SOShipment_packageWeight { get; }
                public Selector SOShipment_ownerID { get; }
                public Selector SOShipment_shipVia { get; }
                public Selector SOShipment_fOBPoint { get; }
                public Selector SOShipment_shipTermsID { get; }
                public Selector SOShipment_shipZoneID { get; }
                public PXNumberEdit SOShipment_freightCost { get; }
                public PXNumberEdit SOShipment_freightAmt { get; }
                public Selector SOShipment_curyID { get; }
                public Selector INSite_branchID { get; }
                public Selector INSite_branchID_description { get; }
                public Selector SOShipment_createdByID { get; }
                public DateSelector SOShipment_createdDateTime { get; }
                public Selector SOShipment_lastModifiedByID { get; }
                public DateSelector SOShipment_lastModifiedDateTime { get; }
                public Selector INSite_SiteCD { get; }
                public Selector BAccountR_AcctCD { get; }
                public Selector Customer_AcctCD { get; }
                public Selector Branch_BranchCD { get; }

                public c_grid_row(c_results_grid grid) :
                        base(grid)
                {
                    Files = new FileColumnButton(null, "Files", grid.Locator, "Files");
                    Notes = new NoteColumnButton(null, "Notes", grid.Locator, "Notes");
                    Selected = new CheckBox("ctl00_phG_grid_ef", "Selected", grid.Locator, "Selected");
                    Selected.DataField = "Selected";
                    SOShipment_shipmentType = new DropDown("_ctl00_phG_grid_lv0_ec", "Type", grid.Locator, "SOShipment_shipmentType");
                    SOShipment_shipmentType.DataField = "SOShipment_shipmentType";
                    SOShipment_shipmentType.Items.Add("I", "Shipment");
                    SOShipment_shipmentType.Items.Add("T", "Transfer");
                    SOShipment_shipmentNbr = new Selector("_ctl00_phG_grid_lv0_es", "Shipment Nbr.", grid.Locator, "SOShipment_shipmentNbr");
                    SOShipment_shipmentNbr.DataField = "SOShipment_shipmentNbr";
                    SOShipment_status = new DropDown("_ctl00_phG_grid_lv0_ec", "Status", grid.Locator, "SOShipment_status");
                    SOShipment_status.DataField = "SOShipment_status";
                    SOShipment_status.Items.Add("N", "Open");
                    SOShipment_status.Items.Add("H", "On Hold");
                    SOShipment_status.Items.Add("C", "Completed");
                    SOShipment_status.Items.Add("L", "Canceled");
                    SOShipment_status.Items.Add("F", "Confirmed");
                    SOShipment_status.Items.Add("I", "Invoiced");
                    SOShipment_status.Items.Add("Y", "Partially Invoiced");
                    SOShipment_status.Items.Add("R", "Receipted");
                    SOShipment_status.Items.Add("A", "Auto-Generated");
                    SOShipment_status.Items.Add("W", "Partially Routed");
                    SOShipment_status.Items.Add("P", "Route Planning");
                    SOShipment_status.Items.Add("S", "Route Assigned");
                    SOShipment_status.Items.Add("D", "Route Delivered");
                    SOShipment_status.Items.Add("E", "Route Error");
                    SOShipment_shipDate = new DateSelector("_ctl00_phG_grid_lv0_ed6", "Shipment Date", grid.Locator, "SOShipment_shipDate");
                    SOShipment_shipDate.DataField = "SOShipment_shipDate";
                    SOShipment_operation = new DropDown("_ctl00_phG_grid_lv0_ec", "Operation", grid.Locator, "SOShipment_operation");
                    SOShipment_operation.DataField = "SOShipment_operation";
                    SOShipment_operation.Items.Add("I", "Issue");
                    SOShipment_operation.Items.Add("R", "Receipt");
                    SOShipment_customerID = new Selector("_ctl00_phG_grid_lv0_es", "Customer", grid.Locator, "SOShipment_customerID");
                    SOShipment_customerID.DataField = "SOShipment_customerID";
                    SOShipment_customerID_description = new Selector("_ctl00_phG_grid_lv0_es", "Customer Name", grid.Locator, "SOShipment_customerID_description");
                    SOShipment_customerID_description.DataField = "SOShipment_customerID_description";
                    SOShipment_siteID = new Selector("_ctl00_phG_grid_lv0_es", "Warehouse ID", grid.Locator, "SOShipment_siteID");
                    SOShipment_siteID.DataField = "SOShipment_siteID";
                    SOShipment_destinationSiteID = new Selector("_ctl00_phG_grid_lv0_es", "To Warehouse", grid.Locator, "SOShipment_destinationSiteID");
                    SOShipment_destinationSiteID.DataField = "SOShipment_destinationSiteID";
                    SOShipment_shipmentQty = new PXNumberEdit("ctl00_phG_grid_en", "Shipped Quantity", grid.Locator, "SOShipment_shipmentQty");
                    SOShipment_shipmentQty.DataField = "SOShipment_shipmentQty";
                    SOShipment_shipmentWeight = new PXNumberEdit("ctl00_phG_grid_en", "Shipped Weight", grid.Locator, "SOShipment_shipmentWeight");
                    SOShipment_shipmentWeight.DataField = "SOShipment_shipmentWeight";
                    SOShipment_shipmentVolume = new PXNumberEdit("ctl00_phG_grid_en", "Shipped Volume", grid.Locator, "SOShipment_shipmentVolume");
                    SOShipment_shipmentVolume.DataField = "SOShipment_shipmentVolume";
                    SOShipment_packageCount = new PXNumberEdit("ctl00_phG_grid_en", "Packages", grid.Locator, "SOShipment_packageCount");
                    SOShipment_packageCount.DataField = "SOShipment_packageCount";
                    SOShipment_packageWeight = new PXNumberEdit("ctl00_phG_grid_en", "Package Weight", grid.Locator, "SOShipment_packageWeight");
                    SOShipment_packageWeight.DataField = "SOShipment_packageWeight";
                    SOShipment_ownerID = new Selector("_ctl00_phG_grid_lv0_es", "Owner", grid.Locator, "SOShipment_ownerID");
                    SOShipment_ownerID.DataField = "SOShipment_ownerID";
                    SOShipment_shipVia = new Selector("_ctl00_phG_grid_lv0_es", "Ship Via", grid.Locator, "SOShipment_shipVia");
                    SOShipment_shipVia.DataField = "SOShipment_shipVia";
                    SOShipment_fOBPoint = new Selector("_ctl00_phG_grid_lv0_es", "FOB Point", grid.Locator, "SOShipment_fOBPoint");
                    SOShipment_fOBPoint.DataField = "SOShipment_fOBPoint";
                    SOShipment_shipTermsID = new Selector("_ctl00_phG_grid_lv0_es", "Shipping Terms", grid.Locator, "SOShipment_shipTermsID");
                    SOShipment_shipTermsID.DataField = "SOShipment_shipTermsID";
                    SOShipment_shipZoneID = new Selector("_ctl00_phG_grid_lv0_es", "Shipping Zone ID", grid.Locator, "SOShipment_shipZoneID");
                    SOShipment_shipZoneID.DataField = "SOShipment_shipZoneID";
                    SOShipment_freightCost = new PXNumberEdit("ctl00_phG_grid_en", "Freight Cost", grid.Locator, "SOShipment_freightCost");
                    SOShipment_freightCost.DataField = "SOShipment_freightCost";
                    SOShipment_freightAmt = new PXNumberEdit("ctl00_phG_grid_en", "Freight Price", grid.Locator, "SOShipment_freightAmt");
                    SOShipment_freightAmt.DataField = "SOShipment_freightAmt";
                    SOShipment_curyID = new Selector("_ctl00_phG_grid_lv0_es", "Freight Currency", grid.Locator, "SOShipment_curyID");
                    SOShipment_curyID.DataField = "SOShipment_curyID";
                    INSite_branchID = new Selector("_ctl00_phG_grid_lv0_es", "Branch", grid.Locator, "INSite_branchID");
                    INSite_branchID.DataField = "INSite_branchID";
                    INSite_branchID_description = new Selector("_ctl00_phG_grid_lv0_es", "Branch Name", grid.Locator, "INSite_branchID_description");
                    INSite_branchID_description.DataField = "INSite_branchID_description";
                    SOShipment_createdByID = new Selector("_ctl00_phG_grid_lv0_es", "Created By", grid.Locator, "SOShipment_createdByID");
                    SOShipment_createdByID.DataField = "SOShipment_createdByID";
                    SOShipment_createdDateTime = new DateSelector("_ctl00_phG_grid_lv0_ed28", "Created On", grid.Locator, "SOShipment_createdDateTime");
                    SOShipment_createdDateTime.DataField = "SOShipment_createdDateTime";
                    SOShipment_lastModifiedByID = new Selector("_ctl00_phG_grid_lv0_es", "Last Modified By", grid.Locator, "SOShipment_lastModifiedByID");
                    SOShipment_lastModifiedByID.DataField = "SOShipment_lastModifiedByID";
                    SOShipment_lastModifiedDateTime = new DateSelector("_ctl00_phG_grid_lv0_ed30", "Last Modified On", grid.Locator, "SOShipment_lastModifiedDateTime");
                    SOShipment_lastModifiedDateTime.DataField = "SOShipment_lastModifiedDateTime";
                    INSite_SiteCD = new Selector("_ctl00_phG_grid_lv0_es", "Warehouse ID", grid.Locator, "INSite_SiteCD");
                    INSite_SiteCD.DataField = "INSite_SiteCD";
                    BAccountR_AcctCD = new Selector("_ctl00_phG_grid_lv0_es", "Account ID", grid.Locator, "BAccountR_AcctCD");
                    BAccountR_AcctCD.DataField = "BAccountR_AcctCD";
                    Customer_AcctCD = new Selector("_ctl00_phG_grid_lv0_es", "Customer ID", grid.Locator, "Customer_AcctCD");
                    Customer_AcctCD.DataField = "Customer_AcctCD";
                    Branch_BranchCD = new Selector("_ctl00_phG_grid_lv0_es", "Branch ID", grid.Locator, "Branch_BranchCD");
                    Branch_BranchCD.DataField = "Branch_BranchCD";
                }
            }

            public class c_grid_header : GridHeader
            {

                public GridColumnHeader Files { get; }
                public GridColumnHeader Notes { get; }
                public CheckBoxColumnFilter Selected { get; }
                public DropDownColumnFilter SOShipment_shipmentType { get; }
                public SelectorColumnFilter SOShipment_shipmentNbr { get; }
                public DropDownColumnFilter SOShipment_status { get; }
                public DateSelectorColumnFilter SOShipment_shipDate { get; }
                public DropDownColumnFilter SOShipment_operation { get; }
                public SelectorColumnFilter SOShipment_customerID { get; }
                public SelectorColumnFilter SOShipment_customerID_description { get; }
                public SelectorColumnFilter SOShipment_siteID { get; }
                public SelectorColumnFilter SOShipment_destinationSiteID { get; }
                public PXNumberEditColumnFilter SOShipment_shipmentQty { get; }
                public PXNumberEditColumnFilter SOShipment_shipmentWeight { get; }
                public PXNumberEditColumnFilter SOShipment_shipmentVolume { get; }
                public PXNumberEditColumnFilter SOShipment_packageCount { get; }
                public PXNumberEditColumnFilter SOShipment_packageWeight { get; }
                public SelectorColumnFilter SOShipment_ownerID { get; }
                public SelectorColumnFilter SOShipment_shipVia { get; }
                public SelectorColumnFilter SOShipment_fOBPoint { get; }
                public SelectorColumnFilter SOShipment_shipTermsID { get; }
                public SelectorColumnFilter SOShipment_shipZoneID { get; }
                public PXNumberEditColumnFilter SOShipment_freightCost { get; }
                public PXNumberEditColumnFilter SOShipment_freightAmt { get; }
                public SelectorColumnFilter SOShipment_curyID { get; }
                public SelectorColumnFilter INSite_branchID { get; }
                public SelectorColumnFilter INSite_branchID_description { get; }
                public SelectorColumnFilter SOShipment_createdByID { get; }
                public DateSelectorColumnFilter SOShipment_createdDateTime { get; }
                public SelectorColumnFilter SOShipment_lastModifiedByID { get; }
                public DateSelectorColumnFilter SOShipment_lastModifiedDateTime { get; }
                public SelectorColumnFilter INSite_SiteCD { get; }
                public SelectorColumnFilter BAccountR_AcctCD { get; }
                public SelectorColumnFilter Customer_AcctCD { get; }
                public SelectorColumnFilter Branch_BranchCD { get; }

                public c_grid_header(c_results_grid grid) :
                        base(grid)
                {
                    Files = new GridColumnHeader(grid.Row.Files);
                    Notes = new GridColumnHeader(grid.Row.Notes);
                    Selected = new CheckBoxColumnFilter(grid.Row.Selected);
                    SOShipment_shipmentType = new DropDownColumnFilter(grid.Row.SOShipment_shipmentType);
                    SOShipment_shipmentNbr = new SelectorColumnFilter(grid.Row.SOShipment_shipmentNbr);
                    SOShipment_status = new DropDownColumnFilter(grid.Row.SOShipment_status);
                    SOShipment_shipDate = new DateSelectorColumnFilter(grid.Row.SOShipment_shipDate);
                    SOShipment_operation = new DropDownColumnFilter(grid.Row.SOShipment_operation);
                    SOShipment_customerID = new SelectorColumnFilter(grid.Row.SOShipment_customerID);
                    SOShipment_customerID_description = new SelectorColumnFilter(grid.Row.SOShipment_customerID_description);
                    SOShipment_siteID = new SelectorColumnFilter(grid.Row.SOShipment_siteID);
                    SOShipment_destinationSiteID = new SelectorColumnFilter(grid.Row.SOShipment_destinationSiteID);
                    SOShipment_shipmentQty = new PXNumberEditColumnFilter(grid.Row.SOShipment_shipmentQty);
                    SOShipment_shipmentWeight = new PXNumberEditColumnFilter(grid.Row.SOShipment_shipmentWeight);
                    SOShipment_shipmentVolume = new PXNumberEditColumnFilter(grid.Row.SOShipment_shipmentVolume);
                    SOShipment_packageCount = new PXNumberEditColumnFilter(grid.Row.SOShipment_packageCount);
                    SOShipment_packageWeight = new PXNumberEditColumnFilter(grid.Row.SOShipment_packageWeight);
                    SOShipment_ownerID = new SelectorColumnFilter(grid.Row.SOShipment_ownerID);
                    SOShipment_shipVia = new SelectorColumnFilter(grid.Row.SOShipment_shipVia);
                    SOShipment_fOBPoint = new SelectorColumnFilter(grid.Row.SOShipment_fOBPoint);
                    SOShipment_shipTermsID = new SelectorColumnFilter(grid.Row.SOShipment_shipTermsID);
                    SOShipment_shipZoneID = new SelectorColumnFilter(grid.Row.SOShipment_shipZoneID);
                    SOShipment_freightCost = new PXNumberEditColumnFilter(grid.Row.SOShipment_freightCost);
                    SOShipment_freightAmt = new PXNumberEditColumnFilter(grid.Row.SOShipment_freightAmt);
                    SOShipment_curyID = new SelectorColumnFilter(grid.Row.SOShipment_curyID);
                    INSite_branchID = new SelectorColumnFilter(grid.Row.INSite_branchID);
                    INSite_branchID_description = new SelectorColumnFilter(grid.Row.INSite_branchID_description);
                    SOShipment_createdByID = new SelectorColumnFilter(grid.Row.SOShipment_createdByID);
                    SOShipment_createdDateTime = new DateSelectorColumnFilter(grid.Row.SOShipment_createdDateTime);
                    SOShipment_lastModifiedByID = new SelectorColumnFilter(grid.Row.SOShipment_lastModifiedByID);
                    SOShipment_lastModifiedDateTime = new DateSelectorColumnFilter(grid.Row.SOShipment_lastModifiedDateTime);
                    INSite_SiteCD = new SelectorColumnFilter(grid.Row.INSite_SiteCD);
                    BAccountR_AcctCD = new SelectorColumnFilter(grid.Row.BAccountR_AcctCD);
                    Customer_AcctCD = new SelectorColumnFilter(grid.Row.Customer_AcctCD);
                    Branch_BranchCD = new SelectorColumnFilter(grid.Row.Branch_BranchCD);
                }
            }
        }

        public class c_results_lv0 : Container
        {

            public Selector Es { get; }
            public Label EsLabel { get; }
            public DateSelector Ed { get; }
            public Label EdLabel { get; }
            public DropDown Ec { get; }

            public c_results_lv0(string locator, string name) :
                    base(locator, name)
            {
                Es = new Selector("ctl00_phG_grid_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Ed = new DateSelector("ctl00_phG_grid_lv0_ed", "Ed", locator, null);
                EdLabel = new Label(Ed);
                Ec = new DropDown("ctl00_phG_grid_lv0_ec", "Ec", locator, null);
                DataMemberName = "Results";
            }
        }

        public class c_addnewkeys_grdkeys : Grid<c_addnewkeys_grdkeys.c_grid_row, c_addnewkeys_grdkeys.c_grid_header>
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            public c_addnewkeys_grdkeys(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_dlgEnterKeys_grdKeys");
                DataMemberName = "AddNewKeys";
                Buttons = new PxButtonCollection();
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

            public virtual void Hi()
            {
                ToolBar.Hi.Click();
            }

            public virtual void First()
            {
                Buttons.First.Click();
            }

            public virtual void Prev()
            {
                Buttons.Prev.Click();
            }

            public virtual void Next()
            {
                Buttons.Next.Click();
            }

            public virtual void Last()
            {
                Buttons.Last.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public virtual void Finish()
            {
                Buttons.Finish.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid New { get; }
                public ToolBarButtonGrid Delete { get; }
                public ToolBarButtonGrid Hi { get; }

                public PxToolBar(string locator)
                {
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_dlgEnterKeys_grdKeys_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_phG_dlgEnterKeys_grdKeys_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#ctl00_phG_dlgEnterKeys_grdKeys_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_dlgEnterKeys_grdKeys_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button Cancel { get; }
                public Button Finish { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_dlgEnterKeys_grdKeys_lfFirst0", "First", "ctl00_phG_dlgEnterKeys_grdKeys");
                    Prev = new Button("ctl00_phG_dlgEnterKeys_grdKeys_lfPrev0", "Prev", "ctl00_phG_dlgEnterKeys_grdKeys");
                    Next = new Button("ctl00_phG_dlgEnterKeys_grdKeys_lfNext0", "Next", "ctl00_phG_dlgEnterKeys_grdKeys");
                    Last = new Button("ctl00_phG_dlgEnterKeys_grdKeys_lfLast0", "Last", "ctl00_phG_dlgEnterKeys_grdKeys");
                    Cancel = new Button("ctl00_phG_dlgEnterKeys_btnCancelAddNew", "Cancel", "ctl00_phG_dlgEnterKeys_grdKeys");
                    Finish = new Button("ctl00_phG_dlgEnterKeys_btnFinishAddNew", "Finish", "ctl00_phG_dlgEnterKeys_grdKeys");
                }
            }

            public class c_grid_row : GridRow
            {

                public PXTextEdit FieldName { get; }
                public PXTextEdit DisplayName { get; }
                public PXTextEdit Value { get; }

                public c_grid_row(c_addnewkeys_grdkeys grid) :
                        base(grid)
                {
                    FieldName = new PXTextEdit("ctl00_phG_dlgEnterKeys_grdKeys_ei", "FieldName", grid.Locator, "FieldName");
                    FieldName.DataField = "FieldName";
                    DisplayName = new PXTextEdit("ctl00_phG_dlgEnterKeys_grdKeys_ei", "Key", grid.Locator, "DisplayName");
                    DisplayName.DataField = "DisplayName";
                    Value = new PXTextEdit("ctl00_phG_dlgEnterKeys_grdKeys_ei", "Value", grid.Locator, "Value");
                    Value.DataField = "Value";
                }
            }

            public class c_grid_header : GridHeader
            {

                public PXTextEditColumnFilter FieldName { get; }
                public PXTextEditColumnFilter DisplayName { get; }
                public PXTextEditColumnFilter Value { get; }

                public c_grid_header(c_addnewkeys_grdkeys grid) :
                        base(grid)
                {
                    FieldName = new PXTextEditColumnFilter(grid.Row.FieldName);
                    DisplayName = new PXTextEditColumnFilter(grid.Row.DisplayName);
                    Value = new PXTextEditColumnFilter(grid.Row.Value);
                }
            }
        }

        public class c_addnewkeys_lv0 : Container
        {

            public PxButtonCollection Buttons;

            public DateSelector Ed { get; }
            public Label EdLabel { get; }
            public DropDown Ec { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }
            public Selector Em { get; }
            public Label EmLabel { get; }

            public c_addnewkeys_lv0(string locator, string name) :
                    base(locator, name)
            {
                Ed = new DateSelector("ctl00_phG_dlgEnterKeys_grdKeys_lv0_ed", "Ed", locator, null);
                EdLabel = new Label(Ed);
                Ec = new DropDown("ctl00_phG_dlgEnterKeys_grdKeys_lv0_ec", "Ec", locator, null);
                Es = new Selector("ctl00_phG_dlgEnterKeys_grdKeys_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Em = new Selector("ctl00_phG_dlgEnterKeys_grdKeys_lv0_em", "Em", locator, null);
                EmLabel = new Label(Em);
                DataMemberName = "AddNewKeys";
                Buttons = new PxButtonCollection();
            }

            public virtual void First()
            {
                Buttons.First.Click();
            }

            public virtual void Prev()
            {
                Buttons.Prev.Click();
            }

            public virtual void Next()
            {
                Buttons.Next.Click();
            }

            public virtual void Last()
            {
                Buttons.Last.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public virtual void Finish()
            {
                Buttons.Finish.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button Cancel { get; }
                public Button Finish { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_dlgEnterKeys_grdKeys_lfFirst0", "First", "ctl00_phG_dlgEnterKeys_grdKeys_lv0");
                    Prev = new Button("ctl00_phG_dlgEnterKeys_grdKeys_lfPrev0", "Prev", "ctl00_phG_dlgEnterKeys_grdKeys_lv0");
                    Next = new Button("ctl00_phG_dlgEnterKeys_grdKeys_lfNext0", "Next", "ctl00_phG_dlgEnterKeys_grdKeys_lv0");
                    Last = new Button("ctl00_phG_dlgEnterKeys_grdKeys_lfLast0", "Last", "ctl00_phG_dlgEnterKeys_grdKeys_lv0");
                    Cancel = new Button("ctl00_phG_dlgEnterKeys_btnCancelAddNew", "Cancel", "ctl00_phG_dlgEnterKeys_grdKeys_lv0");
                    Finish = new Button("ctl00_phG_dlgEnterKeys_btnFinishAddNew", "Finish", "ctl00_phG_dlgEnterKeys_grdKeys_lv0");
                }
            }
        }

        public class c_fields_grdfields : Grid<c_fields_grdfields.c_grid_row, c_fields_grdfields.c_grid_header>
        {

            public PxButtonCollection Buttons;

            public c_grid_filter FilterForm { get; }

            public c_fields_grdfields(string locator, string name) :
                    base(locator, name)
            {
                DataMemberName = "Fields";
                Buttons = new PxButtonCollection();
                FilterForm = new c_grid_filter("ctl00_phG_dlgUpdateParams_grdFields_fe_gf", "FilterForm");
            }

            public virtual void First()
            {
                Buttons.First.Click();
            }

            public virtual void Prev()
            {
                Buttons.Prev.Click();
            }

            public virtual void Next()
            {
                Buttons.Next.Click();
            }

            public virtual void Last()
            {
                Buttons.Last.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public virtual void Finish()
            {
                Buttons.Finish.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button Cancel { get; }
                public Button Finish { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_dlgUpdateParams_grdFields_lfFirst0", "First", "ctl00_phG_dlgUpdateParams_grdFields");
                    Prev = new Button("ctl00_phG_dlgUpdateParams_grdFields_lfPrev0", "Prev", "ctl00_phG_dlgUpdateParams_grdFields");
                    Next = new Button("ctl00_phG_dlgUpdateParams_grdFields_lfNext0", "Next", "ctl00_phG_dlgUpdateParams_grdFields");
                    Last = new Button("ctl00_phG_dlgUpdateParams_grdFields_lfLast0", "Last", "ctl00_phG_dlgUpdateParams_grdFields");
                    Cancel = new Button("ctl00_phG_dlgUpdateParams_btnCancelMassUpdates", "Cancel", "ctl00_phG_dlgUpdateParams_grdFields");
                    Finish = new Button("ctl00_phG_dlgUpdateParams_btnFinishMassUpdates", "Finish", "ctl00_phG_dlgUpdateParams_grdFields");
                }
            }

            public class c_grid_row : GridRow
            {

                public CheckBox Selected { get; }
                public PXTextEdit FieldName { get; }
                public PXTextEdit DisplayName { get; }
                public PXTextEdit Value { get; }

                public c_grid_row(c_fields_grdfields grid) :
                        base(grid)
                {
                    Selected = new CheckBox("ctl00_phG_dlgUpdateParams_grdFields_ef", "Selected", grid.Locator, "Selected");
                    Selected.DataField = "Selected";
                    FieldName = new PXTextEdit("ctl00_phG_dlgUpdateParams_grdFields_ei", "FieldName", grid.Locator, "FieldName");
                    FieldName.DataField = "FieldName";
                    DisplayName = new PXTextEdit("ctl00_phG_dlgUpdateParams_grdFields_ei", "Name", grid.Locator, "DisplayName");
                    DisplayName.DataField = "DisplayName";
                    Value = new PXTextEdit("ctl00_phG_dlgUpdateParams_grdFields_ei", "Value", grid.Locator, "Value");
                    Value.DataField = "Value";
                }
            }

            public class c_grid_header : GridHeader
            {

                public CheckBoxColumnFilter Selected { get; }
                public PXTextEditColumnFilter FieldName { get; }
                public PXTextEditColumnFilter DisplayName { get; }
                public PXTextEditColumnFilter Value { get; }

                public c_grid_header(c_fields_grdfields grid) :
                        base(grid)
                {
                    Selected = new CheckBoxColumnFilter(grid.Row.Selected);
                    FieldName = new PXTextEditColumnFilter(grid.Row.FieldName);
                    DisplayName = new PXTextEditColumnFilter(grid.Row.DisplayName);
                    Value = new PXTextEditColumnFilter(grid.Row.Value);
                }
            }
        }

        public class c_fields_lv0 : Container
        {

            public PxButtonCollection Buttons;

            public DateSelector Ed { get; }
            public Label EdLabel { get; }
            public DropDown Ec { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }
            public Selector Em { get; }
            public Label EmLabel { get; }

            public c_fields_lv0(string locator, string name) :
                    base(locator, name)
            {
                Ed = new DateSelector("ctl00_phG_dlgUpdateParams_grdFields_lv0_ed", "Ed", locator, null);
                EdLabel = new Label(Ed);
                Ec = new DropDown("ctl00_phG_dlgUpdateParams_grdFields_lv0_ec", "Ec", locator, null);
                Es = new Selector("ctl00_phG_dlgUpdateParams_grdFields_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Em = new Selector("ctl00_phG_dlgUpdateParams_grdFields_lv0_em", "Em", locator, null);
                EmLabel = new Label(Em);
                DataMemberName = "Fields";
                Buttons = new PxButtonCollection();
            }

            public virtual void First()
            {
                Buttons.First.Click();
            }

            public virtual void Prev()
            {
                Buttons.Prev.Click();
            }

            public virtual void Next()
            {
                Buttons.Next.Click();
            }

            public virtual void Last()
            {
                Buttons.Last.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public virtual void Finish()
            {
                Buttons.Finish.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button Cancel { get; }
                public Button Finish { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_dlgUpdateParams_grdFields_lfFirst0", "First", "ctl00_phG_dlgUpdateParams_grdFields_lv0");
                    Prev = new Button("ctl00_phG_dlgUpdateParams_grdFields_lfPrev0", "Prev", "ctl00_phG_dlgUpdateParams_grdFields_lv0");
                    Next = new Button("ctl00_phG_dlgUpdateParams_grdFields_lfNext0", "Next", "ctl00_phG_dlgUpdateParams_grdFields_lv0");
                    Last = new Button("ctl00_phG_dlgUpdateParams_grdFields_lfLast0", "Last", "ctl00_phG_dlgUpdateParams_grdFields_lv0");
                    Cancel = new Button("ctl00_phG_dlgUpdateParams_btnCancelMassUpdates", "Cancel", "ctl00_phG_dlgUpdateParams_grdFields_lv0");
                    Finish = new Button("ctl00_phG_dlgUpdateParams_btnFinishMassUpdates", "Finish", "ctl00_phG_dlgUpdateParams_grdFields_lv0");
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

        public class c_pivot_grid : PivotTable<c_pivot_grid.c_pivot_filters, c_pivot_grid.c_pivot_rows, c_pivot_grid.c_pivot_columns, c_pivot_grid.c_pivot_values>
        {

            public PxToolBar ToolBar;

            public c_pivot_grid(String locator, String name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_grid_pivotT");
            }

            public virtual void CollapseAll()
            {
                ToolBar.CollapseAll.Click();
            }

            public virtual void ExpandAll()
            {
                ToolBar.ExpandAll.Click();
            }

            public virtual void YPageFirst()
            {
                ToolBar.YPageFirst.Click();
            }

            public virtual void YPagePrev()
            {
                ToolBar.YPagePrev.Click();
            }

            public virtual void YPageNext()
            {
                ToolBar.YPageNext.Click();
            }

            public virtual void YPageLast()
            {
                ToolBar.YPageLast.Click();
            }

            public virtual void XPageFirst()
            {
                ToolBar.XPageFirst.Click();
            }

            public virtual void XPagePrev()
            {
                ToolBar.XPagePrev.Click();
            }

            public virtual void XPageNext()
            {
                ToolBar.XPageNext.Click();
            }

            public virtual void XPageLast()
            {
                ToolBar.XPageLast.Click();
            }

            public class c_pivot_filters : PivotFilters
            {

                public c_pivot_filters(string locator, PivotTableBase pivotTable) :
                        base(locator, pivotTable)
                {
                }
            }

            public class c_pivot_rows : PivotRows
            {

                public c_pivot_rows(string locator, PivotTableBase pivotTable) :
                        base(locator, pivotTable)
                {
                }
            }

            public class c_pivot_columns : PivotColumns
            {

                public c_pivot_columns(string locator, PivotTableBase pivotTable) :
                        base(locator, pivotTable)
                {
                }
            }

            public class c_pivot_values : PivotValues
            {

                public c_pivot_values(string locator, PivotTableBase pivotTable) :
                        base(locator, pivotTable)
                {
                }
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid CollapseAll { get; }
                public ToolBarButtonGrid ExpandAll { get; }
                public ToolBarButtonGrid YPageFirst { get; }
                public ToolBarButtonGrid YPagePrev { get; }
                public ToolBarButtonGrid YPageNext { get; }
                public ToolBarButtonGrid YPageLast { get; }
                public ToolBarButtonGrid XPageFirst { get; }
                public ToolBarButtonGrid XPagePrev { get; }
                public ToolBarButtonGrid XPageNext { get; }
                public ToolBarButtonGrid XPageLast { get; }

                public PxToolBar(string locator)
                {
                    CollapseAll = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'CollapseAll\']", "Collapse All", locator, null);
                    ExpandAll = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'ExpandAll\']", "Expand All", locator, null);
                    YPageFirst = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'YPageFirst\']", "YPageFirst", locator, null);
                    YPagePrev = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'YPagePrev\']", "YPagePrev", locator, null);
                    YPageNext = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'YPageNext\']", "YPageNext", locator, null);
                    YPageLast = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'YPageLast\']", "YPageLast", locator, null);
                    XPageFirst = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'XPageFirst\']", "XPageFirst", locator, null);
                    XPagePrev = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'XPagePrev\']", "XPagePrev", locator, null);
                    XPageNext = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'XPageNext\']", "XPageNext", locator, null);
                    XPageLast = new ToolBarButtonGrid("css=#ctl00_phG_grid_pivotT_tlbB div[data-cmd=\'XPageLast\']", "XPageLast", locator, null);
                }
            }
        }
    }
}
