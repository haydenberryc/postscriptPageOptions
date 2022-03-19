using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace csbatcher.Models;

public static class PrintProcessor
{
    private static readonly Regex _pageCountRegex = new Regex(@"(?<=%%Pages:\s)\d+");
    
    public static async Task ConvertPdfToPs(string pathToPdf, string outputDirectory)
    {
        var x = $"{outputDirectory}";
        var y = $"{(Path.EndsInDirectorySeparator(outputDirectory) ? Path.DirectorySeparatorChar : string.Empty)}";
        var z = $"{Path.GetFileNameWithoutExtension(pathToPdf)}.ps";
        
        var cmd = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = $@"/C pdf2ps {pathToPdf} {outputDirectory}{(Path.EndsInDirectorySeparator(outputDirectory) ? string.Empty : Path.PathSeparator)}{Path.GetFileNameWithoutExtension(pathToPdf)}.ps"
            }
        };
        cmd.Start();
        await cmd.WaitForExitAsync();
    }

    public static string AddPagePrintOptions(this string psAsString, IEnumerable<PagePrintOptions> pdfPagePrintOptions)
    {
        var pageCount = int.Parse(_pageCountRegex.Match(psAsString).Value);
        if (pageCount.Equals(0)) return psAsString;
        
        for (var page = 1; page <= pageCount; page++)
        {
            var regex = new Regex(@$"%%Page: {page} {page}[\w\W\s]*%%EndPageSetup");
            var originalPageSetup = regex.Match(psAsString).Value;
            var firstGt = originalPageSetup.IndexOf(">>", StringComparison.Ordinal);
            var pagePrintOptions = pdfPagePrintOptions.ElementAt(page - 1);
            var printOptions = $"/MediaType ({pagePrintOptions.MediaType.Type})\n/MediaPosition {pagePrintOptions.MediaPosition.Position}\n";
            var newPageSetup = $"{originalPageSetup[..firstGt]}{printOptions}{originalPageSetup[firstGt..]}";
            psAsString = psAsString.Replace(originalPageSetup, newPageSetup);
        }
        return psAsString;
    }
}