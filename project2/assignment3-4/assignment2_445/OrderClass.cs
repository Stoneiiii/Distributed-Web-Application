using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_445
{
    public class OrderClass
    {
        private string senderId;    //Agent ID for sending orders
        private int cardNo;         // Credit card number must be between 5000 and 7000 to be legal
        private string receiverID;  //cruise ID 
        private int quantity;       //Number of tickets
        private double price;          //Price of the ticket


        public OrderClass(string senderId, int cardNo, string receiverID, int quantity, double price)
        {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.receiverID = receiverID;
            this.quantity = quantity;
            this.price = price;
        }

        public string SenderId  //return or set SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        public int CardNo   //return or set CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        public string ReceiverID    //return or set ReceiverID
        {
            get { return receiverID; }
            set { receiverID = value; }
        }

        public int Quantity //return or set Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double Price //return or set Price
        {
            get { return price; }
            set { price = value; }
        }


    }
}
