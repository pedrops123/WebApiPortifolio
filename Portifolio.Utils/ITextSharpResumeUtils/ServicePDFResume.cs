using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Configuration;
using Portifolio.Domain.Entities.ITextSharp;
using Portifolio.Domain.ITextSharp;
using Portifolio.Utils.Configurations;
using System;
using System.IO;
using System.Reflection;

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

        public bool CreateDocument()
        {
            bool response = false;

            try
            {
                string pdfNameCreated = String.Format("{0}_{1}_{2}_{3}.pdf",
                    _configuration.PdfName,
                    DateTime.Now.Year,
                    DateTime.Now.Month.ToString().ToString().PadLeft(2, '0'),
                    DateTime.Now.Day.ToString().ToString().PadLeft(2, '0'));

                CreateDirectory();

                using (_stream = new FileStream(Path.Combine(_directoryFile, pdfNameCreated), FileMode.CreateNew))
                {
                    ConfigurePdf();

                    _writer = PdfWriter.GetInstance(_document, _stream);

                    _document.Open();

                    Paragraph paragraph = new Paragraph("TESTE 123", new Font(Font.NORMAL, 14));

                    _document.Add(paragraph);

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

                response = true;
            }

            return response;
        }

        private void MontaCabecalho()
        {

        }

        private void ConfigurePdf()
        {
            _document = new Document(PageSize.A4, 25, 25, 30, 30);

            _document.AddAuthor("Pedro Vinicius Rodrigues Furlan");
            _document.AddCreator("Curriculum Pedro");
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
    }
}