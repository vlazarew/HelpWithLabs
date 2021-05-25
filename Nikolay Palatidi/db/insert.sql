insert into buildings.customer (contract_id, name, working_hours, type_of_payment, payment_amount) values (3325, 'ТОО "Корзина"', "24", 'Безнал', 1000000);
insert into buildings.customer (contract_id, name, working_hours, type_of_payment, payment_amount) values (11785, 'ТОО "Сокол"', "10", "Безнал", 653400);
insert into buildings.customer (contract_id, name, working_hours, type_of_payment, payment_amount) values (22478, 'ИП "Ильин"', "2", "Нал", 179000);
insert into buildings.customer (contract_id, name, working_hours, type_of_payment, payment_amount) values (50681, 'ИП "Кушенбаев"', "1", "Нал", 350000);
insert into buildings.customer (contract_id, name, working_hours, type_of_payment, payment_amount) values (101250, 'ТОО "777"', "8", "Безнал", 289000);

insert into buildings.building (name, type, year, customer_contract_id, location, building.condition, team)  values ('Корзина', 'Торговый центр', 2012, 3325, 'г.Темиртау, проспект Металлургов 25', "Выполнено", "Москаленко");
insert into buildings.building (building.name, building.type, building.year, customer_contract_id, location, building.condition, team)   values ('Комсомолец', 'Кинотеатр', 1973, 101250, 'г.Темиртау, проспект Комсомольский 20', "В стадии работы", "Москаленко");
insert into buildings.building (building.name, building.type, building.year, customer_contract_id, location, building.condition, team)  values ('Восток-Авто', 'Бутик', 2015, 22478, 'г.Темиртау, Калинина 26', "В разработке", "Худяков");
insert into buildings.building (building.name, building.type, building.year, customer_contract_id, location, building.condition, team)  values ('Ласточка', 'Ресторан', 2004, 11785, 'г.Темиртау, проспект Металлургов 60/1', "-", "Худяков");
insert into buildings.building (building.name, building.type, building.year, customer_contract_id, location, building.condition, team)  values ('Домик у Озера', 'Зона отдыха', 2005, 50681, 'г.Темиртау, район Черемушки', "В стадии работы", "Власов");

insert into buildings.office (office.name, building_names, customer_contract_id,payment)  values ('ТОО "Корзина"', 'Корзина', 3325, "Оплачено");
insert into buildings.office (office.name, building_names, customer_contract_id,payment)  values ('ТОО "Сокол"', 'Ласточка', 11785, "Оплачено");
insert into buildings.office (office.name, building_names, customer_contract_id,payment)  values ('ИП "Ильин"', 'Восток-Авто', 22478, "Ожидается оплата");
insert into buildings.office (office.name, building_names, customer_contract_id,payment)  values ('ИП "Кушенбаев"', 'Домик у Озера', 50681, "Взаимо оплата");
insert into buildings.office (office.name, building_names, customer_contract_id,payment)  values ('ТОО "777"', 'Комсомолец', 101250, "Оплачено");

insert into buildings.materials (building_type, materials_amount, type_of_materials, customer_contract_id)  values ('Торговый центр', '100', "Арматура", 3325);
insert into buildings.materials (building_type, materials_amount, type_of_materials, customer_contract_id)  values ('Ресторан', '800', "Плитка", 11785);
insert into buildings.materials (building_type, materials_amount, type_of_materials, customer_contract_id)  values ('Бутик', '25', "Краска", 22478);
insert into buildings.materials (building_type, materials_amount, type_of_materials, customer_contract_id)  values ('Зона отдыха', '100', "Бревна", 50681);
insert into buildings.materials (building_type, materials_amount, type_of_materials, customer_contract_id)  values ('Кинотеатр', '28000', "Цемент", 101250);