using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using HFSRBO.Core;

namespace HFSRBO.WebClient
{
    public class ComplaintPDFReport
    {
        public void createReport(IEnumerable<DisplayComplaintViewModel> complaintData, FilterViewModel filterViewData)
        {
            try
            {
                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/Content/PDF/complaints.pdf"));
            }
            catch
            { }

            Document doc = new Document(PageSize.LEGAL.Rotate());
            var output = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/Content/PDF/complaints.pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);

            doc.Open();

            PdfPTable header = new PdfPTable(2);
            header.WidthPercentage = 80f;
            float[] _columnWidths = { 10, 80 };
            header.SetWidths(_columnWidths);
            header.HorizontalAlignment = Element.ALIGN_LEFT;


            Image logo2 = Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("~/Content/PDF/doh.png"));
            logo2.ScaleAbsolute(60f, 60f);

            header.AddCell(new PdfPCell(logo2) { HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_LEFT, Rowspan = 4, Border = 0 });
            header.AddCell(new PdfPCell(new Paragraph("REPUBLIC OF THE PHILIPPINES")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 });
            header.AddCell(new PdfPCell(new Paragraph("Department of Health")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 });
            header.AddCell(new PdfPCell(new Paragraph("HEALTH FACILITIES AND SERVICES REGULATORY BUREAU/REGIONAL OFFICE VII")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 });
            header.AddCell(new PdfPCell(new Paragraph("LOGSHEET OF COMPLAINTS")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 });

            doc.Add(header);


            PdfPTable sheet_num = new PdfPTable(1);
            sheet_num.WidthPercentage = 100f;
            float[] sheet_num_withs = { 100 };
            sheet_num.SetWidths(sheet_num_withs);

            DateTime date_from = Convert.ToDateTime(filterViewData.date_from);
            DateTime date_to = Convert.ToDateTime(filterViewData.date_to);

            String month = "";
            if (date_from.Month == date_to.Month)
                month = date_to.ToString("MMMM");
            else
                month = date_to.ToString("MMMM");

            sheet_num.AddCell(new PdfPCell(new Paragraph("Month of : " + month, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0, Padding = 5f });
            sheet_num.AddCell(new PdfPCell(new Paragraph("Year : " + date_to.ToString("yyyy"), new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0, Padding = 5f });

            doc.Add(sheet_num);

            PdfPTable _thead_page_break = new PdfPTable(16);
            _thead_page_break.WidthPercentage = 100f;
            float[] main = { 40, 40, 40, 40, 40, 40, 50, 50, 40, 40, 40, 40, 40, 40,40,40 };
            _thead_page_break.SetWidths(main);


            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Date Received", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Code Number", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Name of Health Facility Being Complained", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Address", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Ownership", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Name of Complainant", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Types of Complaint", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Assistance Needed", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Form of Communication", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Action Taken", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Date Informed the HF/concerned office", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Date HF/concerned office submitted reply", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Date released to records section", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Date Resolution of the complaint released to records/client", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Status", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            _thead_page_break.AddCell(new PdfPCell(new Paragraph("Staff Assigned", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

            doc.Add(_thead_page_break);

            PdfPTable complaints_table = new PdfPTable(16);
            complaints_table.WidthPercentage = 100f;
            complaints_table.SetWidths(main);

            PageEvent pe = new PageEvent();
            writer.PageEvent = pe;

            foreach (DisplayComplaintViewModel c in complaintData)
            {
                complaints_table.AddCell(new PdfPCell(new Paragraph(c.dateCreated.ToShortDateString() , new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph(c.codeNumber, new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph(c.hospitalName, new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_LEFT, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph(c.hospitalAddress, new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_LEFT, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph(c.ownership == "P" ? "Private" : "Government", new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph(c.annonymos == true ? c.nameOfComplainant : "Anonymous", new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

                Paragraph complaint_type = new Paragraph();
                if (c.complaint_type != null && c.complaint_type.Count() > 0)
                {
                    foreach (string complaintType in c.complaint_type)
                        complaint_type.Add(new Chunk(complaintType + "\n", new Font(Font.FontFamily.HELVETICA, 7f)));

                    if(c.other_complaint != null)
                        complaint_type.Add(new Chunk("Others : " + c.other_complaint, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL)));
                    complaints_table.AddCell(new PdfPCell(complaint_type) { HorizontalAlignment = Element.ALIGN_LEFT, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                }
                else
                {
                    if(c.other_complaint != null)
                    {
                        Chunk otherComplaint = new Chunk("Others : " + c.other_complaint, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL));
                        complaint_type.Add(otherComplaint);
                        complaints_table.AddCell(new PdfPCell(complaint_type) { HorizontalAlignment = Element.ALIGN_LEFT, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                    } else
                        complaints_table.AddCell(new PdfPCell(new Paragraph("-")) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                }

                Paragraph complaint_assistance = new Paragraph();
                if (c.assistanceNeeded != null && c.assistanceNeeded.Count() > 0)
                {
                    foreach (string complaintAssistance in c.assistanceNeeded)
                        complaint_assistance.Add(new Chunk(complaintAssistance + "\n", new Font(Font.FontFamily.HELVETICA, 7f)));
                    if(c.otherAssistanceNeed != null)
                        complaint_assistance.Add(new Chunk("Others : " + c.otherAssistanceNeed, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL)));
                    complaints_table.AddCell(new PdfPCell(complaint_assistance) { HorizontalAlignment = Element.ALIGN_LEFT, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                    
                }
                else
                {
                    if(c.otherAssistanceNeed != null)
                    {
                        Chunk otherAssistance = new Chunk("Others : " + c.otherAssistanceNeed, new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL));
                        complaint_assistance.Add(otherAssistance);
                        complaints_table.AddCell(new PdfPCell(complaint_assistance) { HorizontalAlignment = Element.ALIGN_LEFT, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                    }else
                        complaints_table.AddCell(new PdfPCell(new Paragraph("-")) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

                }

                complaints_table.AddCell(new PdfPCell(new Paragraph(c.pccCheck == true ? "PCC No. " + c.pccNumber : c.communication_form , new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

                if (c._complaintActionDates != null && c._complaintActionDates.Count() > 0)
                {
                    Paragraph complaint_action_dates = new Paragraph();
                    foreach (complaint_action_dates acd in c._complaintActionDates)
                        complaint_action_dates.Add(new Chunk("(" + acd.Date.ToShortDateString() + ") " + acd.Action + "\n", new Font(Font.FontFamily.HELVETICA, 7f)));
                    complaints_table.AddCell(new PdfPCell(complaint_action_dates) { HorizontalAlignment = Element.ALIGN_LEFT, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                }
                else
                {
                    complaints_table.AddCell(new PdfPCell(new Paragraph("-", new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                }

                if (c.date_informed_the_hf != null && c.date_informed_the_hf.Count() > 0)
                {
                    Paragraph p_date_informed_the_hf = new Paragraph();
                    foreach (String s in c.date_informed_the_hf)
                        p_date_informed_the_hf.Add(new Chunk(s + "\n", new Font(Font.FontFamily.HELVETICA, 7f)));
                    complaints_table.AddCell(new PdfPCell(p_date_informed_the_hf) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                }
                else
                {
                    complaints_table.AddCell(new PdfPCell(new Paragraph("-", new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                }
                if (c.date_hf_submitted_reply != null && c.date_hf_submitted_reply.Count() > 0)
                {
                    Paragraph p_date_hf_submitted_reply = new Paragraph();
                    foreach (String s in c.date_hf_submitted_reply)
                        p_date_hf_submitted_reply.Add(new Chunk(s + "\n", new Font(Font.FontFamily.HELVETICA, 7f)));
                    complaints_table.AddCell(new PdfPCell(p_date_hf_submitted_reply) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

                }
                else
                {
                    complaints_table.AddCell(new PdfPCell(new Paragraph("-", new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                }
                if (c.date_release_to_records != null && c.date_release_to_records.Count() > 0)
                {
                    Paragraph p_date_release_to_records = new Paragraph();
                    foreach (String s in c.date_release_to_records)
                        p_date_release_to_records.Add(new Chunk(s + "\n", new Font(Font.FontFamily.HELVETICA, 7f)));
                    complaints_table.AddCell(new PdfPCell(p_date_release_to_records) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

                }
                else
                {
                    complaints_table.AddCell(new PdfPCell(new Paragraph("-", new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                }
                if (c.date_final_resolution != null && c.date_final_resolution.Count() > 0)
                {
                    Paragraph p_date_final_resolution = new Paragraph();
                    foreach (String s in c.date_final_resolution)
                        p_date_final_resolution.Add(new Chunk(s + "\n", new Font(Font.FontFamily.HELVETICA, 7f)));
                    complaints_table.AddCell(new PdfPCell(p_date_final_resolution) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });

                }
                else
                {
                    complaints_table.AddCell(new PdfPCell(new Paragraph("-", new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                }
                complaints_table.AddCell(new PdfPCell(new Paragraph(c.status == 1 ? "On Going" : "Resolved", new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
                complaints_table.AddCell(new PdfPCell(new Paragraph(c.staff, new Font(Font.FontFamily.HELVETICA, 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, VerticalAlignment = Element.ALIGN_CENTER });
            }

            doc.Add(complaints_table);

            doc.Close();
        }
    }
}