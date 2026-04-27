using FluentAssertions;
using Moq;
using ResilientOrders.Api.Models;
using ResilientOrders.Api.Services;
using Xunit;

namespace ResilientOrders.UnitTests;

// =====================================================================
//  ETAPA 1 — Testes Unitários (xUnit + Moq + FluentAssertions, padrão AAA)
//  Você deve completar 3 testes para o OrderService:
//    1) Cálculo correto do total com desconto válido
//    2) Desconto inválido (negativo) deve lançar ArgumentException
//    3) Pedido vazio deve lançar InvalidOperationException
//
//  Use o padrão AAA:
//    // Arrange  -> preparar dependências, mocks e dados de entrada
//    // Act      -> executar o método sob teste
//    // Assert   -> verificar resultado/comportamento com FluentAssertions
//
//  Dica: para PlaceOrder, mocke IOrderRepository.Save para devolver o
//        próprio Order recebido (use Returns<Order>(o => o)).
// =====================================================================

public class OrderServiceTests
{
    [Fact(DisplayName = "CalculateTotal: aplica desconto corretamente sobre o subtotal")]
    public void CalculateTotal_WithValidDiscount_ReturnsExpectedValue()
    {
        // Arrange
        // TODO: criar Mock<IOrderRepository> e instanciar OrderService

        // Act
        // TODO: chamar service.CalculateTotal(subtotal: 100m, discountRate: 0.10m)

        // Assert
        // TODO: usar FluentAssertions para verificar que o resultado é 90m
        Assert.Fail("Implementar teste — remover quando concluir.");
    }

    [Fact(DisplayName = "CalculateTotal: desconto negativo lança ArgumentException")]
    public void CalculateTotal_WithNegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        // TODO: instanciar OrderService com mock do repositório

        // Act
        // TODO: capturar a ação que chama CalculateTotal com discountRate negativo

        // Assert
        // TODO: validar com FluentAssertions:
        //       action.Should().Throw<ArgumentException>()
        //             .WithMessage("*entre 0 e 1*");
        Assert.Fail("Implementar teste — remover quando concluir.");
    }

    [Fact(DisplayName = "PlaceOrder: pedido sem itens lança InvalidOperationException")]
    public void PlaceOrder_WithEmptyItems_ThrowsInvalidOperationException()
    {
        // Arrange
        // TODO: criar mock<IOrderRepository>, instanciar OrderService
        //       e montar um CreateOrderRequest com Items = new List<OrderItem>()

        // Act
        // TODO: capturar a ação que chama service.PlaceOrder(request)

        // Assert
        // TODO: validar com FluentAssertions que InvalidOperationException foi lançada
        //       e que mockRepo.Verify(r => r.Save(It.IsAny<Order>()), Times.Never);
        Assert.Fail("Implementar teste — remover quando concluir.");
    }

    // -------------------------------------------------------------------
    //  DESAFIO BÔNUS (opcional) — escreva mais um teste cobrindo:
    //  PlaceOrder com itens válidos chama IOrderRepository.Save uma única
    //  vez e retorna um Order com Total calculado. Use Times.Once.
    // -------------------------------------------------------------------
}
