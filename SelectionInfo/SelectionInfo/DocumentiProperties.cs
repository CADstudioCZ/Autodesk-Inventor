using System;
using Inventor;

namespace SelectionInfo
{
    /// <summary>
    /// Provides access to standard iProperties in the inventor document.
    /// </summary>
    class DocumentiProperties
    {
        public const string InventorSummaryInformation = "{F29F85E0-4FF9-1068-AB91-08002B27B3D9}";
        public const string InventorDocumentSummaryInformation = "{D5CDD502-2E9C-101B-9397-08002B2CF9AE}";
        public const string DesignTrackingProperties = "{32853F0F-3444-11D1-9E93-0060B03C1CA6}";
        public const string InventorUserDefinedProperties = "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}";
        private readonly Document document;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentiProperties"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        public DocumentiProperties(Document document)
        {
            this.document = document;
        }

        public string Author
        {
            get => AuthorProperty.Value.ToString();
            set => AuthorProperty.Value = value;
        }

        public string Authority
        {
            get => AuthorityProperty.Value.ToString();
            set => AuthorityProperty.Value = value;
        }

        public string CatalogWebLink
        {
            get => CatalogWebLinkProperty.Value.ToString();
            set => CatalogWebLinkProperty.Value = value;
        }

        public string Categories
        {
            get => CategoriesProperty.Value.ToString();
            set => CategoriesProperty.Value = value;
        }

        public string Category
        {
            get => CategoryProperty.Value.ToString();
            set => CategoryProperty.Value = value;
        }

        public string Comments
        {
            get => CommentsProperty.Value.ToString();
            set => CommentsProperty.Value = value;
        }

        public string Company
        {
            get => CompanyProperty.Value.ToString();
            set => CompanyProperty.Value = value;
        }

        public double Cost
        {
            get => (double) CostProperty.Value;
            set => CostProperty.Value = value;
        }

        public string CostCenter
        {
            get => CostCenterProperty.Value.ToString();
            set => CostCenterProperty.Value = value;
        }

        public DateTime CreationTime
        {
            get => (DateTime) CreationTimeProperty.Value;
            set => CreationTimeProperty.Value = value;
        }

        public DateTime DateChecked
        {
            get => (DateTime) DateCheckedProperty.Value;
            set => DateCheckedProperty.Value = value;
        }

        public string DeferUpdates
        {
            get => DeferUpdatesProperty.Value.ToString();
            //set => DeferUpdatesProperty.Value = value;
        }

        public string Density
        {
            get => DensityProperty.Value.ToString();
            //set => DensityProperty.Value = value;
        }

        public string Description
        {
            get => DescriptionProperty.Value.ToString();
            set => DescriptionProperty.Value = value;
        }

        public string Designer
        {
            get => DesignerProperty.Value.ToString();
            set => DesignerProperty.Value = value;
        }

        public string DesignStatus
        {
            get => DesignStatusProperty.Value.ToString();
            //set => DesignStatusProperty.Value = value;
        }

        public string DocumentSubType
        {
            get => DocumentSubTypeProperty.Value.ToString();
            //set => DocumentSubTypeProperty.Value = value;
        }

        public string DocumentSubTypeName
        {
            get => DocumentSubTypeNameProperty.Value.ToString();
            //set => DocumentSubTypeNameProperty.Value = value;
        }

        public string Engineer
        {
            get => EngineerProperty.Value.ToString();
            set => EngineerProperty.Value = value;
        }

        public string EngrApprovedBy
        {
            get => EngrApprovedByProperty.Value.ToString();
            set => EngrApprovedByProperty.Value = value;
        }

        public DateTime EngrDateApproved
        {
            get => (DateTime) EngrDateApprovedProperty.Value;
            set => EngrDateApprovedProperty.Value = value;
        }

        public string ExternalPropertyRevisionId
        {
            get => ExternalPropertyRevisionIdProperty.Value.ToString();
            //set => ExternalPropertyRevisionIdProperty.Value = value;
        }

        public string FlatPatternArea
        {
            get => FlatPatternAreaProperty.Value.ToString();
            //set => FlatPatternAreaProperty.Value = value;
        }

        public string FlatPatternLength
        {
            get => FlatPatternLengthProperty.Value.ToString();
            //set => FlatPatternLengthProperty.Value = value;
        }

        public string FlatPatternWidth
        {
            get => FlatPatternWidthProperty.Value.ToString();
            //set => FlatPatternWidthProperty.Value = value;
        }

        public string CheckedBy
        {
            get => CheckedByProperty.Value.ToString();
            set => CheckedByProperty.Value = value;
        }

        public string Keywords
        {
            get => KeywordsProperty.Value.ToString();
            set => KeywordsProperty.Value = value;
        }

        public string Language
        {
            get => LanguageProperty.Value.ToString();
            //set => LanguageProperty.Value = value;
        }

        public string LastSavedBy
        {
            get => LastSavedByProperty.Value.ToString();
            //set => LastSavedByProperty.Value = value;
        }

        public string LastUpdatedWith
        {
            get => LastUpdatedWithProperty.Value.ToString();
            //set => LastUpdatedWithProperty.Value = value;
        }

        public string Manager
        {
            get => ManagerProperty.Value.ToString();
            set => ManagerProperty.Value = value;
        }

        public string Manufacturer
        {
            get => ManufacturerProperty.Value.ToString();
            set => ManufacturerProperty.Value = value;
        }

        public string Mass
        {
            get => MassProperty.Value.ToString();
            //set => MassProperty.Value = value;
        }

        public string Material
        {
            get => MaterialProperty.Value.ToString();
            //set => MaterialProperty.Value = value;
        }

        public string MfgApprovedBy
        {
            get => MfgApprovedByProperty.Value.ToString();
            set => MfgApprovedByProperty.Value = value;
        }

        public DateTime MfgDateApproved
        {
            get => (DateTime) MfgDateApprovedProperty.Value;
            set => MfgDateApprovedProperty.Value = value;
        }

        public string ParameterizedTemplate
        {
            get => ParameterizedTemplateProperty.Value.ToString();
            //set => ParameterizedTemplateProperty.Value = value;
        }

        public string PartNumber
        {
            get => PartNumberProperty.Value.ToString();
            set => PartNumberProperty.Value = value;
        }

        public string PartPropertyRevisionId
        {
            get => PartPropertyRevisionIdProperty.Value.ToString();
            //set => PartPropertyRevisionIdProperty.Value = value;
        }

        public string Project
        {
            get => ProjectProperty.Value.ToString();
            set => ProjectProperty.Value = value;
        }

        public string ProxyRefreshDate
        {
            get => ProxyRefreshDateProperty.Value.ToString();
            //set => ProxyRefreshDateProperty.Value = value;
        }

        public string RevisionNumber
        {
            get => RevisionNumberProperty.Value.ToString();
            set => RevisionNumberProperty.Value = value;
        }

        public string SheetMetalArea
        {
            get => SheetMetalAreaProperty.Value.ToString();
            //set => SheetMetalAreaProperty.Value = value;
        }

        public string SheetMetalLength
        {
            get => SheetMetalLengthProperty.Value.ToString();
            //set => SheetMetalLengthProperty.Value = value;
        }

        public string SheetMetalRule
        {
            get => SheetMetalRuleProperty.Value.ToString();
            //set => SheetMetalRuleProperty.Value = value;
        }

        public string SheetMetalWidth
        {
            get => SheetMetalWidthProperty.Value.ToString();
            //set => SheetMetalWidthProperty.Value = value;
        }

        public string SizeDesignation
        {
            get => SizeDesignationProperty.Value.ToString();
            set => SizeDesignationProperty.Value = value;
        }

        public string Standard
        {
            get => StandardProperty.Value.ToString();
            set => StandardProperty.Value = value;
        }

        public string StandardRevision
        {
            get => StandardRevisionProperty.Value.ToString();
            set => StandardRevisionProperty.Value = value;
        }

        public string StandardsOrganization
        {
            get => StandardsOrganizationProperty.Value.ToString();
            set => StandardsOrganizationProperty.Value = value;
        }

        public string StockNumber
        {
            get => StockNumberProperty.Value.ToString();
            set => StockNumberProperty.Value = value;
        }

        public string Subject
        {
            get => SubjectProperty.Value.ToString();
            set => SubjectProperty.Value = value;
        }

        public string SurfaceArea
        {
            get => SurfaceAreaProperty.Value.ToString();
            //set => SurfaceAreaProperty.Value = value;
        }

        public string TemplateRow
        {
            get => TemplateRowProperty.Value.ToString();
            //set => TemplateRowProperty.Value = value;
        }

        public string Title
        {
            get => TitleProperty.Value.ToString();
            set => TitleProperty.Value = value;
        }

        public string UserStatus
        {
            get => UserStatusProperty.Value.ToString();
            //set => UserStatusProperty.Value = value;
        }

        public string ValidMassProps
        {
            get => ValidMassPropsProperty.Value.ToString();
            //set => ValidMassPropsProperty.Value = value;
        }

        public string Vendor
        {
            get => VendorProperty.Value.ToString();
            set => VendorProperty.Value = value;
        }

        public string Volume
        {
            get => VolumeProperty.Value.ToString();
            //set => VolumeProperty.Value = value;
        }

        public string WeldMaterial
        {
            get => WeldMaterialProperty.Value.ToString();
            //set => WeldMaterialProperty.Value = value;
        }

        /// <summary>
        /// Gets value of the user defined iProperty with given name.
        /// </summary>
        /// <param name="name">The iProperty name.</param>
        /// <returns>Gets value of the user defined iProperty with given name.</returns>
        public object UserDefined(string name)
        {
            return document.PropertySets[InventorUserDefinedProperties][name].Value;
        }

        /// <summary>
        /// Sets value of the user defined iProperty with given name.
        /// </summary>
        /// <param name="name">The iProperty name.</param>
        /// <param name="value">The iProperty value.</param>
        public void UserDefined(string name, object value)
        {
            document.PropertySets[InventorUserDefinedProperties][name].Value = value;
        }


        #region Default iProperties

        Property TitleProperty => document.PropertySets[InventorSummaryInformation]["Title"];
        Property SubjectProperty => document.PropertySets[InventorSummaryInformation]["Subject"];
        Property AuthorProperty => document.PropertySets[InventorSummaryInformation]["Author"];
        Property KeywordsProperty => document.PropertySets[InventorSummaryInformation]["Keywords"];
        Property CommentsProperty => document.PropertySets[InventorSummaryInformation]["Comments"];
        Property LastSavedByProperty => document.PropertySets[InventorSummaryInformation]["Last Saved By"];

        Property RevisionNumberProperty => document.PropertySets[InventorSummaryInformation]["Revision Number"];

        //Property Property => document.PropertySets[InventorSummaryInformation]["Thumbnail"];
        Property CategoryProperty => document.PropertySets[InventorDocumentSummaryInformation]["Category"];
        Property ManagerProperty => document.PropertySets[InventorDocumentSummaryInformation]["Manager"];
        Property CompanyProperty => document.PropertySets[InventorDocumentSummaryInformation]["Company"];
        Property CreationTimeProperty => document.PropertySets[DesignTrackingProperties]["Creation Time"];
        Property PartNumberProperty => document.PropertySets[DesignTrackingProperties]["Part Number"];
        Property ProjectProperty => document.PropertySets[DesignTrackingProperties]["Project"];
        Property CostCenterProperty => document.PropertySets[DesignTrackingProperties]["Cost Center"];
        Property CheckedByProperty => document.PropertySets[DesignTrackingProperties]["Checked By"];
        Property DateCheckedProperty => document.PropertySets[DesignTrackingProperties]["Date Checked"];
        Property EngrApprovedByProperty => document.PropertySets[DesignTrackingProperties]["Engr Approved By"];
        Property EngrDateApprovedProperty => document.PropertySets[DesignTrackingProperties]["Engr Date Approved"];
        Property UserStatusProperty => document.PropertySets[DesignTrackingProperties]["User Status"];
        Property MaterialProperty => document.PropertySets[DesignTrackingProperties]["Material"];

        Property PartPropertyRevisionIdProperty =>
            document.PropertySets[DesignTrackingProperties]["Part Property Revision Id"];

        Property CatalogWebLinkProperty => document.PropertySets[DesignTrackingProperties]["Catalog Web Link"];

        //Property PartIconProperty => document.PropertySets[DesignTrackingProperties]["Part Icon"];
        Property DescriptionProperty => document.PropertySets[DesignTrackingProperties]["Description"];
        Property VendorProperty => document.PropertySets[DesignTrackingProperties]["Vendor"];
        Property DocumentSubTypeProperty => document.PropertySets[DesignTrackingProperties]["Document SubType"];

        Property DocumentSubTypeNameProperty =>
            document.PropertySets[DesignTrackingProperties]["Document SubType Name"];

        Property ProxyRefreshDateProperty => document.PropertySets[DesignTrackingProperties]["Proxy Refresh Date"];
        Property MfgApprovedByProperty => document.PropertySets[DesignTrackingProperties]["Mfg Approved By"];
        Property MfgDateApprovedProperty => document.PropertySets[DesignTrackingProperties]["Mfg Date Approved"];
        Property CostProperty => document.PropertySets[DesignTrackingProperties]["Cost"];
        Property StandardProperty => document.PropertySets[DesignTrackingProperties]["Standard"];
        Property DesignStatusProperty => document.PropertySets[DesignTrackingProperties]["Design Status"];
        Property DesignerProperty => document.PropertySets[DesignTrackingProperties]["Designer"];
        Property EngineerProperty => document.PropertySets[DesignTrackingProperties]["Engineer"];
        Property AuthorityProperty => document.PropertySets[DesignTrackingProperties]["Authority"];

        Property ParameterizedTemplateProperty =>
            document.PropertySets[DesignTrackingProperties]["Parameterized Template"];

        Property TemplateRowProperty => document.PropertySets[DesignTrackingProperties]["Template Row"];

        Property ExternalPropertyRevisionIdProperty =>
            document.PropertySets[DesignTrackingProperties]["External Property Revision Id"];

        Property StandardRevisionProperty => document.PropertySets[DesignTrackingProperties]["Standard Revision"];
        Property ManufacturerProperty => document.PropertySets[DesignTrackingProperties]["Manufacturer"];

        Property StandardsOrganizationProperty =>
            document.PropertySets[DesignTrackingProperties]["Standards Organization"];

        Property LanguageProperty => document.PropertySets[DesignTrackingProperties]["Language"];
        Property DeferUpdatesProperty => document.PropertySets[DesignTrackingProperties]["Defer Updates"];
        Property SizeDesignationProperty => document.PropertySets[DesignTrackingProperties]["Size Designation"];
        Property CategoriesProperty => document.PropertySets[DesignTrackingProperties]["Categories"];
        Property StockNumberProperty => document.PropertySets[DesignTrackingProperties]["Stock Number"];
        Property WeldMaterialProperty => document.PropertySets[DesignTrackingProperties]["Weld Material"];
        Property MassProperty => document.PropertySets[DesignTrackingProperties]["Mass"];
        Property SurfaceAreaProperty => document.PropertySets[DesignTrackingProperties]["SurfaceArea"];
        Property VolumeProperty => document.PropertySets[DesignTrackingProperties]["Volume"];
        Property DensityProperty => document.PropertySets[DesignTrackingProperties]["Density"];
        Property ValidMassPropsProperty => document.PropertySets[DesignTrackingProperties]["Valid MassProps"];
        Property FlatPatternWidthProperty => document.PropertySets[DesignTrackingProperties]["Flat Pattern Width"];
        Property FlatPatternLengthProperty => document.PropertySets[DesignTrackingProperties]["Flat Pattern Length"];
        Property FlatPatternAreaProperty => document.PropertySets[DesignTrackingProperties]["Flat Pattern Area"];
        Property SheetMetalRuleProperty => document.PropertySets[DesignTrackingProperties]["Sheet Metal Rule"];
        Property LastUpdatedWithProperty => document.PropertySets[DesignTrackingProperties]["Last Updated With"];
        Property SheetMetalWidthProperty => document.PropertySets[DesignTrackingProperties]["Sheet Metal Width"];
        Property SheetMetalLengthProperty => document.PropertySets[DesignTrackingProperties]["Sheet Metal Length"];
        Property SheetMetalAreaProperty => document.PropertySets[DesignTrackingProperties]["Sheet Metal Area"];
        Property MaterialIdentifierProperty => document.PropertySets[DesignTrackingProperties]["Material Identifier"];
        Property AppearanceProperty => document.PropertySets[DesignTrackingProperties]["Appearance"];

        Property FlatPatternDeferUpdateProperty =>
            document.PropertySets[DesignTrackingProperties]["Flat Pattern Defer Update"];

        #endregion
    }
}