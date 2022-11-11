using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1.Controllers
{
    public class Connections
    {
        public void Create()
        {
            var user = new UserController();
            var account = new AccountController();
            var credit = new CreditController();
            var deposit = new DepositController();
            var transit = new TransitController();
            using var db = new ApplicationContext();

            Console.WriteLine("Вы хотите зарегистрироватся или вы уже регистрировались?\n" +
                "Введите 1 что бы зарегистрироватся\n" +
                "Введите 2 если вы уже зарегистрированы");

            var checkConvertio = int.TryParse(Console.ReadLine(), out int result);

            if (!checkConvertio)
            {
                throw new Exception("ошибка конвертации");
            }

            if (result == 1)
            {
                user.SetData(out List<User> userData);

                var id = userData.LastOrDefault()!.Id;

                account.GetAccountInfo(id);
                Console.WriteLine("Введите 1 если Кредит или 2 если Депозит 3 если Операция со своим счетом");
                var checkConvertion = int.TryParse(Console.ReadLine()?.Trim(), out int result1);

                if (!checkConvertion)
                {
                    throw new Exception("ошибка конвертации");
                }



                if (result1 == 1)
                {
                    credit.Create(id);
                }
                else if (result1 == 2)
                {
                    deposit.Create(id);
                }
                else if (result1 == 3)
                {
                    Console.WriteLine("Если хотите пополнить свой счет введите 1 если конвертировать то 2");
                    var check = int.TryParse(Console.ReadLine()?.Trim(), out int resultcon);

                    if (!check)
                    {
                        throw new Exception("Ошибка конвертации");
                    }
                    if (resultcon == 1)
                    {
                        account.OperationsAccaunt(id);
                    }
                    else if (resultcon == 2)
                    {
                        Console.WriteLine("Для начало пополните счет");
                        account.OperationsAccaunt(id);

                        transit.Transit(id);
                    }
                    account.GetAccountInfo(id);
                }


            }
            else if (result == 2)
            {
                var getdata = new UserServices();
                foreach (var u in getdata.GetData())
                {
                    Console.WriteLine($"id: {u.Id} \tuser name: {u.Name}");
                }

                Console.WriteLine("Введите id пользователя");
                var id = Guid.Parse(Console.ReadLine()!);
                user.Read(id);
                Console.WriteLine("Введите 1 если Кредит или 2 если Депозит 3 если Операция со своим счетом");
                var checkConvert = int.TryParse(Console.ReadLine(), out int resulte);

                if (!checkConvert)
                {
                    throw new Exception("Ошибка конвертации");
                }

                if (resulte == 1)
                {
                    Console.WriteLine("Хотите взять еще кредит то 1 или погасить кредит то 2");

                    var checkConvert1 = int.TryParse(Console.ReadLine()?.Trim(), out int resulte1);

                    if (!checkConvert)
                    {
                        throw new Exception("Ошибка конвертации");
                    }
                    if (result == 1)
                    {
                        credit.Create(id);
                    }
                    else
                    {
                        credit.Repayment(id);
                    }
                }
                else if (resulte == 2)
                {
                    deposit.Create(id);
                }
                else if (resulte == 3)
                {
                    account.GetAccountInfo(id);
                    transit.Transit(id);
                    account.GetAccountInfo(id);
                }
            }
        }
    }
}
