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

        public ResponseCreatePdf CreateDocument()
        {
            byte[] byteFile = new byte[0];

            string pdfNameCreated = "";

            try
            {
                pdfNameCreated = String.Format("{0}_{1}_{2}_{3}.pdf",
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

                    MontaCabecalho();


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

            return new ResponseCreatePdf(pdfNameCreated, byteFile);
        }

        private void MontaCabecalho()
        {
            PdfPTable TableHead = new PdfPTable(10);
            PdfPCell HeadCell = new PdfPCell(new Phrase(_configuration.PdfName));

            HeadCell.Colspan = 10;
            

            HeadCell.Border = 1;
            HeadCell.BorderColor = BaseColor.BLACK;
            
            HeadCell.HorizontalAlignment = Element.ALIGN_CENTER;
            HeadCell.VerticalAlignment = Element.ALIGN_CENTER;

            TableHead.AddCell(HeadCell);
            _document.Add(TableHead);
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