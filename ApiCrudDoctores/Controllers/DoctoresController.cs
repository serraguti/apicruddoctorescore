using ApiCrudDoctores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGetDoctoresModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudDoctores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Doctor>> GetDoctores()
        {
            return this.repo.GetDoctores();
        }

        [HttpGet("{id}")]
        public ActionResult<Doctor> BuscarDoctor(int id)
        {
            return this.repo.BuscarDoctor(id);
        }

        [HttpPost]
        public void InsertarDoctor(Doctor doctor)
        {
            this.repo.InsertDoctor(doctor.IdDoctor, doctor.Apellido
                , doctor.Especialidad, doctor.Hospital, doctor.Salario);
        }

        [HttpPut]
        public void UpdateDoctor(Doctor doctor)
        {
            this.repo.UpdateDoctor(doctor.IdDoctor, doctor.Apellido
                , doctor.Especialidad, doctor.Hospital, doctor.Salario);
        }

        [HttpDelete("{id}")]
        public void DeleteDoctor(int id)
        {
            this.repo.DeleteDoctor(id);
        }

        [HttpPut]
        [Route("[action]/{incremento}/{hospital}")]
        public void IncrementarSalarios(int incremento, int hospital)
        {
            this.repo.IncrementarSalario(incremento, hospital);
        }
    }
}
