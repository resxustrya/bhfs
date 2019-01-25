using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFSRBO
{
    public class PageEvent : PdfPageEventHelper
    {
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            
            PdfPTable _thead_page_break = new PdfPTable(14);
            _thead_page_break.WidthPercentage = 100f;
            float[] _columnWidths = { 40, 40, 40, 40, 40, 40, 40, 40, 40 ,40,40,40,40,40};
            _thead_page_break.SetWidths(_columnWidths);
            _thead_page_break.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin; //this centers [table]

           
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE RECEIVED", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4 ,VerticalAlignment = Element.ALIGN_CENTER});
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("CODE", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("COMMUNICATION", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4 , VerticalAlignment = Element.ALIGN_CENTER});
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("NAME OF HEALTH FACILITY", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("OWNERSHIP", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("NAME OF COMPLAINANT", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("TYPES OF COMPLAINT", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4 , VerticalAlignment = Element.ALIGN_CENTER});
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("ACTION TAKEN", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4 , VerticalAlignment = Element.ALIGN_CENTER});
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE INFORMED THE HF/CONCERNED OFFICE", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE HF/CONCERNED OFFICE SUBMITTED REPLY", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4 , VerticalAlignment = Element.ALIGN_CENTER});
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE RELEASE TO RECORDS SECTION/CLIENT", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4 , VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE FINAL RESOLUTION OF THE COMPLAINT RELEASED TO RECORDS SECTION / CLIENT", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4 , VerticalAlignment = Element.ALIGN_CENTER});
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("STATUS", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4 , VerticalAlignment = Element.ALIGN_CENTER});
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("STAFF ASSIGNED", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

            document.Add(_thead_page_break);
           
        }
    }
}