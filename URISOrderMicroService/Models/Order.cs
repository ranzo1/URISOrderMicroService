using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace URISOrderMicroService.Models
{
    public class Order
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String DeliveryDate { get; set; }
        public String DeliveryAddress { get; set; }
        public String DeliveryZipCode { get; set; }
        public String DeliveryCity { get; set; }
        public String Note { get; set; }
        public int UserID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }


       /* public Order() { }

        public Order(int Id,String Date,String DeliveryDate,String DeliveryAddress,String DeliveryZipCode,String DeliveryCity,String Note,int UserID,double Price,int Quantity)
        {

            this.Id = Id;
            this.Date = Date;
            this.DeliveryDate = DeliveryDate;
            this.DeliveryAddress=DeliveryAddress''

        }*/


    }
}