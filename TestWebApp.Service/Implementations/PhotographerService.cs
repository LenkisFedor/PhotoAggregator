using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.DAL.Interfaces;
using TestWebApp.DAL.Repositories;
using TestWebApp.Domain.Entity;
using TestWebApp.Domain.Enum;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.Photographer;
using TestWebApp.Domain.ViewModels.Service;
using TestWebApp.Service.Interfaces;

namespace TestWebApp.Service.Implementations
{
    public class PhotographerService : IPhotographerService
    {
        private readonly IPhotographerRepository _PhotographerRepository;

        public PhotographerService(IPhotographerRepository PhotographerRepository)
        {
            _PhotographerRepository = PhotographerRepository;
        }
        public async Task<IBaseResponse<PhotographerViewModel>> CreatePhotographer(PhotographerViewModel PhotographerViewModel)
        {
            var baseResponse = new BaseResponse<PhotographerViewModel>();
            try
            {
                var Photographer = new Domain.Entity.Photographer()
                {
                    PhotographerId = PhotographerViewModel.PhotographerId,
                    PhotographerName = PhotographerViewModel.PhotographerName,
                    PhotographerEmail = PhotographerViewModel.PhotographerEmail,
                    PhotographerWorkExperience = PhotographerViewModel.PhotographerWorkExperience,
                    Publications = PhotographerViewModel.Publications
                };

                await _PhotographerRepository.Create(Photographer);
            }
            catch (Exception ex)
            {
                return new BaseResponse<PhotographerViewModel>()
                {
                    Description = $"[CreatePhotographer] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeletePhotographer(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };
            try
            {
                var photographer = await _PhotographerRepository.Get(id);
                if (photographer == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _PhotographerRepository.Delete(photographer);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeletePhotographer] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Photographer>> Edit(int id, PhotographerViewModel model)
        {
            var baseResponse = new BaseResponse<Domain.Entity.Photographer>();
            try
            {
                var Photographer = await _PhotographerRepository.Get(id);
                if (Photographer == null)
                {
                    baseResponse.StatusCode = StatusCode.PhotographerNotFound;
                    baseResponse.Description = "Photographer not found";
                    return baseResponse;
                }

                Photographer.PhotographerId = model.PhotographerId;
                Photographer.PhotographerName = model.PhotographerName;
                Photographer.PhotographerEmail = model.PhotographerEmail;
                Photographer.Publications = model.Publications;

                await _PhotographerRepository.Update(Photographer);


                return baseResponse;
                // TypePhotographer

            }
            catch (Exception ex)
            {
                return new BaseResponse<Domain.Entity.Photographer>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<PhotographerViewModel>> GetPhotographer(int id)
        {
            var baseResponse = new BaseResponse<PhotographerViewModel>();
            try
            {
                var Photographer = await _PhotographerRepository.Get(id);
                if (Photographer == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                var data = new PhotographerViewModel()
                {
                    PhotographerId = Photographer.PhotographerId,
                    PhotographerName = Photographer.PhotographerName,
                    PhotographerEmail = Photographer.PhotographerEmail,
                    PhotographerWorkExperience = Photographer.PhotographerWorkExperience,
                    Publications = Photographer.Publications
                };

                baseResponse.StatusCode = StatusCode.Ok;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<PhotographerViewModel>()
                {
                    Description = $"[GetPhotographer] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Photographer>> GetPhotographerByName(string name)
        {
            var baseResponse = new BaseResponse<Domain.Entity.Photographer>();
            try
            {
                var Photographer = await _PhotographerRepository.GetByName(name);
                if (Photographer == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.Data = Photographer;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Domain.Entity.Photographer>()
                {
                    Description = $"[GetPhotographerByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Photographer>>> GetPhotographers()
        {
            var baseResponse = new BaseResponse<IEnumerable<Domain.Entity.Photographer>>();
            try
            {
                var Photographer = await _PhotographerRepository.Select();
                if (Photographer.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.Ok;
                    return baseResponse;
                }

                baseResponse.Data = Photographer;
                baseResponse.StatusCode = StatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Domain.Entity.Photographer>>()
                {
                    Description = $"[GetPhotographers] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
