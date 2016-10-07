.NET 2.0 Interoperability Recipes - by Bruce Bukovics - Apress

** BUILD INSTRUCTIONS **

Software Requirements:

The following build procedure assumes that you have the following
software already installed:
 - Visual Studio 2005
 - Visual Basic 6.0

Follow these steps to build all sample code for the book:

1)  If you haven't done so already, unzip all sample code
    to a work directory.  Use the option that preserves
    the directory structure contained within the zip file.
    The assumed name for the directory is \DotNetInterop.  
    Once unzipped, you should see separate folders for 
    each chapter in the book.  Within each chapter, there 
    are individual folders for each recipe.  Each chapter
    also has a \bin directory where all assemblies are copied
    during post-build steps.
    
2)  Open a Visual Studio 2005 command prompt.  This sets all 
    of the necessary environment variables.

3)  While in the command prompt, change to the \DotNetInterop 
    directory.

4)  Execute the command BuildInteropCode.cmd.  This will build all
    of the solutions for all chapters of the book.  It also builds
    Visual Basic 6.0 projects that are used as COM components or
    clients.  If you don't have VB 6.0 installed, those
    projects that rely upon VB 6.0 components will fail to build.

Note:  The default installation location for VB 6.0 is assumed 
to be %HOMEDRIVE%\Program Files\Microsoft Visual Studio\VB98\.  
If you installed VB 6.0 to a different location, you will need 
to modify the setting of the VSDEVENVVB6 environment variable 
in BuildInteropCode.cmd.


