::docker login -u atomaszewski

docker images

::docker tag zsutpwpatternswebapplicationblazorserver:latest atomaszewski/application:webapplicationblazorserver

::docker rmi zsutpwpatternswebapplicationblazorserver:latest

docker rmi atomaszewski/application:webapplicationblazorserver

docker build -f ZsutPwPatterns.WebApplication.BlazorServer/Dockerfile.dev -t atomaszewski/application:webapplicationblazorserver .

docker images

docker image ls --filter label=stage=webapplicationblazorserver_build

docker image prune --filter label=stage=webapplicationblazorserver_build

docker push atomaszewski/application:webapplicationblazorserver

::docker rmi atomaszewski/application:webapplicationblazorserver

docker images

::docker logout

pause
