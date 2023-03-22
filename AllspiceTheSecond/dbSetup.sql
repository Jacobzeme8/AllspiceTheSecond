CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS recipe(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(100) NOT NULL,
  instructions VARCHAR(500) NOT NULL,
  img VARCHAR(500) NOT NULL,
  catagory VARCHAR(100) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS ingredient(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  quantity VARCHAR(100) NOT NULL,
  recipeId INT NOT NULL,

  FOREIGN KEY (recipeId) REFERENCES recipe(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS favorite(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,

  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeId) REFERENCES recipe(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

INSERT INTO ingredient
(name, quantity, `recipeId`)
VALUES
('Cheerios', '1 cup', 1 );


INSERT INTO recipe
  (title, instructions, img, catagory, creatorId)
  VALUES
  ('Cheerios', 'Pour into Bowl, add Milk, enjoy while finishing the maze on the back of the box', 'https://hips.hearstapps.com/hmg-prod/images/breakfast-cereal-royalty-free-image-93271409-1537303311.jpg', 'cereal', '63ff78396579fcb516818724');

  INSERT INTO recipe 
  (title, instructions, img, catagory, creatorId)
  VALUES
  ('PeanutButter Tortilla', 'Spread PeanutButter on tortilla, roll up, consume', 'https://hips.hearstapps.com/hmg-prod/images/breakfast-cereal-royalty-free-image-93271409-1537303311.jpg', 'snack', '63ff78396579fcb516818724' );

  SELECT
  *
  FROM recipe
  JOIN accounts ON recipe.creatorId = accounts.id;