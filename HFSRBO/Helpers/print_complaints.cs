using System;
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
        private bhfsContext db = new bhfsContext();
        public void print_complaint(IEnumerable<complaints> complaints,DateTime date_from,DateTime date_to)
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

            PdfPTable sheet_num = new PdfPTable(1);
            sheet_num.WidthPercentage = 100f;
            float[] sheet_num_withs = { 100 };
            sheet_num.SetWidths(sheet_num_withs);
            String month = "";
            if (date_from.Month == date_to.Month)
            {
                month = date_to.ToString("MMMM");
            }

            sheet_num.AddCell(new PdfPCell(new Paragraph("Month of : " + month, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0, Padding = 5f });
            sheet_num.AddCell(new PdfPCell(new Paragraph("Year : " + date_to.ToString("yyyy") , new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER,Border = 0 , Padding = 5f});

            doc.Add(sheet_num);


            PdfPTable _thead_page_break = new PdfPTable(15);
            _thead_page_break.WidthPercentage = 100f;
            float[] first_with = { 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40 };
            _thead_page_break.SetWidths(first_with);
            

            _thead_page_break.AddCell(new PdfPCell(new Paragraph("DATE RECEIVED", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("CODE", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
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
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("COMMUNICATION", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

            doc.Add(_thead_page_break);
           
           
            PageEvent pe = new PageEvent();
            writer.PageEvent = pe;


            PdfPTable complaints_table = new PdfPTable(15);
            complaints_table.WidthPercentage = 100f;
            _thead_page_break.SetWidths(first_with);

            foreach (complaints complaint in complaints)
            {
                complaints_table.AddCell(new PdfPCell(new Paragraph(complaint.date != null ? complaint.date.Value.ToShortDateString() : "", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph(complaint.Code, new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                var health_facility = db.hospitals.Where(p => p.ID == complaint.hospitalID).FirstOrDefault();
                complaints_table.AddCell(new PdfPCell(new Paragraph(health_facility.name, new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph(EncyptDecrypt.Decrypt(complaint.firstname) + " "+ EncyptDecrypt.Decrypt(complaint.mi) + " " + EncyptDecrypt.Decrypt(complaint.lastname), new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

                var facility_complaints = db.complaint_types_list.Where(p => p.ComplaintID == complaint.ID).ToList();
                String complaint_desc = "";
                foreach (complaint_types_list ctl in facility_complaints)
                {
                    var type = db.type_complaint.Where(p => p.ID == ctl.ComplaintTypeId).FirstOrDefault();
                    complaint_desc += "- " + type.Description + "\n";
                }
                

                complaints_table.AddCell(new PdfPCell(new Paragraph(complaint_desc, new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("ADRESS", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("OWNERSHIP", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("STAFF ASSIGNED", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("ACTION TAKEN", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("DATE INFORMED THE HF/CONCERNED OFFICE", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("DATE HF/CONCERNED OFFICE SUBMITTED REPLY", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("DATE RELEASE TO RECORDS SECTION/CLIENT", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("DATE FINAL RESOLUTION OF THE COMPLAINT RELEASED TO RECORDS SECTION / CLIENT", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("STATUS", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph("COMMUNICATION", new Font(Font.FontFamily.HELVETICA, 8f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });


            }
            doc.Add(complaints_table);

            doc.Close();
        }
    }
}