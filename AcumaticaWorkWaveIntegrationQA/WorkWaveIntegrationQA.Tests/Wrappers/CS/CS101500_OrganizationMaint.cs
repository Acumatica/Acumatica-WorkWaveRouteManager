using Api;
using Controls.Alert;
using Controls.Button;
using Controls.CheckBox;
using Controls.Container;
using Controls.Container.Extentions;
using Controls.Editors.DropDown;
using Controls.Editors.EmailEdit;
using Controls.Editors.LinkEdit;
using Controls.Editors.Selector;
using Controls.FileColumnButton;
using Controls.Grid;
using Controls.Grid.Filter;
using Controls.Grid.Upload;
using Controls.GroupBox;
using Controls.ImageUploader;
using Controls.Input;
using Controls.Input.PXNumberEdit;
using Controls.Input.PXTextEdit;
using Controls.Label;
using Controls.NoteColumnButton;
using Controls.PxControlCollection;
using Controls.ToolBarButton;
using Core;
using Core.ApiConnection;
using Core.Core.Browser;
using Core.Wait;
using System;


namespace WorkWaveIntegrationQA.Tests.Wrappers
{


    public class CS101500_OrganizationMaint : Wrapper
    {

        public Note NotePanel;

        public SmartPanel_AttachFile FilesUploadDialog;

        public PxToolBar ToolBar;

        public Container Translations { get; } = new Container("ctl00_L10nEditor", "Translations");
        protected c_baccount_pxformview1 BAccount_PXFormView1 { get; } = new c_baccount_pxformview1("ctl00_phF_PXFormView1", "BAccount_PXFormView1");
        protected c_organizationview_pxformview1 OrganizationView_PXFormView1 { get; } = new c_organizationview_pxformview1("ctl00_phF_PXFormView1", "OrganizationView_PXFormView1");
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
        protected c_currentbaccount_tab CurrentBAccount_tab { get; } = new c_currentbaccount_tab("ctl00_phG_tab", "CurrentBAccount_tab");
        protected c_organizationview_tab OrganizationView_tab { get; } = new c_organizationview_tab("ctl00_phG_tab", "OrganizationView_tab");
        protected c_deflocation_pxformviewlocation DefLocation_PXFormViewLocation { get; } = new c_deflocation_pxformviewlocation("ctl00_phG_tab_t0_PXFormViewLocation", "DefLocation_PXFormViewLocation");
        protected c_deflocation_frmdeflocation DefLocation_frmDefLocation { get; } = new c_deflocation_frmdeflocation("ctl00_phG_tab_t2_frmDefLocation", "DefLocation_frmDefLocation");
        protected c_deflocation_frmdeflocationgl DefLocation_frmDefLocationGL { get; } = new c_deflocation_frmdeflocationgl("ctl00_phG_tab_t5_frmDefLocationGL", "DefLocation_frmDefLocationGL");
        protected c_defaddress_defaddress DefAddress_DefAddress { get; } = new c_defaddress_defaddress("ctl00_phG_tab_t0_DefAddress", "DefAddress_DefAddress");
        protected c_deflocationaddress_deflocationaddress DefLocationAddress_DefLocationAddress { get; } = new c_deflocationaddress_deflocationaddress("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress", "DefLocationAddress_DefLocationAddress");
        protected c_defcontact_defcontact DefContact_DefContact { get; } = new c_defcontact_defcontact("ctl00_phG_tab_t0_DefContact", "DefContact_DefContact");
        protected c_deflocationcontact_deflocationcontact DefLocationContact_DefLocationContact { get; } = new c_deflocationcontact_deflocationcontact("ctl00_phG_tab_t2_frmDefLocation_DefLocationContact", "DefLocationContact_DefLocationContact");
        protected c_company_miscsettings Company_MiscSettings { get; } = new c_company_miscsettings("ctl00_phG_tab_t0_MiscSettings", "Company_MiscSettings");
        protected c_organizationview_company OrganizationView_Company { get; } = new c_organizationview_company("ctl00_phG_tab_t0_Company", "OrganizationView_Company");
        protected c_organizationview_configurationsettings OrganizationView_ConfigurationSettings { get; } = new c_organizationview_configurationsettings("ctl00_phG_tab_t0_ConfigurationSettings", "OrganizationView_ConfigurationSettings");
        protected c_organizationview_orgpart10 OrganizationView_OrgPart10 { get; } = new c_organizationview_orgpart10("ctl00_phG_tab_t6_OrgPart10", "OrganizationView_OrgPart10");
        protected c_organizationview_frmlogo OrganizationView_frmLogo { get; } = new c_organizationview_frmlogo("ctl00_phG_tab_t8_frmLogo", "OrganizationView_frmLogo");
        protected c_organizationview_rutrotsettings OrganizationView_RUTROTSettings { get; } = new c_organizationview_rutrotsettings("ctl00_phG_tab_t10_RUTROTSettings", "OrganizationView_RUTROTSettings");
        protected c_organizationview_formcarrierfacility OrganizationView_formCarrierFacility { get; } = new c_organizationview_formcarrierfacility("ctl00_phG_tab_t0_DefAddress_formCarrierFacility", "OrganizationView_formCarrierFacility");
        protected c_branchesview_grdbranches BranchesView_grdBranches { get; } = new c_branchesview_grdbranches("ctl00_phG_tab_t1_grdBranches", "BranchesView_grdBranches");
        protected c_branchesview_lv0 BranchesView_lv0 { get; } = new c_branchesview_lv0("ctl00_phG_tab_t1_grdBranches_lv0", "BranchesView_lv0");
        protected c_employees_grdemployees Employees_grdEmployees { get; } = new c_employees_grdemployees("ctl00_phG_tab_t3_grdEmployees", "Employees_grdEmployees");
        protected c_employees_lv0 Employees_lv0 { get; } = new c_employees_lv0("ctl00_phG_tab_t3_grdEmployees_lv0", "Employees_lv0");
        protected c_commonsetup_commonsettings Commonsetup_commonsettings { get; } = new c_commonsetup_commonsettings("ctl00_phG_tab_t0_CommonSettings", "commonsetup_CommonSettings");
        protected c_stateview_stateform StateView_StateForm { get; } = new c_stateview_stateform("ctl00_phF_PXFormView1_StateForm", "StateView_StateForm");
        protected c_groups_grid Groups_grid { get; } = new c_groups_grid("ctl00_phG_tab_t9_grid", "Groups_grid");
        protected c_groups_lv0 Groups_lv0 { get; } = new c_groups_lv0("ctl00_phG_tab_t9_grid_lv0", "Groups_lv0");
        protected c_createledgerview_loform CreateLedgerView_loform { get; } = new c_createledgerview_loform("ctl00_phF_pnlCreateLedger_loform", "CreateLedgerView_loform");
        protected c_organizationledgerlinkwithledgerselect_grdledgerlinks OrganizationLedgerLinkWithLedgerSelect_grdLedgerLinks { get; } = new c_organizationledgerlinkwithledgerselect_grdledgerlinks("ctl00_phG_tab_t4_grdLedgerLinks", "OrganizationLedgerLinkWithLedgerSelect_grdLedgerLinks");
        protected c_organizationledgerlinkwithledgerselect_lv0 OrganizationLedgerLinkWithLedgerSelect_lv0 { get; } = new c_organizationledgerlinkwithledgerselect_lv0("ctl00_phG_tab_t4_grdLedgerLinks_lv0", "OrganizationLedgerLinkWithLedgerSelect_lv0");
        protected c_addresslookupfilter_addresslookuppanelformaddress AddressLookupFilter_AddressLookupPanelformAddress { get; } = new c_addresslookupfilter_addresslookuppanelformaddress("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress", "AddressLookupFilter_AddressLookupPanelformAddress");
        protected c_changeiddialog_formchangeid ChangeIDDialog_formChangeID { get; } = new c_changeiddialog_formchangeid("ctl00_phF_pnlChangeID_formChangeID", "ChangeIDDialog_formChangeID");
        protected c_taxes_grdtaxes Taxes_grdTaxes { get; } = new c_taxes_grdtaxes("ctl00_phG_tab_t7_grdTaxes", "Taxes_grdTaxes");
        protected c_taxes_lv0 Taxes_lv0 { get; } = new c_taxes_lv0("ctl00_phG_tab_t7_grdTaxes_lv0", "Taxes_lv0");
        protected c_filterpreview_formpreview FilterPreview_FormPreview { get; } = new c_filterpreview_formpreview("ctl00_usrCaption_PanelDynamicForm_FormPreview", "FilterPreview_FormPreview");

        public CS101500_OrganizationMaint()
        {
            ScreenId = "CS101500";
            ScreenUrl = "/Pages/CS/CS101500.aspx";
            NotePanel = new Note("ctl00_usrCaption_tlbDataView");
            FilesUploadDialog = new SmartPanel_AttachFile("ctl00_usrCaption_tlbDataView");
            ToolBar = new PxToolBar(null);
        }

        public virtual CS101500_OrganizationMaint ReadOne(Gate gate, string AcctCD)
        {
            new BiObject<CS101500_OrganizationMaint>(gate).ReadOne(this, AcctCD);
            return this;
        }

        public virtual CS101500_OrganizationMaint ReadOne(string AcctCD)
        {
            return this.ReadOne(ApiConnection.Source, AcctCD);
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

        public virtual void MenuOpener()
        {
            ToolBar.MenuOpener.Click();
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

        public virtual void ActionsMenu()
        {
            ToolBar.ActionsMenu.Click();
        }

        public virtual void CreateLedger()
        {
            ToolBar.CreateLedger.Click();
        }

        public virtual void ChangeID()
        {
            ToolBar.ChangeID.Click();
        }

        public virtual void ValidateAddresses()
        {
            ToolBar.ValidateAddresses.Click();
        }

        public virtual void RefreshLocation()
        {
            ToolBar.RefreshLocation.Click();
        }

        public virtual void ViewLocation()
        {
            ToolBar.ViewLocation.Click();
        }

        public virtual void ExtendToCustomer()
        {
            ToolBar.ExtendToCustomer.Click();
        }

        public virtual void ViewCustomer()
        {
            ToolBar.ViewCustomer.Click();
        }

        public virtual void ExtendToVendor()
        {
            ToolBar.ExtendToVendor.Click();
        }

        public virtual void ViewVendor()
        {
            ToolBar.ViewVendor.Click();
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
            public ToolBarButton MenuOpener { get; }
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
            public ToolBarButton ActionsMenu { get; }
            public ToolBarButton CreateLedger { get; }
            public ToolBarButton ChangeID { get; }
            public ToolBarButton ValidateAddresses { get; }
            public ToolBarButton RefreshLocation { get; }
            public ToolBarButton ViewLocation { get; }
            public ToolBarButton ExtendToCustomer { get; }
            public ToolBarButton ViewCustomer { get; }
            public ToolBarButton ExtendToVendor { get; }
            public ToolBarButton ViewVendor { get; }
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
                MenuOpener = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_MenuOpener", "Menu", locator, null);
                Save = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Save", "Save (Ctrl+S).", locator, null);
                Cancel = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_cancel", "Cancel (Esc)", locator, null);
                Cancel.ConfirmAction = () => Alert.AlertToException("Any unsaved changes will be discarded.");
                Insert = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Insert", "Add New Record (Ctrl+Ins)", locator, null);
                Delete = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Delete", "Delete (Ctrl+Del).", locator, null);
                Delete.ConfirmAction = () => Alert.AlertToException("The current Company record will be deleted.");
                CopyPaste = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_CopyPaste", "Clipboard", locator, null);
                CopyDocument = new ToolBarButton("css=[id=\'ctl00_phDS_ds_ToolBar_CopyPaste@CopyDocument\']", "CopyDocument", locator, CopyPaste);
                PasteDocument = new ToolBarButton("css=[id=\'ctl00_phDS_ds_ToolBar_CopyPaste@PasteDocument\']", "PasteDocument", locator, CopyPaste);
                SaveTemplate = new ToolBarButton("css=[id=\'ctl00_phDS_ds_ToolBar_CopyPaste@SaveTemplate\']", "SaveTemplate", locator, CopyPaste);
                First = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_First", "Go to First Record", locator, null);
                Previous = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Previous", "Go to Previous Record (PgUp)", locator, null);
                Next = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Next", "Go to Next Record (PgDn)", locator, null);
                Last = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Last", "Go to Last Record", locator, null);
                ActionsMenu = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ActionsMenu", "Actions", locator, MenuOpener);
                CreateLedger = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_CreateLedger,#ctl00_phDS_ds_ToolBar_CreateLedger_item", "Create Ledger", locator, MenuOpener);
                ChangeID = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ChangeID,#ctl00_phDS_ds_ToolBar_ChangeID_item", "Change ID", locator, MenuOpener);
                ValidateAddresses = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_validateAddresses,#ctl00_phDS_ds_ToolBar_validateAddre" +
                        "sses_item", "Validate Addresses", locator, MenuOpener);
                RefreshLocation = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_refreshLocation,#ctl00_phDS_ds_ToolBar_refreshLocation" +
                        "_item", "refreshLocation", locator, MenuOpener);
                ViewLocation = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_viewLocation,#ctl00_phDS_ds_ToolBar_viewLocation_item", "Location Details", locator, MenuOpener);
                ExtendToCustomer = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ExtendToCustomer,#ctl00_phDS_ds_ToolBar_ExtendToCustom" +
                        "er_item", "Extend as Customer", locator, MenuOpener);
                ViewCustomer = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ViewCustomer,#ctl00_phDS_ds_ToolBar_ViewCustomer_item", "View Customer", locator, MenuOpener);
                ExtendToVendor = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ExtendToVendor,#ctl00_phDS_ds_ToolBar_ExtendToVendor_i" +
                        "tem", "Extend as Vendor", locator, MenuOpener);
                ViewVendor = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_ViewVendor,#ctl00_phDS_ds_ToolBar_ViewVendor_item", "View Vendor", locator, MenuOpener);
                LongRun = new ToolBarButton("css=qp-long-run", "Nothing in progress", locator, null);
                LongrunCancel = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_cancel", "Cancel", locator, null);
                LongrunTimer = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_timer", "Elapsed Time", locator, null);
            }
        }

        public class c_baccount_pxformview1 : Container
        {

            public Selector AcctCD { get; }
            public Label AcctCDLabel { get; }
            public PXTextEdit AcctName { get; }
            public Label AcctNameLabel { get; }

            public c_baccount_pxformview1(string locator, string name) :
                    base(locator, name)
            {
                AcctCD = new Selector("ctl00_phF_PXFormView1_edAcctCD", "Company ID", locator, null);
                AcctCDLabel = new Label(AcctCD);
                AcctCD.DataField = "AcctCD";
                AcctName = new PXTextEdit("ctl00_phF_PXFormView1_edAcctName", "Company Name", locator, null);
                AcctNameLabel = new Label(AcctName);
                AcctName.DataField = "AcctName";
                DataMemberName = "BAccount";
            }
        }

        public class c_organizationview_pxformview1 : Container
        {

            public DropDown OrganizationType { get; }
            public Label OrganizationTypeLabel { get; }
            public CheckBox Active { get; }
            public Label ActiveLabel { get; }

            public c_organizationview_pxformview1(string locator, string name) :
                    base(locator, name)
            {
                OrganizationType = new DropDown("ctl00_phF_PXFormView1_edOrganizationType", "Company Type", locator, null);
                OrganizationTypeLabel = new Label(OrganizationType);
                OrganizationType.DataField = "OrganizationType";
                OrganizationType.Items.Add("WithoutBranches", "Without Branches");
                OrganizationType.Items.Add("NotBalancing", "With Branches Not Requiring Balancing");
                OrganizationType.Items.Add("Balancing", "With Branches Requiring Balancing");
                Active = new CheckBox("ctl00_phF_PXFormView1_chkActive", "Active", locator, null);
                ActiveLabel = new Label(Active);
                Active.DataField = "Active";
                DataMemberName = "OrganizationView";
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

        public class c_currentbaccount_tab : Container
        {

            public PXTextEdit LegalName { get; }
            public Label LegalNameLabel { get; }
            public PXTextEdit TaxRegistrationID { get; }
            public Label TaxRegistrationIDLabel { get; }
            public Label LblLogoImgUploader_ { get; }
            public Label LblLogoReportImgUploader_ { get; }

            public c_currentbaccount_tab(string locator, string name) :
                    base(locator, name)
            {
                LegalName = new PXTextEdit("ctl00_phG_tab_t0_edLegalName", "Legal Name", locator, null);
                LegalNameLabel = new Label(LegalName);
                LegalName.DataField = "LegalName";
                TaxRegistrationID = new PXTextEdit("ctl00_phG_tab_t0_TaxRegistrationID", "Tax Registration ID", locator, null);
                TaxRegistrationIDLabel = new Label(TaxRegistrationID);
                TaxRegistrationID.DataField = "TaxRegistrationID";
                LblLogoImgUploader_ = new Label("ctl00_phG_tab_t8_frmLogo_lblLogoImgUploader", "Recommended Size: Width 210px, Height 50px", locator, null);
                LblLogoReportImgUploader_ = new Label("ctl00_phG_tab_t8_frmLogo_lblLogoReportImgUploader", "Recommended Size: Width 420px, Height 100px", locator, null);
                DataMemberName = "CurrentBAccount";
            }
        }

        public class c_organizationview_tab : Container
        {

            public CheckBox FileTaxesByBranches { get; }
            public Label FileTaxesByBranchesLabel { get; }
            public CheckBox Reporting1099ByBranches { get; }
            public Label Reporting1099ByBranchesLabel { get; }
            public CheckBox Reporting1099 { get; }
            public Label Reporting1099Label { get; }

            public c_organizationview_tab(string locator, string name) :
                    base(locator, name)
            {
                FileTaxesByBranches = new CheckBox("ctl00_phG_tab_t0_edFileTaxesByBranches", "File Taxes by Branch", locator, null);
                FileTaxesByBranchesLabel = new Label(FileTaxesByBranches);
                FileTaxesByBranches.DataField = "FileTaxesByBranches";
                Reporting1099ByBranches = new CheckBox("ctl00_phG_tab_t0_edReporting1099ByBranches", "File 1099-MISC by Branch", locator, null);
                Reporting1099ByBranchesLabel = new Label(Reporting1099ByBranches);
                Reporting1099ByBranches.DataField = "Reporting1099ByBranches";
                Reporting1099 = new CheckBox("ctl00_phG_tab_t0_edReporting1099", "1099-MISC Reporting Entity", locator, null);
                Reporting1099Label = new Label(Reporting1099);
                Reporting1099.DataField = "Reporting1099";
                DataMemberName = "OrganizationView";
            }
        }

        public class c_deflocation_pxformviewlocation : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit CAvalaraExemptionNumber { get; }
            public Label CAvalaraExemptionNumberLabel { get; }
            public DropDown CAvalaraCustomerUsageType { get; }
            public Label CAvalaraCustomerUsageTypeLabel { get; }

            public c_deflocation_pxformviewlocation(string locator, string name) :
                    base(locator, name)
            {
                CAvalaraExemptionNumber = new PXTextEdit("ctl00_phG_tab_t0_PXFormViewLocation_edFullName", "Tax Exemption Number", locator, null);
                CAvalaraExemptionNumberLabel = new Label(CAvalaraExemptionNumber);
                CAvalaraExemptionNumber.DataField = "CAvalaraExemptionNumber";
                CAvalaraCustomerUsageType = new DropDown("ctl00_phG_tab_t0_PXFormViewLocation_edSalutation", "Entity Usage Type", locator, null);
                CAvalaraCustomerUsageTypeLabel = new Label(CAvalaraCustomerUsageType);
                CAvalaraCustomerUsageType.DataField = "CAvalaraCustomerUsageType";
                CAvalaraCustomerUsageType.Items.Add("A", "Federal Government");
                CAvalaraCustomerUsageType.Items.Add("B", "State/Local Govt.");
                CAvalaraCustomerUsageType.Items.Add("C", "Tribal Government");
                CAvalaraCustomerUsageType.Items.Add("D", "Foreign Diplomat");
                CAvalaraCustomerUsageType.Items.Add("E", "Charitable Organization");
                CAvalaraCustomerUsageType.Items.Add("F", "Religious");
                CAvalaraCustomerUsageType.Items.Add("G", "Resale");
                CAvalaraCustomerUsageType.Items.Add("H", "Agricultural Production");
                CAvalaraCustomerUsageType.Items.Add("I", "Industrial Prod/Mfg.");
                CAvalaraCustomerUsageType.Items.Add("J", "Direct Pay Permit");
                CAvalaraCustomerUsageType.Items.Add("K", "Direct Mail");
                CAvalaraCustomerUsageType.Items.Add("L", "Other");
                CAvalaraCustomerUsageType.Items.Add("M", "Education");
                CAvalaraCustomerUsageType.Items.Add("N", "Local Government");
                CAvalaraCustomerUsageType.Items.Add("P", "Commercial Aquaculture");
                CAvalaraCustomerUsageType.Items.Add("Q", "Commercial Fishery");
                CAvalaraCustomerUsageType.Items.Add("R", "Non-resident");
                CAvalaraCustomerUsageType.Items.Add("0", "Default");
                DataMemberName = "DefLocation";
                Buttons = new PxButtonCollection();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void ViewonMap()
            {
                Buttons.ViewonMap.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void BaseCuryIDEdit()
            {
                Buttons.BaseCuryIDEdit.Click();
            }

            public virtual void CountryIDEdit1()
            {
                Buttons.CountryIDEdit1.Click();
            }

            public virtual void WeightUOMEdit()
            {
                Buttons.WeightUOMEdit.Click();
            }

            public virtual void LinearUOMEdit()
            {
                Buttons.LinearUOMEdit.Click();
            }

            public virtual void VolumeUOMEdit()
            {
                Buttons.VolumeUOMEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button AddressLookup { get; }
                public Button ViewonMap { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }
                public Button BaseCuryIDEdit { get; }
                public Button CountryIDEdit1 { get; }
                public Button WeightUOMEdit { get; }
                public Button LinearUOMEdit { get; }
                public Button VolumeUOMEdit { get; }

                public PxButtonCollection()
                {
                    AddressLookup = new Button("ctl00_phG_tab_t0_DefAddress_btnAddressLookup", "Address Lookup", "ctl00_phG_tab_t0_PXFormViewLocation");
                    ViewonMap = new Button("ctl00_phG_tab_t0_DefAddress_btnViewMainOnMap", "View on Map", "ctl00_phG_tab_t0_PXFormViewLocation");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edCountryID\'] div[class=\'editBtnCont\'] > " +
                            "div > div", "CountryIDEdit", "ctl00_phG_tab_t0_PXFormViewLocation");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edState\'] div[class=\'editBtnCont\'] > div " +
                            "> div", "StateEdit", "ctl00_phG_tab_t0_PXFormViewLocation");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    BaseCuryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_Company_edBaseCuryID\'] div[class=\'editBtnCont\'] > di" +
                            "v > div", "BaseCuryIDEdit", "ctl00_phG_tab_t0_PXFormViewLocation");
                    BaseCuryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    CountryIDEdit1 = new Button("css=div[id=\'ctl00_phG_tab_t0_ConfigurationSettings_edCountryID\'] div[class=\'editB" +
                            "tnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t0_PXFormViewLocation");
                    CountryIDEdit1.WaitAction = Wait.WaitForNewWindowToOpen;
                    WeightUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edWeightUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "WeightUOMEdit", "ctl00_phG_tab_t0_PXFormViewLocation");
                    WeightUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    LinearUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edLinearUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "LinearUOMEdit", "ctl00_phG_tab_t0_PXFormViewLocation");
                    LinearUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VolumeUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edVolumeUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "VolumeUOMEdit", "ctl00_phG_tab_t0_PXFormViewLocation");
                    VolumeUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_deflocation_frmdeflocation : Container
        {

            public PxButtonCollection Buttons;

            public CheckBox OverrideContact { get; }
            public Label OverrideContactLabel { get; }
            public CheckBox OverrideAddress { get; }
            public Label OverrideAddressLabel { get; }
            public Selector VTaxZoneID { get; }
            public Label VTaxZoneIDLabel { get; }
            public DropDown CShipComplete { get; }
            public Label CShipCompleteLabel { get; }

            public c_deflocation_frmdeflocation(string locator, string name) :
                    base(locator, name)
            {
                OverrideContact = new CheckBox("ctl00_phG_tab_t2_frmDefLocation_chkOverrideContact", "Override", locator, null);
                OverrideContactLabel = new Label(OverrideContact);
                OverrideContact.DataField = "OverrideContact";
                OverrideAddress = new CheckBox("ctl00_phG_tab_t2_frmDefLocation_chkOverrideAddress", "Override", locator, null);
                OverrideAddressLabel = new Label(OverrideAddress);
                OverrideAddress.DataField = "OverrideAddress";
                VTaxZoneID = new Selector("ctl00_phG_tab_t2_frmDefLocation_edVTaxZoneID", "Tax Zone", locator, null);
                VTaxZoneIDLabel = new Label(VTaxZoneID);
                VTaxZoneID.DataField = "VTaxZoneID";
                CShipComplete = new DropDown("ctl00_phG_tab_t2_frmDefLocation_edCShipComplete", "Shipping Rule", locator, null);
                CShipCompleteLabel = new Label(CShipComplete);
                CShipComplete.DataField = "CShipComplete";
                CShipComplete.Items.Add("C", "Ship Complete");
                CShipComplete.Items.Add("B", "Back Order Allowed");
                CShipComplete.Items.Add("L", "Cancel Remainder");
                DataMemberName = "DefLocation";
                Buttons = new PxButtonCollection();
            }

            public virtual void VTaxZoneIDEdit()
            {
                Buttons.VTaxZoneIDEdit.Click();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button VTaxZoneIDEdit { get; }
                public Button AddressLookup { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }

                public PxButtonCollection()
                {
                    VTaxZoneIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t2_frmDefLocation_edVTaxZoneID\'] div[class=\'editBtnCont" +
                            "\'] > div > div", "VTaxZoneIDEdit", "ctl00_phG_tab_t2_frmDefLocation");
                    VTaxZoneIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    AddressLookup = new Button("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_btnDefLocationAddressLookup", "Address Lookup", "ctl00_phG_tab_t2_frmDefLocation");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXSelector1\'] div[" +
                            "class=\'editBtnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t2_frmDefLocation");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXSelector2\'] div[" +
                            "class=\'editBtnCont\'] > div > div", "StateEdit", "ctl00_phG_tab_t2_frmDefLocation");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_deflocation_frmdeflocationgl : Container
        {

            public Selector CMPSalesSubID { get; }
            public Label CMPSalesSubIDLabel { get; }
            public Selector CMPExpenseSubID { get; }
            public Label CMPExpenseSubIDLabel { get; }
            public Selector CMPFreightSubID { get; }
            public Label CMPFreightSubIDLabel { get; }
            public Selector CMPDiscountSubID { get; }
            public Label CMPDiscountSubIDLabel { get; }
            public Selector CMPGainLossSubID { get; }
            public Label CMPGainLossSubIDLabel { get; }
            public Selector CMPPayrollSubID { get; }
            public Label CMPPayrollSubIDLabel { get; }

            public c_deflocation_frmdeflocationgl(string locator, string name) :
                    base(locator, name)
            {
                CMPSalesSubID = new Selector("ctl00_phG_tab_t5_frmDefLocationGL_edCMPSalesSubID", "Sales Sub.", locator, null);
                CMPSalesSubIDLabel = new Label(CMPSalesSubID);
                CMPSalesSubID.DataField = "CMPSalesSubID";
                CMPExpenseSubID = new Selector("ctl00_phG_tab_t5_frmDefLocationGL_edCMPExpenseSubID", "Expense Sub.", locator, null);
                CMPExpenseSubIDLabel = new Label(CMPExpenseSubID);
                CMPExpenseSubID.DataField = "CMPExpenseSubID";
                CMPFreightSubID = new Selector("ctl00_phG_tab_t5_frmDefLocationGL_edCMPFreightSubID", "Freight Sub.", locator, null);
                CMPFreightSubIDLabel = new Label(CMPFreightSubID);
                CMPFreightSubID.DataField = "CMPFreightSubID";
                CMPDiscountSubID = new Selector("ctl00_phG_tab_t5_frmDefLocationGL_edCMPDiscountSubID", "Discount Sub.", locator, null);
                CMPDiscountSubIDLabel = new Label(CMPDiscountSubID);
                CMPDiscountSubID.DataField = "CMPDiscountSubID";
                CMPGainLossSubID = new Selector("ctl00_phG_tab_t5_frmDefLocationGL_edCMPGainlossSubID", "Currency Gain/Loss Sub.", locator, null);
                CMPGainLossSubIDLabel = new Label(CMPGainLossSubID);
                CMPGainLossSubID.DataField = "CMPGainLossSubID";
                CMPPayrollSubID = new Selector("ctl00_phG_tab_t5_frmDefLocationGL_edCMPPayrollSubID", "Payroll Sub.", locator, null);
                CMPPayrollSubIDLabel = new Label(CMPPayrollSubID);
                CMPPayrollSubID.DataField = "CMPPayrollSubID";
                DataMemberName = "DefLocation";
            }
        }

        public class c_defaddress_defaddress : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit AddressLine1 { get; }
            public Label AddressLine1Label { get; }
            public PXTextEdit AddressLine2 { get; }
            public Label AddressLine2Label { get; }
            public PXTextEdit City { get; }
            public Label CityLabel { get; }
            public Selector CountryID { get; }
            public Label CountryIDLabel { get; }
            public Selector State { get; }
            public Label StateLabel { get; }
            public PXTextEdit PostalCode { get; }
            public Label PostalCodeLabel { get; }
            public CheckBox IsValidated { get; }
            public Label IsValidatedLabel { get; }

            public c_defaddress_defaddress(string locator, string name) :
                    base(locator, name)
            {
                AddressLine1 = new PXTextEdit("ctl00_phG_tab_t0_DefAddress_edAddressLine1", "Address Line 1", locator, null);
                AddressLine1Label = new Label(AddressLine1);
                AddressLine1.DataField = "AddressLine1";
                AddressLine2 = new PXTextEdit("ctl00_phG_tab_t0_DefAddress_edAddressLine2", "Address Line 2", locator, null);
                AddressLine2Label = new Label(AddressLine2);
                AddressLine2.DataField = "AddressLine2";
                City = new PXTextEdit("ctl00_phG_tab_t0_DefAddress_edCity", "City", locator, null);
                CityLabel = new Label(City);
                City.DataField = "City";
                CountryID = new Selector("ctl00_phG_tab_t0_DefAddress_edCountryID", "Country", locator, null);
                CountryIDLabel = new Label(CountryID);
                CountryID.DataField = "CountryID";
                State = new Selector("ctl00_phG_tab_t0_DefAddress_edState", "State", locator, null);
                StateLabel = new Label(State);
                State.DataField = "State";
                PostalCode = new PXTextEdit("ctl00_phG_tab_t0_DefAddress_edPostalCode", "Postal Code", locator, null);
                PostalCodeLabel = new Label(PostalCode);
                PostalCode.DataField = "PostalCode";
                IsValidated = new CheckBox("ctl00_phG_tab_t0_DefAddress_edIsValidated", "Validated", locator, null);
                IsValidatedLabel = new Label(IsValidated);
                IsValidated.DataField = "IsValidated";
                DataMemberName = "DefAddress";
                Buttons = new PxButtonCollection();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void ViewonMap()
            {
                Buttons.ViewonMap.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void BaseCuryIDEdit()
            {
                Buttons.BaseCuryIDEdit.Click();
            }

            public virtual void CountryIDEdit1()
            {
                Buttons.CountryIDEdit1.Click();
            }

            public virtual void WeightUOMEdit()
            {
                Buttons.WeightUOMEdit.Click();
            }

            public virtual void LinearUOMEdit()
            {
                Buttons.LinearUOMEdit.Click();
            }

            public virtual void VolumeUOMEdit()
            {
                Buttons.VolumeUOMEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button AddressLookup { get; }
                public Button ViewonMap { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }
                public Button BaseCuryIDEdit { get; }
                public Button CountryIDEdit1 { get; }
                public Button WeightUOMEdit { get; }
                public Button LinearUOMEdit { get; }
                public Button VolumeUOMEdit { get; }

                public PxButtonCollection()
                {
                    AddressLookup = new Button("ctl00_phG_tab_t0_DefAddress_btnAddressLookup", "Address Lookup", "ctl00_phG_tab_t0_DefAddress");
                    ViewonMap = new Button("ctl00_phG_tab_t0_DefAddress_btnViewMainOnMap", "View on Map", "ctl00_phG_tab_t0_DefAddress");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edCountryID\'] div[class=\'editBtnCont\'] > " +
                            "div > div", "CountryIDEdit", "ctl00_phG_tab_t0_DefAddress");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edState\'] div[class=\'editBtnCont\'] > div " +
                            "> div", "StateEdit", "ctl00_phG_tab_t0_DefAddress");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    BaseCuryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_Company_edBaseCuryID\'] div[class=\'editBtnCont\'] > di" +
                            "v > div", "BaseCuryIDEdit", "ctl00_phG_tab_t0_DefAddress");
                    BaseCuryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    CountryIDEdit1 = new Button("css=div[id=\'ctl00_phG_tab_t0_ConfigurationSettings_edCountryID\'] div[class=\'editB" +
                            "tnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t0_DefAddress");
                    CountryIDEdit1.WaitAction = Wait.WaitForNewWindowToOpen;
                    WeightUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edWeightUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "WeightUOMEdit", "ctl00_phG_tab_t0_DefAddress");
                    WeightUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    LinearUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edLinearUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "LinearUOMEdit", "ctl00_phG_tab_t0_DefAddress");
                    LinearUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VolumeUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edVolumeUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "VolumeUOMEdit", "ctl00_phG_tab_t0_DefAddress");
                    VolumeUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_deflocationaddress_deflocationaddress : Container
        {

            public PxButtonCollection Buttons;

            public CheckBox IsValidated { get; }
            public Label IsValidatedLabel { get; }
            public PXTextEdit AddressLine1 { get; }
            public Label AddressLine1Label { get; }
            public PXTextEdit AddressLine2 { get; }
            public Label AddressLine2Label { get; }
            public PXTextEdit City { get; }
            public Label CityLabel { get; }
            public Selector CountryID { get; }
            public Label CountryIDLabel { get; }
            public Selector State { get; }
            public Label StateLabel { get; }
            public PXTextEdit PostalCode { get; }
            public Label PostalCodeLabel { get; }

            public c_deflocationaddress_deflocationaddress(string locator, string name) :
                    base(locator, name)
            {
                IsValidated = new CheckBox("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXCheckBox1", "Validated", locator, null);
                IsValidatedLabel = new Label(IsValidated);
                IsValidated.DataField = "IsValidated";
                AddressLine1 = new PXTextEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXTextEdit3", "Address Line 1", locator, null);
                AddressLine1Label = new Label(AddressLine1);
                AddressLine1.DataField = "AddressLine1";
                AddressLine2 = new PXTextEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXTextEdit4", "Address Line 2", locator, null);
                AddressLine2Label = new Label(AddressLine2);
                AddressLine2.DataField = "AddressLine2";
                City = new PXTextEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXTextEdit5", "City", locator, null);
                CityLabel = new Label(City);
                City.DataField = "City";
                CountryID = new Selector("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXSelector1", "Country", locator, null);
                CountryIDLabel = new Label(CountryID);
                CountryID.DataField = "CountryID";
                State = new Selector("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXSelector2", "State", locator, null);
                StateLabel = new Label(State);
                State.DataField = "State";
                PostalCode = new PXTextEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXMaskEdit4", "Postal Code", locator, null);
                PostalCodeLabel = new Label(PostalCode);
                PostalCode.DataField = "PostalCode";
                DataMemberName = "DefLocationAddress";
                Buttons = new PxButtonCollection();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void VTaxZoneIDEdit()
            {
                Buttons.VTaxZoneIDEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button AddressLookup { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }
                public Button VTaxZoneIDEdit { get; }

                public PxButtonCollection()
                {
                    AddressLookup = new Button("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_btnDefLocationAddressLookup", "Address Lookup", "ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXSelector1\'] div[" +
                            "class=\'editBtnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXSelector2\'] div[" +
                            "class=\'editBtnCont\'] > div > div", "StateEdit", "ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VTaxZoneIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t2_frmDefLocation_edVTaxZoneID\'] div[class=\'editBtnCont" +
                            "\'] > div > div", "VTaxZoneIDEdit", "ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress");
                    VTaxZoneIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_defcontact_defcontact : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit FullName { get; }
            public Label FullNameLabel { get; }
            public PXTextEdit Attention { get; }
            public Label AttentionLabel { get; }
            public EmailEdit EMail { get; }
            public Label EMailLabel { get; }
            public LinkEdit WebSite { get; }
            public Label WebSiteLabel { get; }
            public PXTextEdit Phone1 { get; }
            public Label Phone1Label { get; }
            public PXTextEdit Phone2 { get; }
            public Label Phone2Label { get; }
            public PXTextEdit Fax { get; }
            public Label FaxLabel { get; }

            public c_defcontact_defcontact(string locator, string name) :
                    base(locator, name)
            {
                FullName = new PXTextEdit("ctl00_phG_tab_t0_DefContact_edFullName", "Account Name", locator, null);
                FullNameLabel = new Label(FullName);
                FullName.DataField = "FullName";
                Attention = new PXTextEdit("ctl00_phG_tab_t0_DefContact_edAttention", "Attention", locator, null);
                AttentionLabel = new Label(Attention);
                Attention.DataField = "Attention";
                EMail = new EmailEdit("ctl00_phG_tab_t0_DefContact_edEMail", "Email", locator, null);
                EMailLabel = new Label(EMail);
                EMail.DataField = "EMail";
                WebSite = new LinkEdit("ctl00_phG_tab_t0_DefContact_edWebSite", "Web", locator, null);
                WebSiteLabel = new Label(WebSite);
                WebSite.DataField = "WebSite";
                Phone1 = new PXTextEdit("ctl00_phG_tab_t0_DefContact_edPhone1", "Phone 1", locator, null);
                Phone1Label = new Label(Phone1);
                Phone1.DataField = "Phone1";
                Phone2 = new PXTextEdit("ctl00_phG_tab_t0_DefContact_edPhone2", "Phone 2", locator, null);
                Phone2Label = new Label(Phone2);
                Phone2.DataField = "Phone2";
                Fax = new PXTextEdit("ctl00_phG_tab_t0_DefContact_edFax", "Fax", locator, null);
                FaxLabel = new Label(Fax);
                Fax.DataField = "Fax";
                DataMemberName = "DefContact";
                Buttons = new PxButtonCollection();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void ViewonMap()
            {
                Buttons.ViewonMap.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void BaseCuryIDEdit()
            {
                Buttons.BaseCuryIDEdit.Click();
            }

            public virtual void CountryIDEdit1()
            {
                Buttons.CountryIDEdit1.Click();
            }

            public virtual void WeightUOMEdit()
            {
                Buttons.WeightUOMEdit.Click();
            }

            public virtual void LinearUOMEdit()
            {
                Buttons.LinearUOMEdit.Click();
            }

            public virtual void VolumeUOMEdit()
            {
                Buttons.VolumeUOMEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button AddressLookup { get; }
                public Button ViewonMap { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }
                public Button BaseCuryIDEdit { get; }
                public Button CountryIDEdit1 { get; }
                public Button WeightUOMEdit { get; }
                public Button LinearUOMEdit { get; }
                public Button VolumeUOMEdit { get; }

                public PxButtonCollection()
                {
                    AddressLookup = new Button("ctl00_phG_tab_t0_DefAddress_btnAddressLookup", "Address Lookup", "ctl00_phG_tab_t0_DefContact");
                    ViewonMap = new Button("ctl00_phG_tab_t0_DefAddress_btnViewMainOnMap", "View on Map", "ctl00_phG_tab_t0_DefContact");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edCountryID\'] div[class=\'editBtnCont\'] > " +
                            "div > div", "CountryIDEdit", "ctl00_phG_tab_t0_DefContact");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edState\'] div[class=\'editBtnCont\'] > div " +
                            "> div", "StateEdit", "ctl00_phG_tab_t0_DefContact");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    BaseCuryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_Company_edBaseCuryID\'] div[class=\'editBtnCont\'] > di" +
                            "v > div", "BaseCuryIDEdit", "ctl00_phG_tab_t0_DefContact");
                    BaseCuryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    CountryIDEdit1 = new Button("css=div[id=\'ctl00_phG_tab_t0_ConfigurationSettings_edCountryID\'] div[class=\'editB" +
                            "tnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t0_DefContact");
                    CountryIDEdit1.WaitAction = Wait.WaitForNewWindowToOpen;
                    WeightUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edWeightUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "WeightUOMEdit", "ctl00_phG_tab_t0_DefContact");
                    WeightUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    LinearUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edLinearUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "LinearUOMEdit", "ctl00_phG_tab_t0_DefContact");
                    LinearUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VolumeUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edVolumeUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "VolumeUOMEdit", "ctl00_phG_tab_t0_DefContact");
                    VolumeUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_deflocationcontact_deflocationcontact : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit FullName { get; }
            public Label FullNameLabel { get; }
            public PXTextEdit Attention { get; }
            public Label AttentionLabel { get; }
            public EmailEdit EMail { get; }
            public Label EMailLabel { get; }
            public LinkEdit WebSite { get; }
            public Label WebSiteLabel { get; }
            public PXTextEdit Phone1 { get; }
            public Label Phone1Label { get; }
            public PXTextEdit Phone2 { get; }
            public Label Phone2Label { get; }
            public PXTextEdit Fax { get; }
            public Label FaxLabel { get; }

            public c_deflocationcontact_deflocationcontact(string locator, string name) :
                    base(locator, name)
            {
                FullName = new PXTextEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationContact_PXTextEdit1", "Account Name", locator, null);
                FullNameLabel = new Label(FullName);
                FullName.DataField = "FullName";
                Attention = new PXTextEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationContact_PXTextEdit2", "Attention", locator, null);
                AttentionLabel = new Label(Attention);
                Attention.DataField = "Attention";
                EMail = new EmailEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationContact_PXMailEdit1", "Email", locator, null);
                EMailLabel = new Label(EMail);
                EMail.DataField = "EMail";
                WebSite = new LinkEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationContact_PXLinkEdit1", "Web", locator, null);
                WebSiteLabel = new Label(WebSite);
                WebSite.DataField = "WebSite";
                Phone1 = new PXTextEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationContact_PXMaskEdit1", "Phone 1", locator, null);
                Phone1Label = new Label(Phone1);
                Phone1.DataField = "Phone1";
                Phone2 = new PXTextEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationContact_PXMaskEdit2", "Phone 2", locator, null);
                Phone2Label = new Label(Phone2);
                Phone2.DataField = "Phone2";
                Fax = new PXTextEdit("ctl00_phG_tab_t2_frmDefLocation_DefLocationContact_PXMaskEdit3", "Fax", locator, null);
                FaxLabel = new Label(Fax);
                Fax.DataField = "Fax";
                DataMemberName = "DefLocationContact";
                Buttons = new PxButtonCollection();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void VTaxZoneIDEdit()
            {
                Buttons.VTaxZoneIDEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button AddressLookup { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }
                public Button VTaxZoneIDEdit { get; }

                public PxButtonCollection()
                {
                    AddressLookup = new Button("ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_btnDefLocationAddressLookup", "Address Lookup", "ctl00_phG_tab_t2_frmDefLocation_DefLocationContact");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXSelector1\'] div[" +
                            "class=\'editBtnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t2_frmDefLocation_DefLocationContact");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t2_frmDefLocation_DefLocationAddress_PXSelector2\'] div[" +
                            "class=\'editBtnCont\'] > div > div", "StateEdit", "ctl00_phG_tab_t2_frmDefLocation_DefLocationContact");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VTaxZoneIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t2_frmDefLocation_edVTaxZoneID\'] div[class=\'editBtnCont" +
                            "\'] > div > div", "VTaxZoneIDEdit", "ctl00_phG_tab_t2_frmDefLocation_DefLocationContact");
                    VTaxZoneIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_company_miscsettings : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit PhoneMask { get; }
            public Label PhoneMaskLabel { get; }

            public c_company_miscsettings(string locator, string name) :
                    base(locator, name)
            {
                PhoneMask = new PXTextEdit("ctl00_phG_tab_t0_MiscSettings_PhoneMask", "Phone Mask", locator, null);
                PhoneMaskLabel = new Label(PhoneMask);
                PhoneMask.DataField = "PhoneMask";
                DataMemberName = "Company";
                Buttons = new PxButtonCollection();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void ViewonMap()
            {
                Buttons.ViewonMap.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void BaseCuryIDEdit()
            {
                Buttons.BaseCuryIDEdit.Click();
            }

            public virtual void CountryIDEdit1()
            {
                Buttons.CountryIDEdit1.Click();
            }

            public virtual void WeightUOMEdit()
            {
                Buttons.WeightUOMEdit.Click();
            }

            public virtual void LinearUOMEdit()
            {
                Buttons.LinearUOMEdit.Click();
            }

            public virtual void VolumeUOMEdit()
            {
                Buttons.VolumeUOMEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button AddressLookup { get; }
                public Button ViewonMap { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }
                public Button BaseCuryIDEdit { get; }
                public Button CountryIDEdit1 { get; }
                public Button WeightUOMEdit { get; }
                public Button LinearUOMEdit { get; }
                public Button VolumeUOMEdit { get; }

                public PxButtonCollection()
                {
                    AddressLookup = new Button("ctl00_phG_tab_t0_DefAddress_btnAddressLookup", "Address Lookup", "ctl00_phG_tab_t0_MiscSettings");
                    ViewonMap = new Button("ctl00_phG_tab_t0_DefAddress_btnViewMainOnMap", "View on Map", "ctl00_phG_tab_t0_MiscSettings");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edCountryID\'] div[class=\'editBtnCont\'] > " +
                            "div > div", "CountryIDEdit", "ctl00_phG_tab_t0_MiscSettings");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edState\'] div[class=\'editBtnCont\'] > div " +
                            "> div", "StateEdit", "ctl00_phG_tab_t0_MiscSettings");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    BaseCuryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_Company_edBaseCuryID\'] div[class=\'editBtnCont\'] > di" +
                            "v > div", "BaseCuryIDEdit", "ctl00_phG_tab_t0_MiscSettings");
                    BaseCuryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    CountryIDEdit1 = new Button("css=div[id=\'ctl00_phG_tab_t0_ConfigurationSettings_edCountryID\'] div[class=\'editB" +
                            "tnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t0_MiscSettings");
                    CountryIDEdit1.WaitAction = Wait.WaitForNewWindowToOpen;
                    WeightUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edWeightUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "WeightUOMEdit", "ctl00_phG_tab_t0_MiscSettings");
                    WeightUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    LinearUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edLinearUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "LinearUOMEdit", "ctl00_phG_tab_t0_MiscSettings");
                    LinearUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VolumeUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edVolumeUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "VolumeUOMEdit", "ctl00_phG_tab_t0_MiscSettings");
                    VolumeUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_organizationview_company : Container
        {

            public PxButtonCollection Buttons;

            public Selector BaseCuryID { get; }
            public Label BaseCuryIDLabel { get; }

            public c_organizationview_company(string locator, string name) :
                    base(locator, name)
            {
                BaseCuryID = new Selector("ctl00_phG_tab_t0_Company_edBaseCuryID", "Base Currency ID", locator, null);
                BaseCuryIDLabel = new Label(BaseCuryID);
                BaseCuryID.DataField = "BaseCuryID";
                DataMemberName = "OrganizationView";
                Buttons = new PxButtonCollection();
            }

            public virtual void BaseCuryIDEdit()
            {
                Buttons.BaseCuryIDEdit.Click();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void ViewonMap()
            {
                Buttons.ViewonMap.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void CountryIDEdit1()
            {
                Buttons.CountryIDEdit1.Click();
            }

            public virtual void WeightUOMEdit()
            {
                Buttons.WeightUOMEdit.Click();
            }

            public virtual void LinearUOMEdit()
            {
                Buttons.LinearUOMEdit.Click();
            }

            public virtual void VolumeUOMEdit()
            {
                Buttons.VolumeUOMEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button BaseCuryIDEdit { get; }
                public Button AddressLookup { get; }
                public Button ViewonMap { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }
                public Button CountryIDEdit1 { get; }
                public Button WeightUOMEdit { get; }
                public Button LinearUOMEdit { get; }
                public Button VolumeUOMEdit { get; }

                public PxButtonCollection()
                {
                    BaseCuryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_Company_edBaseCuryID\'] div[class=\'editBtnCont\'] > di" +
                            "v > div", "BaseCuryIDEdit", "ctl00_phG_tab_t0_Company");
                    BaseCuryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    AddressLookup = new Button("ctl00_phG_tab_t0_DefAddress_btnAddressLookup", "Address Lookup", "ctl00_phG_tab_t0_Company");
                    ViewonMap = new Button("ctl00_phG_tab_t0_DefAddress_btnViewMainOnMap", "View on Map", "ctl00_phG_tab_t0_Company");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edCountryID\'] div[class=\'editBtnCont\'] > " +
                            "div > div", "CountryIDEdit", "ctl00_phG_tab_t0_Company");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edState\'] div[class=\'editBtnCont\'] > div " +
                            "> div", "StateEdit", "ctl00_phG_tab_t0_Company");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    CountryIDEdit1 = new Button("css=div[id=\'ctl00_phG_tab_t0_ConfigurationSettings_edCountryID\'] div[class=\'editB" +
                            "tnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t0_Company");
                    CountryIDEdit1.WaitAction = Wait.WaitForNewWindowToOpen;
                    WeightUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edWeightUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "WeightUOMEdit", "ctl00_phG_tab_t0_Company");
                    WeightUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    LinearUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edLinearUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "LinearUOMEdit", "ctl00_phG_tab_t0_Company");
                    LinearUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VolumeUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edVolumeUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "VolumeUOMEdit", "ctl00_phG_tab_t0_Company");
                    VolumeUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_organizationview_configurationsettings : Container
        {

            public PxButtonCollection Buttons;

            public Selector RoleName { get; }
            public Label RoleNameLabel { get; }
            public Selector CountryID { get; }
            public Label CountryIDLabel { get; }
            public Selector DefaultPrinterID { get; }
            public Label DefaultPrinterIDLabel { get; }

            public c_organizationview_configurationsettings(string locator, string name) :
                    base(locator, name)
            {
                RoleName = new Selector("ctl00_phG_tab_t0_ConfigurationSettings_edRolename", "Access Role", locator, null);
                RoleNameLabel = new Label(RoleName);
                RoleName.DataField = "RoleName";
                CountryID = new Selector("ctl00_phG_tab_t0_ConfigurationSettings_edCountryID", "Default Country", locator, null);
                CountryIDLabel = new Label(CountryID);
                CountryID.DataField = "CountryID";
                DefaultPrinterID = new Selector("ctl00_phG_tab_t0_ConfigurationSettings_edDefaultPrinter", "Default Printer", locator, null);
                DefaultPrinterIDLabel = new Label(DefaultPrinterID);
                DefaultPrinterID.DataField = "DefaultPrinterID";
                DataMemberName = "OrganizationView";
                Buttons = new PxButtonCollection();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void ViewonMap()
            {
                Buttons.ViewonMap.Click();
            }

            public virtual void CountryIDEdit1()
            {
                Buttons.CountryIDEdit1.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void BaseCuryIDEdit()
            {
                Buttons.BaseCuryIDEdit.Click();
            }

            public virtual void WeightUOMEdit()
            {
                Buttons.WeightUOMEdit.Click();
            }

            public virtual void LinearUOMEdit()
            {
                Buttons.LinearUOMEdit.Click();
            }

            public virtual void VolumeUOMEdit()
            {
                Buttons.VolumeUOMEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button CountryIDEdit { get; }
                public Button AddressLookup { get; }
                public Button ViewonMap { get; }
                public Button CountryIDEdit1 { get; }
                public Button StateEdit { get; }
                public Button BaseCuryIDEdit { get; }
                public Button WeightUOMEdit { get; }
                public Button LinearUOMEdit { get; }
                public Button VolumeUOMEdit { get; }

                public PxButtonCollection()
                {
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_ConfigurationSettings_edCountryID\'] div[class=\'editB" +
                            "tnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t0_ConfigurationSettings");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    AddressLookup = new Button("ctl00_phG_tab_t0_DefAddress_btnAddressLookup", "Address Lookup", "ctl00_phG_tab_t0_ConfigurationSettings");
                    ViewonMap = new Button("ctl00_phG_tab_t0_DefAddress_btnViewMainOnMap", "View on Map", "ctl00_phG_tab_t0_ConfigurationSettings");
                    CountryIDEdit1 = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edCountryID\'] div[class=\'editBtnCont\'] > " +
                            "div > div", "CountryIDEdit", "ctl00_phG_tab_t0_ConfigurationSettings");
                    CountryIDEdit1.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edState\'] div[class=\'editBtnCont\'] > div " +
                            "> div", "StateEdit", "ctl00_phG_tab_t0_ConfigurationSettings");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    BaseCuryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_Company_edBaseCuryID\'] div[class=\'editBtnCont\'] > di" +
                            "v > div", "BaseCuryIDEdit", "ctl00_phG_tab_t0_ConfigurationSettings");
                    BaseCuryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    WeightUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edWeightUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "WeightUOMEdit", "ctl00_phG_tab_t0_ConfigurationSettings");
                    WeightUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    LinearUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edLinearUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "LinearUOMEdit", "ctl00_phG_tab_t0_ConfigurationSettings");
                    LinearUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VolumeUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edVolumeUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "VolumeUOMEdit", "ctl00_phG_tab_t0_ConfigurationSettings");
                    VolumeUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_organizationview_orgpart10 : Container
        {

            public PXTextEdit TCC { get; }
            public Label TCCLabel { get; }
            public CheckBox CFSFiler { get; }
            public Label CFSFilerLabel { get; }
            public CheckBox ForeignEntity { get; }
            public Label ForeignEntityLabel { get; }
            public PXTextEdit ContactName { get; }
            public Label ContactNameLabel { get; }
            public PXTextEdit CTelNumber { get; }
            public Label CTelNumberLabel { get; }
            public PXTextEdit CEmail { get; }
            public Label CEmailLabel { get; }
            public PXTextEdit NameControl { get; }
            public Label NameControlLabel { get; }

            public c_organizationview_orgpart10(string locator, string name) :
                    base(locator, name)
            {
                TCC = new PXTextEdit("ctl00_phG_tab_t6_OrgPart10_edTCC1", "Transmitter Control Code (TCC)", locator, null);
                TCCLabel = new Label(TCC);
                TCC.DataField = "TCC";
                CFSFiler = new CheckBox("ctl00_phG_tab_t6_OrgPart10_edCFSFiler2", "Combined Federal/State Filer", locator, null);
                CFSFilerLabel = new Label(CFSFiler);
                CFSFiler.DataField = "CFSFiler";
                ForeignEntity = new CheckBox("ctl00_phG_tab_t6_OrgPart10_edForeignEntity3", "Foreign Entity", locator, null);
                ForeignEntityLabel = new Label(ForeignEntity);
                ForeignEntity.DataField = "ForeignEntity";
                ContactName = new PXTextEdit("ctl00_phG_tab_t6_OrgPart10_edContactName4", "Contact Name", locator, null);
                ContactNameLabel = new Label(ContactName);
                ContactName.DataField = "ContactName";
                CTelNumber = new PXTextEdit("ctl00_phG_tab_t6_OrgPart10_edCTelNumber5", "Contact Telephone Number", locator, null);
                CTelNumberLabel = new Label(CTelNumber);
                CTelNumber.DataField = "CTelNumber";
                CEmail = new PXTextEdit("ctl00_phG_tab_t6_OrgPart10_edCEmail6", "Contact E-mail", locator, null);
                CEmailLabel = new Label(CEmail);
                CEmail.DataField = "CEmail";
                NameControl = new PXTextEdit("ctl00_phG_tab_t6_OrgPart10_edNameControl1", "Name Control", locator, null);
                NameControlLabel = new Label(NameControl);
                NameControl.DataField = "NameControl";
                DataMemberName = "OrganizationView";
            }
        }

        public class c_organizationview_frmlogo : Container
        {

            public PxButtonCollection Buttons;

            public ImageUploader LogoName { get; }
            public Label LogoNameLabel { get; }
            public PXTextEdit LogoNameGetter { get; }
            public Label LogoNameGetterLabel { get; }
            public ImageUploader LogoNameReport { get; }
            public Label LogoNameReportLabel { get; }
            public PXTextEdit LogoNameReportGetter { get; }
            public Label LogoNameReportGetterLabel { get; }
            public CheckBox OverrideThemeVariables { get; }
            public Label OverrideThemeVariablesLabel { get; }
            public PXTextEdit PrimaryColor { get; }
            public Label PrimaryColorLabel { get; }
            public PXTextEdit BackgroundColor { get; }
            public Label BackgroundColorLabel { get; }
            public Label LblLogoImgUploader_ { get; }
            public Label LblLogoReportImgUploader_ { get; }

            public c_organizationview_frmlogo(string locator, string name) :
                    base(locator, name)
            {
                LogoName = new ImageUploader("ctl00_phG_tab_t8_frmLogo_logoImgUploader", "Logo Name", locator);
                LogoNameLabel = new Label(LogoName);
                LogoName.DataField = "LogoName";
                LogoNameGetter = new PXTextEdit("ctl00_phG_tab_t8_frmLogo_lblLogoFileName", "Logo File", locator, null);
                LogoNameGetterLabel = new Label(LogoNameGetter);
                LogoNameGetter.DataField = "LogoNameGetter";
                LogoNameReport = new ImageUploader("ctl00_phG_tab_t8_frmLogo_reportLogoImgUploader", "Logo Name Report", locator);
                LogoNameReportLabel = new Label(LogoNameReport);
                LogoNameReport.DataField = "LogoNameReport";
                LogoNameReportGetter = new PXTextEdit("ctl00_phG_tab_t8_frmLogo_lblLogoFileNameReport", "Logo File", locator, null);
                LogoNameReportGetterLabel = new Label(LogoNameReportGetter);
                LogoNameReportGetter.DataField = "LogoNameReportGetter";
                OverrideThemeVariables = new CheckBox("ctl00_phG_tab_t8_frmLogo_chkOverrideThemeVariables", "Override Colors for the Selected Company", locator, null);
                OverrideThemeVariablesLabel = new Label(OverrideThemeVariables);
                OverrideThemeVariables.DataField = "OverrideThemeVariables";
                PrimaryColor = new PXTextEdit("ctl00_phG_tab_t8_frmLogo_edPrimaryColor", "Primary Color", locator, null);
                PrimaryColorLabel = new Label(PrimaryColor);
                PrimaryColor.DataField = "PrimaryColor";
                BackgroundColor = new PXTextEdit("ctl00_phG_tab_t8_frmLogo_PXBackgroundColor", "Background Color", locator, null);
                BackgroundColorLabel = new Label(BackgroundColor);
                BackgroundColor.DataField = "BackgroundColor";
                LblLogoImgUploader_ = new Label("ctl00_phG_tab_t8_frmLogo_lblLogoImgUploader", "Recommended Size: Width 210px, Height 50px", locator, null);
                LblLogoReportImgUploader_ = new Label("ctl00_phG_tab_t8_frmLogo_lblLogoReportImgUploader", "Recommended Size: Width 420px, Height 100px", locator, null);
                DataMemberName = "OrganizationView";
                Buttons = new PxButtonCollection();
            }

            public virtual void UpBtn()
            {
                Buttons.UpBtn.Click();
            }

            public virtual void UpBtn1()
            {
                Buttons.UpBtn1.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button UpBtn { get; }
                public Button UpBtn1 { get; }

                public PxButtonCollection()
                {
                    UpBtn = new Button("ctl00_phG_tab_t8_frmLogo_logoImgUploader_upld_upBtn", "upBtn", "ctl00_phG_tab_t8_frmLogo");
                    UpBtn1 = new Button("ctl00_phG_tab_t8_frmLogo_reportLogoImgUploader_upld_upBtn", "upBtn", "ctl00_phG_tab_t8_frmLogo");
                }
            }
        }

        public class c_organizationview_rutrotsettings : Container
        {

            public CheckBox AllowsRUTROT { get; }
            public Label AllowsRUTROTLabel { get; }
            public Selector RUTROTCuryID { get; }
            public Label RUTROTCuryIDLabel { get; }
            public PXNumberEdit RUTROTClaimNextRefNbr { get; }
            public Label RUTROTClaimNextRefNbrLabel { get; }
            public PXTextEdit RUTROTOrgNbrValidRegEx { get; }
            public Label RUTROTOrgNbrValidRegExLabel { get; }
            public DropDown DefaultRUTROTType { get; }
            public Label DefaultRUTROTTypeLabel { get; }
            public Selector TaxAgencyAccountID { get; }
            public Label TaxAgencyAccountIDLabel { get; }
            public DropDown BalanceOnProcess { get; }
            public Label BalanceOnProcessLabel { get; }
            public PXNumberEdit ROTPersonalAllowanceLimit { get; }
            public Label ROTPersonalAllowanceLimitLabel { get; }
            public PXNumberEdit ROTExtraAllowanceLimit { get; }
            public Label ROTExtraAllowanceLimitLabel { get; }
            public PXNumberEdit ROTDeductionPct { get; }
            public Label ROTDeductionPctLabel { get; }
            public PXNumberEdit RUTPersonalAllowanceLimit { get; }
            public Label RUTPersonalAllowanceLimitLabel { get; }
            public PXNumberEdit RUTExtraAllowanceLimit { get; }
            public Label RUTExtraAllowanceLimitLabel { get; }
            public PXNumberEdit RUTDeductionPct { get; }
            public Label RUTDeductionPctLabel { get; }

            public c_organizationview_rutrotsettings(string locator, string name) :
                    base(locator, name)
            {
                AllowsRUTROT = new CheckBox("ctl00_phG_tab_t10_RUTROTSettings_edRUTROTFlag", "Uses ROT & RUT deduction", locator, null);
                AllowsRUTROTLabel = new Label(AllowsRUTROT);
                AllowsRUTROT.DataField = "AllowsRUTROT";
                RUTROTCuryID = new Selector("ctl00_phG_tab_t10_RUTROTSettings_edRUTROTCury", "Currency", locator, null);
                RUTROTCuryIDLabel = new Label(RUTROTCuryID);
                RUTROTCuryID.DataField = "RUTROTCuryID";
                RUTROTClaimNextRefNbr = new PXNumberEdit("ctl00_phG_tab_t10_RUTROTSettings_edRUTROTNextRef", "Next Claim Nbr", locator, null);
                RUTROTClaimNextRefNbrLabel = new Label(RUTROTClaimNextRefNbr);
                RUTROTClaimNextRefNbr.DataField = "RUTROTClaimNextRefNbr";
                RUTROTOrgNbrValidRegEx = new PXTextEdit("ctl00_phG_tab_t10_RUTROTSettings_edRUTROTOrgNbrRegEx", "Org. Nbr. Validation Reg. Exp.", locator, null);
                RUTROTOrgNbrValidRegExLabel = new Label(RUTROTOrgNbrValidRegEx);
                RUTROTOrgNbrValidRegEx.DataField = "RUTROTOrgNbrValidRegEx";
                DefaultRUTROTType = new DropDown("ctl00_phG_tab_t10_RUTROTSettings_edDefaultRUTROTType", "Default RUTROT Type", locator, null);
                DefaultRUTROTTypeLabel = new Label(DefaultRUTROTType);
                DefaultRUTROTType.DataField = "DefaultRUTROTType";
                TaxAgencyAccountID = new Selector("ctl00_phG_tab_t10_RUTROTSettings_edTaxAgencyAccountID", "Tax Agency Account", locator, null);
                TaxAgencyAccountIDLabel = new Label(TaxAgencyAccountID);
                TaxAgencyAccountID.DataField = "TaxAgencyAccountID";
                BalanceOnProcess = new DropDown("ctl00_phG_tab_t10_RUTROTSettings_edBalanceOnProcess", "Balance Invoices On", locator, null);
                BalanceOnProcessLabel = new Label(BalanceOnProcess);
                BalanceOnProcess.DataField = "BalanceOnProcess";
                ROTPersonalAllowanceLimit = new PXNumberEdit("ctl00_phG_tab_t10_RUTROTSettings_edROTAllowance", "Standard Allowance Limit", locator, null);
                ROTPersonalAllowanceLimitLabel = new Label(ROTPersonalAllowanceLimit);
                ROTPersonalAllowanceLimit.DataField = "ROTPersonalAllowanceLimit";
                ROTExtraAllowanceLimit = new PXNumberEdit("ctl00_phG_tab_t10_RUTROTSettings_edROTAllowanceExtra", "Extra Allowance Limit", locator, null);
                ROTExtraAllowanceLimitLabel = new Label(ROTExtraAllowanceLimit);
                ROTExtraAllowanceLimit.DataField = "ROTExtraAllowanceLimit";
                ROTDeductionPct = new PXNumberEdit("ctl00_phG_tab_t10_RUTROTSettings_edROTPercent", "Deduction,%", locator, null);
                ROTDeductionPctLabel = new Label(ROTDeductionPct);
                ROTDeductionPct.DataField = "ROTDeductionPct";
                RUTPersonalAllowanceLimit = new PXNumberEdit("ctl00_phG_tab_t10_RUTROTSettings_edRUTAllowance", "Standard Allowance Limit", locator, null);
                RUTPersonalAllowanceLimitLabel = new Label(RUTPersonalAllowanceLimit);
                RUTPersonalAllowanceLimit.DataField = "RUTPersonalAllowanceLimit";
                RUTExtraAllowanceLimit = new PXNumberEdit("ctl00_phG_tab_t10_RUTROTSettings_edRUTAllowanceExtra", "Extra Allowance Limit", locator, null);
                RUTExtraAllowanceLimitLabel = new Label(RUTExtraAllowanceLimit);
                RUTExtraAllowanceLimit.DataField = "RUTExtraAllowanceLimit";
                RUTDeductionPct = new PXNumberEdit("ctl00_phG_tab_t10_RUTROTSettings_edRUTPercent", "Deduction,%", locator, null);
                RUTDeductionPctLabel = new Label(RUTDeductionPct);
                RUTDeductionPct.DataField = "RUTDeductionPct";
                DataMemberName = "OrganizationView";
            }
        }

        public class c_organizationview_formcarrierfacility : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit CarrierFacility { get; }
            public Label CarrierFacilityLabel { get; }

            public c_organizationview_formcarrierfacility(string locator, string name) :
                    base(locator, name)
            {
                CarrierFacility = new PXTextEdit("ctl00_phG_tab_t0_DefAddress_formCarrierFacility_edCarrierFacility", "Carrier Facility", locator, null);
                CarrierFacilityLabel = new Label(CarrierFacility);
                CarrierFacility.DataField = "CarrierFacility";
                DataMemberName = "OrganizationView";
                Buttons = new PxButtonCollection();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void ViewonMap()
            {
                Buttons.ViewonMap.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void BaseCuryIDEdit()
            {
                Buttons.BaseCuryIDEdit.Click();
            }

            public virtual void CountryIDEdit1()
            {
                Buttons.CountryIDEdit1.Click();
            }

            public virtual void WeightUOMEdit()
            {
                Buttons.WeightUOMEdit.Click();
            }

            public virtual void LinearUOMEdit()
            {
                Buttons.LinearUOMEdit.Click();
            }

            public virtual void VolumeUOMEdit()
            {
                Buttons.VolumeUOMEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button AddressLookup { get; }
                public Button ViewonMap { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }
                public Button BaseCuryIDEdit { get; }
                public Button CountryIDEdit1 { get; }
                public Button WeightUOMEdit { get; }
                public Button LinearUOMEdit { get; }
                public Button VolumeUOMEdit { get; }

                public PxButtonCollection()
                {
                    AddressLookup = new Button("ctl00_phG_tab_t0_DefAddress_btnAddressLookup", "Address Lookup", "ctl00_phG_tab_t0_DefAddress_formCarrierFacility");
                    ViewonMap = new Button("ctl00_phG_tab_t0_DefAddress_btnViewMainOnMap", "View on Map", "ctl00_phG_tab_t0_DefAddress_formCarrierFacility");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edCountryID\'] div[class=\'editBtnCont\'] > " +
                            "div > div", "CountryIDEdit", "ctl00_phG_tab_t0_DefAddress_formCarrierFacility");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edState\'] div[class=\'editBtnCont\'] > div " +
                            "> div", "StateEdit", "ctl00_phG_tab_t0_DefAddress_formCarrierFacility");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    BaseCuryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_Company_edBaseCuryID\'] div[class=\'editBtnCont\'] > di" +
                            "v > div", "BaseCuryIDEdit", "ctl00_phG_tab_t0_DefAddress_formCarrierFacility");
                    BaseCuryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    CountryIDEdit1 = new Button("css=div[id=\'ctl00_phG_tab_t0_ConfigurationSettings_edCountryID\'] div[class=\'editB" +
                            "tnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t0_DefAddress_formCarrierFacility");
                    CountryIDEdit1.WaitAction = Wait.WaitForNewWindowToOpen;
                    WeightUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edWeightUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "WeightUOMEdit", "ctl00_phG_tab_t0_DefAddress_formCarrierFacility");
                    WeightUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    LinearUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edLinearUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "LinearUOMEdit", "ctl00_phG_tab_t0_DefAddress_formCarrierFacility");
                    LinearUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VolumeUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edVolumeUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "VolumeUOMEdit", "ctl00_phG_tab_t0_DefAddress_formCarrierFacility");
                    VolumeUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_branchesview_grdbranches : Grid<c_branchesview_grdbranches.c_grid_row, c_branchesview_grdbranches.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_branchesview_grdbranches(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t1_grdBranches");
                DataMemberName = "BranchesView";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t1_grdBranches_fe_gf", "FilterForm");
            }

            public virtual void Refresh()
            {
                ToolBar.Refresh.Click();
            }

            public virtual void AddBranch()
            {
                ToolBar.AddBranch.Click();
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
                public ToolBarButtonGrid AddBranch { get; }
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    AddBranch = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_at_tlb div[data-cmd=\'AddBranch\']", "Add Branch", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_grdBranches_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public Selector BranchCD { get; }
                public PXTextEdit AcctName { get; }
                public CheckBox Active { get; }
                public Selector RoleName { get; }
                public PXTextEdit Roles__Descr { get; }

                public c_grid_row(c_branchesview_grdbranches grid) :
                        base(grid)
                {
                    BranchCD = new Selector("_ctl00_phG_tab_t1_grdBranches_lv0_es", "Branch ID", grid.Locator, "BranchCD");
                    BranchCD.DataField = "BranchCD";
                    AcctName = new PXTextEdit("ctl00_phG_tab_t1_grdBranches_ei", "Branch Name", grid.Locator, "AcctName");
                    AcctName.DataField = "AcctName";
                    Active = new CheckBox("ctl00_phG_tab_t1_grdBranches", "Active", grid.Locator, "Active");
                    Active.DataField = "Active";
                    RoleName = new Selector("_ctl00_phG_tab_t1_grdBranches_lv0_es", "Access Role", grid.Locator, "RoleName");
                    RoleName.DataField = "RoleName";
                    Roles__Descr = new PXTextEdit("ctl00_phG_tab_t1_grdBranches_ei", "Role Description", grid.Locator, "Roles__Descr");
                    Roles__Descr.DataField = "Roles__Descr";
                }
            }

            public class c_grid_header : GridHeader
            {

                public SelectorColumnFilter BranchCD { get; }
                public PXTextEditColumnFilter AcctName { get; }
                public CheckBoxColumnFilter Active { get; }
                public SelectorColumnFilter RoleName { get; }
                public PXTextEditColumnFilter Roles__Descr { get; }

                public c_grid_header(c_branchesview_grdbranches grid) :
                        base(grid)
                {
                    BranchCD = new SelectorColumnFilter(grid.Row.BranchCD);
                    AcctName = new PXTextEditColumnFilter(grid.Row.AcctName);
                    Active = new CheckBoxColumnFilter(grid.Row.Active);
                    RoleName = new SelectorColumnFilter(grid.Row.RoleName);
                    Roles__Descr = new PXTextEditColumnFilter(grid.Row.Roles__Descr);
                }
            }
        }

        public class c_branchesview_lv0 : Container
        {

            public Selector Es { get; }
            public Label EsLabel { get; }

            public c_branchesview_lv0(string locator, string name) :
                    base(locator, name)
            {
                Es = new Selector("ctl00_phG_tab_t1_grdBranches_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                DataMemberName = "BranchesView";
            }
        }

        public class c_employees_grdemployees : Grid<c_employees_grdemployees.c_grid_row, c_employees_grdemployees.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }
            public SmartPanel_AttachFile FilesUploadDialog { get; }
            public Note NotePanel { get; }

            public c_employees_grdemployees(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t3_grdEmployees");
                DataMemberName = "Employees";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t3_grdEmployees_fe_gf", "FilterForm");
                FilesUploadDialog = new SmartPanel_AttachFile(locator);
                NotePanel = new Note(locator);
            }

            public virtual void Refresh()
            {
                ToolBar.Refresh.Click();
            }

            public virtual void NewContact()
            {
                ToolBar.NewContact.Click();
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
                public ToolBarButtonGrid NewContact { get; }
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    NewContact = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_at_tlb div[data-cmd=\'NewContact\']", "New Employee", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_grdEmployees_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public FileColumnButton Files { get; }
                public NoteColumnButton Notes { get; }
                public Selector BranchAlias__BranchCD { get; }
                public Selector AcctCD { get; }
                public PXTextEdit Contact__DisplayName { get; }
                public Selector DepartmentID { get; }
                public PXTextEdit Address__City { get; }
                public Selector Address__State { get; }
                public PXTextEdit Contact__Phone1 { get; }
                public PXTextEdit Contact__EMail { get; }
                public DropDown VStatus { get; }

                public c_grid_row(c_employees_grdemployees grid) :
                        base(grid)
                {
                    Files = new FileColumnButton(null, "Files", grid.Locator, "Files");
                    Notes = new NoteColumnButton(null, "Notes", grid.Locator, "Notes");
                    BranchAlias__BranchCD = new Selector("_ctl00_phG_tab_t3_grdEmployees_lv0_es", "Branch ID", grid.Locator, "BranchAlias__BranchCD");
                    BranchAlias__BranchCD.DataField = "BranchAlias__BranchCD";
                    AcctCD = new Selector("_ctl00_phG_tab_t3_grdEmployees_lv0_es", "Employee ID", grid.Locator, "AcctCD");
                    AcctCD.DataField = "AcctCD";
                    Contact__DisplayName = new PXTextEdit("ctl00_phG_tab_t3_grdEmployees_ei", "Name", grid.Locator, "Contact__DisplayName");
                    Contact__DisplayName.DataField = "Contact__DisplayName";
                    DepartmentID = new Selector("_ctl00_phG_tab_t3_grdEmployees_lv0_es", "Department", grid.Locator, "DepartmentID");
                    DepartmentID.DataField = "DepartmentID";
                    Address__City = new PXTextEdit("ctl00_phG_tab_t3_grdEmployees_ei", "City", grid.Locator, "Address__City");
                    Address__City.DataField = "Address__City";
                    Address__State = new Selector("_ctl00_phG_tab_t3_grdEmployees_lv0_es", "State", grid.Locator, "Address__State");
                    Address__State.DataField = "Address__State";
                    Contact__Phone1 = new PXTextEdit("ctl00_phG_tab_t3_grdEmployees_ei", "Phone 1", grid.Locator, "Contact__Phone1");
                    Contact__Phone1.DataField = "Contact__Phone1";
                    Contact__EMail = new PXTextEdit("ctl00_phG_tab_t3_grdEmployees_ei", "Email", grid.Locator, "Contact__EMail");
                    Contact__EMail.DataField = "Contact__EMail";
                    VStatus = new DropDown("_ctl00_phG_tab_t3_grdEmployees_lv0_ec", "Status", grid.Locator, "VStatus");
                    VStatus.DataField = "VStatus";
                    VStatus.Items.Add("A", "Active");
                    VStatus.Items.Add("H", "On Hold");
                    VStatus.Items.Add("P", "Hold Payments");
                    VStatus.Items.Add("T", "One-Time");
                    VStatus.Items.Add("I", "Inactive");
                }
            }

            public class c_grid_header : GridHeader
            {

                public GridColumnHeader Files { get; }
                public GridColumnHeader Notes { get; }
                public SelectorColumnFilter BranchAlias__BranchCD { get; }
                public SelectorColumnFilter AcctCD { get; }
                public PXTextEditColumnFilter Contact__DisplayName { get; }
                public SelectorColumnFilter DepartmentID { get; }
                public PXTextEditColumnFilter Address__City { get; }
                public SelectorColumnFilter Address__State { get; }
                public PXTextEditColumnFilter Contact__Phone1 { get; }
                public PXTextEditColumnFilter Contact__EMail { get; }
                public DropDownColumnFilter VStatus { get; }

                public c_grid_header(c_employees_grdemployees grid) :
                        base(grid)
                {
                    Files = new GridColumnHeader(grid.Row.Files);
                    Notes = new GridColumnHeader(grid.Row.Notes);
                    BranchAlias__BranchCD = new SelectorColumnFilter(grid.Row.BranchAlias__BranchCD);
                    AcctCD = new SelectorColumnFilter(grid.Row.AcctCD);
                    Contact__DisplayName = new PXTextEditColumnFilter(grid.Row.Contact__DisplayName);
                    DepartmentID = new SelectorColumnFilter(grid.Row.DepartmentID);
                    Address__City = new PXTextEditColumnFilter(grid.Row.Address__City);
                    Address__State = new SelectorColumnFilter(grid.Row.Address__State);
                    Contact__Phone1 = new PXTextEditColumnFilter(grid.Row.Contact__Phone1);
                    Contact__EMail = new PXTextEditColumnFilter(grid.Row.Contact__EMail);
                    VStatus = new DropDownColumnFilter(grid.Row.VStatus);
                }
            }
        }

        public class c_employees_lv0 : Container
        {

            public Selector Es { get; }
            public Label EsLabel { get; }
            public DropDown Ec { get; }

            public c_employees_lv0(string locator, string name) :
                    base(locator, name)
            {
                Es = new Selector("ctl00_phG_tab_t3_grdEmployees_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Ec = new DropDown("ctl00_phG_tab_t3_grdEmployees_lv0_ec", "Ec", locator, null);
                DataMemberName = "Employees";
            }
        }

        public class c_commonsetup_commonsettings : Container
        {

            public PxButtonCollection Buttons;

            public PXNumberEdit DecPlQty { get; }
            public Label DecPlQtyLabel { get; }
            public PXNumberEdit DecPlPrcCst { get; }
            public Label DecPlPrcCstLabel { get; }
            public Selector WeightUOM { get; }
            public Label WeightUOMLabel { get; }
            public Selector LinearUOM { get; }
            public Label LinearUOMLabel { get; }
            public Selector VolumeUOM { get; }
            public Label VolumeUOMLabel { get; }

            public c_commonsetup_commonsettings(string locator, string name) :
                    base(locator, name)
            {
                DecPlQty = new PXNumberEdit("ctl00_phG_tab_t0_CommonSettings_edDecPlQty", "Quantity Decimal Places", locator, null);
                DecPlQtyLabel = new Label(DecPlQty);
                DecPlQty.DataField = "DecPlQty";
                DecPlPrcCst = new PXNumberEdit("ctl00_phG_tab_t0_CommonSettings_edDecPlPrcCst", "Price/Cost Decimal Places", locator, null);
                DecPlPrcCstLabel = new Label(DecPlPrcCst);
                DecPlPrcCst.DataField = "DecPlPrcCst";
                WeightUOM = new Selector("ctl00_phG_tab_t0_CommonSettings_edWeightUOM", "Weight UOM", locator, null);
                WeightUOMLabel = new Label(WeightUOM);
                WeightUOM.DataField = "WeightUOM";
                LinearUOM = new Selector("ctl00_phG_tab_t0_CommonSettings_edLinearUOM", "Linear UOM", locator, null);
                LinearUOMLabel = new Label(LinearUOM);
                LinearUOM.DataField = "LinearUOM";
                VolumeUOM = new Selector("ctl00_phG_tab_t0_CommonSettings_edVolumeUOM", "Volume UOM", locator, null);
                VolumeUOMLabel = new Label(VolumeUOM);
                VolumeUOM.DataField = "VolumeUOM";
                DataMemberName = "commonsetup";
                Buttons = new PxButtonCollection();
            }

            public virtual void WeightUOMEdit()
            {
                Buttons.WeightUOMEdit.Click();
            }

            public virtual void LinearUOMEdit()
            {
                Buttons.LinearUOMEdit.Click();
            }

            public virtual void VolumeUOMEdit()
            {
                Buttons.VolumeUOMEdit.Click();
            }

            public virtual void AddressLookup()
            {
                Buttons.AddressLookup.Click();
            }

            public virtual void ViewonMap()
            {
                Buttons.ViewonMap.Click();
            }

            public virtual void CountryIDEdit()
            {
                Buttons.CountryIDEdit.Click();
            }

            public virtual void StateEdit()
            {
                Buttons.StateEdit.Click();
            }

            public virtual void BaseCuryIDEdit()
            {
                Buttons.BaseCuryIDEdit.Click();
            }

            public virtual void CountryIDEdit1()
            {
                Buttons.CountryIDEdit1.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button WeightUOMEdit { get; }
                public Button LinearUOMEdit { get; }
                public Button VolumeUOMEdit { get; }
                public Button AddressLookup { get; }
                public Button ViewonMap { get; }
                public Button CountryIDEdit { get; }
                public Button StateEdit { get; }
                public Button BaseCuryIDEdit { get; }
                public Button CountryIDEdit1 { get; }

                public PxButtonCollection()
                {
                    WeightUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edWeightUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "WeightUOMEdit", "ctl00_phG_tab_t0_CommonSettings");
                    WeightUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    LinearUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edLinearUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "LinearUOMEdit", "ctl00_phG_tab_t0_CommonSettings");
                    LinearUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    VolumeUOMEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_CommonSettings_edVolumeUOM\'] div[class=\'editBtnCont\'" +
                            "] > div > div", "VolumeUOMEdit", "ctl00_phG_tab_t0_CommonSettings");
                    VolumeUOMEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    AddressLookup = new Button("ctl00_phG_tab_t0_DefAddress_btnAddressLookup", "Address Lookup", "ctl00_phG_tab_t0_CommonSettings");
                    ViewonMap = new Button("ctl00_phG_tab_t0_DefAddress_btnViewMainOnMap", "View on Map", "ctl00_phG_tab_t0_CommonSettings");
                    CountryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edCountryID\'] div[class=\'editBtnCont\'] > " +
                            "div > div", "CountryIDEdit", "ctl00_phG_tab_t0_CommonSettings");
                    CountryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    StateEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_DefAddress_edState\'] div[class=\'editBtnCont\'] > div " +
                            "> div", "StateEdit", "ctl00_phG_tab_t0_CommonSettings");
                    StateEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    BaseCuryIDEdit = new Button("css=div[id=\'ctl00_phG_tab_t0_Company_edBaseCuryID\'] div[class=\'editBtnCont\'] > di" +
                            "v > div", "BaseCuryIDEdit", "ctl00_phG_tab_t0_CommonSettings");
                    BaseCuryIDEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    CountryIDEdit1 = new Button("css=div[id=\'ctl00_phG_tab_t0_ConfigurationSettings_edCountryID\'] div[class=\'editB" +
                            "tnCont\'] > div > div", "CountryIDEdit", "ctl00_phG_tab_t0_CommonSettings");
                    CountryIDEdit1.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_stateview_stateform : Container
        {

            public CheckBox IsBranchTabVisible { get; }
            public Label IsBranchTabVisibleLabel { get; }
            public CheckBox IsDeliverySettingsTabVisible { get; }
            public Label IsDeliverySettingsTabVisibleLabel { get; }
            public CheckBox IsGLAccountsTabVisible { get; }
            public Label IsGLAccountsTabVisibleLabel { get; }
            public CheckBox IsRutRotTabVisible { get; }
            public Label IsRutRotTabVisibleLabel { get; }
            public CheckBox IsGroup { get; }
            public Label IsGroupLabel { get; }
            public CheckBox IsCompanyGroupsVisible { get; }
            public Label IsCompanyGroupsVisibleLabel { get; }

            public c_stateview_stateform(string locator, string name) :
                    base(locator, name)
            {
                IsBranchTabVisible = new CheckBox("ctl00_phF_PXFormView1_StateForm_chkIsBranchTabVisible", "IsBranchTabVisible", locator, null);
                IsBranchTabVisibleLabel = new Label(IsBranchTabVisible);
                IsBranchTabVisible.DataField = "IsBranchTabVisible";
                IsDeliverySettingsTabVisible = new CheckBox("ctl00_phF_PXFormView1_StateForm_chkIsDeliverySettingsTabVisible", "IsDeliverySettingsTabVisible", locator, null);
                IsDeliverySettingsTabVisibleLabel = new Label(IsDeliverySettingsTabVisible);
                IsDeliverySettingsTabVisible.DataField = "IsDeliverySettingsTabVisible";
                IsGLAccountsTabVisible = new CheckBox("ctl00_phF_PXFormView1_StateForm_chkIsGLAccountsTabVisible", "IsGLAccountsTabVisible", locator, null);
                IsGLAccountsTabVisibleLabel = new Label(IsGLAccountsTabVisible);
                IsGLAccountsTabVisible.DataField = "IsGLAccountsTabVisible";
                IsRutRotTabVisible = new CheckBox("ctl00_phF_PXFormView1_StateForm_chkIsRutRotTabVisible", "IsRutRotTabVisible", locator, null);
                IsRutRotTabVisibleLabel = new Label(IsRutRotTabVisible);
                IsRutRotTabVisible.DataField = "IsRutRotTabVisible";
                IsGroup = new CheckBox("ctl00_phF_PXFormView1_StateForm_chkIsGroup", "IsGroup", locator, null);
                IsGroupLabel = new Label(IsGroup);
                IsGroup.DataField = "IsGroup";
                IsCompanyGroupsVisible = new CheckBox("ctl00_phF_PXFormView1_StateForm_chkIsCompanyGroupsVisible", "IsCompanyGroupsVisible", locator, null);
                IsCompanyGroupsVisibleLabel = new Label(IsCompanyGroupsVisible);
                IsCompanyGroupsVisible.DataField = "IsCompanyGroupsVisible";
                DataMemberName = "StateView";
            }
        }

        public class c_groups_grid : Grid<c_groups_grid.c_grid_row, c_groups_grid.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_groups_grid(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t9_grid");
                DataMemberName = "Groups";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t9_grid_fe_gf", "FilterForm");
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

            public virtual void SetAsPrimary()
            {
                ToolBar.SetAsPrimary.Click();
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
                public ToolBarButtonGrid SetAsPrimary { get; }
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Delete.ConfirmAction = () => Alert.AlertToException("The current {0} record will be deleted.");
                    SetAsPrimary = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_at_tlb div[data-cmd=\'SetAsPrimary\']", "Set As Primary", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t9_grid_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public Selector GroupID { get; }
                public PXTextEdit Organization__OrganizationName { get; }
                public CheckBox PrimaryGroup { get; }
                public PXNumberEdit OrganizationID { get; }

                public c_grid_row(c_groups_grid grid) :
                        base(grid)
                {
                    GroupID = new Selector("_ctl00_phG_tab_t9_grid_lv0_edGroupID", "Group ID", grid.Locator, "GroupID");
                    GroupID.DataField = "GroupID";
                    Organization__OrganizationName = new PXTextEdit("ctl00_phG_tab_t9_grid_ei", "Group Name", grid.Locator, "Organization__OrganizationName");
                    Organization__OrganizationName.DataField = "Organization__OrganizationName";
                    PrimaryGroup = new CheckBox("ctl00_phG_tab_t9_grid", "Primary", grid.Locator, "PrimaryGroup");
                    PrimaryGroup.DataField = "PrimaryGroup";
                    OrganizationID = new PXNumberEdit("ctl00_phG_tab_t9_grid_en", "OrganizationID", grid.Locator, "OrganizationID");
                    OrganizationID.DataField = "OrganizationID";
                }
            }

            public class c_grid_header : GridHeader
            {

                public SelectorColumnFilter GroupID { get; }
                public PXTextEditColumnFilter Organization__OrganizationName { get; }
                public CheckBoxColumnFilter PrimaryGroup { get; }
                public PXNumberEditColumnFilter OrganizationID { get; }

                public c_grid_header(c_groups_grid grid) :
                        base(grid)
                {
                    GroupID = new SelectorColumnFilter(grid.Row.GroupID);
                    Organization__OrganizationName = new PXTextEditColumnFilter(grid.Row.Organization__OrganizationName);
                    PrimaryGroup = new CheckBoxColumnFilter(grid.Row.PrimaryGroup);
                    OrganizationID = new PXNumberEditColumnFilter(grid.Row.OrganizationID);
                }
            }
        }

        public class c_groups_lv0 : Container
        {

            public Selector GroupID { get; }
            public Label GroupIDLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }

            public c_groups_lv0(string locator, string name) :
                    base(locator, name)
            {
                GroupID = new Selector("ctl00_phG_tab_t9_grid_lv0_edGroupID", "Group ID", locator, null);
                GroupIDLabel = new Label(GroupID);
                GroupID.DataField = "GroupID";
                Es = new Selector("ctl00_phG_tab_t9_grid_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                DataMemberName = "Groups";
            }
        }

        public class c_createledgerview_loform : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit LedgerCD { get; }
            public Label LedgerCDLabel { get; }
            public PXTextEdit Descr { get; }
            public Label DescrLabel { get; }

            public c_createledgerview_loform(string locator, string name) :
                    base(locator, name)
            {
                LedgerCD = new PXTextEdit("ctl00_phF_pnlCreateLedger_loform_edLedgerCD", "Ledger CD", locator, null);
                LedgerCDLabel = new Label(LedgerCD);
                LedgerCD.DataField = "LedgerCD";
                Descr = new PXTextEdit("ctl00_phF_pnlCreateLedger_loform_edLedgerDescr", "Descr", locator, null);
                DescrLabel = new Label(Descr);
                Descr.DataField = "Descr";
                DataMemberName = "CreateLedgerView";
                Buttons = new PxButtonCollection();
            }

            public virtual void Create()
            {
                Buttons.Create.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Create { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    Create = new Button("ctl00_phF_pnlCreateLedger_cbOK", "Create", "ctl00_phF_pnlCreateLedger_loform");
                    Cancel = new Button("ctl00_phF_pnlCreateLedger_cbCancel", "Cancel", "ctl00_phF_pnlCreateLedger_loform");
                }
            }
        }

        public class c_organizationledgerlinkwithledgerselect_grdledgerlinks : Grid<c_organizationledgerlinkwithledgerselect_grdledgerlinks.c_grid_row, c_organizationledgerlinkwithledgerselect_grdledgerlinks.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_organizationledgerlinkwithledgerselect_grdledgerlinks(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t4_grdLedgerLinks");
                DataMemberName = "OrganizationLedgerLinkWithLedgerSelect";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t4_grdLedgerLinks_fe_gf", "FilterForm");
            }

            public virtual void Refresh()
            {
                ToolBar.Refresh.Click();
            }

            public virtual void New()
            {
                ToolBar.New.Click();
            }

            public virtual void DeleteOrganizationLedgerLink()
            {
                ToolBar.DeleteOrganizationLedgerLink.Click();
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
                public ToolBarButtonGrid DeleteOrganizationLedgerLink { get; }
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    DeleteOrganizationLedgerLink = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_at_tlb div[data-cmd=\'DeleteOrganizationLedge" +
                            "rLink\']", "Delete", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_grdLedgerLinks_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public Selector LedgerID { get; }
                public InputLocalizable Ledger__Descr { get; }
                public DropDown Ledger__BalanceType { get; }
                public Selector Ledger__BaseCuryID { get; }
                public CheckBox Ledger__ConsolAllowed { get; }
                public PXNumberEdit OrganizationID { get; }

                public c_grid_row(c_organizationledgerlinkwithledgerselect_grdledgerlinks grid) :
                        base(grid)
                {
                    LedgerID = new Selector("_ctl00_phG_tab_t4_grdLedgerLinks_lv0_edLedgerID", "Ledger", grid.Locator, "LedgerID");
                    LedgerID.DataField = "LedgerID";
                    Ledger__Descr = new InputLocalizable("ctl00_phG_tab_t4_grdLedgerLinks_ei", "Description", grid.Locator, "Ledger__Descr");
                    Ledger__Descr.DataField = "Ledger__Descr";
                    Ledger__BalanceType = new DropDown("_ctl00_phG_tab_t4_grdLedgerLinks_lv0_ec", "Type", grid.Locator, "Ledger__BalanceType");
                    Ledger__BalanceType.DataField = "Ledger__BalanceType";
                    Ledger__BalanceType.Items.Add("A", "Actual");
                    Ledger__BalanceType.Items.Add("R", "Reporting");
                    Ledger__BalanceType.Items.Add("S", "Statistical");
                    Ledger__BalanceType.Items.Add("B", "Budget");
                    Ledger__BaseCuryID = new Selector("_ctl00_phG_tab_t4_grdLedgerLinks_lv0_es", "Currency", grid.Locator, "Ledger__BaseCuryID");
                    Ledger__BaseCuryID.DataField = "Ledger__BaseCuryID";
                    Ledger__ConsolAllowed = new CheckBox("ctl00_phG_tab_t4_grdLedgerLinks", "Consolidation Source", grid.Locator, "Ledger__ConsolAllowed");
                    Ledger__ConsolAllowed.DataField = "Ledger__ConsolAllowed";
                    OrganizationID = new PXNumberEdit("ctl00_phG_tab_t4_grdLedgerLinks_en", "OrganizationID", grid.Locator, "OrganizationID");
                    OrganizationID.DataField = "OrganizationID";
                }
            }

            public class c_grid_header : GridHeader
            {

                public SelectorColumnFilter LedgerID { get; }
                public PXTextEditColumnFilter Ledger__Descr { get; }
                public DropDownColumnFilter Ledger__BalanceType { get; }
                public SelectorColumnFilter Ledger__BaseCuryID { get; }
                public CheckBoxColumnFilter Ledger__ConsolAllowed { get; }
                public PXNumberEditColumnFilter OrganizationID { get; }

                public c_grid_header(c_organizationledgerlinkwithledgerselect_grdledgerlinks grid) :
                        base(grid)
                {
                    LedgerID = new SelectorColumnFilter(grid.Row.LedgerID);
                    Ledger__Descr = new PXTextEditColumnFilter(grid.Row.Ledger__Descr);
                    Ledger__BalanceType = new DropDownColumnFilter(grid.Row.Ledger__BalanceType);
                    Ledger__BaseCuryID = new SelectorColumnFilter(grid.Row.Ledger__BaseCuryID);
                    Ledger__ConsolAllowed = new CheckBoxColumnFilter(grid.Row.Ledger__ConsolAllowed);
                    OrganizationID = new PXNumberEditColumnFilter(grid.Row.OrganizationID);
                }
            }
        }

        public class c_organizationledgerlinkwithledgerselect_lv0 : Container
        {

            public Selector LedgerID { get; }
            public Label LedgerIDLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }
            public DropDown Ec { get; }

            public c_organizationledgerlinkwithledgerselect_lv0(string locator, string name) :
                    base(locator, name)
            {
                LedgerID = new Selector("ctl00_phG_tab_t4_grdLedgerLinks_lv0_edLedgerID", "Ledger", locator, null);
                LedgerIDLabel = new Label(LedgerID);
                LedgerID.DataField = "LedgerID";
                Es = new Selector("ctl00_phG_tab_t4_grdLedgerLinks_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                Ec = new DropDown("ctl00_phG_tab_t4_grdLedgerLinks_lv0_ec", "Ec", locator, null);
                DataMemberName = "OrganizationLedgerLinkWithLedgerSelect";
            }
        }

        public class c_addresslookupfilter_addresslookuppanelformaddress : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit SearchAddress { get; }
            public Label SearchAddressLabel { get; }
            public PXTextEdit ViewName { get; }
            public Label ViewNameLabel { get; }
            public PXTextEdit AddressLine1 { get; }
            public Label AddressLine1Label { get; }
            public PXTextEdit AddressLine2 { get; }
            public Label AddressLine2Label { get; }
            public PXTextEdit AddressLine3 { get; }
            public Label AddressLine3Label { get; }
            public PXTextEdit City { get; }
            public Label CityLabel { get; }
            public PXTextEdit CountryID { get; }
            public Label CountryIDLabel { get; }
            public PXTextEdit State { get; }
            public Label StateLabel { get; }
            public PXTextEdit PostalCode { get; }
            public Label PostalCodeLabel { get; }
            public PXTextEdit Latitude { get; }
            public Label LatitudeLabel { get; }
            public PXTextEdit Longitude { get; }
            public Label LongitudeLabel { get; }

            public c_addresslookupfilter_addresslookuppanelformaddress(string locator, string name) :
                    base(locator, name)
            {
                SearchAddress = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_searchBox", "Search Address", locator, null);
                SearchAddressLabel = new Label(SearchAddress);
                SearchAddress.DataField = "SearchAddress";
                ViewName = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_addressLookupViewName", "ViewName", locator, null);
                ViewNameLabel = new Label(ViewName);
                ViewName.DataField = "ViewName";
                AddressLine1 = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_SearchResponseAddressL" +
                        "ine1", "AddressLine1", locator, null);
                AddressLine1Label = new Label(AddressLine1);
                AddressLine1.DataField = "AddressLine1";
                AddressLine2 = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_SearchResponseAddressL" +
                        "ine2", "AddressLine2", locator, null);
                AddressLine2Label = new Label(AddressLine2);
                AddressLine2.DataField = "AddressLine2";
                AddressLine3 = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_SearchResponseAddressL" +
                        "ine3", "AddressLine3", locator, null);
                AddressLine3Label = new Label(AddressLine3);
                AddressLine3.DataField = "AddressLine3";
                City = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_SearchResponseCity", "City", locator, null);
                CityLabel = new Label(City);
                City.DataField = "City";
                CountryID = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_SearchResponseCountry", "CountryID", locator, null);
                CountryIDLabel = new Label(CountryID);
                CountryID.DataField = "CountryID";
                State = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_SearchResponseState", "State", locator, null);
                StateLabel = new Label(State);
                State.DataField = "State";
                PostalCode = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_SearchResponsePostalCo" +
                        "de", "PostalCode", locator, null);
                PostalCodeLabel = new Label(PostalCode);
                PostalCode.DataField = "PostalCode";
                Latitude = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_SearchResponseLatitude" +
                        "", "Latitude", locator, null);
                LatitudeLabel = new Label(Latitude);
                Latitude.DataField = "Latitude";
                Longitude = new PXTextEdit("ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress_SearchResponseLongitud" +
                        "e", "Longitude", locator, null);
                LongitudeLabel = new Label(Longitude);
                Longitude.DataField = "Longitude";
                DataMemberName = "AddressLookupFilter";
                Buttons = new PxButtonCollection();
            }

            public virtual void Select()
            {
                Buttons.Select.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Select { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    Select = new Button("ctl00_phG_AddressLookupPanel_AddressLookupSelectAction", "Select", "ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress");
                    Cancel = new Button("ctl00_phG_AddressLookupPanel_AddressEntityBtnCancel", "Cancel", "ctl00_phG_AddressLookupPanel_AddressLookupPanelformAddress");
                }
            }
        }

        public class c_changeiddialog_formchangeid : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit CD { get; }
            public Label CDLabel { get; }

            public c_changeiddialog_formchangeid(string locator, string name) :
                    base(locator, name)
            {
                CD = new PXTextEdit("ctl00_phF_pnlChangeID_formChangeID_edAcctCD", "CD", locator, null);
                CDLabel = new Label(CD);
                CD.DataField = "CD";
                DataMemberName = "ChangeIDDialog";
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
                    Ok = new Button("ctl00_phF_pnlChangeID_btnOK", "OK", "ctl00_phF_pnlChangeID_formChangeID");
                    Cancel = new Button("ctl00_phF_pnlChangeID_btnCancel", "Cancel", "ctl00_phF_pnlChangeID_formChangeID");
                }
            }
        }

        public class c_taxes_grdtaxes : Grid<c_taxes_grdtaxes.c_grid_row, c_taxes_grdtaxes.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_taxes_grdtaxes(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t7_grdTaxes");
                DataMemberName = "Taxes";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t7_grdTaxes_fe_gf", "FilterForm");
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Delete.ConfirmAction = () => Alert.AlertToException("The current {0} record will be deleted.");
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t7_grdTaxes_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public Selector TaxID { get; }
                public PXTextEdit TaxID_Tax_descr { get; }
                public PXTextEdit TaxRegistrationNumber { get; }

                public c_grid_row(c_taxes_grdtaxes grid) :
                        base(grid)
                {
                    TaxID = new Selector("_ctl00_phG_tab_t7_grdTaxes_lv0_edTaxID", "Tax ID", grid.Locator, "TaxID");
                    TaxID.DataField = "TaxID";
                    TaxID_Tax_descr = new PXTextEdit("ctl00_phG_tab_t7_grdTaxes_ei", "Tax ID _ Tax _descr", grid.Locator, "TaxID_Tax_descr");
                    TaxID_Tax_descr.DataField = "TaxID_Tax_descr";
                    TaxRegistrationNumber = new PXTextEdit("ctl00_phG_tab_t7_grdTaxes_ei", "Tax Registration Number", grid.Locator, "TaxRegistrationNumber");
                    TaxRegistrationNumber.DataField = "TaxRegistrationNumber";
                }
            }

            public class c_grid_header : GridHeader
            {

                public SelectorColumnFilter TaxID { get; }
                public PXTextEditColumnFilter TaxID_Tax_descr { get; }
                public PXTextEditColumnFilter TaxRegistrationNumber { get; }

                public c_grid_header(c_taxes_grdtaxes grid) :
                        base(grid)
                {
                    TaxID = new SelectorColumnFilter(grid.Row.TaxID);
                    TaxID_Tax_descr = new PXTextEditColumnFilter(grid.Row.TaxID_Tax_descr);
                    TaxRegistrationNumber = new PXTextEditColumnFilter(grid.Row.TaxRegistrationNumber);
                }
            }
        }

        public class c_taxes_lv0 : Container
        {

            public Selector TaxID { get; }
            public Label TaxIDLabel { get; }

            public c_taxes_lv0(string locator, string name) :
                    base(locator, name)
            {
                TaxID = new Selector("ctl00_phG_tab_t7_grdTaxes_lv0_edTaxID", "Tax ID", locator, null);
                TaxIDLabel = new Label(TaxID);
                TaxID.DataField = "TaxID";
                DataMemberName = "Taxes";
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
