using AutoMapper;
using CarDealership.API.Entities;
using CarDealership.API.DTOs;

public class AutoMapperPurchase : Profile
{
    public AutoMapperPurchase()
    {
        CreateMap<PurchaseOrderEntity, PurchaseOrderDTO>();
        CreateMap<CreatePurchaseOrderDTO, PurchaseOrderEntity>();
        CreateMap<UpdatePurchaseOrderDTO, PurchaseOrderEntity>();
    }
}