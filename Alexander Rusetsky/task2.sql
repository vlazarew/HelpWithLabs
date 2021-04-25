-- Обновим те записи, которые изначально value = null
--     Будем устанавливать такое value, что

update test.main_table main
-- Поиск последнего value != null
set value = (select main3.value
             from test.main_table main3
             where main3.client_id = main.client_id
--                Поиск последней даты с актуальным балансом
               and main3.date = (select max(main2.date)
                                 from test.main_table main2
                                 where not main2.value is null
                                   and main2.client_id = main.client_id
                                   and main.date > main2.date
                                 group by main2.client_id))
where main.value is null;
