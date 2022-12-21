using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfInvoices.Models
{
    public class Invoice
    {
        public string invoiceID { get; set; }
        public DateTime dateOfCreation { get; set; }
        public int totalPrice { get; set; }

        private List<InvoiceItem> items;

        public Invoice(string ID, DateTime dateTime)
        {
            invoiceID = ID;
            dateOfCreation = dateTime;
            items = new List<InvoiceItem>();
            totalPrice = 0;
        }

        public void fillInvoice()
        {
            Random random = new Random();
            int numberOfItems = random.Next(1, 20);
            int unitPrice;
            int quantity;

            for (uint i = 1; i <= numberOfItems; i++)
            {
                unitPrice = random.Next(1, 2500);
                quantity = random.Next(1, 20);

                InvoiceItem item = new InvoiceItem(i, unitPrice, quantity);
                totalPrice += item.getTotalPrice();

                items.Add(item);
            }
        }
    }
}
