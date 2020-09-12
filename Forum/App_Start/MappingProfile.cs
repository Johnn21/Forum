using AutoMapper;
using Forum.Dtos;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<Post, PostDto>();
            Mapper.CreateMap<PostDto, Post>();
        }

    }
}