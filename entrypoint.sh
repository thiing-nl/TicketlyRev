#!/bin/bash

set -e

until dotnet ef database update --configuration=Release; do
>&2 echo "SQL Server is starting up"
sleep 1
done