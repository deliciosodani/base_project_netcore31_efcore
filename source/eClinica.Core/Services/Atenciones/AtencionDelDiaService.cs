using AutoMapper;
using eClinica.Core.Exceptions;
using eClinica.Core.Interfaces;
using eClinica.Infrastructure;
using eClinica.Infrastructure.Data.Entities;
using eClinica.Models.Atenciones.AtencionesDelDia;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eClinica.Core.Services
{
    public class AtencionDelDiaService : IAtencionDelDiaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AtencionDelDiaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<bool> IAtencionDelDiaService.AddAsync(AtencionDelDiaRequestModel entity)
        {
            await _unitOfWork.AtencionDelDia.AddAsync(_mapper.Map<AtencionDelDia>(entity));
            return await _unitOfWork.CommitAsync() == 1 ? true : false;
        }

        async Task IAtencionDelDiaService.DeleteAsync(long id)
        {
            var entityToBeDeleted = await _unitOfWork.AtencionDelDia.GetByIdAsync(id);
            if (entityToBeDeleted == null) throw new BadRequestException("La Atencion que intenta eliminar no existe.");

            _unitOfWork.AtencionDelDia.Remove(entityToBeDeleted);
            await _unitOfWork.CommitAsync();
        }

        async Task<IEnumerable<AtencionDelDiaModel>> IAtencionDelDiaService.GetAllAsync()
        {
            var entities = await _unitOfWork.AtencionDelDia.GetAllAsync();
            //entities.ToList().ForEach(entity =>
            //{
            //    entity.NombreCliente = _unitOfWork.Cliente.Find(x => x.Id == entity.ClienteId).FirstOrDefault();
            //});
            return _mapper.Map<IEnumerable<AtencionDelDiaModel>>(entities);
        }

        IEnumerable<AtencionDelDiaModel> IAtencionDelDiaService.GetAllByUserAsync(long id)
        {
            return _mapper.Map<IEnumerable<AtencionDelDiaModel>>(_unitOfWork.AtencionDelDia.Find(d => d.Id == id));
        }

        async Task<AtencionDelDiaModel> IAtencionDelDiaService.GetByIdAsync(long id)
        {
            var entity = await _unitOfWork.AtencionDelDia.GetByIdAsync(id);
            if (entity == null) throw new BadRequestException("No existe la atencion solicitada.");
            //entity.NombreCliente = _unitOfWork.Cliente.Find(x => x.Id == entity.ClienteId).FirstOrDefault();
            return _mapper.Map<AtencionDelDiaModel>(entity);
        }

        async Task IAtencionDelDiaService.UpdateAsync(AtencionDelDiaRequestModel entity, long Id)
        {
            var entityToBeUpdated = await _unitOfWork.AtencionDelDia.GetByIdAsync(Id);
            if (entityToBeUpdated == null) throw new BadRequestException("La atencion que intenta modificar no existe.");

            entityToBeUpdated.Documento = entity.Documento;
            // etc, campo campo ...

            await _unitOfWork.CommitAsync();
        }
    }
}
