insert into communal_services.type_of_consumer(type_of_consumer.id, type_of_consumer.name) values (0, "Администратор"); 
insert into communal_services.type_of_consumer(type_of_consumer.id, type_of_consumer.name) values (1, "Клиент"); 

insert into communal_services.type_of_service(type_of_service.name, type_of_service.cost) values ("Газоснабжение", 150); 
insert into communal_services.type_of_service(type_of_service.name, type_of_service.cost) values ("Водоснабжение", 50); 
insert into communal_services.type_of_service(type_of_service.name, type_of_service.cost) values ("Капитальный ремонт", 25); 
insert into communal_services.type_of_service(type_of_service.name, type_of_service.cost) values ("Электроснабжение", 350); 
insert into communal_services.type_of_service(type_of_service.name, type_of_service.cost) values ("Обслуживание лифта", 15); 

insert into communal_services.address_register(address_register.street, address_register.house, address_register.flat) values ("Советская", "15", 5);
insert into communal_services.address_register(address_register.street, address_register.house, address_register.flat) values ("Минская", "2Б", 13);
insert into communal_services.address_register(address_register.street, address_register.house, address_register.flat) values ("Ломоносовский проспект", "153", 2);
insert into communal_services.address_register(address_register.street, address_register.house, address_register.flat) values ("Таганская", "25", 308);
insert into communal_services.address_register(address_register.street, address_register.house, address_register.flat) values ("Карла Маркса", "58", 18);
insert into communal_services.address_register(address_register.street, address_register.house, address_register.flat) values ("5-ой Танковой Армии", "46Б", 1);
insert into communal_services.address_register(address_register.street, address_register.house, address_register.flat) values ("Переверткина", "15", 5);

insert into communal_services.credentials(credentials.login, credentials.password) values ("123", "123");
insert into communal_services.credentials(credentials.login, credentials.password) values ("test1", "test");
insert into communal_services.credentials(credentials.login, credentials.password) values ("test2", "test");
insert into communal_services.credentials(credentials.login, credentials.password) values ("admin", "admin");

insert into communal_services.consumer(consumer.name, consumer.surname, consumer.address_register_id, consumer.credentials_id, consumer.type_of_consumer_id) 
				values ("Петров", "Петр", 1, 1, 1);
                
insert into communal_services.consumer(consumer.name, consumer.surname, consumer.address_register_id, consumer.credentials_id, consumer.type_of_consumer_id) 
				values ("Иванов", "Иван", 2, 2, 1);
                
insert into communal_services.consumer(consumer.name, consumer.surname, consumer.address_register_id, consumer.credentials_id, consumer.type_of_consumer_id) 
				values ("Сидоров", "BLM", 3, 3, 1);
                
insert into communal_services.consumer(consumer.name, consumer.surname, consumer.address_register_id, consumer.credentials_id, consumer.type_of_consumer_id) 
				values ("Admin", "Admin", 4, 4, 0);
                
insert into communal_services.consumer_card(consumer_card.consumer_id, consumer_card.type_of_service_id, consumer_card.date_of_pay) values (1, 1, TIMESTAMP(curdate(), curtime()));
insert into communal_services.consumer_card(consumer_card.consumer_id, consumer_card.type_of_service_id, consumer_card.date_of_pay) values (1, 2, TIMESTAMP(curdate(), curtime()));
insert into communal_services.consumer_card(consumer_card.consumer_id, consumer_card.type_of_service_id, consumer_card.date_of_pay) values (1, 3, TIMESTAMP(curdate(), curtime()));
insert into communal_services.consumer_card(consumer_card.consumer_id, consumer_card.type_of_service_id, consumer_card.date_of_pay) values (2, 1, TIMESTAMP(curdate(), curtime()));
insert into communal_services.consumer_card(consumer_card.consumer_id, consumer_card.type_of_service_id, consumer_card.date_of_pay) values (2, 2, TIMESTAMP(curdate(), curtime()));

insert into communal_services.payments(payments.deadline, payments.consumer_card_id, payments.payed) values (TIMESTAMP(curdate(), curtime()), 1, 150);
insert into communal_services.payments(payments.deadline, payments.consumer_card_id, payments.payed) values (TIMESTAMP(curdate(), curtime()), 2, 50);
insert into communal_services.payments(payments.deadline, payments.consumer_card_id, payments.payed) values (TIMESTAMP(curdate(), curtime()), 3, 10);
insert into communal_services.payments(payments.deadline, payments.consumer_card_id, payments.payed) values (TIMESTAMP(curdate(), curtime()), 4, 150);
insert into communal_services.payments(payments.deadline, payments.consumer_card_id, payments.payed) values (TIMESTAMP(curdate(), curtime()), 5, 0);

insert into communal_services.phone_number(phone_number.value, phone_number.consumer_id) values ("+7 888 150 25 25", 1); 
insert into communal_services.phone_number(phone_number.value, phone_number.consumer_id) values ("2 55 55 55", 1); 
insert into communal_services.phone_number(phone_number.value, phone_number.consumer_id) values ("+7 777 777 77 77", 2); 
insert into communal_services.phone_number(phone_number.value, phone_number.consumer_id) values ("+7 999 999 99 99", 3); 