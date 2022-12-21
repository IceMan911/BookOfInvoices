using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfInvoices.Models
{
    public class InvoiceItem
    {
        private uint itemID;
        private int unitPrice;
        private int quantity;
        private int totalPrice;

        public InvoiceItem(uint pItemId, int pUnitPrice, int pQuantity)
        {
            itemID = pItemId;
            unitPrice = pUnitPrice;
            quantity = pQuantity;
            totalPrice = unitPrice * quantity;
        }

        public int getTotalPrice()
        {
            return totalPrice;
        }
    }
}
