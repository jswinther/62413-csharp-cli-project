using System.Collections.Generic;

namespace DiscountsConsole.BusinessLogicLayer
{
    public interface IBusinessLogic
    {
        public void Run(Stack<string> args);
    }
}