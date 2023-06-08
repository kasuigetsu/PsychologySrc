using Microsoft.EntityFrameworkCore;
using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Helpers;
using PsychologyApp.WebApi.Models;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class TherapyService : ITherapyService
    {
        private PsychologyContext _ctx;
        private Helper _helper;

        public TherapyService()
        {
            _ctx = new PsychologyContext();
            _helper = new Helper();
        }
                
        public async Task<bool> CreateTherapyAsync(TherapyModel therapy, int psychoId)
        {
            if (therapy.Title == null || therapy.Description == null)
                throw new Exception("Пожалуйста, заполните все поля");

            var newTherapy = new Therapy
            {
                Title = therapy.Title,
                Description = therapy.Description,
                psychoId = therapy.psychoId,
                NeedShow = true,
                Cost = therapy.Cost,
                IsDeleted = false
            };
                       
            _ctx.Therapies.Add(newTherapy);
            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditTherapyAsync(TherapyModel therapy, int psychoId)
        {
            if (therapy.Title == null || therapy.Description == null)
                throw new Exception("Пожалуйста, заполните все поля");

            var oldTherapy = await _ctx.Therapies
                .Where(x => x.Id == therapy.Id)
                .Where(x => x.psychoId == psychoId)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (oldTherapy == null)
                throw new Exception($"Терапия не найдена, id: {therapy.Id}");

            oldTherapy.Title = therapy.Title;
            oldTherapy.Description = therapy.Description;
            oldTherapy.Cost = therapy.Cost;
            oldTherapy.NeedShow = therapy.NeedShow;

            await _ctx.SaveChangesAsync();              
            return true;
        }

        public async Task<bool> DeleteTherapyAsync(int therapyId, int psychoId)
        {
            var therapy = await _ctx.Therapies
               .Where(x => x.Id == therapyId)
               .Where(x => x.psychoId == psychoId)
               .Where(x => !x.IsDeleted)
               .FirstOrDefaultAsync();

            if (therapy == null)
                throw new Exception($"Терапия не найдена, id: {therapyId}");

            therapy.IsDeleted = true;

            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<Therapy> GetTherapyAsync(int therapyId, int psychoId)
        {
            var therapy = await _ctx.Therapies
             .Where(x => x.Id == therapyId)
             .Where(x => x.psychoId == psychoId)
             .Where(x => !x.IsDeleted)
             .FirstOrDefaultAsync();

            if (therapy == null)
                throw new Exception($"Терапия не найдена, id: {therapyId}");

            return therapy;
        }

        public async Task<List<Therapy>> GetTherapyListAsync(int psychoId, bool IsPatient = false)
        {
            var therapies = await _ctx.Therapies
                .Where(x => x.psychoId == psychoId || x.psychoId == 0)                
                .Where(x => !x.IsDeleted)
                .ToListAsync();           

            if (!therapies.Any())
                throw new Exception("Список терапий пуст");

            if(IsPatient)
                therapies = therapies.Where(x => x.NeedShow).ToList();

            return therapies;
        }
    }
}
