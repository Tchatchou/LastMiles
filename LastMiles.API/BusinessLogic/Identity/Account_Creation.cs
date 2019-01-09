using LastMiles.API.DataBase;
using LastMiles.API.DataTransferObject;
using LastMiles.API.Repositories_UnitOfWork.UnitOfWorks;
using AutoMapper;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LastMiles.API.BusinessLogic.Identity
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
                
                _unitOfWork_Identity.companies.Add_Distributor(entity_id_to_Map_User, distToCreate.distributor_id);
                _unitOfWork_Identity.save();
            }
        }

        public void create_new_Retailer(Retailer_For_Registration_Dto retailer)
        {
             var  retailerToCreate =  _mapper.Map<Retailer>(retailer);

            _unitOfWork_Identity.retailers.Add(retailerToCreate);
            _unitOfWork_Identity.save();
        }

        public Distributor_For_Registration_Dto Distributor_Details(int distributor_id)
        {
              var result = new Distributor();
        
                result= _unitOfWork_Identity.distributors.Distributor_Details(distributor_id);           

             return  _mapper.Map<Distributor_For_Registration_Dto>(result);
        }

        public List<Retailer_For_Registration_Dto> Get_Retailers(string retailer)
        {
             var result = new List<Retailer>();
        
                result= _unitOfWork_Identity.retailers.Get_Retailers(retailer);           

         return  _mapper.Map<List<Retailer_For_Registration_Dto>>(result);
        }

        public Retailer_For_Registration_Dto Get_Retailers_WithDetails(int retailer)
        {
            var result = new Retailer();
        
                result= _unitOfWork_Identity.retailers.Get_Retailers_WithDetails(retailer);           

         return  _mapper.Map<Retailer_For_Registration_Dto>(result);
        }

        public List<Company_For_Registration_Dto> search_company_withDetails(string company)
        {
             var result = new List<Company>();
        
                result= _unitOfWork_Identity.companies.Search_Company_WithDetails(company);           

         return  _mapper.Map<List<Company_For_Registration_Dto>>(result);
        }

        public List<Distributor_For_Registration_Dto> Search_Distributors(int? company_id, string distributorName)
        {
              var result = new List<Distributor>();
        
                result= _unitOfWork_Identity.distributors.Search_Distributors(company_id,distributorName);           

         return  _mapper.Map<List<Distributor_For_Registration_Dto>>(result);
        }

        public void Update_Distributor(Distributor_For_Registration_Dto distributor)
        {
            var dis = _mapper.Map<Distributor>(distributor);;
        
            _unitOfWork_Identity.distributors.Update_Distributor(dis);

            _unitOfWork_Identity.save();
        }
    }
}