using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckDemo_v1.Application.Data;
using TruckDemo_v1.Application.DTO.Result;

namespace TruckDemo_v1.Application.UseCases.Courses.GetCourseById
{
    public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdRequest, Result<GetCourseByIdResponse>>
    {
        private readonly ITruckDemoContext _context;
        public async Task<Result<GetCourseByIdResponse>> Handle(GetCourseByIdRequest request, CancellationToken cancellationToken)
        {
            var Course = await _context.Courses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.CourseId);
            

            if (Course == null)
            {
                return "El curso con el id otorgado no existe";
            }

            return new GetCourseByIdResponse(Course.Id,
                Course.Title,
                Course.Content,
                Course.CreatedAt,
                Course.Subtitle,
                Course.LastUpdatedAt,
                Course.PublishedAt);
        }
    }
}
