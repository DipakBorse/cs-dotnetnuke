using System;
using System.Diagnostics;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace DotNetNuke.Modules.SearchResults
{
    /// Namespace:  DotNetNuke.Modules.SearchResults
    /// Project:    DotNetNuke.SearchResults
    /// Class:      ResultsSettings
    /// <summary>
    /// The ResultsSettings ModuleSettingsBase is used to manage the
    /// settings for the Search Results Module
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// </remarks>
    /// <history>
    ///		[cnurse]	11/11/2004	created
    /// </history>
    public partial class ResultsSettings : ModuleSettingsBase
    {
        /// <summary>
        /// LoadSettings loads the settings from the Databas and displays them
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        ///		[cnurse]	11/11/2004	created
        /// </history>
        public override void LoadSettings()
        {
            try
            {
                if( Page.IsPostBack == false )
                {
                    if( Convert.ToString( TabModuleSettings["maxresults"] ) != "" )
                    {
                        txtresults.Text = Convert.ToString( TabModuleSettings["maxresults"] );
                    }
                    else
                    {
                        txtresults.Text = "";
                    }
                    if( Convert.ToString( TabModuleSettings["perpage"] ) != "" )
                    {
                        txtPage.Text = Convert.ToString( TabModuleSettings["perpage"] );
                    }
                    else
                    {
                        txtPage.Text = "";
                    }
                    if( Convert.ToString( TabModuleSettings["titlelength"] ) != "" )
                    {
                        txtTitle.Text = Convert.ToString( TabModuleSettings["titlelength"] );
                    }
                    else
                    {
                        txtTitle.Text = "";
                    }
                    if( Convert.ToString( TabModuleSettings["descriptionlength"] ) != "" )
                    {
                        txtdescription.Text = Convert.ToString( TabModuleSettings["descriptionlength"] );
                    }
                    else
                    {
                        txtdescription.Text = "";
                    }
                    chkDescription.Checked = false;
                    if( Convert.ToString( TabModuleSettings["showdescription"] ) != "" )
                    {
                        if( Convert.ToString( TabModuleSettings["showdescription"] ) == "Y" )
                        {
                            chkDescription.Checked = true;
                        }
                    }
                }
            }
            catch( Exception exc ) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException( this, exc );
            }
        }

        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        ///		[cnurse]	11/11/2004	created
        /// </history>
        public override void UpdateSettings()
        {
            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateTabModuleSetting( TabModuleId, "maxresults", txtresults.Text );
                objModules.UpdateTabModuleSetting( TabModuleId, "perpage", txtPage.Text );
                objModules.UpdateTabModuleSetting( TabModuleId, "titlelength", txtTitle.Text );
                objModules.UpdateTabModuleSetting( TabModuleId, "descriptionlength", txtdescription.Text );
                objModules.UpdateTabModuleSetting( TabModuleId, "showdescription", Convert.ToString( chkDescription.Checked ? "Y" : "N" ) );
            }
            catch( Exception exc ) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException( this, exc );
            }
        }

        //This call is required by the Web Form Designer.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
        }

        protected void Page_Init( Object sender, EventArgs e )
        {
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
        }
    }
}