using BoatRentingAppKnorish.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentingAppKnorish.Models
{
    public class BoatRepository : IBoatRepository
    {
        private readonly AppDBContext context;

        public BoatRepository(AppDBContext context)
        {
            this.context = context;
        }
        public string AddBoat(Boat boat)
        {
                    
            string boatNumber;
            try
            {
                boatNumber = Guid.NewGuid().ToString();
                boat.BoatNumber = boatNumber;
                context.Boats.Add(boat);
                context.SaveChanges();


                return boatNumber;
            }
            catch(Exception ex)
            {
                boatNumber = "Error occured while registering boat detail. Error: " + ex.Message;
                return boatNumber;
            }
            
        }

        public List<Boat> GetBoat()
        {
            return context.Boats.ToList();
        }

        public string RentRequest(RentBoatModel rentBoatmodel)
        {
            Boat boatDetail = new Boat();
            string result;
            try
            
            {
                boatDetail = context.Boats.Where(x => x.BoatNumber == rentBoatmodel.BoatNumber).FirstOrDefault();

                if (!string.IsNullOrEmpty(boatDetail.CustomerName))
                {
                    //Can not Rent.
                    result = "Boat is already rented. Can not rent this boat.";
                }
                else
                {
                    // Rent out
                    boatDetail.CustomerName = rentBoatmodel.CustomerName ;
                    context.Boats.Update(boatDetail);
                    context.SaveChanges();
                    result = "Successfully Rented.";
                }
                return result;
            }
            catch (Exception ex)
            {
                result = "Error occured while renting boat. Error: " + ex.Message;
                return result;            
            }
        }
    }
}
