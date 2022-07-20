CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

DROP TABLE artists;
CREATE TABLE IF NOT EXISTS artists (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  dateOfBirth INT NOT NULL,
  isAlive TINYINT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,

  FOREIGN KEY (creatorId)
    REFERENCES accounts(id)
    ON DELETE CASCADE

) default charset utf8;



/* SECTION fun with MySQL */

/* CREATE */
INSERT INTO artists
(name, dateOfBirth, isAlive)
VALUES
("Albert Einstein", 1879, true);

/* GET ALL */
SELECT * FROM artists;

/* GET BY ID */
SELECT * FROM artists WHERE id = 3;

/* Search */
SELECT * FROM artists WHERE name LIKE "%Leonardo%";


/* EDIT */
UPDATE artists
 SET
  isAlive = false,
  name = "Robert Ross"
WHERE id=4;


/* DELETE */
DELETE FROM artists WHERE id = 3 LIMIT 1;





/* SECTION DANGER ZONE!!! */
/* With no WHERE statement all values will be deleted */
DELETE FROM artists;

/* Remove entire table and all data*/
DROP TABLE artists;

/* Remove entire DB */
DROP DATABASE;



      SELECT
        a.*,
        acts.*
      FROM artists a
      JOIN accounts acts ON acts.id = a.creatorId;