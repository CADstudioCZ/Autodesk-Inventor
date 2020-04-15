using System;
using Inventor;

namespace SelectionInfo
{
    /// <summary>
    /// Provides information about the physical properties of parts and assemblies.
    /// </summary>
    class PhysicalProperties
    {
        private readonly Document document;

        private readonly Application inventor;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalProperties"/> class.
        /// </summary>
        /// <param name="document">An Inventor.PartDocument or Inventor.AssemblyDocument object.</param>
        public PhysicalProperties(Document document)
        {
            this.document = document;
            inventor = document.DocumentEvents.Application as Application;
        }

        /// <summary>
        /// Returns area of the model in the document.
        /// </summary>
        /// <param name="units">The area units as a string (e.g."m^2", "mm*mm", etc). If not specified, database units [cm^2] are used.</param>
        /// <returns>Returns area of the model in the document.</returns>
        public double Area(object units = null)
        {
            double area = MassProperties(document)?.Area ?? double.NaN;
            return units == null ? area : inventor.UnitsOfMeasure.ConvertUnits(area, "cm^2", units);
        }

        /// <summary>
        /// Returns mass of the model in the document.
        /// </summary>
        /// <param name="units">The mass units as a UnitsTypeEnum or a string (e.g. "kg", "lbmass", etc.). If not specified, database units [g] are used.</param>
        /// <returns>Returns mass of the model in the document</returns>
        public double Mass(object units = null)
        {
            double mass = MassProperties(document)?.Mass ?? double.NaN;
            return units == null
                ? mass
                : inventor.UnitsOfMeasure.ConvertUnits(mass, UnitsTypeEnum.kDatabaseMassUnits, units);
        }

        /// <summary>
        /// Returns volume of the model in the document.
        /// </summary>
        /// <param name="units">The volume units as a string (e.g. "m^3", "mm*mm*mm", etc). If not specified, database units [cm^3] are used.</param>
        /// <returns>Returns volume of the model in the document.</returns>
        public double Volume(object units = null)
        {
            double volume = MassProperties(document)?.Volume ?? double.NaN;
            return units == null ? volume : inventor.UnitsOfMeasure.ConvertUnits(volume, "cm^3", units);
        }

        /// <summary>
        /// Gets the mass properties for part or assembly document.
        /// </summary>
        /// <param name="document">A PartDocument or AssemblyDocument object.</param>
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