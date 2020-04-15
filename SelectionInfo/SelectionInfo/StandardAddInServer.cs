using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Inventor;
using Microsoft.Win32;

namespace SelectionInfo
{
    /// <summary>
    /// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
    /// that all Inventor AddIns are required to implement. The communication between Inventor and
    /// the AddIn is via the methods on this interface.
    /// </summary>
    [GuidAttribute("25119a9c-3557-4ed2-9bec-e184a99835f3")]
    public class StandardAddInServer : Inventor.ApplicationAddInServer
    {
        private ApplicationEvents applicationEvents;
        private string ClientId = "{25119A9C-3557-4ED2-9BEC-E184A99835F3}";

        // Inventor application object.
        private Inventor.Application inventor;

        private DockableWindow selectionInfoWnd;
        private PropertyGrid selectionPropertyGrid;
        private UserInputEvents userInputEvents;


        public StandardAddInServer()
        {
        }

        /// <summary>
        /// Gets or sets the selected object for display properties.
        /// </summary>
        /// <value>
        /// The selected object.
        /// </value>
        private object SelectedObject
        {
            get => selectionPropertyGrid?.SelectedObject;
            set
            {
                if (selectionPropertyGrid != null)
                    selectionPropertyGrid.SelectedObject = value;
            }
        }

        /// <summary>
        /// Handle when a document is deactivated [deselected].
        /// </summary>
        /// <param name="DocumentObject"></param>
        /// <param name="BeforeOrAfter"></param>
        /// <param name="Context"></param>
        /// <param name="HandlingCode"></param>
        private void ApplicationEvents_OnDeactivateDocument(_Document DocumentObject, EventTimingEnum BeforeOrAfter,
            NameValueMap Context, out HandlingCodeEnum HandlingCode)
        {
            HandlingCode = HandlingCodeEnum.kEventNotHandled;
            if (BeforeOrAfter != EventTimingEnum.kBefore)
                return;

            SelectedObject = null;
        }

        /// <summary>
        /// Handle when a document is selected by the user.
        /// </summary>
        /// <param name="JustSelectedEntities"></param>
        /// <param name="MoreSelectedEntities"></param>
        /// <param name="SelectionDevice"></param>
        /// <param name="ModelPosition"></param>
        /// <param name="ViewPosition"></param>
        /// <param name="View"></param>
        private void UserInputEvents_OnSelect(ObjectsEnumerator JustSelectedEntities,
            ref ObjectCollection MoreSelectedEntities, SelectionDeviceEnum SelectionDevice, Point ModelPosition,
            Point2d ViewPosition, Inventor.View View)
        {
            if (JustSelectedEntities.Count > 0)
            {
                var selectedEntity = JustSelectedEntities[1];
                selectedEntity = SelectionInfoSelector.GetSelectionInfo(selectedEntity);

                SelectedObject = selectedEntity;
            }
        }

        #region ApplicationAddInServer Members

        public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime)
        {
            // This method is called by Inventor when it loads the addin.
            // The AddInSiteObject provides access to the Inventor Application object.
            // The FirstTime flag indicates if the addin is loaded for the first time.

            // Initialize AddIn members.
            inventor = addInSiteObject.Application;

            //Create dockable window
            selectionInfoWnd = inventor.UserInterfaceManager.DockableWindows.Add(ClientId,
                "SelectionInfo.StandardAddInServer.selectionInfoWnd", "Selection");
            selectionInfoWnd.ShowVisibilityCheckBox = true;

            //Create propertyGrig control
            selectionPropertyGrid = new PropertyGrid();

            //Add propertyGrid to dockable window
            selectionInfoWnd.AddChild(selectionPropertyGrid.Handle);

            //Setup event handlers
            userInputEvents = inventor.CommandManager.UserInputEvents;
            userInputEvents.OnSelect += UserInputEvents_OnSelect;

            applicationEvents = inventor.ApplicationEvents;
            applicationEvents.OnDeactivateDocument += ApplicationEvents_OnDeactivateDocument;
        }

        public void Deactivate()
        {
            // This method is called by Inventor when the AddIn is unloaded.
            // The AddIn will be unloaded either manually by the user or
            // when the Inventor session is terminated

            //Remove event handlers
            userInputEvents.OnSelect -= UserInputEvents_OnSelect;
            applicationEvents.OnDeactivateDocument -= ApplicationEvents_OnDeactivateDocument;

            //Cleanup selectionPropertyGrid
            SelectedObject = null;
            selectionPropertyGrid = null;

            // Release objects.
            applicationEvents = null;
            userInputEvents = null;
            inventor = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ExecuteCommand(int commandID)
        {
            // Note:this method is now obsolete, you should use the 
            // ControlDefinition functionality for implementing commands.
        }

        public object Automation
        {
            // This property is provided to allow the AddIn to expose an API 
            // of its own to other programs. Typically, this  would be done by
            // implementing the AddIn's API interface in a class and returning 
            // that class object through this property.

            get
            {
                // TODO: Add ApplicationAddInServer.Automation getter implementation
                return null;
            }
        }

        #endregion
    }
}