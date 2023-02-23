﻿create table Produto(
Id bigint identity(1,1) not null,
Descricao varchar(250) not null,
Situacao bit,
Fabricacao datetime2,
Validade datetime2,
FornecedorCodigo bigint,
Fornecedor varchar(100),
FornecedorCNPJ varchar(50)
constraint PK_Produto primary key (Id)
)
go