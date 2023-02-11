use LearningMath;
CREATE TABLE users
(
	user_id INT IDENTITY(1,1) NOT NULL,
	login varchar(50) NOT NULL,
	passw varchar(20) NOT NULL,
	acc_type varchar(20) NOT NULL,
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

INSERT users VALUES ('kesha', 'pass', 'student');
INSERT users VALUES ('kepka', '123', 'student');
INSERT users VALUES ('misha', '123', 'student');
INSERT users VALUES ('aleks', '1234', 'teacher');
INSERT users VALUES ('admin', 'admin', 'admin');
INSERT results VALUES (1, 'Сложение и вычитание отрицательных чисел', 7);
INSERT results VALUES (1, 'Сложение и вычитание отрицательных чисел', 2);
INSERT results VALUES (1, 'Сложение и вычитание отрицательных чисел', 8);
INSERT results VALUES (2, 'Сложение и вычитание отрицательных чисел', 9);
INSERT results VALUES (2, 'Сложение и вычитание отрицательных чисел', 10);
INSERT results VALUES (2, 'Сложение и вычитание отрицательных чисел', 2);
INSERT results VALUES (3, 'Сложение и вычитание отрицательных чисел', 5);
INSERT results VALUES (3, 'Сложение и вычитание отрицательных чисел', 6);
INSERT results VALUES (3, 'Сложение и вычитание отрицательных чисел', 8);