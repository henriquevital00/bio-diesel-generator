using BioDieselProject.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Services
{
    public class BioDieselService
    {
        public double GetCapacity(BioDiesel bio)
        {
            return bio.Capacity;
        }
    }
}
