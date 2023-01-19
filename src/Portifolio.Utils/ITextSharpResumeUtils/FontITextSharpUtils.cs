using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Reflection;
using System.Text;

namespace Portifolio.Utils.ITextSharpResumeUtils
{
    public static class FontITextSharpUtils
    {
        private readonly static string _pathRoot = Assembly.GetAssembly(typeof(FontITextSharpUtils)).Location;

        private readonly static string _pathFont = Path.Combine(_pathRoot.Substring(0, _pathRoot.IndexOf(Assembly.GetAssembly(typeof(ServicePDFResume)).ManifestModule.Name)), "Fonts");

        public static readonly BaseColor colorBaseTitle = new BaseColor(57, 165, 183);

        public static readonly BaseColor colorBaseDefaultSections = BaseColor.BLACK;

        private static Encoding RegisterEncoding1252()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1252 = Encoding.GetEncoding(1252);

            return enc1252;
        }

        public static iTextSharp.text.Font GetTahoma()
        {
            RegisterEncoding1252();

            var fontName = "Tahoma";

            if (!FontFactory.IsRegistered(fontName))
            {
                FontFactory.Register(Path.Combine(_pathFont, "RegularFont.ttf"), fontName);
            }

            return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }

        public static iTextSharp.text.Font GetTahomaBold()
        {
            RegisterEncoding1252();

            var fontName = "TahomaBold";

            if (!FontFactory.IsRegistered(fontName))
            {
                FontFactory.Register(Path.Combine(_pathFont, "TAHOMAB0.TTF"), fontName);
            }

            return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }


        public static Font FontTitle(float size) => new Font(GetTahomaBold().BaseFont, size, Font.NORMAL, colorBaseTitle);
        public static Font FontTitle(float size, BaseColor color, int fontStyle) => new Font(GetTahomaBold().BaseFont, size, fontStyle, color);
        public static Font FontNormal(float size) => new Font(GetTahoma().BaseFont, size, 2, BaseColor.BLACK);
        public static Font FontNormal(float size, BaseColor color) => new Font(GetTahoma().BaseFont, size, 2, color);
    }
}