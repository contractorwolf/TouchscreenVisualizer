TouchscreenVisualizer
=====================

Winform Visualizer for the Nintendo DSL digitizer using an Arduino 


This is the hardware I am using:
Arduino UNO
Nintendo DSL digitizer: http://adafru.it/333



Project is a Visual Studio solution that can be run and edited using the free version of Visual Studio available here:
http://www.microsoft.com/visualstudio/eng/downloads#d-2010-express
(I recommend downloading the Visual C# 2010, which is free and very good for using on winform projects like this)

If you have Visual Studio installed simply open the .sln file at the root of the project. The project will list the attached COM Ports allowing you to choose the one for the Arduino (that outputs a comma delim list like this 344,266,482*)


To get the Arduino to output this data it needs to be running this code:
https://github.com/contractorwolf/Touch-Screen-Library
