# Fractal Explorer (WIP)

A fractal explorer built with WPF and MVVM, experimenting with the limits of datatypes and optimization techniques for real-time fractal rendering.

## Description

This project is a work-in-progress fractal visualizer written in C# using WPF and the MVVM pattern. It's an experimental sandbox for exploring how different numeric datatypes (float, double, decimal, etc.) and optimization strategies affect the performance and precision of fractal rendering, particularly for deep zooms into fractals like the Mandelbrot set.

## Getting Started

### Dependencies

* Windows 10 (for native WPF builds)
* .NET SDK (compatible with the project's target framework, e.g. net10.0-windows)
* Visual Studio (recommended for building on Windows)
* Wine (for running on Linux)

### Installing

* Clone or download this repository
* No additional file/folder modifications are needed for a standard Windows build


### Building on Windows

* Open the project in Visual Studio
* Build the project using Visual Studio

### Building on Linux

* add the following line from `mandelbrot.csproj`:
```mandelbrot.csproj
<UseWPF>true</UseWPF>
```

* Build with the .NET CLI:

```shell
dotnet build
```

* Run the resulting `.exe` with Wine:

```shell
wine mandelbrot/bin/Debug/net10.0-windows/mandelbrot.exe
```


* For convenience, set up an alias to run the program:
```shell
alias run="wine mandelbrot/bin/Debug/net10.0-windows/mandelbrot.exe"
```
### Screenshots

<img width="763" height="778" alt="image" src="https://github.com/user-attachments/assets/ca07667d-576e-45b4-96bb-f9bfd9e041d8" />

<img width="764" height="783" alt="image" src="https://github.com/user-attachments/assets/4abe1d11-dd40-4be1-816b-6a7a9c9ff84b" />


