using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Policy_Management_System_API.Utilityfunctions
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles(){
            
            
            // var configuration= new MapperConfiguration(cfg => {
                 CreateMap<PolicyDto,Policy>()
                .AfterMap((policyDto,policy) => {
                    policy.Duration=(Convert.ToDateTime(policyDto.EndDate) - Convert.ToDateTime(policyDto.StartDate)).Days / 365;
                    policy.Premium=policyDto.InsuredAmount / policy.Duration;
                    switch(policyDto.PolicyTypeId){
                        case (int)PolicyType.PolicyTypes.Personal:
                            policy.VehicleDetailId = null;
                            policy.HouseDetailId = null;
                            break;
                        case (int)PolicyType.PolicyTypes.Vehicle:
                            policy.HouseDetailId=null;
                            break;
                        case (int)PolicyType.PolicyTypes.Asset:
                            policy.VehicleDetailId=null;
                            break;
                    }
                });
                // CreateMap<Policy,GetPolicyDto>();
                // .AfterMap((policyDto,policy) => policyDto.PolicyTypeId==2 ? policy.HouseDetailId==null : policy.VehicleDetailId==null);
            // });
                
                
           
            // CreateMap<Policy,PolicyDto>().ReverseMap();
            // .ForMember(
            //     dest=>dest.VehicleModel,
            //     opt=>opt.MapFrom(src => new VehicleDetail {VehicleNumber: src.vehicleDetail})
            // )

            

            CreateMap<VehicleDetail,PolicyDto>().ReverseMap();
            CreateMap<HouseDetail,PolicyDto>().ReverseMap();
        }

    }
}