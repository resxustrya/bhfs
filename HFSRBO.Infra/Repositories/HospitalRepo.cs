﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HFSRBO.Core;
namespace HFSRBO.Infra
{
    public class HospitalRepo : IHospitalRepo
    {
        hfsrboContext db = new hfsrboContext();
        public void Add(hospitals _hospital)
        {
            db.hospitals.Add(_hospital);
            db.SaveChanges();
        }
        public void Edit(hospitals _hospital)
        {
            db.Entry(_hospital).State = EntityState.Modified;
        }
        public void Remove(Int32 ID)
        {
            db.hospitals.Remove(db.hospitals.Where(p => p.ID == ID).FirstOrDefault());
            db.SaveChanges();
        }
        public hospitals FindById(Int32 ID)
        {
            var result = db.hospitals.Where(p => p.ID == ID).FirstOrDefault();
            return result;
        }
        public IEnumerable<hospitals> GetHospitals()
        {
            var result = db.hospitals;
            return result;
        }
        public IEnumerable<object> GetHospitalFacilities()
        {
            var result = (from hospital in db.hospitals
                          join facilites in db.facilityType on hospital.facilityID equals facilites.ID
                          select new
                          {
                              hospitalID = hospital.ID,
                              hospitalName = hospital.name,
                              hospitalAddress = hospital.address,
                              facilityType = facilites.Name
                          }).ToList();

            return result;
        }
    }
}
