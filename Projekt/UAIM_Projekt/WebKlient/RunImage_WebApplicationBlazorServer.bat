::docker login -u atomaszewski

docker ps -a

docker start webapplication

docker ps 

docker images

docker pull atomaszewski/application:webapplicationblazorserver

docker run -d -p 8080:80 -p 44300:443 --name webapplication atomaszewski/application:webapplicationblazorserver

docker inspect webapplication

curl -X GET "http://localhost:8080/list_radzen"

pause

docker stop webapplication

docker rm webapplication

pause
