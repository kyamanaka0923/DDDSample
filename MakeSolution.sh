#! /bin/bash

PRODUCT_NAME="DDDSample"

PROJECT_DOMAIN=${PRODUCT_NAME}.DomainModel
PROJECT_TEST=${PRODUCT_NAME}Test.Test

dotnet new classlib -n ${PROJECT_DOMAIN}
dotnet new mstest -n ${PROJECT_TEST}

cd ${PROJECT_TEST}

dotnet add reference ../${PROJECT_DOMAIN}/${PROJECT_DOMAIN}.csproj

cd ..

dotnet new sln -n ${PRODUCT_NAME}
dotnet sln add ${PROJECT_DOMAIN}/${PROJECT_DOMAIN}.csproj
dotnet sln add ${PROJECT_TEST}/${PROJECT_TEST}.csproj
