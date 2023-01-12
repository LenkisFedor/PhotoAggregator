using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Service.Interfaces;
using TestWebApp.Domain.Entity;
using TestWebApp.DAL.Interfaces;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.Enum;
using System.Runtime.ConstrainedExecution;
using TestWebApp.Domain.ViewModels.Service;
using Microsoft.EntityFrameworkCore;
using static TestWebApp.Service.Implementations.ServiceService;

namespace TestWebApp.Service.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _ServiceRepository;

        public ServiceService(IServiceRepository ServiceRepository)
        {
            _ServiceRepository = ServiceRepository;
        }

        public async Task<IBaseResponse<ServiceViewModel>> GetService(int id)
        {
            var baseResponse = new BaseResponse<ServiceViewModel>();
            try
            {
                var Service = await _ServiceRepository.Get(id);
                if (Service == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                var data = new ServiceViewModel()
                {
                    ServiceId = Service.ServiceId,
                    ServiceDescription = Service.ServiceDescription,
                    ServiceName = Service.ServiceName
                };

                baseResponse.StatusCode = StatusCode.Ok;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ServiceViewModel>()
                {
                    Description = $"[GetService] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ServiceViewModel>> CreateService(ServiceViewModel ServiceViewModel)
        {
            var baseResponse = new BaseResponse<ServiceViewModel>();
            try
            {
                var Service = new Domain.Entity.Service()
                {
                    ServiceId = ServiceViewModel.ServiceId,
                    ServiceDescription = ServiceViewModel.ServiceDescription,
                    ServiceName = ServiceViewModel.ServiceName
                };

                await _ServiceRepository.Create(Service);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ServiceViewModel>()
                {
                    Description = $"[CreateService] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeleteService(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };
            try
            {
                var Service = await _ServiceRepository.Get(id);
                if (Service == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _ServiceRepository.Delete(Service);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteService] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Domain.Entity.Service>> GetServiceByName(string name)
        {
            var baseResponse = new BaseResponse<Domain.Entity.Service>();
            try
            {
                var Service = await _ServiceRepository.GetByName(name);
                if (Service == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.Data = Service;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Domain.Entity.Service>()
                {
                    Description = $"[GetServiceByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Domain.Entity.Service>> Edit(int id, ServiceViewModel model)
        {
            var baseResponse = new BaseResponse<Domain.Entity.Service>();
            try
            {
                var Service = await _ServiceRepository.Get(id);
                if (Service == null)
                {
                    baseResponse.StatusCode = StatusCode.ServiceNotFound;
                    baseResponse.Description = "Service not found";
                    return baseResponse;
                }

                Service.ServiceId = model.ServiceId;
                Service.ServiceDescription = model.ServiceDescription;
                Service.ServiceName = model.ServiceName;

                await _ServiceRepository.Update(Service);


                return baseResponse;
                // TypeService

            }
            catch (Exception ex)
            {
                return new BaseResponse<Domain.Entity.Service>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Domain.Entity.Service>>> GetServices()
        {
            var baseResponse = new BaseResponse<IEnumerable<Domain.Entity.Service>>();
            try
            {
                var Services = await _ServiceRepository.Select();
                if (Services.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.Ok;
                    return baseResponse;
                }

                baseResponse.Data = Services;
                baseResponse.StatusCode = StatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Domain.Entity.Service>>()
                {
                    Description = $"[GetServices] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }

}
