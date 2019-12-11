using System.ComponentModel;
using Inventor;

namespace SelectionInfo
{
    static class SelectionInfoSelector
    {
        public static object GetSelectionInfo(object selectedEntity)
        {
            if (selectedEntity is ComponentOccurrence occ)
                return new OccurrenceInfo(occ);

            if (selectedEntity is PartComponentDefinition partDef)
                return new DocumentInfo(partDef.Document as Document);

            if (selectedEntity is AssemblyComponentDefinition asmDef)
                return new DocumentInfo(asmDef.Document as Document);
            
            //else
            return null;
        }
    }

    class OccurrenceInfo : DocumentInfo
    {
        private readonly ComponentOccurrence occurrence;

        public OccurrenceInfo(ComponentOccurrence occurrence) : base(occurrence.Definition.Document as Document)
        {
            this.occurrence = occurrence;
        }

        public string DisplayName { get => occurrence.Name; set => occurrence.Name = value; }

    }


    class DocumentInfo
    {
        protected string InventorSummaryInformation = "{F29F85E0-4FF9-1068-AB91-08002B27B3D9}";
        protected string InventorDocumentSummaryInformation = "{D5CDD502-2E9C-101B-9397-08002B2CF9AE}";
        protected string DesignTrackingProperties = "{32853F0F-3444-11D1-9E93-0060B03C1CA6}";
        protected string InventorUserDefinedProperties = "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}";
        
        private readonly Document document;

        public DocumentInfo(Document document)
        {
            this.document = document;
        }

        [Category("Physical")]
        public double Area => MassProperties(document)?.Area ?? double.NaN;

        [Category("iProperties")]
        public string Description
        {
            get =>
                document.PropertySets[DesignTrackingProperties]["Description"].Value.ToString();
            set => document.PropertySets[DesignTrackingProperties]["Description"].Value =
                value ?? "";
        }

        [Category("Physical")]
        public double Mass => MassProperties(document)?.Mass ?? double.NaN;

        [Category("iProperties")]
        public string PartNumber
        {
            get =>
                document.PropertySets[DesignTrackingProperties]["Part Number"].Value.ToString();
            set => document.PropertySets[DesignTrackingProperties]["Part Number"].Value =
                value ?? "";
        }

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
