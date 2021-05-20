insert into country (name, creation_date, creation_time)
values ('Россия', CURRENT_DATE(), CURRENT_TIME());

insert into city (name, creation_date, creation_time, country)
values ('Москва', CURRENT_DATE(), CURRENT_TIME(), 1);

insert into city (name, creation_date, creation_time, country)
values ('Санкт-Петербург', CURRENT_DATE(), CURRENT_TIME(), 1);

insert into city (name, creation_date, creation_time, country)
values ('Калининград', CURRENT_DATE(), CURRENT_TIME(), 1);

insert into city (name, creation_date, creation_time, country)
values ('Казань', CURRENT_DATE(), CURRENT_TIME(), 1);

insert into city (name, creation_date, creation_time, country)
values ('Воронеж', CURRENT_DATE(), CURRENT_TIME(), 1);

insert into airport (city, creation_date, creation_time, name, short_name)
values (1, CURRENT_DATE(), CURRENT_TIME(), 'Шереметьево', 'SVO');

insert into airport (city, creation_date, creation_time, name, short_name)
values (1, CURRENT_DATE(), CURRENT_TIME(), 'Домодедово', 'DME');

insert into airport (city, creation_date, creation_time, name, short_name)
values (1, CURRENT_DATE(), CURRENT_TIME(), 'Внуково', 'VKO');

insert into airport (city, creation_date, creation_time, name, short_name)
values (2, CURRENT_DATE, CURRENT_TIME, 'Пулково', 'LED');

insert into airport (city, creation_date, creation_time, name, short_name)
values (3, CURRENT_DATE, CURRENT_TIME, 'Храброво', 'KGD');

insert into airport (city, creation_date, creation_time, name, short_name)
values (4, CURRENT_DATE, CURRENT_TIME, 'Казань', 'KZN');

insert into airport (city, creation_date, creation_time, name, short_name)
values (5, CURRENT_DATE, CURRENT_TIME, 'Воронеж', 'VOZ');

insert into voyage(baggage_passed, from_date, from_time, price, to_date, to_time, from_id, to_id)
values (false, DATE('2021-05-05'), TIME('12:10:00'), 15000, DATE('2021-05-05'), TIME('15:35:00'), 4, 1);

insert into voyage(baggage_passed, from_date, from_time, price, to_date, to_time, from_id, to_id)
values (false, DATE('2021-05-05'), TIME('14:10:00'), 15000, DATE('2021-05-05'), TIME('20:35:00'), 1, 5);

insert into voyage(baggage_passed, from_date, from_time, price, to_date, to_time, from_id, to_id)
values (false, DATE('2021-05-06'), TIME('4:55:00'), 15000, DATE('2021-05-06'), TIME('6:35:00'), 1, 2);

insert into voyage(baggage_passed, from_date, from_time, price, to_date, to_time, from_id, to_id)
values (false, DATE('2021-05-06'), TIME('7:00:00'), 15000, DATE('2021-05-06'), TIME('8:35:00'), 2, 3);