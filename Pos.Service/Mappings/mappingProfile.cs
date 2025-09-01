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
            //Mapeo de Rol a RolDto.
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
            //Mapeo de RolDot a Rol.
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

            #region Negocio
            CreateMap<Negocio, NegocioDto>()
            .ForMember(destino => destino.IdNegocio,
                opt => opt.MapFrom(origen => origen.IdNegocio)
            )
            .ForMember(destino => destino.RUC,
                opt => opt.MapFrom(origen => origen.RUC)
            )
            .ForMember(destino => destino.RazonSocial,
                opt => opt.MapFrom(origen => origen.RazonSocial)
            )
            .ForMember(destino => destino.Email,
                opt => opt.MapFrom(origen => origen.Email)
            )
            .ForMember(destino => destino.Telefono,
                opt => opt.MapFrom(origen => origen.Telefono)
            )
            .ForMember(destino => destino.Direccion,
                opt => opt.MapFrom(origen => origen.Direccion)
            )
            .ForMember(destino => destino.Propietario,
                opt => opt.MapFrom(origen => origen.Propietario)
            )
            .ForMember(destino => destino.Descuento,
                opt => opt.MapFrom(origen => origen.Descuento)
            );

            CreateMap<NegocioDto, Negocio>()
            .ForMember(destino => destino.IdNegocio,
                opt => opt.MapFrom(origen => origen.IdNegocio)
            )
            .ForMember(destino => destino.RUC,
                opt => opt.MapFrom(origen => origen.RUC)
            )
            .ForMember(destino => destino.RazonSocial,
                opt => opt.MapFrom(origen => origen.RazonSocial)
            )
            .ForMember(destino => destino.Email,
                opt => opt.MapFrom(origen => origen.Email)
            )
            .ForMember(destino => destino.Telefono,
                opt => opt.MapFrom(origen => origen.Telefono)
            )
            .ForMember(destino => destino.Direccion,
                opt => opt.MapFrom(origen => origen.Direccion)
            )
            .ForMember(destino => destino.Propietario,
                opt => opt.MapFrom(origen => origen.Propietario)
            )
            .ForMember(destino => destino.Descuento,
                opt => opt.MapFrom(origen => origen.Descuento)
            );
            #endregion

            #region NumeroDocumento
            CreateMap<NumeroDocumento, NumeroDocumentoDto>()
            .ForMember(destino => destino.IdNumeroDocumento,
                opt => opt.MapFrom(origen => origen.IdNumeroDocumento)
            )
            .ForMember(destino => destino.Documento,
                opt => opt.MapFrom(origen => origen.Documento)
            );

            CreateMap<NumeroDocumentoDto, NumeroDocumento>()
            .ForMember(destino => destino.IdNumeroDocumento,
                opt => opt.MapFrom(origen => origen.IdNumeroDocumento)
            )
            .ForMember(destino => destino.Documento,
                opt => opt.MapFrom(origen => origen.Documento)
            );
            #endregion

            #region Categoria
            //Mapeo de Categoria a CategoriaDTO
            CreateMap<Categoria, CategoriaDto>()
            .ForMember(destino => destino.IdCategoria,
                opt => opt.MapFrom(origen => origen.IdCategoria)
            )
            .ForMember(destino => destino.Descripcion,
                opt => opt.MapFrom(origen => origen.Descripcion)
            )
            .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado)
            );
            //CategoriaDTO a Categoria
            CreateMap<CategoriaDto, Categoria>()
            .ForMember(destino => destino.IdCategoria,
                opt => opt.MapFrom(origen => origen.IdCategoria)
            )
            .ForMember(destino => destino.Descripcion,
                opt => opt.MapFrom(origen => origen.Descripcion)
            )
            .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado)
            );
            #endregion

            #region Producto
            //Mapeo de Producto a ProductoDTO
            CreateMap<Producto, ProductoDto>()
            .ForMember(destino => destino.IdProducto,
                opt => opt.MapFrom(origen => origen.IdProducto)
            )
            .ForMember(destino => destino.CodigoBarra,
                opt => opt.MapFrom(origen => origen.CodigoBarra)
            )
            .ForMember(destino => destino.Descripcion,
                opt => opt.MapFrom(origen => origen.Descripcion)
            )
            .ForMember(destino => destino.CategoriaDescripcion,
                opt => opt.MapFrom(origen => origen.Categoria != null ? 
                origen.Categoria.Descripcion : string.Empty)
            )
            .ForMember(destino => destino.PrecioVenta,
                opt => opt.MapFrom(origen => origen.PrecioVenta)
            )
            .ForMember(destino => destino.Stock,
                opt => opt.MapFrom(origen => origen.Stock)
            )
            .ForMember(destino => destino.StockMinimo,
                opt => opt.MapFrom(origen => origen.StockMinimo)
            )
            .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado)
            );
            //ProductoDTO a Producto
            CreateMap<ProductoDto, Producto>()
            .ForMember(destino => destino.IdProducto,
                opt => opt.MapFrom(origen => origen.IdProducto)
            )
            .ForMember(destino => destino.CodigoBarra,
                opt => opt.MapFrom(origen => origen.CodigoBarra)
            )
            .ForMember(destino => destino.Descripcion,
                opt => opt.MapFrom(origen => origen.Descripcion)
            )
            .ForMember(destino => destino.IdCategoria,
                opt => opt.MapFrom(origen => origen.IdCategoria)
            )
            .ForMember(destino => destino.PrecioVenta,
                opt => opt.MapFrom(origen => origen.PrecioVenta)
            )
            .ForMember(destino => destino.Stock,
                opt => opt.MapFrom(origen => origen.Stock)
            )
            .ForMember(destino => destino.StockMinimo,
                opt => opt.MapFrom(origen => origen.StockMinimo)
            )
            .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado)
            );
            #endregion

            #region Venta
            //Mapeo de Venta a VentaDto.
            CreateMap<Venta, VentaDto>()
            .ForMember(destino => destino.Dni,
                opt => opt.MapFrom(origen => origen.Dni)
            )
            .ForMember(destino => destino.Cliente,
                opt => opt.MapFrom(origen => origen.Cliente)
            )
            .ForMember(destino => destino.Descuento,
                opt => opt.MapFrom(origen => origen.Descuento)
            )
            .ForMember(destino => destino.Total,
                opt => opt.MapFrom(origen => origen.Total)
            )
            .ForMember(destino => destino.IdUsuario,
                opt => opt.MapFrom(origen => origen.IdUsuario)
            )
            .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado)
            )
            .ForMember(destino => destino.Motivo,
                opt => opt.MapFrom(origen => origen.Motivo)
            )
            .ForMember(destino => destino.UsuarioAnula,
                opt => opt.MapFrom(origen => origen.UsuarioAnula)
            );
            //Mapeo de VentaDto a Venta.
            CreateMap<VentaDto, Venta>()
            .ForMember(destino => destino.IdVenta,
                opt => opt.Ignore()
            )
            .ForMember(destino => destino.Dni,
                opt => opt.MapFrom(origen => origen.Dni)
            )
            .ForMember(destino => destino.Cliente,
                opt => opt.MapFrom(origen => origen.Cliente)
            )
            .ForMember(destino => destino.Descuento,
                opt => opt.MapFrom(origen => origen.Descuento)
            )
            .ForMember(destino => destino.Total,
                opt => opt.MapFrom(origen => origen.Total)
            )
            .ForMember(destino => destino.IdUsuario,
                opt => opt.MapFrom(origen => origen.IdUsuario)
            )
            .ForMember(destino => destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado)
            )
            .ForMember(destino => destino.Motivo,
                opt => opt.MapFrom(origen => origen.Motivo)
            )
            .ForMember(destino => destino.UsuarioAnula,
                opt => opt.MapFrom(origen => origen.UsuarioAnula)
            );
            #endregion

            #region DetalleVenta
            //Mapeo de Venta a VentaDto.
            CreateMap<DetalleVenta, DetalleVentaDto>()
            .ForMember(destino => destino.IdVenta,
                opt => opt.MapFrom(origen => origen.IdVenta)
            )
            .ForMember(destino => destino.IdProducto,
                opt => opt.MapFrom(origen => origen.IdProducto)
            )
            .ForMember(destino => destino.NombreProducto,
                opt => opt.MapFrom(origen => origen.NombreProducto)
            )
            .ForMember(destino => destino.Precio,
                opt => opt.MapFrom(origen => origen.Precio)
            )
            .ForMember(destino => destino.Cantidad,
                opt => opt.MapFrom(origen => origen.Cantidad)
            )
            .ForMember(destino => destino.Descuento,
                opt => opt.MapFrom(origen => origen.Descuento)
            )
            .ForMember(destino => destino.Total,
                opt => opt.MapFrom(origen => origen.Total)
            );
            //Mapeo de VentaDto a Venta.
            CreateMap<DetalleVentaDto, DetalleVenta>()
            .ForMember(destino => destino.IdDetalleVenta,
                //Para prevenir el duplicado de datos.
                opt => opt.Ignore()
            )
            .ForMember(destino => destino.IdVenta,
                opt => opt.MapFrom(origen => origen.IdVenta)
            )
            .ForMember(destino => destino.IdProducto,
                opt => opt.MapFrom(origen => origen.IdProducto)
            )
            .ForMember(destino => destino.NombreProducto,
                opt => opt.MapFrom(origen => origen.NombreProducto)
            )
            .ForMember(destino => destino.Precio,
                opt => opt.MapFrom(origen => origen.Precio)
            )
            .ForMember(destino => destino.Cantidad,
                opt => opt.MapFrom(origen => origen.Cantidad)
            )
            .ForMember(destino => destino.Descuento,
                opt => opt.MapFrom(origen => origen.Descuento)
            )
            .ForMember(destino => destino.Total,
                opt => opt.MapFrom(origen => origen.Total)
            );
            #endregion
        }
    }
}
