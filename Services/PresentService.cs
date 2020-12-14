using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IPresentService
    {
        IEnumerable<Present> GetAllPresents(Guid uId);
        Present GetPresentById(Guid id);        
        void UpdatePresent(Present present);
        Present CreatePresent(Present present);
        void DeletePresent(Guid id);
    }

    public class PresentService : IPresentService
    {
        
        private DataContext _context;
        

        public PresentService(DataContext context)
        {
            _context= context;
        }

        public void DeletePresent(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Present> GetAllPresents(Guid uId)
        {
            return _context.Presents.Where(o=>o.UserId == uId).ToList<Present>();
        }

        public Present GetPresentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePresent(Present present)
        {
            throw new NotImplementedException();
        }

        public Present CreatePresent(Present present){

            if(present==null)
            {
                throw new PresentXException("present is null");
            }
            _context.Presents.Add(present);
            _context.SaveChanges();

            return present;

        }
    }
}
