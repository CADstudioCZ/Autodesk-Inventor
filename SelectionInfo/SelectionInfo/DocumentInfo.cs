using System.ComponentModel;
using Inventor;

namespace SelectionInfo
{
    /// <summary>
    /// This clas contains informations about Document
    /// </summary>
    class DocumentInfo
    {
        private readonly Document document;
        private readonly DocumentiProperties iProperties;
        private readonly PhysicalProperties physicalProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentInfo"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        public DocumentInfo(Document document)
        {
            this.document = document;
            iProperties = new DocumentiProperties(document);
            physicalProperties = new PhysicalProperties(document);
        }

        /// <summary>
        /// Gets the model surface area in database units [cm2].
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        [Category("Physical")]
        public double Area => physicalProperties.Area();

        /// <summary>
        /// Gets the model mass in database units [kg].
        /// </summary>
        /// <value>
        /// The mass.
        /// </value>
        [Category("Physical")]
        public double Mass => physicalProperties.Mass();

        /// <summary>
        /// Gets the model mass in pounds [lb].
        /// </summary>
        /// <value>
        /// The mass.
        /// </value>
        [Category("Physical")]
        [DisplayName("Mass [lb]")]
        public double MassLb => physicalProperties.Mass("lb");

        /// <summary>
        /// Gets or sets the description iProperty value.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Category("iProperties")]
        public string Description
        {
            get => iProperties.Description;
            set => iProperties.Description = value;
        }


        /// <summary>
        /// Gets the part number iProperty value.
        /// </summary>
        /// <value>
        /// The part number.
        /// </value>
        [Category("iProperties")]
        [ReadOnly(true)]
        public string PartNumber
        {
            get => iProperties.PartNumber;
            set => iProperties.PartNumber = value;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Category("iProperties")]
        public string Title
        {
            get => iProperties.Title;
            set => iProperties.Title = value;
        }

        /// <summary>
        /// Gets or sets the user defined property. This is example usage.
        /// </summary>
        /// <value>
        /// The user defined property.
        /// </value>
        [Category("iProperties")]
        public string UserDefinedProperty
        {
            get => iProperties.UserDefined("UserDefinedProperty").ToString();
            set => iProperties.UserDefined("UserDefinedProperty", value);
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName => document.FullFileName;
    }
}