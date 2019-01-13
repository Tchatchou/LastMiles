namespace Data_Base.Data_Transfer_Objects
{
    public class User_Logged_Dto
    {
        public string token { get; set; }

        public User_For_Registration_Dto user { get; set; } 
    }
}