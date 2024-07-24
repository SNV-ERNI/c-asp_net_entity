using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealership.API.Data;
using CarDealership.API.DTOs;
using CarDealership.API.Entities;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrderController : ControllerBase
{
    private readonly DataContext _context;

    public PurchaseOrderController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllCar()
    {
        var purchaseOrders = _context.PurchaseOrderEntities
            .Include(po => po.Car)
            .Include(po => po.Customer)
            .Select(po => new
            {
                OrderID = po.OrderID,
                Car = new
                {
                    po.Car.VIN,
                    po.Car.Brand,
                    po.Car.Model,
                    po.Car.YearVersion,
                    po.Car.PlateNumber,
                    po.Car.CarType
                },
                Customer = new
                {
                    po.Customer.CustomerID,
                    po.Customer.LastName,
                    po.Customer.FirstName,
                    po.Customer.DateOfBirth,
                    po.Customer.Address,
                    po.Customer.PhoneNum
                }
            })
            .ToList();

        return Ok(purchaseOrders);
    }

    [HttpGet("{id}")]
    public IActionResult GetPurchaseOrder(int id)
    {
        var purchaseOrder = _context.PurchaseOrderEntities
            .Include(po => po.Car)
            .Include(po => po.Customer)
            .Where(po => po.OrderID == id)
            .Select(po => new
            {
                OrderID = po.OrderID,
                Car = new
                {
                    po.Car.VIN,
                    po.Car.Brand,
                    po.Car.Model,
                    po.Car.YearVersion,
                    po.Car.PlateNumber,
                    po.Car.CarType
                },
                Customer = new
                {
                    po.Customer.CustomerID,
                    po.Customer.LastName,
                    po.Customer.FirstName,
                    po.Customer.DateOfBirth,
                    po.Customer.Address,
                    po.Customer.PhoneNum
                }
            })
            .FirstOrDefault();

        if (purchaseOrder == null)
        {
            return NotFound();
        }

        return Ok(purchaseOrder);
    }

    [HttpPost]
    public async Task<ActionResult<CreatePurchaseOrderDTO>> PostPurchaseOrder(CreatePurchaseOrderDTO purchaseOrderDTO)
    {
        var purchaseOrder = new PurchaseOrderEntity
        {
            VIN = purchaseOrderDTO.VIN,
            CustomerID = purchaseOrderDTO.CustomerID
        };

        _context.PurchaseOrderEntities.Add(purchaseOrder);
        await _context.SaveChangesAsync();

        return Ok("Purchaes Order created!");

        //return CreatedAtAction(nameof(GetPurchaseOrder), new { id = purchaseOrder.OrderID }, purchaseOrderDTO);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCar(int id, [FromBody] UpdatePurchaseOrderDTO updatePurchaseDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var purchaseOrder = _context.PurchaseOrderEntities.FirstOrDefault(x => x.OrderID == id);

        if (purchaseOrder == null)
        {
            return NotFound();
        }

        try
        {

            purchaseOrder.VIN = updatePurchaseDTO.VIN;
            purchaseOrder.CustomerID = updatePurchaseDTO.CustomerID;

            _context.SaveChanges();
            var response = new
            {
                Message = $"Purchase Order {purchaseOrder.OrderID} has been successfully updated."
            };

            return Ok(response);
        }
        catch (Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] int id)
    {
        var purchaseOrder = await _context.PurchaseOrderEntities.FindAsync(id);
        if (purchaseOrder == null)
        {
            return NotFound();
        }

        _context.PurchaseOrderEntities.Remove(purchaseOrder);
        await _context.SaveChangesAsync();

        return Ok("Purchase Order deleted!");
    }
}
