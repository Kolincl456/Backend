using AutoMapper;
using Pos.Dto.Dto;
using Pos.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Mappings
{
    public class mappingProfile : Profile
    {
        public mappingProfile() {
            #region Rol
            //Mapeo de Rol a RolDto
            CreateMap<Rol, RolDto>()
            .ForMember(destino => destino.IdRol,
                opt => opt.MapFrom(origen => origen.IdRol)
            )
            .ForMember(destino => destino.Descripcion,
                opt => opt.MapFrom(origen => origen.Descripcion)
            )
            .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado)
            );

            CreateMap<RolDto, Rol>()
            .ForMember(destino => destino.IdRol,
            opt => opt.MapFrom(origen => origen.IdRol)
            )
            .ForMember(destino => destino.Descripcion,
                opt => opt.MapFrom(origen => origen.Descripcion)
            )
            .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado)
            );
            #endregion

            #region Usuario
            CreateMap<Usuario, UsuarioDto>()
            .ForMember(destino => destino.IdUsuario,
                opt => opt.MapFrom(origen => origen.IdUsuario)
            )
            .ForMember(destino => destino.Nombres,
                opt => opt.MapFrom(origen => origen.Nombres)
            )
            .ForMember(destino => destino.Apellidos,
                opt => opt.MapFrom(origen => origen.Apellidos)
            )
            .ForMember(destino => destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.Rol != null ? origen.Rol.Descripcion : string.Empty)
            )
            .ForMember(destino => destino.Telefono,
                opt => opt.MapFrom(origen => origen.Telefono)
            )
            .ForMember(destino => destino.Email,
                opt => opt.MapFrom(origen => origen.Email)
            )
            .ForMember(destino => destino.Clave,
                /*La contraseña no se mapea*/
                opt => opt.Ignore()
            )
            .ForMember(destino => destino.Estado,
                /*La contraseña no se mapea*/
                opt => opt.MapFrom(origen => origen.Estado)
            );

            CreateMap<UsuarioDto, Usuario>()
            .ForMember(destino => destino.IdUsuario,
                opt => opt.MapFrom(origen => origen.IdUsuario)
            )
            .ForMember(destino => destino.Nombres,
                opt => opt.MapFrom(origen => origen.Nombres)
            )
            .ForMember(destino => destino.Apellidos,
                opt => opt.MapFrom(origen => origen.Apellidos)
            )
            .ForMember(destino => destino.IdRol,
                opt => opt.MapFrom(origen => origen.IdRol)
            )
            .ForMember(destino => destino.Telefono,
                opt => opt.MapFrom(origen => origen.Telefono)
            )
            .ForMember(destino => destino.Email,
                opt => opt.MapFrom(origen => origen.Email)
            )
            .ForMember(destino => destino.Estado,
                /*La contraseña no se mapea*/
                opt => opt.MapFrom(origen => origen.Estado)
            );
            #endregion

            #region

            #endregion
        }
    }
}
