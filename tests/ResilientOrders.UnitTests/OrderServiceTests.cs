using FluentAssertions;
using Moq;
using ResilientOrders.Api.Models;
using ResilientOrders.Api.Services;
using Xunit;

namespace ResilientOrders.UnitTests;

public class OrderServiceTests
{
    // ---------------------------------------------------------------
    //  TESTE 1 — Cálculo correto do total com desconto válido
    // ---------------------------------------------------------------
    [Fact(DisplayName = "CalculateTotal: aplica desconto corretamente sobre o subtotal")]
    public void CalculateTotal_WithValidDiscount_ReturnsExpectedValue()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        var service  = new OrderService(mockRepo.Object);

        // Act
        var result = service.CalculateTotal(subtotal: 100m, discountRate: 0.10m);

        // Assert
        result.Should().Be(90m);
    }

    // ---------------------------------------------------------------
    //  TESTE 2 — Desconto negativo lança ArgumentException
    // ---------------------------------------------------------------
    [Fact(DisplayName = "CalculateTotal: desconto negativo lança ArgumentException")]
    public void CalculateTotal_WithNegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        var service  = new OrderService(mockRepo.Object);

        // Act
        Action act = () => service.CalculateTotal(subtotal: 100m, discountRate: -0.5m);

        // Assert
        act.Should()
           .Throw<ArgumentException>()
           .WithMessage("*entre 0 e 1*");
    }

    // ---------------------------------------------------------------
    //  TESTE 3 — Pedido sem itens lança InvalidOperationException
    //            e garante que repository.Save NUNCA foi chamado
    // ---------------------------------------------------------------
    [Fact(DisplayName = "PlaceOrder: pedido sem itens lança InvalidOperationException")]
    public void PlaceOrder_WithEmptyItems_ThrowsInvalidOperationException()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        var service  = new OrderService(mockRepo.Object);

        var request = new PlaceOrderRequest
        {
            CustomerName = "Teste",
            Items        = new List<OrderItem>(),  // lista vazia — inválida
            DiscountRate = 0
        };

        // Act
        Action act = () => service.PlaceOrder(request);

        // Assert
        act.Should()
           .Throw<InvalidOperationException>()
           .WithMessage("*vazia*");

        // Verifica comportamento: Save nunca deve ser chamado
        mockRepo.Verify(r => r.Save(It.IsAny<Order>()), Times.Never);
    }

    }
