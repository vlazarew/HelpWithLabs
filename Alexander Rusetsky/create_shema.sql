drop schema test CASCADE ;

create schema test;

create table test.main_table
(
    client_id bigint NOT NULL,
    date      date   NOT NULL,
    value     float
);

ALTER TABLE ONLY test.main_table
    ADD CONSTRAINT main_table_pk PRIMARY KEY (client_id, date);