using AutoMapper;
using Data_Access_Layer.UnitOfWorks;
using Data_Base.Data_Transfer_Objects;
using Data_Base.DB_Identity_Management;

namespace Business_Layer.Identity
{
    public class Account_Update :IAccount_Update
    {
         private readonly IMapper _mapper;
        private readonly IUnitOfWork_Identity _unitOfWork_Identity;

        public Account_Update (IMapper mapper,IUnitOfWork_Identity unitOfWork_Identity)
        {
            _mapper = mapper;
            _unitOfWork_Identity = unitOfWork_Identity;
        }

        public void update_company(Distributor_For_Registration_Dto distributor)
        {
            throw new System.NotImplementedException();
        }

        public void update_distributor(Distributor_For_Registration_Dto distributor)
        {
            var dis = _mapper.Map<Distributor>(distributor);;
        
            _unitOfWork_Identity.distributors.update_distributor(dis);

            _unitOfWork_Identity.save();
        }

        public void update_retailer_details(Retailer_For_Registration_Dto retailer)
        {
            throw new System.NotImplementedException();
        }

        public void update_retailer_gps_location(int retailer_id, string gps_x, string gps_y)
        {
            throw new System.NotImplementedException();
        }

        public void update_retailer_picture1(int retailer_id, string path1)
        {
            throw new System.NotImplementedException();
        }

        public void update_retailer_picture2(int retailer_id, string path2)
        {
            throw new System.NotImplementedException();
        }
    }
}