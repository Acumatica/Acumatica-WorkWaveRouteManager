using Api;
using Controls.Alert;
using Controls.Button;
using Controls.CheckBox;
using Controls.Container;
using Controls.Container.Extentions;
using Controls.Editors.DateSelector;
using Controls.Editors.DropDown;
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
using Controls.UnknownControl;
using Core;
using Core.ApiConnection;
using Core.Core.Browser;
using Core.Wait;
using System;


namespace WorkWaveIntegrationQA.Tests.Wrappers
{


    public class IN303000_INAdjustmentEntry : Wrapper
    {

        public Note NotePanel;

        public ActivityPanel ActivityPanel;

        public SmartPanel_AttachFile FilesUploadDialog;

        public PxToolBar ToolBar;

        public Container Translations { get; } = new Container("ctl00_L10nEditor", "Translations");
        protected c_adjustment_form Adjustment_form { get; } = new c_adjustment_form("ctl00_phF_form", "adjustment_form");
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
        protected c_currentdocument_form2 CurrentDocument_form2 { get; } = new c_currentdocument_form2("ctl00_phG_tab_t1_form2", "CurrentDocument_form2");
        protected c_currentdocument_formam1 CurrentDocument_formam1 { get; } = new c_currentdocument_formam1("ctl00_phG_tab_t2_formam1", "CurrentDocument_formam1");
        protected c_transactions_grid Transactions_grid { get; } = new c_transactions_grid("ctl00_phG_tab_t0_grid", "transactions_grid");
        protected c_transactions_lv0 Transactions_lv0 { get; } = new c_transactions_lv0("ctl00_phG_tab_t0_grid_lv0", "transactions_lv0");
        protected c_sitestatusfilter_formsitesstatus Sitestatusfilter_formsitesstatus { get; } = new c_sitestatusfilter_formsitesstatus("ctl00_phG_PanelAddSiteStatus_formSitesStatus", "sitestatusfilter_formSitesStatus");
        protected c_sitestatus_gripsitestatus Sitestatus_gripsitestatus { get; } = new c_sitestatus_gripsitestatus("ctl00_phG_PanelAddSiteStatus_gripSiteStatus", "siteStatus_gripSiteStatus");
        protected c_sitestatus_lv0 Sitestatus_lv0 { get; } = new c_sitestatus_lv0("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0", "siteStatus_lv0");
        protected c_workflowview_workflowfictivediagram WorkflowView_WorkflowFictiveDiagram { get; } = new c_workflowview_workflowfictivediagram("ctl00_usrCaption_WorkflowDiagram_pnlWorkFlow_WorkflowFictiveDiagram", "WorkflowView_WorkflowFictiveDiagram");
        protected c_filterpreview_formpreview FilterPreview_FormPreview { get; } = new c_filterpreview_formpreview("ctl00_usrCaption_PanelDynamicForm_FormPreview", "FilterPreview_FormPreview");
        protected c_transactions_importcsvsettings_frmimportcsvsettings Transactions_importcsvsettings_frmimportcsvsettings { get; } = new c_transactions_importcsvsettings_frmimportcsvsettings("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_frmImportCSVSettings", "transactions$ImportCSVSettings_frmImportCSVSettings");
        protected c_transactions_importxlsxsettings_frmimportxlsxsettings Transactions_importxlsxsettings_frmimportxlsxsettings { get; } = new c_transactions_importxlsxsettings_frmimportxlsxsettings("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_frmImportXLSXSettings", "transactions$ImportXLSXSettings_frmImportXLSXSettings");
        protected c_transactions_importcolumns_grdimportcolumn Transactions_importcolumns_grdimportcolumn { get; } = new c_transactions_importcolumns_grdimportcolumn("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn", "transactions$ImportColumns_grdImportColumn");
        protected c_transactions_importcolumns_lv0 Transactions_importcolumns_lv0 { get; } = new c_transactions_importcolumns_lv0("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0", "transactions$ImportColumns_lv0");
        public c_attributes Attributes { get; } = new c_attributes("ctl00_phF_form_t1", "Attributes");

        public IN303000_INAdjustmentEntry()
        {
            ScreenId = "IN303000";
            ScreenUrl = "/Pages/IN/IN303000.aspx";
            NotePanel = new Note("ctl00_usrCaption_tlbDataView");
            ActivityPanel = new ActivityPanel("ctl00_usrCaption_tlbDataView");
            FilesUploadDialog = new SmartPanel_AttachFile("ctl00_usrCaption_tlbDataView");
            ToolBar = new PxToolBar(null);
        }

        public virtual IN303000_INAdjustmentEntry ReadOne(Gate gate, string RefNbr)
        {
            new BiObject<IN303000_INAdjustmentEntry>(gate).ReadOne(this, RefNbr);
            return this;
        }

        public virtual IN303000_INAdjustmentEntry ReadOne(string RefNbr)
        {
            return this.ReadOne(ApiConnection.Source, RefNbr);
        }

        public virtual void SyncTOC()
        {
            ToolBar.SyncTOC.Click();
        }

        public virtual void Note()
        {
            ToolBar.Note.Click();
        }

        public virtual void ActivityShow()
        {
            ToolBar.ActivityShow.Click();
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

        public virtual void ManageAttributes()
        {
            ToolBar.ManageAttributes.Click();
        }

        public virtual void MenuEditProj()
        {
            ToolBar.MenuEditProj.Click();
        }

        public virtual void ManageCustomizations()
        {
            ToolBar.ManageCustomizations.Click();
        }

        public virtual void ShowWorkflow()
        {
            ToolBar.ShowWorkflow.Click();
        }

        public virtual void KeyBtnRefresh()
        {
            ToolBar.KeyBtnRefresh.Click();
        }

        public virtual void Help()
        {
            ToolBar.Help.Click();
        }

        public virtual void MenuOpener()
        {
            ToolBar.MenuOpener.Click();
        }

        public virtual void CancelClose()
        {
            ToolBar.CancelClose.Click();
        }

        public virtual void SaveClose()
        {
            ToolBar.SaveClose.Click();
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

        public virtual void CopyPaste()
        {
            ToolBar.CopyPaste.Click();
        }

        public virtual void CopyDocument()
        {
            ToolBar.CopyDocument.Click();
        }

        public virtual void PasteDocument()
        {
            ToolBar.PasteDocument.Click();
        }

        public virtual void SaveTemplate()
        {
            ToolBar.SaveTemplate.Click();
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

        public virtual void InitializeState()
        {
            ToolBar.InitializeState.Click();
        }

        public virtual void ReleaseFromHold()
        {
            ToolBar.ReleaseFromHold.Click();
        }

        public virtual void PutOnHold()
        {
            ToolBar.PutOnHold.Click();
        }

        public virtual void Release()
        {
            ToolBar.Release.Click();
        }

        public virtual void Release(bool status, string message = null)
        {
            ToolBar.Release.WaitActionOverride = () => Wait.WaitForLongOperationToComplete(status, message);
            ToolBar.Release.Click();
        }

        public virtual void INEdit()
        {
            ToolBar.INEdit.Click();
        }

        public virtual void INRegisterDetails()
        {
            ToolBar.INRegisterDetails.Click();
        }

        public virtual void ViewBatch()
        {
            ToolBar.ViewBatch.Click();
        }

        public virtual void ProcessingCategory()
        {
            ToolBar.ProcessingCategory.Click();
        }

        public virtual void Report()
        {
            ToolBar.Report.Click();
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
            public ToolBarButton ActivityShow { get; }
            public ToolBarButton FilesMenuShow { get; }
            public ToolBarButton Custom { get; }
            public ToolBarButton ActionSelectWorkingProject { get; }
            public ToolBarButton InspectElementCtrlAltClick { get; }
            public ToolBarButton ManageAttributes { get; }
            public ToolBarButton MenuEditProj { get; }
            public ToolBarButton ManageCustomizations { get; }
            public ToolBarButton ShowWorkflow { get; }
            public ToolBarButton KeyBtnRefresh { get; }
            public ToolBarButton Help { get; }
            public ToolBarButton MenuOpener { get; }
            public ToolBarButton CancelClose { get; }
            public ToolBarButton SaveClose { get; }
            public ToolBarButton Save { get; }
            public ToolBarButton Cancel { get; }
            public ToolBarButton Insert { get; }
            public ToolBarButton Delete { get; }
            public ToolBarButton CopyPaste { get; }
            public ToolBarButton CopyDocument { get; }
            public ToolBarButton PasteDocument { get; }
            public ToolBarButton SaveTemplate { get; }
            public ToolBarButton First { get; }
            public ToolBarButton Previous { get; }
            public ToolBarButton Next { get; }
            public ToolBarButton Last { get; }
            public ToolBarButton InitializeState { get; }
            public ToolBarButton ReleaseFromHold { get; }
            public ToolBarButton PutOnHold { get; }
            public ToolBarButton Release { get; }
            public ToolBarButton INEdit { get; }
            public ToolBarButton INRegisterDetails { get; }
            public ToolBarButton ViewBatch { get; }
            public ToolBarButton ProcessingCategory { get; }
            public ToolBarButton Report { get; }
            public ToolBarButton LongRun { get; }
            public ToolBarButton LongrunCancel { get; }
            public ToolBarButton LongrunTimer { get; }

            public PxToolBar(string locator)
            {
                SyncTOC = new ToolBarButton("css=#ctl00_usrCaption_tlbPath div[data-cmd=\'syncTOC\']", "Sync Navigation Pane", locator, null);
                Note = new ToolBarButton("css=#ctl00_usrCaption_tlbDataView div[data-cmd=\'NoteShow\']", "Add Note", locator, null);
                ActivityShow = new ToolBarButton("css=#ctl00_usrCaption_tlbDataView div[data-cmd=\'ActivityShow\']", "Activities", locator, null);
                FilesMenuShow = new ToolBarButton("css=#ctl00_usrCaption_tlbDataView div[data-cmd=\'FilesMenuShow\']", "Files", locator, null);
                Custom = new ToolBarButton("css=#ctl00_usrCaption_CustomizationDialogs_PXToolBar1 div[data-cmd=\'Custom\']", "Customization", locator, null);
                ActionSelectWorkingProject = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li[data-cmd=\'" +
                        "ActionSelectWorkingProject\']", "Select Project...", locator, Custom);
                InspectElementCtrlAltClick = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li.menuItem d" +
                        "iv:textEqual(\"Inspect Element (Ctrl+Alt+Click)\")", "Inspect Element (Ctrl+Alt+Click)", locator, Custom);
                ManageAttributes = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li[data-cmd=\'" +
                        "ManageAttributes\']", "Manage User-Defined Fields", locator, Custom);
                MenuEditProj = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li[data-cmd=\'" +
                        "menuEditProj\']", "Edit Project...", locator, Custom);
                ManageCustomizations = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li.menuItem d" +
                        "iv:textEqual(\"Manage Customizations...\")", "Manage Customizations...", locator, Custom);
                ShowWorkflow = new ToolBarButton("css=div#ctl00_usrCaption_CustomizationDialogs_PXToolBar1_menuCustom li[data-cmd=\'" +
                        "ShowWorkflow\']", "Show state diagram", locator, Custom);
                KeyBtnRefresh = new ToolBarButton("css=#ctl00_usrCaption_tlbTools div[data-cmd=\'keyBtnRefresh\']", "Click to refresh page.", locator, null);
                Help = new ToolBarButton("css=#ctl00_usrCaption_tlbTools div[data-cmd=\'help\']", "View Tools", locator, null);
                MenuOpener = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_MenuOpener", "Menu", locator, null);
                CancelClose = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_CancelClose", "Discard Changes and Close", locator, null);
                CancelClose.ConfirmAction = () => Alert.AlertToException("Any unsaved changes will be discarded.");
                SaveClose = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_SaveClose", "Save the current record and close the screen (Ctrl+Shift+S).", locator, null);
                Save = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Save", "Save (Ctrl+S).", locator, null);
                Cancel = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Cancel", "Cancel (Esc)", locator, null);
                Cancel.ConfirmAction = () => Alert.AlertToException("Any unsaved changes will be discarded.");
                Insert = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Insert", "Add New Record (Ctrl+Ins)", locator, null);
                Delete = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Delete", "Delete (Ctrl+Del).", locator, null);
                Delete.ConfirmAction = () => Alert.AlertToException("The current Receipt record will be deleted.");
                CopyPaste = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_CopyPaste", "Clipboard", locator, null);
                CopyDocument = new ToolBarButton("css=[id=\'ctl00_phDS_ds_ToolBar_CopyPaste@CopyDocument\']", "CopyDocument", locator, CopyPaste);
                PasteDocument = new ToolBarButton("css=[id=\'ctl00_phDS_ds_ToolBar_CopyPaste@PasteDocument\']", "PasteDocument", locator, CopyPaste);
                SaveTemplate = new ToolBarButton("css=[id=\'ctl00_phDS_ds_ToolBar_CopyPaste@SaveTemplate\']", "SaveTemplate", locator, CopyPaste);
                First = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_First", "Go to First Record", locator, null);
                Previous = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Previous", "Go to Previous Record (PgUp)", locator, null);
                Next = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Next", "Go to Next Record (PgDn)", locator, null);
                Last = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Last", "Go to Last Record", locator, null);
                InitializeState = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_initializeState,#ctl00_phDS_ds_ToolBar_initializeState" +
                        "_item", "initializeState", locator, MenuOpener);
                ReleaseFromHold = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ReleaseFromHold,#ctl00_phDS_ds_ToolBar_ReleaseFromHold" +
                        "_item", "Remove Hold", locator, MenuOpener);
                PutOnHold = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_PutOnHold,#ctl00_phDS_ds_ToolBar_PutOnHold_item", "Hold", locator, MenuOpener);
                Release = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Release,#ctl00_phDS_ds_ToolBar_Release_item", "Release", locator, MenuOpener);
                Release.WaitAction = Wait.WaitForLongOperationToComplete;
                INEdit = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_INEdit,#ctl00_phDS_ds_ToolBar_INEdit_item", "Inventory Edit Details", locator, MenuOpener);
                INRegisterDetails = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_INRegisterDetails,#ctl00_phDS_ds_ToolBar_INRegisterDet" +
                        "ails_item", "Inventory Register Detailed", locator, MenuOpener);
                ViewBatch = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ViewBatch,#ctl00_phDS_ds_ToolBar_ViewBatch_item", "Review Batch", locator, MenuOpener);
                ProcessingCategory = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Processing_Category", "Processing", locator, MenuOpener);
                Report = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Report", "Reports", locator, MenuOpener);
                LongRun = new ToolBarButton("css=qp-long-run", "Nothing in progress", locator, null);
                LongrunCancel = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_cancel", "Cancel", locator, null);
                LongrunTimer = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_timer", "Elapsed Time", locator, null);
            }
        }

        public class c_adjustment_form : Container
        {

            public Selector RefNbr { get; }
            public Label RefNbrLabel { get; }
            public DropDown Status { get; }
            public Label StatusLabel { get; }
            public DateSelector TranDate { get; }
            public Label TranDateLabel { get; }
            public Selector FinPeriodID { get; }
            public Label FinPeriodIDLabel { get; }
            public PXTextEdit ExtRefNbr { get; }
            public Label ExtRefNbrLabel { get; }
            public Selector PIID { get; }
            public Label PIIDLabel { get; }
            public PXTextEdit TranDesc { get; }
            public Label TranDescLabel { get; }
            public PXNumberEdit TotalQty { get; }
            public Label TotalQtyLabel { get; }
            public PXNumberEdit ControlQty { get; }
            public Label ControlQtyLabel { get; }
            public PXNumberEdit TotalCost { get; }
            public Label TotalCostLabel { get; }
            public PXNumberEdit ControlCost { get; }
            public Label ControlCostLabel { get; }
            public Label Ctl02_ { get; }

            public c_adjustment_form(string locator, string name) :
                    base(locator, name)
            {
                RefNbr = new Selector("ctl00_phF_form_t0_edRefNbr", "Reference Nbr.", locator, null);
                RefNbrLabel = new Label(RefNbr);
                RefNbr.DataField = "RefNbr";
                Status = new DropDown("ctl00_phF_form_t0_edStatus", "Status", locator, null);
                StatusLabel = new Label(Status);
                Status.DataField = "Status";
                Status.Items.Add("H", "On Hold");
                Status.Items.Add("B", "Balanced");
                Status.Items.Add("R", "Released");
                TranDate = new DateSelector("ctl00_phF_form_t0_edTranDate", "Date", locator, null);
                TranDateLabel = new Label(TranDate);
                TranDate.DataField = "TranDate";
                FinPeriodID = new Selector("ctl00_phF_form_t0_edFinPeriodID", "Post Period", locator, null);
                FinPeriodIDLabel = new Label(FinPeriodID);
                FinPeriodID.DataField = "FinPeriodID";
                ExtRefNbr = new PXTextEdit("ctl00_phF_form_t0_edExtRefNbr", "External Ref.", locator, null);
                ExtRefNbrLabel = new Label(ExtRefNbr);
                ExtRefNbr.DataField = "ExtRefNbr";
                PIID = new Selector("ctl00_phF_form_t0_pIID", "PI Count Reference Nbr.", locator, null);
                PIIDLabel = new Label(PIID);
                PIID.DataField = "PIID";
                TranDesc = new PXTextEdit("ctl00_phF_form_t0_edTranDesc", "Description", locator, null);
                TranDescLabel = new Label(TranDesc);
                TranDesc.DataField = "TranDesc";
                TotalQty = new PXNumberEdit("ctl00_phF_form_t0_edTotalQty", "Total Qty.", locator, null);
                TotalQtyLabel = new Label(TotalQty);
                TotalQty.DataField = "TotalQty";
                ControlQty = new PXNumberEdit("ctl00_phF_form_t0_edControlQty", "Control Qty.", locator, null);
                ControlQtyLabel = new Label(ControlQty);
                ControlQty.DataField = "ControlQty";
                TotalCost = new PXNumberEdit("ctl00_phF_form_t0_edTotalCost", "Total Cost", locator, null);
                TotalCostLabel = new Label(TotalCost);
                TotalCost.DataField = "TotalCost";
                ControlCost = new PXNumberEdit("ctl00_phF_form_t0_edControlCost", "Control Cost", locator, null);
                ControlCostLabel = new Label(ControlCost);
                ControlCost.DataField = "ControlCost";
                Ctl02_ = new Label("ctl00_phF_form_t1_ctl02", "No user-defined fields have been found.", locator, null);
                DataMemberName = "adjustment";
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

        public class c_currentdocument_form2 : Container
        {

            public Selector BatchNbr { get; }
            public Label BatchNbrLabel { get; }
            public Selector BranchID { get; }
            public Label BranchIDLabel { get; }
            public PXTextEdit BranchBaseCuryID { get; }
            public Label BranchBaseCuryIDLabel { get; }

            public c_currentdocument_form2(string locator, string name) :
                    base(locator, name)
            {
                BatchNbr = new Selector("ctl00_phG_tab_t1_form2_edBatchNbr", "Batch Nbr.", locator, null);
                BatchNbrLabel = new Label(BatchNbr);
                BatchNbr.DataField = "BatchNbr";
                BranchID = new Selector("ctl00_phG_tab_t1_form2_edBranchID", "Branch", locator, null);
                BranchIDLabel = new Label(BranchID);
                BranchID.DataField = "BranchID";
                BranchBaseCuryID = new PXTextEdit("ctl00_phG_tab_t1_form2_edBranchBaseCuryID", "Currency", locator, null);
                BranchBaseCuryIDLabel = new Label(BranchBaseCuryID);
                BranchBaseCuryID.DataField = "BranchBaseCuryID";
                DataMemberName = "CurrentDocument";
            }
        }

        public class c_currentdocument_formam1 : Container
        {

            public Selector AMBatNbr { get; }
            public Label AMBatNbrLabel { get; }
            public DropDown AMDocType { get; }
            public Label AMDocTypeLabel { get; }

            public c_currentdocument_formam1(string locator, string name) :
                    base(locator, name)
            {
                AMBatNbr = new Selector("ctl00_phG_tab_t2_formam1_edAMBatNbr", "MFG Batch Nbr", locator, null);
                AMBatNbrLabel = new Label(AMBatNbr);
                AMBatNbr.DataField = "AMBatNbr";
                AMDocType = new DropDown("ctl00_phG_tab_t2_formam1_edAMDocType", "MFG Document Type", locator, null);
                AMDocTypeLabel = new Label(AMDocType);
                AMDocType.DataField = "AMDocType";
                DataMemberName = "CurrentDocument";
            }
        }

        public class c_transactions_grid : Grid<c_transactions_grid.c_grid_row, c_transactions_grid.c_grid_header>
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            private Label _StatusBar = new Label("ctl00_phG_tab_t0_grid_ab_tlb_ul", "Status Bar", "ctl00_phG_tab_t0_grid", null);

            public c_grid_upload UploadForm { get; }
            public c_grid_filter FilterForm { get; }
            public SmartPanel_AttachFile FilesUploadDialog { get; }
            public Note NotePanel { get; }

            public c_transactions_grid(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t0_grid");
                DataMemberName = "transactions";
                Buttons = new PxButtonCollection();
                UploadForm = new c_grid_upload("ctl00_phG_tab_t0_grid_imp_upl_pnl", "UploadForm");
                FilterForm = new c_grid_filter("ctl00_phG_tab_t0_grid_fe_gf", "FilterForm");
                FilesUploadDialog = new SmartPanel_AttachFile(locator);
                NotePanel = new Note(locator);
            }

            public virtual Label StatusBar
            {
                get
                {
                    return _StatusBar;
                }
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

            public virtual void Split()
            {
                ToolBar.Split.Click();
            }

            public virtual void AddItems()
            {
                ToolBar.AddItems.Click();
            }

            public virtual void InventorySummary()
            {
                ToolBar.InventorySummary.Click();
            }

            public virtual void Adjust()
            {
                ToolBar.Adjust.Click();
            }

            public virtual void Export()
            {
                ToolBar.Export.Click();
            }

            public virtual void Upload()
            {
                ToolBar.Upload.Click();
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

            public virtual void SOShipmentNbrEdit()
            {
                Buttons.SOShipmentNbrEdit.Click();
            }

            public virtual void POReceiptNbrEdit()
            {
                Buttons.POReceiptNbrEdit.Click();
            }

            public virtual void SOOrderNbrEdit()
            {
                Buttons.SOOrderNbrEdit.Click();
            }

            public virtual void Ok()
            {
                Buttons.Ok.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public virtual void Ok1()
            {
                Buttons.Ok1.Click();
            }

            public virtual void Cancel1()
            {
                Buttons.Cancel1.Click();
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

            public virtual void Ok2()
            {
                Buttons.Ok2.Click();
            }

            public virtual void Cancel2()
            {
                Buttons.Cancel2.Click();
            }

            public virtual void Upload1()
            {
                Buttons.Upload1.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid New { get; }
                public ToolBarButtonGrid Delete { get; }
                public ToolBarButtonGrid Split { get; }
                public ToolBarButtonGrid AddItems { get; }
                public ToolBarButtonGrid InventorySummary { get; }
                public ToolBarButtonGrid Adjust { get; }
                public ToolBarButtonGrid Export { get; }
                public ToolBarButtonGrid Upload { get; }
                public ToolBarButtonGrid Hi { get; }
                public ToolBarButtonGrid PageFirst { get; }
                public ToolBarButtonGrid PagePrev { get; }
                public ToolBarButtonGrid PageNext { get; }
                public ToolBarButtonGrid PageLast { get; }
                public ToolBarButtonGrid Hi1 { get; }

                public PxToolBar(string locator)
                {
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Delete.ConfirmAction = () => Alert.AlertToException("The current {0} record will be deleted.");
                    Split = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'cmdSplit\']", "Split", locator, null);
                    AddItems = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'cmdASI\']", "Add Items", locator, null);
                    InventorySummary = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'InventorySummary\']", "Inventory Summary", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Upload = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'Upload\']", "Load Records from File", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_grid_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button SOShipmentNbrEdit { get; }
                public Button POReceiptNbrEdit { get; }
                public Button SOOrderNbrEdit { get; }
                public Button Ok { get; }
                public Button Cancel { get; }
                public Button Ok1 { get; }
                public Button Cancel1 { get; }
                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button Ok2 { get; }
                public Button Cancel2 { get; }
                public Button Upload1 { get; }

                public PxButtonCollection()
                {
                    SOShipmentNbrEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_grid_lv0_edSOShipmentNbr\'] div[class=\'editBtnCont\'] " +
                            "> div > div", "SOShipmentNbrEdit", "ctl00_phG_tab_t0_grid");
                    SOShipmentNbrEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    POReceiptNbrEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_grid_lv0_edPOReceiptNbr\'] div[class=\'editBtnCont\'] >" +
                            " div > div", "POReceiptNbrEdit", "ctl00_phG_tab_t0_grid");
                    POReceiptNbrEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    SOOrderNbrEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_grid_lv0_edSOOrderNbr\'] div[class=\'editBtnCont\'] > d" +
                            "iv > div", "SOOrderNbrEdit", "ctl00_phG_tab_t0_grid");
                    SOOrderNbrEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    Ok = new Button("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_btnSave1", "OK", "ctl00_phG_tab_t0_grid");
                    Cancel = new Button("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_btnCancel1", "Cancel", "ctl00_phG_tab_t0_grid");
                    Ok1 = new Button("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_btnSave2", "OK", "ctl00_phG_tab_t0_grid");
                    Cancel1 = new Button("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_btnCancel2", "Cancel", "ctl00_phG_tab_t0_grid");
                    First = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfFirst0", "First", "ctl00_phG_tab_t0_grid");
                    Prev = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfPrev0", "Prev", "ctl00_phG_tab_t0_grid");
                    Next = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfNext0", "Next", "ctl00_phG_tab_t0_grid");
                    Last = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfLast0", "Last", "ctl00_phG_tab_t0_grid");
                    Ok2 = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_btnSave", "OK", "ctl00_phG_tab_t0_grid");
                    Cancel2 = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_btnCancel", "Cancel", "ctl00_phG_tab_t0_grid");
                    Upload1 = new Button("ctl00_phG_tab_t0_grid_imp_upl_pnl_btnUpload", "Upload", "ctl00_phG_tab_t0_grid");
                }
            }

            public class c_grid_row : GridRow
            {

                public FileColumnButton Files { get; }
                public NoteColumnButton Notes { get; }
                public PXNumberEdit PILineNbr { get; }
                public Selector BranchID { get; }
                public Selector InventoryID { get; }
                public Selector SubItemID { get; }
                public Selector SiteID { get; }
                public Selector LocationID { get; }
                public Selector ProjectID { get; }
                public Selector TaskID { get; }
                public Selector CostCodeID { get; }
                public PXNumberEdit Qty { get; }
                public Selector UOM { get; }
                public PXNumberEdit UnitCost { get; }
                public PXNumberEdit TranCost { get; }
                public CheckBox ManualCost { get; }
                public Selector LotSerialNbr { get; }
                public DateSelector ExpireDate { get; }
                public Selector OrigRefNbr { get; }
                public Selector ReasonCode { get; }
                public PXTextEdit TranDesc { get; }
                public Selector SOOrderType { get; }
                public Selector SOOrderNbr { get; }
                public Selector SOShipmentNbr { get; }
                public Selector POReceiptNbr { get; }
                public DropDown DocType { get; }
                public PXTextEdit RefNbr { get; }
                public PXNumberEdit LineNbr { get; }
                public PXTextEdit Availability { get; }

                public c_grid_row(c_transactions_grid grid) :
                        base(grid)
                {
                    Files = new FileColumnButton(null, "Files", grid.Locator, "Files");
                    Notes = new NoteColumnButton(null, "Notes", grid.Locator, "Notes");
                    PILineNbr = new PXNumberEdit("ctl00_phG_tab_t0_grid_en", "PI Line Nbr.", grid.Locator, "PILineNbr");
                    PILineNbr.DataField = "PILineNbr";
                    BranchID = new Selector("_ctl00_phG_tab_t0_grid_lv0_edBranchID", "Branch", grid.Locator, "BranchID");
                    BranchID.DataField = "BranchID";
                    InventoryID = new Selector("_ctl00_phG_tab_t0_grid_lv0_edInventoryID", "Inventory ID", grid.Locator, "InventoryID");
                    InventoryID.DataField = "InventoryID";
                    SubItemID = new Selector("_ctl00_phG_tab_t0_grid_lv0_edSubItemID", "Subitem", grid.Locator, "SubItemID");
                    SubItemID.DataField = "SubItemID";
                    SiteID = new Selector("_ctl00_phG_tab_t0_grid_lv0_edSiteID", "Warehouse", grid.Locator, "SiteID");
                    SiteID.DataField = "SiteID";
                    LocationID = new Selector("_ctl00_phG_tab_t0_grid_lv0_edLocationID", "Location", grid.Locator, "LocationID");
                    LocationID.DataField = "LocationID";
                    ProjectID = new Selector("_ctl00_phG_tab_t0_grid_lv0_edProjectID", "Project", grid.Locator, "ProjectID");
                    ProjectID.DataField = "ProjectID";
                    TaskID = new Selector("_ctl00_phG_tab_t0_grid_lv0_edTaskID", "Project Task", grid.Locator, "TaskID");
                    TaskID.DataField = "TaskID";
                    CostCodeID = new Selector("_ctl00_phG_tab_t0_grid_lv0_edCostCodeID", "Cost Code", grid.Locator, "CostCodeID");
                    CostCodeID.DataField = "CostCodeID";
                    Qty = new PXNumberEdit("_ctl00_phG_tab_t0_grid_lv0_edQty", "Quantity", grid.Locator, "Qty");
                    Qty.DataField = "Qty";
                    UOM = new Selector("_ctl00_phG_tab_t0_grid_lv0_edUOM", "UOM", grid.Locator, "UOM");
                    UOM.DataField = "UOM";
                    UnitCost = new PXNumberEdit("_ctl00_phG_tab_t0_grid_lv0_edUnitCost", "Unit Cost", grid.Locator, "UnitCost");
                    UnitCost.DataField = "UnitCost";
                    TranCost = new PXNumberEdit("_ctl00_phG_tab_t0_grid_lv0_edTranCost", "Ext. Cost", grid.Locator, "TranCost");
                    TranCost.DataField = "TranCost";
                    ManualCost = new CheckBox("ctl00_phG_tab_t0_grid", "Manual Cost", grid.Locator, "ManualCost");
                    ManualCost.DataField = "ManualCost";
                    LotSerialNbr = new Selector("_ctl00_phG_tab_t0_grid_lv0_edLotSerialNbr", "Lot/Serial Nbr.", grid.Locator, "LotSerialNbr");
                    LotSerialNbr.DataField = "LotSerialNbr";
                    ExpireDate = new DateSelector("_ctl00_phG_tab_t0_grid_lv0_edExpireDate", "Expiration Date", grid.Locator, "ExpireDate");
                    ExpireDate.DataField = "ExpireDate";
                    OrigRefNbr = new Selector("_ctl00_phG_tab_t0_grid_lv0_edOrigRefNbr", "Receipt Nbr.", grid.Locator, "OrigRefNbr");
                    OrigRefNbr.DataField = "OrigRefNbr";
                    ReasonCode = new Selector("_ctl00_phG_tab_t0_grid_lv0_edReasonCode", "Reason Code", grid.Locator, "ReasonCode");
                    ReasonCode.DataField = "ReasonCode";
                    TranDesc = new PXTextEdit("_ctl00_phG_tab_t0_grid_lv0_edTranDesc", "Description", grid.Locator, "TranDesc");
                    TranDesc.DataField = "TranDesc";
                    SOOrderType = new Selector("_ctl00_phG_tab_t0_grid_lv0_edSOOrderType", "SO Order Type", grid.Locator, "SOOrderType");
                    SOOrderType.DataField = "SOOrderType";
                    SOOrderNbr = new Selector("_ctl00_phG_tab_t0_grid_lv0_edSOOrderNbr", "SO Order Nbr.", grid.Locator, "SOOrderNbr");
                    SOOrderNbr.DataField = "SOOrderNbr";
                    SOShipmentNbr = new Selector("_ctl00_phG_tab_t0_grid_lv0_edSOShipmentNbr", "SO Shipment Nbr.", grid.Locator, "SOShipmentNbr");
                    SOShipmentNbr.DataField = "SOShipmentNbr";
                    POReceiptNbr = new Selector("_ctl00_phG_tab_t0_grid_lv0_edPOReceiptNbr", "PO Receipt Nbr.", grid.Locator, "POReceiptNbr");
                    POReceiptNbr.DataField = "POReceiptNbr";
                    DocType = new DropDown("_ctl00_phG_tab_t0_grid_lv0_ec", "Document Type", grid.Locator, "DocType");
                    DocType.DataField = "DocType";
                    DocType.Items.Add("I", "Issue");
                    DocType.Items.Add("R", "Receipt");
                    DocType.Items.Add("T", "Transfer");
                    DocType.Items.Add("A", "Adjustment");
                    DocType.Items.Add("P", "Production");
                    DocType.Items.Add("D", "Disassembly");
                    RefNbr = new PXTextEdit("ctl00_phG_tab_t0_grid_ei", "Reference Nbr.", grid.Locator, "RefNbr");
                    RefNbr.DataField = "RefNbr";
                    LineNbr = new PXNumberEdit("ctl00_phG_tab_t0_grid_en", "Line Number", grid.Locator, "LineNbr");
                    LineNbr.DataField = "LineNbr";
                    Availability = new PXTextEdit("ctl00_phG_tab_t0_grid_ei", "Availability", grid.Locator, "Availability");
                    Availability.DataField = "Availability";
                }
            }

            public class c_grid_header : GridHeader
            {

                public GridColumnHeader Files { get; }
                public GridColumnHeader Notes { get; }
                public PXNumberEditColumnFilter PILineNbr { get; }
                public SelectorColumnFilter BranchID { get; }
                public SelectorColumnFilter InventoryID { get; }
                public SelectorColumnFilter SubItemID { get; }
                public SelectorColumnFilter SiteID { get; }
                public SelectorColumnFilter LocationID { get; }
                public SelectorColumnFilter ProjectID { get; }
                public SelectorColumnFilter TaskID { get; }
                public SelectorColumnFilter CostCodeID { get; }
                public PXNumberEditColumnFilter Qty { get; }
                public SelectorColumnFilter UOM { get; }
                public PXNumberEditColumnFilter UnitCost { get; }
                public PXNumberEditColumnFilter TranCost { get; }
                public CheckBoxColumnFilter ManualCost { get; }
                public SelectorColumnFilter LotSerialNbr { get; }
                public DateSelectorColumnFilter ExpireDate { get; }
                public SelectorColumnFilter OrigRefNbr { get; }
                public SelectorColumnFilter ReasonCode { get; }
                public PXTextEditColumnFilter TranDesc { get; }
                public SelectorColumnFilter SOOrderType { get; }
                public SelectorColumnFilter SOOrderNbr { get; }
                public SelectorColumnFilter SOShipmentNbr { get; }
                public SelectorColumnFilter POReceiptNbr { get; }
                public DropDownColumnFilter DocType { get; }
                public PXTextEditColumnFilter RefNbr { get; }
                public PXNumberEditColumnFilter LineNbr { get; }
                public PXTextEditColumnFilter Availability { get; }

                public c_grid_header(c_transactions_grid grid) :
                        base(grid)
                {
                    Files = new GridColumnHeader(grid.Row.Files);
                    Notes = new GridColumnHeader(grid.Row.Notes);
                    PILineNbr = new PXNumberEditColumnFilter(grid.Row.PILineNbr);
                    BranchID = new SelectorColumnFilter(grid.Row.BranchID);
                    InventoryID = new SelectorColumnFilter(grid.Row.InventoryID);
                    SubItemID = new SelectorColumnFilter(grid.Row.SubItemID);
                    SiteID = new SelectorColumnFilter(grid.Row.SiteID);
                    LocationID = new SelectorColumnFilter(grid.Row.LocationID);
                    ProjectID = new SelectorColumnFilter(grid.Row.ProjectID);
                    TaskID = new SelectorColumnFilter(grid.Row.TaskID);
                    CostCodeID = new SelectorColumnFilter(grid.Row.CostCodeID);
                    Qty = new PXNumberEditColumnFilter(grid.Row.Qty);
                    UOM = new SelectorColumnFilter(grid.Row.UOM);
                    UnitCost = new PXNumberEditColumnFilter(grid.Row.UnitCost);
                    TranCost = new PXNumberEditColumnFilter(grid.Row.TranCost);
                    ManualCost = new CheckBoxColumnFilter(grid.Row.ManualCost);
                    LotSerialNbr = new SelectorColumnFilter(grid.Row.LotSerialNbr);
                    ExpireDate = new DateSelectorColumnFilter(grid.Row.ExpireDate);
                    OrigRefNbr = new SelectorColumnFilter(grid.Row.OrigRefNbr);
                    ReasonCode = new SelectorColumnFilter(grid.Row.ReasonCode);
                    TranDesc = new PXTextEditColumnFilter(grid.Row.TranDesc);
                    SOOrderType = new SelectorColumnFilter(grid.Row.SOOrderType);
                    SOOrderNbr = new SelectorColumnFilter(grid.Row.SOOrderNbr);
                    SOShipmentNbr = new SelectorColumnFilter(grid.Row.SOShipmentNbr);
                    POReceiptNbr = new SelectorColumnFilter(grid.Row.POReceiptNbr);
                    DocType = new DropDownColumnFilter(grid.Row.DocType);
                    RefNbr = new PXTextEditColumnFilter(grid.Row.RefNbr);
                    LineNbr = new PXNumberEditColumnFilter(grid.Row.LineNbr);
                    Availability = new PXTextEditColumnFilter(grid.Row.Availability);
                }
            }
        }

        public class c_transactions_lv0 : Container
        {

            public PxButtonCollection Buttons;

            public Selector InventoryID { get; }
            public Label InventoryIDLabel { get; }
            public Selector OrigRefNbr { get; }
            public Label OrigRefNbrLabel { get; }
            public Selector ReasonCode { get; }
            public Label ReasonCodeLabel { get; }
            public Selector SubItemID { get; }
            public Label SubItemIDLabel { get; }
            public Selector SiteID { get; }
            public Label SiteIDLabel { get; }
            public Selector LocationID { get; }
            public Label LocationIDLabel { get; }
            public PXNumberEdit Qty { get; }
            public Label QtyLabel { get; }
            public Selector UOM { get; }
            public Label UOMLabel { get; }
            public PXNumberEdit UnitCost { get; }
            public Label UnitCostLabel { get; }
            public PXNumberEdit TranCost { get; }
            public Label TranCostLabel { get; }
            public Selector LotSerialNbr { get; }
            public Label LotSerialNbrLabel { get; }
            public DateSelector ExpireDate { get; }
            public Label ExpireDateLabel { get; }
            public PXTextEdit TranDesc { get; }
            public Label TranDescLabel { get; }
            public Selector SOShipmentNbr { get; }
            public Label SOShipmentNbrLabel { get; }
            public Selector POReceiptNbr { get; }
            public Label POReceiptNbrLabel { get; }
            public Selector SOOrderType { get; }
            public Label SOOrderTypeLabel { get; }
            public Selector SOOrderNbr { get; }
            public Label SOOrderNbrLabel { get; }
            public Selector BranchID { get; }
            public Label BranchIDLabel { get; }
            public Selector ProjectID { get; }
            public Label ProjectIDLabel { get; }
            public Selector TaskID { get; }
            public Label TaskIDLabel { get; }
            public Selector CostCodeID { get; }
            public Label CostCodeIDLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }
            public DropDown Ec { get; }

            public c_transactions_lv0(string locator, string name) :
                    base(locator, name)
            {
                InventoryID = new Selector("ctl00_phG_tab_t0_grid_lv0_edInventoryID", "Inventory ID", locator, null);
                InventoryIDLabel = new Label(InventoryID);
                InventoryID.DataField = "InventoryID";
                OrigRefNbr = new Selector("ctl00_phG_tab_t0_grid_lv0_edOrigRefNbr", "Receipt Nbr.", locator, null);
                OrigRefNbrLabel = new Label(OrigRefNbr);
                OrigRefNbr.DataField = "OrigRefNbr";
                ReasonCode = new Selector("ctl00_phG_tab_t0_grid_lv0_edReasonCode", "Reason Code", locator, null);
                ReasonCodeLabel = new Label(ReasonCode);
                ReasonCode.DataField = "ReasonCode";
                SubItemID = new Selector("ctl00_phG_tab_t0_grid_lv0_edSubItemID", "Subitem", locator, null);
                SubItemIDLabel = new Label(SubItemID);
                SubItemID.DataField = "SubItemID";
                SiteID = new Selector("ctl00_phG_tab_t0_grid_lv0_edSiteID", "Warehouse", locator, null);
                SiteIDLabel = new Label(SiteID);
                SiteID.DataField = "SiteID";
                LocationID = new Selector("ctl00_phG_tab_t0_grid_lv0_edLocationID", "Location", locator, null);
                LocationIDLabel = new Label(LocationID);
                LocationID.DataField = "LocationID";
                Qty = new PXNumberEdit("ctl00_phG_tab_t0_grid_lv0_edQty", "Quantity", locator, null);
                QtyLabel = new Label(Qty);
                Qty.DataField = "Qty";
                UOM = new Selector("ctl00_phG_tab_t0_grid_lv0_edUOM", "UOM", locator, null);
                UOMLabel = new Label(UOM);
                UOM.DataField = "UOM";
                UnitCost = new PXNumberEdit("ctl00_phG_tab_t0_grid_lv0_edUnitCost", "Unit Cost", locator, null);
                UnitCostLabel = new Label(UnitCost);
                UnitCost.DataField = "UnitCost";
                TranCost = new PXNumberEdit("ctl00_phG_tab_t0_grid_lv0_edTranCost", "Ext. Cost", locator, null);
                TranCostLabel = new Label(TranCost);
                TranCost.DataField = "TranCost";
                LotSerialNbr = new Selector("ctl00_phG_tab_t0_grid_lv0_edLotSerialNbr", "Lot/Serial Nbr.", locator, null);
                LotSerialNbrLabel = new Label(LotSerialNbr);
                LotSerialNbr.DataField = "LotSerialNbr";
                ExpireDate = new DateSelector("ctl00_phG_tab_t0_grid_lv0_edExpireDate", "Expiration Date", locator, null);
                ExpireDateLabel = new Label(ExpireDate);
                ExpireDate.DataField = "ExpireDate";
                TranDesc = new PXTextEdit("ctl00_phG_tab_t0_grid_lv0_edTranDesc", "Description", locator, null);
                TranDescLabel = new Label(TranDesc);
                TranDesc.DataField = "TranDesc";
                SOShipmentNbr = new Selector("ctl00_phG_tab_t0_grid_lv0_edSOShipmentNbr", "SO Shipment Nbr.", locator, null);
                SOShipmentNbrLabel = new Label(SOShipmentNbr);
                SOShipmentNbr.DataField = "SOShipmentNbr";
                POReceiptNbr = new Selector("ctl00_phG_tab_t0_grid_lv0_edPOReceiptNbr", "PO Receipt Nbr.", locator, null);
                POReceiptNbrLabel = new Label(POReceiptNbr);
                POReceiptNbr.DataField = "POReceiptNbr";
                SOOrderType = new Selector("ctl00_phG_tab_t0_grid_lv0_edSOOrderType", "SO Order Type", locator, null);
                SOOrderTypeLabel = new Label(SOOrderType);
                SOOrderType.DataField = "SOOrderType";
                SOOrderNbr = new Selector("ctl00_phG_tab_t0_grid_lv0_edSOOrderNbr", "SO Order Nbr.", locator, null);
                SOOrderNbrLabel = new Label(SOOrderNbr);
                SOOrderNbr.DataField = "SOOrderNbr";
                BranchID = new Selector("ctl00_phG_tab_t0_grid_lv0_edBranchID", "Branch", locator, null);
                BranchIDLabel = new Label(BranchID);
                BranchID.DataField = "BranchID";
                ProjectID = new Selector("ctl00_phG_tab_t0_grid_lv0_edProjectID", "Project", locator, null);
                ProjectIDLabel = new Label(ProjectID);
                ProjectID.DataField = "ProjectID";
                TaskID = new Selector("ctl00_phG_tab_t0_grid_lv0_edTaskID", "Project Task", locator, null);
                TaskIDLabel = new Label(TaskID);
                TaskID.DataField = "TaskID";
                CostCodeID = new Selector("ctl00_phG_tab_t0_grid_lv0_edCostCodeID", "Cost Code", locator, null);
                CostCodeIDLabel = new Label(CostCodeID);
                CostCodeID.DataField = "CostCodeID";
                Es = new Selector("ctl00_phG_tab_t0_grid_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Ec = new DropDown("ctl00_phG_tab_t0_grid_lv0_ec", "Ec", locator, null);
                DataMemberName = "transactions";
                Buttons = new PxButtonCollection();
            }

            public virtual void InventoryIDEdit()
            {
                Buttons.InventoryIDEdit.Click();
            }

            public virtual void SOShipmentNbrEdit()
            {
                Buttons.SOShipmentNbrEdit.Click();
            }

            public virtual void POReceiptNbrEdit()
            {
                Buttons.POReceiptNbrEdit.Click();
            }

            public virtual void SOOrderNbrEdit()
            {
                Buttons.SOOrderNbrEdit.Click();
            }

            public virtual void Ok()
            {
                Buttons.Ok.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public virtual void Ok1()
            {
                Buttons.Ok1.Click();
            }

            public virtual void Cancel1()
            {
                Buttons.Cancel1.Click();
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

            public virtual void Ok2()
            {
                Buttons.Ok2.Click();
            }

            public virtual void Cancel2()
            {
                Buttons.Cancel2.Click();
            }

            public virtual void Upload()
            {
                Buttons.Upload.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button InventoryIDEdit { get; }
                public Button SOShipmentNbrEdit { get; }
                public Button POReceiptNbrEdit { get; }
                public Button SOOrderNbrEdit { get; }
                public Button Ok { get; }
                public Button Cancel { get; }
                public Button Ok1 { get; }
                public Button Cancel1 { get; }
                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button Ok2 { get; }
                public Button Cancel2 { get; }
                public Button Upload { get; }

                public PxButtonCollection()
                {
                    InventoryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_grid_lv0_edInventoryID\'] div[class=\'editBtnCont\'] > " +
                            "div > div", "InventoryIDEdit", "ctl00_phG_tab_t0_grid_lv0");
                    InventoryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    SOShipmentNbrEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_grid_lv0_edSOShipmentNbr\'] div[class=\'editBtnCont\'] " +
                            "> div > div", "SOShipmentNbrEdit", "ctl00_phG_tab_t0_grid_lv0");
                    SOShipmentNbrEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    POReceiptNbrEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_grid_lv0_edPOReceiptNbr\'] div[class=\'editBtnCont\'] >" +
                            " div > div", "POReceiptNbrEdit", "ctl00_phG_tab_t0_grid_lv0");
                    POReceiptNbrEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    SOOrderNbrEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_grid_lv0_edSOOrderNbr\'] div[class=\'editBtnCont\'] > d" +
                            "iv > div", "SOOrderNbrEdit", "ctl00_phG_tab_t0_grid_lv0");
                    SOOrderNbrEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    Ok = new Button("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_btnSave1", "OK", "ctl00_phG_tab_t0_grid_lv0");
                    Cancel = new Button("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_btnCancel1", "Cancel", "ctl00_phG_tab_t0_grid_lv0");
                    Ok1 = new Button("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_btnSave2", "OK", "ctl00_phG_tab_t0_grid_lv0");
                    Cancel1 = new Button("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_btnCancel2", "Cancel", "ctl00_phG_tab_t0_grid_lv0");
                    First = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfFirst0", "First", "ctl00_phG_tab_t0_grid_lv0");
                    Prev = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfPrev0", "Prev", "ctl00_phG_tab_t0_grid_lv0");
                    Next = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfNext0", "Next", "ctl00_phG_tab_t0_grid_lv0");
                    Last = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfLast0", "Last", "ctl00_phG_tab_t0_grid_lv0");
                    Ok2 = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_btnSave", "OK", "ctl00_phG_tab_t0_grid_lv0");
                    Cancel2 = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_btnCancel", "Cancel", "ctl00_phG_tab_t0_grid_lv0");
                    Upload = new Button("ctl00_phG_tab_t0_grid_imp_upl_pnl_btnUpload", "Upload", "ctl00_phG_tab_t0_grid_lv0");
                }
            }
        }

        public class c_sitestatusfilter_formsitesstatus : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit Inventory { get; }
            public Label InventoryLabel { get; }
            public PXTextEdit BarCode { get; }
            public Label BarCodeLabel { get; }
            public Selector ItemClass { get; }
            public Label ItemClassLabel { get; }
            public CheckBox OnlyAvailable { get; }
            public Label OnlyAvailableLabel { get; }
            public Selector SubItem { get; }
            public Label SubItemLabel { get; }
            public Selector SiteID { get; }
            public Label SiteIDLabel { get; }
            public Selector LocationID { get; }
            public Label LocationIDLabel { get; }

            public c_sitestatusfilter_formsitesstatus(string locator, string name) :
                    base(locator, name)
            {
                Inventory = new PXTextEdit("ctl00_phG_PanelAddSiteStatus_formSitesStatus_edInventory", "Inventory", locator, null);
                InventoryLabel = new Label(Inventory);
                Inventory.DataField = "Inventory";
                BarCode = new PXTextEdit("ctl00_phG_PanelAddSiteStatus_formSitesStatus_edBarCode", "Bar Code", locator, null);
                BarCodeLabel = new Label(BarCode);
                BarCode.DataField = "BarCode";
                ItemClass = new Selector("ctl00_phG_PanelAddSiteStatus_formSitesStatus_edItemClassID", "Item Class", locator, null);
                ItemClassLabel = new Label(ItemClass);
                ItemClass.DataField = "ItemClass";
                OnlyAvailable = new CheckBox("ctl00_phG_PanelAddSiteStatus_formSitesStatus_chkOnlyAvailable", "Only Available", locator, null);
                OnlyAvailableLabel = new Label(OnlyAvailable);
                OnlyAvailable.DataField = "OnlyAvailable";
                SubItem = new Selector("ctl00_phG_PanelAddSiteStatus_formSitesStatus_edSubItem", "Sub Item", locator, null);
                SubItemLabel = new Label(SubItem);
                SubItem.DataField = "SubItem";
                SiteID = new Selector("ctl00_phG_PanelAddSiteStatus_formSitesStatus_edSiteID", "Site ID", locator, null);
                SiteIDLabel = new Label(SiteID);
                SiteID.DataField = "SiteID";
                LocationID = new Selector("ctl00_phG_PanelAddSiteStatus_formSitesStatus_edLocationID", "Location ID", locator, null);
                LocationIDLabel = new Label(LocationID);
                LocationID.DataField = "LocationID";
                DataMemberName = "sitestatusfilter";
                Buttons = new PxButtonCollection();
            }

            public virtual void Add()
            {
                Buttons.Add.Click();
            }

            public virtual void AddClose()
            {
                Buttons.AddClose.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Add { get; }
                public Button AddClose { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    Add = new Button("ctl00_phG_PanelAddSiteStatus_PXButton5", "Add", "ctl00_phG_PanelAddSiteStatus_formSitesStatus");
                    AddClose = new Button("ctl00_phG_PanelAddSiteStatus_PXButton4", "Add & Close", "ctl00_phG_PanelAddSiteStatus_formSitesStatus");
                    Cancel = new Button("ctl00_phG_PanelAddSiteStatus_PXButton6", "Cancel", "ctl00_phG_PanelAddSiteStatus_formSitesStatus");
                }
            }
        }

        public class c_sitestatus_gripsitestatus : Grid<c_sitestatus_gripsitestatus.c_grid_row, c_sitestatus_gripsitestatus.c_grid_header>
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            public DropDown PredefinedFilter { get; }
            public c_grid_filter FilterForm { get; }

            public c_sitestatus_gripsitestatus(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_PanelAddSiteStatus_gripSiteStatus");
                DataMemberName = "siteStatus";
                Buttons = new PxButtonCollection();
                PredefinedFilter = new DropDown("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_at_tlb_fs", "Predefined Filter", locator, null);
                PredefinedFilter.Items.Add("00000000-0000-0000-0000-000000000000", "All Records");
                FilterForm = new c_grid_filter("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_fe_gf", "FilterForm");
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

            public virtual void Filter()
            {
                ToolBar.Filter.Click();
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

            public virtual void Add()
            {
                Buttons.Add.Click();
            }

            public virtual void AddClose()
            {
                Buttons.AddClose.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid New { get; }
                public ToolBarButtonGrid Delete { get; }
                public ToolBarButtonGrid Adjust { get; }
                public ToolBarButtonGrid Export { get; }
                public ToolBarButtonGrid Filter { get; }
                public ToolBarButtonGrid Hi { get; }
                public ToolBarButtonGrid PageFirst { get; }
                public ToolBarButtonGrid PagePrev { get; }
                public ToolBarButtonGrid PageNext { get; }
                public ToolBarButtonGrid PageLast { get; }
                public ToolBarButtonGrid Hi1 { get; }

                public PxToolBar(string locator)
                {
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Delete.ConfirmAction = () => Alert.AlertToException("The current {0} record will be deleted.");
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_at_tlb div[data-cmd=\'AdjustColum" +
                            "ns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_at_tlb div[data-cmd=\'ExportExcel" +
                            "\']", "Export to Excel", locator, null);
                    Filter = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_at_tlb div[data-cmd=\'FilterShow\'" +
                            "]", "Filter Settings", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ab_tlb div[data-cmd=\'PageFirst\']" +
                            "", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Add { get; }
                public Button AddClose { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    Add = new Button("ctl00_phG_PanelAddSiteStatus_PXButton5", "Add", "ctl00_phG_PanelAddSiteStatus_gripSiteStatus");
                    AddClose = new Button("ctl00_phG_PanelAddSiteStatus_PXButton4", "Add & Close", "ctl00_phG_PanelAddSiteStatus_gripSiteStatus");
                    Cancel = new Button("ctl00_phG_PanelAddSiteStatus_PXButton6", "Cancel", "ctl00_phG_PanelAddSiteStatus_gripSiteStatus");
                }
            }

            public class c_grid_row : GridRow
            {

                public CheckBox Selected { get; }
                public PXNumberEdit QtySelected { get; }
                public Selector SiteID { get; }
                public PXTextEdit SiteCD { get; }
                public Selector LocationID { get; }
                public PXTextEdit LocationCD { get; }
                public Selector ItemClassID { get; }
                public InputLocalizable ItemClassDescription { get; }
                public PXTextEdit PriceClassID { get; }
                public PXTextEdit PriceClassDescription { get; }
                public Selector InventoryCD { get; }
                public Selector SubItemID { get; }
                public PXTextEdit SubItemCD { get; }
                public InputLocalizable Descr { get; }
                public Selector BaseUnit { get; }
                public PXNumberEdit QtyAvail { get; }
                public PXNumberEdit QtyOnHand { get; }
                public PXNumberEdit InventoryID { get; }

                public c_grid_row(c_sitestatus_gripsitestatus grid) :
                        base(grid)
                {
                    Selected = new CheckBox("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ef", "Selected", grid.Locator, "Selected");
                    Selected.DataField = "Selected";
                    QtySelected = new PXNumberEdit("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_en", "Qty. Selected", grid.Locator, "QtySelected");
                    QtySelected.DataField = "QtySelected";
                    SiteID = new Selector("_ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0_es", "Warehouse", grid.Locator, "SiteID");
                    SiteID.DataField = "SiteID";
                    SiteCD = new PXTextEdit("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ei", "SiteCD", grid.Locator, "SiteCD");
                    SiteCD.DataField = "SiteCD";
                    LocationID = new Selector("_ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0_es", "Location", grid.Locator, "LocationID");
                    LocationID.DataField = "LocationID";
                    LocationCD = new PXTextEdit("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ei", "LocationCD", grid.Locator, "LocationCD");
                    LocationCD.DataField = "LocationCD";
                    ItemClassID = new Selector("_ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0_editemClass", "Item Class ID", grid.Locator, "ItemClassID");
                    ItemClassID.DataField = "ItemClassID";
                    ItemClassDescription = new InputLocalizable("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ei", "Item Class Description", grid.Locator, "ItemClassDescription");
                    ItemClassDescription.DataField = "ItemClassDescription";
                    PriceClassID = new PXTextEdit("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ei", "Price Class ID", grid.Locator, "PriceClassID");
                    PriceClassID.DataField = "PriceClassID";
                    PriceClassDescription = new PXTextEdit("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ei", "Price Class Description", grid.Locator, "PriceClassDescription");
                    PriceClassDescription.DataField = "PriceClassDescription";
                    InventoryCD = new Selector("_ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0_es", "Inventory ID", grid.Locator, "InventoryCD");
                    InventoryCD.DataField = "InventoryCD";
                    SubItemID = new Selector("_ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0_es", "Subitem", grid.Locator, "SubItemID");
                    SubItemID.DataField = "SubItemID";
                    SubItemCD = new PXTextEdit("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ei", "SubItemCD", grid.Locator, "SubItemCD");
                    SubItemCD.DataField = "SubItemCD";
                    Descr = new InputLocalizable("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_ei", "Description", grid.Locator, "Descr");
                    Descr.DataField = "Descr";
                    BaseUnit = new Selector("_ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0_es", "Base Unit", grid.Locator, "BaseUnit");
                    BaseUnit.DataField = "BaseUnit";
                    QtyAvail = new PXNumberEdit("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_en", "Qty. Available", grid.Locator, "QtyAvail");
                    QtyAvail.DataField = "QtyAvail";
                    QtyOnHand = new PXNumberEdit("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_en", "Qty. On Hand", grid.Locator, "QtyOnHand");
                    QtyOnHand.DataField = "QtyOnHand";
                    InventoryID = new PXNumberEdit("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_en", "InventoryID", grid.Locator, "InventoryID");
                    InventoryID.DataField = "InventoryID";
                }
            }

            public class c_grid_header : GridHeader
            {

                public CheckBoxColumnFilter Selected { get; }
                public PXNumberEditColumnFilter QtySelected { get; }
                public SelectorColumnFilter SiteID { get; }
                public PXTextEditColumnFilter SiteCD { get; }
                public SelectorColumnFilter LocationID { get; }
                public PXTextEditColumnFilter LocationCD { get; }
                public SelectorColumnFilter ItemClassID { get; }
                public PXTextEditColumnFilter ItemClassDescription { get; }
                public PXTextEditColumnFilter PriceClassID { get; }
                public PXTextEditColumnFilter PriceClassDescription { get; }
                public SelectorColumnFilter InventoryCD { get; }
                public SelectorColumnFilter SubItemID { get; }
                public PXTextEditColumnFilter SubItemCD { get; }
                public PXTextEditColumnFilter Descr { get; }
                public SelectorColumnFilter BaseUnit { get; }
                public PXNumberEditColumnFilter QtyAvail { get; }
                public PXNumberEditColumnFilter QtyOnHand { get; }
                public PXNumberEditColumnFilter InventoryID { get; }

                public c_grid_header(c_sitestatus_gripsitestatus grid) :
                        base(grid)
                {
                    Selected = new CheckBoxColumnFilter(grid.Row.Selected);
                    QtySelected = new PXNumberEditColumnFilter(grid.Row.QtySelected);
                    SiteID = new SelectorColumnFilter(grid.Row.SiteID);
                    SiteCD = new PXTextEditColumnFilter(grid.Row.SiteCD);
                    LocationID = new SelectorColumnFilter(grid.Row.LocationID);
                    LocationCD = new PXTextEditColumnFilter(grid.Row.LocationCD);
                    ItemClassID = new SelectorColumnFilter(grid.Row.ItemClassID);
                    ItemClassDescription = new PXTextEditColumnFilter(grid.Row.ItemClassDescription);
                    PriceClassID = new PXTextEditColumnFilter(grid.Row.PriceClassID);
                    PriceClassDescription = new PXTextEditColumnFilter(grid.Row.PriceClassDescription);
                    InventoryCD = new SelectorColumnFilter(grid.Row.InventoryCD);
                    SubItemID = new SelectorColumnFilter(grid.Row.SubItemID);
                    SubItemCD = new PXTextEditColumnFilter(grid.Row.SubItemCD);
                    Descr = new PXTextEditColumnFilter(grid.Row.Descr);
                    BaseUnit = new SelectorColumnFilter(grid.Row.BaseUnit);
                    QtyAvail = new PXNumberEditColumnFilter(grid.Row.QtyAvail);
                    QtyOnHand = new PXNumberEditColumnFilter(grid.Row.QtyOnHand);
                    InventoryID = new PXNumberEditColumnFilter(grid.Row.InventoryID);
                }
            }
        }

        public class c_sitestatus_lv0 : Container
        {

            public PxButtonCollection Buttons;

            public Selector ItemClassID { get; }
            public Label ItemClassIDLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }
            public Selector Em { get; }
            public Label EmLabel { get; }

            public c_sitestatus_lv0(string locator, string name) :
                    base(locator, name)
            {
                ItemClassID = new Selector("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0_editemClass", "Item Class ID", locator, null);
                ItemClassIDLabel = new Label(ItemClassID);
                ItemClassID.DataField = "ItemClassID";
                Es = new Selector("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Em = new Selector("ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0_em", "Em", locator, null);
                EmLabel = new Label(Em);
                DataMemberName = "siteStatus";
                Buttons = new PxButtonCollection();
            }

            public virtual void Add()
            {
                Buttons.Add.Click();
            }

            public virtual void AddClose()
            {
                Buttons.AddClose.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Add { get; }
                public Button AddClose { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    Add = new Button("ctl00_phG_PanelAddSiteStatus_PXButton5", "Add", "ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0");
                    AddClose = new Button("ctl00_phG_PanelAddSiteStatus_PXButton4", "Add & Close", "ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0");
                    Cancel = new Button("ctl00_phG_PanelAddSiteStatus_PXButton6", "Cancel", "ctl00_phG_PanelAddSiteStatus_gripSiteStatus_lv0");
                }
            }
        }

        public class c_workflowview_workflowfictivediagram : Container
        {

            public PxButtonCollection Buttons;

            public UnknownControl Layout { get; }
            public Label LayoutLabel { get; }

            public c_workflowview_workflowfictivediagram(string locator, string name) :
                    base(locator, name)
            {
                Layout = new UnknownControl("ctl00_usrCaption_WorkflowDiagram_pnlWorkFlow_WorkflowFictiveDiagram_diagram", "Layout", locator, null);
                LayoutLabel = new Label(Layout);
                Layout.DataField = "Layout";
                DataMemberName = "WorkflowView";
                Buttons = new PxButtonCollection();
            }

            public virtual void Customize()
            {
                Buttons.Customize.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Customize { get; }

                public PxButtonCollection()
                {
                    Customize = new Button("ctl00_usrCaption_WorkflowDiagram_pnlWorkFlow_PXButtonCustomize", "Customize", "ctl00_usrCaption_WorkflowDiagram_pnlWorkFlow_WorkflowFictiveDiagram");
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

        public class c_transactions_importcsvsettings_frmimportcsvsettings : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit Separator { get; }
            public Label SeparatorLabel { get; }
            public PXTextEdit NullValue { get; }
            public Label NullValueLabel { get; }
            public DropDown CodePage { get; }
            public Label CodePageLabel { get; }
            public DropDown Culture { get; }
            public Label CultureLabel { get; }
            public DropDown Mode { get; }
            public Label ModeLabel { get; }

            public c_transactions_importcsvsettings_frmimportcsvsettings(string locator, string name) :
                    base(locator, name)
            {
                Separator = new PXTextEdit("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_frmImportCSVSettings_edSeparator", "Separator", locator, null);
                SeparatorLabel = new Label(Separator);
                Separator.DataField = "Separator";
                NullValue = new PXTextEdit("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_frmImportCSVSettings_edNullValue", "Null Value", locator, null);
                NullValueLabel = new Label(NullValue);
                NullValue.DataField = "NullValue";
                CodePage = new DropDown("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_frmImportCSVSettings_edCodePage", "Code Page", locator, null);
                CodePageLabel = new Label(CodePage);
                CodePage.DataField = "CodePage";
                Culture = new DropDown("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_frmImportCSVSettings_edCultures", "Culture", locator, null);
                CultureLabel = new Label(Culture);
                Culture.DataField = "Culture";
                Mode = new DropDown("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_frmImportCSVSettings_edMode", "Mode", locator, null);
                ModeLabel = new Label(Mode);
                Mode.DataField = "Mode";
                DataMemberName = "transactions$ImportCSVSettings";
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
                    Ok = new Button("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_btnSave1", "OK", "ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_frmImportCSVSettings");
                    Cancel = new Button("ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_btnCancel1", "Cancel", "ctl00_phG_tab_t0_grid_imp_importCSVSettingsDlg_frmImportCSVSettings");
                }
            }
        }

        public class c_transactions_importxlsxsettings_frmimportxlsxsettings : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit NullValue { get; }
            public Label NullValueLabel { get; }
            public DropDown Culture { get; }
            public Label CultureLabel { get; }
            public DropDown Mode { get; }
            public Label ModeLabel { get; }

            public c_transactions_importxlsxsettings_frmimportxlsxsettings(string locator, string name) :
                    base(locator, name)
            {
                NullValue = new PXTextEdit("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_frmImportXLSXSettings_edNullValue" +
                        "", "Null Value", locator, null);
                NullValueLabel = new Label(NullValue);
                NullValue.DataField = "NullValue";
                Culture = new DropDown("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_frmImportXLSXSettings_edCultures", "Culture", locator, null);
                CultureLabel = new Label(Culture);
                Culture.DataField = "Culture";
                Mode = new DropDown("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_frmImportXLSXSettings_edMode", "Mode", locator, null);
                ModeLabel = new Label(Mode);
                Mode.DataField = "Mode";
                DataMemberName = "transactions$ImportXLSXSettings";
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
                    Ok = new Button("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_btnSave2", "OK", "ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_frmImportXLSXSettings");
                    Cancel = new Button("ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_btnCancel2", "Cancel", "ctl00_phG_tab_t0_grid_imp_importXLSXSettingsDlg_frmImportXLSXSettings");
                }
            }
        }

        public class c_transactions_importcolumns_grdimportcolumn : Grid<c_transactions_importcolumns_grdimportcolumn.c_grid_row, c_transactions_importcolumns_grdimportcolumn.c_grid_header>
        {

            public PxButtonCollection Buttons;

            public c_transactions_importcolumns_grdimportcolumn(string locator, string name) :
                    base(locator, name)
            {
                DataMemberName = "transactions$ImportColumns";
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

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button Ok { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfFirst0", "First", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn");
                    Prev = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfPrev0", "Prev", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn");
                    Next = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfNext0", "Next", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn");
                    Last = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfLast0", "Last", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn");
                    Ok = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_btnSave", "OK", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn");
                    Cancel = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_btnCancel", "Cancel", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn");
                }
            }

            public class c_grid_row : GridRow
            {

                public PXTextEdit ColumnName { get; }
                public DropDown PropertyName { get; }

                public c_grid_row(c_transactions_importcolumns_grdimportcolumn grid) :
                        base(grid)
                {
                    ColumnName = new PXTextEdit("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_ei", "ColumnName", grid.Locator, "ColumnName");
                    ColumnName.DataField = "ColumnName";
                    PropertyName = new DropDown("_ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0_ec", "PropertyName", grid.Locator, "PropertyName");
                    PropertyName.DataField = "PropertyName";
                }
            }

            public class c_grid_header : GridHeader
            {

                public PXTextEditColumnFilter ColumnName { get; }
                public InputColumnFilter PropertyName { get; }

                public c_grid_header(c_transactions_importcolumns_grdimportcolumn grid) :
                        base(grid)
                {
                    ColumnName = new PXTextEditColumnFilter(grid.Row.ColumnName);
                    PropertyName = new InputColumnFilter(grid.Row.PropertyName);
                }
            }
        }

        public class c_transactions_importcolumns_lv0 : Container
        {

            public PxButtonCollection Buttons;

            public DateSelector Ed { get; }
            public Label EdLabel { get; }
            public DropDown Ec { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }
            public Selector Em { get; }
            public Label EmLabel { get; }

            public c_transactions_importcolumns_lv0(string locator, string name) :
                    base(locator, name)
            {
                Ed = new DateSelector("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0_ed", "Ed", locator, null);
                EdLabel = new Label(Ed);
                Ec = new DropDown("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0_ec", "Ec", locator, null);
                Es = new Selector("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Em = new Selector("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0_em", "Em", locator, null);
                EmLabel = new Label(Em);
                DataMemberName = "transactions$ImportColumns";
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

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button Ok { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfFirst0", "First", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0");
                    Prev = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfPrev0", "Prev", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0");
                    Next = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfNext0", "Next", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0");
                    Last = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lfLast0", "Last", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0");
                    Ok = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_btnSave", "OK", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0");
                    Cancel = new Button("ctl00_phG_tab_t0_grid_imp_importColumnDlg_btnCancel", "Cancel", "ctl00_phG_tab_t0_grid_imp_importColumnDlg_grdImportColumn_lv0");
                }
            }
        }

        public class c_attributes : Container
        {

            public c_attributes(string locator, string name) :
                    base(locator, name)
            {
                DataMemberName = null;
            }
        }
    }
}
