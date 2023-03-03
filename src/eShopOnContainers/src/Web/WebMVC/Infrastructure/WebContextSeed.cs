namespace WebMVC.Infrastructure
{
    using ILogger = Serilog.ILogger;

    public class WebContextSeed
    {
        public static void Seed(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
        {
            var log = Log.Logger;

            var settings = applicationBuilder
                .ApplicationServices.GetRequiredService<IOptions<AppSettings>>().Value;

            bool useCustomizationData = settings.UseCustomizationData;
            string contentRootPath = env.ContentRootPath;
            string webroot = env.WebRootPath;

            if (useCustomizationData)
            {
                GetPreconfiguredImages(contentRootPath, webroot, log);

                GetPreconfiguredCSS(contentRootPath, webroot, log);
            }
        }

        private static void GetPreconfiguredCSS(string contentRootPath, string webroot, ILogger log)
        {
            try
            {
                string overrideCssFile = Path.Combine(contentRootPath, "Setup", "override.css");
                if (!File.Exists(overrideCssFile))
                {
                    log.Error("Override css file '{FileName}' does not exists.", overrideCssFile);
                    return;
                }

                string destinationFilename = Path.Combine(webroot, "css", "override.css");
                File.Copy(overrideCssFile, destinationFilename, true);
            }
            catch (Exception ex)
            {
                log.Error(ex, "EXCEPTION ERROR: {Message}", ex.Message);
            }
        }

        private static void GetPreconfiguredImages(string contentRootPath, string webroot, ILogger log)
        {
            try
            {
                string imagesZipFile = Path.Combine(contentRootPath, "Setup", "images.zip");
                if (!File.Exists(imagesZipFile))
                {
                    log.Error("Zip file '{ZipFileName}' does not exists.", imagesZipFile);
                    return;
                }

                string imagePath = Path.Combine(webroot, "images");
                string[] imageFiles = Directory.GetFiles(imagePath).Select(file => Path.GetFileName(file)).ToArray();

                using var zip = ZipFile.Open(imagesZipFile, ZipArchiveMode.Read);
                foreach (var entry in zip.Entries)
                {
                    if (imageFiles.Contains(entry.Name))
                    {
                        string destinationFilename = Path.Combine(imagePath, entry.Name);
                        if (File.Exists(destinationFilename))
                        {
                            File.Delete(destinationFilename);
                        }
                        entry.ExtractToFile(destinationFilename);
                    }
                    else
                    {
                        log.Warning("Skipped file '{FileName}' in zipfile '{ZipFileName}'", entry.Name, imagesZipFile);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "EXCEPTION ERROR: {Message}", ex.Message);
            }
        }
    }
}
