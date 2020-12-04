using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Services
{
    public interface IPresentService{
        IEnumerable<Present> GetAllPresentItems();
        Present GetPresentItemById(int id);
        void CreatePresentItem(Present present);
        void UpdatePresentItem(Present present);
        void DeletePresentItem(Present present);
    }
    public class PresentService : IPresentService
    {
        public void CreatePresentItem(Present present)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePresentItem(Present present)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Present> GetAllPresentItems()
        {
            throw new System.NotImplementedException();
        }

        public Present GetPresentItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePresentItem(Present present)
        {
            throw new System.NotImplementedException();
        }
    }
}