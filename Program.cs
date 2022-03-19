using csbatcher.Models;

await PrintProcessor.ConvertPdfToPs(@"D:\Dev\Postscript\test.pdf", @"D:\Dev\Postscript\csbatcher\csbatcher\bin\Debug\net6.0\ps\");
var psFile = File.ReadAllText("./ps/test.ps");

var pagePrintOptions = new List<PagePrintOptions>()
{
    new(){MediaType = MediaType.Plain, MediaPosition = MediaPosition.Tray2},
    new(){MediaType = MediaType.Plain, MediaPosition = MediaPosition.Tray2},
    new(){MediaType = MediaType.Perforated, MediaPosition = MediaPosition.Tray3},
    new(){MediaType = MediaType.Perforated, MediaPosition = MediaPosition.Tray3},
    new(){MediaType = MediaType.Perforated, MediaPosition = MediaPosition.Tray3},
    new(){MediaType = MediaType.Perforated, MediaPosition = MediaPosition.Tray3},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.Perforated, MediaPosition = MediaPosition.Tray3},
    new(){MediaType = MediaType.Perforated, MediaPosition = MediaPosition.Tray3},
    new(){MediaType = MediaType.Perforated, MediaPosition = MediaPosition.Tray3},
    new(){MediaType = MediaType.Perforated, MediaPosition = MediaPosition.Tray3},
    new(){MediaType = MediaType.Perforated, MediaPosition = MediaPosition.Tray3},
    new(){MediaType = MediaType.Plain, MediaPosition = MediaPosition.Tray2},
    new(){MediaType = MediaType.Plain, MediaPosition = MediaPosition.Tray2},
    new(){MediaType = MediaType.Plain, MediaPosition = MediaPosition.Tray2},
    new(){MediaType = MediaType.Plain, MediaPosition = MediaPosition.Tray2},
    new(){MediaType = MediaType.Plain, MediaPosition = MediaPosition.Tray2},
    new(){MediaType = MediaType.Plain, MediaPosition = MediaPosition.Tray2},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.CardStock, MediaPosition = MediaPosition.Tray1},
    new(){MediaType = MediaType.Plain, MediaPosition = MediaPosition.Tray2}
};
psFile = psFile.AddPagePrintOptions(pagePrintOptions);

await using var writer = File.CreateText("./ps/new/test.ps");
writer.Write(psFile);