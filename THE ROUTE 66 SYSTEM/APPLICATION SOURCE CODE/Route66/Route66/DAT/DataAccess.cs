using Route66;
//using PortalTester.Classes;
using Route66.LTS;
using System;
using System.Collections.Generic;
using System.Linq;
using Route66.DAT;
using Route66.Properties;






namespace Route66.DAT
{
    public static class DataAccess
    {
        #region Customer
        public static LTS.Customer GetCustomerItemByID(int? CustomerID)
        {
            LTS.Customer customer = new LTS.Customer();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    customer = access.Customer.Where(o => o.CustID == CustomerID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return customer;
        }
        public static List<LTS.Customer> GetCustomer()
        {
            List<LTS.Customer> customer = new List<LTS.Customer>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    customer = access.Customer.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return customer;
        }
        public static int AddCustomer(LTS.Customer customer)
        {
            int? CustomerID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertCustomer(customer.CellNo, customer.CustAddress, customer.Email, customer.IDno, customer.Name, customer.Surname, ref CustomerID);
                }
            }
            catch (Exception ex)
            {
            }
            return CustomerID.Value;
        }
        public static bool RemoveCustomer(int CustomerID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteCustomer(CustomerID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateCustomer(LTS.Customer customer)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateCustomer(customer.CellNo, customer.CustAddress, customer.Email, customer.IDno, customer.Name, customer.Surname, customer.CustID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Employee
        public static LTS.Employee GetEmployeeItemByID(int? EmployeeID)
        {
            LTS.Employee employee = new LTS.Employee();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    employee = access.Employee.Where(o => o.EmpID == EmployeeID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return employee;
        }
        public static List<LTS.Employee> GetEmployee()
        {
            List<LTS.Employee> employee = new List<LTS.Employee>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    employee = access.Employee.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return employee;
        }
        public static int AddEmployee(LTS.Employee employee)
        {
            int? EmployeeID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertEmployee(employee.Activated, employee.CellNo, employee.Email, employee.EmpAddress, employee.IDno, employee.IsAdmin, employee.Name, employee.Pass, employee.Salary, employee.Surname, employee.Username, ref EmployeeID);
                }
            }
            catch (Exception ex)
            {
            }
            return EmployeeID.Value;
        }
        public static bool RemoveEmployee(int EmployeeID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteEmployee(EmployeeID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateEmployee(LTS.Employee employee)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateEmployee(employee.Activated, employee.CellNo, employee.Email, employee.EmpAddress, employee.IDno, employee.IsAdmin, employee.Name, employee.Pass, employee.Salary, employee.Surname, employee.Username, employee.EmpID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Reserve
        public static LTS.Reserve GetReserveItemByID(int? ReserveID)
        {
            LTS.Reserve reserve = new LTS.Reserve();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    reserve = access.Reserve.Where(o => o.ResID == ReserveID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return reserve;
        }
        public static List<LTS.Reserve> GetReserve()
        {
            List<LTS.Reserve> reserve = new List<LTS.Reserve>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    reserve = access.Reserve.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return reserve;
        }
        public static int AddReserve(LTS.Reserve reserve)
        {
            int? ReserveID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertReserve(reserve.CellNo, reserve.Email, reserve.IDno, reserve.Name, reserve.ResDate, reserve.StockID, reserve.Surname, ref ReserveID);
                }
            }
            catch (Exception ex)
            {
            }
            return ReserveID.Value;
        }
        public static bool RemoveReserve(int ReserveID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteReserve(ReserveID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateReserve(LTS.Reserve reserve)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateReserve(reserve.CellNo, reserve.Email, reserve.IDno, reserve.Name, reserve.ResDate, reserve.StockID, reserve.Surname, reserve.ResID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Sale
        public static LTS.Sale GetSaleItemByID(int? SaleID)
        {
            LTS.Sale sale = new LTS.Sale();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    sale = access.Sale.Where(o => o.SaleID == SaleID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return sale;
        }
        public static List<LTS.Sale> GetSale()
        {
            List<LTS.Sale> sale = new List<LTS.Sale>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    sale = access.Sale.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return sale;
        }
        public static int AddSale(LTS.Sale sale)
        {
            int? SaleID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertSale(sale.CustID, sale.EmpID, sale.Paid, sale.SaleDate, sale.StockID, ref SaleID);
                }
            }
            catch (Exception ex)
            {
            }
            return SaleID.Value;
        }
        public static bool RemoveSale(int SaleID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteSale(SaleID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateSale(LTS.Sale sale)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateSale(sale.CustID, sale.EmpID, sale.Paid, sale.SaleDate, sale.StockID, sale.SaleID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Stock
        public static LTS.Stock GetStockItemByID(int? StockID)
        {
            LTS.Stock stock = new LTS.Stock();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    stock = access.Stock.Where(o => o.StockID == StockID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return stock;
        }
        public static List<LTS.Stock> GetStock()
        {
            List<LTS.Stock> stock = new List<LTS.Stock>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    stock = access.Stock.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return stock;
        }
        public static int AddStock(LTS.Stock stock)
        {
            int? StockID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertStock(stock.Make, stock.Model, stock.Price, stock.VehicleStatus, stock.VehicleYear, stock.VIN, ref StockID);
                }
            }
            catch (Exception ex)
            {
            }
            return StockID.Value;
        }
        public static bool RemoveStock(int StockID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteStock(StockID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateStock(LTS.Stock stock)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateStock(stock.Make, stock.Model, stock.Price, stock.VehicleStatus, stock.VehicleYear, stock.VIN, stock.StockID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region StockRemoved
        public static LTS.StockRemoved GetStockRemovedItemByID(int? StockRemovedID)
        {
            LTS.StockRemoved stockRemoved = new LTS.StockRemoved();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    stockRemoved = access.StockRemoved.Where(o => o.StockRemovedID == StockRemovedID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return stockRemoved;
        }
        public static List<LTS.StockRemoved> GetStockRemoved()
        {
            List<LTS.StockRemoved> stockRemoved = new List<LTS.StockRemoved>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    stockRemoved = access.StockRemoved.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return stockRemoved;
        }
        public static int AddStockRemoved(LTS.StockRemoved stockRemoved)
        {
            int? StockRemovedID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertStockRemoved(stockRemoved.DateRemoved, stockRemoved.EmpId, stockRemoved.VIN, ref StockRemovedID);
                }
            }
            catch (Exception ex)
            {
            }
            return StockRemovedID.Value;
        }
        public static bool RemoveStockRemoved(int StockRemovedID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteStockRemoved(StockRemovedID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateStockRemoved(LTS.StockRemoved stockRemoved)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateStockRemoved(stockRemoved.DateRemoved, stockRemoved.EmpId, stockRemoved.VIN, stockRemoved.StockRemovedID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
       























    }
}
