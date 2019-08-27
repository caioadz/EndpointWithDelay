#!/bin/bash

## Please don't judge me, this is just an exercise...

yum update -y

mkdir ./app

curl -Lo ./app/release.zip  "https://github.com/caioadz/EndpointWithDelay/releases/download/1.0/release.zip"

cd ./app

unzip release.zip

cd publish

dotnet EndpointWithDelay.dll --server.urls http://0.0.0.0:80
