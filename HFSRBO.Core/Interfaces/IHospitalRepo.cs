using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public interface IHospitalRepo
    {
        void Add(hospitals _hospital);
        void Edit(hospitals _hospital);
        void Remove(Int32 ID);
        hospitals FindById(Int32 ID);
        IEnumerable<hospitals> GetHospitals();
    }
}
