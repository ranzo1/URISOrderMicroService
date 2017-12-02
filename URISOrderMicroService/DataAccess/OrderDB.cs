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

        private static object CreateLikeQueryString(string str)
        {
            return str == null ? (object)DBNull.Value : "%" + str + "%";
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

            command.Parameters.Add("@DeliveryCity", SqlDbType.NVarChar);
            command.Parameters["@DeliveryCity"].Value = order.DeliveryCity;

            command.Parameters.Add("@Note", SqlDbType.NVarChar, order.Note);
            command.Parameters["@Note"].Value = order.Note;

            command.Parameters.Add("@UserID", SqlDbType.Int, order.UserID);
            command.Parameters["@UserID"].Value = order.UserID;

            command.Parameters.Add("@Price", SqlDbType.Float, order.Price);
            command.Parameters["@Price"].Value = order.Price;

            command.Parameters.Add("@Quantity", SqlDbType.Int, order.Quantity);
            command.Parameters["@Quantity"].Value = order.Quantity;

            command.Parameters.Add("@Active", SqlDbType.Bit, order.Active);
            command.Parameters["@Active"].Value = order.Active;
        }

       /* public static List<Order> GetUsers(string userType, string userName, ActiveStatusEnum active, UserOrderEnum order, OrderEnum orderDirection)
        {
            try
            {
                List<Order> retVal = new List<Order>();

                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"
                        SELECT
                            {0}
                        FROM
                            [user].[User]
                            JOIN [user].[UserType] ON [User].[UserTypeId] = [UserType].[Id]
                        WHERE
                            (@UserType IS NULL OR [user].[UserType].Name LIKE @UserType) AND
                            (@UserName IS NULL OR [user].[User].Name LIKE @UserName) AND
                            (@Active IS NULL OR [user].[User].Active = @Active)
                    ", AllColumnSelect);
                    command.Parameters.Add("@UserType", SqlDbType.NVarChar);
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                    command.Parameters.Add("@Active", SqlDbType.Bit);

                    command.Parameters["@UserType"].Value = CreateLikeQueryString(userType);
                    command.Parameters["@UserName"].Value = CreateLikeQueryString(userName);
                    switch (active)
                    {
                        case ActiveStatusEnum.Active:
                            command.Parameters["@Active"].Value = true;
                            break;
                        case ActiveStatusEnum.Inactive:
                            command.Parameters["@Active"].Value = false;
                            break;
                        case ActiveStatusEnum.All:
                            command.Parameters["@Active"].Value = DBNull.Value;
                            break;
                    }

                    System.Diagnostics.Debug.WriteLine(command.CommandText);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(ReadRow(reader));
                        }
                    }
                }
                return retVal;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                throw ErrorResponse.ErrorMessage(HttpStatusCode.BadRequest, ex);
            }
        }*/


    }



}