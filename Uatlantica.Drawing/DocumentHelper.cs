using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace Uatlantica.Drawing
{
    public class DocumentHelper
    {

        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        public static string SaveImage(Image image)
        {
            return SaveImage(image, false);
        }

        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="Transparency">if set to <c>true</c> [transparency].</param>
        /// <returns></returns>
        public static string SaveImage(Image image, bool Transparency)
        {
            Image img = new Bitmap(image.Width, image.Height);

            if (Transparency == false)
            {
                StatisticalChart.SetBackground(ref img);
            }

            Graphics g = Graphics.FromImage(img);
            g.DrawImage(image, 0, 0, image.Width, image.Height);

            string strPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
            img.Save(strPath, ImageFormat.Png);

            return strPath;
        }

        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="image">The image.</param>
        public static void SaveImageToDocument(string filepath, Image image)
        {
            string strPath = SaveImage(image, true);
            ImagePart imagePart;

            using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(filepath, true))
            {
                MainDocumentPart mainPart = wordprocessingDocument.MainDocumentPart;

                using (FileStream stream = new FileStream(strPath, FileMode.Open))
                {
                    imagePart = mainPart.AddImagePart(ImagePartType.Png);
                    imagePart.FeedData(stream);
                }

                AddImageToBody(wordprocessingDocument.MainDocumentPart.Document.Body, mainPart.GetIdOfPart(imagePart), image);
            }

            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }
        }

        private static void AddImageToBody(OpenXmlElement mainElement, string relationshipId, Image image)
        {
            long cx = (long)image.Width * (long)((float)914400 / image.HorizontalResolution);
            long cy = (long)image.Height * (long)((float)914400 / image.VerticalResolution);

            // Define the reference of the image.
            var element =
                 new A.Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = cx, Cy = cy },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = System.Guid.NewGuid().ToString()
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = System.Guid.NewGuid().ToString() + ".png"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                       "{" + System.Guid.NewGuid().ToString() + "}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = cx, Cy = cy }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         ) { Preset = A.ShapeTypeValues.Rectangle }))
                             ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     ));

            // Append the reference to body, the element should be in a Run.
            mainElement.AppendChild(new Paragraph(new Run(element)));
        }

    }
}
