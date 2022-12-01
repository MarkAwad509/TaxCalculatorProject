FROM mysql:latest

ENV MYSQL_ROOT_PASSWORD=Admin22!

EXPOSE 3306

COPY taxdb.sql /docker-entrypoint-initdb.d/

# build cmd
# docker build --rm -t taxdb-mysql:latest .

# run cmd
# docker run --rm --name taxdb-sql -p 3306:3306 taxdb-mysql
# docker run --name taxdb-sql-net --network taxing-network -e MYSQL_ROOT_PASSWORD=Admin22! -e MYSQL_DATABASE=TaxDB -e MYSQL_PASSWORD=Admin22! -p 6033:3306 -d taxdb-mysql