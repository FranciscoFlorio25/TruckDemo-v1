using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckDemo_v1.Application.Data;
using TruckDemo_v1.Application.DTO.Lesson;
using TruckDemo_v1.Application.DTO.Result;

namespace TruckDemo_v1.Application.UseCases.Lessons.GetBySeccion
{
    public class GetBySeccionHandler : IRequestHandler<GetBySeccionRequest, Result<GetBySeccionResponse>>
    {
        private readonly ITruckDemoContext _context;

        public GetBySeccionHandler(ITruckDemoContext context)
        {
            _context = context;
        }

        public async Task<Result<GetBySeccionResponse>> Handle(GetBySeccionRequest request, CancellationToken cancellationToken)
        {
            var seccion = await _context.Sections.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.SeccionId);

            if(seccion == null) {

                return "La seccion con el id otorgado no existe";

            }
            var seccionList = seccion.Lessons.Select(x =>
                 new LessonDTO( x.Id,x.Title,x.Content,x.SectionId,x.Order))
                .Where(x => x.SectionId == request.SeccionId);

            if(!seccionList.Any() || seccionList== null) {

                return "No existen lecciones vinculadas a la seccion requerida";
            
            }
            return new GetBySeccionResponse(seccionList);
        }
    }
}
