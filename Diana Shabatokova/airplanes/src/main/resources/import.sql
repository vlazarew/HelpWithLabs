insert into airport (city, country, creation_date, creation_time, name, short_name)
values ('Москва', 'Россия', CURRENT_DATE(), CURRENT_TIME(), 'Шереметьево', 'SVO');

insert into airport (city, country, creation_date, creation_time, name, short_name)
values ('Москва', 'Россия', CURRENT_DATE(), CURRENT_TIME(), 'Домодедово', 'DME');

insert into airport (city, country, creation_date, creation_time, name, short_name)
values ('Москва', 'Россия', CURRENT_DATE(), CURRENT_TIME(), 'Внуково', 'VKO');

insert into airport (city, country, creation_date, creation_time, name, short_name)
values ('Санкт-Петербург', 'Россия', CURRENT_DATE, CURRENT_TIME, 'Пулково', 'LED');

insert into airport (city, country, creation_date, creation_time, name, short_name)
values ('Калининград', 'Россия', CURRENT_DATE, CURRENT_TIME, 'Храброво', 'KGD');

insert into airport (city, country, creation_date, creation_time, name, short_name)
values ('Казань', 'Россия', CURRENT_DATE, CURRENT_TIME, 'Казань', 'KZN');

insert into airport (city, country, creation_date, creation_time, name, short_name)
values ('Воронеж', 'Россия', CURRENT_DATE, CURRENT_TIME, 'Воронеж', 'VOZ');

insert into voyage(baggage_passed, from_date, from_time, price, to_date, to_time, from_id, to_id)
values (false, DATE('2021-05-05'), TIME('12:10:00'), 15000, DATE('2021-05-05'), TIME('15:35:00'), 4, 1);

insert into voyage(baggage_passed, from_date, from_time, price, to_date, to_time, from_id, to_id)
values (false, DATE('2021-05-05'), TIME('14:10:00'), 15000, DATE('2021-05-05'), TIME('20:35:00'), 1, 5);

insert into voyage(baggage_passed, from_date, from_time, price, to_date, to_time, from_id, to_id)
values (false, DATE('2021-05-06'), TIME('4:55:00'), 15000, DATE('2021-05-06'), TIME('6:35:00'), 1, 2);

insert into voyage(baggage_passed, from_date, from_time, price, to_date, to_time, from_id, to_id)
values (false, DATE('2021-05-06'), TIME('7:00:00'), 15000, DATE('2021-05-06'), TIME('8:35:00'), 2, 3);