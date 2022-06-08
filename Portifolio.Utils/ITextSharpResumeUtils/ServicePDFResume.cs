using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Configuration;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Entities.ITextSharp;
using Portifolio.Domain.Entities.PdfResume;
using Portifolio.Domain.Enums;
using Portifolio.Domain.ITextSharp;
using Portifolio.Utils.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private string _defaultTemplate
        {
            get
            {
                return "Brasileiro • {martialStatus} | {address} | {cellphone} | {email} | {gitHubLink} |{linkedinLink}";
            }
        }

        public ServicePDFResume()
        {
            _conf = ConfigurationRootFactory.SetConfigurationRootBuilder();
            _configuration = _conf.GetSection("PdfConfig").Get<PdfConfigurations>();
            _directoryFile = Path.Combine(_assemblyPath.Substring(0, _assemblyPath.IndexOf("bin")), _configuration.TempFile);
        }

        public async Task<ResponseCreatePdf> CreateDocument()
        {
            byte[] byteFile = new byte[0];

            var topics = GenerateMockResume.Generate();

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

                    ConfigureGradient();

                    SectionHeader(topics.InitialParameters);

                    foreach (TopicResume topic in topics.Topics.OrderBy(r => r.Order))
                    {
                        CreateTopicTitle(topic.Description);

                        foreach (SubTopicResume subTopic in topic.SubTopics.OrderBy(r => r.Order))
                        {
                            CreateSubTopicTitle(subTopic.Description, subTopic.ItemsSubTopic, subTopic.IsBold);
                        }
                    }

                    KnowlegesSection();

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


        #region TopicsResume

        private void CreateTopicTitle(string descriptionTopicTitle)
        {
            PdfPTable tableTitleSection = new PdfPTable(10);

            PdfPCell titleCell = new PdfPCell(new Paragraph(descriptionTopicTitle, FontITextSharpUtils.FontTitle(15f, FontITextSharpUtils.colorBaseDefaultSections)));
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

        private void CreateSubTopicTitle(string descriptionSubTopic, List<ItemsSubTopicResume> listItems, bool isBold)
        {
            PdfPTable tableSubTopic = new PdfPTable(10);

            List unorderedListPrincipal = new List(List.UNORDERED, 10f);
            unorderedListPrincipal.SetListSymbol("\u2022");

            ListItem listItemPrincipal = new ListItem(new Paragraph(descriptionSubTopic, isBold ? FontITextSharpUtils.FontTitle(10f, BaseColor.BLACK) : FontITextSharpUtils.FontNormal(10f, BaseColor.BLACK)));

            unorderedListPrincipal.Add(listItemPrincipal);

            PdfPCell subTopicCell = new PdfPCell();
            subTopicCell.Colspan = 10;
            subTopicCell.Border = 0;
            subTopicCell.PaddingTop = 10f;
            subTopicCell.AddElement(unorderedListPrincipal);

            tableSubTopic.AddCell(subTopicCell);

            if (listItems.Count != 0)
            {
                foreach (ItemsSubTopicResume item in listItems.OrderBy(r => r.Order))
                {
                    List unorderedListItem = new List(List.UNORDERED, 10f);
                    unorderedListItem.IndentationLeft = 20f;
                    unorderedListItem.SetListSymbol("◦");

                    ListItem listItemsub = new ListItem(new Paragraph(item.Description, FontITextSharpUtils.FontNormal(8f, BaseColor.BLACK)));

                    unorderedListItem.Add(listItemsub);

                    PdfPCell ItemsubTopicCell = new PdfPCell();
                    ItemsubTopicCell.Colspan = 10;
                    ItemsubTopicCell.Border = 0;
                    ItemsubTopicCell.AddElement(unorderedListItem);
                    tableSubTopic.AddCell(ItemsubTopicCell);
                }

            }

            _document.Add(tableSubTopic);
        }

        #endregion


        #region configurations

        private void ConfigurePdf()
        {
            _document = new Document(PageSize.A4, 2, 25, 30, 30);

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

        private void ConfigureGradient()
        {
            Rectangle pageSize = new Rectangle(PageSize.A4);

            PdfShading shading = PdfShading.SimpleAxial(_writer, 100f, 50f, 50f, 50f, FontITextSharpUtils.colorBaseTitle, BaseColor.WHITE);

            PdfShadingPattern pattern = new PdfShadingPattern(shading);

            PdfContentByte canvas = _writer.DirectContent;

            canvas.SetShadingFill(pattern);

            canvas.Rectangle(0, 0, pageSize.Width, pageSize.Height);
            canvas.Fill();
        }

        #endregion


        #region SectionsResume

        private void SectionHeader(ICollection<GeneralParameters> parameters)
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

            PdfPCell headDescriptionCell = new PdfPCell(new Paragraph(PreparePersonalInformations(_defaultTemplate, parameters), FontITextSharpUtils.FontNormal(10f)));
            headDescriptionCell.Colspan = 10;
            headDescriptionCell.PaddingTop = 10f;
            headDescriptionCell.PaddingBottom = 10f;
            headDescriptionCell.BorderWidth = 0f;

            TableHead.AddCell(headCell);
            TableHead.AddCell(headDescriptionCell);

            _document.Add(TableHead);
        }

        private void KnowlegesSection()
        {
            _document.NewPage();

            CreateTopicTitle("Conhecimentos");

            CreateSpaceLines(4);

            IEnumerable<string> listOfTopics = new List<string>() { "FRONT END", "BACK END", "BANCO DE DADOS", "MOBILE", "API'S" };

            IEnumerable<string[]> listOfKnowleges = new List<string[]>()
            {
                new string[]{ "HTML 5" , "C# / ASP.NET" , "Microsoft SQL", "Android (Kotlin)" , "RestFull" },
                new string[]{ "CSS 3" , ".NET CORE", "Mongo DB", "Flutter (Iniciante)" , "SOAP" },
                new string[]{ "Bootstrap 4" , "Java" , "Fire Base", "" , "" },
                new string[]{ "Java Script" , "Python" , "MySql", "" , "" },
                new string[]{ "Type Script" , "Visual Basic" , "", "" , "" },
                new string[]{ "CSS Grid Layout" , "PHP" , "", "" , "" },
                new string[]{ "CSS Flex Box" , "Docker" , "", "" , "" },
                new string[]{ "" , "Node JS", "", "" , "" },
            };

            PdfPTable knowlegesTable = new PdfPTable(new float[] { 2, 2, 2, 2, 2 });

            foreach (string topics in listOfTopics)
            {
                knowlegesTable.AddCell(CreateCellTitleTableKnowleges(topics));
            }

            PdfPCell blankCell = new PdfPCell(new Paragraph(" "));

            blankCell.Border = 0;

            knowlegesTable.AddCell(blankCell);
            knowlegesTable.AddCell(blankCell);
            knowlegesTable.AddCell(blankCell);
            knowlegesTable.AddCell(blankCell);
            knowlegesTable.AddCell(blankCell);

            foreach (string[] record in listOfKnowleges)
            {
                PdfPCell FrontItemCell = CreateCellDescriptionTableKnowleges(record[0]);

                PdfPCell BackItemCell = CreateCellDescriptionTableKnowleges(record[1]);

                PdfPCell BDItemCell = CreateCellDescriptionTableKnowleges(record[2]);

                PdfPCell MobileItemCell = CreateCellDescriptionTableKnowleges(record[3]);

                PdfPCell APISItemCell = CreateCellDescriptionTableKnowleges(record[4]);

                knowlegesTable.AddCell(FrontItemCell);

                knowlegesTable.AddCell(BackItemCell);

                knowlegesTable.AddCell(BDItemCell);

                knowlegesTable.AddCell(MobileItemCell);

                knowlegesTable.AddCell(APISItemCell);
            }

            _document.Add(knowlegesTable);
        }

        private string PreparePersonalInformations(string template, ICollection<GeneralParameters> parameters)
        {
            if (template.ToLower().Contains("{martialstatus}"))
            {
                template = template.Replace("{martialStatus}", parameters.Where(r => r.Key == (ResumeParameters.MartialStatus).ToString()).First().Value);
            }

            if (template.ToLower().Contains("{address}"))
            {
                template = template.Replace("{address}", parameters.Where(r => r.Key == (ResumeParameters.Address).ToString()).First().Value);
            }

            if (template.ToLower().Contains("{cellphone}"))
            {
                template = template.Replace("{cellphone}", parameters.Where(r => r.Key == (ResumeParameters.CellPhone).ToString()).First().Value);
            }

            if (template.ToLower().Contains("{email}"))
            {
                template = template.Replace("{email}", parameters.Where(r => r.Key == (ResumeParameters.Email).ToString()).First().Value);
            }

            if (template.ToLower().Contains("{githublink}"))
            {
                template = template.Replace("{gitHubLink}", parameters.Where(r => r.Key == (ResumeParameters.GitHubLink).ToString()).First().Value);
            }

            if (template.ToLower().Contains("{linkedinlink}"))
            {
                template = template.Replace("{linkedinLink}", parameters.Where(r => r.Key == (ResumeParameters.LinkedinLink).ToString()).First().Value);
            }

            return template;
        }

        #endregion


        #region utilities

        private PdfPCell CreateCellTitleTableKnowleges(string description)
        {
            float sizeFontTitles = 9f;

            PdfPCell titleTableCell = new PdfPCell(new Paragraph(description, FontITextSharpUtils.FontTitle(sizeFontTitles, BaseColor.BLACK)));
            titleTableCell.PaddingTop = 2f;
            titleTableCell.PaddingBottom = 2f;
            titleTableCell.Border = 0;
            titleTableCell.VerticalAlignment = Element.ALIGN_CENTER;
            titleTableCell.HorizontalAlignment = Element.ALIGN_CENTER;

            return titleTableCell;
        }

        private PdfPCell CreateCellDescriptionTableKnowleges(string description)
        {
            float sizeFontItem = 8f;

            PdfPCell ItemTableCell = new PdfPCell(new Paragraph(description, FontITextSharpUtils.FontNormal(sizeFontItem, BaseColor.BLACK)));
            ItemTableCell.Border = 0;
            ItemTableCell.VerticalAlignment = Element.ALIGN_CENTER;
            ItemTableCell.HorizontalAlignment = Element.ALIGN_CENTER;

            return ItemTableCell;
        }

        private void CreateSpaceLines(int numberOfTimes)
        {

            PdfPTable tableSpaceLines = new PdfPTable(10);

            for (int numbers = 1; numbers <= numberOfTimes; numbers++)
            {
                PdfPCell blankCell = new PdfPCell(new Phrase(" "));
                blankCell.Border = 0;
                tableSpaceLines.AddCell(blankCell);
            }

            _document.Add(tableSpaceLines);
        }

        #endregion
    }
}