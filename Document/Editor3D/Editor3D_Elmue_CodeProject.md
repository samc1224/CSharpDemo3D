##### Editor3D: A Windows.Forms Render Control with interactive 3D Editor in C#

## https://www.codeproject.com/Articles/5293980/Editor3D-A-Windows-Forms-Render-Control-with-inter

An easy to use 3D control which can be integrated into an application in a few minutes

A universal ready-to-use interactive 3D Editor control for System.Windows.Forms applications. It displays 3D data that the user can modify with the mouse. The control consists of a single C# file and is optimized for maximum speed.

[Download Zip file](https://netcult.ch/elmue/Download/Editor3D.zip) (Source code + Compiled Exe) - 897kB - Version 12.feb.2024

![Image 1](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Main.png)

## Features

+   **NEW:** New demo 'Surface Missing' shows how to draw a surface plot with missing points.
+   **NEW:** User mouse actions can be defined 100% individually.
+   **NEW:** Axis legends can be drawn also at the end of the main axes.
+   X and Y axes can be mirrored.
+   Option to include zero value of Z-axis or not.
+   Added Undo / Redo buffer for user operations.
+   BUGFIX: Drawing of selected multi-color lines
+   The control has been completely rewritten (4100 lines of code, 170 kB filesize!)
+   The user can select 3D objects with the mouse while pressing the ALT key.
+   The user can move points or objects with the mouse in the 3D space.
+   A callback provides full control over user actions and object selection.
+   3D objects can be added, modified and removed on the fly.
+   A new demo "Animation" shows how to dynamically change properties of 3D objects.
+   The border color changes when the 3D editor gets the keyboard focus
+   Line width and scatter point size are adapted when zooming
+   Can be configured to use only the left or middle mouse button for all movements
+   Support for drawing 3D objects. Added example "Pyramid" and "Sphere"
+   Rendering speed optimized to the extreme
+   BUGFIX: Sometimes the Z axis was drawn on top of the 3D object instead behind
+   Display a tooltip when the mouse is over a 3D point
+   Resizing of 3D object when resizing 3D control
+   Completely rewritten to allow display of multiple graphs at the same time
+   Individual color scheme for each graph
+   Surface plots can also be drawn as grid
+   User messages can be drawn into the control
+   Added scatter squares and triangles
+   Copy Screenshot to Image
+   Set Rho, Theta, Phi programmatically
+   Drawing of scatterplots
+   Coordinate system now also with negative values
+   Universal ready-to-use 3D Graph control for System.Windows.Forms applications
+   Derived from UserControl
+   Target: Framework 4 (Visual Studio 2010 or higher)
+   Display of 3 dimensional functions or binary data (X, Y, Z values)
+   Very clean and reusable code written by an experienced programmer
+   All code is in one single C# file with < 1200 lines
+   Optional function compiler allows to enter formulas as strings
+   Optional coordinate system with raster lines and labels
+   Optionally multiple color schemes
+   The user can rotate, elevate and zoom with the mouse or with 3 optional TrackBars
+   Zooming is also possible with the mouse wheel, but only if the 3D Graph has the focus.
+   The entire code is optimized for the maximum speed that is possible.
+   An optional legend displays the current rotation angles to the user in the top left corner.
+   An optional legend displays a user defined text for the axis in the bottom left corner.
+   The black lines between the polygons can be turned off.
+   Automatic normalization of 3D input data with 3 options

## Why this Project?

I'am writing an ECU tunig software [HUD ECU Hacker](https://netcult.ch/elmue/HUD%20ECU%20Hacker) for which I need a 3D Viewer which displays the calibration tables.

I searched a ready-to-use 3D Control in internet but could not find what fits my needs.  
Huge 3D software projects like Helix Toolkit are completely overbloated (220 MB) for my small project.

Commercial 3D software from $250 USD up to $2900 USD is also not an option.

## WPF 3D Chart (from Jianzhong Zhang)

I found [WPF 3D Chart](https://www.codeproject.com/Articles/42174/High-performance-WPF-3D-Chart) on Codeproject.

It is very fast because WPF uses hardware acceleration.  
The graphics processor can render 3D surfaces which must be composed of triangles.  
But it is difficult to render lines. Each line would have to be defined as 2 triangles.  
I need lines for the coordinate system.  
I also need lines which display discrete values on the 3D surface.  
I want each value in a data table to be represented as a polygon on the 3D object.  
The screenshot at the top shows the representation of a data table with 22 rows and 17 columns.  
I found it too complicated to implement this in WPF.  
Extra work must be done to integrate a WPF control into a Windows.Forms application. See this [article](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/walkthrough-hosting-a-wpf-composite-control-in-windows-forms).

## Plot 3D (from Michal Brylka)

Then I found [Plot 3D](https://www.codeproject.com/Articles/17715/Plot-3D-surfaces) on Codeproject.  
This is more what I'am looking for but the code is not reusable and has many issues.

It is one of these many projects on Codeproject or Github which the author never has finished, which are buggy and lack functionality.  
There is no useful way to rotate the 3D object. Instead of specifying a rotation angle you must specify the 3D observer coordinates which is a complete misdesign.  
After fixing this I found that rotation results in ugly drawing artifacts at certain angles.  
The reason is that the polygons are not rendered in the correct order.  
The code has a bad performance because of wrong programming. For example in `OnPaint()` he creates each time 100 brushes and disposes them afterwards.  
The code has been designed only for formulas but assigning fix values from a data table is not possible.

## Editor3D (from Elmü)

I ended up rewriting Plot 3D from the scratch, bug fixing and adding a lot of missing functionality.  
The result is a UserControl which you can copy unchanged into your project and which you get working in a few minutes.  
The features of my control are already listed above.  
As my code does not use hardware acceleration the number of polygons that you display determines the drawing speed.  
Without problem you can rotate and elevate the 3D objects of the demos in real time with the mouse without any delay.  
However if you want to render far more polygons it will be obviously slower.  
For my purpose I need less than 2000 polygons which allows real time rotating with the mouse.  
Download the ZIP file and then run the already compiled EXE file and play around with it and you will see the speed.

## Demo: Surface Fill

![Image 2](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Surface.jpg)

Here you see data from a table with 22x17 values displayed as 3D surface with coordinate system.

```csharp
int\[,\] s32\_Values = new int\[,\]
{
    { 9059,   9634, 10617, 11141, ....., 15368, 15368, 15368, 15368, 15368 }, // row 1
    { 9684,  10387, 11141, 11796, ....., 15794, 15794, 15794, 15794, 15794 }, // row 2
    .........
    { 34669, 34210, 33653, 33096, ....., 27886, 26492, 25167, 25167, 25167 }, // row 21
    { 34767, 34210, 33718, 33096, ....., 27984, 26492, 25167, 25167, 25167 }  // row 22
};

int s32\_Cols = s32\_Values.GetLength(1);
int s32\_Rows = s32\_Values.GetLength(0);

cColorScheme i\_Scheme = new cColorScheme(me\_ColorScheme);
cSurfaceData i\_Data   = new cSurfaceData(e\_Mode, s32\_Cols, s32\_Rows, Pens.Black, i\_Scheme);

for (int C=0; C<i\_Data.Cols; C++)
{
    for (int R=0; R<i\_Data.Rows; R++)
    {
        int s32\_RawValue = s32\_Values\[R,C\];

        double d\_X = C \* 640.0; // X must be related to colum
        double d\_Y = R \*   5.0; // Y must be related to row
        double d\_Z = s32\_RawValue / 327.68;

        String s\_Tooltip = String.Format("Speed = {0} rpm\\nMAP = {1} kPa\\n"
                                       + "Volume Eff. = {2} %\\nColumn = {3}\\nRow = {4}", 
                                         d\_X, d\_Y, Editor3D.FormatDouble(d\_Z), C, R);

        cPoint3D i\_Point = new cPoint3D(d\_X, d\_Y, d\_Z, s\_Tooltip, s32\_RawValue);

        i\_Data.SetPointAt(C, R, i\_Point);
    }
}

editor3D.Clear();
editor3D.Normalize = eNormalize.Separate;
editor3D.AxisY.Mirror = true;
editor3D.AxisX.LegendText = "Engine Speed (rpm)";
editor3D.AxisY.LegendText = "MAP (kPa)";
editor3D.AxisZ.LegendText = "Volume Efficiency (%)";
editor3D.AddRenderData(i\_Data);

editor3D.Selection.Callback       = OnSelectEvent;
editor3D.Selection.HighlightColor = Color.FromArgb(90, 90, 90); // gray
editor3D.Selection.MultiSelect    = true;
editor3D.Selection.Enabled        = true;
editor3D.Invalidate();
```

When you use discrete values for X,Y and Z which are not related like in this example make sure that X,Y and Z values are **normalized** separately by using the parameter `eNormalize.Separate` because the axes have different ranges.

Each point in the grid has a **tooltip** assigned which shows the values X,Y,Z, Row, Column and Raw value.

This demo allows user **selection** of multiple polygons or points in the grid while pressing the ALT key.  
The Z-values of the selected points can then be **modified** with the mouse while pressing ALT + CTRL.  
The selection and movement are handled in a user defined **callback**: `OnSelectEvent()`.

## Mirroring Axes

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Mirror.png)

Use Demo Surface Fill to test the checkboxes "Mirror X" and "Mirror Y".

## Demo: Math Callback

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Callback.png)

Or you can write a C# callback function which calculates the Z values from the given X and Y values.

```csharp
cColorScheme i\_Scheme = new cColorScheme(me\_ColorScheme);
cSurfaceData i\_Data   = new cSurfaceData(ePolygonMode.Fill, 49, 33, Pens.Black, i\_Scheme);

delRendererFunction f\_Callback = delegate(double X, double Y)
{
    double r = 0.15 \* Math.Sqrt(X \* X + Y \* Y);
    if (r < 1e-10) return 120;
    else           return 120 \* Math.Sin(r) / r;
};

i\_Data.ExecuteFunction(f\_Callback, new PointF(-120, -80), new PointF(120, 80));

editor3D.Clear();
editor3D.Normalize = eNormalize.MaintainXYZ;
editor3D.AddRenderData(i\_Data);
editor3D.Invalidate();
```

A modulated sinus function is displayed on the X axis from -120 to +120 and on the Y axis from -80 to +80.  
The 49 columns and 33 rows of points result in 48 columns and 32 rows of polygons (totally 1536).

When you use functions make sure that the relation between X,Y and Z values is not distorted by using the parameter `eNormalize.MaintainXYZ`.

## Demo: Math Formula

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Formula.png)

Or you can let the user enter a string formula which will be compiled at run time:

```csharp
cColorScheme i\_Scheme = new cColorScheme(me\_ColorScheme);
cSurfaceData i\_Data   = new cSurfaceData(ePolygonMode.Fill, 41, 41, Pens.Black, i\_Scheme);

String s\_Formula = "7 \* sin(x) \* cos(y) / (sqrt(sqrt(x \* x + y \* y)) + 0.2)";
delRendererFunction f\_Function = FunctionCompiler.Compile(s\_Formula);
i\_Data.ExecuteFunction(f\_Function, new PointF(-7, -7), new PointF(7, 7));

editor3D.Clear();
editor3D.Normalize = eNormalize.MaintainXYZ;
editor3D.AddRenderData(i\_Data);
editor3D.Invalidate();
```

## Demo: Scatter Plot

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_ScatterPlot.png)

```csharp
cColorScheme i\_Scheme = new cColorScheme(me\_ColorScheme);
cScatterData i\_Data   = new cScatterData(i\_Scheme);

for (double P = -22.0; P < 22.0; P += 0.1)
{
    double d\_X = Math.Sin(P) \* P;
    double d\_Y = Math.Cos(P) \* P;
    double d\_Z = P;
    if (d\_Z > 0.0) d\_Z /= 3.0;

    cPoint3D i\_Point = new cPoint3D(d\_X, d\_Y, d\_Z, "Scatter Point");
    i\_Data.AddShape(i\_Point, eScatterShape.Circle, 3, null);
}
 
editor3D.Clear();
editor3D.Normalize = eNormalize.Separate;
editor3D.AddRenderData(i\_Data);
editor3D.Invalidate();
```

## Demo: Scatter Shapes

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_ScatterShapes.png)

This demo shows negative values as red squares and positive values as green triangles.  
Each point in this plot consists of 4 doubles: X,Y,Z and a value.  
The value defines the size of the square or triangle while X,Y,Z define the position.  
The value is displayed in the tooltip.

4 shapes are selected (blue) and can be moved with the mouse in the 3D space.

```csharp
double\[,\] d\_Values = new double\[,\]
{
    // Value  X        Y      Z
    {   0.39, 0.0051,  0.133, 0.66 },
    {   0.23, 0.0002,  0.114, 0.87 },
    {   1.46, 0.0007,  0.077, 0.72 },
    {  -1.85, 0.0137,  0.053, 0.87 },
    ......
}

// A ColorScheme is not needed because all points have their own Brush
cScatterData i\_Data = new cScatterData(null);

for (int P = 0; P < d\_Values.GetLength(0); P++)
{
    double d\_Value = d\_Values\[P, 0\];
    int s32\_Radius = (int)Math.Abs(d\_Value) + 1;

    double X = d\_Values\[P,1\];
    double Y = d\_Values\[P,2\];
    double Z = d\_Values\[P,3\];

    eScatterShape e\_Shape = (d\_Value < 0) ? eScatterShape.Square : eScatterShape.Triangle;
    Brush         i\_Brush = (d\_Value < 0) ? Brushes.Red          : Brushes.Lime;

    String s\_Tooltip = "Value = " + Editor3D.FormatDouble(d\_Value);
    cPoint3D i\_Point = new cPoint3D(X, Y, Z, s\_Tooltip, d\_Value);

    i\_Data.AddShape(i\_Point, e\_Shape, s32\_Radius, i\_Brush);
}

editor3D.Clear();
editor3D.Normalize = eNormalize.Separate;
editor3D.AddRenderData(i\_Data);
editor3D.Invalidate();
'''

## Demo: Nested Graphs

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_NestedGraphs.png)

This demo shows how to display 2 graphs at once.  
It also shows how to add messages as a legend to the user (bottom left).  
This demo demonstrates single point selection. The user can only select one point at a time.

```csharp
const int POINTS = 8;
cSurfaceData i\_Data1 = new cSurfaceData(ePolygonMode.Lines, POINTS, POINTS, new Pen(Color.Orange, 3), null);
cSurfaceData i\_Data2 = new cSurfaceData(ePolygonMode.Lines, POINTS, POINTS, new Pen(Color.Green,  2), null);

for (int C=0; C<POINTS; C++)
{
    for (int R=0; R<POINTS; R++)
    {
        double d\_X = (C - POINTS / 2.3) / (POINTS / 5.5); // X must be related to colum
        double d\_Y = (R - POINTS / 2.3) / (POINTS / 5.5); // Y must be related to row
        double d\_Radius = Math.Sqrt(d\_X \* d\_X + d\_Y \* d\_Y);
        double d\_Z = Math.Cos(d\_Radius) + 1.0;

        String  s\_Tooltip = String.Format("Col = {0}\\nRow = {1}", C, R);
        cPoint3D i\_Point1 = new cPoint3D(d\_X, d\_Y, d\_Z,       s\_Tooltip + "\\nWrong Data");
        cPoint3D i\_Point2 = new cPoint3D(d\_X, d\_Y, d\_Z \* 0.6, s\_Tooltip + "\\nCorrect Data");

        i\_Data1.SetPointAt(C, R, i\_Point1);
        i\_Data2.SetPointAt(C, R, i\_Point2);
    }
}

cMessgData i\_Mesg1 = new cMessgData("Graph with error data",   7,  -7, Color.Orange);
cMessgData i\_Mesg2 = new cMessgData("Graph with correct data", 7, -24, Color.Green);

editor3D.Clear();
editor3D.Normalize = eNormalize.MaintainXY;
editor3D.AddRenderData (i\_Data1, i\_Data2);
editor3D.AddMessageData(i\_Mesg1, i\_Mesg2);
editor3D.Selection.MultiSelect = false;
editor3D.Selection.Enabled     = true;
editor3D.Invalidate();
```

## Demo: Pyramid

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Pyramid.png)

This demo shows a simple 3D object which consists of lines.  
Normally lines are drawn in one solid color.  
But this demo renders the vertical lines in 50 parts with colors from the rainbow scheme.

```csharp
cLineData i\_Data = new cLineData(new cColorScheme(me\_ColorScheme));

cPoint3D i\_Center  = new cPoint3D(45, 45, 40, "Center");
cPoint3D i\_Corner1 = new cPoint3D(45, 25, 20, "Corner 1");
cPoint3D i\_Corner2 = new cPoint3D(25, 45, 20, "Corner 2");
cPoint3D i\_Corner3 = new cPoint3D(45, 65, 20, "Corner 3");
cPoint3D i\_Corner4 = new cPoint3D(65, 45, 20, "Corner 4");

// Add the 4 vertical lines which are rendered as 50 parts with different colors
cLine3D i\_Vert1 = i\_Data.AddMultiColorLine(50, i\_Center, i\_Corner1, 4, null);
cLine3D i\_Vert2 = i\_Data.AddMultiColorLine(50, i\_Center, i\_Corner2, 4, null);
cLine3D i\_Vert3 = i\_Data.AddMultiColorLine(50, i\_Center, i\_Corner3, 4, null);
cLine3D i\_Vert4 = i\_Data.AddMultiColorLine(50, i\_Center, i\_Corner4, 4, null);

// Add the 4 base lines with solid color
cLine3D i\_Hor1 = i\_Data.AddSolidLine(i\_Corner1, i\_Corner2, 8, null);
cLine3D i\_Hor2 = i\_Data.AddSolidLine(i\_Corner2, i\_Corner3, 8, null);
cLine3D i\_Hor3 = i\_Data.AddSolidLine(i\_Corner3, i\_Corner4, 8, null);
cLine3D i\_Hor4 = i\_Data.AddSolidLine(i\_Corner4, i\_Corner1, 8, null);

editor3D.Clear();
editor3D.Normalize = eNormalize.Separate;
editor3D.AxisZ.IncludeZero = false;
editor3D.AddRenderData(i\_Data);
editor3D.Invalidate();
```

## Including Z Value Zero

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_IncludeZero.png)

Use Demo Pyramid to test the checkbox "Include Zero Z".  
The Z values of the pyramid range from 20 to 40.  
You can chose if the bottom of the Z axis is 0 or 20.

## Demo: Sphere

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Sphere.png)

This demo shows another 3D object which is rendered with polygons.  
If you have been working with other 3D libraries (WPF, Direct3D) you know that all surfaces must be rendered as triangles.  
But my library allows to pass polygons with any amount of corners (minimum 3).  
This eliptic sphere contains a round polygon with 50 corners for the top and bottom.

# The code of this demo is a bit longer.
# Have a look into the source code.

## Modifying 3D Objects

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_ModifyPyramid.png)

With the checkbox 'Point Selection' in the demo application you can chose if you want to select points or lines.  
Press ALT and click a point of the pyramid to select it. A green circle marks it as selected.  
Then press ALT + CTRL and drag the selecetd point(s) with the mouse in the 3D space.

All this is handled in the selection callback where you have 100% control over all user actions.

## The Selection Callback

```csharp
void DemoPyramid()
{
    .....
    editor3D.Selection.HighlightColor = Color.Green;
    editor3D.Selection.Callback       = OnSelectEvent;
    editor3D.Selection.MultiSelect    = true;
    editor3D.Selection.Enabled        = true;
    .....
}

eInvalidate OnSelectEvent(eAltEvent e\_Event, Keys e\_Modifiers,
                          int s32\_DeltaX, int s32\_DeltaY, cObject3D i\_Object)
{
    eInvalidate e\_Invalidate = eInvalidate.NoChange;

    bool b\_CTRL = (e\_Modifiers & Keys.Control) > 0;

    if (e\_Event == eAltEvent.MouseDown && !b\_CTRL && i\_Object != null)
    {
        i\_Object.Selected = !i\_Object.Selected; // toggle selection

        // After changing the selection status the objects must be redrawn.
        e\_Invalidate = eInvalidate.Invalidate;
    }
    else if (e\_Event == eAltEvent.MouseDrag && b\_CTRL)
    {
        cPoint3D i\_Project = editor3D.ReverseProject(s32\_DeltaX, s32\_DeltaY);

        foreach (cPoint3D i\_Selected in editor3D.Selection.GetSelectedPoints(eSelType.All))
        {
            i\_Selected.Move(i\_Project.X, i\_Project.Y, i\_Project.Z);
        }

        // Set flag to recalculate the coordinate system, then Invalidate()
        e\_Invalidate = eInvalidate.CoordSystem;
    }

    return e\_Invalidate;
}
```

The callback `OnSelectEvent()` receives several parameters.  
Read the comment for function `Editor3D.SelectionCallback()` where they are explained.  
In the first `if()` the selection of the point/object is toggled when the mouse goes down with ALT key pressed but without CTRL key.  
In the `else if()` the relative movement of the mouse is reverse projected into the 3D space while the user drags the point/object.  
This 3D movement in the X,Y,Z directions is then added to the X,Y,Z coordinates of the selected points.

You can write your own callback function which does whatever you like to manipulate the 3D objects.  
You can change the coordinates of a 3D object, the color, the shape, the size, the selection status, the tooltip,...

Pay attention to the status bar which shows all mouse events:

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Statusbar.png)

## Selecting an entire 3D figure

You can assign your own data to the property `Tag` of any 3D object.  
This data may be a `List<cObject3D>` or any class or struct of your project.  
When the callback is called because the user clicks or drags a 3D object you can obtain the data from the `Tag`.  
The following code shows how to select an entire 3D figure consisting of lines, shapes and polygons when the user clicks one of them.

```csharp
// Add all parts of your 3D figure to a list
List<cObject3D> i\_Parts = new List<cObject3D>();
i\_Parts.Add(i\_MyLine1);
i\_Parts.Add(i\_MyLine2);
i\_Parts.Add(i\_MyShape1);
i\_Parts.Add(i\_MyPolygon1);
i\_Parts.Add(i\_MyPolygon2);

i\_MyLine1.Tag    = i\_Parts;
i\_MyLine2.Tag    = i\_Parts;
i\_MyShape1.Tag   = i\_Parts;
i\_MyPolygon1.Tag = i\_Parts;
i\_MyPolygon2.Tag = i\_Parts;

.....

editor3D.Selection.SinglePoints = false;

.....

private eInvalidate OnSelectEvent(eAltEvent e\_Event, Keys e\_Modifiers,
                                  int s32\_DeltaX, int s32\_DeltaY, cObject3D i\_Object)
{
    bool b\_CTRL = (e\_Modifiers & Keys.Control) > 0;

    if (e\_Event == eAltEvent.MouseDown && !b\_CTRL &&
        i\_Object != null && i\_Object.Tag is List<cObject3D>)
    {
        bool b\_Selected = !i\_Object.Selected; // toggle selection
        foreach (cObject3D i\_Part in (List<cObject3D>)i\_Object.Tag)
        {
            i\_Part.Selected = b\_Selected;
        }
        return eInvalidate.Invalidate;
    }

    return eInvalidate.NoChange;
}
```

## Deleting 3D Objects

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_DeletePolygons.png)

In demo 'Sphere' you can select polygons and delete them by hitting the DEL key.

```csharp
editor3D.KeyDown += new KeyEventHandler(OnEditorKeyDown);

void OnEditorKeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyCode != Keys.Delete)
        return;

    foreach (cObject3D i\_Polygon in editor3D.Selection.GetSelectedObjects(eSelType.Polygon))
    {
        editor3D.RemoveObject(i\_Polygon);
    }
    editor3D.Invalidate();
}
```

## Demo Animation

![System.Windows.Forms 3D Editor Control in C#](data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==)

This demo uses a timer which updates 50 scatter circles and a pyramid of 5 polygons.  
The sinus is sweeping up and down slowly and changes through all colors of the rainbow.  
The pyramid rotates around it's own axis and drifts up and down.

The timer calls this function every 100 ms:

```csharp
void ProcessAnimation()
{
    ms32\_AnimationAngle ++;

    // ======== SCATTER =========

    cShape3D\[\]   i\_AllShapes   = mi\_SinusData.AllShapes;
    cColorScheme i\_ColorScheme = mi\_SinusData.ColorScheme;
    double       d\_DeltaX      = 400.0 / i\_AllShapes.Length;

    double d\_X = -200.0;
    for (int S=0; S<i\_AllShapes.Length; S++, d\_X += d\_DeltaX)
    {
        cShape3D i\_Shape = i\_AllShapes\[S\];

        i\_Shape.Points\[0\].X =  d\_X;
        i\_Shape.Points\[0\].Y = -d\_X;
        i\_Shape.Points\[0\].Z = Math.Sin((ms32\_AnimationAngle + d\_X) / 50.0) \* 50.0 + 50.0;

        i\_Shape.Brush = i\_ColorScheme.GetBrush(ms32\_AnimationAngle \* 10);
    }

    // ======== PYRAMID =========

    double d\_Angle   = ms32\_AnimationAngle / 30.0;
    double d\_Sinus   = Math.Sin(d\_Angle) \* 50.0; // -50 ... +50
    double d\_Cosinus = Math.Cos(d\_Angle) \* 50.0; // -50 ... +50
    double d\_DeltaZ  = d\_Sinus / 2.0;            // -25 ... +25

    // Top
    mi\_Pyramid\[0\].X = -100.0;
    mi\_Pyramid\[0\].Y = -100.0;
    mi\_Pyramid\[0\].Z =   70.0 + d\_DeltaZ;
    // Edge 1
    mi\_Pyramid\[1\].X = -100.0 + d\_Sinus;
    mi\_Pyramid\[1\].Y = -100.0 + d\_Cosinus;
    mi\_Pyramid\[1\].Z =   40.0 + d\_DeltaZ;
    // Edge 2
    mi\_Pyramid\[2\].X = -100.0 + d\_Cosinus;
    mi\_Pyramid\[2\].Y = -100.0 - d\_Sinus;
    mi\_Pyramid\[2\].Z =   40.0 + d\_DeltaZ;
    // Edge 3
    mi\_Pyramid\[3\].X = -100.0 - d\_Sinus;
    mi\_Pyramid\[3\].Y = -100.0 - d\_Cosinus;
    mi\_Pyramid\[3\].Z =   40.0 + d\_DeltaZ;
    // Edge 4
    mi\_Pyramid\[4\].X = -100.0 - d\_Cosinus;
    mi\_Pyramid\[4\].Y = -100.0 + d\_Sinus;
    mi\_Pyramid\[4\].Z =   40.0 + d\_DeltaZ;
}
```

## Tooltip

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Tooltips.png)

Each polygon corner shows a tooltip when the mouse is over it.  
I marked in magenta the locations for the tooltip of the back part of the sphere and in pink of the front part.  
If you use `ePolygonMode.Fill` you will see the tooltip also for corners which are invisible.  
This means that in one rectangle on the right screenshot you may see 10 tooltips instead of 4.  
Fixing this would require to detect if a corner is covered by a polygon which would extremely decrease the perfomance.  
If you find this confusing, I recomend to turn off the tooltip:

```csharp
editor3D.TooltipMode = eTooltip.Off;
```

## Demo: Valentine

And last but not least:  
Well, this demo has just been written on 14th february 2021.

![System.Windows.Forms 3D Editor Control in C#](https://www.codeproject.com/KB/Articles/5293980/Editor3D_Valentine.png)

Have fun with my library. Read the plenty of comments in the code!

# Elmü

## License
This article, along with any associated source code and files, is licensed under The Code Project Open License (CPOL)

# Written By
### Elmue
Software Developer (Senior) ElmüSoft
Chile

Software Engineer since 40 years.
