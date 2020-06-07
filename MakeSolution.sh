#! /bin/bash

PRODUCT_NAME="DDDSample"

PROJECT_DOMAIN=${PRODUCT_NAME}.DomainModel
PROJECT_TEST=${PRODUCT_NAME}Test.Test
PROJECT_INFRASTRUCTURE=${PRODUCT_NAME}.Infrastructure

#### DOMAINモデル　プロジェクトの作成
dotnet new classlib -n ${PROJECT_DOMAIN}

#### Infrastructure プロジェクトの作成
dotnet new classlib -n ${PROJECT_INFRASTRUCTURE}
cd ${PROJECT_INFRASTRUCTURE}
dotnet add reference ../${PROJECT_DOMAIN}/${PROJECT_DOMAIN}.csproj
dotnet add package System.Data.SQLite
dotnet add package Dapper
dotnet add package Microsoft.Extensions.Configuration
cd ..

#### Create Test Project
dotnet new mstest -n ${PROJECT_TEST}
cd ${PROJECT_TEST}
dotnet add reference ../${PROJECT_DOMAIN}/${PROJECT_DOMAIN}.csproj
dotnet add reference ../${PROJECT_INFRASTRUCTURE}/${PROJECT_INFRASTRUCTURE}.csproj
dotnet add package Microsoft.Extensions.Configuration
dotnet add package moq
cd ..

#### Solutionの作成
dotnet new sln -n ${PRODUCT_NAME}
dotnet sln add ${PROJECT_DOMAIN}/${PROJECT_DOMAIN}.csproj
dotnet sln add ${PROJECT_TEST}/${PROJECT_TEST}.csproj
dotnet sln add ${PROJECT_INFRASTRUCTURE}/${PROJECT_INFRASTRUCTURE}.csproj
