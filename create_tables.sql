CREATE TABLE IF NOT EXISTS PESSOA
 (
 	IDPESSOA SERIAL PRIMARY KEY,
 	NOME VARCHAR(100),
 	DOCUMENTO VARCHAR(20),
 	CELULAR VARCHAR(20)
 );

 CREATE TABLE IF NOT EXISTS PRODUTO
 (
 	IDPRODUTO SERIAL PRIMARY KEY,
 	NOME VARCHAR(100),
 	CODERP VARCHAR(10),
 	PRECO NUMERIC(10,2)
 );

 CREATE TABLE IF NOT EXISTS COMPRA
 (
 	IDCOMPRA SERIAL PRIMARY KEY,
 	IDPRODUTO INT,
 	IDPESSOA INT,
 	DATACOMPRA DATE,

 	CONSTRAINT FK_PESSOA_COMPRA FOREIGN KEY(IDPESSOA) REFERENCES PESSOA(IDPESSOA),
 	CONSTRAINT FK_PRODUTO_COMPRA FOREIGN KEY(IDPRODUTO) REFERENCES PRODUTO(IDPRODUTO)
 );
