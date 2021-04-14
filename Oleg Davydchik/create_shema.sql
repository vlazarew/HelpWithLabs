create schema communal_services;

create table communal_services.type_of_service
(
    id   bigint      NOT NULL PRIMARY KEY,
    name varchar(50) NOT NULL
);

create table communal_services.address_register
(
    id     bigint      NOT NULL PRIMARY KEY,
    street varchar(50) NOT NULL,
#     Сделаю varchar, т.к. могут быть номера с литералами
    house  varchar(10) NOT NULL,
    flat   int         NOT NULL check ( flat > 1 ),

    CONSTRAINT address_unique UNIQUE (street, house, flat)
);

create table communal_services.consumer
(
    id           bigint      NOT NULL PRIMARY KEY,
    name         varchar(50) NOT NULL,
    surname      varchar(80) NOT NULL,
    phone_number varchar(11) NOT NULL,
    address_id   bigint      NOT NULL
# Думаю тут unique не нужен (может быть несколько квартир / номеров телефона)
);

create table communal_services.consumer_card
(
    id          bigint    NOT NULL PRIMARY KEY,
    consumer_id bigint    NOT NULL,
    service_id  bigint    NOT NULL,
    date_of_pay timestamp NOT NULL default CURRENT_TIMESTAMP
);

create table communal_services.payments
(
    id               bigint    NOT NULL PRIMARY KEY,
    consumer_card_id bigint    NOT NULL,
    deadline_ts      timestamp NOT NULL default CURRENT_TIMESTAMP
);


alter table communal_services.consumer
    add constraint address_fk FOREIGN KEY (address_id) REFERENCES communal_services.address_register (id)
        ON UPDATE CASCADE
        ON DELETE CASCADE;

alter table communal_services.consumer_card
    add constraint consumer_fk FOREIGN KEY (consumer_id) REFERENCES communal_services.consumer (id)
        ON UPDATE CASCADE
        ON DELETE CASCADE;

alter table communal_services.consumer_card
    add constraint service_fk FOREIGN KEY (service_id) REFERENCES communal_services.type_of_service (id)
        ON UPDATE CASCADE
        ON DELETE CASCADE;

alter table communal_services.payments
    add constraint consumer_card_fk FOREIGN KEY (consumer_card_id) REFERENCES communal_services.consumer_card (id)
        ON UPDATE CASCADE
        ON DELETE CASCADE;