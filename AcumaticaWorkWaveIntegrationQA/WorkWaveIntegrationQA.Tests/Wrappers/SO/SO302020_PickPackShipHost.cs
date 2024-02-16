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
using Core;
using Core.Core.Browser;
using Core.Wait;
using System;


namespace WorkWaveIntegrationQA.Tests.Wrappers
{


    public class SO302020_PickPackShipHost : Wrapper
    {

        public SmartPanel_AttachFile FilesUploadDialog;

        public PxToolBar ToolBar;

        protected c_headerview_formheader HeaderView_formHeader { get; } = new c_headerview_formheader("ctl00_phF_formHeader", "HeaderView_formHeader");
        protected c_headerview_formboxpackage HeaderView_formBoxPackage { get; } = new c_headerview_formboxpackage("ctl00_phG_tab_t3_formBoxPackage", "HeaderView_formBoxPackage");
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
        protected c_currentdocument_formshipinfo CurrentDocument_formShipInfo { get; } = new c_currentdocument_formshipinfo("ctl00_phG_tab_t4_formShipAddress_formShipInfo", "CurrentDocument_formShipInfo");
        protected c_shipping_address_formshipaddress Shipping_Address_formShipAddress { get; } = new c_shipping_address_formshipaddress("ctl00_phG_tab_t4_formShipAddress", "Shipping_Address_formShipAddress");
        protected c_packages_gridpackages Packages_gridPackages { get; } = new c_packages_gridpackages("ctl00_phG_tab_t4_gridPackages", "Packages_gridPackages");
        protected c_packages_lv0 Packages_lv0 { get; } = new c_packages_lv0("ctl00_phG_tab_t4_gridPackages_lv0", "Packages_lv0");
        protected c_shownpackage_formboxinfo ShownPackage_formBoxInfo { get; } = new c_shownpackage_formboxinfo("ctl00_phG_tab_t3_formBoxPackage_formBoxInfo", "ShownPackage_formBoxInfo");
        protected c_pickedforpack_gridpacked PickedForPack_gridPacked { get; } = new c_pickedforpack_gridpacked("ctl00_phG_tab_t3_gridPacked", "PickedForPack_gridPacked");
        protected c_pickedforpack_lv0 PickedForPack_lv0 { get; } = new c_pickedforpack_lv0("ctl00_phG_tab_t3_gridPacked_lv0", "PickedForPack_lv0");
        protected c_packed_gridpackeditems Packed_gridPackedItems { get; } = new c_packed_gridpackeditems("ctl00_phG_tab_t3_gridPackedItems", "Packed_gridPackedItems");
        protected c_packed_lv0 Packed_lv0 { get; } = new c_packed_lv0("ctl00_phG_tab_t3_gridPackedItems_lv0", "Packed_lv0");
        protected c_picked_gridpicked Picked_gridPicked { get; } = new c_picked_gridpicked("ctl00_phG_tab_t1_gridPicked", "Picked_gridPicked");
        protected c_picked_lv0 Picked_lv0 { get; } = new c_picked_lv0("ctl00_phG_tab_t1_gridPicked_lv0", "Picked_lv0");
        protected c_returned_gridreturned Returned_gridReturned { get; } = new c_returned_gridreturned("ctl00_phG_tab_t2_gridReturned", "Returned_gridReturned");
        protected c_returned_lv0 Returned_lv0 { get; } = new c_returned_lv0("ctl00_phG_tab_t2_gridReturned_lv0", "Returned_lv0");
        protected c_carrierrates_gridrates CarrierRates_gridRates { get; } = new c_carrierrates_gridrates("ctl00_phG_tab_t4_gridRates", "CarrierRates_gridRates");
        protected c_carrierrates_lv0 CarrierRates_lv0 { get; } = new c_carrierrates_lv0("ctl00_phG_tab_t4_gridRates_lv0", "CarrierRates_lv0");
        protected c_info_forminfo Info_formInfo { get; } = new c_info_forminfo("ctl00_phF_formInfo", "Info_formInfo");
        protected c_logs_grid4 Logs_grid4 { get; } = new c_logs_grid4("ctl00_phG_tab_t5_grid4", "Logs_grid4");
        protected c_logs_lv0 Logs_lv0 { get; } = new c_logs_lv0("ctl00_phG_tab_t5_grid4_lv0", "Logs_lv0");
        protected c_usersetupview_frmsettings UserSetupView_frmSettings { get; } = new c_usersetupview_frmsettings("ctl00_phG_PanelSettings_frmSettings", "UserSetupView_frmSettings");
        protected c_picklistofpicker_gridpickedws PickListOfPicker_gridPickedWS { get; } = new c_picklistofpicker_gridpickedws("ctl00_phG_tab_t0_gridPickedWS", "PickListOfPicker_gridPickedWS");
        protected c_picklistofpicker_lv0 PickListOfPicker_lv0 { get; } = new c_picklistofpicker_lv0("ctl00_phG_tab_t0_gridPickedWS_lv0", "PickListOfPicker_lv0");
        protected c_filterpreview_formpreview FilterPreview_FormPreview { get; } = new c_filterpreview_formpreview("ctl00_usrCaption_PanelDynamicForm_FormPreview", "FilterPreview_FormPreview");

        public SO302020_PickPackShipHost()
        {
            ScreenId = "SO302020";
            ScreenUrl = "/Pages/SO/SO302020.aspx";
            FilesUploadDialog = new SmartPanel_AttachFile("ctl00_usrCaption_tlbDataView");
            ToolBar = new PxToolBar(null);
        }

        public virtual void SyncTOC()
        {
            ToolBar.SyncTOC.Click();
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

        public virtual void ScanConfirm()
        {
            ToolBar.ScanConfirm.Click();
        }

        public virtual void ScanReset()
        {
            ToolBar.ScanReset.Click();
        }

        public virtual void ClearBtn()
        {
            ToolBar.ClearBtn.Click();
        }

        public virtual void Review()
        {
            ToolBar.Review.Click();
        }

        public virtual void CreateWorkWaveOrder()
        {
            ToolBar.CreateWorkWaveOrder.Click();
        }

        public virtual void CreateWorkWaveOrder(bool status, string message = null)
        {
            ToolBar.CreateWorkWaveOrder.WaitActionOverride = () => Wait.WaitForLongOperationToComplete(status, message);
            ToolBar.CreateWorkWaveOrder.Click();
        }

        public virtual void ReviewPack()
        {
            ToolBar.ReviewPack.Click();
        }

        public virtual void ReviewPick()
        {
            ToolBar.ReviewPick.Click();
        }

        public virtual void ReviewReturn()
        {
            ToolBar.ReviewReturn.Click();
        }

        public virtual void UserSetupDialog()
        {
            ToolBar.UserSetupDialog.Click();
        }

        public virtual void ReviewPickWS()
        {
            ToolBar.ReviewPickWS.Click();
        }

        public virtual void SoordershipmentDisplayshippingrefnoteidLink()
        {
            ToolBar.SoordershipmentDisplayshippingrefnoteidLink.Click();
        }

        public virtual void ScanRemove()
        {
            ToolBar.ScanRemove.Click();
        }

        public virtual void ScanQty()
        {
            ToolBar.ScanQty.Click();
        }

        public virtual void ScanConfirmShipment()
        {
            ToolBar.ScanConfirmShipment.Click();
        }

        public virtual void ScanConfirmPackage()
        {
            ToolBar.ScanConfirmPackage.Click();
        }

        public virtual void ScanRefreshRates()
        {
            ToolBar.ScanRefreshRates.Click();
        }

        public virtual void ScanGetLabels()
        {
            ToolBar.ScanGetLabels.Click();
        }

        public virtual void ScanModeSTORAGE()
        {
            ToolBar.ScanModeSTORAGE.Click();
        }

        public virtual void ScanModeITEM()
        {
            ToolBar.ScanModeITEM.Click();
        }

        public virtual void ScanModeINISSUE()
        {
            ToolBar.ScanModeINISSUE.Click();
        }

        public virtual void ScanModeINRECEIVE()
        {
            ToolBar.ScanModeINRECEIVE.Click();
        }

        public virtual void ScanModeINTRANSFER()
        {
            ToolBar.ScanModeINTRANSFER.Click();
        }

        public virtual void ScanModeCOUNT()
        {
            ToolBar.ScanModeCOUNT.Click();
        }

        public virtual void ScanModeReceive()
        {
            ToolBar.ScanModeReceive.Click();
        }

        public virtual void ScanModePORETURN()
        {
            ToolBar.ScanModePORETURN.Click();
        }

        public virtual void ScanModePutAway()
        {
            ToolBar.ScanModePutAway.Click();
        }

        public virtual void ScanModePick()
        {
            ToolBar.ScanModePick.Click();
        }

        public virtual void ScanModePack()
        {
            ToolBar.ScanModePack.Click();
        }

        public virtual void ScanModeSHIP()
        {
            ToolBar.ScanModeSHIP.Click();
        }

        public virtual void ScanModeSORETURN()
        {
            ToolBar.ScanModeSORETURN.Click();
        }

        public virtual void ScanPackAllIntoBox()
        {
            ToolBar.ScanPackAllIntoBox.Click();
        }

        public virtual void ScanConfirmPickList()
        {
            ToolBar.ScanConfirmPickList.Click();
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
            public ToolBarButton ScanConfirm { get; }
            public ToolBarButton ScanReset { get; }
            public ToolBarButton ClearBtn { get; }
            public ToolBarButton Review { get; }
            public ToolBarButton CreateWorkWaveOrder { get; }
            public ToolBarButton ReviewPack { get; }
            public ToolBarButton ReviewPick { get; }
            public ToolBarButton ReviewReturn { get; }
            public ToolBarButton UserSetupDialog { get; }
            public ToolBarButton ReviewPickWS { get; }
            public ToolBarButton SoordershipmentDisplayshippingrefnoteidLink { get; }
            public ToolBarButton ScanRemove { get; }
            public ToolBarButton ScanQty { get; }
            public ToolBarButton ScanConfirmShipment { get; }
            public ToolBarButton ScanConfirmPackage { get; }
            public ToolBarButton ScanRefreshRates { get; }
            public ToolBarButton ScanGetLabels { get; }
            public ToolBarButton ScanModeSTORAGE { get; }
            public ToolBarButton ScanModeITEM { get; }
            public ToolBarButton ScanModeINISSUE { get; }
            public ToolBarButton ScanModeINRECEIVE { get; }
            public ToolBarButton ScanModeINTRANSFER { get; }
            public ToolBarButton ScanModeCOUNT { get; }
            public ToolBarButton ScanModeReceive { get; }
            public ToolBarButton ScanModePORETURN { get; }
            public ToolBarButton ScanModePutAway { get; }
            public ToolBarButton ScanModePick { get; }
            public ToolBarButton ScanModePack { get; }
            public ToolBarButton ScanModeSHIP { get; }
            public ToolBarButton ScanModeSORETURN { get; }
            public ToolBarButton ScanPackAllIntoBox { get; }
            public ToolBarButton ScanConfirmPickList { get; }
            public ToolBarButton LongRun { get; }
            public ToolBarButton LongrunCancel { get; }
            public ToolBarButton LongrunTimer { get; }

            public PxToolBar(string locator)
            {
                SyncTOC = new ToolBarButton("css=#ctl00_usrCaption_tlbPath div[data-cmd=\'syncTOC\']", "Sync Navigation Pane", locator, null);
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
                Cancel = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_Cancel", "Cancel (Esc)", locator, null);
                Cancel.ConfirmAction = () => Alert.AlertToException("Any unsaved changes will be discarded.");
                ScanConfirm = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanConfirm,#ctl00_phDS_ds_ToolBar_scanConfirm_item", "Scan *OK to confirm", locator, MenuOpener);
                ScanReset = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanReset,#ctl00_phDS_ds_ToolBar_scanReset_item", "Scan *RESET to reset", locator, MenuOpener);
                ClearBtn = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_clearBtn,#ctl00_phDS_ds_ToolBar_clearBtn_item", "Reset", locator, MenuOpener);
                Review = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_review,#ctl00_phDS_ds_ToolBar_review_item", "Review", locator, MenuOpener);
                CreateWorkWaveOrder = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_createWorkWaveOrder,#ctl00_phDS_ds_ToolBar_createWorkW" +
                        "aveOrder_item", "Create WorkWave Order", locator, MenuOpener);
                CreateWorkWaveOrder.WaitAction = Wait.WaitForLongOperationToComplete;
                ReviewPack = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_reviewPack,#ctl00_phDS_ds_ToolBar_reviewPack_item", "Review", locator, MenuOpener);
                ReviewPick = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_reviewPick,#ctl00_phDS_ds_ToolBar_reviewPick_item", "Review", locator, MenuOpener);
                ReviewReturn = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_reviewReturn,#ctl00_phDS_ds_ToolBar_reviewReturn_item", "Review", locator, MenuOpener);
                UserSetupDialog = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_userSetupDialog", "User Settings", locator, null);
                ReviewPickWS = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_reviewPickWS,#ctl00_phDS_ds_ToolBar_reviewPickWS_item", "Review", locator, MenuOpener);
                SoordershipmentDisplayshippingrefnoteidLink = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_SOOrderShipment~DisplayShippingRefNoteID~Link,#ctl00_p" +
                        "hDS_ds_ToolBar_SOOrderShipment~DisplayShippingRefNoteID~Link_item", "SOOrderShipment\r\nDisplayShippingRefNoteID\r\nLink", locator, MenuOpener);
                ScanRemove = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanRemove,#ctl00_phDS_ds_ToolBar_scanRemove_item", "Scan *REMOVE to execute", locator, MenuOpener);
                ScanQty = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanQty,#ctl00_phDS_ds_ToolBar_scanQty_item", "Scan *QTY to execute", locator, MenuOpener);
                ScanConfirmShipment = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanConfirmShipment,#ctl00_phDS_ds_ToolBar_scanConfirm" +
                        "Shipment_item", "Scan *CONFIRM*SHIPMENT to execute", locator, MenuOpener);
                ScanConfirmPackage = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanConfirmPackage,#ctl00_phDS_ds_ToolBar_scanConfirmP" +
                        "ackage_item", "Scan *PACKAGE*CONFIRM to execute", locator, MenuOpener);
                ScanRefreshRates = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanRefreshRates,#ctl00_phDS_ds_ToolBar_scanRefreshRat" +
                        "es_item", "Scan *REFRESH*RATES to execute", locator, MenuOpener);
                ScanGetLabels = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanGetLabels,#ctl00_phDS_ds_ToolBar_scanGetLabels_ite" +
                        "m", "Scan *GET*LABELS to execute", locator, MenuOpener);
                ScanModeSTORAGE = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModeSTORAGE,#ctl00_phDS_ds_ToolBar_scanModeSTORAGE" +
                        "_item", "Scan @STORAGE to change mode", locator, MenuOpener);
                ScanModeITEM = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModeITEM,#ctl00_phDS_ds_ToolBar_scanModeITEM_item", "Scan @ITEM to change mode", locator, MenuOpener);
                ScanModeINISSUE = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModeINISSUE,#ctl00_phDS_ds_ToolBar_scanModeINISSUE" +
                        "_item", "Scan @INISSUE to change mode", locator, MenuOpener);
                ScanModeINRECEIVE = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModeINRECEIVE,#ctl00_phDS_ds_ToolBar_scanModeINREC" +
                        "EIVE_item", "Scan @INRECEIVE to change mode", locator, MenuOpener);
                ScanModeINTRANSFER = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModeINTRANSFER,#ctl00_phDS_ds_ToolBar_scanModeINTR" +
                        "ANSFER_item", "Scan @INTRANSFER to change mode", locator, MenuOpener);
                ScanModeCOUNT = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModeCOUNT,#ctl00_phDS_ds_ToolBar_scanModeCOUNT_ite" +
                        "m", "Scan @COUNT to change mode", locator, MenuOpener);
                ScanModeReceive = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModeReceive,#ctl00_phDS_ds_ToolBar_scanModeReceive" +
                        "_item", "Scan @RECEIVE to change mode", locator, MenuOpener);
                ScanModePORETURN = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModePORETURN,#ctl00_phDS_ds_ToolBar_scanModePORETU" +
                        "RN_item", "Scan @PORETURN to change mode", locator, MenuOpener);
                ScanModePutAway = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModePutAway,#ctl00_phDS_ds_ToolBar_scanModePutAway" +
                        "_item", "Scan @PUTAWAY to change mode", locator, MenuOpener);
                ScanModePick = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModePick,#ctl00_phDS_ds_ToolBar_scanModePick_item", "Scan @PICK to change mode", locator, MenuOpener);
                ScanModePack = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModePack,#ctl00_phDS_ds_ToolBar_scanModePack_item", "Scan @PACK to change mode", locator, MenuOpener);
                ScanModeSHIP = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModeSHIP,#ctl00_phDS_ds_ToolBar_scanModeSHIP_item", "Scan @SHIP to change mode", locator, MenuOpener);
                ScanModeSORETURN = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanModeSORETURN,#ctl00_phDS_ds_ToolBar_scanModeSORETU" +
                        "RN_item", "Scan @SORETURN to change mode", locator, MenuOpener);
                ScanPackAllIntoBox = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanPackAllIntoBox,#ctl00_phDS_ds_ToolBar_scanPackAllI" +
                        "ntoBox_item", "Scan *PACK*ALL*INTO*BOX to execute", locator, MenuOpener);
                ScanConfirmPickList = new ToolBarButton("css=#ctl00_phDS_ds_ToolBar_scanConfirmPickList,#ctl00_phDS_ds_ToolBar_scanConfirm" +
                        "PickList_item", "Scan *CONFIRM*PICK to execute", locator, MenuOpener);
                LongRun = new ToolBarButton("css=qp-long-run", "Nothing in progress", locator, null);
                LongrunCancel = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_cancel", "Cancel", locator, null);
                LongrunTimer = new ToolBarButton("css=#ctl00_phDS_ds_LongRun_timer", "Elapsed Time", locator, null);
            }
        }

        public class c_headerview_formheader : Container
        {

            public PxButtonCollection Buttons;

            public PXTextEdit Barcode { get; }
            public Label BarcodeLabel { get; }
            public Selector RefNbr { get; }
            public Label RefNbrLabel { get; }
            public Selector WorksheetNbr { get; }
            public Label WorksheetNbrLabel { get; }
            public Selector SingleShipmentNbr { get; }
            public Label SingleShipmentNbrLabel { get; }
            public Selector LastVisitedLocationID { get; }
            public Label LastVisitedLocationIDLabel { get; }
            public Selector CartID { get; }
            public Label CartIDLabel { get; }
            public CheckBox ProcessingSucceeded { get; }
            public Label ProcessingSucceededLabel { get; }
            public PXTextEdit Message { get; }
            public Label MessageLabel { get; }
            public CheckBox Remove { get; }
            public Label RemoveLabel { get; }
            public CheckBox CartLoaded { get; }
            public Label CartLoadedLabel { get; }
            public CheckBox ShowPickWS { get; }
            public Label ShowPickWSLabel { get; }
            public CheckBox ShowPick { get; }
            public Label ShowPickLabel { get; }
            public CheckBox ShowPack { get; }
            public Label ShowPackLabel { get; }
            public CheckBox ShowShip { get; }
            public Label ShowShipLabel { get; }
            public CheckBox ShowReturn { get; }
            public Label ShowReturnLabel { get; }
            public CheckBox ShowLog { get; }
            public Label ShowLogLabel { get; }

            public c_headerview_formheader(string locator, string name) :
                    base(locator, name)
            {
                Barcode = new PXTextEdit("ctl00_phF_formHeader_edBarcode", "Scan", locator, null);
                BarcodeLabel = new Label(Barcode);
                Barcode.DataField = "Barcode";
                RefNbr = new Selector("ctl00_phF_formHeader_edRefNbr", "Shipment Nbr.", locator, null);
                RefNbrLabel = new Label(RefNbr);
                RefNbr.DataField = "RefNbr";
                WorksheetNbr = new Selector("ctl00_phF_formHeader_edWSNbr", "Worksheet Nbr.", locator, null);
                WorksheetNbrLabel = new Label(WorksheetNbr);
                WorksheetNbr.DataField = "WorksheetNbr";
                SingleShipmentNbr = new Selector("ctl00_phF_formHeader_edSingleShipmentNbr", "Shipment Nbr.", locator, null);
                SingleShipmentNbrLabel = new Label(SingleShipmentNbr);
                SingleShipmentNbr.DataField = "SingleShipmentNbr";
                LastVisitedLocationID = new Selector("ctl00_phF_formHeader_edCurrentLocationID", "Current Location", locator, null);
                LastVisitedLocationIDLabel = new Label(LastVisitedLocationID);
                LastVisitedLocationID.DataField = "LastVisitedLocationID";
                CartID = new Selector("ctl00_phF_formHeader_edCartID", "Cart ID", locator, null);
                CartIDLabel = new Label(CartID);
                CartID.DataField = "CartID";
                ProcessingSucceeded = new CheckBox("ctl00_phF_formHeader_chkStatusIcon", "Processing Succeeded", locator, null);
                ProcessingSucceededLabel = new Label(ProcessingSucceeded);
                ProcessingSucceeded.DataField = "ProcessingSucceeded";
                Message = new PXTextEdit("ctl00_phF_formHeader_edMessage", "Message", locator, null);
                MessageLabel = new Label(Message);
                Message.DataField = "Message";
                Remove = new CheckBox("ctl00_phF_formHeader_chkRemove", "Remove Mode", locator, null);
                RemoveLabel = new Label(Remove);
                Remove.DataField = "Remove";
                CartLoaded = new CheckBox("ctl00_phF_formHeader_chkCartLoaded", "Cart Unloading", locator, null);
                CartLoadedLabel = new Label(CartLoaded);
                CartLoaded.DataField = "CartLoaded";
                ShowPickWS = new CheckBox("ctl00_phF_formHeader_chkShowPickWS", "ShowPickWS", locator, null);
                ShowPickWSLabel = new Label(ShowPickWS);
                ShowPickWS.DataField = "ShowPickWS";
                ShowPick = new CheckBox("ctl00_phF_formHeader_chkShowPick", "ShowPick", locator, null);
                ShowPickLabel = new Label(ShowPick);
                ShowPick.DataField = "ShowPick";
                ShowPack = new CheckBox("ctl00_phF_formHeader_chkShowPack", "ShowPack", locator, null);
                ShowPackLabel = new Label(ShowPack);
                ShowPack.DataField = "ShowPack";
                ShowShip = new CheckBox("ctl00_phF_formHeader_chkShowShip", "ShowShip", locator, null);
                ShowShipLabel = new Label(ShowShip);
                ShowShip.DataField = "ShowShip";
                ShowReturn = new CheckBox("ctl00_phF_formHeader_chkShowReturn", "ShowReturn", locator, null);
                ShowReturnLabel = new Label(ShowReturn);
                ShowReturn.DataField = "ShowReturn";
                ShowLog = new CheckBox("ctl00_phF_formHeader_chkShowLog", "ShowLog", locator, null);
                ShowLogLabel = new Label(ShowLog);
                ShowLog.DataField = "ShowLog";
                DataMemberName = "HeaderView";
                Buttons = new PxButtonCollection();
            }

            public virtual void RefNbrEdit()
            {
                Buttons.RefNbrEdit.Click();
            }

            public virtual void WorksheetNbrEdit()
            {
                Buttons.WorksheetNbrEdit.Click();
            }

            public virtual void SingleShipmentNbrEdit()
            {
                Buttons.SingleShipmentNbrEdit.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button RefNbrEdit { get; }
                public Button WorksheetNbrEdit { get; }
                public Button SingleShipmentNbrEdit { get; }

                public PxButtonCollection()
                {
                    RefNbrEdit = new Button("css=div[id=\'ctl00_phF_formHeader_edRefNbr\'] div[class=\'editBtnCont\'] > div > div", "RefNbrEdit", "ctl00_phF_formHeader");
                    RefNbrEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    WorksheetNbrEdit = new Button("css=div[id=\'ctl00_phF_formHeader_edWSNbr\'] div[class=\'editBtnCont\'] > div > div", "WorksheetNbrEdit", "ctl00_phF_formHeader");
                    WorksheetNbrEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                    SingleShipmentNbrEdit = new Button("css=div[id=\'ctl00_phF_formHeader_edSingleShipmentNbr\'] div[class=\'editBtnCont\'] >" +
                            " div > div", "SingleShipmentNbrEdit", "ctl00_phF_formHeader");
                    SingleShipmentNbrEdit.WaitAction = Wait.WaitForNewWindowToOpen;
                }
            }
        }

        public class c_headerview_formboxpackage : Container
        {

            public PxButtonCollection Buttons;

            public Selector PackageLineNbrUI { get; }
            public Label PackageLineNbrUILabel { get; }

            public c_headerview_formboxpackage(string locator, string name) :
                    base(locator, name)
            {
                PackageLineNbrUI = new Selector("ctl00_phG_tab_t3_formBoxPackage_edPackage", "Package", locator, null);
                PackageLineNbrUILabel = new Label(PackageLineNbrUI);
                PackageLineNbrUI.DataField = "PackageLineNbrUI";
                DataMemberName = "HeaderView";
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

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t3_gridPackedItems_lfFirst0", "First", "ctl00_phG_tab_t3_formBoxPackage");
                    Prev = new Button("ctl00_phG_tab_t3_gridPackedItems_lfPrev0", "Prev", "ctl00_phG_tab_t3_formBoxPackage");
                    Next = new Button("ctl00_phG_tab_t3_gridPackedItems_lfNext0", "Next", "ctl00_phG_tab_t3_formBoxPackage");
                    Last = new Button("ctl00_phG_tab_t3_gridPackedItems_lfLast0", "Last", "ctl00_phG_tab_t3_formBoxPackage");
                }
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

        public class c_currentdocument_formshipinfo : Container
        {

            public PxButtonCollection Buttons;

            public PXNumberEdit ShipmentQty { get; }
            public Label ShipmentQtyLabel { get; }
            public PXNumberEdit ShipmentWeight { get; }
            public Label ShipmentWeightLabel { get; }
            public PXNumberEdit ShipmentVolume { get; }
            public Label ShipmentVolumeLabel { get; }
            public PXNumberEdit PackageCount { get; }
            public Label PackageCountLabel { get; }
            public PXNumberEdit PackageWeight { get; }
            public Label PackageWeightLabel { get; }

            public c_currentdocument_formshipinfo(string locator, string name) :
                    base(locator, name)
            {
                ShipmentQty = new PXNumberEdit("ctl00_phG_tab_t4_formShipAddress_formShipInfo_edShipmentQty", "Shipped Quantity", locator, null);
                ShipmentQtyLabel = new Label(ShipmentQty);
                ShipmentQty.DataField = "ShipmentQty";
                ShipmentWeight = new PXNumberEdit("ctl00_phG_tab_t4_formShipAddress_formShipInfo_edShipmentWeight", "Shipped Weight", locator, null);
                ShipmentWeightLabel = new Label(ShipmentWeight);
                ShipmentWeight.DataField = "ShipmentWeight";
                ShipmentVolume = new PXNumberEdit("ctl00_phG_tab_t4_formShipAddress_formShipInfo_edShipmentVolume", "Shipped Volume", locator, null);
                ShipmentVolumeLabel = new Label(ShipmentVolume);
                ShipmentVolume.DataField = "ShipmentVolume";
                PackageCount = new PXNumberEdit("ctl00_phG_tab_t4_formShipAddress_formShipInfo_edPackageCount", "Packages", locator, null);
                PackageCountLabel = new Label(PackageCount);
                PackageCount.DataField = "PackageCount";
                PackageWeight = new PXNumberEdit("ctl00_phG_tab_t4_formShipAddress_formShipInfo_edPackageWeight", "Package Weight", locator, null);
                PackageWeightLabel = new Label(PackageWeight);
                PackageWeight.DataField = "PackageWeight";
                DataMemberName = "CurrentDocument";
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

            public virtual void First1()
            {
                Buttons.First1.Click();
            }

            public virtual void Prev1()
            {
                Buttons.Prev1.Click();
            }

            public virtual void Next1()
            {
                Buttons.Next1.Click();
            }

            public virtual void Last1()
            {
                Buttons.Last1.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button First1 { get; }
                public Button Prev1 { get; }
                public Button Next1 { get; }
                public Button Last1 { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t4_gridRates_lfFirst0", "First", "ctl00_phG_tab_t4_formShipAddress_formShipInfo");
                    Prev = new Button("ctl00_phG_tab_t4_gridRates_lfPrev0", "Prev", "ctl00_phG_tab_t4_formShipAddress_formShipInfo");
                    Next = new Button("ctl00_phG_tab_t4_gridRates_lfNext0", "Next", "ctl00_phG_tab_t4_formShipAddress_formShipInfo");
                    Last = new Button("ctl00_phG_tab_t4_gridRates_lfLast0", "Last", "ctl00_phG_tab_t4_formShipAddress_formShipInfo");
                    First1 = new Button("ctl00_phG_tab_t4_gridPackages_lfFirst0", "First", "ctl00_phG_tab_t4_formShipAddress_formShipInfo");
                    Prev1 = new Button("ctl00_phG_tab_t4_gridPackages_lfPrev0", "Prev", "ctl00_phG_tab_t4_formShipAddress_formShipInfo");
                    Next1 = new Button("ctl00_phG_tab_t4_gridPackages_lfNext0", "Next", "ctl00_phG_tab_t4_formShipAddress_formShipInfo");
                    Last1 = new Button("ctl00_phG_tab_t4_gridPackages_lfLast0", "Last", "ctl00_phG_tab_t4_formShipAddress_formShipInfo");
                }
            }
        }

        public class c_shipping_address_formshipaddress : Container
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

            public c_shipping_address_formshipaddress(string locator, string name) :
                    base(locator, name)
            {
                AddressLine1 = new PXTextEdit("ctl00_phG_tab_t4_formShipAddress_edAddressLine1", "Address Line 1", locator, null);
                AddressLine1Label = new Label(AddressLine1);
                AddressLine1.DataField = "AddressLine1";
                AddressLine2 = new PXTextEdit("ctl00_phG_tab_t4_formShipAddress_edAddressLine2", "Address Line 2", locator, null);
                AddressLine2Label = new Label(AddressLine2);
                AddressLine2.DataField = "AddressLine2";
                City = new PXTextEdit("ctl00_phG_tab_t4_formShipAddress_edCity", "City", locator, null);
                CityLabel = new Label(City);
                City.DataField = "City";
                CountryID = new Selector("ctl00_phG_tab_t4_formShipAddress_edCountryID", "Country", locator, null);
                CountryIDLabel = new Label(CountryID);
                CountryID.DataField = "CountryID";
                State = new Selector("ctl00_phG_tab_t4_formShipAddress_edState", "State", locator, null);
                StateLabel = new Label(State);
                State.DataField = "State";
                PostalCode = new PXTextEdit("ctl00_phG_tab_t4_formShipAddress_edPostalCode", "Postal Code", locator, null);
                PostalCodeLabel = new Label(PostalCode);
                PostalCode.DataField = "PostalCode";
                DataMemberName = "Shipping_Address";
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

            public virtual void First1()
            {
                Buttons.First1.Click();
            }

            public virtual void Prev1()
            {
                Buttons.Prev1.Click();
            }

            public virtual void Next1()
            {
                Buttons.Next1.Click();
            }

            public virtual void Last1()
            {
                Buttons.Last1.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button First1 { get; }
                public Button Prev1 { get; }
                public Button Next1 { get; }
                public Button Last1 { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t4_gridRates_lfFirst0", "First", "ctl00_phG_tab_t4_formShipAddress");
                    Prev = new Button("ctl00_phG_tab_t4_gridRates_lfPrev0", "Prev", "ctl00_phG_tab_t4_formShipAddress");
                    Next = new Button("ctl00_phG_tab_t4_gridRates_lfNext0", "Next", "ctl00_phG_tab_t4_formShipAddress");
                    Last = new Button("ctl00_phG_tab_t4_gridRates_lfLast0", "Last", "ctl00_phG_tab_t4_formShipAddress");
                    First1 = new Button("ctl00_phG_tab_t4_gridPackages_lfFirst0", "First", "ctl00_phG_tab_t4_formShipAddress");
                    Prev1 = new Button("ctl00_phG_tab_t4_gridPackages_lfPrev0", "Prev", "ctl00_phG_tab_t4_formShipAddress");
                    Next1 = new Button("ctl00_phG_tab_t4_gridPackages_lfNext0", "Next", "ctl00_phG_tab_t4_formShipAddress");
                    Last1 = new Button("ctl00_phG_tab_t4_gridPackages_lfLast0", "Last", "ctl00_phG_tab_t4_formShipAddress");
                }
            }
        }

        public class c_packages_gridpackages : Grid<c_packages_gridpackages.c_grid_row, c_packages_gridpackages.c_grid_header>
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            public c_grid_filter FilterForm { get; }
            public SmartPanel_AttachFile FilesUploadDialog { get; }
            public Note NotePanel { get; }

            public c_packages_gridpackages(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t4_gridPackages");
                DataMemberName = "Packages";
                Buttons = new PxButtonCollection();
                FilterForm = new c_grid_filter("ctl00_phG_tab_t4_gridPackages_fe_gf", "FilterForm");
                FilesUploadDialog = new SmartPanel_AttachFile(locator);
                NotePanel = new Note(locator);
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

            public virtual void Hi1()
            {
                ToolBar.Hi1.Click();
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

            public virtual void First1()
            {
                Buttons.First1.Click();
            }

            public virtual void Prev1()
            {
                Buttons.Prev1.Click();
            }

            public virtual void Next1()
            {
                Buttons.Next1.Click();
            }

            public virtual void Last1()
            {
                Buttons.Last1.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid New { get; }
                public ToolBarButtonGrid Delete { get; }
                public ToolBarButtonGrid Adjust { get; }
                public ToolBarButtonGrid Export { get; }
                public ToolBarButtonGrid Hi { get; }
                public ToolBarButtonGrid Hi1 { get; }

                public PxToolBar(string locator)
                {
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridPackages_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridPackages_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridPackages_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Delete.ConfirmAction = () => Alert.AlertToException("The current {0} record will be deleted.");
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridPackages_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridPackages_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridPackages_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridPackages_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button First1 { get; }
                public Button Prev1 { get; }
                public Button Next1 { get; }
                public Button Last1 { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t4_gridRates_lfFirst0", "First", "ctl00_phG_tab_t4_gridPackages");
                    Prev = new Button("ctl00_phG_tab_t4_gridRates_lfPrev0", "Prev", "ctl00_phG_tab_t4_gridPackages");
                    Next = new Button("ctl00_phG_tab_t4_gridRates_lfNext0", "Next", "ctl00_phG_tab_t4_gridPackages");
                    Last = new Button("ctl00_phG_tab_t4_gridRates_lfLast0", "Last", "ctl00_phG_tab_t4_gridPackages");
                    First1 = new Button("ctl00_phG_tab_t4_gridPackages_lfFirst0", "First", "ctl00_phG_tab_t4_gridPackages");
                    Prev1 = new Button("ctl00_phG_tab_t4_gridPackages_lfPrev0", "Prev", "ctl00_phG_tab_t4_gridPackages");
                    Next1 = new Button("ctl00_phG_tab_t4_gridPackages_lfNext0", "Next", "ctl00_phG_tab_t4_gridPackages");
                    Last1 = new Button("ctl00_phG_tab_t4_gridPackages_lfLast0", "Last", "ctl00_phG_tab_t4_gridPackages");
                }
            }

            public class c_grid_row : GridRow
            {

                public FileColumnButton Files { get; }
                public NoteColumnButton Notes { get; }
                public Selector BoxID { get; }
                public PXTextEdit Description { get; }
                public PXTextEdit WeightUOM { get; }
                public PXNumberEdit Weight { get; }
                public PXNumberEdit BoxWeight { get; }
                public PXNumberEdit NetWeight { get; }
                public PXNumberEdit MaxWeight { get; }
                public PXNumberEdit DeclaredValue { get; }
                public PXNumberEdit COD { get; }
                public PXTextEdit TrackNumber { get; }
                public DropDown StampsAddOns { get; }
                public PXTextEdit ShipmentNbr { get; }
                public PXNumberEdit LineNbr { get; }

                public c_grid_row(c_packages_gridpackages grid) :
                        base(grid)
                {
                    Files = new FileColumnButton(null, "Files", grid.Locator, "Files");
                    Notes = new NoteColumnButton(null, "Notes", grid.Locator, "Notes");
                    BoxID = new Selector("_ctl00_phG_tab_t4_gridPackages_lv0_es", "Box ID", grid.Locator, "BoxID");
                    BoxID.DataField = "BoxID";
                    Description = new PXTextEdit("ctl00_phG_tab_t4_gridPackages_ei", "Description", grid.Locator, "Description");
                    Description.DataField = "Description";
                    WeightUOM = new PXTextEdit("ctl00_phG_tab_t4_gridPackages_ei", "UOM", grid.Locator, "WeightUOM");
                    WeightUOM.DataField = "WeightUOM";
                    Weight = new PXNumberEdit("ctl00_phG_tab_t4_gridPackages_en", "Weight", grid.Locator, "Weight");
                    Weight.DataField = "Weight";
                    BoxWeight = new PXNumberEdit("ctl00_phG_tab_t4_gridPackages_en", "Box Weight", grid.Locator, "BoxWeight");
                    BoxWeight.DataField = "BoxWeight";
                    NetWeight = new PXNumberEdit("ctl00_phG_tab_t4_gridPackages_en", "Net Weight", grid.Locator, "NetWeight");
                    NetWeight.DataField = "NetWeight";
                    MaxWeight = new PXNumberEdit("ctl00_phG_tab_t4_gridPackages_en", "Max Weight", grid.Locator, "MaxWeight");
                    MaxWeight.DataField = "MaxWeight";
                    DeclaredValue = new PXNumberEdit("ctl00_phG_tab_t4_gridPackages_en", "Declared Value", grid.Locator, "DeclaredValue");
                    DeclaredValue.DataField = "DeclaredValue";
                    COD = new PXNumberEdit("ctl00_phG_tab_t4_gridPackages_en", "C.O.D. Amount", grid.Locator, "COD");
                    COD.DataField = "COD";
                    TrackNumber = new PXTextEdit("ctl00_phG_tab_t4_gridPackages_ei", "Tracking Number", grid.Locator, "TrackNumber");
                    TrackNumber.DataField = "TrackNumber";
                    StampsAddOns = new DropDown("_ctl00_phG_tab_t4_gridPackages_lv0_edStampsAddOns", "Stamps Surcharges", grid.Locator, "StampsAddOns");
                    StampsAddOns.DataField = "StampsAddOns";
                    StampsAddOns.Items.Add("USARD", "USPS Restricted Delivery");
                    StampsAddOns.Items.Add("USAESH", "Priority Mail Express delivery on a Sunday/holiday");
                    StampsAddOns.Items.Add("USANDW", "Priority Mail Express no delivery on Saturday");
                    StampsAddOns.Items.Add("USANND", "USPS notice of non-delivery");
                    StampsAddOns.Items.Add("USALAWS", "Mailable Live Animals with charge");
                    StampsAddOns.Items.Add("USASH", "Fragile items");
                    StampsAddOns.Items.Add("USA1030", "Deliver by 10:30 AM");
                    StampsAddOns.Items.Add("SCAHP", "Hidden Postage");
                    ShipmentNbr = new PXTextEdit("ctl00_phG_tab_t4_gridPackages_em", "Shipment Nbr.", grid.Locator, "ShipmentNbr");
                    ShipmentNbr.DataField = "ShipmentNbr";
                    LineNbr = new PXNumberEdit("ctl00_phG_tab_t4_gridPackages_en", "Line Nbr.", grid.Locator, "LineNbr");
                    LineNbr.DataField = "LineNbr";
                }
            }

            public class c_grid_header : GridHeader
            {

                public GridColumnHeader Files { get; }
                public GridColumnHeader Notes { get; }
                public SelectorColumnFilter BoxID { get; }
                public PXTextEditColumnFilter Description { get; }
                public PXTextEditColumnFilter WeightUOM { get; }
                public PXNumberEditColumnFilter Weight { get; }
                public PXNumberEditColumnFilter BoxWeight { get; }
                public PXNumberEditColumnFilter NetWeight { get; }
                public PXNumberEditColumnFilter MaxWeight { get; }
                public PXNumberEditColumnFilter DeclaredValue { get; }
                public PXNumberEditColumnFilter COD { get; }
                public PXTextEditColumnFilter TrackNumber { get; }
                public DropDownColumnFilter StampsAddOns { get; }
                public PXTextEditColumnFilter ShipmentNbr { get; }
                public PXNumberEditColumnFilter LineNbr { get; }

                public c_grid_header(c_packages_gridpackages grid) :
                        base(grid)
                {
                    Files = new GridColumnHeader(grid.Row.Files);
                    Notes = new GridColumnHeader(grid.Row.Notes);
                    BoxID = new SelectorColumnFilter(grid.Row.BoxID);
                    Description = new PXTextEditColumnFilter(grid.Row.Description);
                    WeightUOM = new PXTextEditColumnFilter(grid.Row.WeightUOM);
                    Weight = new PXNumberEditColumnFilter(grid.Row.Weight);
                    BoxWeight = new PXNumberEditColumnFilter(grid.Row.BoxWeight);
                    NetWeight = new PXNumberEditColumnFilter(grid.Row.NetWeight);
                    MaxWeight = new PXNumberEditColumnFilter(grid.Row.MaxWeight);
                    DeclaredValue = new PXNumberEditColumnFilter(grid.Row.DeclaredValue);
                    COD = new PXNumberEditColumnFilter(grid.Row.COD);
                    TrackNumber = new PXTextEditColumnFilter(grid.Row.TrackNumber);
                    StampsAddOns = new DropDownColumnFilter(grid.Row.StampsAddOns);
                    ShipmentNbr = new PXTextEditColumnFilter(grid.Row.ShipmentNbr);
                    LineNbr = new PXNumberEditColumnFilter(grid.Row.LineNbr);
                }
            }
        }

        public class c_packages_lv0 : Container
        {

            public PxButtonCollection Buttons;

            public DropDown StampsAddOns { get; }
            public Label StampsAddOnsLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }

            public c_packages_lv0(string locator, string name) :
                    base(locator, name)
            {
                StampsAddOns = new DropDown("ctl00_phG_tab_t4_gridPackages_lv0_edStampsAddOns", "Stamps Surcharges", locator, null);
                StampsAddOnsLabel = new Label(StampsAddOns);
                StampsAddOns.DataField = "StampsAddOns";
                StampsAddOns.Items.Add("USARD", "USPS Restricted Delivery");
                StampsAddOns.Items.Add("USAESH", "Priority Mail Express delivery on a Sunday/holiday");
                StampsAddOns.Items.Add("USANDW", "Priority Mail Express no delivery on Saturday");
                StampsAddOns.Items.Add("USANND", "USPS notice of non-delivery");
                StampsAddOns.Items.Add("USALAWS", "Mailable Live Animals with charge");
                StampsAddOns.Items.Add("USASH", "Fragile items");
                StampsAddOns.Items.Add("USA1030", "Deliver by 10:30 AM");
                StampsAddOns.Items.Add("SCAHP", "Hidden Postage");
                Es = new Selector("ctl00_phG_tab_t4_gridPackages_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                DataMemberName = "Packages";
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

            public virtual void First1()
            {
                Buttons.First1.Click();
            }

            public virtual void Prev1()
            {
                Buttons.Prev1.Click();
            }

            public virtual void Next1()
            {
                Buttons.Next1.Click();
            }

            public virtual void Last1()
            {
                Buttons.Last1.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button First1 { get; }
                public Button Prev1 { get; }
                public Button Next1 { get; }
                public Button Last1 { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t4_gridRates_lfFirst0", "First", "ctl00_phG_tab_t4_gridPackages_lv0");
                    Prev = new Button("ctl00_phG_tab_t4_gridRates_lfPrev0", "Prev", "ctl00_phG_tab_t4_gridPackages_lv0");
                    Next = new Button("ctl00_phG_tab_t4_gridRates_lfNext0", "Next", "ctl00_phG_tab_t4_gridPackages_lv0");
                    Last = new Button("ctl00_phG_tab_t4_gridRates_lfLast0", "Last", "ctl00_phG_tab_t4_gridPackages_lv0");
                    First1 = new Button("ctl00_phG_tab_t4_gridPackages_lfFirst0", "First", "ctl00_phG_tab_t4_gridPackages_lv0");
                    Prev1 = new Button("ctl00_phG_tab_t4_gridPackages_lfPrev0", "Prev", "ctl00_phG_tab_t4_gridPackages_lv0");
                    Next1 = new Button("ctl00_phG_tab_t4_gridPackages_lfNext0", "Next", "ctl00_phG_tab_t4_gridPackages_lv0");
                    Last1 = new Button("ctl00_phG_tab_t4_gridPackages_lfLast0", "Last", "ctl00_phG_tab_t4_gridPackages_lv0");
                }
            }
        }

        public class c_shownpackage_formboxinfo : Container
        {

            public PxButtonCollection Buttons;

            public PXNumberEdit Weight { get; }
            public Label WeightLabel { get; }
            public PXNumberEdit MaxWeight { get; }
            public Label MaxWeightLabel { get; }
            public PXTextEdit WeightUOM { get; }
            public Label WeightUOMLabel { get; }
            public CheckBox Confirmed { get; }
            public Label ConfirmedLabel { get; }

            public c_shownpackage_formboxinfo(string locator, string name) :
                    base(locator, name)
            {
                Weight = new PXNumberEdit("ctl00_phG_tab_t3_formBoxPackage_formBoxInfo_edPackageWeight", "Weight", locator, null);
                WeightLabel = new Label(Weight);
                Weight.DataField = "Weight";
                MaxWeight = new PXNumberEdit("ctl00_phG_tab_t3_formBoxPackage_formBoxInfo_edBoxMaxWeight", "Max Weight", locator, null);
                MaxWeightLabel = new Label(MaxWeight);
                MaxWeight.DataField = "MaxWeight";
                WeightUOM = new PXTextEdit("ctl00_phG_tab_t3_formBoxPackage_formBoxInfo_edWeightUOM", "UOM", locator, null);
                WeightUOMLabel = new Label(WeightUOM);
                WeightUOM.DataField = "WeightUOM";
                Confirmed = new CheckBox("ctl00_phG_tab_t3_formBoxPackage_formBoxInfo_chPackageConfirmed", "Confirmed", locator, null);
                ConfirmedLabel = new Label(Confirmed);
                Confirmed.DataField = "Confirmed";
                DataMemberName = "ShownPackage";
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

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t3_gridPackedItems_lfFirst0", "First", "ctl00_phG_tab_t3_formBoxPackage_formBoxInfo");
                    Prev = new Button("ctl00_phG_tab_t3_gridPackedItems_lfPrev0", "Prev", "ctl00_phG_tab_t3_formBoxPackage_formBoxInfo");
                    Next = new Button("ctl00_phG_tab_t3_gridPackedItems_lfNext0", "Next", "ctl00_phG_tab_t3_formBoxPackage_formBoxInfo");
                    Last = new Button("ctl00_phG_tab_t3_gridPackedItems_lfLast0", "Last", "ctl00_phG_tab_t3_formBoxPackage_formBoxInfo");
                }
            }
        }

        public class c_pickedforpack_gridpacked : Grid<c_pickedforpack_gridpacked.c_grid_row, c_pickedforpack_gridpacked.c_grid_header>
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            public c_grid_filter FilterForm { get; }

            public c_pickedforpack_gridpacked(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t3_gridPacked");
                DataMemberName = "PickedForPack";
                Buttons = new PxButtonCollection();
                FilterForm = new c_grid_filter("ctl00_phG_tab_t3_gridPacked_fe_gf", "FilterForm");
            }

            public virtual void Refresh()
            {
                ToolBar.Refresh.Click();
            }

            public virtual void ReopenLineQty()
            {
                ToolBar.ReopenLineQty.Click();
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

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid ReopenLineQty { get; }
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    ReopenLineQty = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_at_tlb div[data-cmd=\'ReopenLineQty\']", "Proceed Picking", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPacked_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t3_gridPackedItems_lfFirst0", "First", "ctl00_phG_tab_t3_gridPacked");
                    Prev = new Button("ctl00_phG_tab_t3_gridPackedItems_lfPrev0", "Prev", "ctl00_phG_tab_t3_gridPacked");
                    Next = new Button("ctl00_phG_tab_t3_gridPackedItems_lfNext0", "Next", "ctl00_phG_tab_t3_gridPacked");
                    Last = new Button("ctl00_phG_tab_t3_gridPackedItems_lfLast0", "Last", "ctl00_phG_tab_t3_gridPacked");
                }
            }

            public class c_grid_row : GridRow
            {

                public CheckBox Fits { get; }
                public PXNumberEdit LineNbr { get; }
                public PXTextEdit SOShipLine__OrigOrderType { get; }
                public Selector SOShipLine__OrigOrderNbr { get; }
                public Selector SiteID { get; }
                public Selector LocationID { get; }
                public Selector InventoryID { get; }
                public PXTextEdit SOShipLine__TranDesc { get; }
                public PXTextEdit LotSerialNbr { get; }
                public DateSelector ExpireDate { get; }
                public PXNumberEdit CartQty { get; }
                public PXNumberEdit OverAllCartQty { get; }
                public PXNumberEdit PickedQty { get; }
                public PXNumberEdit PackedQty { get; }
                public PXNumberEdit Qty { get; }
                public Selector UOM { get; }
                public CheckBox SOShipLine__IsFree { get; }
                public CheckBox RelatedPickListSplitForceCompleted { get; }
                public PXTextEdit ShipmentNbr { get; }
                public PXNumberEdit SplitLineNbr { get; }

                public c_grid_row(c_pickedforpack_gridpacked grid) :
                        base(grid)
                {
                    Fits = new CheckBox("ctl00_phG_tab_t3_gridPacked", "Matched", grid.Locator, "Fits");
                    Fits.DataField = "Fits";
                    LineNbr = new PXNumberEdit("_ctl00_phG_tab_t3_gridPacked_lv0_edPackLineNbr", "Line Nbr.", grid.Locator, "LineNbr");
                    LineNbr.DataField = "LineNbr";
                    SOShipLine__OrigOrderType = new PXTextEdit("_ctl00_phG_tab_t3_gridPacked_lv0_edPackOrigOrderType", "Order Type", grid.Locator, "SOShipLine__OrigOrderType");
                    SOShipLine__OrigOrderType.DataField = "SOShipLine__OrigOrderType";
                    SOShipLine__OrigOrderNbr = new Selector("_ctl00_phG_tab_t3_gridPacked_lv0_edPackOrigOrderNbr", "Order Nbr.", grid.Locator, "SOShipLine__OrigOrderNbr");
                    SOShipLine__OrigOrderNbr.DataField = "SOShipLine__OrigOrderNbr";
                    SiteID = new Selector("_ctl00_phG_tab_t3_gridPacked_lv0_edPackSiteID", "Warehouse", grid.Locator, "SiteID");
                    SiteID.DataField = "SiteID";
                    LocationID = new Selector("_ctl00_phG_tab_t3_gridPacked_lv0_edPackLocationID", "Location", grid.Locator, "LocationID");
                    LocationID.DataField = "LocationID";
                    InventoryID = new Selector("_ctl00_phG_tab_t3_gridPacked_lv0_edPackInventoryID", "Inventory ID", grid.Locator, "InventoryID");
                    InventoryID.DataField = "InventoryID";
                    SOShipLine__TranDesc = new PXTextEdit("ctl00_phG_tab_t3_gridPacked_ei", "Description", grid.Locator, "SOShipLine__TranDesc");
                    SOShipLine__TranDesc.DataField = "SOShipLine__TranDesc";
                    LotSerialNbr = new PXTextEdit("_ctl00_phG_tab_t3_gridPacked_lv0_edPackLotSerialNbr", "Lot/Serial Nbr.", grid.Locator, "LotSerialNbr");
                    LotSerialNbr.DataField = "LotSerialNbr";
                    ExpireDate = new DateSelector("_ctl00_phG_tab_t3_gridPacked_lv0_edPackExpireDate", "Expiration Date", grid.Locator, "ExpireDate");
                    ExpireDate.DataField = "ExpireDate";
                    CartQty = new PXNumberEdit("ctl00_phG_tab_t3_gridPacked_en", "Cart Qty.", grid.Locator, "CartQty");
                    CartQty.DataField = "CartQty";
                    OverAllCartQty = new PXNumberEdit("ctl00_phG_tab_t3_gridPacked_en", "Overall Cart Qty.", grid.Locator, "OverAllCartQty");
                    OverAllCartQty.DataField = "OverAllCartQty";
                    PickedQty = new PXNumberEdit("_ctl00_phG_tab_t3_gridPacked_lv0_PXPackPickedQty", "Picked Quantity", grid.Locator, "PickedQty");
                    PickedQty.DataField = "PickedQty";
                    PackedQty = new PXNumberEdit("_ctl00_phG_tab_t3_gridPacked_lv0_PXPackPackedQty", "Packed Quantity", grid.Locator, "PackedQty");
                    PackedQty.DataField = "PackedQty";
                    Qty = new PXNumberEdit("_ctl00_phG_tab_t3_gridPacked_lv0_PXPackQty", "Quantity", grid.Locator, "Qty");
                    Qty.DataField = "Qty";
                    UOM = new Selector("_ctl00_phG_tab_t3_gridPacked_lv0_edPackUOM", "UOM", grid.Locator, "UOM");
                    UOM.DataField = "UOM";
                    SOShipLine__IsFree = new CheckBox("_ctl00_phG_tab_t3_gridPacked_lv0_chkPackIsFree", "Free Item", grid.Locator, "SOShipLine__IsFree");
                    SOShipLine__IsFree.DataField = "SOShipLine__IsFree";
                    RelatedPickListSplitForceCompleted = new CheckBox("ctl00_phG_tab_t3_gridPacked", "Quantity Confirmed", grid.Locator, "RelatedPickListSplitForceCompleted");
                    RelatedPickListSplitForceCompleted.DataField = "RelatedPickListSplitForceCompleted";
                    ShipmentNbr = new PXTextEdit("ctl00_phG_tab_t3_gridPacked_ei", "ShipmentNbr", grid.Locator, "ShipmentNbr");
                    ShipmentNbr.DataField = "ShipmentNbr";
                    SplitLineNbr = new PXNumberEdit("ctl00_phG_tab_t3_gridPacked_en", "SplitLineNbr", grid.Locator, "SplitLineNbr");
                    SplitLineNbr.DataField = "SplitLineNbr";
                }
            }

            public class c_grid_header : GridHeader
            {

                public CheckBoxColumnFilter Fits { get; }
                public PXNumberEditColumnFilter LineNbr { get; }
                public PXTextEditColumnFilter SOShipLine__OrigOrderType { get; }
                public SelectorColumnFilter SOShipLine__OrigOrderNbr { get; }
                public SelectorColumnFilter SiteID { get; }
                public SelectorColumnFilter LocationID { get; }
                public SelectorColumnFilter InventoryID { get; }
                public PXTextEditColumnFilter SOShipLine__TranDesc { get; }
                public PXTextEditColumnFilter LotSerialNbr { get; }
                public DateSelectorColumnFilter ExpireDate { get; }
                public PXNumberEditColumnFilter CartQty { get; }
                public PXNumberEditColumnFilter OverAllCartQty { get; }
                public PXNumberEditColumnFilter PickedQty { get; }
                public PXNumberEditColumnFilter PackedQty { get; }
                public PXNumberEditColumnFilter Qty { get; }
                public SelectorColumnFilter UOM { get; }
                public CheckBoxColumnFilter SOShipLine__IsFree { get; }
                public CheckBoxColumnFilter RelatedPickListSplitForceCompleted { get; }
                public PXTextEditColumnFilter ShipmentNbr { get; }
                public PXNumberEditColumnFilter SplitLineNbr { get; }

                public c_grid_header(c_pickedforpack_gridpacked grid) :
                        base(grid)
                {
                    Fits = new CheckBoxColumnFilter(grid.Row.Fits);
                    LineNbr = new PXNumberEditColumnFilter(grid.Row.LineNbr);
                    SOShipLine__OrigOrderType = new PXTextEditColumnFilter(grid.Row.SOShipLine__OrigOrderType);
                    SOShipLine__OrigOrderNbr = new SelectorColumnFilter(grid.Row.SOShipLine__OrigOrderNbr);
                    SiteID = new SelectorColumnFilter(grid.Row.SiteID);
                    LocationID = new SelectorColumnFilter(grid.Row.LocationID);
                    InventoryID = new SelectorColumnFilter(grid.Row.InventoryID);
                    SOShipLine__TranDesc = new PXTextEditColumnFilter(grid.Row.SOShipLine__TranDesc);
                    LotSerialNbr = new PXTextEditColumnFilter(grid.Row.LotSerialNbr);
                    ExpireDate = new DateSelectorColumnFilter(grid.Row.ExpireDate);
                    CartQty = new PXNumberEditColumnFilter(grid.Row.CartQty);
                    OverAllCartQty = new PXNumberEditColumnFilter(grid.Row.OverAllCartQty);
                    PickedQty = new PXNumberEditColumnFilter(grid.Row.PickedQty);
                    PackedQty = new PXNumberEditColumnFilter(grid.Row.PackedQty);
                    Qty = new PXNumberEditColumnFilter(grid.Row.Qty);
                    UOM = new SelectorColumnFilter(grid.Row.UOM);
                    SOShipLine__IsFree = new CheckBoxColumnFilter(grid.Row.SOShipLine__IsFree);
                    RelatedPickListSplitForceCompleted = new CheckBoxColumnFilter(grid.Row.RelatedPickListSplitForceCompleted);
                    ShipmentNbr = new PXTextEditColumnFilter(grid.Row.ShipmentNbr);
                    SplitLineNbr = new PXNumberEditColumnFilter(grid.Row.SplitLineNbr);
                }
            }
        }

        public class c_pickedforpack_lv0 : Container
        {

            public PxButtonCollection Buttons;

            public PXNumberEdit LineNbr { get; }
            public Label LineNbrLabel { get; }
            public PXTextEdit SOShipLine__OrigOrderType { get; }
            public Label SOShipLine__OrigOrderTypeLabel { get; }
            public Selector SOShipLine__OrigOrderNbr { get; }
            public Label SOShipLine__OrigOrderNbrLabel { get; }
            public Selector InventoryID { get; }
            public Label InventoryIDLabel { get; }
            public Selector SiteID { get; }
            public Label SiteIDLabel { get; }
            public Selector LocationID { get; }
            public Label LocationIDLabel { get; }
            public PXTextEdit LotSerialNbr { get; }
            public Label LotSerialNbrLabel { get; }
            public DateSelector ExpireDate { get; }
            public Label ExpireDateLabel { get; }
            public PXNumberEdit PickedQty { get; }
            public Label PickedQtyLabel { get; }
            public PXNumberEdit PackedQty { get; }
            public Label PackedQtyLabel { get; }
            public PXNumberEdit Qty { get; }
            public Label QtyLabel { get; }
            public Selector UOM { get; }
            public Label UOMLabel { get; }
            public CheckBox SOShipLine__IsFree { get; }
            public Label SOShipLine__IsFreeLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }

            public c_pickedforpack_lv0(string locator, string name) :
                    base(locator, name)
            {
                LineNbr = new PXNumberEdit("ctl00_phG_tab_t3_gridPacked_lv0_edPackLineNbr", "Line Nbr.", locator, null);
                LineNbrLabel = new Label(LineNbr);
                LineNbr.DataField = "LineNbr";
                SOShipLine__OrigOrderType = new PXTextEdit("ctl00_phG_tab_t3_gridPacked_lv0_edPackOrigOrderType", "Order Type", locator, null);
                SOShipLine__OrigOrderTypeLabel = new Label(SOShipLine__OrigOrderType);
                SOShipLine__OrigOrderType.DataField = "SOShipLine__OrigOrderType";
                SOShipLine__OrigOrderNbr = new Selector("ctl00_phG_tab_t3_gridPacked_lv0_edPackOrigOrderNbr", "Order Nbr.", locator, null);
                SOShipLine__OrigOrderNbrLabel = new Label(SOShipLine__OrigOrderNbr);
                SOShipLine__OrigOrderNbr.DataField = "SOShipLine__OrigOrderNbr";
                InventoryID = new Selector("ctl00_phG_tab_t3_gridPacked_lv0_edPackInventoryID", "Inventory ID", locator, null);
                InventoryIDLabel = new Label(InventoryID);
                InventoryID.DataField = "InventoryID";
                SiteID = new Selector("ctl00_phG_tab_t3_gridPacked_lv0_edPackSiteID", "Warehouse", locator, null);
                SiteIDLabel = new Label(SiteID);
                SiteID.DataField = "SiteID";
                LocationID = new Selector("ctl00_phG_tab_t3_gridPacked_lv0_edPackLocationID", "Location", locator, null);
                LocationIDLabel = new Label(LocationID);
                LocationID.DataField = "LocationID";
                LotSerialNbr = new PXTextEdit("ctl00_phG_tab_t3_gridPacked_lv0_edPackLotSerialNbr", "Lot/Serial Nbr.", locator, null);
                LotSerialNbrLabel = new Label(LotSerialNbr);
                LotSerialNbr.DataField = "LotSerialNbr";
                ExpireDate = new DateSelector("ctl00_phG_tab_t3_gridPacked_lv0_edPackExpireDate", "Expiration Date", locator, null);
                ExpireDateLabel = new Label(ExpireDate);
                ExpireDate.DataField = "ExpireDate";
                PickedQty = new PXNumberEdit("ctl00_phG_tab_t3_gridPacked_lv0_PXPackPickedQty", "Picked Quantity", locator, null);
                PickedQtyLabel = new Label(PickedQty);
                PickedQty.DataField = "PickedQty";
                PackedQty = new PXNumberEdit("ctl00_phG_tab_t3_gridPacked_lv0_PXPackPackedQty", "Packed Quantity", locator, null);
                PackedQtyLabel = new Label(PackedQty);
                PackedQty.DataField = "PackedQty";
                Qty = new PXNumberEdit("ctl00_phG_tab_t3_gridPacked_lv0_PXPackQty", "Quantity", locator, null);
                QtyLabel = new Label(Qty);
                Qty.DataField = "Qty";
                UOM = new Selector("ctl00_phG_tab_t3_gridPacked_lv0_edPackUOM", "UOM", locator, null);
                UOMLabel = new Label(UOM);
                UOM.DataField = "UOM";
                SOShipLine__IsFree = new CheckBox("ctl00_phG_tab_t3_gridPacked_lv0_chkPackIsFree", "Free Item", locator, null);
                SOShipLine__IsFreeLabel = new Label(SOShipLine__IsFree);
                SOShipLine__IsFree.DataField = "SOShipLine__IsFree";
                Es = new Selector("ctl00_phG_tab_t3_gridPacked_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                DataMemberName = "PickedForPack";
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

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t3_gridPackedItems_lfFirst0", "First", "ctl00_phG_tab_t3_gridPacked_lv0");
                    Prev = new Button("ctl00_phG_tab_t3_gridPackedItems_lfPrev0", "Prev", "ctl00_phG_tab_t3_gridPacked_lv0");
                    Next = new Button("ctl00_phG_tab_t3_gridPackedItems_lfNext0", "Next", "ctl00_phG_tab_t3_gridPacked_lv0");
                    Last = new Button("ctl00_phG_tab_t3_gridPackedItems_lfLast0", "Last", "ctl00_phG_tab_t3_gridPacked_lv0");
                }
            }
        }

        public class c_packed_gridpackeditems : Grid<c_packed_gridpackeditems.c_grid_row, c_packed_gridpackeditems.c_grid_header>
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            public c_grid_filter FilterForm { get; }

            public c_packed_gridpackeditems(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t3_gridPackedItems");
                DataMemberName = "Packed";
                Buttons = new PxButtonCollection();
                FilterForm = new c_grid_filter("ctl00_phG_tab_t3_gridPackedItems_fe_gf", "FilterForm");
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

            public virtual void Hi1()
            {
                ToolBar.Hi1.Click();
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

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid Adjust { get; }
                public ToolBarButtonGrid Export { get; }
                public ToolBarButtonGrid Hi { get; }
                public ToolBarButtonGrid Hi1 { get; }

                public PxToolBar(string locator)
                {
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPackedItems_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPackedItems_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPackedItems_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPackedItems_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t3_gridPackedItems_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t3_gridPackedItems_lfFirst0", "First", "ctl00_phG_tab_t3_gridPackedItems");
                    Prev = new Button("ctl00_phG_tab_t3_gridPackedItems_lfPrev0", "Prev", "ctl00_phG_tab_t3_gridPackedItems");
                    Next = new Button("ctl00_phG_tab_t3_gridPackedItems_lfNext0", "Next", "ctl00_phG_tab_t3_gridPackedItems");
                    Last = new Button("ctl00_phG_tab_t3_gridPackedItems_lfLast0", "Last", "ctl00_phG_tab_t3_gridPackedItems");
                }
            }

            public class c_grid_row : GridRow
            {

                public PXNumberEdit LineNbr { get; }
                public Selector InventoryID { get; }
                public PXTextEdit SOShipLine__TranDesc { get; }
                public Selector LotSerialNbr { get; }
                public PXNumberEdit PackedQtyPerBox { get; }
                public PXNumberEdit Qty { get; }
                public Selector UOM { get; }
                public CheckBox RelatedPickListSplitForceCompleted { get; }
                public PXTextEdit ShipmentNbr { get; }
                public PXNumberEdit SplitLineNbr { get; }

                public c_grid_row(c_packed_gridpackeditems grid) :
                        base(grid)
                {
                    LineNbr = new PXNumberEdit("ctl00_phG_tab_t3_gridPackedItems_en", "Line Nbr.", grid.Locator, "LineNbr");
                    LineNbr.DataField = "LineNbr";
                    InventoryID = new Selector("_ctl00_phG_tab_t3_gridPackedItems_lv0_edPackedItemInventoryID", "Inventory ID", grid.Locator, "InventoryID");
                    InventoryID.DataField = "InventoryID";
                    SOShipLine__TranDesc = new PXTextEdit("ctl00_phG_tab_t3_gridPackedItems_ei", "Description", grid.Locator, "SOShipLine__TranDesc");
                    SOShipLine__TranDesc.DataField = "SOShipLine__TranDesc";
                    LotSerialNbr = new Selector("_ctl00_phG_tab_t3_gridPackedItems_lv0_es", "Lot/Serial Nbr.", grid.Locator, "LotSerialNbr");
                    LotSerialNbr.DataField = "LotSerialNbr";
                    PackedQtyPerBox = new PXNumberEdit("ctl00_phG_tab_t3_gridPackedItems_en", "Packed Qty.", grid.Locator, "PackedQtyPerBox");
                    PackedQtyPerBox.DataField = "PackedQtyPerBox";
                    Qty = new PXNumberEdit("ctl00_phG_tab_t3_gridPackedItems_en", "Quantity", grid.Locator, "Qty");
                    Qty.DataField = "Qty";
                    UOM = new Selector("_ctl00_phG_tab_t3_gridPackedItems_lv0_es", "UOM", grid.Locator, "UOM");
                    UOM.DataField = "UOM";
                    RelatedPickListSplitForceCompleted = new CheckBox("ctl00_phG_tab_t3_gridPackedItems", "Quantity Confirmed", grid.Locator, "RelatedPickListSplitForceCompleted");
                    RelatedPickListSplitForceCompleted.DataField = "RelatedPickListSplitForceCompleted";
                    ShipmentNbr = new PXTextEdit("ctl00_phG_tab_t3_gridPackedItems_ei", "ShipmentNbr", grid.Locator, "ShipmentNbr");
                    ShipmentNbr.DataField = "ShipmentNbr";
                    SplitLineNbr = new PXNumberEdit("ctl00_phG_tab_t3_gridPackedItems_en", "SplitLineNbr", grid.Locator, "SplitLineNbr");
                    SplitLineNbr.DataField = "SplitLineNbr";
                }
            }

            public class c_grid_header : GridHeader
            {

                public PXNumberEditColumnFilter LineNbr { get; }
                public SelectorColumnFilter InventoryID { get; }
                public PXTextEditColumnFilter SOShipLine__TranDesc { get; }
                public SelectorColumnFilter LotSerialNbr { get; }
                public PXNumberEditColumnFilter PackedQtyPerBox { get; }
                public PXNumberEditColumnFilter Qty { get; }
                public SelectorColumnFilter UOM { get; }
                public CheckBoxColumnFilter RelatedPickListSplitForceCompleted { get; }
                public PXTextEditColumnFilter ShipmentNbr { get; }
                public PXNumberEditColumnFilter SplitLineNbr { get; }

                public c_grid_header(c_packed_gridpackeditems grid) :
                        base(grid)
                {
                    LineNbr = new PXNumberEditColumnFilter(grid.Row.LineNbr);
                    InventoryID = new SelectorColumnFilter(grid.Row.InventoryID);
                    SOShipLine__TranDesc = new PXTextEditColumnFilter(grid.Row.SOShipLine__TranDesc);
                    LotSerialNbr = new SelectorColumnFilter(grid.Row.LotSerialNbr);
                    PackedQtyPerBox = new PXNumberEditColumnFilter(grid.Row.PackedQtyPerBox);
                    Qty = new PXNumberEditColumnFilter(grid.Row.Qty);
                    UOM = new SelectorColumnFilter(grid.Row.UOM);
                    RelatedPickListSplitForceCompleted = new CheckBoxColumnFilter(grid.Row.RelatedPickListSplitForceCompleted);
                    ShipmentNbr = new PXTextEditColumnFilter(grid.Row.ShipmentNbr);
                    SplitLineNbr = new PXNumberEditColumnFilter(grid.Row.SplitLineNbr);
                }
            }
        }

        public class c_packed_lv0 : Container
        {

            public PxButtonCollection Buttons;

            public Selector InventoryID { get; }
            public Label InventoryIDLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }

            public c_packed_lv0(string locator, string name) :
                    base(locator, name)
            {
                InventoryID = new Selector("ctl00_phG_tab_t3_gridPackedItems_lv0_edPackedItemInventoryID", "Inventory ID", locator, null);
                InventoryIDLabel = new Label(InventoryID);
                InventoryID.DataField = "InventoryID";
                Es = new Selector("ctl00_phG_tab_t3_gridPackedItems_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                DataMemberName = "Packed";
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

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t3_gridPackedItems_lfFirst0", "First", "ctl00_phG_tab_t3_gridPackedItems_lv0");
                    Prev = new Button("ctl00_phG_tab_t3_gridPackedItems_lfPrev0", "Prev", "ctl00_phG_tab_t3_gridPackedItems_lv0");
                    Next = new Button("ctl00_phG_tab_t3_gridPackedItems_lfNext0", "Next", "ctl00_phG_tab_t3_gridPackedItems_lv0");
                    Last = new Button("ctl00_phG_tab_t3_gridPackedItems_lfLast0", "Last", "ctl00_phG_tab_t3_gridPackedItems_lv0");
                }
            }
        }

        public class c_picked_gridpicked : Grid<c_picked_gridpicked.c_grid_row, c_picked_gridpicked.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_picked_gridpicked(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t1_gridPicked");
                DataMemberName = "Picked";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t1_gridPicked_fe_gf", "FilterForm");
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_gridPicked_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_gridPicked_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_gridPicked_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_gridPicked_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_gridPicked_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_gridPicked_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_gridPicked_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_gridPicked_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t1_gridPicked_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public CheckBox Fits { get; }
                public PXNumberEdit LineNbr { get; }
                public PXTextEdit SOShipLine__OrigOrderType { get; }
                public Selector SOShipLine__OrigOrderNbr { get; }
                public Selector SiteID { get; }
                public Selector LocationID { get; }
                public Selector InventoryID { get; }
                public PXTextEdit SOShipLine__TranDesc { get; }
                public Selector LotSerialNbr { get; }
                public DateSelector ExpireDate { get; }
                public PXNumberEdit CartQty { get; }
                public PXNumberEdit OverAllCartQty { get; }
                public PXNumberEdit PickedQty { get; }
                public PXNumberEdit PackedQty { get; }
                public PXNumberEdit Qty { get; }
                public Selector UOM { get; }
                public CheckBox SOShipLine__IsFree { get; }
                public PXTextEdit ShipmentNbr { get; }
                public PXNumberEdit SplitLineNbr { get; }

                public c_grid_row(c_picked_gridpicked grid) :
                        base(grid)
                {
                    Fits = new CheckBox("ctl00_phG_tab_t1_gridPicked", "Matched", grid.Locator, "Fits");
                    Fits.DataField = "Fits";
                    LineNbr = new PXNumberEdit("_ctl00_phG_tab_t1_gridPicked_lv0_edPickLineNbr", "Line Nbr.", grid.Locator, "LineNbr");
                    LineNbr.DataField = "LineNbr";
                    SOShipLine__OrigOrderType = new PXTextEdit("_ctl00_phG_tab_t1_gridPicked_lv0_edPickOrigOrderType", "Order Type", grid.Locator, "SOShipLine__OrigOrderType");
                    SOShipLine__OrigOrderType.DataField = "SOShipLine__OrigOrderType";
                    SOShipLine__OrigOrderNbr = new Selector("_ctl00_phG_tab_t1_gridPicked_lv0_edPickOrigOrderNbr", "Order Nbr.", grid.Locator, "SOShipLine__OrigOrderNbr");
                    SOShipLine__OrigOrderNbr.DataField = "SOShipLine__OrigOrderNbr";
                    SiteID = new Selector("_ctl00_phG_tab_t1_gridPicked_lv0_edPickSiteID", "Warehouse", grid.Locator, "SiteID");
                    SiteID.DataField = "SiteID";
                    LocationID = new Selector("_ctl00_phG_tab_t1_gridPicked_lv0_edPickLocationID", "Location", grid.Locator, "LocationID");
                    LocationID.DataField = "LocationID";
                    InventoryID = new Selector("_ctl00_phG_tab_t1_gridPicked_lv0_edPickInventoryID", "Inventory ID", grid.Locator, "InventoryID");
                    InventoryID.DataField = "InventoryID";
                    SOShipLine__TranDesc = new PXTextEdit("ctl00_phG_tab_t1_gridPicked_ei", "Description", grid.Locator, "SOShipLine__TranDesc");
                    SOShipLine__TranDesc.DataField = "SOShipLine__TranDesc";
                    LotSerialNbr = new Selector("_ctl00_phG_tab_t1_gridPicked_lv0_edPickLotSerialNbr", "Lot/Serial Nbr.", grid.Locator, "LotSerialNbr");
                    LotSerialNbr.DataField = "LotSerialNbr";
                    ExpireDate = new DateSelector("_ctl00_phG_tab_t1_gridPicked_lv0_edPickExpireDate", "Expiration Date", grid.Locator, "ExpireDate");
                    ExpireDate.DataField = "ExpireDate";
                    CartQty = new PXNumberEdit("ctl00_phG_tab_t1_gridPicked_en", "Cart Qty.", grid.Locator, "CartQty");
                    CartQty.DataField = "CartQty";
                    OverAllCartQty = new PXNumberEdit("ctl00_phG_tab_t1_gridPicked_en", "Overall Cart Qty.", grid.Locator, "OverAllCartQty");
                    OverAllCartQty.DataField = "OverAllCartQty";
                    PickedQty = new PXNumberEdit("_ctl00_phG_tab_t1_gridPicked_lv0_PXPickPickedQty", "Picked Quantity", grid.Locator, "PickedQty");
                    PickedQty.DataField = "PickedQty";
                    PackedQty = new PXNumberEdit("_ctl00_phG_tab_t1_gridPicked_lv0_PXPickPackedQty", "Packed Quantity", grid.Locator, "PackedQty");
                    PackedQty.DataField = "PackedQty";
                    Qty = new PXNumberEdit("_ctl00_phG_tab_t1_gridPicked_lv0_PXPickQty", "Quantity", grid.Locator, "Qty");
                    Qty.DataField = "Qty";
                    UOM = new Selector("_ctl00_phG_tab_t1_gridPicked_lv0_edPickUOM", "UOM", grid.Locator, "UOM");
                    UOM.DataField = "UOM";
                    SOShipLine__IsFree = new CheckBox("_ctl00_phG_tab_t1_gridPicked_lv0_chkPickIsFree", "Free Item", grid.Locator, "SOShipLine__IsFree");
                    SOShipLine__IsFree.DataField = "SOShipLine__IsFree";
                    ShipmentNbr = new PXTextEdit("ctl00_phG_tab_t1_gridPicked_ei", "ShipmentNbr", grid.Locator, "ShipmentNbr");
                    ShipmentNbr.DataField = "ShipmentNbr";
                    SplitLineNbr = new PXNumberEdit("ctl00_phG_tab_t1_gridPicked_en", "SplitLineNbr", grid.Locator, "SplitLineNbr");
                    SplitLineNbr.DataField = "SplitLineNbr";
                }
            }

            public class c_grid_header : GridHeader
            {

                public CheckBoxColumnFilter Fits { get; }
                public PXNumberEditColumnFilter LineNbr { get; }
                public PXTextEditColumnFilter SOShipLine__OrigOrderType { get; }
                public SelectorColumnFilter SOShipLine__OrigOrderNbr { get; }
                public SelectorColumnFilter SiteID { get; }
                public SelectorColumnFilter LocationID { get; }
                public SelectorColumnFilter InventoryID { get; }
                public PXTextEditColumnFilter SOShipLine__TranDesc { get; }
                public SelectorColumnFilter LotSerialNbr { get; }
                public DateSelectorColumnFilter ExpireDate { get; }
                public PXNumberEditColumnFilter CartQty { get; }
                public PXNumberEditColumnFilter OverAllCartQty { get; }
                public PXNumberEditColumnFilter PickedQty { get; }
                public PXNumberEditColumnFilter PackedQty { get; }
                public PXNumberEditColumnFilter Qty { get; }
                public SelectorColumnFilter UOM { get; }
                public CheckBoxColumnFilter SOShipLine__IsFree { get; }
                public PXTextEditColumnFilter ShipmentNbr { get; }
                public PXNumberEditColumnFilter SplitLineNbr { get; }

                public c_grid_header(c_picked_gridpicked grid) :
                        base(grid)
                {
                    Fits = new CheckBoxColumnFilter(grid.Row.Fits);
                    LineNbr = new PXNumberEditColumnFilter(grid.Row.LineNbr);
                    SOShipLine__OrigOrderType = new PXTextEditColumnFilter(grid.Row.SOShipLine__OrigOrderType);
                    SOShipLine__OrigOrderNbr = new SelectorColumnFilter(grid.Row.SOShipLine__OrigOrderNbr);
                    SiteID = new SelectorColumnFilter(grid.Row.SiteID);
                    LocationID = new SelectorColumnFilter(grid.Row.LocationID);
                    InventoryID = new SelectorColumnFilter(grid.Row.InventoryID);
                    SOShipLine__TranDesc = new PXTextEditColumnFilter(grid.Row.SOShipLine__TranDesc);
                    LotSerialNbr = new SelectorColumnFilter(grid.Row.LotSerialNbr);
                    ExpireDate = new DateSelectorColumnFilter(grid.Row.ExpireDate);
                    CartQty = new PXNumberEditColumnFilter(grid.Row.CartQty);
                    OverAllCartQty = new PXNumberEditColumnFilter(grid.Row.OverAllCartQty);
                    PickedQty = new PXNumberEditColumnFilter(grid.Row.PickedQty);
                    PackedQty = new PXNumberEditColumnFilter(grid.Row.PackedQty);
                    Qty = new PXNumberEditColumnFilter(grid.Row.Qty);
                    UOM = new SelectorColumnFilter(grid.Row.UOM);
                    SOShipLine__IsFree = new CheckBoxColumnFilter(grid.Row.SOShipLine__IsFree);
                    ShipmentNbr = new PXTextEditColumnFilter(grid.Row.ShipmentNbr);
                    SplitLineNbr = new PXNumberEditColumnFilter(grid.Row.SplitLineNbr);
                }
            }
        }

        public class c_picked_lv0 : Container
        {

            public PXNumberEdit LineNbr { get; }
            public Label LineNbrLabel { get; }
            public PXTextEdit SOShipLine__OrigOrderType { get; }
            public Label SOShipLine__OrigOrderTypeLabel { get; }
            public Selector SOShipLine__OrigOrderNbr { get; }
            public Label SOShipLine__OrigOrderNbrLabel { get; }
            public Selector InventoryID { get; }
            public Label InventoryIDLabel { get; }
            public Selector SiteID { get; }
            public Label SiteIDLabel { get; }
            public Selector LocationID { get; }
            public Label LocationIDLabel { get; }
            public Selector LotSerialNbr { get; }
            public Label LotSerialNbrLabel { get; }
            public DateSelector ExpireDate { get; }
            public Label ExpireDateLabel { get; }
            public PXNumberEdit PickedQty { get; }
            public Label PickedQtyLabel { get; }
            public PXNumberEdit PackedQty { get; }
            public Label PackedQtyLabel { get; }
            public PXNumberEdit Qty { get; }
            public Label QtyLabel { get; }
            public Selector UOM { get; }
            public Label UOMLabel { get; }
            public CheckBox SOShipLine__IsFree { get; }
            public Label SOShipLine__IsFreeLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }

            public c_picked_lv0(string locator, string name) :
                    base(locator, name)
            {
                LineNbr = new PXNumberEdit("ctl00_phG_tab_t1_gridPicked_lv0_edPickLineNbr", "Line Nbr.", locator, null);
                LineNbrLabel = new Label(LineNbr);
                LineNbr.DataField = "LineNbr";
                SOShipLine__OrigOrderType = new PXTextEdit("ctl00_phG_tab_t1_gridPicked_lv0_edPickOrigOrderType", "Order Type", locator, null);
                SOShipLine__OrigOrderTypeLabel = new Label(SOShipLine__OrigOrderType);
                SOShipLine__OrigOrderType.DataField = "SOShipLine__OrigOrderType";
                SOShipLine__OrigOrderNbr = new Selector("ctl00_phG_tab_t1_gridPicked_lv0_edPickOrigOrderNbr", "Order Nbr.", locator, null);
                SOShipLine__OrigOrderNbrLabel = new Label(SOShipLine__OrigOrderNbr);
                SOShipLine__OrigOrderNbr.DataField = "SOShipLine__OrigOrderNbr";
                InventoryID = new Selector("ctl00_phG_tab_t1_gridPicked_lv0_edPickInventoryID", "Inventory ID", locator, null);
                InventoryIDLabel = new Label(InventoryID);
                InventoryID.DataField = "InventoryID";
                SiteID = new Selector("ctl00_phG_tab_t1_gridPicked_lv0_edPickSiteID", "Warehouse", locator, null);
                SiteIDLabel = new Label(SiteID);
                SiteID.DataField = "SiteID";
                LocationID = new Selector("ctl00_phG_tab_t1_gridPicked_lv0_edPickLocationID", "Location", locator, null);
                LocationIDLabel = new Label(LocationID);
                LocationID.DataField = "LocationID";
                LotSerialNbr = new Selector("ctl00_phG_tab_t1_gridPicked_lv0_edPickLotSerialNbr", "Lot/Serial Nbr.", locator, null);
                LotSerialNbrLabel = new Label(LotSerialNbr);
                LotSerialNbr.DataField = "LotSerialNbr";
                ExpireDate = new DateSelector("ctl00_phG_tab_t1_gridPicked_lv0_edPickExpireDate", "Expiration Date", locator, null);
                ExpireDateLabel = new Label(ExpireDate);
                ExpireDate.DataField = "ExpireDate";
                PickedQty = new PXNumberEdit("ctl00_phG_tab_t1_gridPicked_lv0_PXPickPickedQty", "Picked Quantity", locator, null);
                PickedQtyLabel = new Label(PickedQty);
                PickedQty.DataField = "PickedQty";
                PackedQty = new PXNumberEdit("ctl00_phG_tab_t1_gridPicked_lv0_PXPickPackedQty", "Packed Quantity", locator, null);
                PackedQtyLabel = new Label(PackedQty);
                PackedQty.DataField = "PackedQty";
                Qty = new PXNumberEdit("ctl00_phG_tab_t1_gridPicked_lv0_PXPickQty", "Quantity", locator, null);
                QtyLabel = new Label(Qty);
                Qty.DataField = "Qty";
                UOM = new Selector("ctl00_phG_tab_t1_gridPicked_lv0_edPickUOM", "UOM", locator, null);
                UOMLabel = new Label(UOM);
                UOM.DataField = "UOM";
                SOShipLine__IsFree = new CheckBox("ctl00_phG_tab_t1_gridPicked_lv0_chkPickIsFree", "Free Item", locator, null);
                SOShipLine__IsFreeLabel = new Label(SOShipLine__IsFree);
                SOShipLine__IsFree.DataField = "SOShipLine__IsFree";
                Es = new Selector("ctl00_phG_tab_t1_gridPicked_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                DataMemberName = "Picked";
            }
        }

        public class c_returned_gridreturned : Grid<c_returned_gridreturned.c_grid_row, c_returned_gridreturned.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_returned_gridreturned(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t2_gridReturned");
                DataMemberName = "Returned";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t2_gridReturned_fe_gf", "FilterForm");
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t2_gridReturned_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t2_gridReturned_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t2_gridReturned_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t2_gridReturned_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t2_gridReturned_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t2_gridReturned_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t2_gridReturned_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t2_gridReturned_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t2_gridReturned_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public CheckBox Fits { get; }
                public PXNumberEdit LineNbr { get; }
                public PXTextEdit SOShipLine__OrigOrderType { get; }
                public Selector SOShipLine__OrigOrderNbr { get; }
                public Selector SiteID { get; }
                public Selector LocationID { get; }
                public Selector InventoryID { get; }
                public PXTextEdit SOShipLine__TranDesc { get; }
                public Selector LotSerialNbr { get; }
                public DateSelector ExpireDate { get; }
                public PXNumberEdit PickedQty { get; }
                public PXNumberEdit Qty { get; }
                public Selector UOM { get; }
                public CheckBox SOShipLine__IsFree { get; }
                public PXTextEdit ShipmentNbr { get; }
                public PXNumberEdit SplitLineNbr { get; }

                public c_grid_row(c_returned_gridreturned grid) :
                        base(grid)
                {
                    Fits = new CheckBox("ctl00_phG_tab_t2_gridReturned", "Matched", grid.Locator, "Fits");
                    Fits.DataField = "Fits";
                    LineNbr = new PXNumberEdit("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnLineNbr", "Line Nbr.", grid.Locator, "LineNbr");
                    LineNbr.DataField = "LineNbr";
                    SOShipLine__OrigOrderType = new PXTextEdit("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnOrigOrderType", "Order Type", grid.Locator, "SOShipLine__OrigOrderType");
                    SOShipLine__OrigOrderType.DataField = "SOShipLine__OrigOrderType";
                    SOShipLine__OrigOrderNbr = new Selector("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnOrigOrderNbr", "Order Nbr.", grid.Locator, "SOShipLine__OrigOrderNbr");
                    SOShipLine__OrigOrderNbr.DataField = "SOShipLine__OrigOrderNbr";
                    SiteID = new Selector("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnSiteID", "Warehouse", grid.Locator, "SiteID");
                    SiteID.DataField = "SiteID";
                    LocationID = new Selector("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnLocationID", "Location", grid.Locator, "LocationID");
                    LocationID.DataField = "LocationID";
                    InventoryID = new Selector("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnInventoryID", "Inventory ID", grid.Locator, "InventoryID");
                    InventoryID.DataField = "InventoryID";
                    SOShipLine__TranDesc = new PXTextEdit("ctl00_phG_tab_t2_gridReturned_ei", "Description", grid.Locator, "SOShipLine__TranDesc");
                    SOShipLine__TranDesc.DataField = "SOShipLine__TranDesc";
                    LotSerialNbr = new Selector("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnLotSerialNbr", "Lot/Serial Nbr.", grid.Locator, "LotSerialNbr");
                    LotSerialNbr.DataField = "LotSerialNbr";
                    ExpireDate = new DateSelector("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnExpireDate", "Expiration Date", grid.Locator, "ExpireDate");
                    ExpireDate.DataField = "ExpireDate";
                    PickedQty = new PXNumberEdit("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnPickedQty", "Picked Quantity", grid.Locator, "PickedQty");
                    PickedQty.DataField = "PickedQty";
                    Qty = new PXNumberEdit("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnQty", "Quantity", grid.Locator, "Qty");
                    Qty.DataField = "Qty";
                    UOM = new Selector("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnUOM", "UOM", grid.Locator, "UOM");
                    UOM.DataField = "UOM";
                    SOShipLine__IsFree = new CheckBox("_ctl00_phG_tab_t2_gridReturned_lv0_edReturnIsFree", "Free Item", grid.Locator, "SOShipLine__IsFree");
                    SOShipLine__IsFree.DataField = "SOShipLine__IsFree";
                    ShipmentNbr = new PXTextEdit("ctl00_phG_tab_t2_gridReturned_ei", "ShipmentNbr", grid.Locator, "ShipmentNbr");
                    ShipmentNbr.DataField = "ShipmentNbr";
                    SplitLineNbr = new PXNumberEdit("ctl00_phG_tab_t2_gridReturned_en", "SplitLineNbr", grid.Locator, "SplitLineNbr");
                    SplitLineNbr.DataField = "SplitLineNbr";
                }
            }

            public class c_grid_header : GridHeader
            {

                public CheckBoxColumnFilter Fits { get; }
                public PXNumberEditColumnFilter LineNbr { get; }
                public PXTextEditColumnFilter SOShipLine__OrigOrderType { get; }
                public SelectorColumnFilter SOShipLine__OrigOrderNbr { get; }
                public SelectorColumnFilter SiteID { get; }
                public SelectorColumnFilter LocationID { get; }
                public SelectorColumnFilter InventoryID { get; }
                public PXTextEditColumnFilter SOShipLine__TranDesc { get; }
                public SelectorColumnFilter LotSerialNbr { get; }
                public DateSelectorColumnFilter ExpireDate { get; }
                public PXNumberEditColumnFilter PickedQty { get; }
                public PXNumberEditColumnFilter Qty { get; }
                public SelectorColumnFilter UOM { get; }
                public CheckBoxColumnFilter SOShipLine__IsFree { get; }
                public PXTextEditColumnFilter ShipmentNbr { get; }
                public PXNumberEditColumnFilter SplitLineNbr { get; }

                public c_grid_header(c_returned_gridreturned grid) :
                        base(grid)
                {
                    Fits = new CheckBoxColumnFilter(grid.Row.Fits);
                    LineNbr = new PXNumberEditColumnFilter(grid.Row.LineNbr);
                    SOShipLine__OrigOrderType = new PXTextEditColumnFilter(grid.Row.SOShipLine__OrigOrderType);
                    SOShipLine__OrigOrderNbr = new SelectorColumnFilter(grid.Row.SOShipLine__OrigOrderNbr);
                    SiteID = new SelectorColumnFilter(grid.Row.SiteID);
                    LocationID = new SelectorColumnFilter(grid.Row.LocationID);
                    InventoryID = new SelectorColumnFilter(grid.Row.InventoryID);
                    SOShipLine__TranDesc = new PXTextEditColumnFilter(grid.Row.SOShipLine__TranDesc);
                    LotSerialNbr = new SelectorColumnFilter(grid.Row.LotSerialNbr);
                    ExpireDate = new DateSelectorColumnFilter(grid.Row.ExpireDate);
                    PickedQty = new PXNumberEditColumnFilter(grid.Row.PickedQty);
                    Qty = new PXNumberEditColumnFilter(grid.Row.Qty);
                    UOM = new SelectorColumnFilter(grid.Row.UOM);
                    SOShipLine__IsFree = new CheckBoxColumnFilter(grid.Row.SOShipLine__IsFree);
                    ShipmentNbr = new PXTextEditColumnFilter(grid.Row.ShipmentNbr);
                    SplitLineNbr = new PXNumberEditColumnFilter(grid.Row.SplitLineNbr);
                }
            }
        }

        public class c_returned_lv0 : Container
        {

            public PXNumberEdit LineNbr { get; }
            public Label LineNbrLabel { get; }
            public PXTextEdit SOShipLine__OrigOrderType { get; }
            public Label SOShipLine__OrigOrderTypeLabel { get; }
            public Selector SOShipLine__OrigOrderNbr { get; }
            public Label SOShipLine__OrigOrderNbrLabel { get; }
            public Selector InventoryID { get; }
            public Label InventoryIDLabel { get; }
            public Selector SiteID { get; }
            public Label SiteIDLabel { get; }
            public Selector LocationID { get; }
            public Label LocationIDLabel { get; }
            public Selector LotSerialNbr { get; }
            public Label LotSerialNbrLabel { get; }
            public DateSelector ExpireDate { get; }
            public Label ExpireDateLabel { get; }
            public PXNumberEdit PickedQty { get; }
            public Label PickedQtyLabel { get; }
            public PXNumberEdit Qty { get; }
            public Label QtyLabel { get; }
            public Selector UOM { get; }
            public Label UOMLabel { get; }
            public CheckBox SOShipLine__IsFree { get; }
            public Label SOShipLine__IsFreeLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }

            public c_returned_lv0(string locator, string name) :
                    base(locator, name)
            {
                LineNbr = new PXNumberEdit("ctl00_phG_tab_t2_gridReturned_lv0_edReturnLineNbr", "Line Nbr.", locator, null);
                LineNbrLabel = new Label(LineNbr);
                LineNbr.DataField = "LineNbr";
                SOShipLine__OrigOrderType = new PXTextEdit("ctl00_phG_tab_t2_gridReturned_lv0_edReturnOrigOrderType", "Order Type", locator, null);
                SOShipLine__OrigOrderTypeLabel = new Label(SOShipLine__OrigOrderType);
                SOShipLine__OrigOrderType.DataField = "SOShipLine__OrigOrderType";
                SOShipLine__OrigOrderNbr = new Selector("ctl00_phG_tab_t2_gridReturned_lv0_edReturnOrigOrderNbr", "Order Nbr.", locator, null);
                SOShipLine__OrigOrderNbrLabel = new Label(SOShipLine__OrigOrderNbr);
                SOShipLine__OrigOrderNbr.DataField = "SOShipLine__OrigOrderNbr";
                InventoryID = new Selector("ctl00_phG_tab_t2_gridReturned_lv0_edReturnInventoryID", "Inventory ID", locator, null);
                InventoryIDLabel = new Label(InventoryID);
                InventoryID.DataField = "InventoryID";
                SiteID = new Selector("ctl00_phG_tab_t2_gridReturned_lv0_edReturnSiteID", "Warehouse", locator, null);
                SiteIDLabel = new Label(SiteID);
                SiteID.DataField = "SiteID";
                LocationID = new Selector("ctl00_phG_tab_t2_gridReturned_lv0_edReturnLocationID", "Location", locator, null);
                LocationIDLabel = new Label(LocationID);
                LocationID.DataField = "LocationID";
                LotSerialNbr = new Selector("ctl00_phG_tab_t2_gridReturned_lv0_edReturnLotSerialNbr", "Lot/Serial Nbr.", locator, null);
                LotSerialNbrLabel = new Label(LotSerialNbr);
                LotSerialNbr.DataField = "LotSerialNbr";
                ExpireDate = new DateSelector("ctl00_phG_tab_t2_gridReturned_lv0_edReturnExpireDate", "Expiration Date", locator, null);
                ExpireDateLabel = new Label(ExpireDate);
                ExpireDate.DataField = "ExpireDate";
                PickedQty = new PXNumberEdit("ctl00_phG_tab_t2_gridReturned_lv0_edReturnPickedQty", "Picked Quantity", locator, null);
                PickedQtyLabel = new Label(PickedQty);
                PickedQty.DataField = "PickedQty";
                Qty = new PXNumberEdit("ctl00_phG_tab_t2_gridReturned_lv0_edReturnQty", "Quantity", locator, null);
                QtyLabel = new Label(Qty);
                Qty.DataField = "Qty";
                UOM = new Selector("ctl00_phG_tab_t2_gridReturned_lv0_edReturnUOM", "UOM", locator, null);
                UOMLabel = new Label(UOM);
                UOM.DataField = "UOM";
                SOShipLine__IsFree = new CheckBox("ctl00_phG_tab_t2_gridReturned_lv0_edReturnIsFree", "Free Item", locator, null);
                SOShipLine__IsFreeLabel = new Label(SOShipLine__IsFree);
                SOShipLine__IsFree.DataField = "SOShipLine__IsFree";
                Es = new Selector("ctl00_phG_tab_t2_gridReturned_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                DataMemberName = "Returned";
            }
        }

        public class c_carrierrates_gridrates : Grid<c_carrierrates_gridrates.c_grid_row, c_carrierrates_gridrates.c_grid_header>
        {

            public PxToolBar ToolBar;

            public PxButtonCollection Buttons;

            public c_carrierrates_gridrates(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t4_gridRates");
                DataMemberName = "CarrierRates";
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

            public virtual void RefreshRates()
            {
                ToolBar.RefreshRates.Click();
            }

            public virtual void GetReturnLabels()
            {
                ToolBar.GetReturnLabels.Click();
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

            public virtual void First1()
            {
                Buttons.First1.Click();
            }

            public virtual void Prev1()
            {
                Buttons.Prev1.Click();
            }

            public virtual void Next1()
            {
                Buttons.Next1.Click();
            }

            public virtual void Last1()
            {
                Buttons.Last1.Click();
            }

            public class PxToolBar : PxControlCollection
            {

                public ToolBarButtonGrid Refresh { get; }
                public ToolBarButtonGrid New { get; }
                public ToolBarButtonGrid Delete { get; }
                public ToolBarButtonGrid RefreshRates { get; }
                public ToolBarButtonGrid GetReturnLabels { get; }
                public ToolBarButtonGrid Adjust { get; }
                public ToolBarButtonGrid Export { get; }
                public ToolBarButtonGrid Hi { get; }

                public PxToolBar(string locator)
                {
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridRates_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    New = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridRates_at_tlb div[data-cmd=\'AddNew\']", "Add Row", locator, null);
                    Delete = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridRates_at_tlb div[data-cmd=\'Delete\']", "Delete Row", locator, null);
                    Delete.ConfirmAction = () => Alert.AlertToException("The current {0} record will be deleted.");
                    RefreshRates = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridRates_at_tlb div[data-cmd=\'RefreshRates\']", "Refresh Rates", locator, null);
                    GetReturnLabels = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridRates_at_tlb div[data-cmd=\'GetReturnLabels\']", "Get Return Labels", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridRates_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridRates_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t4_gridRates_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button First1 { get; }
                public Button Prev1 { get; }
                public Button Next1 { get; }
                public Button Last1 { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t4_gridRates_lfFirst0", "First", "ctl00_phG_tab_t4_gridRates");
                    Prev = new Button("ctl00_phG_tab_t4_gridRates_lfPrev0", "Prev", "ctl00_phG_tab_t4_gridRates");
                    Next = new Button("ctl00_phG_tab_t4_gridRates_lfNext0", "Next", "ctl00_phG_tab_t4_gridRates");
                    Last = new Button("ctl00_phG_tab_t4_gridRates_lfLast0", "Last", "ctl00_phG_tab_t4_gridRates");
                    First1 = new Button("ctl00_phG_tab_t4_gridPackages_lfFirst0", "First", "ctl00_phG_tab_t4_gridRates");
                    Prev1 = new Button("ctl00_phG_tab_t4_gridPackages_lfPrev0", "Prev", "ctl00_phG_tab_t4_gridRates");
                    Next1 = new Button("ctl00_phG_tab_t4_gridPackages_lfNext0", "Next", "ctl00_phG_tab_t4_gridRates");
                    Last1 = new Button("ctl00_phG_tab_t4_gridPackages_lfLast0", "Last", "ctl00_phG_tab_t4_gridRates");
                }
            }

            public class c_grid_row : GridRow
            {

                public CheckBox Selected { get; }
                public PXTextEdit Method { get; }
                public PXTextEdit Description { get; }
                public PXNumberEdit Amount { get; }
                public PXNumberEdit DaysInTransit { get; }
                public DateSelector DeliveryDate { get; }
                public PXNumberEdit LineNbr { get; }

                public c_grid_row(c_carrierrates_gridrates grid) :
                        base(grid)
                {
                    Selected = new CheckBox("ctl00_phG_tab_t4_gridRates_ef", "Selected", grid.Locator, "Selected");
                    Selected.DataField = "Selected";
                    Method = new PXTextEdit("ctl00_phG_tab_t4_gridRates_ei", "Code", grid.Locator, "Method");
                    Method.DataField = "Method";
                    Description = new PXTextEdit("ctl00_phG_tab_t4_gridRates_ei", "Description", grid.Locator, "Description");
                    Description.DataField = "Description";
                    Amount = new PXNumberEdit("ctl00_phG_tab_t4_gridRates_en", "Amount", grid.Locator, "Amount");
                    Amount.DataField = "Amount";
                    DaysInTransit = new PXNumberEdit("ctl00_phG_tab_t4_gridRates_en", "Days in Transit", grid.Locator, "DaysInTransit");
                    DaysInTransit.DataField = "DaysInTransit";
                    DeliveryDate = new DateSelector("_ctl00_phG_tab_t4_gridRates_lv0_ed5", "Delivery Date", grid.Locator, "DeliveryDate");
                    DeliveryDate.DataField = "DeliveryDate";
                    LineNbr = new PXNumberEdit("ctl00_phG_tab_t4_gridRates_en", "LineNbr", grid.Locator, "LineNbr");
                    LineNbr.DataField = "LineNbr";
                }
            }

            public class c_grid_header : GridHeader
            {

                public CheckBoxColumnFilter Selected { get; }
                public PXTextEditColumnFilter Method { get; }
                public PXTextEditColumnFilter Description { get; }
                public PXNumberEditColumnFilter Amount { get; }
                public PXNumberEditColumnFilter DaysInTransit { get; }
                public DateSelectorColumnFilter DeliveryDate { get; }
                public PXNumberEditColumnFilter LineNbr { get; }

                public c_grid_header(c_carrierrates_gridrates grid) :
                        base(grid)
                {
                    Selected = new CheckBoxColumnFilter(grid.Row.Selected);
                    Method = new PXTextEditColumnFilter(grid.Row.Method);
                    Description = new PXTextEditColumnFilter(grid.Row.Description);
                    Amount = new PXNumberEditColumnFilter(grid.Row.Amount);
                    DaysInTransit = new PXNumberEditColumnFilter(grid.Row.DaysInTransit);
                    DeliveryDate = new DateSelectorColumnFilter(grid.Row.DeliveryDate);
                    LineNbr = new PXNumberEditColumnFilter(grid.Row.LineNbr);
                }
            }
        }

        public class c_carrierrates_lv0 : Container
        {

            public PxButtonCollection Buttons;

            public DateSelector Ed { get; }
            public Label EdLabel { get; }

            public c_carrierrates_lv0(string locator, string name) :
                    base(locator, name)
            {
                Ed = new DateSelector("ctl00_phG_tab_t4_gridRates_lv0_ed", "Ed", locator, null);
                EdLabel = new Label(Ed);
                DataMemberName = "CarrierRates";
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

            public virtual void First1()
            {
                Buttons.First1.Click();
            }

            public virtual void Prev1()
            {
                Buttons.Prev1.Click();
            }

            public virtual void Next1()
            {
                Buttons.Next1.Click();
            }

            public virtual void Last1()
            {
                Buttons.Last1.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button First { get; }
                public Button Prev { get; }
                public Button Next { get; }
                public Button Last { get; }
                public Button First1 { get; }
                public Button Prev1 { get; }
                public Button Next1 { get; }
                public Button Last1 { get; }

                public PxButtonCollection()
                {
                    First = new Button("ctl00_phG_tab_t4_gridRates_lfFirst0", "First", "ctl00_phG_tab_t4_gridRates_lv0");
                    Prev = new Button("ctl00_phG_tab_t4_gridRates_lfPrev0", "Prev", "ctl00_phG_tab_t4_gridRates_lv0");
                    Next = new Button("ctl00_phG_tab_t4_gridRates_lfNext0", "Next", "ctl00_phG_tab_t4_gridRates_lv0");
                    Last = new Button("ctl00_phG_tab_t4_gridRates_lfLast0", "Last", "ctl00_phG_tab_t4_gridRates_lv0");
                    First1 = new Button("ctl00_phG_tab_t4_gridPackages_lfFirst0", "First", "ctl00_phG_tab_t4_gridRates_lv0");
                    Prev1 = new Button("ctl00_phG_tab_t4_gridPackages_lfPrev0", "Prev", "ctl00_phG_tab_t4_gridRates_lv0");
                    Next1 = new Button("ctl00_phG_tab_t4_gridPackages_lfNext0", "Next", "ctl00_phG_tab_t4_gridRates_lv0");
                    Last1 = new Button("ctl00_phG_tab_t4_gridPackages_lfLast0", "Last", "ctl00_phG_tab_t4_gridRates_lv0");
                }
            }
        }

        public class c_info_forminfo : Container
        {

            public PXTextEdit Mode { get; }
            public Label ModeLabel { get; }
            public PXTextEdit Message { get; }
            public Label MessageLabel { get; }
            public PXTextEdit MessageSoundFile { get; }
            public Label MessageSoundFileLabel { get; }
            public PXTextEdit Instructions { get; }
            public Label InstructionsLabel { get; }
            public PXTextEdit Prompt { get; }
            public Label PromptLabel { get; }

            public c_info_forminfo(string locator, string name) :
                    base(locator, name)
            {
                Mode = new PXTextEdit("ctl00_phF_formInfo_edInfoMode", "Mode", locator, null);
                ModeLabel = new Label(Mode);
                Mode.DataField = "Mode";
                Message = new PXTextEdit("ctl00_phF_formInfo_edInfoMessage", "Message", locator, null);
                MessageLabel = new Label(Message);
                Message.DataField = "Message";
                MessageSoundFile = new PXTextEdit("ctl00_phF_formInfo_edInfoMessageSoundFile", "Message Sound", locator, null);
                MessageSoundFileLabel = new Label(MessageSoundFile);
                MessageSoundFile.DataField = "MessageSoundFile";
                Instructions = new PXTextEdit("ctl00_phF_formInfo_edInfoInstructions", "Instructions", locator, null);
                InstructionsLabel = new Label(Instructions);
                Instructions.DataField = "Instructions";
                Prompt = new PXTextEdit("ctl00_phF_formInfo_edInfoPrompt", "Prompt", locator, null);
                PromptLabel = new Label(Prompt);
                Prompt.DataField = "Prompt";
                DataMemberName = "Info";
            }
        }

        public class c_logs_grid4 : Grid<c_logs_grid4.c_grid_row, c_logs_grid4.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_logs_grid4(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t5_grid4");
                DataMemberName = "Logs";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t5_grid4_fe_gf", "FilterForm");
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t5_grid4_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t5_grid4_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t5_grid4_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t5_grid4_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t5_grid4_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t5_grid4_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t5_grid4_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t5_grid4_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t5_grid4_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public DateSelector ScanTime { get; }
                public PXTextEdit Mode { get; }
                public PXTextEdit Prompt { get; }
                public PXTextEdit Scan { get; }
                public PXTextEdit Message { get; }

                public c_grid_row(c_logs_grid4 grid) :
                        base(grid)
                {
                    ScanTime = new DateSelector("_ctl00_phG_tab_t5_grid4_lv0_ed0", "Time", grid.Locator, "ScanTime");
                    ScanTime.DataField = "ScanTime";
                    Mode = new PXTextEdit("ctl00_phG_tab_t5_grid4_ei", "Mode", grid.Locator, "Mode");
                    Mode.DataField = "Mode";
                    Prompt = new PXTextEdit("ctl00_phG_tab_t5_grid4_ei", "Prompt", grid.Locator, "Prompt");
                    Prompt.DataField = "Prompt";
                    Scan = new PXTextEdit("ctl00_phG_tab_t5_grid4_ei", "Scan", grid.Locator, "Scan");
                    Scan.DataField = "Scan";
                    Message = new PXTextEdit("ctl00_phG_tab_t5_grid4_ei", "Message", grid.Locator, "Message");
                    Message.DataField = "Message";
                }
            }

            public class c_grid_header : GridHeader
            {

                public DateSelectorColumnFilter ScanTime { get; }
                public PXTextEditColumnFilter Mode { get; }
                public PXTextEditColumnFilter Prompt { get; }
                public PXTextEditColumnFilter Scan { get; }
                public PXTextEditColumnFilter Message { get; }

                public c_grid_header(c_logs_grid4 grid) :
                        base(grid)
                {
                    ScanTime = new DateSelectorColumnFilter(grid.Row.ScanTime);
                    Mode = new PXTextEditColumnFilter(grid.Row.Mode);
                    Prompt = new PXTextEditColumnFilter(grid.Row.Prompt);
                    Scan = new PXTextEditColumnFilter(grid.Row.Scan);
                    Message = new PXTextEditColumnFilter(grid.Row.Message);
                }
            }
        }

        public class c_logs_lv0 : Container
        {

            public DateSelector Ed { get; }
            public Label EdLabel { get; }

            public c_logs_lv0(string locator, string name) :
                    base(locator, name)
            {
                Ed = new DateSelector("ctl00_phG_tab_t5_grid4_lv0_ed", "Ed", locator, null);
                EdLabel = new Label(Ed);
                DataMemberName = "Logs";
            }
        }

        public class c_usersetupview_frmsettings : Container
        {

            public PxButtonCollection Buttons;

            public CheckBox DefaultLocationFromShipment { get; }
            public Label DefaultLocationFromShipmentLabel { get; }
            public CheckBox DefaultLotSerialFromShipment { get; }
            public Label DefaultLotSerialFromShipmentLabel { get; }
            public CheckBox PrintShipmentConfirmation { get; }
            public Label PrintShipmentConfirmationLabel { get; }
            public CheckBox PrintShipmentLabels { get; }
            public Label PrintShipmentLabelsLabel { get; }
            public CheckBox UseScale { get; }
            public Label UseScaleLabel { get; }
            public Selector ScaleDeviceID { get; }
            public Label ScaleDeviceIDLabel { get; }
            public CheckBox EnterSizeForPackages { get; }
            public Label EnterSizeForPackagesLabel { get; }

            public c_usersetupview_frmsettings(string locator, string name) :
                    base(locator, name)
            {
                DefaultLocationFromShipment = new CheckBox("ctl00_phG_PanelSettings_frmSettings_edDefaultLocation", "Use Default Location", locator, null);
                DefaultLocationFromShipmentLabel = new Label(DefaultLocationFromShipment);
                DefaultLocationFromShipment.DataField = "DefaultLocationFromShipment";
                DefaultLotSerialFromShipment = new CheckBox("ctl00_phG_PanelSettings_frmSettings_edDefaultLotSerial", "Use Default Lot/Serial Nbr.", locator, null);
                DefaultLotSerialFromShipmentLabel = new Label(DefaultLotSerialFromShipment);
                DefaultLotSerialFromShipment.DataField = "DefaultLotSerialFromShipment";
                PrintShipmentConfirmation = new CheckBox("ctl00_phG_PanelSettings_frmSettings_edPrintShipmentConfirmation", "Print Shipment Confirmation Automatically", locator, null);
                PrintShipmentConfirmationLabel = new Label(PrintShipmentConfirmation);
                PrintShipmentConfirmation.DataField = "PrintShipmentConfirmation";
                PrintShipmentLabels = new CheckBox("ctl00_phG_PanelSettings_frmSettings_edPrintShipmentLabels", "Print Shipment Labels Automatically", locator, null);
                PrintShipmentLabelsLabel = new Label(PrintShipmentLabels);
                PrintShipmentLabels.DataField = "PrintShipmentLabels";
                UseScale = new CheckBox("ctl00_phG_PanelSettings_frmSettings_edUseScale", "Use Digital Scale", locator, null);
                UseScaleLabel = new Label(UseScale);
                UseScale.DataField = "UseScale";
                ScaleDeviceID = new Selector("ctl00_phG_PanelSettings_frmSettings_edScaleID", "Scale", locator, null);
                ScaleDeviceIDLabel = new Label(ScaleDeviceID);
                ScaleDeviceID.DataField = "ScaleDeviceID";
                EnterSizeForPackages = new CheckBox("ctl00_phG_PanelSettings_frmSettings_edEnterSizeForPackages", "Enter Length/Width/Height for Packages", locator, null);
                EnterSizeForPackagesLabel = new Label(EnterSizeForPackages);
                EnterSizeForPackages.DataField = "EnterSizeForPackages";
                DataMemberName = "UserSetupView";
                Buttons = new PxButtonCollection();
            }

            public virtual void Save()
            {
                Buttons.Save.Click();
            }

            public virtual void Cancel()
            {
                Buttons.Cancel.Click();
            }

            public class PxButtonCollection : PxControlCollection
            {

                public Button Save { get; }
                public Button Cancel { get; }

                public PxButtonCollection()
                {
                    Save = new Button("ctl00_phG_PanelSettings_pbClose", "Save", "ctl00_phG_PanelSettings_frmSettings");
                    Cancel = new Button("ctl00_phG_PanelSettings_pbCancel", "Cancel", "ctl00_phG_PanelSettings_frmSettings");
                }
            }
        }

        public class c_picklistofpicker_gridpickedws : Grid<c_picklistofpicker_gridpickedws.c_grid_row, c_picklistofpicker_gridpickedws.c_grid_header>
        {

            public PxToolBar ToolBar;

            public c_grid_filter FilterForm { get; }

            public c_picklistofpicker_gridpickedws(string locator, string name) :
                    base(locator, name)
            {
                ToolBar = new PxToolBar("ctl00_phG_tab_t0_gridPickedWS");
                DataMemberName = "PickListOfPicker";
                FilterForm = new c_grid_filter("ctl00_phG_tab_t0_gridPickedWS_fe_gf", "FilterForm");
            }

            public virtual void Refresh()
            {
                ToolBar.Refresh.Click();
            }

            public virtual void ReopenLineQty()
            {
                ToolBar.ReopenLineQty.Click();
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
                public ToolBarButtonGrid ReopenLineQty { get; }
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
                    Refresh = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_at_tlb div[data-cmd=\'Refresh\']", "Refresh", locator, null);
                    ReopenLineQty = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_at_tlb div[data-cmd=\'ReopenLineQty\']", "Proceed Picking", locator, null);
                    Adjust = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_at_tlb div[data-cmd=\'AdjustColumns\']", "Fit to Screen", locator, null);
                    Export = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_at_tlb div[data-cmd=\'ExportExcel\']", "Export to Excel", locator, null);
                    Hi = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_at_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                    PageFirst = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_ab_tlb div[data-cmd=\'PageFirst\']", "Go to First Page (Ctrl+PgUp)", locator, null);
                    PagePrev = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_ab_tlb div[data-cmd=\'PagePrev\']", "Go to Previous Page (PgUp)", locator, null);
                    PageNext = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_ab_tlb div[data-cmd=\'PageNext\']", "Go to Next Page (PgDn)", locator, null);
                    PageLast = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_ab_tlb div[data-cmd=\'PageLast\']", "Go to Last Page (Ctrl+PgDn)", locator, null);
                    Hi1 = new ToolBarButtonGrid("css=#ctl00_phG_tab_t0_gridPickedWS_ab_tlb div[data-cmd=\'hi\']", "Hi", locator, null);
                }
            }

            public class c_grid_row : GridRow
            {

                public CheckBox FitsWS { get; }
                public Selector SiteID { get; }
                public Selector LocationID { get; }
                public Selector InventoryID { get; }
                public PXTextEdit LotSerialNbr { get; }
                public DateSelector ExpireDate { get; }
                public PXNumberEdit PickedQty { get; }
                public PXNumberEdit Qty { get; }
                public Selector UOM { get; }
                public PXTextEdit ShipmentNbr { get; }
                public CheckBox ForceCompleted { get; }
                public Selector SOPickerToShipmentLink__ToteID { get; }
                public PXTextEdit WorksheetNbr { get; }
                public PXNumberEdit PickerNbr { get; }
                public PXNumberEdit EntryNbr { get; }

                public c_grid_row(c_picklistofpicker_gridpickedws grid) :
                        base(grid)
                {
                    FitsWS = new CheckBox("ctl00_phG_tab_t0_gridPickedWS", "Matched", grid.Locator, "FitsWS");
                    FitsWS.DataField = "FitsWS";
                    SiteID = new Selector("_ctl00_phG_tab_t0_gridPickedWS_lv0_edWSSiteID", "Warehouse", grid.Locator, "SiteID");
                    SiteID.DataField = "SiteID";
                    LocationID = new Selector("_ctl00_phG_tab_t0_gridPickedWS_lv0_edWSLocationID", "Location", grid.Locator, "LocationID");
                    LocationID.DataField = "LocationID";
                    InventoryID = new Selector("_ctl00_phG_tab_t0_gridPickedWS_lv0_edWSInventoryID", "Inventory ID", grid.Locator, "InventoryID");
                    InventoryID.DataField = "InventoryID";
                    LotSerialNbr = new PXTextEdit("_ctl00_phG_tab_t0_gridPickedWS_lv0_edWSLotSerialNbr", "Lot/Serial Nbr.", grid.Locator, "LotSerialNbr");
                    LotSerialNbr.DataField = "LotSerialNbr";
                    ExpireDate = new DateSelector("_ctl00_phG_tab_t0_gridPickedWS_lv0_edWSExpireDate", "Expiration Date", grid.Locator, "ExpireDate");
                    ExpireDate.DataField = "ExpireDate";
                    PickedQty = new PXNumberEdit("_ctl00_phG_tab_t0_gridPickedWS_lv0_PXWSPickedQty", "Picked Quantity", grid.Locator, "PickedQty");
                    PickedQty.DataField = "PickedQty";
                    Qty = new PXNumberEdit("_ctl00_phG_tab_t0_gridPickedWS_lv0_PXWSQty", "Quantity", grid.Locator, "Qty");
                    Qty.DataField = "Qty";
                    UOM = new Selector("_ctl00_phG_tab_t0_gridPickedWS_lv0_edWSUOM", "UOM", grid.Locator, "UOM");
                    UOM.DataField = "UOM";
                    ShipmentNbr = new PXTextEdit("ctl00_phG_tab_t0_gridPickedWS_ei", "Shipment Nbr.", grid.Locator, "ShipmentNbr");
                    ShipmentNbr.DataField = "ShipmentNbr";
                    ForceCompleted = new CheckBox("ctl00_phG_tab_t0_gridPickedWS", "Quantity Confirmed", grid.Locator, "ForceCompleted");
                    ForceCompleted.DataField = "ForceCompleted";
                    SOPickerToShipmentLink__ToteID = new Selector("_ctl00_phG_tab_t0_gridPickedWS_lv0_es", "Tote ID", grid.Locator, "SOPickerToShipmentLink__ToteID");
                    SOPickerToShipmentLink__ToteID.DataField = "SOPickerToShipmentLink__ToteID";
                    WorksheetNbr = new PXTextEdit("ctl00_phG_tab_t0_gridPickedWS_em", "Worksheet Nbr.", grid.Locator, "WorksheetNbr");
                    WorksheetNbr.DataField = "WorksheetNbr";
                    PickerNbr = new PXNumberEdit("ctl00_phG_tab_t0_gridPickedWS_en", "Picker Nbr.", grid.Locator, "PickerNbr");
                    PickerNbr.DataField = "PickerNbr";
                    EntryNbr = new PXNumberEdit("_ctl00_phG_tab_t0_gridPickedWS_lv0_edWSEntryNbr", "Entry Nbr.", grid.Locator, "EntryNbr");
                    EntryNbr.DataField = "EntryNbr";
                }
            }

            public class c_grid_header : GridHeader
            {

                public CheckBoxColumnFilter FitsWS { get; }
                public SelectorColumnFilter SiteID { get; }
                public SelectorColumnFilter LocationID { get; }
                public SelectorColumnFilter InventoryID { get; }
                public PXTextEditColumnFilter LotSerialNbr { get; }
                public DateSelectorColumnFilter ExpireDate { get; }
                public PXNumberEditColumnFilter PickedQty { get; }
                public PXNumberEditColumnFilter Qty { get; }
                public SelectorColumnFilter UOM { get; }
                public PXTextEditColumnFilter ShipmentNbr { get; }
                public CheckBoxColumnFilter ForceCompleted { get; }
                public SelectorColumnFilter SOPickerToShipmentLink__ToteID { get; }
                public PXTextEditColumnFilter WorksheetNbr { get; }
                public PXNumberEditColumnFilter PickerNbr { get; }
                public PXNumberEditColumnFilter EntryNbr { get; }

                public c_grid_header(c_picklistofpicker_gridpickedws grid) :
                        base(grid)
                {
                    FitsWS = new CheckBoxColumnFilter(grid.Row.FitsWS);
                    SiteID = new SelectorColumnFilter(grid.Row.SiteID);
                    LocationID = new SelectorColumnFilter(grid.Row.LocationID);
                    InventoryID = new SelectorColumnFilter(grid.Row.InventoryID);
                    LotSerialNbr = new PXTextEditColumnFilter(grid.Row.LotSerialNbr);
                    ExpireDate = new DateSelectorColumnFilter(grid.Row.ExpireDate);
                    PickedQty = new PXNumberEditColumnFilter(grid.Row.PickedQty);
                    Qty = new PXNumberEditColumnFilter(grid.Row.Qty);
                    UOM = new SelectorColumnFilter(grid.Row.UOM);
                    ShipmentNbr = new PXTextEditColumnFilter(grid.Row.ShipmentNbr);
                    ForceCompleted = new CheckBoxColumnFilter(grid.Row.ForceCompleted);
                    SOPickerToShipmentLink__ToteID = new SelectorColumnFilter(grid.Row.SOPickerToShipmentLink__ToteID);
                    WorksheetNbr = new PXTextEditColumnFilter(grid.Row.WorksheetNbr);
                    PickerNbr = new PXNumberEditColumnFilter(grid.Row.PickerNbr);
                    EntryNbr = new PXNumberEditColumnFilter(grid.Row.EntryNbr);
                }
            }
        }

        public class c_picklistofpicker_lv0 : Container
        {

            public PXNumberEdit EntryNbr { get; }
            public Label EntryNbrLabel { get; }
            public Selector InventoryID { get; }
            public Label InventoryIDLabel { get; }
            public Selector SiteID { get; }
            public Label SiteIDLabel { get; }
            public Selector LocationID { get; }
            public Label LocationIDLabel { get; }
            public PXTextEdit LotSerialNbr { get; }
            public Label LotSerialNbrLabel { get; }
            public DateSelector ExpireDate { get; }
            public Label ExpireDateLabel { get; }
            public PXNumberEdit PickedQty { get; }
            public Label PickedQtyLabel { get; }
            public PXNumberEdit PackedQty { get; }
            public Label PackedQtyLabel { get; }
            public PXNumberEdit Qty { get; }
            public Label QtyLabel { get; }
            public Selector UOM { get; }
            public Label UOMLabel { get; }
            public Selector Es { get; }
            public Label EsLabel { get; }

            public c_picklistofpicker_lv0(string locator, string name) :
                    base(locator, name)
            {
                EntryNbr = new PXNumberEdit("ctl00_phG_tab_t0_gridPickedWS_lv0_edWSEntryNbr", "Entry Nbr.", locator, null);
                EntryNbrLabel = new Label(EntryNbr);
                EntryNbr.DataField = "EntryNbr";
                InventoryID = new Selector("ctl00_phG_tab_t0_gridPickedWS_lv0_edWSInventoryID", "Inventory ID", locator, null);
                InventoryIDLabel = new Label(InventoryID);
                InventoryID.DataField = "InventoryID";
                SiteID = new Selector("ctl00_phG_tab_t0_gridPickedWS_lv0_edWSSiteID", "Warehouse", locator, null);
                SiteIDLabel = new Label(SiteID);
                SiteID.DataField = "SiteID";
                LocationID = new Selector("ctl00_phG_tab_t0_gridPickedWS_lv0_edWSLocationID", "Location", locator, null);
                LocationIDLabel = new Label(LocationID);
                LocationID.DataField = "LocationID";
                LotSerialNbr = new PXTextEdit("ctl00_phG_tab_t0_gridPickedWS_lv0_edWSLotSerialNbr", "Lot/Serial Nbr.", locator, null);
                LotSerialNbrLabel = new Label(LotSerialNbr);
                LotSerialNbr.DataField = "LotSerialNbr";
                ExpireDate = new DateSelector("ctl00_phG_tab_t0_gridPickedWS_lv0_edWSExpireDate", "Expiration Date", locator, null);
                ExpireDateLabel = new Label(ExpireDate);
                ExpireDate.DataField = "ExpireDate";
                PickedQty = new PXNumberEdit("ctl00_phG_tab_t0_gridPickedWS_lv0_PXWSPickedQty", "Picked Quantity", locator, null);
                PickedQtyLabel = new Label(PickedQty);
                PickedQty.DataField = "PickedQty";
                PackedQty = new PXNumberEdit("ctl00_phG_tab_t0_gridPickedWS_lv0_PXWSPackedQty", "Packed Qty", locator, null);
                PackedQtyLabel = new Label(PackedQty);
                PackedQty.DataField = "PackedQty";
                Qty = new PXNumberEdit("ctl00_phG_tab_t0_gridPickedWS_lv0_PXWSQty", "Quantity", locator, null);
                QtyLabel = new Label(Qty);
                Qty.DataField = "Qty";
                UOM = new Selector("ctl00_phG_tab_t0_gridPickedWS_lv0_edWSUOM", "UOM", locator, null);
                UOMLabel = new Label(UOM);
                UOM.DataField = "UOM";
                Es = new Selector("ctl00_phG_tab_t0_gridPickedWS_lv0_es", "Es", locator, null);
                EsLabel = new Label(Es);
                DataMemberName = "PickListOfPicker";
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
