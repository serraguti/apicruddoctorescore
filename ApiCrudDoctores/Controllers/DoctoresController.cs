using ApiCrudDoctores.Models;
using ApiCrudDoctores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return this.repo.FindDoctor(id);
        }

        [HttpPost]
        public void InsertarDoctor(Doctor doctor)
        {
            this.repo.InsertDoctor(doctor.Apellido
                , doctor.Especialidad, doctor.IdHospital, doctor.Salario);
        }

        [HttpPut]
        public void UpdateDoctor(Doctor doctor)
        {
            this.repo.UpdateDoctor(doctor.IdDoctor, doctor.Apellido
                , doctor.Especialidad, doctor.IdHospital, doctor.Salario);
        }

        [HttpDelete("{id}")]
        public void DeleteDoctor(int id)
        {
            this.repo.DeleteDoctor(id);
        }

        //MODIFICAR EL SALARIO DE LOS DOCTORES
        [HttpPut]
        [Route("[action]/{especialidad}/{incremento}")]
        public void UpdateSalarioDoctores
            (string especialidad, int incremento)
        {
            this.repo.UpdateSalarioDoctores(especialidad, incremento);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<string>> Especialidades()
        {
            return this.repo.GetEspecialidades();
        }

        [HttpGet]
        [Route("[action]/{especialidad}")]
        public ActionResult<List<Doctor>> DoctoresEspecialidad(string especialidad)
        {
            return this.repo.GetDoctoresEspecialidad(especialidad);
        }

        //doctoresespecialidades?especialidad=pediatria&especialidad=cardiologia
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Doctor>> DoctoresEspecialidades
            ([FromQuery] List<string> especialidad)
        {
            return this.repo.GetDoctoresEspecialidades(especialidad);
        }
    }
}
