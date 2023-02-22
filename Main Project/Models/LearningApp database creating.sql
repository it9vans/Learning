use LearningMath;
CREATE TABLE users
(
	user_id INT IDENTITY(1,1) NOT NULL,
	login varchar(50) NOT NULL,
	passw varchar(20) NOT NULL,
	acc_type varchar(20) NOT NULL,
	firstName varchar(20) NOT NULL,
	secondName varchar(50) NOT NULL,
	surname varchar(50) NOT NULL,
	PRIMARY KEY (user_id)
);

CREATE TABLE results
(
	res_id INT IDENTITY(1,1) NOT NULL,
	stud_id INT NOT NULL,
	theme varchar(50) NOT NULL,
	score INT NOT NULL,
	PRIMARY KEY (res_id),
	FOREIGN KEY (stud_id) REFERENCES users (user_id)
);

INSERT users VALUES ('kesha', 'pass', 'student', 'Алексей', 'Степанович', 'Мамедов');
INSERT users VALUES ('kepka', '123', 'student', 'Иван', 'Степанович', 'Саубуров');
INSERT users VALUES ('misha', '123', 'student', 'Евгений', 'Степанович', 'Бельников');
INSERT users VALUES ('aleks', '1234', 'teacher', 'Тимофей', 'Степанович', 'Моментов');
INSERT users VALUES ('admin', 'admin', 'admin', 'Админ', 'Админович', 'Админ');
INSERT results VALUES (1, 'Сложение и вычитание отрицательных чисел', 7);
INSERT results VALUES (1, 'Сложение и вычитание отрицательных чисел', 2);
INSERT results VALUES (1, 'Сложение и вычитание отрицательных чисел', 8);
INSERT results VALUES (2, 'Сложение и вычитание отрицательных чисел', 9);
INSERT results VALUES (2, 'Сложение и вычитание отрицательных чисел', 10);
INSERT results VALUES (2, 'Сложение и вычитание отрицательных чисел', 2);
INSERT results VALUES (3, 'Сложение и вычитание отрицательных чисел', 5);
INSERT results VALUES (3, 'Сложение и вычитание отрицательных чисел', 6);
INSERT results VALUES (3, 'Сложение и вычитание отрицательных чисел', 8);


GO
CREATE PROCEDURE UsersExtraCountProcedure AS
BEGIN
    SELECT Count(login) AS 'Пользователи на "ке"'
    FROM users
	WHERE login LIKE 'ke%'
END;

GO
CREATE PROCEDURE UsersTestsCountProcedure AS
BEGIN
    SELECT login, CONCAT(surname, firstName, secondName), COUNT(res_id) AS 'Тестов пройдено:' 
	FROM results 
	JOIN users ON results.stud_id=users.user_id 
	GROUP BY login, surname, firstName, secondName
END;

GO
CREATE PROCEDURE TestsOver4CountProcedure AS
BEGIN
    SELECT login, COUNT(*) AS 'Кол-во тестов с рез-ом > 4' 
	FROM results 
	JOIN users ON results.stud_id=users.user_id 
	GROUP BY login HAVING MIN(score) > 4
END;

