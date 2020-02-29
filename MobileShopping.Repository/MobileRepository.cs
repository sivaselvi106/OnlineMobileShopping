using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShopping.Entity;

namespace MobileShopping.Repository
{
    public class MobileRepository
    {
        public static List<Mobile> mobiles = new List<Mobile>();
        static MobileRepository()
        {
            mobiles.Add(new Mobile { BrandName = "Samsung", MobileModel = "A50", Id = 1, Color = "Blue", Price = 15000 });
            mobiles.Add(new Mobile { BrandName = "Redmi", MobileModel = "Note5 Pro", Id = 2, Color = "White", Price = 10000 });
            mobiles.Add(new Mobile { BrandName = "Moto", MobileModel = "G4+", Id = 3, Color = "Blue", Price = 9000 });
        }
        public IEnumerable<Mobile> GetMobileDetails()
        {
            return mobiles;
        }
        public void AddMobile(Mobile mobile)
        {
            mobiles.Add(mobile);
        }
        public Mobile GetMobileId(int mobileId)
        {
            return mobiles.Find(id => id.Id == mobileId);
        }
        public void DeleteMobile(int mobileId)
        {
            Mobile mobile = GetMobileId(mobileId);
            if (mobile != null)
                mobiles.Remove(mobile);
        }
        public void UpdateMobile(Mobile mobile)
        {
            Mobile updateMobile = GetMobileId(mobile.Id);
            updateMobile.BrandName = mobile.BrandName;
            updateMobile.Color = mobile.Color;
            updateMobile.MobileModel = mobile.MobileModel;
            updateMobile.Price = mobile.Price;
        }
    }
}
