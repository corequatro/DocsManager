// //DocxDocumetn.cs
// // Copyright (c) 2018 07 03All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using DocsManager.Domain.Entities;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;

namespace DocsManager.Domain.DocumentTypes
{
    public class DocxDocument : BaseDocument
    {
        public override void ProcessDocument()
        {
            WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(FileStream, true);
            if (wordprocessingDocument.ExtendedFilePropertiesPart == null)
                wordprocessingDocument.AddExtendedFilePropertiesPart();
            AddExtraInfo(wordprocessingDocument);
            FillDocumentSpecificInfo(wordprocessingDocument);
            wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Save();
            wordprocessingDocument.Close();
            FileStream.Position = 0;
            DocumentFile = FileStream.ToArray();
            FileType = DocumentTypesEnum.Docx;
            FileStream.Close();
        }

        private void FillDocumentSpecificInfo(WordprocessingDocument wordprocessingDocument)
        {
            Application = wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Application.Text;
            Company = wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Company.Text;
            Manager = wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Manager.Text;
        }

        private static void AddExtraInfo(WordprocessingDocument wordprocessingDocument)
        {
            wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Company = new Company
            {
                Text = "Fluffysoft company"
            };
            wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Manager = new Manager
            {
                Text = "Billy Gates"
            };
            wordprocessingDocument.ExtendedFilePropertiesPart.Properties.Application = new Application
            {
                Text = "docs manager app"
            };
        }
    }
}