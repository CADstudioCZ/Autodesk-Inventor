using System;
using System.ComponentModel;
using Inventor;

namespace SelectionInfo
{
    /// <summary>
    /// This class is responible for converting selected object to
    /// <para>object displayed in PropertyGrid</para>
    /// </summary>
    static class SelectionInfoSelector
    {
        /// <summary>
        /// Gets the object which contains information about <paramref name="selectedEntity"/>.
        /// </summary>
        /// <param name="selectedEntity">The selected entity.</param>
        /// <returns>Returns object with inforamtions about <paramref name="selectedEntity"/> when possible. Otherwise returns null.</returns>
        public static object GetSelectionInfo(object selectedEntity)
        {
            switch (selectedEntity)
            {
                case ComponentOccurrence occ:
                    return new OccurrenceInfo(occ);
                case PartComponentDefinition partDef:
                    return new DocumentInfo(partDef.Document as Document);
                case AssemblyComponentDefinition asmDef:
                    return new DocumentInfo(asmDef.Document as Document);
                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// This class extends <see cref="DocumentInfo"/> with informations specific for ComponentOccurrence.
    /// </summary>
    /// <seealso cref="SelectionInfo.DocumentInfo" />
    class OccurrenceInfo : DocumentInfo
    {
        private readonly ComponentOccurrence occurrence;

        /// <summary>
        /// Initializes a new instance of the <see cref="OccurrenceInfo"/> class.
        /// </summary>
        /// <param name="occurrence">The occurrence.</param>
        public OccurrenceInfo(ComponentOccurrence occurrence) : base(occurrence.Definition.Document as Document)
        {
            this.occurrence = occurrence;
        }

        /// <summary>
        /// Gets or sets the display name of the occurrence.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        [Category("Occurrence")]
        public string DisplayName
        {
            get => occurrence.Name;
            set => occurrence.Name = value;
        }
    }


    /// <summary>
    /// This clas contains informations about Document
    /// </summary>
    class DocumentInfo
    {
        private readonly Document document;
        protected string DesignTrackingProperties = "{32853F0F-3444-11D1-9E93-0060B03C1CA6}";

        protected string InventorDocumentSummaryInformation = "{D5CDD502-2E9C-101B-9397-08002B2CF9AE}";

        //PropertySet internal names
        protected string InventorSummaryInformation = "{F29F85E0-4FF9-1068-AB91-08002B27B3D9}";
        protected string InventorUserDefinedProperties = "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}";
        private DocumentiProperties iProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentInfo"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        public DocumentInfo(Document document)
        {
            this.document = document;
            iProperties = new DocumentiProperties(document);
        }

        /// <summary>
        /// Gets the model surface area in database units [cm2].
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        [Category("Physical")]
        public double Area => MassProperties(document)?.Area ?? double.NaN;

        /// <summary>
        /// Gets or sets the description iProperty value.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Category("iProperties")]
        public string Description
        {
            get =>
                document.PropertySets[DesignTrackingProperties]["Description"].Value.ToString();
            set => document.PropertySets[DesignTrackingProperties]["Description"].Value =
                value ?? "";
        }

        /// <summary>
        /// Gets the model mass in database units [g].
        /// </summary>
        /// <value>
        /// The mass.
        /// </value>
        [Category("Physical")]
        public double Mass => MassProperties(document)?.Mass ?? double.NaN;

        /// <summary>
        /// Gets or sets the part number iProperty value.
        /// </summary>
        /// <value>
        /// The part number.
        /// </value>
        [Category("iProperties")]
        public string PartNumber
        {
            get =>
                document.PropertySets[DesignTrackingProperties]["Part Number"].Value.ToString();
            set => document.PropertySets[DesignTrackingProperties]["Part Number"].Value =
                value ?? "";
        }

        public object Title => iProperties.Title;
        //public DateTime CreationTime
        //{
        //    get { return iProperties.CreationTime; }
        //    set { iProperties.CreationTime = value; }
        //}

        /// <summary>
        /// Gets the mass properties for part or assembly document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Returns MassProperties for PartDocument os AssemblyDocument. Otherwise returns null.</returns>
        private static MassProperties MassProperties(Document document)
        {
            if (document is AssemblyDocument asm)
                return asm.ComponentDefinition.MassProperties;
            if (document is PartDocument part)
                return part.ComponentDefinition.MassProperties;
            return null;
        }
    }
}