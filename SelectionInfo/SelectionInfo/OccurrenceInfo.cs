using System.ComponentModel;
using Inventor;

namespace SelectionInfo
{
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
}