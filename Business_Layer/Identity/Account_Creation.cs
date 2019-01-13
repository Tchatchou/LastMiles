
using AutoMapper;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.UnitOfWorks;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Identity_Management;
using System.Threading.Tasks;
using System;

namespace Business_Layer.Identity
{
    public class Account_Creation : IAccount_Creation
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork_Identity _unitOfWork_Identity;

        public Account_Creation (IMapper mapper,IUnitOfWork_Identity unitOfWork_Identity)
        {
            _mapper = mapper;
            _unitOfWork_Identity = unitOfWork_Identity;
        }
        public void create_new_company(Company_For_Registration_Dto companyForRegistrationDto)
        {
            var  companyToCreate =  _mapper.Map<Company>(companyForRegistrationDto);
            _unitOfWork_Identity.companies.Add(companyToCreate);
            _unitOfWork_Identity.save();
        }
        public void create_new_Distributor(Distributor_For_Registration_Dto distributor, ClaimsPrincipal user, int entity_id_to_Map_User)
        {
            var  distToCreate =  _mapper.Map<Distributor>(distributor);
            if(user.IsInRole("SuperAdmin") || user.IsInRole("Admin"))
            {
                _unitOfWork_Identity.distributors.Add(distToCreate);
                _unitOfWork_Identity.save();
            }
            if (user.IsInRole("CompanyAdmin")) 
            {               
                _unitOfWork_Identity.distributors.Add(distToCreate);
                _unitOfWork_Identity.save();                
                // get companie for the login in company admin
                // then map distributor create to company                
                _unitOfWork_Identity.companies.add_distributor_to_a_company(entity_id_to_Map_User, distToCreate.distributor_id);
                _unitOfWork_Identity.save();
            }
        }
        public void add_distributor_to_a_company(int company_id, int distributor_id)
        {
               _unitOfWork_Identity.companies.add_distributor_to_a_company(company_id,distributor_id);
               _unitOfWork_Identity.save();
        }
        public void remove_distributor_to_a_company(int company_id, int distributor_id)
        {
            _unitOfWork_Identity.companies.remove_distributor_to_a_company(company_id,distributor_id);
            _unitOfWork_Identity.save();
        }
        public void create_new_Retailer(Retailer_For_Registration_Dto retailer)
        {            

             var  retailerToCreate =  _mapper.Map<Retailer>(retailer);
            _unitOfWork_Identity.retailers.Add(retailerToCreate);            
            _unitOfWork_Identity.save();
         
        }

      
    }
}