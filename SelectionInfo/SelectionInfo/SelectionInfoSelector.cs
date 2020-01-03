using System;
using System.Windows.Forms;
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
}