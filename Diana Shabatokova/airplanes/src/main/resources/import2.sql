insert into country (name)
values ('Россия');

insert into city (name, country_id)
values ('Москва', 1);

insert into city (name, country_id)
values ('Санкт-Петербург', 1);

insert into city (name, country_id)
values ('Калининград', 1);

insert into city (name, country_id)
values ('Казань', 1);

insert into city (name, country_id)
values ('Воронеж', 1);

insert into airport (city_id, name, short_name)
values (1, 'Шереметьево', 'SVO');

insert into airport (city_id, name, short_name)
values (1, 'Домодедово', 'DME');

insert into airport (city_id, name, short_name)
values (1, 'Внуково', 'VKO');

insert into airport (city_id, name, short_name)
values (2, 'Пулково', 'LED');

insert into airport (city_id, name, short_name)
values (3, 'Храброво', 'KGD');

insert into airport (city_id, name, short_name)
values (4, 'Казань', 'KZN');

insert into airport (city_id, name, short_name)
values (5, 'Воронеж', 'VOZ');

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1621071946, 15000, 1621082746, 4, 1);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620213000, 15000, 1620236100, 1, 5);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620205800, 25000, 1620210900, 1, 5);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620216600, 35000, 1620228900, 1, 5);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620297301, 35000, 1620327301, 1, 5);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620266100, 15000, 1620272100, 1, 2);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620273600, 30000, 1620279300, 2, 3);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620227400, 15000, 1620246900, 5, 6);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620285000, 35000, 1620297300, 5, 6);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620249000, 50000, 1620254100, 5, 6);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620285050, 50000, 1620385050, 6, 2);

insert into voyage(baggage_passed, fromTS, price, toTS, from_id, to_id)
values (false, 1620275000, 50000, 1620385050, 6, 1);