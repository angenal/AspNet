#define MyAppName "ShareX"
#define MyAppRootDirectory "..\.."
#define MyAppOutputDirectory MyAppRootDirectory + "\Output"
#define MyAppReleaseDirectory MyAppRootDirectory + "\ShareX\bin\Release"
#define MyAppFilename MyAppName + ".exe"
#define MyAppFilepath MyAppReleaseDirectory + "\" + MyAppFilename
#dim Version[4]
#expr ParseVersion(MyAppFilepath, Version[0], Version[1], Version[2], Version[3])
#define MyAppVersion Str(Version[0]) + "." + Str(Version[1]) + "." + Str(Version[2])
#define MyAppPublisher "ShareX Team"
#define MyAppId "82E6AC09-0FEF-4390-AD9F-0DD3F5561EFC"

[Setup]
AppCopyright=Copyright (c) 2007-2018 {#MyAppPublisher}
AppId={#MyAppId}
AppMutex={#MyAppId}
AppName={#MyAppName}
AppPublisher={#MyAppPublisher}
AppPublisherURL=https://getsharex.com
AppSupportURL=https://github.com/ShareX/ShareX/issues
AppUpdatesURL=https://github.com/ShareX/ShareX/releases
AppVerName={#MyAppName} {#MyAppVersion}
AppVersion={#MyAppVersion}
ArchitecturesAllowed=x86 x64 ia64
ArchitecturesInstallIn64BitMode=x64 ia64
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DirExistsWarning=no
DisableStartupPrompt=yes
DisableWelcomePage=yes
DisableProgramGroupPage=yes
DisableReadyPage=no
DisableReadyMemo=no
DisableFinishedPage=no
LicenseFile={#MyAppRootDirectory}\LICENSE.txt
; .NET 4.6.2 is supported only on Windows 7 SP1 and up
MinVersion=0,6.1.7601
OutputBaseFilename={#MyAppName}-{#MyAppVersion}-setup
OutputDir={#MyAppOutputDirectory}
PrivilegesRequired=none
ShowLanguageDialog=no
UninstallDisplayIcon={app}\{#MyAppFilename}
UninstallDisplayName={#MyAppName}
VersionInfoCompany={#MyAppPublisher}
VersionInfoTextVersion={#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
WizardImageFile=WizardImageFile.bmp
WizardImageStretch=no
WizardSmallImageFile=WizardSmallImageFile.bmp

#include "Scripts\lang\english.iss"

[Tasks]
Name: "CreateDesktopIcon"; Description: "Create a desktop shortcut"; GroupDescription: "Additional shortcuts:"; Check: not IsUpdating and not DesktopIconExists
Name: "CreateContextMenuButton"; Description: "Show ""Upload with ShareX"" button in Windows Explorer context menu"; GroupDescription: "Additional shortcuts:"; Check: not IsUpdating
Name: "CreateSendToIcon"; Description: "Create a send to shortcut"; GroupDescription: "Additional shortcuts:"; Check: not IsUpdating
Name: "CreateStartupIcon"; Description: "Run ShareX when Windows starts"; GroupDescription: "Other tasks:"; Check: not IsUpdating

[Files]
Source: "{#MyAppFilepath}"; DestDir: {app}; Flags: ignoreversion
Source: "{#MyAppFilepath}.config"; DestDir: {app}; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\*.dll"; DestDir: {app}; Flags: ignoreversion
Source: "{#MyAppRootDirectory}\Licenses\*.txt"; DestDir: {app}\Licenses; Flags: ignoreversion
Source: "{#MyAppOutputDirectory}\Recorder-devices-setup.exe"; DestDir: {app}; Flags: ignoreversion
Source: "{#MyAppRootDirectory}\ShareX.NativeMessagingHost\bin\Release\ShareX_NativeMessagingHost.exe"; DestDir: {app}; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\de\*.resources.dll"; DestDir: {app}\Languages\de; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\es\*.resources.dll"; DestDir: {app}\Languages\es; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\es-MX\*.resources.dll"; DestDir: {app}\Languages\es-MX; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\fr\*.resources.dll"; DestDir: {app}\Languages\fr; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\hu\*.resources.dll"; DestDir: {app}\Languages\hu; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\id-ID\*.resources.dll"; DestDir: {app}\Languages\id-ID; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\it-IT\*.resources.dll"; DestDir: {app}\Languages\it-IT; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\ko-KR\*.resources.dll"; DestDir: {app}\Languages\ko-KR; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\nl-NL\*.resources.dll"; DestDir: {app}\Languages\nl-NL; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\pt-BR\*.resources.dll"; DestDir: {app}\Languages\pt-BR; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\ru\*.resources.dll"; DestDir: {app}\Languages\ru; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\tr\*.resources.dll"; DestDir: {app}\Languages\tr; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\uk\*.resources.dll"; DestDir: {app}\Languages\uk; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\vi-VN\*.resources.dll"; DestDir: {app}\Languages\vi-VN; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\zh-CN\*.resources.dll"; DestDir: {app}\Languages\zh-CN; Flags: ignoreversion
Source: "{#MyAppReleaseDirectory}\zh-TW\*.resources.dll"; DestDir: {app}\Languages\zh-TW; Flags: ignoreversion
Source: "{#MyAppRootDirectory}\ShareX.ScreenCaptureLib\Stickers\*"; DestDir: {app}\Stickers; Flags: ignoreversion recursesubdirs
Source: "puush"; DestDir: {app}; Check: IsPuushMode

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppFilename}"; WorkingDir: "{app}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"; WorkingDir: "{app}"
Name: "{userdesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppFilename}"; WorkingDir: "{app}"; Tasks: CreateDesktopIcon
Name: "{sendto}\{#MyAppName}"; Filename: "{app}\{#MyAppFilename}"; WorkingDir: "{app}"; Tasks: CreateSendToIcon
Name: "{userstartup}\{#MyAppName}"; Filename: "{app}\{#MyAppFilename}"; WorkingDir: "{app}"; Parameters: "-silent"; Tasks: CreateStartupIcon

[Run]
Filename: "{app}\{#MyAppFilename}"; Description: "{cm:LaunchProgram,{#MyAppName}}"; Flags: nowait postinstall; Check: not IsNoRun

[Registry]
Root: "HKCU"; Subkey: "Software\Classes\*\shell\{#MyAppName}"; ValueType: string; ValueData: "Upload with {#MyAppName}"; Tasks: CreateContextMenuButton
Root: "HKCU"; Subkey: "Software\Classes\*\shell\{#MyAppName}"; ValueType: string; ValueName: "Icon"; ValueData: """{app}\{#MyAppFilename}"",0"; Tasks: CreateContextMenuButton
Root: "HKCU"; Subkey: "Software\Classes\*\shell\{#MyAppName}\command"; ValueType: string; ValueData: """{app}\{#MyAppFilename}"" ""%1"""; Tasks: CreateContextMenuButton
Root: "HKCU"; Subkey: "Software\Classes\Directory\shell\{#MyAppName}"; ValueType: string; ValueData: "Upload with {#MyAppName}"; Tasks: CreateContextMenuButton
Root: "HKCU"; Subkey: "Software\Classes\Directory\shell\{#MyAppName}"; ValueType: string; ValueName: "Icon"; ValueData: """{app}\{#MyAppFilename}"",0"; Tasks: CreateContextMenuButton
Root: "HKCU"; Subkey: "Software\Classes\Directory\shell\{#MyAppName}\command"; ValueType: string; ValueData: """{app}\{#MyAppFilename}"" ""%1"""; Tasks: CreateContextMenuButton
Root: "HKCU"; Subkey: "Software\Classes\*\shell\{#MyAppName}"; Flags: dontcreatekey uninsdeletekey
Root: "HKCU"; Subkey: "Software\Classes\Directory\shell\{#MyAppName}"; Flags: dontcreatekey uninsdeletekey
Root: "HKCU"; Subkey: "Software\Classes\.sxcu"; Flags: dontcreatekey uninsdeletekey
Root: "HKCU"; Subkey: "Software\Classes\ShareX.sxcu"; Flags: dontcreatekey uninsdeletekey
Root: "HKCU"; Subkey: "Software\Classes\SystemFileAssociations\image\shell\ShareXImageEditor"; Flags: dontcreatekey uninsdeletekey

[CustomMessages]
DependenciesDir=Dependencies

#include "Scripts\products.iss"
#include "Scripts\products\stringversion.iss"
#include "Scripts\products\winversion.iss"
#include "Scripts\products\fileversion.iss"
#include "Scripts\products\dotnetfxversion.iss"
#include "scripts\products\dotnetfx46.iss"

[Code]
function InitializeSetup(): Boolean;
begin
  initwinversion();
  dotnetfx46(62);
  Result := true;
end;

function CmdLineParamExists(const value: string): Boolean;
var
  i: Integer;  
begin
  Result := False;
  for i := 1 to ParamCount do
    if CompareText(ParamStr(i), value) = 0 then
    begin
      Result := True;
      Exit;
    end;
end;

function IsUpdating(): Boolean;
begin
  Result := CmdLineParamExists('/UPDATE');
end;

function IsNoRun(): Boolean;
begin
  Result := CmdLineParamExists('/NORUN');
end;

function IsPuushMode(): Boolean;
begin
  Result := CmdLineParamExists('-puush');
end;

function DesktopIconExists(): Boolean;
begin
  Result := FileExists(ExpandConstant('{userdesktop}\{#MyAppName}.lnk'));
end;