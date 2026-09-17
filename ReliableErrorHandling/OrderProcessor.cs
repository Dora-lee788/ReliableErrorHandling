using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliableErrorHandling
{
        public class OrderProcessor
        {
            public void Process(string[] orders)
            {
                int processed = 0;
                int succeeded = 0;
                int skipped = 0;

                try
                {
                    foreach (string raw in orders)
                    {
                        processed++;

                        string[] parts = raw.Split(';');

                        if (parts.Length != 3)
                        {
                            Console.WriteLine("Пропущено (неверный формат): " + raw);
                            skipped++;
                            continue;
                        }

                        decimal price;
                        if (!decimal.TryParse(parts[1].Replace('.', ','), out price))
                        {
                            Console.WriteLine("Пропущено (цена не число): " + raw);
                            skipped++;
                            continue;
                        }

                        int quantity;
                        if (!int.TryParse(parts[2], out quantity))
                        {
                            Console.WriteLine("Пропущено (количество не число): " + raw);
                            skipped++;
                            continue;
                        }

                        if (price < 0)
                        {
                            try
                            {
                                throw new OrderProcessingException("Цена не может быть отрицательной: " + price);
                            }
                            catch (OrderProcessingException ex) when (ex.Message.Contains("Цена"))
                            {
                                Console.WriteLine("Пропущено (повреждённые данные): " + ex.Message);
                                skipped++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Обработано: " + parts[0] + ", цена: " + price + ", количество: " + quantity);
                            succeeded++;
                        }
                    }
                }
                finally
                {
                    Console.WriteLine("Итого обработано: " + processed + ", успешно: " + succeeded + ", пропущено: " + skipped);
                }
            }
        }
    }








