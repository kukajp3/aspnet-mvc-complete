CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Fornecedores" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Fornecedores" PRIMARY KEY,
    "Nome" varchar(200) NOT NULL,
    "Documento" varchar(14) NOT NULL,
    "TipoFornecedor" INTEGER NOT NULL,
    "Ativo" INTEGER NOT NULL
);

CREATE TABLE "Enderecos" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Enderecos" PRIMARY KEY,
    "FornecedorId" TEXT NOT NULL,
    "Logradouro" varchar(200) NOT NULL,
    "Numero" varchar(50) NOT NULL,
    "Complemento" varchar(250) NULL,
    "Cep" varchar(8) NOT NULL,
    "Bairro" varchar(100) NOT NULL,
    "Cidade" varchar(100) NOT NULL,
    "Estado" varchar(50) NOT NULL,
    CONSTRAINT "FK_Enderecos_Fornecedores_FornecedorId" FOREIGN KEY ("FornecedorId") REFERENCES "Fornecedores" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "Produtos" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Produtos" PRIMARY KEY,
    "FornecedorId" TEXT NOT NULL,
    "Nome" varchar(200) NOT NULL,
    "Descricao" varchar(1000) NOT NULL,
    "Imagem" varchar(100) NOT NULL,
    "Valor" TEXT NOT NULL,
    "DataCadastro" TEXT NOT NULL,
    "Ativo" INTEGER NOT NULL,
    CONSTRAINT "FK_Produtos_Fornecedores_FornecedorId" FOREIGN KEY ("FornecedorId") REFERENCES "Fornecedores" ("Id") ON DELETE RESTRICT
);

CREATE UNIQUE INDEX "IX_Enderecos_FornecedorId" ON "Enderecos" ("FornecedorId");

CREATE INDEX "IX_Produtos_FornecedorId" ON "Produtos" ("FornecedorId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20201018070011_Initial', '3.1.9');

