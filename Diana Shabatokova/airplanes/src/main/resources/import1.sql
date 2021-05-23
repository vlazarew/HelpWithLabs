insert into country (name )
values ('Россия', CURRENT_DATE(), CURRENT_TIME());

insert into city (name , country_id)
values ('Москва',  1);

insert into city (name , country_id)
values ('Санкт-Петербург',  1);

insert into city (name , country_id)
values ('Калининград',  1);

insert into city (name , country_id)
values ('Казань',  1);

insert into city (name , country_id)
values ('Воронеж',  1);

insert into airport (city_id , name, short_name)
values (1,  'Шереметьево', 'SVO');

insert into airport (city_id , name, short_name)
values (1,  'Домодедово', 'DME');

insert into airport (city_id , name, short_name)
values (1,  'Внуково', 'VKO');

insert into airport (city_id , name, short_name)
values (2, CURRENT_DATE, CURRENT_TIME, 'Пулково', 'LED');

insert into airport (city_id , name, short_name)
values (3, CURRENT_DATE, CURRENT_TIME, 'Храброво', 'KGD');

insert into airport (city_id , name, short_name)
values (4, CURRENT_DATE, CURRENT_TIME, 'Казань', 'KZN');

insert into airport (city_id , name, short_name)
values (5, CURRENT_DATE, CURRENT_TIME, 'Воронеж', 'VOZ');

insert into voyage(baggage_passed,  fromTS, price, toTS, from_id, to_id)
values (false, DATE('2021-05-05'), TIME('12:10:00'), 15000, DATE('2021-05-05'), TIME('15:35:00'), 4, 1);

insert into voyage(baggage_passed,  fromTS, price, toTS, from_id, to_id)
values (false, DATE('2021-05-05'), TIME('14:10:00'), 15000, DATE('2021-05-05'), TIME('20:35:00'), 1, 5);

insert into voyage(baggage_passed,  fromTS, price, toTS, from_id, to_id)
values (false, DATE('2021-05-05'), TIME('12:10:00'), 25000, DATE('2021-05-05'), TIME('13:35:00'), 1, 5);

insert into voyage(baggage_passed,  fromTS, price, toTS, from_id, to_id)
values (false, DATE('2021-05-05'), TIME('15:10:00'), 35000, DATE('2021-05-05'), TIME('18:35:00'), 1, 5);

insert into voyage(baggage_passed,  fromTS, price, toTS, from_id, to_id)
values (false, DATE('2021-05-06'), TIME('4:55:00'), 15000, DATE('2021-05-06'), TIME('6:35:00'), 1, 2);

insert into voyage(baggage_passed,  fromTS, price, toTS, from_id, to_id)
values (false, DATE('2021-05-06'), TIME('7:00:00'), 30000, DATE('2021-05-06'), TIME('8:35:00'), 2, 3);

insert into voyage(baggage_passed,  fromTS, price, toTS, from_id, to_id)
values (false, DATE('2021-05-05'), TIME('18:10:00'), 15000, DATE('2021-05-05'), TIME('23:35:00'), 5, 6);

insert into voyage(baggage_passed,  fromTS, price, toTS, from_id, to_id)
values (false, DATE('2021-05-06'), TIME('10:10:00'), 35000, DATE('2021-05-06'), TIME('13:35:00'), 5, 6);

insert into voyage(baggage_passed,  fromTS, price, toTS, from_id, to_id)
values (false, DATE('2021-05-06'), TIME('00:10:00'), 50000, DATE('2021-05-06'), TIME('01:35:00'), 5, 6);