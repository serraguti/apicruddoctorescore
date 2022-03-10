using ApiCrudDoctores.Data;
using ApiCrudDoctores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudDoctores.Repositories
{
    public class RepositoryDoctores
    {
        DoctoresContext context;

        public RepositoryDoctores(DoctoresContext context)
        {
            this.context = context;
        }

        public List<Doctor> GetDoctores()
        {
            return this.context.Doctores.ToList();
        }

        public Doctor FindDoctor(int id)
        {
            return this.context.Doctores
                .SingleOrDefault(x => x.IdDoctor == id);
        }

        public void DeleteDoctor(int id)
        {
            Doctor doctor = this.FindDoctor(id);
            this.context.Doctores.Remove(doctor);
            this.context.SaveChanges();
        }

        private int GetMaxIdDoctor()
        {
            if (this.context.Doctores.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Doctores.Max(z => z.IdDoctor) + 1;
            }
        }

        public void InsertDoctor(String apellido, String especialidad
            , int hospital, int salario)
        {
            Doctor doctor = new Doctor();
            doctor.IdDoctor = this.GetMaxIdDoctor();
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.IdHospital = hospital;
            doctor.Salario = salario;
            this.context.Doctores.Add(doctor);
            this.context.SaveChanges();
        }

        public void UpdateDoctor(int id, String apellido, String especialidad
            , int hospital, int salario)
        {
            Doctor doctor = this.FindDoctor(id);
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.IdHospital = hospital;
            doctor.Salario = salario;
            this.context.SaveChanges();
        }

        public List<String> GetEspecialidades()
        {
            var consulta = (from datos in this.context.Doctores
                            select datos.Especialidad).Distinct();
            return consulta.ToList();
        }

        public List<Doctor> GetDoctoresEspecialidad(string especialidad)
        {
            var consulta = from datos in this.context.Doctores
                           where datos.Especialidad == especialidad
                           select datos;
            return consulta.ToList();
        }

        public List<Doctor> GetDoctoresEspecialidades(List<string> especialidades)
        {
            var consulta = from datos in this.context.Doctores
                           where especialidades.Contains(datos.Especialidad)
                           select datos;
            return consulta.ToList();
        }

        public void UpdateSalarioDoctores(string especialidad, int incremento)
        {
            List<Doctor> doctores =
                this.GetDoctoresEspecialidad(especialidad);
            foreach (Doctor doc in doctores)
            {
                doc.Salario += incremento;
            }
            this.context.SaveChanges();
        }
    }
}
