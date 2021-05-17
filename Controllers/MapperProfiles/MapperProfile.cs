using AutoMapper;
using citasmedicas.DTO;
using citasmedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.Controllers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();

            CreateMap<Paciente, PacienteDTO>()
                .ForMember(dto => dto.Medicos, o => o.MapFrom(pac => pac.Medicos.Select(m => m.Id).ToList()))
                .ForMember(dto => dto.Usuario, o => o.MapFrom(pac => pac.User));

            CreateMap<Medico, MedicoDTO>()
                .ForMember(dto => dto.Pacientes, o => o.MapFrom(med => med.Pacientes.Select(p => p.Id).ToList()))
                .ForMember(dto => dto.Usuario, o => o.MapFrom(med => med.User));
             
            CreateMap<Cita, CitaDTO>()
                .ForMember(dto => dto.Medico, o => o.MapFrom(med => med.Id))
                .ForMember(dto => dto.Paciente, o => o.MapFrom(pac => pac.Id))
                .ForMember(dto => dto.Diagnostico, o => o.MapFrom(diag => diag.Id)); ; 

            CreateMap<Diagnostico, DiagnosticoDTO>();

            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<PacienteDTO, Paciente>()
                .ForMember(pac => pac.Medicos, o => o.MapFrom(dto => new List<Medico>()))
                .ForMember(pac => pac.User, o => o.MapFrom(dto => dto.Usuario));

            CreateMap<MedicoDTO, Medico>()
                .ForMember(med => med.Pacientes, o => o.MapFrom(dto => new List<Paciente>()))
                .ForMember(med => med.User, o => o.MapFrom(dto => dto.Usuario));

            CreateMap<CitaDTO, Cita>()
                .ForMember(cita => cita.Medico, o => o.Ignore())
                .ForMember(cita => cita.Paciente, o => o.Ignore())
                .ForMember(cita => cita.Diagnostico, o => o.Ignore());


            CreateMap<DiagnosticoDTO, Diagnostico>();
        }
    }
}
