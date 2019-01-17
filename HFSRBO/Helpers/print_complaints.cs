﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HFSRBO
{
    public class print_complaints
    {
        public void print_complaint(IEnumerable<complaints> complaints)
        {
            try
            {
                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/PDF/complaints.pdf"));
            }
            catch
            { }

            Document doc = new Document(PageSize.LEGAL.Rotate());
            var output = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/PDF/complaints.pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);
            
            doc.Open();

            PdfPTable header = new PdfPTable(2);
            header.WidthPercentage = 80f;
            float[] _columnWidths = { 10, 80 };
            header.SetWidths(_columnWidths);
            header.HorizontalAlignment = Element.ALIGN_LEFT;


            Image logo2 = Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("~/PDF/doh.png"));
            logo2.ScaleAbsolute(60f, 60f);

            header.AddCell(new PdfPCell(logo2) { HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_LEFT, Rowspan = 4,Border = 0 });
            header.AddCell(new PdfPCell(new Paragraph("REPUBLIC OF THE PHILIPPINES")) { HorizontalAlignment = Element.ALIGN_CENTER,Border = 0 });
            header.AddCell(new PdfPCell(new Paragraph("Department of Health")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0});
            header.AddCell(new PdfPCell(new Paragraph("HEALTH FACILITIES AND SERVICES REGULATORY BUREAU/REGIONAL OFFICE VII")) { HorizontalAlignment = Element.ALIGN_CENTER,Border = 0 });
            header.AddCell(new PdfPCell(new Paragraph("LOGSHEET OF COMPLAINTS")) { HorizontalAlignment = Element.ALIGN_CENTER ,Border = 0});

            doc.Add(header);

            PdfPTable _thead_page_break = new PdfPTable(15);
            _thead_page_break.WidthPercentage = 100f;
            float[] first_with = { 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40 };
            _thead_page_break.SetWidths(first_with);
            

            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE RECEIVED", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("CODE", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("COMMUNICATION", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("NAME OF HEALTH FACILITY", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("NAME OF COMPLAINANT", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("TYPES OF COMPLAINT", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("ADRESS", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("OWNERSHIP", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("STAFF ASSIGNED", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("ACTION TAKEN", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE INFORMED THE HF/CONCERNED OFFICE", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE HF/CONCERNED OFFICE SUBMITTED REPLY", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE RELEASE TO RECORDS SECTION/CLIENT", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE FINAL RESOLUTION OF THE COMPLAINT RELEASED TO RECORDS SECTION / CLIENT", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("STATUS", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

            doc.Add(_thead_page_break);

            doc.NewPage();
            PageEvent pe = new PageEvent();
            writer.PageEvent = pe;
            doc.Add(new Paragraph("List of Complaints"));
            
            doc.Close();
        }
    }
}