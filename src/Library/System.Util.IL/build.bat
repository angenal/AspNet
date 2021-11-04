:: 编译并附带强命名参数: 确定要打包的程序集

C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe /dll ILMethods.il /include=include\netcoreapp /out=out\netcoreapp\System.Util.Il.dll /key=..\..\manifest.snk
C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe /dll ILMethods.il /include=include\netstandard /out=out\netstandard\System.Util.Il.dll /key=..\..\manifest.snk
C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe /dll ILMethods.il /include=include\netframework /out=out\netframework\System.Util.Il.dll /key=..\..\manifest.snk

:: 运行 nuget 包以生成 .nupkg 文件
:: 提前下载 https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
nuget pack System.Util.IL.nuspec
:: 移动或复制到本地包源所在目录
move System.Util.IL.1.0.0.nupkg A:\dotnet\NuGetPackages
