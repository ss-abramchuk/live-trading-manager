using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using WealthLab.Extensions.Attribute;
using System.Resources;

// Управление общими сведениями о сборке осуществляется с помощью 
// набора атрибутов. Измените значения этих атрибутов, чтобы изменить сведения,
// связанные со сборкой.
[assembly: AssemblyTitle("LiveTradingManager")]
[assembly: AssemblyDescription("Live Trading Products Manager")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("SS.Abramchuk")]
[assembly: AssemblyProduct("LiveTradingManager")]
[assembly: AssemblyCopyright("Copyright © 2014 SS.Abramchuk")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Параметр ComVisible со значением FALSE делает типы в сборке невидимыми 
// для COM-компонентов.  Если требуется обратиться к типу в этой сборке через 
// COM, задайте атрибуту ComVisible значение TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("92e44378-abbe-422e-a36a-3c25691bc6f1")]

// Сведения о версии сборки состоят из следующих четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии 
//      Номер построения:
//            0 - Alpha, X - Ver, XX - Hot Fixes
//            1 - Beta, X - Ver, XX - Hot Fixes
//            2 - RC, X - Ver, XX - Hot Fixes
//            3 - Release, X - SP, XX - Hot Fixes
//      Редакция
//
// Можно задать все значения или принять номер построения и номер редакции по умолчанию, 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.3000.50")]
[assembly: AssemblyInformationalVersion("1.0")]

[assembly: ExtensionInfo(
    ExtensionType.Addin,
    "LiveTradingManager",
    "Live Trading Products Manager",
    "Менеджер управления продуктами Live Trading.",
    "1.0",
    "SS.Abramchuk",
    "WLDSolutions.LiveTradingManager.Resources.iconRTT.png",
    ExtensionLicence.Freeware,
    new string[] { "LiveTradingManager.dll" },
    MinDeveloperVersion = "6.4",
    HostApp = ExtensionHostApp.Developer,
    PublisherUrl = @"")]

#if DEBUG
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("LiveTradingManagerUnitTests")]
#endif
[assembly: NeutralResourcesLanguageAttribute("")]
