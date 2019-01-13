using System.Collections.Generic;
using AutoMapper;
using Data_Access_Layer.UnitOfWorks;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Identity_Management;

namespace Business_Layer.Identity
{
    public class Account_Queries : IAccount_Queries
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork_Identity _unitOfWork_Identity;

        public Account_Queries (IMapper mapper,IUnitOfWork_Identity unitOfWork_Identity)
        {
            _mapper = mapper;
            _unitOfWork_Identity = unitOfWork_Identity;
        }


        #region  Queries companies account
        public List<Company_For_Details_Dto> search_company_and_load_details_along(string company)
        {
             var result = new List<Company>();
        
                result= _unitOfWork_Identity.companies.search_company_and_load_details_along(company);           

         return  _mapper.Map<List<Company_For_Details_Dto>>(result);
        }

         #endregion
      
        #region  Queries distributors account 
        public Distributor_For_Details_Dto get_distributor_with_details(int distributor_id)
        {
              var result = new Distributor();
        
                result= _unitOfWork_Identity.distributors.get_distributor_with_details(distributor_id);           

             return  _mapper.Map<Distributor_For_Details_Dto>(result);
        }

        public List<Distributor_For_Details_Dto> search_distributors_without_loading_details(int? company_id, string distributorName)
        {
              var result = new List<Distributor>();
        
                result= _unitOfWork_Identity.distributors.search_distributors_without_loading_details(company_id,distributorName);           

         return  _mapper.Map<List<Distributor_For_Details_Dto>>(result);
        }

        #endregion
       
        #region  Queries retailers account 
        public List<Retailer_For_Registration_Dto> search_retailers_without_loading_details(string retailer)
        {
             var result = new List<Retailer>();
        
                result= _unitOfWork_Identity.retailers.search_retailers_without_loading_details(retailer);           

         return  _mapper.Map<List<Retailer_For_Registration_Dto>>(result);
        }

        public Retailer_For_Registration_Dto get_retailer_with_details(int retailer)
        {
            var result = new Retailer();
        
                result= _unitOfWork_Identity.retailers.get_retailer_with_details(retailer);           

         return  _mapper.Map<Retailer_For_Registration_Dto>(result);
        }

        #endregion

    }
}