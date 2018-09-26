#!/bin/bash

# 
# Import Jenkins Job
# 

java -jar /opt/jenkins-cli.jar -s http://localhost:8080/ create-job Docker < /vagrant/Docker-GitHub-Final.xml --username admin --password admin
java -jar /opt/jenkins-cli.jar -s http://localhost:8080/ build Docker --username admin --password admin
