using MbDB.Entities;

public class CanEditOnlyNewOrdersBusinessRule
{
    public static void Validation(Order order)
    {
        if (order.Status != OrderStatus.New)
        {
            throw new ApplicationException("Only NEW orders can be edited!");
        }
    }
}