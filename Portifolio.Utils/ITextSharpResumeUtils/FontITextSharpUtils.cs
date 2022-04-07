using iTextSharp.text;

namespace Portifolio.Utils.ITextSharpResumeUtils
{
    public static class FontITextSharpUtils
    {
        private static readonly BaseColor _colorBaseTitle = new BaseColor(161, 189, 244);

        public static Font FontTitle() => new Font(Font.FontFamily.TIMES_ROMAN, 30f, 2, _colorBaseTitle);
    }
}
