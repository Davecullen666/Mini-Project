using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ead_Mini_project_3.Models;

namespace WebService.API.Controllers
{
    public class BandsController : ApiController
    {
        private MyDBContext db = new MyDBContext();
        [Route("api/Bands")]
        // GET: api/Bands
        public IHttpActionResult GetBands()
        {
            return Ok(db.bands.OrderBy(s=>s.Genres).ToList());
        }

        // GET: api/Bands/name
        //[ResponseType(typeof(Band))]
        //public async Task<IHttpActionResult> GetBand(string name)
        //{
        //    Band band = await db.bands.FindAsync(name);
        //    if (band == null)
        //    {
        //        return Ok(db.bands.OrderBy(s => s.Genres).ToList());
        //    }

        //    return Ok(band);
        //}

        
    }
}