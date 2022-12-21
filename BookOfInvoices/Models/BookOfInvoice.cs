using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfInvoices.Models
{
    public class BookOfInvoice
    {
        private List<Invoice> invoices;

        public BookOfInvoice()
        {
            invoices = new List<Invoice>();
        }

        public void addInvoice(Invoice invoice)
        {
            if (invoices.Exists( x => x.invoiceID == invoice.invoiceID))
            {
                Console.WriteLine($"The invoice with this identifier {invoice.invoiceID} already exists");
            }
            else
            {
                invoices.Add(invoice);
            }
        }

        public Invoice getInvoice(string invoiceID)
        {
            if (invoices.Exists(x => x.invoiceID == invoiceID))
            {
                return invoices.FirstOrDefault(x => x.invoiceID == invoiceID);
            }
            else
            {
                Console.WriteLine($"The invoice with this identifier {invoiceID} dont exists");
                return null;
            }
        }

        public void fillBookOfInvoices(int minNumberOfInvoice, int maxNumberOfInvoice)
        {
            Random random = new Random();
            int number = random.Next(minNumberOfInvoice, maxNumberOfInvoice);
            DateTime lastDateTime = DateTime.MinValue;

            for (int i = 1; i <= number; i++)
            {
                string ID = Helpers.getID(i);
                DateTime dateTime = Helpers.getDatetimeOfCreated(i, lastDateTime);
                lastDateTime = dateTime;
                Invoice invoice = new Invoice(ID, lastDateTime);
                invoice.fillInvoice();
                addInvoice(invoice);
            }
        }

        private IQueryable<Invoice> getQueryInvoicesOver100000()
        {
            List<Invoice> lreturn = new List<Invoice>();

            foreach (var item in invoices)
            {
                if (item.totalPrice > 100000)
                {
                    lreturn.Add(item);
                }
            }

            return lreturn.AsQueryable<Invoice>();
        }

        public void printResult()
        {
            DateTime dateTimeNow = DateTime.Now;
            DateTime dateTime = dateTimeNow.AddDays(-90);

            foreach (var item in getQueryInvoicesOver100000().Where(x => x.dateOfCreation > dateTime && x.dateOfCreation < dateTimeNow).OrderByDescending(x => x.invoiceID))
            {
                Console.WriteLine($"{item.invoiceID}, {item.dateOfCreation.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)}, {item.totalPrice}");
            }
        }
    }
}
