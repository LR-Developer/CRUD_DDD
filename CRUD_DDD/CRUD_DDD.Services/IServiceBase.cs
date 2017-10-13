using System.Collections.Generic;

namespace CRUD_DDD.Services
{
    public interface IServiceBase<TFindDto, TListDto, TAddDto, TUpdateDto>
        where TFindDto : class
        where TListDto : class
        where TAddDto : class
        where TUpdateDto : class
    {
        TFindDto Find(object key);
        IEnumerable<TListDto> GetAll();

        void Add(TAddDto dto);
        void Update(object key, TUpdateDto dto);
        void RemoveBy(object key);
    }
}