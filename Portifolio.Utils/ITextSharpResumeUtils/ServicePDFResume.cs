using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Configuration;
using Portifolio.Domain.Entities.ITextSharp;
using Portifolio.Domain.ITextSharp;
using Portifolio.Utils.Configurations;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Portifolio.Utils.ITextSharpResumeUtils
{
    public sealed class ServicePDFResume : ITextSharpUtils
    {
        private readonly string _directoryFile;

        private string _assemblyPath = Assembly.GetAssembly(typeof(ServicePDFResume)).Location;

        private IConfigurationRoot _conf;

        private PdfConfigurations _configuration;

        private Document _document;

        private PdfWriter _writer;

        private FileStream _stream;

        public ServicePDFResume()
        {
            _conf = ConfigurationRootFactory.SetConfigurationRootBuilder();
            _configuration = _conf.GetSection("PdfConfig").Get<PdfConfigurations>();
            _directoryFile = Path.Combine(_assemblyPath.Substring(0, _assemblyPath.IndexOf("bin")), _configuration.TempFile);
        }

        public async Task<ResponseCreatePdf> CreateDocument()
        {
            byte[] byteFile = new byte[0];

            string pdfNameCreated = "";

            try
            {
                pdfNameCreated = String.Format("Curriculum {0} {1}_{2}_{3}.pdf",
                    _configuration.OwnerName,
                    DateTime.Now.Year,
                    DateTime.Now.Month.ToString().ToString().PadLeft(2, '0'),
                    DateTime.Now.Day.ToString().ToString().PadLeft(2, '0'));

                CreateDirectory();

                using (_stream = new FileStream(Path.Combine(_directoryFile, pdfNameCreated), FileMode.CreateNew))
                {
                    ConfigurePdf();

                    _writer = PdfWriter.GetInstance(_document, _stream);

                    _document.Open();

                    SectionHeader();
                    SectionObjective();
                    SectionEducation();
                    SectionExperience();
                    SectionComplementaryInformation();
                    SectionKnowleges();

                    _document.Close();

                    _writer.Close();
                }
            }
            catch (Exception e)
            {
                _stream.Close();

                throw e;
            }
            finally
            {
                _stream.Close();
                byteFile = GetFileBytes();
            }

            var response = Task.FromResult(new ResponseCreatePdf(pdfNameCreated, byteFile));

            return await response;
        }

        private void SectionHeader()
        {
            PdfPTable TableHead = new PdfPTable(10);

            PdfPCell headCell = new PdfPCell(new Paragraph(String.Format("{0}", _configuration.OwnerName), FontITextSharpUtils.FontTitle(25f)));
            headCell.Colspan = 10;
            headCell.PaddingTop = 10f;
            headCell.PaddingBottom = 10f;
            headCell.VerticalAlignment = Element.ALIGN_CENTER;
            headCell.BorderWidthTop = 0f;
            headCell.BorderWidthLeft = 0f;
            headCell.BorderWidthRight = 0f;
            headCell.BorderWidthBottom = 3f;
            headCell.BorderColorBottom = FontITextSharpUtils.colorBaseTitle;

            PdfPCell headDescriptionCell = new PdfPCell(new Paragraph("Brasileiro • {martialStatus} | {address} |{cellphone} | {email} | {gitHubLink} | {linkedinLink}", FontITextSharpUtils.FontNormal(10f)));
            headDescriptionCell.Colspan = 10;
            headDescriptionCell.PaddingTop = 10f;
            headDescriptionCell.PaddingBottom = 10f;
            headDescriptionCell.BorderWidth = 0f;
            headDescriptionCell.VerticalAlignment = Element.ALIGN_CENTER;
            headDescriptionCell.HorizontalAlignment = Element.ALIGN_CENTER;

            TableHead.AddCell(headCell);
            TableHead.AddCell(headDescriptionCell);

            _document.Add(TableHead);
        }

        private void SectionObjective()
        {
            CreateTitleDefaultSection("Objetivos");
        }

        private void SectionEducation()
        {
            CreateTitleDefaultSection("Educação");
        }

        private void SectionExperience()
        {
            CreateTitleDefaultSection("Experiência");
        }

        private void SectionComplementaryInformation()
        {
            CreateTitleDefaultSection("Informações Complementares");
        }

        private void SectionKnowleges()
        {
            CreateTitleDefaultSection("Conhecimentos");
        }

        private void CreateTitleDefaultSection(string descriptionTitle)
        {
            PdfPTable tableTitleSection = new PdfPTable(10);

            PdfPCell titleCell = new PdfPCell(new Paragraph(descriptionTitle, FontITextSharpUtils.FontTitle(15f, FontITextSharpUtils.colorBaseDefaultSections)));
            titleCell.Colspan = 10;
            titleCell.VerticalAlignment = Element.ALIGN_CENTER;
            titleCell.BorderWidthTop = 0f;
            titleCell.BorderWidthLeft = 0f;
            titleCell.BorderWidthRight = 0f;
            titleCell.PaddingTop = 15f;
            titleCell.PaddingBottom = 10f;
            titleCell.BorderColorBottom = FontITextSharpUtils.colorBaseDefaultSections;

            tableTitleSection.AddCell(titleCell);

            _document.Add(tableTitleSection);
        }

        private void ConfigurePdf()
        {
            _document = new Document(PageSize.A4, 25, 25, 30, 30);

            _document.AddAuthor(_configuration.OwnerName);
            _document.AddCreator($"Curriculum { _configuration.OwnerName }");
            _document.AddKeywords("PDF curriculum");
            _document.AddTitle("Curriculum customizado");
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(_directoryFile))
            {
                Directory.CreateDirectory(_directoryFile);
            }
        }

        private byte[] GetFileBytes()
        {

            var files = Directory.GetFiles(_directoryFile);

            var fileBytes = System.IO.File.ReadAllBytes(files[0]);

            foreach (string pathFiles in files)
            {
                if (File.Exists(pathFiles))
                {
                    GC.Collect(0, GCCollectionMode.Forced, false);
                    File.Delete(pathFiles);
                }
            }

            Directory.Delete(_directoryFile);

            return fileBytes;
        }
    }
}