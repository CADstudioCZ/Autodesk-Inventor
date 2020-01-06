# Selection info

>[Czech/Česky](ReadmeCZ.md)

## Content
- [Installation](#Installation)

- [Compilation](#Compilation)

- [Basic structure of the source code](#Basic-structure-of-the-source-code)

- [Code samples](#Code-samples)

  - [Create new object for display informations](#Create-new-object-for-display-informations)
  - [Attribute usage](#Attribute-usage)



## Installation
Copy files from the archive [out/Release.zip](out/Release.zip) to a local folder. 

Example:
* For all users
  * *C:\ProgramData\Autodesk\ApplicationPlugins\SelectionInfo.bundle\\*
* For current user
  * *C:\Users\USER_NAME\AppData\Roaming\Autodesk\ApplicationPlugins\SelectionInfo.bundle\\*

The last folder *SelectionInfo.bundle* doesn't exist and it is necessary to create it manually.

## Compilation
For the code compilation, you can use [Visual Studio 2017](https://visualstudio.microsoft.com/cs/downloads/) or higher. You can also use the free version *Community Edition*. 
If you want to create the archive with all necessary Add-In files during the compilation, you will also need the [7-Zip](https://www.7-zip.org/download.html) installed.

Inventor 2017 or higher and .NET Framework 4.7 libraries are used as the target platform. If you need to perform compilation for older Inventor releases, you will need to adjust the reference to *Autodesk.Inventor.Interop* of the given version. But backwards compatibility is not guaranteed.

## Basic structure of the source code
### [StandardAddInServer.cs](SelectionInfo/StandardAddInServer.cs)
A basic class for loading the AddIn into Inventor. Contains definition of basic objects and handles general behaviour on loading, on running and on exiting.

### [SelectionInfoSelector.cs](SelectionInfo/SelectionInfoSelector.cs)
This class is responsible for decisions which data will be displayed for the selected object. If no description is defined for the selected object, it returns `null` and nothing is displayed in the palette window.

### [DocumentiProperties.cs](SelectionInfo/DocumentiProperties.cs)
This class ensures access to the document's iProperties. It contains direct access to standard iProperties, which can be displayed directly. Even data types are defined for these iProperties. Some iProperties are defined both for reading and for writing, some are preset as read-only. 

Furthermore it contains two methods, which can be used to access custom iProperties.

### `UserDefined(string name)`
This method returns the value of the custom iProperty defined by its name. If no such iProperty exists, an error message os displayed.

### `UserDefined(string name, object value)`
This method sets the value of the custom iProperty defined by its name to the value of the argument `value`. If no such iProperty exists, it is neither possible to set the value, nor is the property created. 

### [PhysicalProperties.cs](SelectionInfo/PhysicalProperties.cs) 
This class ensures access to physical properties of the given CAD document.
As an input argument, the part or assembly document is required. No values are returned for other document types.

#### `Area(string units)`
The method `Area` returns the total area of the model. As the argument `units`, you can specify an area measurement unit which should be used for the output. Usually, this is a string defining the unit in the same way as in Inventor parameters, e.g. "m^2" or "m\*m" for output in square meters. If no unit is defined, the output is returned in the default Inventor units which is cm^2.

#### `Mass(string units)`
The method `Mass` returns the total mass of the model. As the argument `units`, you can specify a mass measurement unit which should be used for the output. Usually, this is a string defining the unit in the same way as in Inventor parameters, e.g. "g" or "lb" for output in grams or pounds. If no unit is defined, the output is returned in the default Inventor units which is kg.

#### `Volume(string units)`
The method `Volume` returns the total volume of the model. As the argument `units`, you can specify a volume area measurement unit which should be used for the output. Usually, this is a string defining the unit in the same way as in Inventor parameters, e.g. "m^3" or "m\*m\*m" for output in cubic meters. If no unit is defined, the output is returned in the default Inventor units which is cm^3.

### [DocumentInfo.cs](SelectionInfo/DocumentInfo.cs)
This class defines properties, which will be displayed, if the selected object is a document, or is convertible to a document. E.g. a document occurence in an assembly.

### [OccurrenceInfo.cs](SelectionInfo/OccurrenceInfo.cs)
This class defines properties, which will be displayed, if the selected object is a document occurence in an assembly. It displays all information which is defined in [DocumentInfo.cs](SelectionInfo/DocumentInfo.cs) and adds more, those specific for the occurence. E.g. `DisplayName`, which is the name of the occurence in the assembly tree.

## Code samples
### Create new object for display informations
In this example is shown, how to extend current code for diaplay informations about drawing view.

1. Create class for drawing view description

>Create class as new file, for example *DrawingViewInfo.cs*. In this file create folowing code. In the next step you can modify code for your needs.

```csharp
  class DrawingViewInfo
  {
      private readonly DrawingView drawingView;
  
      public DrawingViewInfo(DrawingView drawingView)
      {
          this.drawingView = drawingView;
      }
  
      /// <summary>
      /// Gets the scale of the drawing view.
      /// </summary>
      /// <value>
      /// The scale.
      /// </value>
      public string Scale => drawingView.ScaleString;
  
      /// <summary>
      /// Gets the model display name referenced by drawingView.
      /// </summary>
      /// <value>
      /// The model.
      /// </value>
      public string Model
      {
          get
          {
              var model = drawingView.ReferencedDocumentDescriptor;
              if (model == null)
                  return "No Model";
              else
                  return model.DisplayName;
          }
      }
  }
```

2. Extend list of available objects

>In the file [SelectionInfoSelector.cs](SelectionInfo/SelectionInfoSelector.cs) modify method `GetSelectionInfo` as shown below.

```csharp
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
        case DrawingView drawingView:
            return new DrawingViewInfo(drawingView);
        default:
            return null;
    }
}
```

3. Finalize

Finally compile project and update installation of AddIn. Now after selection of drawing view is shown informations like in the preview.

![DrawingViewInfoPreview](doc/img/DrawingViewInfoPreview.png)


### Attribute usage
For control behavior and appearance of dockable window you can use *Attributes*. Usage fo some attributes is described in following table. Attributes are declared in code before property definition.

Atribute|Description
---|---
[Category("Model")]|Groups properties together
[DisplayName("View of")]|Assign display name of the property.
[Description("Display name of the referenced model")]|Extended description of the property.

Code usage example:
```csharp
[Category("Model")]
[DisplayName("View of")]
[Description("Display name of the referenced model")]
public string Model
{
    get
    {
        var model = drawingView.ReferencedDocumentDescriptor;
        if (model == null)
            return "No Model";
        else
            return model.DisplayName;
    }
}
```

Preview:

![Attribute preview](doc/img/AttributesPreview.png)

>**Note:** There is lot of usable attributes. This is only commonest.
