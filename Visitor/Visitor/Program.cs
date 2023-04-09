using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    interface iVisitor
    {
        void VisitSmallHouse(Small House);
        void VisitMediumHouse(Medium House);
        void VisitBigHouse(Big House);
    }
    class Visitor : iVisitor
    {
        public void VisitSmallHouse(Small House)
        {
            Console.WriteLine($"Price for big house: {House.PriceForSmallHouse()}\n" );
        }
        public void VisitMediumHouse(Medium House)
        {
            Console.WriteLine($"Price for big house: {House.PriceForMediumHouse()}\n");
        }
        public void VisitBigHouse(Big House)
        {
            Console.WriteLine($"Price for big house: {House.PriceForBigHouse()}\n");
        }
    }
    interface iHouse
    {
        void Accept(iVisitor Visitor);
    }
    class Small : iHouse
    {
        public void Accept(iVisitor Visitor)
        {
            Visitor.VisitSmallHouse(this);
        }
        public string PriceForSmallHouse()
        {
            return "1000$";
        }
    }
    class Medium : iHouse
    {
        public void Accept(iVisitor Visitor)
        {
            Visitor.VisitMediumHouse(this);
        }
        public string PriceForMediumHouse()
        {
            return "2500$";
        }
    }
    class Big : iHouse
    {
        public void Accept(iVisitor Visitor)
        {
            Visitor.VisitBigHouse(this);
        }
        public string PriceForBigHouse()
        {
            return "5000$";
        }
    }
    class Owner
    {
        public static void OwnerCode(List<iHouse> Houses, iVisitor Visitor)
        {
            foreach (var House in Houses)
            {
                House.Accept(Visitor);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<iHouse> Houses = new List<iHouse>
            {
                new Small(),new Medium(),new Big()
            };
            var Visitor = new Visitor();
            Owner.OwnerCode(Houses, Visitor);
        }
    }
}
