FROM mcr.microsoft.com/mssql/server:2019-CU10-ubuntu-20.04

COPY data2.sql data2.sql
COPY setup_database.sh setup_database.sh
COPY entrypoint.sh entrypoint.sh
USER root
RUN ["chmod", "+x", "setup_database.sh"]
#initialise the database during build time
#RUN ./opt/mssql/bin/sqlservr & ./setup_database.sh
EXPOSE 1433
#initialise the database during run time 
CMD /bin/bash ./entrypoint.sh
