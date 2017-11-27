using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using URISOrderMicroService.Models;

namespace URISOrderMicroService.DataAccess
{
    public class OrderDB
    {

        public static Order ReadRow(SqlDataReader reader)
        {
            Order orderToReturn = new Order();


            /*public int Id { get; set; }
              public String Date { get; set; }
              public String DeliveryDate { get; set; }
              public String DeliveryAddress { get; set; }
              public String DeliveryZipCode { get; set; }
              public String DeliveryCity { get; set; }
              public String Note { get; set; }
              public int UserID { get; set; }
              public double Price { get; set; }
              public int Quantity { get; set; }*/

            orderToReturn.Id = (int)reader["Id"];
            orderToReturn.Date = (DateTime)reader["Date"];
            orderToReturn.DeliveryDate = (string)reader["DeliveryDate"];
            orderToReturn.DeliveryAddress = (string)reader["DeliveryAddress"];
            orderToReturn.DeliveryZipCode = (string)reader["DeliveryZipCode"];
            orderToReturn.DeliveryCity = (string)reader["DeliveryCity"];
            orderToReturn.Note = (string)reader["Note"];
            orderToReturn.UserID = (int)reader["UserID"];
            orderToReturn.Price = (double)reader["Price"];
            orderToReturn.Quantity = (int)reader["Quantity"];

            return orderToReturn;

           
        }

        private static int ReadId(SqlDataReader reader)
        {
            return (int)reader["Id"];
        }

        private static string AllColumnSelect
        {
            get
            {
                return @"
                    [Order].[Id],
	                [Order].[Date],
	                [Order].[DeliveryDate],
                    [Order].[DeliveryAddress],
                    [Order].[DeliveryZipCode],
                    [Order].[DeliveryCity],
                    [Order].[Note],
                    [Order].[UserID],
                    [Order].[Price],
	                [Order].[Quantity]
                ";
            }
        }


        private static void FillData(SqlCommand command, Order order)
        {
            command.Parameters.Add("@Id", SqlDbType.Int, order.Id);
            command.Parameters["@Id"].Value = order.Id;

            command.Parameters.Add("@Date", SqlDbType.DateTime);
            command.Parameters["@Date"].Value = order.Date;

            command.Parameters.Add("@DeliveryDate", SqlDbType.NVarChar);
            command.Parameters["@DeliveryDate"].Value = order.DeliveryDate;

            command.Parameters.Add("@DeliveryAddress", SqlDbType.NVarChar);
            command.Parameters["@DeliveryAddress"].Value = order.DeliveryAddress;

            command.Parameters.Add("@DeliveryZipCode", SqlDbType.NVarChar);
            command.Parameters["@DeliveryZipCode"].Value = order.DeliveryZipCode;


           /* command.Parameters.Add("@DeliveryCity", SqlDbType.NVarChar);
            command.Parameters.Add("@Note", SqlDbType.NVarChar, order.Note);
            command.Parameters.Add("@UserID", SqlDbType.NVarChar, order.UserID);
            command.Parameters.Add("@Price", SqlDbType.Int, order.Price);
            command.Parameters.Add("@Quantity", SqlDbType.NVarChar, order.Quantity);
            command.Parameters.Add("@Active", SqlDbType.Bit, order.Active);*/
        }


    }



}