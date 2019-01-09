using System;
using System.Collections.Generic;

namespace Infrastructure.Communication.OrangeSMS
{
 
public class ServiceContract
{
    public string country { get; set; }
    public string service { get; set; }
    public string contractId { get; set; }
    public int availableUnits { get; set; }
    public DateTime expires { get; set; }
    public string scDescription { get; set; }
}

public class Contract
{
    public string service { get; set; }
    public string contractDescription { get; set; }
    public List<ServiceContract> serviceContracts { get; set; }
}

public class PartnerContracts
{
    public string partnerId { get; set; }
    public List<Contract> contracts { get; set; }
}

public class OrangeSMSBalance
{
    public PartnerContracts partnerContracts { get; set; }
}
}