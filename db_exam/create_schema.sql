create schema db_exam;

create table db_exam.emp
(
    emp_no      int PRIMARY KEY NOT NULL,
    emp_name    varchar(50)     NOT NULL,
    emp_sal     int             NOT NULL check ( emp_sal > 0 ),
    emp_dept_no int
);

create table db_exam.dept
(
    dept_no     int PRIMARY KEY NOT NULL,
    dept_mng_no int             NOT NULL
);

alter table only db_exam.emp
    add constraint emp_dept_no_fk FOREIGN KEY (emp_dept_no) REFERENCES db_exam.dept (dept_no) ON
        UPDATE CASCADE
        ON
            DELETE
            CASCADE;

alter table only db_exam.dept
    add constraint dept_mng_no_fk FOREIGN KEY (dept_mng_no) REFERENCES db_exam.emp (emp_no) ON
        UPDATE CASCADE
        ON
            DELETE
            CASCADE;