﻿using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class UnitofWork : IUnitofWork
    {
        private readonly RentaCarContext _context;
        private EfUserDal _efUserDal;
        private EfCarDal _efCarDal;
        private EfCompanyDal _efCompanyDal;
        private EfCustomerDal _efCustomerDal;
        private EfEmployeeDal _efEmployeeDal;
        private EfRentalDal _efRentalDal;
        public UnitofWork()
        {
            _context = new RentaCarContext();
        }

        public IUserDal Users => _efUserDal ?? new EfUserDal();
        public ICarDal Cars => _efCarDal ?? new EfCarDal();

        public ICompanyDal Companies => _efCompanyDal ?? new EfCompanyDal();

        public ICustomerDal Customers => _efCustomerDal ?? new EfCustomerDal();
        public IRentalDal Rentals => _efRentalDal ?? new EfRentalDal();

        public IEmployeeDal Employees => _efEmployeeDal ?? new EfEmployeeDal();

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
