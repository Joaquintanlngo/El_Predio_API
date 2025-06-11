using Application.Models.Request;
using Application.Models.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICourtService
    {
        Task<List<CourtFrontDto>> GetAll();
        Task<Court> GetById(int id);
        Task<Court> Create(CourtRequest request);
        Task<Court> Update(CourtUpdateRequest request);
        Task<Court> Delete(int id);
    }
}
