# prime-numbers-microservice
Prime Numbers Microservice
<br><br>
Instructions to run in container
<br>
#open a terminal in the solution folder
<br>
docker build -f PrimeNumbersMicroservice/Dockerfile -t primenumbersmicroservice:final .
<br>
docker run -d -p 8080:80 --name PrimeNumbersMicroservice primenumbersmicroservice:final
<br>
#access the service on http://localhost:8080/swagger/index.html
<br><br>
#OR
<br>
#open a terminal in the solution folder
<br>
docker-compose up -d