using ApiFilme.Data.DTOs;
using ApiFilme.Models;
using AutoMapper;

namespace ApiFilme.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<ReadFilmeDTO, Filme>();
            CreateMap<UpdateFilmeDTO, Filme>();
        }
    }
}