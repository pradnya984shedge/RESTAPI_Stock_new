using Stock_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock_API.Services
{
    public interface IProfitCenterservice
    {
        IEnumerable<ProftCenter> GetAll() ;
    }
    public class ProfitCenterservice: IProfitCenterservice
    {
        public static ProftCenter center = new ProftCenter
        {
            Id = 1,
            ProftCenterName = "PC1",
            Address = "Leeds",
            TelephoneNumber = "09878675645",
            
        };

        public static ProftCenter center1 = new ProftCenter
        {
            Id = 2,
            ProftCenterName = "PC2",
            Address = "Leeds",
            TelephoneNumber = "09878675645"
        };
        public static List<ProftCenter> proftCenters = new List<ProftCenter>
        {

            center ,
            center1
        };


        public List<Stock> _stocks = new List<Stock>
            {
                new Stock { StockId = 1, StockName = "SN1",Quantity=100,Branch="Leeds",Id=1} ,
                new Stock { StockId = 2, StockName = "SN2",Quantity=80,Branch="Leeds",Id=1 }
            };

        public List<Stock> _stocks1 = new List<Stock>
            {
                new Stock { StockId = 3, StockName = "SN3",Quantity=100,Branch="Leeds",Id=2} ,
                new Stock { StockId = 4, StockName = "SN4",Quantity=80,Branch="Leeds",Id=2 }
            };

        public IEnumerable<ProftCenter> GetAll()
        {
            center.stocks.Add(new Stock { StockId = 1, StockName = "SN1", Quantity = 100, Branch = "Leeds", Id = 1 });
            center.stocks.Add(new Stock { StockId = 2, StockName = "SN2", Quantity = 80, Branch = "Leeds", Id = 1 });

            center1.stocks.Add(new Stock { StockId = 3, StockName = "SN3", Quantity = 100, Branch = "Leeds", Id = 1 });
            center1.stocks.Add(new Stock { StockId = 4, StockName = "SN4", Quantity = 80, Branch = "Leeds", Id = 1 });


            // return users without passwords
            return proftCenters;
        }
    }
}
