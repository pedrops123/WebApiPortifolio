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

            var topics = await Task.FromResult(GenerateMockResume.Generate());

            string completeName = topics.InitialParameters.Where(r => r.Key == (ResumeParameters.CompleteName).ToString()).First().Value;

            string pdfNameCreated = "";

            try
            {
                pdfNameCreated = String.Format("Curriculum {0} {1}_{2}_{3}.pdf",
                    completeName,
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

                    SectionHeader(topics.InitialParameters, completeName);

                    foreach (TopicResume topic in topics.Topics.OrderBy(r => r.Order))
                    {
                        CreateTopicTitle(topic.Description);

                        foreach (SubTopicResume subTopic in topic.SubTopics.OrderBy(r => r.Order))
                        {
                            CreateSubTopicTitle(subTopic.Description, subTopic.ItemsSubTopic, subTopic.IsBold);
                        }
                    }

                    KnowlegesSection(
                        topics.ListOfTopicsTechnologies,
                        topics.ListOfKnowlegesTechnologies,
                        topics.ListOfTopicsFrameworks,
                        topics.ListOfKnowlegesFrameworks);

                    _document.Close();

                    _writer.Close();
                }
            }
            catch (Exception)
            {
                _stream.Close();

                throw;
            }
            finally
            {
                _stream.Close();

                byteFile = GetFileBytes();
            }

            return new ResponseCreatePdf(pdfNameCreated, byteFile);
        }


        #region TopicsResume

        private void CreateTopicTitle(string descriptionTopicTitle, bool center = false, bool bottomLine = true)
        {
            PdfPTable tableTitleSection = new PdfPTable(10);

            PdfPCell titleCell = new PdfPCell(new Paragraph(descriptionTopicTitle, FontITextSharpUtils.FontTitle(15f, FontITextSharpUtils.colorBaseDefaultSections, Font.NORMAL)));
            titleCell.Colspan = 10;
            titleCell.VerticalAlignment = Element.ALIGN_CENTER;

            if (center)
            {
                titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }

            titleCell.BorderWidthTop = 0f;
            titleCell.BorderWidthLeft = 0f;
            titleCell.BorderWidthRight = 0f;
            titleCell.PaddingTop = 15f;

            if (bottomLine)
            {
                titleCell.PaddingBottom = 10f;
                titleCell.BorderColorBottom = FontITextSharpUtils.colorBaseDefaultSections;
            }
            else
            {
                titleCell.PaddingBottom = 0f;
                titleCell.BorderColorBottom = BaseColor.WHITE;
            }

            tableTitleSection.AddCell(titleCell);

            _document.Add(tableTitleSection);
        }

        private void CreateSubTopicTitle(string descriptionSubTopic, List<ItemsSubTopicResume> listItems, bool isBold)
        {
            PdfPTable tableSubTopic = new PdfPTable(10);

            List unorderedListPrincipal = new List(List.UNORDERED, 10f);
            unorderedListPrincipal.SetListSymbol("\u2022");

            ListItem listItemPrincipal = new ListItem(new Paragraph(descriptionSubTopic, isBold ? FontITextSharpUtils.FontTitle(10f, BaseColor.BLACK, Font.NORMAL) : FontITextSharpUtils.FontNormal(10f, BaseColor.BLACK)));

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

                    PdfPCell itemSubTopicCell = new PdfPCell();
                    itemSubTopicCell.Colspan = 10;
                    itemSubTopicCell.Border = 0;
                    itemSubTopicCell.AddElement(unorderedListItem);
                    tableSubTopic.AddCell(itemSubTopicCell);
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
            _document.AddCreator(_configuration.OwnerName);
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

            PdfShading shading = PdfShading.SimpleAxial(_writer, pageSize.Width, 28f, pageSize.Height, 90f, BaseColor.WHITE, FontITextSharpUtils.colorBaseTitle);

            PdfShadingPattern pattern = new PdfShadingPattern(shading);

            PdfContentByte canvas = _writer.DirectContent;

            canvas.SetShadingFill(pattern);

            canvas.Rectangle(0, 0, pageSize.Width, pageSize.Height);
            canvas.Fill();
        }

        #endregion


        #region SectionsResume

        private void SectionHeader(ICollection<GeneralParameters> parameters, string completeName)
        {
            PdfPTable tableHead = new PdfPTable(10);

            PdfPCell headCell = new PdfPCell(new Paragraph(String.Format("{0}", completeName), FontITextSharpUtils.FontTitle(25f)));
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

            tableHead.AddCell(headCell);
            tableHead.AddCell(headDescriptionCell);

            _document.Add(tableHead);
        }

        private void KnowlegesSection(
            IEnumerable<string> listOfTopicsTechnologies,
            IEnumerable<string[]> listOfKnowlegesTechnologies,
            IEnumerable<string> listOfTopicsFrameworks,
            IEnumerable<string[]> listOfKnowlegesFrameworks)
        {
            _document.NewPage();

            CreateTopicTitle("Conhecimentos");

            CreateSpaceLines(4);

            /* TABELA TECNOLOGIAS */

            PdfPTable knowlegesTableTechnologies = new PdfPTable(new float[] { 2, 2, 2, 2, 2 });

            foreach (string topics in listOfTopicsTechnologies)
            {
                knowlegesTableTechnologies.AddCell(CreateCellTitleTableKnowleges(topics));
            }

            PdfPCell blankCellTechnologies = new PdfPCell(new Paragraph(" "));

            blankCellTechnologies.Border = 0;

            knowlegesTableTechnologies.AddCell(blankCellTechnologies);
            knowlegesTableTechnologies.AddCell(blankCellTechnologies);
            knowlegesTableTechnologies.AddCell(blankCellTechnologies);
            knowlegesTableTechnologies.AddCell(blankCellTechnologies);
            knowlegesTableTechnologies.AddCell(blankCellTechnologies);

            foreach (string[] record in listOfKnowlegesTechnologies)
            {
                PdfPCell frontItemCell = CreateCellDescriptionTableKnowleges(record[0]);

                PdfPCell backItemCell = CreateCellDescriptionTableKnowleges(record[1]);

                PdfPCell bdItemCell = CreateCellDescriptionTableKnowleges(record[2]);

                PdfPCell mobileItemCell = CreateCellDescriptionTableKnowleges(record[3]);

                PdfPCell apisItemCell = CreateCellDescriptionTableKnowleges(record[4]);

                knowlegesTableTechnologies.AddCell(frontItemCell);

                knowlegesTableTechnologies.AddCell(backItemCell);

                knowlegesTableTechnologies.AddCell(bdItemCell);

                knowlegesTableTechnologies.AddCell(mobileItemCell);

                knowlegesTableTechnologies.AddCell(apisItemCell);
            }

            _document.Add(knowlegesTableTechnologies);

            /* TABELA FRAMEWORKS  */

            CreateTopicTitle("Frameworks", true, false);

            CreateSpaceLines(10);

            PdfPTable knowlegesTableFrameworks = new PdfPTable(new float[] { 2, 2, 2, 2, 2 });

            foreach (string topics in listOfTopicsFrameworks)
            {
                knowlegesTableFrameworks.AddCell(CreateCellTitleTableKnowleges(topics));
            }

            knowlegesTableFrameworks.AddCell(CreateCellTitleTableKnowleges(""));
            knowlegesTableFrameworks.AddCell(CreateCellTitleTableKnowleges(""));

            PdfPCell blankCellFrameworks = new PdfPCell(new Paragraph(" "));

            blankCellFrameworks.Border = 0;

            knowlegesTableFrameworks.AddCell(blankCellFrameworks);
            knowlegesTableFrameworks.AddCell(blankCellFrameworks);
            knowlegesTableFrameworks.AddCell(blankCellFrameworks);
            knowlegesTableFrameworks.AddCell(blankCellFrameworks);
            knowlegesTableFrameworks.AddCell(blankCellFrameworks);

            foreach (string[] record in listOfKnowlegesFrameworks)
            {
                PdfPCell emptyItemCellfirst = CreateCellDescriptionTableKnowleges(record[0]);

                PdfPCell netItemCell = CreateCellDescriptionTableKnowleges(record[1]);

                PdfPCell frontItemCell = CreateCellDescriptionTableKnowleges(record[2]);

                PdfPCell nodetemCell = CreateCellDescriptionTableKnowleges("");

                PdfPCell emptyItemCellLast = CreateCellDescriptionTableKnowleges("");

                knowlegesTableFrameworks.AddCell(emptyItemCellfirst);

                knowlegesTableFrameworks.AddCell(netItemCell);

                knowlegesTableFrameworks.AddCell(frontItemCell);

                knowlegesTableFrameworks.AddCell(nodetemCell);

                knowlegesTableFrameworks.AddCell(emptyItemCellLast);
            }

            _document.Add(knowlegesTableFrameworks);
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

            PdfPCell titleTableCell = new PdfPCell(new Paragraph(description, FontITextSharpUtils.FontTitle(sizeFontTitles, BaseColor.BLACK, Font.NORMAL)));
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

            PdfPCell itemTableCell = new PdfPCell(new Paragraph(description, FontITextSharpUtils.FontNormal(sizeFontItem, BaseColor.BLACK)));
            itemTableCell.Border = 0;
            itemTableCell.VerticalAlignment = Element.ALIGN_CENTER;
            itemTableCell.HorizontalAlignment = Element.ALIGN_CENTER;

            return itemTableCell;
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