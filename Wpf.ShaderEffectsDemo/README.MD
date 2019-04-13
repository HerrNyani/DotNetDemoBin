ShaderEffects Demo
==================

This demo showcases the use of a ShaderEffect subclass to access a compiled PixelShader, which enables access to GPU-computed effect in WPF.


Requirements
------------
* .NET 3.5 SP1 or later


Keystones
---------
* Resources/ShaderEffects/Grayscale.hlsl: The HLSL (High-level shader Language) definition of your shader. Not required to build the C# solution.
* Resources/ShaderEffects/Grayscale.fxc: The compiled output of the hlsl-file. Must be added to the project with *Build Action* set to **Resource**.
* Class Effects.GrayscaleShaderEffect: Interfaces your compiled shader to the .NET framework.


Building the HLSL file
----------------------
To create the fxc-file from the hlsl-file, you need the DirectX SDK. Windows 8 and later comes preinstalled with the SDK.

To build the shader, enter following command in cmd.exe:

```
fxc.exe /T ps_2_0 /Fo "Grayscale.fxc" "Grayscale.hlsl"
```

Adjust paths as required. On my Windows 10 machine, fxc.exe was located at:
```
C:\Program Files (x86)\Windows Kits\10\bin\&lt;version number&gt;\&lt;architecture&gt;\fxc.exe
```

You can build the shader when selecting Build Project as well. To do so, open the *Project Properties* > *Build Events*. 
Enter following in the *Pre-build event commandline* field:

```
fxc.exe /T ps_2_0 /Fo"$(SolutionDir)Resources/ShaderEffects/Grayscale.fxc" "$(SolutionDir)Resources/ShaderEffects/Grayscale.fx"
```

Please refer to the [Effect-Compiler Tool documentation](https://docs.microsoft.com/en-us/windows/desktop/direct3dtools/fxc) for more information.


Third party resources
---------------------
* Image: https://www.pexels.com/photo/bloom-blooming-blossom-blur-462118/
